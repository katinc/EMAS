using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.TimeAndAttendance
{
    public partial class BulkDutyRoaster : Form
    {
        private IDAL dal;
        private DataTable rosterGroupsTable;
        private string rosterGroupID;
        private string idsToDelete;
        private DataTable daysTable;
        //DataReference.hrContextDataContext context = new DataReference.hrContextDataContext();
        List<DateTime> dates = new List<DateTime>();
        List<UserDetails> details = new List<UserDetails>();
        bool UseStartDate = false;
        bool UseEndDate = false;
        private IList<Unit> units;

        public Permissions permissions;

        public BulkDutyRoaster()
        {
            InitializeComponent();
            this.dal = new DAL();
            rosterGroupsTable = new DataTable();
            daysTable = new DataTable();
            rosterGroupID = string.Empty;
            idsToDelete = string.Empty;
            this.units = new List<Unit>();
        }


        private void chkEmployees_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmployees.Checked == true)
            {
                lbintern.Visible = false;
                comboInterntype.Visible = false;
                chkInterns.Checked = false;
            }
            else
            {
                lbintern.Visible = true;
                comboInterntype.Visible = true;
                chkInterns.Checked = true;
            }
            departmentsComboBox_SelectedIndexChanged(sender, e);
        }

        private void departmentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkEmployees.Checked == true)
                {
                    if (departmentsComboBox.Text == "ALL")
                    {
                        var getAll = GlobalData._context.StaffPersonalInfoViews.OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1} {2}", u.Firstname, u.Surname, u.OtherName), staffid = u.StaffID });
                        grid.DataSource = getAll;

                    }
                    else
                    {
                        var getAll = GlobalData._context.StaffPersonalInfoViews.Where(x => x.Department == departmentsComboBox.Text).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1} {2}", u.Firstname, u.Surname, u.OtherName), staffid = u.StaffID });
                        grid.DataSource = getAll;
                    }
                }
                if (chkInterns.Checked == true)
                {
                    if (comboInterntype.SelectedIndex == -1)
                    {
                        var getAll = GlobalData._context.InternshipViews.OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1} ", u.Surname, u.OtherName), staffid = u.StaffID });
                        grid.DataSource = getAll;
                    }
                    else
                    {
                        var getAll = GlobalData._context.InternshipViews.Where(x => x.Department == departmentsComboBox.Text && x.InternshipType == comboInterntype.Text).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1} ", u.Surname, u.OtherName), staffid = u.StaffID });
                        grid.DataSource = getAll;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void departmentsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = departmentsComboBox.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                cboUnit.Items.Add("All");
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cboUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkEmployees.Checked == true)
                {
                    if (cboUnit.Text == "ALL")
                    {
                        var getAll = GlobalData._context.StaffPersonalInfoViews.Where(x => x.Department == departmentsComboBox.Text).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1} {2}", u.Firstname, u.Surname, u.OtherName), staffid = u.StaffID });
                        //int i = 0;
                        grid.DataSource = getAll;

                    }
                    else
                    {

                        var getAll = GlobalData._context.StaffPersonalInfoViews.Where(x => x.Department == departmentsComboBox.Text && x.Unit == cboUnit.Text).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1} {2}", u.Firstname, u.Surname, u.OtherName), staffid = u.StaffID });
                        //int i = 0;
                        grid.DataSource = getAll;
                    }
                }
                if (chkInterns.Checked == true)
                {
                    if (cboUnit.Text == "ALL")
                    {
                        var getAll = GlobalData._context.InternshipViews.Where(x => x.Department == departmentsComboBox.Text).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1}", u.Surname, u.OtherName), staffid = u.StaffID });
                        //int i = 0;
                        grid.DataSource = getAll;

                    }
                    else
                    {

                        var getAll = GlobalData._context.InternshipViews.Where(x => x.Department == departmentsComboBox.Text && x.Unit == cboUnit.Text).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1}", u.Surname, u.OtherName), staffid = u.StaffID });
                        //int i = 0;
                        grid.DataSource = getAll;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkEmployees.Checked == true)
                {
                    if (departmentsComboBox.Text == "ALL")
                    {
                        var getAll = GlobalData._context.StaffPersonalInfoViews.Where(u => u.StaffID.ToUpper().Contains(tbxSearch.Text.ToUpper())).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1} {2}", u.Firstname, u.Surname, u.OtherName), staffid = u.StaffID });
                        //int i = 0;
                        grid.DataSource = getAll;

                    }
                    else
                    {

                        var getAll = GlobalData._context.StaffPersonalInfoViews.Where(x => x.Department == departmentsComboBox.Text && x.StaffID.ToUpper().Contains(tbxSearch.Text.ToUpper())).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1} {2}", u.Firstname, u.Surname, u.OtherName), staffid = u.StaffID });
                        //int i = 0;
                        grid.DataSource = getAll;
                    }
                }
                if (chkInterns.Checked == true)
                {
                    if (departmentsComboBox.Text == "ALL")
                    {
                        var getAll = GlobalData._context.InternshipViews.Where(u => u.StaffID.ToUpper().Contains(tbxSearch.Text.ToUpper())).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1}", u.Surname, u.OtherName), staffid = u.StaffID });
                        grid.DataSource = getAll;

                    }
                    else
                    {
                        if(string.IsNullOrEmpty(departmentsComboBox.Text))
                        {
                            MessageBox.Show("Please select department");
                            return;
                        }
                        var getAll = GlobalData._context.InternshipViews.Where(x => x.Department == departmentsComboBox.Text && x.StaffID.ToUpper().Contains(tbxSearch.Text.ToUpper())).OrderBy(u => u.StaffID).Select(u => new { ID = u.ID, Name = string.Format("{0} {1}", u.Surname, u.OtherName), staffid = u.StaffID });
                        grid.DataSource = getAll;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkAllusers_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllusers.Checked == true)
                {
                    grid.SelectAll();

                    foreach (DataGridViewRow r in grid.SelectedRows)
                    {
                        var getUser = details.SingleOrDefault(u => u.ID == r.Cells["ID"].Value.ToString());
                        if (getUser == null)
                        {
                            details.Add(new UserDetails { ID = r.Cells["ID"].Value.ToString(), Name = r.Cells["gName"].Value.ToString(), StaffID = r.Cells["StaffID"].Value.ToString() });

                            listBoxUsers.Items.Add(string.Format("{0}  {1}", (string)r.Cells["StaffID"].Value, (string)r.Cells["gName"].Value));
                        }
                    }
                }
                else
                {
                    grid.ClearSelection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong see System Administrator");
                Logger.LogError(ex);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var getUser = details.SingleOrDefault(u => u.ID == grid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                if (getUser == null)
                {
                    details.Add(new UserDetails { ID = grid.Rows[e.RowIndex].Cells["ID"].Value.ToString(), Name = grid.Rows[e.RowIndex].Cells["gName"].Value.ToString(), StaffID = grid.Rows[e.RowIndex].Cells["StaffID"].Value.ToString() });

                    listBoxUsers.Items.Add(string.Format("{0}  {1}", (string)grid.Rows[e.RowIndex].Cells["StaffID"].Value, (string)grid.Rows[e.RowIndex].Cells["gName"].Value));
                }


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void comboShfit_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboShfit.Items.Clear();
                var shift = GlobalData._context.WorkShifts.Where(u => u.Active == true && u.Archived == false).OrderBy(u => u.Name).ToList();
                foreach (var item in shift)
                {
                    comboShfit.Items.Add(item.Name);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            dates.Clear();
            UseStartDate = true;
            UseEndDate = false;
            try
            {
                //if (startDatePicker.Value.Date < DateTime.Now.Date)
                //{
                //    MessageBox.Show("Please you cannot set shift for a past day. If you want to edit shift click on user and edit shift for a particular date");
                //    return;
                //}
                if (endDatePicker.Value.Date <= startDatePicker.Value.Date)
                {
                    endDatePicker.Value = DateTime.Parse(string.Format("{0}/{1}/{2}", startDatePicker.Value.Month, DateTime.DaysInMonth(startDatePicker.Value.Year, startDatePicker.Value.Month), startDatePicker.Value.Year));
                }


                if (UseStartDate == true)
                {
                    var startdate = startDatePicker.Value.Date;
                    while (startdate <= endDatePicker.Value.Date)
                    {
                        dates.Add(startdate);
                        listBox1.Items.Add(string.Format("{0}  {1}", startdate.ToShortDateString(), startdate.ToString("dddd")));
                        startdate = startdate.AddDays(1);
                    }
                }

                //for (var dt = startDatePicker.Value; dt <= endDatePicker.Value; dt = dt.AddDays(1))
                //{
                //    dates.Add(dt);
                //    listBox1.Items.Add(string.Format("{0}  {1}", dt.Date.ToShortDateString(), dt.Date.ToString("dddd")));
                //}
                //listBox1.Items.Add(string.Format("{0}  {1}", endDatePicker.Value.Date.ToShortDateString(), endDatePicker.Value.Date.ToString("dddd")));
                dateshift.Value = startDatePicker.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            dates.Clear();
            UseStartDate = false;
            UseEndDate = true;

            try
            {
                if (UseEndDate == true)
                {
                    var startdate = startDatePicker.Value.Date;
                    while (startdate <= endDatePicker.Value.Date)
                    {
                        dates.Add(startdate);
                        listBox1.Items.Add(string.Format("{0}  {1}", startdate.ToShortDateString(), startdate.ToString("dddd")));
                        startdate = startdate.AddDays(1);
                    }
                }

                //for (var dt = startDatePicker.Value; dt <= endDatePicker.Value; dt = dt.AddDays(1))
                //{

                //}
                //listBox1.Items.Add(string.Format("{0}  {1}", endDatePicker.Value.Date.ToShortDateString(), endDatePicker.Value.Date.ToString("dddd")));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selected = GlobalData._context.StaffShifts.Where(u => u.Date == dates[listBox1.SelectedIndex]).Count();
                dateshift.Value = dates[listBox1.SelectedIndex];
            }
            catch (Exception ex)
            {

            }
        }

        private void bttnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                string uType = string.Empty;
                if (comboShfit.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select shift to assign");
                    return;
                }
                List<DataReference.StaffShift> list = new List<DataReference.StaffShift>();
                List<DataReference.ShiftLog> loggs = new List<DataReference.ShiftLog>();
                int exitscount = 0;
                if (chkPeriod.Checked == true)
                {
                    foreach (var date in dates)
                    {
                        foreach (var user in details)
                        {
                            var shiftId = GlobalData._context.WorkShifts.SingleOrDefault(u => u.Name == comboShfit.Text).ID;
                            var checkuser = GlobalData._context.StaffShifts.SingleOrDefault(u => u.staffId == user.StaffID && u.Date == date && u.ShiftType == shiftId);
                            if (checkuser == null)
                            {

                                if (chkInterns.Checked == true)
                                {
                                    if (comboInterntype.SelectedIndex == -1)
                                    {
                                        uType = GlobalData._context.InternshipViews.SingleOrDefault(u => u.StaffID == user.StaffID && u.Archived == false).InternshipType;
                                    }
                                    else
                                    {
                                        uType = comboInterntype.Text;
                                    }
                                }
                                if (chkEmployees.Checked == true)
                                {
                                    uType = "EMPLOYEE";
                                }
                                DataReference.StaffShift shift = new DataReference.StaffShift
                                {
                                    Date = date,
                                    Day = date.DayOfWeek.ToString(),
                                    staffId = user.StaffID,
                                    ShiftType = shiftId,
                                    Usertype = uType,
                                    Reason = tbxReason.Text,
                                    StaffMainID = Convert.ToInt32(user.ID)
                                };

                                list.Add(shift);


                                var shiftlog = new DataReference.ShiftLog { date = date, shift = GlobalData._context.WorkShifts.SingleOrDefault(u => u.Name == comboShfit.Text).ID, userId = GlobalData.UserID, staffID = user.StaffID, datecreated = DateTime.Now, Action = "Add" };

                                loggs.Add(shiftlog);
                            }
                            else
                            {
                                exitscount++;
                            }
                        }
                        

                    }

                }
                else
                {
                    foreach (var user in details)
                    {
                        var shiftId = GlobalData._context.WorkShifts.SingleOrDefault(u => u.Name == comboShfit.Text).ID;
                        var checkuser = GlobalData._context.StaffShifts.SingleOrDefault(u => u.staffId == user.StaffID && u.Date == dateshift.Value.Date && u.ShiftType == shiftId);

                        if (checkuser == null)
                        {
                            if (chkInterns.Checked == true)
                            {
                                if (comboInterntype.SelectedIndex == -1)
                                {
                                    uType = GlobalData._context.InternshipViews.SingleOrDefault(u => u.StaffID == user.StaffID).InternshipType;
                                }
                                else
                                {
                                    uType = comboInterntype.Text;
                                }
                            }
                            if (chkEmployees.Checked == true)
                            {
                                uType = "EMPLOYEE";
                            }
                            DataReference.StaffShift shift = new DataReference.StaffShift
                            {
                                Date = dateshift.Value.Date,
                                Day = dateshift.Value.Date.DayOfWeek.ToString(),
                                staffId = user.StaffID,
                                ShiftType = GlobalData._context.WorkShifts.SingleOrDefault(u => u.Name == comboShfit.Text).ID,
                                Usertype = uType,
                                Reason = tbxReason.Text,
                                StaffMainID = Convert.ToInt32(user.ID)
                            };

                            list.Add(shift);


                            var shiftlog = new DataReference.ShiftLog { date = dateshift.Value.Date, shift = GlobalData._context.WorkShifts.SingleOrDefault(u => u.Name == comboShfit.Text).ID, userId = GlobalData.UserID, staffID = user.StaffID, datecreated = DateTime.Now, Action = "Add" };

                            loggs.Add(shiftlog);
                        }
                        else
                        {
                            exitscount++;
                        }
                    }
                }

                if(exitscount > 0)
                {
                    MessageBox.Show("User(s) assigned to shift already !!!",this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                GlobalData._context.StaffShifts.InsertAllOnSubmit(list);
                GlobalData._context.ShiftLogs.InsertAllOnSubmit(loggs);
                GlobalData._context.SubmitChanges();

                MessageBox.Show("Users assigned successfully");

                bttnClear_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong see System Administrator");
                Logger.LogError(ex);
            }
        }

        private void bttnClear_Click(object sender, EventArgs e)
        {
            listBoxUsers.Items.Clear();
            details.Clear();
            grid.ClearSelection();
            chkAllusers.Checked = false;
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            try
            {
                DutyRosterView viewForm = new DutyRosterView(this);
                viewForm.Show();
                viewForm.MdiParent = this.MdiParent ;
                viewForm.removeButton.Enabled = permissions.CanDelete;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void departmentsComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                departmentsComboBox.Items.Clear();
                var dept = GlobalData._context.DepartmentViews.ToList().OrderBy(u => u.Description);
                //foreach (DataRow row in dal.ExecuteReader("Select Description From DepartmentView order by Description asc").Rows)
                //{
                //    departmentsComboBox.Items.Add(row["Description"].ToString());
                //}


                departmentsComboBox.Items.Add("ALL");
                foreach (var item in dept)
                {
                    departmentsComboBox.Items.Add(item.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void chkInterns_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInterns.Checked == true)
            {
                lbintern.Visible = true;
                comboInterntype.Visible = true;
                chkEmployees.Checked = false;
            }
            else
            {
                lbintern.Visible = false;
                comboInterntype.Visible = false;
                chkEmployees.Checked = true;
            }
            departmentsComboBox_SelectedIndexChanged(sender, e);
        }

        private void BulkDutyRoaster_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBoxUsers.Items.Clear();
            try
            {
                this.Text = GlobalData.Caption;
                departmentsComboBox.Items.Add("ALL");
                departmentsComboBox.SelectedIndex = 0;

                //MessageBox.Show(string.Format("{0}  {1}  {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));

                endDatePicker.Value = DateTime.Parse(string.Format("{0}/{1}/{2}", DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Year));

                permissions = GlobalData.CheckPermissions(2);
                bttnAssign.Enabled = permissions.CanAdd;
                viewButton.Enabled = permissions.CanView;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void comboInterntype_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboInterntype.Items.Clear();
                var intern = GlobalData._context.InternshipTypes.Where(u => u.Active == true && u.Archived == false).OrderBy(u => u.Description).ToList();
                foreach (var item in intern)
                {
                    comboInterntype.Items.Add(item.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
public class UserDetails
{
    public string ID { get; set; }
    public string StaffID { get; set; }
    public string Name { get; set; }
}
