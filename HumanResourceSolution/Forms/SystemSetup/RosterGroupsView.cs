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
    public partial class RosterGroupsView : Form
    {
        DALHelper dal;
        IDAL idal;
        RosterGroups mainForm;

        public RosterGroupsView(RosterGroups mainForm)
        {
            InitializeComponent();
            dal = new DALHelper();
            idal = new DAL();
            this.mainForm = mainForm;
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        public RosterGroupsView()
        {
            InitializeComponent();
            dal = new DALHelper();
            idal = new DAL();
            this.mainForm = new RosterGroups();
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

        private void RosterGroupsView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, idal, GlobalData.User.ID);
                int ctr = 0;
                grid.Rows.Clear();
                DataTable daysTable;
                foreach (DataRow row in dal.ExecuteReader("Select RosterGroups.ID,RosterGroups.ShiftID,RosterGroups.Name,WorkShifts.Name as Shift,RosterGroups.UserID From RosterGroups inner join WorkShifts On WorkShifts.ID = RosterGroups.ShiftID Where RosterGroups.Archived = 'False' order by RosterGroups.Name asc").Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row["ID"].ToString();
                    grid.Rows[ctr].Cells["gridShiftID"].Value = row["ShiftID"].ToString();
                    grid.Rows[ctr].Cells["gridName"].Value = row["Name"].ToString();
                    grid.Rows[ctr].Cells["gridShift"].Value = row["Shift"].ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = row["UserID"].ToString();

                    daysTable = dal.ExecuteReader("Select Day From RoasterGroupDays Where RosterGroupID="+ row["ID"].ToString());
                    foreach (DataRow day in daysTable.Rows)
                    {
                        string test = day["Day"].ToString();
                        if (day["Day"].ToString() == "1")
                        {
                            grid.Rows[ctr].Cells["gridSunday"].Value = true;
                        }
                        if (day["Day"].ToString() == "2")
                        {
                            grid.Rows[ctr].Cells["gridMonday"].Value = true;
                        }
                        if (day["Day"].ToString() == "3")
                        {
                            grid.Rows[ctr].Cells["gridTuesday"].Value = true;
                        }
                        if (day["Day"].ToString() == "4")
                        {
                            grid.Rows[ctr].Cells["gridWednesday"].Value = true;
                        }
                        if (day["Day"].ToString() == "5")
                        {
                            grid.Rows[ctr].Cells["gridThursday"].Value = true;
                        }
                        if (day["Day"].ToString() == "6")
                        {
                            grid.Rows[ctr].Cells["gridFriday"].Value = true;
                        }
                        if (day["Day"].ToString() == "7")
                        {
                            grid.Rows[ctr].Cells["gridSaturday"].Value = true;
                        }
                    }
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                    {
                        dal.ExecuteNonQuery("Update RosterGroups Set Archived='True' Where ID =" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                    {
                        dal.ExecuteNonQuery("Update RosterGroups Set Archived='True' Where ID =" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                    }
                }
                catch(Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
