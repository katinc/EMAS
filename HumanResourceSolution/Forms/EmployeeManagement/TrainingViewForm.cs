using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class TrainingViewForm : Form
    {
        private IDAL dal;
        private IList<StaffTraining> staffTrainings;
        private TrainingNewForm trainingNewForm;
        private bool found;

        public TrainingViewForm(IDAL dal, TrainingNewForm trainingNewForm)
        {
            InitializeComponent();
            this.trainingNewForm = trainingNewForm;
            this.dal = dal;
            this.found = false;
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete the current claim?", GlobalData.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dal.Delete(new StaffTraining()
                            {
                                ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString()),
                                Archived=false
                            });
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dal.Delete(new StaffTraining()
                            {
                                ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString()),
                                Archived = false
                            });
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrainingViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                staffTrainings = dal.GetAll<StaffTraining>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            UpdateGrid();
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void UpdateGrid()
        {
            grid.Rows.Clear();
            int ctr = 0;
            foreach (StaffTraining staffTraining in staffTrainings)
            {
                grid.Rows.Add(1);
                grid.Rows[ctr].Cells["gridID"].Value = staffTraining.ID;
                grid.Rows[ctr].Cells["gridStaffID"].Value = staffTraining.Employee.StaffID;
                grid.Rows[ctr].Cells["gridStaffCode"].Value = staffTraining.Employee.ID;
                grid.Rows[ctr].Cells["gridStaffName"].Value = staffTraining.Employee.Surname+" "+staffTraining.Employee.FirstName+" "+staffTraining.Employee.OtherName;
                grid.Rows[ctr].Cells["gridTrainingTypeID"].Value = staffTraining.TrainingType.ID;
                grid.Rows[ctr].Cells["gridHealthFacilityType"].Value = staffTraining.InServiceTraining.ID;
                grid.Rows[ctr].Cells["gridStartDate"].Value = staffTraining.StartDate;
                grid.Rows[ctr].Cells["gridEndDate"].Value = staffTraining.EndDate;
                grid.Rows[ctr].Cells["gridOrganisers"].Value = staffTraining.Organisers;
                grid.Rows[ctr].Cells["gridVenue"].Value = staffTraining.Venue;
                grid.Rows[ctr].Cells["gridCostFee"].Value = staffTraining.CostFee;
                grid.Rows[ctr].Cells["gridAccomodationFee"].Value = staffTraining.AccomodationFee;
                grid.Rows[ctr].Cells["gridTotalCost"].Value = staffTraining.TotalCost;
                grid.Rows[ctr].Cells["gridLocationTypeID"].Value = staffTraining.LocationType.ID;
                grid.Rows[ctr].Cells["gridSponsorID"].Value = staffTraining.Sponsor.ID;
                grid.Rows[ctr].Cells["gridUserID"].Value = staffTraining.User.ID;
                grid.Rows[ctr].Cells["gridDateEntered"].Value = staffTraining.DateEntered;
                ctr++;
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    StaffTraining staffTraining = new StaffTraining();
                    staffTraining.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    staffTraining.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    staffTraining.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    staffTraining.TrainingType.ID = int.Parse(grid.CurrentRow.Cells["gridTrainingTypeID"].Value.ToString());
                    staffTraining.InServiceTraining.ID = int.Parse(grid.CurrentRow.Cells["gridISTID"].Value.ToString());
                    staffTraining.StartDate = DateTime.Parse(grid.CurrentRow.Cells["gridStartDate"].Value.ToString());
                    staffTraining.EndDate = DateTime.Parse(grid.CurrentRow.Cells["gridEndDate"].Value.ToString());
                    staffTraining.Organisers = grid.CurrentRow.Cells["gridOrganisers"].Value.ToString();
                    staffTraining.CertificateAwarded = grid.CurrentRow.Cells["gridCertificateAwarded"].Value.ToString();
                    staffTraining.Venue = grid.CurrentRow.Cells["gridVenue"].Value.ToString();
                    staffTraining.CostFee = float.Parse(grid.CurrentRow.Cells["gridCostFee"].Value.ToString());
                    staffTraining.AccomodationFee = float.Parse(grid.CurrentRow.Cells["gridAccomodationFee"].Value.ToString());
                    staffTraining.TotalCost = grid.CurrentRow.Cells["gridTotalCost"].Value.ToString();
                    staffTraining.LocationType.ID = int.Parse(grid.CurrentRow.Cells["gridLocationTypeID"].Value.ToString());
                    staffTraining.Sponsor.ID = int.Parse(grid.CurrentRow.Cells["gridSponsorID"].Value.ToString());
                    staffTraining.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    staffTraining.DateEntered = DateTime.Parse(grid.CurrentRow.Cells["DateEntered"].Value.ToString());
                    trainingNewForm.StaffTraining = staffTraining;
                    trainingNewForm.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
}
