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

namespace eMAS.Forms.TimeAndAttendance
{
    public partial class DutyRoster : Form
    {

        private DALHelper dal;
        private DataTable rosterGroupsTable;
        private string rosterGroupID;
        private string idsToDelete;
        private DataTable daysTable;

        public DutyRoster()
        {
            try
            {
                InitializeComponent();
                dal = new DALHelper();
                rosterGroupsTable = new DataTable();
                daysTable = new DataTable();
                rosterGroupID = string.Empty;
                idsToDelete = string.Empty;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                countLabel.Text = (grid.RowCount - 1).ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void searchGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null && searchGrid.CurrentRow != null)
                {
                    grid.CurrentRow.Cells["gridStaffID"].Value = searchGrid.CurrentRow.Cells["StaffID"].Value;
                    grid.CurrentRow.Cells["gridEmpID"].Value = searchGrid.CurrentRow.Cells["ID"].Value;
                    grid.CurrentRow.Cells["gridName"].Value = searchGrid.CurrentRow.Cells["Name"].Value;
                    searchGrid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                grid.CurrentCellDirtyStateChanged += new EventHandler(grid_CurrentCellDirtyStateChanged);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                grid.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
                if (grid.CurrentCell.Value != null && grid.CurrentCell.Value.ToString().Trim() != string.Empty)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@SearchTerm", grid.CurrentCell.Value, DbType.String);
                    if (departmentsComboBox.Text == "ALL")
                    {                       
                        searchGrid.DataSource = dal.ExecuteReader("Select StaffPersonalInfoView.ID,StaffPersonalInfoView.StaffID,FirstName + ' '+ OtherName +' '+ Surname as Name,StaffPersonalInfoView.Department From StaffPersonalInfoView where FirstName +' '+ OtherName +' '+ Surname Like '%' + @SearchTerm + '%' And StaffPersonalInfoView.Archived = 'False'");
                    }
                    else
                    {
                        searchGrid.DataSource = dal.ExecuteReader("Select StaffPersonalInfoView.ID,StaffPersonalInfoView.StaffID,FirstName + ' '+ OtherName +' '+ Surname as Name,StaffPersonalInfoView.Department From StaffPersonalInfoView where FirstName + ' '+ OtherName +' '+ Surname Like '%' + @SearchTerm + '%' And StaffPersonalInfoView.Department ='" + departmentsComboBox.Text + "' And StaffPersonalInfoView.Archived = 'False'");
                    }
                    if (searchGrid.ColumnCount > 0)
                    {
                        searchGrid.Columns["ID"].Visible = false;
                    }
                    if (grid.CurrentRow.Index == 0)
                    {
                        searchGrid.Location = new Point(47, 101);
                    }
                    else if (grid.CurrentRow.Index < 3)
                    {
                        searchGrid.Location = new Point(47, 101 + (grid.CurrentRow.Index * 23));
                    }
                    else if (grid.CurrentRow.Index <= 12)
                    {
                        searchGrid.Location = new Point(47, 101 + (grid.CurrentRow.Index * 22));
                    }
                    else
                    {
                        searchGrid.Location = new Point(47, 101 + (12 * 22));
                    }

                    searchGrid.Height = searchGrid.RowCount * 23;
                    searchGrid.Visible = true;
                    if (searchGrid.RowCount == 0)
                    {
                        MessageBox.Show("No staff exists with this name in the departmemt", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grid.CurrentCell.Value = string.Empty;
                        grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                }
                else
                {
                    searchGrid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void departmentsComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                dal.OpenConnection();
                departmentsComboBox.Items.Clear();
                departmentsComboBox.Items.Add("ALL");
                foreach (DataRow row in dal.ExecuteReader("Select Description From DepartmentView order by Description asc").Rows)
                {
                    departmentsComboBox.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        void rosterGroupComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                sundayCheckBox.Checked = false;
                mondayCheckBox.Checked = false;
                tuesdayCheckBox.Checked = false;
                wednesdayCheckBox.Checked = false;
                thursdayCheckBox.Checked = false;
                fridayCheckBox.Checked = false;
                saturdayCheckBox.Checked = false;
                dal.OpenConnection();
                rosterGroupsTable = dal.ExecuteReader("Select RosterGroups.ID,RosterGroups.ShiftID,RosterGroups.Name,WorkShifts.Name as Shift From RosterGroups inner join WorkShifts On WorkShifts.ID = RosterGroups.ShiftID Where RosterGroups.Archived = 'False' order by RosterGroups.Name asc");
                
                rosterGroupComboBox.Items.Clear();

                foreach (DataRow row in rosterGroupsTable.Rows)
                {
                    rosterGroupComboBox.Items.Add(row["Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void DutyRoster_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                departmentsComboBox.Items.Add("ALL");
                departmentsComboBox.Text = "ALL";
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void rosterGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                shiftTextBox.Text = rosterGroupsTable.Rows[rosterGroupComboBox.SelectedIndex]["Shift"].ToString();
                employeesGroupBox.Enabled = true;
                departmentsComboBox.Enabled = true;
                grid.ReadOnly = false;
                grid.Enabled = true;
                rosterGroupID = rosterGroupsTable.Rows[rosterGroupComboBox.SelectedIndex]["ID"].ToString();
                daysTable = dal.ExecuteReader("Select Day From RoasterGroupDays Where RosterGroupID=" + rosterGroupsTable.Rows[rosterGroupComboBox.SelectedIndex]["ID"].ToString());
                foreach (DataRow day in daysTable.Rows)
                {
                    string test = day["Day"].ToString();
                    if (day["Day"].ToString() == "1")
                    {
                        sundayCheckBox.Checked = true;
                    }
                    if (day["Day"].ToString() == "2")
                    {
                        mondayCheckBox.Checked = true;
                    }
                    if (day["Day"].ToString() == "3")
                    {
                        tuesdayCheckBox.Checked = true;
                    }
                    if (day["Day"].ToString() == "4")
                    {
                        wednesdayCheckBox.Checked = true;
                    }
                    if (day["Day"].ToString() == "5")
                    {
                        thursdayCheckBox.Checked = true;
                    }
                    if (day["Day"].ToString() == "6")
                    {
                        fridayCheckBox.Checked = true;
                    }
                    if (day["Day"].ToString() == "7")
                    {
                        saturdayCheckBox.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            shiftTextBox.Clear();
            rosterGroupComboBox.Items.Clear();
            rosterGroupComboBox.Text = string.Empty;
            mondayCheckBox.Checked = false;
            tuesdayCheckBox.Checked = false;
            wednesdayCheckBox.Checked = false;
            thursdayCheckBox.Checked = false;
            fridayCheckBox.Checked = false;
            saturdayCheckBox.Checked = false;
            sundayCheckBox.Checked = false;
            grid.Rows.Clear();
            departmentsComboBox.Text = "All";
            employeesGroupBox.Enabled = false;
            searchGrid.Visible = false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                dal.BeginTransaction();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridID"].Value == null)
                        {
                            dal.ExecuteNonQuery("Insert Into DutyRoster(StartDate,EndDate,RosterGroupID,EmpID) Values('"+ startDatePicker.Text +"','"+ endDatePicker.Text +"',"+ rosterGroupID +",'"+ row.Cells["gridEmpID"].Value.ToString() +"')");
                        }
                        else
                        {
                            dal.ExecuteNonQuery("Update DutyRoster Set StartDate='" + startDatePicker.Text + "',EndDate='" + endDatePicker.Text + "',RosterGroupID=" + rosterGroupID + ",EmpID='" + row.Cells["gridEmpID"].Value.ToString() + "' Where ID = "+ row.Cells["gridID"].Value.ToString());
                        }
                    }
                }

                if (idsToDelete != string.Empty)
                {
                    dal.ExecuteNonQuery("Delete from DutyRoster where ID in ("+ idsToDelete.Substring(0,idsToDelete.Length -1) +")");
                }
                dal.CommitTransaction();
                clearButton_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dal.RollBackTransaction();
            }
        }

        private void removeButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        idsToDelete = grid.CurrentRow.Cells["gridID"].Value.ToString() + ",";
                    }
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                }

                countLabel.Text = (grid.RowCount - 1).ToString();
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
                DutyRosterView viewForm = new DutyRosterView(this);
                viewForm.Show();
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
                startDatePicker.Text = row.Cells["StartDate"].Value.ToString();
                endDatePicker.Text = row.Cells["EndDate"].Value.ToString();
                rosterGroupComboBox_DropDown(this, EventArgs.Empty);
                rosterGroupComboBox.Text = row.Cells["Name"].Value.ToString();

                DataTable gridTable = dal.ExecuteReader("Select DutyRoster.ID,DutyRoster.EmpID,StaffPersonalInfoView.FirstName+' '+ StaffPersonalInfoView.OtherName +' '+ StaffPersonalInfoView.Surname as Name From DutyRoster inner join StaffPersonalInfoView on StaffPersonalInfoView.ID = DutyRoster.EmpID Where DutyRoster.RosterGroupID= " + row.Cells["RosterGroupID"].Value.ToString() + " And DutyRoster.StartDate = '" + row.Cells["StartDate"].Value.ToString() + "' And DutyRoster.EndDate='" + row.Cells["EndDate"].Value.ToString() + "'");
                grid.Rows.Clear();
                int ctr = 0;
                foreach (DataRow rowE in gridTable.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = rowE["ID"].ToString();
                    grid.Rows[ctr].Cells["gridEmpID"].Value = rowE["EmpID"].ToString();
                    grid.Rows[ctr].Cells["gridName"].Value = rowE["Name"].ToString();
                    ctr++;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

    }
}
