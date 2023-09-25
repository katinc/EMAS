using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRBussinessLayer.Staff_Information_CLASS;

namespace eMAS.Forms.Employment
{
    public partial class EnrollFingerTemplate : Form
    {
        private MyStuff mineObj;
        private string[] ExcludeFingers;
        private int ID;
        private string StaffID;
        private string Name;
        private string UserType;
        public FingerprintTemplate template = new FingerprintTemplate();
        //Create Standalone SDK class dynamicly.
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        bool bIsConnected = false ;
        private int fingercount = 0;
        DataTable ConnectedDevices;
        public EnrollFingerTemplate()
        {
            InitializeComponent();
            mineObj = new MyStuff();
        }

        public EnrollFingerTemplate(int ID, string StaffID, string UserType ,string Name,params string[] ExcludeFingers):this()
        {
            this.ExcludeFingers = ExcludeFingers;
            this.StaffID = StaffID;
            this.Name = Name;
            this.ID = ID;
            this.UserType = UserType;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult  = DialogResult.Abort;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void EnrollFingerTemplate_Load(object sender, EventArgs e)
        {
            txtName.Text = this.Name;
            txtStaffID.Text = this.StaffID;

            DataTable tbl = mineObj.getFingerTypes(-1);

            for (int i = 0; i < tbl.Rows.Count;)
            {
                DataRow r = tbl.Rows[i];
                if (Array.IndexOf(ExcludeFingers, r["FingerType"]) > -1)
                {
                    tbl.Rows.Remove(r);
                }
                else
                {
                    i++;
                }
            }
           
            cmbFingerType.Items.Clear();
            cmbFingerType.DisplayMember = "FingerType";
            cmbFingerType.ValueMember = "ZktecMask";
            cmbFingerType.DataSource = tbl;

            ConnectedDevices = mineObj.getConnectedDevices();

            cmbConnectedDevices.Items.Clear();
            cmbConnectedDevices.DisplayMember = "Location";
            cmbConnectedDevices.ValueMember = "IPAddress";
            cmbConnectedDevices.DataSource = ConnectedDevices;

            if (ConnectedDevices.Rows.Count > 0)
            {
                btnStartEnrollment.Enabled = true;
            }            
        }

        private void btnStartEnrollment_Click(object sender, EventArgs e)
        {
            fingercount = 0;
            Cursor = Cursors.WaitCursor;
           
            int idwErrorCode = 0;
            if(!(bIsConnected))
            {
                bIsConnected = axCZKEM1.Connect_Net(cmbConnectedDevices.SelectedValue.ToString(), 4370);
                this.BringToFront();
            }           
            if (bIsConnected)
            {

                if (axCZKEM1.RegEvent(1, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                {
                    this.axCZKEM1.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
                    this.axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                    this.axCZKEM1.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
                 }

                axCZKEM1.CancelOperation();
                axCZKEM1.SSR_DelUserTmpExt(1, Convert.ToString(ID), Convert.ToInt32(cmbFingerType.SelectedValue));//If the specified index of user's templates has existed ,delete it first.(SSR_DelUserTmp is also available sometimes)
                if (axCZKEM1.SSR_SetUserInfo(1, Convert.ToString(ID), Name, null, 0, true))
                {
                    if (axCZKEM1.StartEnrollEx(Convert.ToString(ID), Convert.ToInt32(cmbFingerType.SelectedValue), 1))
                    {
                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate()
                        {
                            lblInfo.Text = string.Format("Capture {0} 3 times on Device to enroll", cmbFingerType.Text);
                        });
                        //lblInfo.Text = string.Format("Capture {0} 3 times on Device to enroll", cmbFingerType.Text);

                        //MessageBox.Show("Start to Enroll a new User,UserID=" + sUserID + " FingerID=" + iFingerIndex.ToString() + " Flag=" + iFlag.ToString(), "Start");
                        axCZKEM1.StartIdentify();//After enrolling templates,you should let the device into the 1:N verification condition

                    }
                    else
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
                    }
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    MessageBox.Show("User Information could not be set on the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                }
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            Cursor = Cursors.Default;
            //response = DialogResult.OK;
            //this.Close();
        }

        void axCZKEM1_OnFingerFeature(int Score)
        {
            try
            {
                if (Score > 60)
                {
                    fingercount++;

                    if (fingercount < 3)
                    {
                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lblInfo.Text = fingercount + " Template Taken.Please capture again"; });
                        //lblInfo.Text = fingercount + " Template Taken.Please capture again";
                    }
                }
            }
            catch(Exception ex)
            {
                this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lblInfo.Text = ex.Message; });
            }
        }

        void axCZKEM1_OnNewUser(int EnrollNumber)
        {
           // SetTemplate();
        }

        void axCZKEM1_OnEnrollFingerEx(string EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            SetTemplate();
        }

        private int getDeviceByIP(string IP)
        {
            int ID = 0;
            foreach (DataRow r in ConnectedDevices.Rows)
            {
                if (r["IPAddress"].ToString() == IP)
                {
                    ID= Int32.Parse( r["ID"].ToString());
                    break;
                }
            }

            return ID;
        }

        private void SetTemplate()
        {
            lblInfo.Text = "OnEnrollFingerEx Triggered";
            int flag = 0;
            int tempLength = 0;
            string byTmpData = "";
            if (axCZKEM1.GetUserTmpExStr(1, Convert.ToString(ID), Convert.ToInt32(cmbFingerType.SelectedValue), out flag, out byTmpData, out tempLength))
            {
                template.TmpLength = tempLength;
                template.Flag = flag;
                template.byTmpData = byTmpData;
                template.FingerType = Convert.ToInt16(cmbFingerType.SelectedValue);
                template.FingerTypeText = cmbFingerType.Text;
                
                this.DialogResult = DialogResult.OK;

                StaffFingerprintTemplates dbtemp = new StaffFingerprintTemplates();
                dbtemp.StaffID = StaffID;
                dbtemp.CreatedDate = DateTime.UtcNow;
                dbtemp.FingerType = template.FingerType;
                dbtemp.Template = template.byTmpData;
                dbtemp.TempLen = template.TmpLength;
                dbtemp.Flag = template.Flag;
                dbtemp.UserType = UserType;
                dbtemp.StaffMainID = ID;
                dbtemp.UserID = GlobalData.User.ID ;
                dbtemp.ID = new MyStuff().SaveFingerPrintTemplate(dbtemp,getDeviceByIP(cmbConnectedDevices.SelectedValue.ToString()));
                template.ID = dbtemp.ID;

                if (dbtemp.ID > 0)
                {
                    axCZKEM1.Disconnect();

                    this.axCZKEM1.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);          
                    this.axCZKEM1.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                    this.axCZKEM1.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);

                    this.Close();
                }
                this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate()
                {
                    lblInfo.Text = "Finger Enrolled Successfully";
                });

            }
            else
            {
                this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate()
                {
                    lblInfo.Text = "Finger could not be Enrolled";
                });
            }
        }

    }
}
