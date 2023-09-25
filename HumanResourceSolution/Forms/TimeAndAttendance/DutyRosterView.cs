using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;

namespace eMAS.Forms.TimeAndAttendance
{
    public partial class DutyRosterView : Form
    {
        DALHelper dal;
        DutyRoster mainForm;

        public DutyRosterView(DutyRoster mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            dal = new DALHelper();
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                mainForm.PopulateView(grid.CurrentRow);
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
                    dal.ExecuteNonQuery("Delete From DutyRoster where RosterGroupID=" + grid.CurrentRow.Cells["RosterGroupID"].Value.ToString() + " And StartDate ='" + grid.CurrentRow.Cells["StartDate"].Value.ToString() + "' And EndDate='" + grid.CurrentRow.Cells["EndDate"].Value.ToString() + "'");
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
                
            }
        }

        private void DutyRosterView_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            try
            {
                grid.DataSource = dal.ExecuteReader("Select Distinct DutyRoster.RosterGroupID,RosterGroups.Name,DutyRoster.StartDate,DutyRoster.EndDate From DutyRoster inner join RosterGroups on RosterGroups.ID = DutyRoster.RosterGroupID Order By DutyRoster.StartDate Asc");
                if (grid.ColumnCount > 0)
                {
                    grid.Columns["RosterGroupID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
    }
}
