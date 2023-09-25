using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;

namespace eMAS.Forms.SystemSetup
{
    public partial class RosterGroups : Form
    {
        private DALHelper dal;
        private IDAL idal;
        private DataTable shifts = new DataTable();
        private string shiftID;
        private bool editMode;
        private string rosterID;

        public RosterGroups()
        {
            try
            {
                InitializeComponent();
                dal = new DALHelper();
                idal = new DAL();
                editMode = false;
                rosterID = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void shiftComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                shifts = dal.ExecuteReader("Select * from WorkShifts where Archived='False'");
                shiftComboBox.Items.Clear();
                foreach (DataRow row in shifts.Rows)
                {
                    shiftComboBox.Items.Add(row["Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
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

        private void RosterGroups_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, idal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider1.Clear();

                if (nameTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider1.SetError(nameTextBox, "Please enter a name");
                }
                if (shiftComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider1.SetError(shiftComboBox, "Please select a shift");
                }
                if (!mondayCheckBox.Checked && !tuesdayCheckBox.Checked && !wednesdayCheckBox.Checked && !thursdayCheckBox.Checked && !fridayCheckBox.Checked && !saturdayCheckBox.Checked && !sundayCheckBox.Checked)
                {
                    result = false;
                    errorProvider1.SetError(mondayCheckBox, "At least one day must be selected");
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
                    if (!editMode)
                    {
                        dal.ClearParameters();
                        dal.CreateParameter("@ShiftID", shiftID, DbType.Int32);
                        dal.CreateParameter("@Name", nameTextBox.Text, DbType.String);
                        dal.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                        dal.ExecuteNonQuery("Insert Into RosterGroups(ShiftID,Name,UserID) Values(@ShiftID,@Name,@UserID)");
                        rosterID = dal.ExecuteScalar("Select Max(ID) From RosterGroups").ToString();

                        if (mondayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 2, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (tuesdayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 3, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (wednesdayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 4, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (thursdayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 5, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (fridayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 6, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (saturdayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 7, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (sundayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 1, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }

                    }
                    else
                    {
                        dal.ClearParameters();
                        dal.CreateParameter("@ID", rosterID, DbType.Int32);
                        dal.CreateParameter("@ShiftID", shiftID, DbType.Int32);
                        dal.CreateParameter("@Name", nameTextBox.Text, DbType.String);
                        dal.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                        dal.ExecuteNonQuery("Update RosterGroups Set ShiftID=@ShiftID,Name=@Name,UserID=@UserID Where ID =@ID");

                        dal.ClearParameters();
                        dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                        dal.ExecuteNonQuery("Delete from RoasterGroupDays Where RosterGroupID=@RosterGroupID");

                        if (mondayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 2, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (tuesdayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 3, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (wednesdayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 4, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (thursdayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 5, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (fridayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 6, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (saturdayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 7, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }
                        if (sundayCheckBox.Checked)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@RosterGroupID", rosterID, DbType.Int32);
                            dal.CreateParameter("@Day", 1, DbType.Int32);
                            dal.ExecuteNonQuery("Insert Into RoasterGroupDays(RosterGroupID,Day) Values(@RosterGroupID,@Day)");
                        }

                    }
                }
                clearButton_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            try
            {
                nameTextBox.Clear();
                shiftComboBox.Items.Clear();
                shiftComboBox.Text = string.Empty;
                mondayCheckBox.Checked = false;
                tuesdayCheckBox.Checked = false;
                wednesdayCheckBox.Checked = false;
                thursdayCheckBox.Checked = false;
                fridayCheckBox.Checked = false;
                saturdayCheckBox.Checked = false;
                sundayCheckBox.Checked = false;
                editMode = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            try
            {
                RosterGroupsView viewForm = new RosterGroupsView(this);
                viewForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void shiftComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow shift in shifts.Rows)
                {
                    if (shift["Name"].ToString().Trim() == shiftComboBox.Text.Trim())
                    {
                        shiftID = shift["ID"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void PopulateView(DataGridViewRow row)
        {
            try
            {
                shifts = dal.ExecuteReader("Select * from WorkShifts Where Archived='False'");
                shiftComboBox_DropDown(this, EventArgs.Empty);
                nameTextBox.Text = row.Cells["gridName"].Value.ToString();
                shiftComboBox.Text = row.Cells["gridShift"].Value.ToString();
                if (row.Cells["gridMonday"].Value != null)
                {
                    mondayCheckBox.Checked = true;
                }
                else
                {
                    mondayCheckBox.Checked = false;
                }
                if (row.Cells["gridTuesday"].Value != null)
                {
                    tuesdayCheckBox.Checked = true;
                }
                else
                {
                    tuesdayCheckBox.Checked = false;
                }
                if (row.Cells["gridWednesday"].Value != null)
                {
                    wednesdayCheckBox.Checked = true;
                }
                else
                {
                    wednesdayCheckBox.Checked = false;
                }
                if (row.Cells["gridThursday"].Value != null)
                {
                    thursdayCheckBox.Checked = true;
                }
                else
                {
                    thursdayCheckBox.Checked = false;
                }
                if (row.Cells["gridFriday"].Value != null)
                {
                    fridayCheckBox.Checked = true;
                }
                else
                {
                    fridayCheckBox.Checked = false;
                }
                if (row.Cells["gridSaturday"].Value != null)
                {
                    saturdayCheckBox.Checked = true;
                }
                else
                {
                    saturdayCheckBox.Checked = false;
                }
                if (row.Cells["gridSunday"].Value != null)
                {
                    sundayCheckBox.Checked = true;
                }
                else
                {
                    sundayCheckBox.Checked = false;
                }

                editMode = true;
                rosterID = row.Cells["gridID"].Value.ToString();
                shiftID = row.Cells["gridShiftID"].Value.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
    }
}
