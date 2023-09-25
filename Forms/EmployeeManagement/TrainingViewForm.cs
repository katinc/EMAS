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
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class TrainingViewForm : Form
    {
        private IDAL dal;
        private IList<StaffTraining> staffTrainings;
        private TrainingNewForm trainingNewForm;
        private bool found;
        private int ctr;
        private TrainingType trainingType;

        public TrainingViewForm(IDAL dal, TrainingNewForm trainingNewForm)
        {
            InitializeComponent();
            this.trainingNewForm = trainingNewForm;
            this.dal = dal;
            this.found = false;
            this.ctr = 0;
            trainingType = new TrainingType();
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
                            var id = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            var staffTraining = GlobalData._context.StaffTrainings.Single(u => u.ID == id);

                            if (staffTraining != null)
                            {
                                staffTraining.Archived = true;
                                staffTraining.ArchivedTime = DateTime.Now;
                                staffTraining.ArchivererID = GlobalData.User.ID;
                                
                                //GlobalData._context.StaffTrainings.InsertOnSubmit(staffTraining);
                                GlobalData._context.SubmitChanges();
                            }
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
                //staffTrainings = dal.GetAll<StaffTraining>();
                //UpdateGrid();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
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
                //grid.Rows[ctr].Cells["gridStaffCode"].Value = staffTraining.Employee.ID;
                grid.Rows[ctr].Cells["gridStaffName"].Value = staffTraining.Employee.Surname+" "+staffTraining.Employee.FirstName+" "+staffTraining.Employee.OtherName;
                grid.Rows[ctr].Cells["gridTrainingType"].Value = staffTraining.TrainingType.Description;
                //grid.Rows[ctr].Cells["gridHealthFacilityType"].Value = staffTraining.InServiceTraining.ID;
                grid.Rows[ctr].Cells["gridStartDate"].Value = staffTraining.StartDate;
                grid.Rows[ctr].Cells["gridEndDate"].Value = staffTraining.EndDate;
                grid.Rows[ctr].Cells["gridOrganisers"].Value = staffTraining.Organisers;
                grid.Rows[ctr].Cells["gridVenue"].Value = staffTraining.Venue;
                grid.Rows[ctr].Cells["gridCostFee"].Value = staffTraining.CostFee;
                grid.Rows[ctr].Cells["gridAccomodationFee"].Value = staffTraining.AccomodationFee;
                grid.Rows[ctr].Cells["gridTotalCost"].Value = staffTraining.TotalCost;
                grid.Rows[ctr].Cells["gridLocationType"].Value = staffTraining.LocationType;
                grid.Rows[ctr].Cells["gridSponsor"].Value = staffTraining.Sponsor.Description;
                //grid.Rows[ctr].Cells["gridUserID"].Value = staffTraining.User.ID;
                //grid.Rows[ctr].Cells["gridDateEntered"].Value = staffTraining.DateEntered;
                ctr++;
            }
        }

        //private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (grid.CurrentRow != null)
        //        {
        //            StaffTraining staffTraining = new StaffTraining();
        //            staffTraining.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
        //            staffTraining.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
        //            //staffTraining.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
        //            staffTraining.TrainingType.Description = grid.CurrentRow.Cells["gridTrainingType"].Value.ToString();
        //            staffTraining.InServiceTraining.Description = grid.CurrentRow.Cells["gridIST"].Value.ToString();
        //            staffTraining.StartDate = DateTime.Parse(grid.CurrentRow.Cells["gridStartDate"].Value.ToString());
        //            staffTraining.EndDate = DateTime.Parse(grid.CurrentRow.Cells["gridEndDate"].Value.ToString());
        //            staffTraining.Organisers.Description = grid.CurrentRow.Cells["gridOrganisers"].Value.ToString();
        //            //staffTraining.CertificateAwarded = grid.CurrentRow.Cells["gridCertificateAwarded"].Value.ToString();
        //            staffTraining.Venue = grid.CurrentRow.Cells["gridVenue"].Value.ToString();
        //            //staffTraining.CostFee = float.Parse(grid.CurrentRow.Cells["gridCostFee"].Value.ToString());
        //            //staffTraining.AccomodationFee = float.Parse(grid.CurrentRow.Cells["gridAccomodationFee"].Value.ToString());
        //            //staffTraining.TotalCost = grid.CurrentRow.Cells["gridTotalCost"].Value.ToString();
        //            staffTraining.LocationType.Description = grid.CurrentRow.Cells["gridLocationType"].Value.ToString();
        //            staffTraining.Sponsor.Description = grid.CurrentRow.Cells["gridSponsor"].Value.ToString();
        //            //staffTraining.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
        //            //staffTraining.DateEntered = DateTime.Parse(grid.CurrentRow.Cells["DateEntered"].Value.ToString());
        //            //trainingNewForm.StaffTraining = staffTraining;
        //            trainingNewForm.EditStaffTraining(staffTraining);
        //            trainingNewForm.Show();
        //            trainingNewForm.BringToFront();
        //            this.Close();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        string str = ex.Message;
        //    }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw ex;
            }
        }

        private void getData() 
        {
            try
            {

                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffTrainingView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                if (cboTrainingType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffTrainingView.TrainingType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboTrainingType.Text,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }



                if (txtVenue.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffTrainingView.Venue",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtVenue.Text,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffTrainingView.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = staffIDtxt.Text,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                if (dateStartDate.Checked)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StartDate",
                        CriterionOperator = CriterionOperator.GreaterThanOrEqualTo,
                        Value = dateStartDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                if (dateEndDate.Checked)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "EndDate",
                        CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                        Value = dateEndDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                } 
                query.Criteria.Add(new Criterion()
                {
                    Property = "Archived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.None
                });

                staffTrainings = dal.GetByCriteria<StaffTraining>(query);
                PopulateView(staffTrainings);
                
                

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(IList<StaffTraining> staffTrainings) 
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (StaffTraining staffTraining in staffTrainings)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffTraining.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffTraining.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffTraining.Employee.FirstName + " " + staffTraining.Employee.OtherName + " " + staffTraining.Employee.Surname;
                    grid.Rows[ctr].Cells["gridTrainingType"].Value = staffTraining.TrainingType.Description;
                    grid.Rows[ctr].Cells["gridCertificateAwarded"].Value = staffTraining.CertificateAwarded;
                    grid.Rows[ctr].Cells["gridStartDate"].Value = staffTraining.StartDate;
                    grid.Rows[ctr].Cells["gridEndDate"].Value = staffTraining.EndDate;
                    grid.Rows[ctr].Cells["gridOrganisers"].Value = staffTraining.Organisers.Description;
                    grid.Rows[ctr].Cells["gridVenue"].Value = staffTraining.Venue;
                    grid.Rows[ctr].Cells["gridSponsor"].Value = staffTraining.Sponsor.Description;
                    grid.Rows[ctr].Cells["gridLocationType"].Value = staffTraining.LocationType;
                    grid.Rows[ctr].Cells["gridDuration"].Value = staffTraining.Days;
                    grid.Rows[ctr].Cells["gridHours"].Value = staffTraining.Hours;
                    grid.Rows[ctr].Cells["gridCourse"].Value = staffTraining.Program;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }
        }

        private void attedanceDate_CloseUp(object sender, EventArgs e)
        {

        }

        private void attedanceDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboTrainingType_DropDown(object sender, EventArgs e)
        {
            try
            {
                var trainingTypes = GlobalData._context.TrainingTypes.ToList();

                cboTrainingType.Items.Clear();
                foreach (var item in trainingTypes)
                {
                    cboTrainingType.Items.Add(item.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }



        private void grid_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null && trainingNewForm.CanEdit)
                {
                    StaffTraining staffTraining = new StaffTraining();
                    staffTraining.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    staffTraining.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    //staffTraining.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    staffTraining.TrainingType.Description = grid.CurrentRow.Cells["gridTrainingType"].Value.ToString();
                    //staffTraining.InServiceTraining.Description = grid.CurrentRow.Cells["gridIST"].Value.ToString();
                    staffTraining.StartDate = DateTime.Parse(grid.CurrentRow.Cells["gridStartDate"].Value.ToString());
                    staffTraining.EndDate = DateTime.Parse(grid.CurrentRow.Cells["gridEndDate"].Value.ToString());
                    staffTraining.Organisers.Description = grid.CurrentRow.Cells["gridOrganisers"].Value.ToString();
                    staffTraining.CertificateAwarded = grid.CurrentRow.Cells["gridCertificateAwarded"].Value.ToString();
                    staffTraining.Venue = grid.CurrentRow.Cells["gridVenue"].Value.ToString();
                    //staffTraining.CostFee = float.Parse(grid.CurrentRow.Cells["gridCostFee"].Value.ToString());
                    //staffTraining.AccomodationFee = float.Parse(grid.CurrentRow.Cells["gridAccomodationFee"].Value.ToString());
                    //staffTraining.TotalCost = grid.CurrentRow.Cells["gridTotalCost"].Value.ToString();
                    staffTraining.LocationType = grid.CurrentRow.Cells["gridLocationType"].Value.ToString();
                    staffTraining.Sponsor.Description = grid.CurrentRow.Cells["gridSponsor"].Value.ToString();
                    staffTraining.Hours = Convert.ToDecimal(grid.CurrentRow.Cells["gridHours"].Value.ToString());
                    staffTraining.Days = Convert.ToInt32(grid.CurrentRow.Cells["gridDuration"].Value.ToString());
                    staffTraining.Program = grid.CurrentRow.Cells["gridCourse"].Value.ToString();
                    //staffTraining.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    //staffTraining.DateEntered = DateTime.Parse(grid.CurrentRow.Cells["DateEntered"].Value.ToString());
                    //trainingNewForm.StaffTraining = staffTraining;
                    trainingNewForm.EditStaffTraining(staffTraining);
                    trainingNewForm.Show();
                    trainingNewForm.BringToFront();
                    this.Close();
                }
                else if (!trainingNewForm.CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
}
