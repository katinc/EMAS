using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;

namespace eMAS.Forms.Notifications
{
    public partial class NotificationsForm : Form
    {
        DALHelper dalHelper;
        DataTable dtNotificationAlert;
        bool ediMode;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        //PleaseWait waitPls;
        public NotificationsForm()
        {
            InitializeComponent();
            dalHelper = new DALHelper();
            dtNotificationAlert = new DataTable();
            ediMode = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridNotificationReceivers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          //  waitPls = new PleaseWait();
            if (ediMode)
            {
                try
                {
                    if (e.RowIndex > -1 && e.ColumnIndex > -1 && gridNotificationReceivers.Columns[e.ColumnIndex].Name != "gridReceiveSMS" && gridNotificationReceivers.Columns[e.ColumnIndex].Name != "gridReceiveEmail")
                    {
                        Thread th = new Thread(() =>
                         {
                             try
                             {
                                 var staffID = gridNotificationReceivers.Rows[e.RowIndex].Cells["gridStaffID"].Value;

                                 if (staffID != null){
                                      getGridRecordByStaffID(staffID.ToString(), e.RowIndex);
                                    
                                 }
                                     
                                 else
                                 {
                                     ClearRow(e.RowIndex);
                                 }

                             }
                             catch (Exception ex) { }

                         });
                        th.Start();
                    }

                }
                catch (Exception ex)
                {
                    //Logger.LogError(ex);
                    //MessageBox.Show(this, "Data retrieval error!");
                }
            }
            if (!ediMode)
            {
                gridNotificationReceivers.AllowUserToAddRows = true;
                gridNotificationReceivers.Rows.Insert(gridNotificationReceivers.RowCount - 1, 1);
            }
        }


        private void getGridRecordByStaffID(string staffID,int RowIndex)
        {
           
            dalHelper.BeginTransaction();
            dalHelper.ClearParameters();
            dalHelper.CreateParameter("@staffID", staffID.Trim(), DbType.String);
            dalHelper.CreateParameter("@userID", GlobalData.User.ID, DbType.String);
            var dtStaff = dalHelper.ExecuteReader("select 0 as ID,info.StaffID,concat(rtrim(concat([Firstname],' ',[OtherName])),' ',[Surname]) as StaffName,info.Department,info.Telno,info.MobileNo,info.Email,isnull(rec.GetEmail,1) as 'GetEmail',isnull(rec.GetSMS,1) as 'GetSMS' from StaffPersonalInfoView info left outer join NotificationAlertReceivers rec on info.StaffID=rec.StaffID and info.UserID=@userID  where info.StaffID=@staffID and info.status='Regular' and info.archived=0");
            updatePopulateGrid(dtStaff.Rows[0], RowIndex);

            

            //gridNotificationReceivers.Refresh();
        }
        private void ClearRow(int RowIndex)
        {
           
            gridNotificationReceivers.Rows[RowIndex].Cells["gridID"].Value = null;
            gridNotificationReceivers.Rows[RowIndex].Cells["gridStaffName"].Value = null;
            gridNotificationReceivers.Rows[RowIndex].Cells["gridDepartment"].Value = null;
            gridNotificationReceivers.Rows[RowIndex].Cells["gridTel"].Value = null;
            gridNotificationReceivers.Rows[RowIndex].Cells["gridEmailAddress"].Value = null;

            gridNotificationReceivers.Rows[RowIndex].Cells["gridReceiveSMS"].Value = false;
            gridNotificationReceivers.Rows[RowIndex].Cells["gridReceiveEmail"].Value = false;

            gridNotificationReceivers.EndEdit();
            gridNotificationReceivers.Rows.RemoveAt(RowIndex);
            gridNotificationReceivers.Refresh();
           
        }
        private void updatePopulateGrid(DataRow dRow,int RowIndex)
        {
            try
            {
                if (RowIndex >= gridNotificationReceivers.Rows.Count)
                    RowIndex = gridNotificationReceivers.Rows.Add();
               

                    gridNotificationReceivers.Rows[RowIndex].Cells["gridID"].Value = dRow["ID"].ToString();
                    gridNotificationReceivers.Rows[RowIndex].Cells["gridStaffID"].Value = dRow["StaffID"].ToString();
                    gridNotificationReceivers.Rows[RowIndex].Cells["gridStaffName"].Value = dRow["StaffName"].ToString();
                    gridNotificationReceivers.Rows[RowIndex].Cells["gridDepartment"].Value = dRow["Department"].ToString();
                    gridNotificationReceivers.Rows[RowIndex].Cells["gridTel"].Value = dRow["MobileNo"].ToString();
                    gridNotificationReceivers.Rows[RowIndex].Cells["gridEmailAddress"].Value = dRow["Email"].ToString();

                    gridNotificationReceivers.Rows[RowIndex].Cells["gridReceiveSMS"].Value = bool.Parse(dRow["GetSMS"].ToString());
                    gridNotificationReceivers.Rows[RowIndex].Cells["gridReceiveEmail"].Value = bool.Parse(dRow["GetEmail"].ToString());
                
               }
            catch (Exception ex) { }
           }
        private void btnRemoveReceiver_Click(object sender, EventArgs e)
        {
            if (gridNotificationReceivers.SelectedRows.Count == 0)
                MessageBox.Show("No record is selected!");
            else if(MessageBox.Show(this,"Do you really want to delete record?","Conformation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                gridNotificationReceivers.Rows.Remove(gridNotificationReceivers.CurrentRow);
                dalHelper.ClearParameters();
                dalHelper.BeginTransaction();

                try
                {
                   
                    dalHelper.CreateParameter("@StaffID",gridNotificationReceivers.CurrentRow.Cells[1].Value.ToString(),DbType.Int32);

                    dalHelper.ExecuteNonQuery("");
                }
                catch (Exception ex)
                {
                    dalHelper.RollBackTransaction();
                }

            }
        }

        private void NotificationsForm_Load(object sender, EventArgs e)
        {
            try
            {
               
                
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@UserID",GlobalData.User.ID,DbType.Int32);
                    dtNotificationAlert = dalHelper.ExecuteReader("select top 1 * from NotificationAlerts  where UserID=@UserID");

                    chkLeaveOverDue.Checked = bool.Parse(dtNotificationAlert.Rows[0]["AlertLeave"].ToString());
                    chkProbationOverdue.Checked = bool.Parse(dtNotificationAlert.Rows[0]["AlertProbation"].ToString());
                    chkPensionOverdue.Checked = bool.Parse(dtNotificationAlert.Rows[0]["AlertPension"].ToString());

                    chkIsActive.Checked = bool.Parse(dtNotificationAlert.Rows[0]["IsActive"].ToString());
                    
                    chkLeaveNotifyRelatedStaff.Checked = bool.Parse(dtNotificationAlert.Rows[0]["LeaveNotifyRelatedStaff"].ToString());
                    chkProbationNotifyRelatedStaff.Checked = bool.Parse(dtNotificationAlert.Rows[0]["ProbationNotifyRelatedStaff"].ToString());
                    chkPensionNotifyRelatedStaff.Checked = bool.Parse(dtNotificationAlert.Rows[0]["PensionNotifyRelatedStaff"].ToString());

                    txtLeaveEmailCaption.Text = dtNotificationAlert.Rows[0]["LeaveEmailCaption"].ToString();
                    htmlTextBoxLeaveEmailMessage.Text = dtNotificationAlert.Rows[0]["LeaveEmailMessage"].ToString();
                    txtLeaveSMSMessage.Text = dtNotificationAlert.Rows[0]["LeaveSMSMessage"].ToString();

                    txtProbationEmailCaption.Text = dtNotificationAlert.Rows[0]["ProbationEmailCaption"].ToString();
                    htmlTextBoxProbationEmailMessage.Text = dtNotificationAlert.Rows[0]["ProbationEmailMessage"].ToString();
                    txtProbationSMSMessage.Text = dtNotificationAlert.Rows[0]["ProbationSMSMessage"].ToString();

                    txtPensionEmailCaption.Text = dtNotificationAlert.Rows[0]["PensionEmailCaption"].ToString();
                    htmlTextBoxPensionEmailMessage.Text = dtNotificationAlert.Rows[0]["PensionEmailMessage"].ToString();
                    txtPensionSMSMessage.Text = dtNotificationAlert.Rows[0]["PensionSMSMessage"].ToString();

                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.String);
                    var dtStaff = dalHelper.ExecuteReader("select rec.ID,info.StaffID,concat(rtrim(concat([Firstname],' ',[OtherName])),' ',[Surname]) as StaffName,info.Department,info.MobileNo,info.Email,isnull(rec.GetEmail,'true') as 'GetEmail',isnull(rec.GetSMS,'true') as 'GetSMS' from StaffPersonalInfoView info inner join NotificationAlertReceivers rec on rec.StaffID=info.StaffID where info.Status='regular' and info.archived='false' and rec.UserID=@UserID");
                   
                    int ctr = 0;
                    foreach (DataRow dRow in dtStaff.Rows)
                    {
                            updatePopulateGrid(dRow, ctr);
                            ctr++;
                    }
                    //gridNotificationReceivers.DataSource = dtStaff;

                    gridNotificationReceivers.AllowUserToAddRows = true ;

            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
            }
           
           
            
            ediMode = true;
            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnSave.Visible = getPermissions.CanAdd;
                btnRemoveReceiver.Visible = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }

            //gridNotificationReceivers.AllowUserToAddRows = false;
        }
        private void updateInsertAlertReceivers()
        {
            try
            {
                foreach (DataGridViewRow gridRow in gridNotificationReceivers.Rows)
                {
                    if (!gridRow.IsNewRow && gridRow.Cells["gridID"].Value!=null)
                    {
                        var ID = int.Parse(gridRow.Cells["gridID"].Value.ToString());
                        var StaffID = gridRow.Cells["gridStaffID"].Value.ToString();
                        var StaffName = gridRow.Cells["gridStaffName"].Value.ToString();
                        var GetSMS = gridRow.Cells["gridReceiveSMS"].Value.ToString();
                        var GetEmail = gridRow.Cells["gridReceiveEmail"].Value.ToString();
                        dalHelper.ClearParameters();


                        dalHelper.CreateParameter("@GetSMS", GetSMS, DbType.String);
                        dalHelper.CreateParameter("@GetEmail", GetEmail, DbType.String);
                        if (ID == 0)
                        {
                            dalHelper.CreateParameter("@StaffID", StaffID, DbType.String);
                            dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                            dalHelper.ExecuteNonQuery("Insert into NotificationAlertReceivers (StaffID,UserID,GetSMS,GetEmail) values(@StaffID,@UserID,@GetSMS,@GetEmail)");
                        }
                        else
                        {
                            dalHelper.CreateParameter("@ID", ID, DbType.Int32);
                            dalHelper.ExecuteNonQuery("update NotificationAlertReceivers set GetSMS=@GetSMS,GetEmail=@GetEmail where ID=@ID");
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkLeaveOverDue.Checked == false && chkPensionOverdue.Checked == false && chkProbationOverdue.Checked == false)
                MessageBox.Show("Please kindly check what you want to notify on!");
            else if (chkLeaveOverDue.Checked && htmlTextBoxLeaveEmailMessage.Text == string.Empty && txtLeaveSMSMessage.Text == string.Empty)
            {
                MessageBox.Show("Leave Email and SMS messages cannot be empty");
            }
            else if (chkProbationOverdue.Checked && htmlTextBoxProbationEmailMessage.Text == string.Empty && txtProbationSMSMessage.Text == string.Empty)
            {
                MessageBox.Show("Probation Email and SMS messages cannot be empty");
            }
            else if (chkPensionOverdue.Checked &&  htmlTextBoxPensionEmailMessage.Text == string.Empty && txtPensionSMSMessage.Text == string.Empty)
            {
                MessageBox.Show("Pension Email and SMS messages cannot be empty");
            }
            else if (txtLeaveEmailCaption.Text == string.Empty && htmlTextBoxLeaveEmailMessage.Text != string.Empty)
                MessageBox.Show("Email caption cannot be empty");
            else if(gridNotificationReceivers.Rows.Count==0)
                MessageBox.Show("Notification receiver list cannot be empty!");
            else
            {
                try
                {

               
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                dtNotificationAlert.Clear();
                 dtNotificationAlert=dalHelper.ExecuteReader("select top 1 * from NotificationAlerts  where UserID=@UserID");


                dalHelper.BeginTransaction();

                dalHelper.CreateParameter("@AlertProbation",chkProbationOverdue.Checked,DbType.Boolean);
                dalHelper.CreateParameter("@AlertPension", chkPensionOverdue.Checked, DbType.Boolean);
                dalHelper.CreateParameter("@AlertLeave", chkLeaveOverDue.Checked, DbType.Boolean);

                dalHelper.CreateParameter("@LeaveNotifyRelatedStaff", chkLeaveNotifyRelatedStaff.Checked, DbType.Boolean);
                dalHelper.CreateParameter("@ProbationNotifyRelatedStaff", chkProbationNotifyRelatedStaff.Checked, DbType.Boolean);
                dalHelper.CreateParameter("@PensionNotifyRelatedStaff", chkPensionNotifyRelatedStaff.Checked, DbType.Boolean);
                
                    
                    
               dalHelper.CreateParameter("@IsActive", chkIsActive.Checked, DbType.Boolean);

                dalHelper.CreateParameter("@LeaveEmailCaption", txtLeaveEmailCaption.Text, DbType.String);
                dalHelper.CreateParameter("@LeaveEmailMessage", htmlTextBoxLeaveEmailMessage.Text, DbType.String);

                dalHelper.CreateParameter("@LeaveSMSMessage", txtLeaveSMSMessage.Text, DbType.String);

                dalHelper.CreateParameter("@ProbationEmailCaption", txtProbationEmailCaption.Text, DbType.String);
                dalHelper.CreateParameter("@ProbationEmailMessage", htmlTextBoxProbationEmailMessage.Text, DbType.String);

                dalHelper.CreateParameter("@ProbationSMSMessage", txtProbationSMSMessage.Text, DbType.String);

                dalHelper.CreateParameter("@PensionEmailCaption", txtPensionEmailCaption.Text, DbType.String);
                dalHelper.CreateParameter("@PensionEmailMessage", htmlTextBoxPensionEmailMessage.Text, DbType.String);

                dalHelper.CreateParameter("@PensionSMSMessage", txtPensionSMSMessage.Text, DbType.String);

                if (dtNotificationAlert.Rows.Count > 0)
                {
                    dalHelper.ExecuteNonQuery("update NotificationAlerts set AlertProbation=@AlertProbation,AlertPension=@AlertPension,AlertLeave=@AlertLeave,IsActive=@IsActive,LeaveEmailCaption=@LeaveEmailCaption,LeaveEmailMessage=@LeaveEmailMessage,LeaveSMSMessage=@LeaveSMSMessage,ProbationEmailCaption=@ProbationEmailCaption,ProbationEmailMessage=@ProbationEmailMessage,ProbationSMSMessage=@ProbationSMSMessage,PensionEmailCaption=@PensionEmailCaption,PensionEmailMessage=@PensionEmailMessage,PensionSMSMessage=@PensionSMSMessage,LeaveNotifyRelatedStaff=@LeaveNotifyRelatedStaff,ProbationNotifyRelatedStaff=@ProbationNotifyRelatedStaff,PensionNotifyRelatedStaff=@PensionNotifyRelatedStaff where UserID=@UserID");
                }
                else
                {
                    dalHelper.ExecuteNonQuery("insert into NotificationAlerts (AlertProbation,AlertPension,AlertLeave,LeaveNotifyRelatedStaff,ProbationNotifyRelatedStaff,PensionNotifyRelatedStaff,IsActive,LeaveEmailCaption,LeaveEmailMessage,LeaveSMSMessage,ProbationEmailCaption,ProbationEmailMessage,ProbationSMSMessage,PensionEmailCaption,PensionEmailMessage,PensionSMSMessage,UserID) values(@AlertProbation,@AlertPension,@AlertLeave,@LeaveNotifyRelatedStaff,@ProbationNotifyRelatedStaff,@PensionNotifyRelatedStaff,@IsActive,@LeaveEmailCaption,@LeaveEmailMessage,@LeaveSMSMessage,@ProbationEmailCaption,@ProbationEmailMessage,@ProbationSMSMessage,@PensionEmailCaption,@PensionEmailMessage,@PensionSMSMessage,@UserID)");
                }
                updateInsertAlertReceivers();
                dalHelper.CommitTransaction();
                MessageBox.Show("Notification Parameters Saved Successfully!");
               }
               catch (Exception ex) {
                    Logger.LogError(ex);
                    dalHelper.RollBackTransaction();
                    MessageBox.Show("Unable to save notification details check and retry!");
                }

            }

        }

        private void chkLeaveOverDue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLeaveOverDue.Checked)
                tabNotifications.TabPages[0].Show();
            else
                tabNotifications.TabPages[0].Hide();
          
            
        }

        private void chkProbationOverdue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProbationOverdue.Checked)
                tabNotifications.TabPages[1].Show();
            else
                tabNotifications.TabPages[1].Hide();
        }

        private void chkPensionOverdue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPensionOverdue.Checked)
                tabNotifications.TabPages[1].Show();
            else
                tabNotifications.TabPages[1].Hide();

        }

        private void NotificationsForm_Shown(object sender, EventArgs e)
        {
           
        }

        


    }
}
