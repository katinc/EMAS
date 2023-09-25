using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.All_UIs.Staff_Information_FORMS
{
    public partial class EmployeeRegistration : Form
    {
        Employee employee;
        IDAL dal;
        public EmployeeRegistration()
        {
            employee = new Employee();
            dal = new DAL();
            InitializeComponent();
            dal.OpenConnection();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.UpdateEmployeeEntity();
            try
            {
                if (!Exists(employee.StaffID))
                {
                    dal.Save(employee);
                    this.Clear();
                }
                else
                {
                    idErrorProvider.SetError(txtID, "The employee ID you have entered already exists");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool Exists(string staffNo)
        {
            bool result = true;
            if (dal.GetByID<Employee>(staffNo).StaffID  == string.Empty)
            {
                result = false;
            }
            return result;
        }

        #region ASSIGNMENT
        private void UpdateEmployeeEntity()
        {
            employee.StaffID = txtID.Text;
            employee.Surname = txtSurname.Text;
            employee.FirstName = txtFirstName.Text;
            employee.OtherName = txtOtherName.Text;
            employee.Title.Description = cmbTitle.Text;
            employee.DOB = dateDOB.Value;
            employee.Gender = cmbSex.Text;
            employee.Nationality.Description = cmbNationality.Text;
            employee.Religion.Description = cmbReligion.Text;
            employee.MaritalStatus = cmbMaritalStatus.Text;
            employee.HomeTown.Description = txtHomeTown.Text;
            employee.Address = txtAddress.Text;
            employee.TelNo = txtTelephone.Text;
            employee.MobileNo = txtMobile.Text;
            employee.Email = txtEmail.Text;
            employee.NoOfChildren = int.Parse(noOfChildrenNUD.Value.ToString());
            employee.Photo = pictureBox.Image;
            employee.POB.Description = txtPOB.Text;
            employee.EmploymentDate = DateTime.Parse(employmentDatePicker.Text);
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            txtID.Clear();
            txtSurname.Clear();
            txtFirstName.Clear();
            txtOtherName.Clear();
            cmbTitle.Text = string.Empty;
            dateDOB.Value = DateTime.Now;
            cmbSex.Text = string.Empty;
            cmbNationality.Text = string.Empty;
            cmbReligion.Text = string.Empty;
            cmbReligion.Text = string.Empty;
            txtNID.Clear();
            cmbMaritalStatus.Text = string.Empty;
            txtHomeTown.Clear();
            txtAddress.Clear();
            txtTelephone.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            cmbRegion.Text = string.Empty;
            noOfChildrenNUD.Value = 0;
            txtPOB.Clear();
            pictureBox.Image = pictureBox.InitialImage;
            idErrorProvider.Clear();
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel the registration", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Employee_Maintenance_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void pictureButton_Click(object sender, EventArgs e)
        {
            ShowPictureDialog();
        }

        public void ShowPictureDialog()
        {
            OpenFileDialog pictureDialog = new OpenFileDialog();
            pictureDialog.Multiselect = false;
            pictureDialog.RestoreDirectory = true;
            pictureDialog.Title = "Select A Picture";
            pictureDialog.AutoUpgradeEnabled = true;
            pictureDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            pictureDialog.Filter = "Image Files(*.JPE;*.JPEG;*.JFIF;*.JPG;*.EXIF;*.TIFF;*.TIF;*.PAW;*.PNG;*.GIF;*.BMP;*.PPM;*.PGM;*.PBM;*.PNM;*.CGM;*.SVG)|*.JPE;*.JPEG;*.JFIF;*.JPG;*.EXIF;*.TIFF;*.TIF;*.PAW;*.PNG;*.GIF;*.BMP;*.PPM;*.PGM;*.PBM;*.PNM;*.CGM;*.SVG|All Files(*.*)|*.*";
            pictureDialog.CheckFileExists = true;
            if (pictureDialog.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(pictureDialog.FileName);
            }
        }
    }
}
