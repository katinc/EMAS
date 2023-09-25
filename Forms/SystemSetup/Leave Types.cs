using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayer;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using eMAS.Forms.Reports;
using HRDataAccessLayerBase;
using HRBussinessLayer;
using HRBussinessLayer.System_Setup_Class;
using System.Configuration;

namespace eMAS.Forms.SystemSetup
{
    public partial class Leave_Types : Form
    {
        private LeaveType leaveType;
        private IList<LeaveType> leaveTypes;
        private IDAL dal;
        private bool found;
        private string connectionString;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;
        DataGridView oldDT;

        public Leave_Types()
        {
            try
            {
                InitializeComponent();
                this.leaveType = new LeaveType();
                this.leaveTypes = new List<LeaveType>();
                this.dal = new DAL();
                this.leaveType = new LeaveType();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Leave_Types_Load(object sender, EventArgs e)
        {
            try
            {
                string password = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(ConfigurationManager.AppSettings["dbPassword"]));
                connectionString = string.Format(ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString, password);
                this.Text = GlobalData.Caption;
                GetLeaves();
              //  GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Enabled = getPermissions.CanAdd;
                    deleteButton.Enabled = getPermissions.CanDelete;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }

                DataGridView oldGrid = new DataGridView();

                oldDT = GlobalData.CopyDataGridView(grid);

            }
            catch (Exception ex)
            
            {
                Logger.LogError(ex);
            }
        }

        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }

        private void GetLeaves()
        {
            try
            {
                try
                {
                    grid.Rows.Clear();
                    int ctr = 0;
                    foreach (LeaveType leaveType in dal.GetAll<LeaveType>())
                    {
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = leaveType.ID;
                        grid.Rows[ctr].Cells["gridDescription"].Value = leaveType.Description;
                        grid.Rows[ctr].Cells["gridMaximumEntitlement"].Value = leaveType.MaximumEntitlement;
                        grid.Rows[ctr].Cells["gridActive"].Value = leaveType.Active;
                        grid.Rows[ctr].Cells["gridUserID"].Value = leaveType.User.ID;
                        grid.Rows[ctr].Cells["gridCountHolidays"].Value = leaveType.CountHolidays;
                        grid.Rows[ctr].Cells["gridCountWeekends"].Value = leaveType.CountWeekends;
                        ctr++;
                    }
                    grid.ClearSelection();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(List<DataReference.LeaveTypeView> leaveTypes)
        {
            try
            {
                int ctr = 0;
               
                foreach (DataReference.LeaveTypeView leaveType in leaveTypes)
                {
                   
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = leaveType.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = leaveType.Description;
                    grid.Rows[ctr].Cells["gridMaximumEntitlement"].Value = leaveType.MaximumEntitlement;
                    grid.Rows[ctr].Cells["gridActive"].Value = leaveType.Active;
                    grid.Rows[ctr].Cells["gridUserID"].Value = leaveType.UserID;
                    grid.Rows[ctr].Cells["gridCountHolidays"].Value = leaveType.CountHolidays;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridDescription"].Value.ToString() + "'s leave?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //Archiving 
                    SqlCommand cmdUpdate = new SqlCommand("update leavetypes set archived='true' where ID=@ID", new SqlConnection(connectionString));


                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                    {
                        leaveType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());

                        //Archiving 
                        cmdUpdate.Parameters.AddWithValue("ID", leaveType.ID);
                        if (cmdUpdate.Connection.State == ConnectionState.Closed)
                            cmdUpdate.Connection.Open();

                        cmdUpdate.ExecuteNonQuery();

                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                    {
                        leaveType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());

                        //Archiving 
                        cmdUpdate.Parameters.AddWithValue("ID", leaveType.ID);
                        if (cmdUpdate.Connection.State == ConnectionState.Closed)
                            cmdUpdate.Connection.Open();

                        cmdUpdate.ExecuteNonQuery();

                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Unable to delete record\n Contact administrator");
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Description cannot be empty" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();

                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    int ctr = 0;
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            leaveType.MaximumEntitlement = (row.Cells["gridMaximumEntitlement"].Value!=null)?int.Parse(row.Cells["gridMaximumEntitlement"].Value.ToString()):0;
                            leaveType.Description = row.Cells["gridDescription"].Value.ToString();
                            leaveType.Active = (row.Cells["gridActive"].Value!=null)?bool.Parse(row.Cells["gridActive"].Value.ToString()):false;
                            leaveType.User.ID = GlobalData.User.ID;
                            leaveType.CountHolidays =(row.Cells["gridCountHolidays"].Value!=null)? bool.Parse(row.Cells["gridCountHolidays"].Value.ToString()):false;
                            leaveType.CountWeekends = (row.Cells["gridCountWeekends"].Value != null) ? bool.Parse(row.Cells["gridCountWeekends"].Value.ToString()) : false;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(leaveType);
                            }
                            else
                            {
                                var leaveId = int.Parse(row.Cells["gridID"].Value.ToString());

                                if (ConfigurationManager.AppSettings["RequestChanges"].ToLower() == "true")
                                {
                                    GlobalData.ProcessGridEdit(oldDT.Rows[ctr], row, leaveId, this);
                                }
                                else
                                {
                                    leaveType.ID = leaveId;
                                    //Updating the Leave Type
                                    SqlCommand cmdUpdate = new SqlCommand("update LeaveTypes set MaximumEntitlement=@MaximumEntitlement,Description=@Description,Active=@Active,CountHolidays=@CountHolidays,CountWeekends=@CountWeekends,DateModified=@DateModified where ID=@ID", new SqlConnection(connectionString));
                                    cmdUpdate.Parameters.AddWithValue("MaximumEntitlement", leaveType.MaximumEntitlement);
                                    cmdUpdate.Parameters.AddWithValue("Description", leaveType.Description);
                                    cmdUpdate.Parameters.AddWithValue("Active", leaveType.Active);
                                    cmdUpdate.Parameters.AddWithValue("CountHolidays", leaveType.CountHolidays);
                                    cmdUpdate.Parameters.AddWithValue("CountWeekends", leaveType.CountWeekends);
                                    cmdUpdate.Parameters.AddWithValue("DateModified", leaveType.DateModified);
                                    cmdUpdate.Parameters.AddWithValue("ID", leaveType.ID);

                                    if (cmdUpdate.Connection.State == ConnectionState.Closed)
                                        cmdUpdate.Connection.Open();

                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }
                        }
                        ctr++;
                    }
                    
                    //GetLeaves();
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }
    }
}
