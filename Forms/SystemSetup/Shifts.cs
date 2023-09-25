using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;


namespace eMAS.Forms.SystemSetup
{
    public partial class Shifts : Form
    {
        DALHelper dal;
        IDAL idal;
        string idsToDelete;
        bool editMode;
        string shiftID;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public Shifts()
        {
            InitializeComponent();
            dal = new DALHelper();
            idal = new DAL();
            idsToDelete = string.Empty;
            editMode = false;
            shiftID = string.Empty;
            grid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(grid_EditingControlShowing);
        }

        void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            grid.CurrentCellDirtyStateChanged += new EventHandler(grid_CurrentCellDirtyStateChanged);
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grid.CurrentCell.ColumnIndex == gridCheckInTime.Index)
            {
                SetWorkHours();
            }
            if (grid.CurrentCell.ColumnIndex == gridCheckOutTime.Index)
            {
                SetWorkHours();
            }
        }

        private void GetBreakDuration()
        {
            try
            {
                if (grid.CurrentRow.Cells["gridCheckOutTime"].Value != null && grid.CurrentRow.Cells["gridCheckInTime"].Value != null && (DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()) >= DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString())))
                {
                    grid.CurrentRow.Cells["gridDuration"].Value = DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString()).Subtract(DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString())).Hours + "." + DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString()).Subtract(DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString())).Minutes;
                    SetWorkHours();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void Shifts_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            activeCheckBox.Checked = true;
          //  GlobalData.SetFormPermissions(this, idal, GlobalData.User.ID);

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                saveButton.Enabled = getPermissions.CanAdd;
                viewButton.Enabled = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }


        private void Clear()
        {
            errorProvider.Clear();
            nameTextBox.Clear();
            checkInTimePicker.Text = GlobalData.ServerDate.TimeOfDay.ToString();
            checkInTimePicker.Checked = false;
            checkOutTimePicker.Text = GlobalData.ServerDate.TimeOfDay.ToString();
            checkOutTimePicker.Checked = false;
            activeCheckBox.Checked = true;
            textBox1.Clear();
            grid.Rows.Clear();
            editMode = false;
            textBox2.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                dal.BeginTransaction();
                try
                {
                    string tempID = string.Empty;
                    
                    if (!editMode)
                    {
                        dal.ClearParameters();
                        dal.CreateParameter("@Name", nameTextBox.Text, DbType.String);
                        dal.CreateParameter("@CheckInTime", checkInTimePicker.Text, DbType.DateTime);
                        dal.CreateParameter("@CheckOutTime", checkOutTimePicker.Text, DbType.DateTime);
                        dal.CreateParameter("@Active", activeCheckBox.Checked, DbType.Boolean);
                        dal.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                        dal.CreateParameter("@Duration", textBox1.Text +"."+ textBox2.Text , DbType.Decimal);
                        dal.ExecuteNonQuery("Insert Into WorkShifts(Name,CheckInTime,CheckOutTime,Active,UserID,Duration) Values(@Name,@CheckInTime,@CheckOutTime,@Active,@UserID,@Duration)");
                        tempID = dal.ExecuteScalar("Select Max(ID) From WorkShifts").ToString();
                    }
                    else
                    {
                        dal.ClearParameters();
                        dal.CreateParameter("@ID", shiftID,DbType.Int32);
                        dal.CreateParameter("@Name", nameTextBox.Text, DbType.String);
                        dal.CreateParameter("@CheckInTime", checkInTimePicker.Text, DbType.DateTime);
                        dal.CreateParameter("@CheckOutTime", checkOutTimePicker.Text, DbType.DateTime);
                        dal.CreateParameter("@Active", activeCheckBox.Checked, DbType.Boolean);
                        dal.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                        dal.CreateParameter("@Duration", textBox1.Text + "." + textBox2.Text, DbType.Decimal);
                        dal.ExecuteNonQuery("Update WorkShifts Set Name=@Name,CheckInTime=@CheckInTime,CheckOutTime=@CheckOutTime,UserID=@UserID,Duration=@Duration,Active=@Active where ID = @ID");
                        tempID = shiftID;
                    }


                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.ClearParameters();
                                dal.CreateParameter("@ShiftID", tempID, DbType.Int32);
                                dal.CreateParameter("@CheckInTime", row.Cells["gridCheckInTime"].Value, DbType.DateTime);
                                dal.CreateParameter("@CheckOutTime", row.Cells["gridCheckOutTime"].Value, DbType.DateTime);
                                dal.CreateParameter("@Duration", row.Cells["gridDuration"].Value, DbType.String);
                                dal.CreateParameter("@Active", row.Cells["gridActive"].Value, DbType.Boolean);
                                dal.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                                dal.CreateParameter("@ShiftID", tempID, DbType.Int32);
                                dal.ExecuteNonQuery("Insert Into WorkShiftBreaks(ShiftID,CheckInTime,CheckOutTime,Active,Duration,UserID) Values(@ShiftID,@CheckInTime,@CheckOutTime,@Active,@Duration,@UserID)");
                            }
                            else
                            {
                                dal.ClearParameters();
                                dal.CreateParameter("@ID", tempID, DbType.Int32);
                                dal.CreateParameter("@ShiftID", row.Cells["gridShiftID"].Value, DbType.Int32);
                                dal.CreateParameter("@CheckInTime", DateTime.Parse(row.Cells["gridCheckInTime"].Value.ToString()), DbType.DateTime);
                                dal.CreateParameter("@CheckOutTime", DateTime.Parse(row.Cells["gridCheckOutTime"].Value.ToString()), DbType.DateTime);
                                dal.CreateParameter("@Duration", row.Cells["gridDuration"].Value, DbType.String);
                                dal.CreateParameter("@Active", row.Cells["gridActive"].Value, DbType.Boolean);
                                dal.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                                dal.ExecuteNonQuery("Update WorkShiftBreaks Set UserID=@UserID,ShiftID =@ShiftID,CheckInTime=@CheckInTime,CheckOutTime=@CheckOutTime,Active=@Active,Duration=@Duration Where ID=@ID");
                            }
                            if (editMode)
                            {
                                if (idsToDelete.Trim() != string.Empty)
                                {
                                    dal.ExecuteNonQuery("Delete From WorkShiftBreaks Where ID=" + idsToDelete.Substring(0, idsToDelete.Length - 1));
                                }
                            }
                        }
                    }
                    
                    dal.CommitTransaction();
                    Clear();
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    dal.RollBackTransaction();
                }
            }
        }


        private bool ValidateFields()
        {
            bool result = true;
            errorProvider.Clear();
            
            if (checkOutTimePicker.Value < checkInTimePicker.Value)
            {
                result = false;
                errorProvider.SetError(checkOutTimePicker, "The check out time must be greater than the check in time");
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (grid.CurrentRow.Cells["gridCheckOutTime"].Value != null && grid.CurrentRow.Cells["gridCheckInTime"].Value != null && (DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()) < DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString())))
                    {
                        result = false;
                        errorProvider.SetError(groupBox1, "The check out time for the break must be greater than the check in time");
                    }
                }
            }
            return result;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            ShiftsView shiftsView = new ShiftsView(this);
            shiftsView.Enabled = CanDelete;
            shiftsView.Show();
        }

        public void PopulateView(DataGridViewRow row)
        {
            nameTextBox.Text = row.Cells["Name"].Value.ToString();
            activeCheckBox.Checked = bool.Parse(row.Cells["Active"].Value.ToString());
            checkInTimePicker.Text = row.Cells["CheckInTime"].Value.ToString();
            checkOutTimePicker.Text = row.Cells["CheckOutTime"].Value.ToString();
            string[] duration = row.Cells["Duration"].Value.ToString().Split('.');
            textBox1.Text = duration[0];
            textBox2.Text = duration[1];
            shiftID = row.Cells["ID"].Value .ToString();

            try
            {
                int ctr = 0;
                grid.Rows.Clear();
                
                foreach (DataRow rowB in dal.ExecuteReader("Select * from WorkShiftBreaks where ShiftID = " + row.Cells["ID"].Value.ToString()).Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = rowB["ID"].ToString();
                    grid.Rows[ctr].Cells["gridShiftID"].Value = rowB["ShiftID"].ToString();
                    grid.Rows[ctr].Cells["gridCheckInTime"].Value = DateTime.Parse(rowB["CheckInTime"].ToString()).TimeOfDay;
                    grid.Rows[ctr].Cells["gridCheckOutTime"].Value = DateTime.Parse(rowB["CheckOutTime"].ToString()).TimeOfDay;
                    grid.Rows[ctr].Cells["gridDuration"].Value = rowB["Duration"].ToString();
                    grid.Rows[ctr].Cells["gridActive"].Value = rowB["Active"].ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = rowB["UserID"].ToString();
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            editMode = true;
        }

        private void checkOutTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetWorkHours();
            EnableBreaks();
        }

        private void SetWorkHours()
        {
            decimal workHours  = 0;
            decimal workMinutes = 0;
            decimal breakHours = 0;
            decimal breakMinutes = 0;
            if (checkOutTimePicker.Value >= checkInTimePicker.Value)
            {
                workHours = DateTime.Parse(checkOutTimePicker.Text).Subtract(DateTime.Parse(checkInTimePicker.Text)).Hours;
                workMinutes =  DateTime.Parse(checkOutTimePicker.Text).Subtract(DateTime.Parse(checkInTimePicker.Text)).Minutes;
                
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridCheckOutTime"].Value != null && row.Cells["gridCheckInTime"].Value != null)
                        {
                            if (DateTime.Parse(row.Cells["gridCheckOutTime"].Value.ToString()) >= DateTime.Parse(row.Cells["gridCheckInTime"].Value.ToString()))
                            {
                                breakHours = DateTime.Parse(row.Cells["gridCheckOutTime"].Value.ToString()).Subtract(DateTime.Parse(row.Cells["gridCheckInTime"].Value.ToString())).Hours;
                                breakMinutes = DateTime.Parse(row.Cells["gridCheckOutTime"].Value.ToString()).Subtract(DateTime.Parse(row.Cells["gridCheckInTime"].Value.ToString())).Minutes;

                                if (workMinutes >= breakMinutes)
                                {
                                    workHours -= breakHours;
                                    workMinutes -= breakMinutes;
                                }
                                else
                                {
                                    workHours = workHours - breakHours - 1;
                                    workMinutes = 60 - breakMinutes;
                                }
                                row.Cells["gridDuration"].Value = breakHours + " Hours " + breakMinutes + " Minutes ";
                            }
                            else
                                row.Cells["gridDuration"].Value = "N/A";
                        }
                        else
                            row.Cells["gridDuration"].Value = "N/A";
                    }
                }
                textBox1.Text = workHours.ToString();
                textBox2.Text = workMinutes.ToString();
            }
            else
                textBox1.Text ="N/A";
        }

        private void checkInTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SetWorkHours();
            EnableBreaks();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            EnableBreaks();
        }

        private void EnableBreaks()
        {
            if (nameTextBox.Text.Trim() != string.Empty)
            {
                groupBox1.Enabled = true;
            }
        }

    }
}
