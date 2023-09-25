using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using eMAS.Forms.System_SetupFORMS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
namespace eMAS.Forms.SystemSetup
{
    public partial class HolidayView : Form
    {
        IDAL dal;
        HolidayEdit holidayEdit;

        public HolidayView(IDAL dal)
        {
            InitializeComponent();
            this.dal = dal;
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        public HolidayView()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                Holiday holiday = new Holiday();
                holiday.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                holiday.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                holiday.Description = grid.CurrentRow.Cells["gridDescription"].Value.ToString();
                holidayEdit = new HolidayEdit(dal, holiday,this);
                holidayEdit.ShowDialog();
            }

        }

        private void HolidayView_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GetHolidays();
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        public void GetHolidays()
        {
            try
            {
                grid.Rows.Clear();
                int ctr = 0;
                foreach (Holiday holiday in dal.GetAll<Holiday>())
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = holiday.ID;
                    grid.Rows[ctr].Cells["gridDate"].Value = holiday.Date;
                    grid.Rows[ctr].Cells["gridDescription"].Value = holiday.Description;
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
            this.Close();
        }
    }
}
