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
    public partial class DutyRosterView : Form
    {
        DALHelper dal;
        DutyRoster mainForm;
        BulkDutyRoaster NmainForm;
        //DataReference.hrContextDataContext _context = new DataReference.hrContextDataContext();


        public DutyRosterView(DutyRoster mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            dal = new DALHelper();
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        public DutyRosterView(BulkDutyRoaster NmainForm)
        {
            InitializeComponent();
            this.NmainForm = NmainForm;
            dal = new DALHelper();
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }


        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                //mainForm.PopulateView(grid.CurrentRow);
                this.Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    var del = GlobalData._context.StaffShifts.SingleOrDefault(u => u.Id == Convert.ToInt32(grid.CurrentRow.Cells["ID"].Value));
                    if (del != null)
                    {
                        GlobalData._context.StaffShifts.DeleteOnSubmit(del);
                        GlobalData._context.SubmitChanges();
                        MessageBox.Show("Shift removed successfully");
                        DutyRosterView_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }

            }
        }

        private void DutyRosterView_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            try
            {
                //var getAll = _context.StaffShift_Views.OrderBy(u => u.Date).Select(u => new { ID = u.Id, Firstname = u.Firstname, Surname = u.Surname, OtherName = u.OtherName, Name = u.Name, Day = u.Day, Date = u.Date });

                //grid.DataSource = getAll;

                bttnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<object> list = new List<object>();
                string start = string.Empty;
                string end = string.Empty;

                if (dateTimePickerFrom.Checked == true)
                {
                    start = dateTimePickerFrom.Value.Date.ToShortDateString();
                }
                else
                {
                    start = "01/01/1753";
                }
                if (dateTimePickerTo.Checked == true)
                {
                    end = dateTimePickerTo.Value.Date.ToShortDateString();
                }
                else
                {
                    end = "01/01/9999";
                }
                var find = GlobalData._context.StaffShift_Views.Where(u =>
                    (string.IsNullOrEmpty(start.Trim()) || u.Date.Value.Date >= DateTime.Parse(start.Trim()))
                    && (string.IsNullOrEmpty(end.Trim()) || u.Date.Value.Date <= DateTime.Parse(end.Trim()))
                    && (string.IsNullOrEmpty(tbxStaffID.Text) || u.staffId.Contains(tbxStaffID.Text))
                    && (string.IsNullOrEmpty(comboShfit.Text) || u.Name.Contains(comboShfit.Text))).OrderBy(u => u.Date).Select(u => new { ID = u.Id, Firstname = u.Firstname, Surname = u.Surname, OtherName = u.OtherName, Name = u.Name, Day = u.Day, Date = u.Date }); ;

                foreach (var f in find)
                {
                    list.Add(new
                    {
                        ID = f.ID,
                        Firstname = f.Firstname,
                        Surname = f.Surname,
                        OtherName = f.OtherName,
                        Name = f.Name,
                        Day = f.Day,
                        Date = f.Date
                    });
                }

                var Ifind = GlobalData._context.InternShip_Shifts.Where(u =>
                     (string.IsNullOrEmpty(start.Trim()) || u.Date.Value.Date >= DateTime.Parse(start.Trim()))
                     && (string.IsNullOrEmpty(end.Trim()) || u.Date.Value.Date <= DateTime.Parse(end.Trim()))
                     && (string.IsNullOrEmpty(tbxStaffID.Text) || u.staffId.Contains(tbxStaffID.Text))
                     && (string.IsNullOrEmpty(comboShfit.Text) || u.Name.Contains(comboShfit.Text))).OrderBy(u => u.Date).Select(u => new { ID = u.Id, Firstname = "", Surname = u.Surname, OtherName = u.OtherName, Name = u.Name, Day = u.Day, Date = u.Date });

                foreach (var f in Ifind)
                {
                    list.Add(new
                    {
                        ID = f.ID,
                        Firstname = f.Firstname,
                        Surname = f.Surname,
                        OtherName = f.OtherName,
                        Name = f.Name,
                        Day = f.Day,
                        Date = f.Date
                    });
                }
                grid.DataSource = list;
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
    }
}
