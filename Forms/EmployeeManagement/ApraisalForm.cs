using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eMAS.Forms.Reports;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;
using Session_Framework;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ApraisalForm : Form
    {
        private IList<AppraisalObjective> lstAppraisalObjectives;
        private AppraisalObjectivesDataMapper appraisalObjectives;
        private IList<AppraisalGeneralPerformanceRating> lstAppraisalGeneralPerformance;

        public IList<AppraisalPeriod> lstAppraisalPeriods;
        private AppraisalPeriodDataMapper appraisalPeriodDataMapper;
        private AppraisalGeneralPerformanceRatingDataMapper appraisalGeneralPerformanceDataMapper;

        private Company company;
        private IDAL dal;
        private int ctr;
        private IList<Employee> employees;
        private IList<Employee> employeeList;

        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        private IList<AppraisalRating> ratings;

        private int staffCode;
        public Employee selectedEmployee;
        private DALHelper dalHelper;
        private EmployeeDataMapper staffDataMapper;

        private AppraisalGeneralReviewDataMapper appraisalGeneralReviewDataMapper;
        private AppraisalGeneralReview appraisalGeneralReviewData;
        public ApraisalForm()
        {
            InitializeComponent();
            lstAppraisalPeriods = new List<AppraisalPeriod>();
            lstAppraisalObjectives = new List<AppraisalObjective>();
            appraisalObjectives = new AppraisalObjectivesDataMapper();
            appraisalPeriodDataMapper = new AppraisalPeriodDataMapper();
            appraisalGeneralPerformanceDataMapper = new AppraisalGeneralPerformanceRatingDataMapper();
            lstAppraisalGeneralPerformance = new List<AppraisalGeneralPerformanceRating>();
            company = new Company();
            dal = new DAL();
            employees =new List < Employee >();
            employeeList = new List<Employee>();
            dalHelper = new DALHelper();
            staffDataMapper = new EmployeeDataMapper();
            appraisalGeneralReviewDataMapper = new AppraisalGeneralReviewDataMapper();

            ratings = new List<AppraisalRating>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void LoadObjectives()
        {
            try
            {
                int ctr = 0;
                gridB.Rows.Clear();
                lstAppraisalObjectives = appraisalObjectives.getDataByStaffId(selectedEmployee.ID, lstAppraisalPeriods[cmbPeriod.SelectedIndex].Id);

                var appraisalObj = GlobalData._context.AppraisalRatings.ToList();

                gridOBRating.Items.Clear();
                foreach (var item in appraisalObj)
                {
                    gridOBRating.Items.Add(item.Rating);
                }

                foreach (AppraisalObjective dRow in lstAppraisalObjectives)
                {
                    gridB.Rows.Add(1);
                    gridB.Rows[ctr].Cells["gridID"].Value = dRow.Id;
                    gridB.Rows[ctr].Cells["gridObjective"].Value = dRow.Description;

                    if (dRow.PeriodRating != null)
                    {
                        gridB.Rows[ctr].Cells["gridOBRating"].Value = dRow.PeriodRating.Description;
                    }
                    //gridB.Rows[ctr].Cells["gridRating"].Value = dRow.PeriodRating != null ? dRow.PeriodRating.RateDescription : null;
                   // ((DataGridViewComboBoxColumn)gridB.Rows[ctr].Cells["gridRating"]). = true;
                    gridB.Rows[ctr].Cells["gridComment"].Value = dRow.Comment;
                    ctr++;
                }
            }
            catch (Exception xi) 
            {
                Logger.LogError(xi);
                //throw (xi);
            }
            
        }
        private void LoadPerformance()
        {
            try
            {
                int ctr = 0;
                gridC.Rows.Clear();
                lstAppraisalGeneralPerformance.Clear();
                appraisalGeneralPerformanceDataMapper = new AppraisalGeneralPerformanceRatingDataMapper();
                lstAppraisalGeneralPerformance = appraisalGeneralPerformanceDataMapper.getDataBy(selectedEmployee.ID, lstAppraisalPeriods[cmbPeriod.SelectedIndex].Id);

                var appraisalObj = GlobalData._context.AppraisalRatings.ToList();

                gridCRating.Items.Clear();
                foreach (var item in appraisalObj)
                {
                    gridCRating.Items.Add(item.Rating);
                }

                foreach (AppraisalGeneralPerformanceRating dRow in lstAppraisalGeneralPerformance)
                {
                    gridC.Rows.Add(1);
                    gridC.Rows[ctr].Cells["gridCID"].Value = dRow.Id;
                    gridC.Rows[ctr].Cells["gridFactor"].Value = dRow.Factor.Description;
                    gridC.Rows[ctr].Cells["gridFactorId"].Value = dRow.Factor.ID;
                    gridC.Rows[ctr].Cells["gridCRating"].Value = dRow.Rating != null ? dRow.Rating.RateDescription.Trim(): null;
                    gridC.Rows[ctr].Cells["gridCComments"].Value = dRow.Comment;
                    ctr++;
                }

                ComputeTotal(gridC);
            }
            catch (Exception xi) { }
            
        }
        private void loadPeriodsCombox(){
             try
            {
                lstAppraisalPeriods.Clear();
                lstAppraisalPeriods = appraisalPeriodDataMapper.getData(true, false);
                cmbPeriod.Items.Clear();
                foreach (AppraisalPeriod dRow in lstAppraisalPeriods)
                {
                    cmbPeriod.Items.Add(dRow.Description.Trim());
                }
            }
            catch (Exception xi) { }
        }
        private decimal maxBPoints = 0;
        private decimal maxCPoints = 0;
        private decimal maxDPoints = 0;


        IList<AppraisalRating> AppraisalRatingsStands;
        private void ApraisalForm_Load(object sender, EventArgs e)
        {
           //getBRatings();
           loadPeriodsCombox();
           maxCPoints = getMaxEndPoint("C");
           maxDPoints = maxBPoints + maxCPoints;
           try
           {
               // TODO: This line of code loads data into the 'countriesDataSet.AppraisalRatings' table. You can move, or remove it, as needed.
               //this.appraisalRatingsTableAdapter.FillForJustReview(this.countriesDataSet.AppraisalRatings);

               var RatingsStands = GlobalData._context.AppraisalRatings.ToList(); 
                //var RatingsStands= this.countriesDataSet.AppraisalRatings;
               
                AppraisalRatingsStands =new List<AppraisalRating>();

            if (RatingsStands.Count > 0)
            {
                foreach (var item in RatingsStands)
                {
                    var AppraisalRatingsStand = new AppraisalRating();

                    AppraisalRatingsStand.Id = Convert.ToInt32(item.id);
                    AppraisalRatingsStand.RateDescription = item.Rating;
                    AppraisalRatingsStand.Value = Convert.ToDecimal(item.value);
                    AppraisalRatingsStand.OveralMin = Convert.ToDecimal(item.overalmin);
                    AppraisalRatingsStand.OveralMax = Convert.ToDecimal(item.overalmax);
                    AppraisalRatingsStand.AvgMin = Convert.ToDecimal(item.avgmin);
                    AppraisalRatingsStand.AvgMax = Convert.ToDecimal(item.avgmax);

                    AppraisalRatingsStands.Add(AppraisalRatingsStand);
                }
            }

            tslCRange.Text = "N/A";
            tslBRange.Text = "N/A";
            tslBOveralRating.Text = "N/A";
            tslCOveralRating.Text = "N/A";
            tslRange.Text = "N/A";
            tslOveralRating.Text = "N/A";

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnSave.Enabled = getPermissions.CanAdd;
                btnPreview.Enabled = getPermissions.CanView;
                btnViewEntries.Enabled = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }

           }
           catch (Exception xi) 
           {
               Logger.LogError(xi);
               throw xi;
           }
        }

        decimal avgB = 0;
        decimal avgC = 0;
        decimal totalB = 0;
        decimal totalC = 0;
        private void ComputeTotal(DataGridView grid)
        {
            try
            {
                decimal avg=0;
                if (grid == gridB)
                    totalB = 0;
                else if (grid == gridC)
                    totalC = 0;
                AppraisalRating appraisalRating = new AppraisalRating();
                foreach (DataGridViewRow dRow in grid.Rows)
                {
                    if (grid == gridB && dRow.Cells["gridOBRating"].Value!=null)
                    {
                        appraisalRating = getRating(Convert.ToString(dRow.Cells["gridOBRating"].Value));
                        if (appraisalRating != null && appraisalRating.Id > 0)
                        {
                            totalB += appraisalRating.Value > -1 ? appraisalRating.Value : 0;
                        }
                    }
                    else if (grid == gridC && dRow.Cells["gridCRating"].Value != null)
                    {
                        appraisalRating = getRating(Convert.ToString(dRow.Cells["gridCRating"].Value));
                        if (appraisalRating != null && appraisalRating.Id > 0)
                        {
                            totalC += appraisalRating.Value > -1 ? appraisalRating.Value : 0;

                        }
                    }
                }

                if (grid == gridB)
                {
                    avg = totalB / maxBPoints;
                    avgB = avg;
                    appraisalRating = getCorrespondingRating(avg, "B");

                    if (appraisalRating != null && appraisalRating.Id > 0)
                    {
                        tslBRange.Text = appraisalRating.AvgMin + " to " + appraisalRating.AvgMax;
                        tslBOveralRating.Text = appraisalRating.Description;
                    }
                    else
                    {
                        tslBRange.Text = "N/A";
                        tslBOveralRating.Text = "N/A";
                    }
                }
                else
                {
                    avg = totalC / maxCPoints;
                    avgC = avg;

                    appraisalRating = getCorrespondingRating(avg, "C");
                    if (appraisalRating != null && appraisalRating.Id > 0)
                    {
                        tslCRange.Text = appraisalRating.AvgMin + " to " + appraisalRating.AvgMax;
                        tslCOveralRating.Text = appraisalRating.Description;
                    }
                    else
                    {
                        tslCRange.Text = "N/A";
                        tslCOveralRating.Text = "N/A";
                    }
                }

                computeGrand();
            }
            catch (Exception xi) { }
        }
        AppraisalRating GrandRating;
        private void computeGrand(){
            try
            {
                maxDPoints = maxBPoints + maxCPoints;
                var scoreB = totalB / maxBPoints;
                var scoreC = totalC / maxCPoints;
                var grand = scoreB + scoreC;
                GrandRating = getCorrespondingRating(grand, "D");

                if (GrandRating != null && GrandRating.Id > 0)
                {
                    tslOveralRating.Text = GrandRating.Description;
                    tslRange.Text = GrandRating.OveralMin + " to " + GrandRating.OveralMax;
                }
                else
                {
                    tslOveralRating.Text = "N/A";
                    tslRange.Text = "N/A";
                    GrandRating = new AppraisalRating();
                }
            }
            catch (Exception xi) { }
            
        }
        private decimal getMaxEndPoint(string pos)
        {
            try
            {
                object val = null;
                dalHelper.ClearParameters();
                if (pos == "B"){
                    dalHelper.CreateParameter("@staffId", selectedEmployee.ID, DbType.Int32);
                    dalHelper.CreateParameter("@periodId", lstAppraisalPeriods[cmbPeriod.SelectedIndex].Id, DbType.Int32);
                    val = dalHelper.ExecuteScalar("select count(id) from AppraisalObjectives where archived='false' and staffId=@staffId and periodId=@periodId");

                }
                else if(pos=="C")
                    val = dalHelper.ExecuteScalar("select count(id) from AppraisalTypes where archived='false'");

                else
                    val = dalHelper.ExecuteScalar("select max(overalmax) from AppraisalRatings where archived='false'");
                if (Information.IsNumeric(val))
                    return Convert.ToDecimal(val);
            }
            catch (Exception xi){}
            return 0;

        }
        private AppraisalRating getCorrespondingRating(decimal value, string pos)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@value", Math.Round(value, 1), DbType.Decimal);
                DataTable dt = new DataTable();
                if (pos == "B" || pos == "C")
                {
                    //var rating = GlobalData._context.AppraisalRatings.SingleOrDefault(u => u.avgmin < value && u.avgmax > value);
                    dt = dalHelper.ExecuteReader("select * from AppraisalRatings where @value between avgmin and avgmax");
                }
                else if (pos == "D")
                {
                    dt = dalHelper.ExecuteReader("select * from AppraisalRatings where @value between overalmin and overalmax");
                }



                if(dt.Rows.Count>0)
                {
                    DataRow dRow = dt.Rows[0];
                    return new AppraisalRating() { Id = Convert.ToInt32(dRow["id"]), Value = Convert.ToDecimal(dRow["value"]), Description = Convert.ToString(dRow["Rating"]), AvgMax = Convert.ToDecimal(dRow["avgmax"]), AvgMin = Convert.ToDecimal(dRow["avgmin"]), OveralMax = Convert.ToDecimal(dRow["overalmax"]), OveralMin = Convert.ToDecimal(dRow["overalmin"]) };
                }
            }
            catch (Exception xi) 
            {
                Logger.LogError(xi);
                throw xi;
            }

            return null;
                
        }
        private AppraisalRating getRating(string Rating){
            try
            {

                var appraisalRatings = GlobalData._context.AppraisalRatings.ToList();
                //foreach (DataRow dRow in this.countriesDataSet.AppraisalRatings)
                foreach (var dRow in appraisalRatings)
                {
                    var RateText = dRow.Rating;
                    var newRating = dRow.Rating;
                    if (RateText == Rating || newRating==Rating)
                        return new AppraisalRating() { Id = Convert.ToInt32(dRow.id), Value = Convert.ToDecimal(dRow.value), Description = Convert.ToString(dRow.Rating), RateDescription = RateText, AvgMax = Convert.ToDecimal(dRow.avgmax), AvgMin = Convert.ToDecimal(dRow.avgmin), OveralMax = Convert.ToDecimal(dRow.overalmax), OveralMin = Convert.ToDecimal(dRow.overalmin) };
                }
            }
            catch (Exception xi) { }
            return null;
        }
      

        private void cmbPeriod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbPeriod.SelectedItem != null)
            //    {
            //        txtStartDate.Text = lstAppraisalPeriods[cmbPeriod.SelectedIndex].StartDate.ToShortDateString();
            //        txtEndDate.Text = lstAppraisalPeriods[cmbPeriod.SelectedIndex].EndDate.ToShortDateString();
            //        maxBPoints = getMaxEndPoint("B");
            //        LoadObjectives();
            //        LoadPerformance();
            //        ShowOtherEntries();
            //    }
            //    else
            //    {
            //        txtEndDate.Clear();
            //        txtStartDate.Clear();
            //    }

            //}
            //catch (Exception xi)
            //{
            //    txtEndDate.Clear();
            //    txtStartDate.Clear();
            //    Logger.LogError(xi);
            //    throw (xi);
            //}
        }
        private void ShowOtherEntries()
        {
            try
            {
                appraisalGeneralReviewData = appraisalGeneralReviewDataMapper.getDataStaffIdANDPeriodId(selectedEmployee.ID, lstAppraisalPeriods[cmbPeriod.SelectedIndex].Id);
                txtStrengths.Text = appraisalGeneralReviewData.strengths;
                txtWeeknesses.Text = appraisalGeneralReviewData.weeknesses;
                txtTrainings.Text = appraisalGeneralReviewData.recommendedTrainings;
                txtAppraiserID.Text = appraisalGeneralReviewData.Appraiser.StaffID;
                txtAppraiserComment.Text = appraisalGeneralReviewData.AppraiserComment;
                dtpAppraiserDate.Value = appraisalGeneralReviewData.AppraiserDate;

                txtAppraiseeComment.Text = appraisalGeneralReviewData.AppraiseeComment;
                dtpAppraiseeDate.Value = appraisalGeneralReviewData.AppraiseeDate;

                txtOfficerID.Text = appraisalGeneralReviewData.Officer.StaffID;
                txtOfficerComment.Text = appraisalGeneralReviewData.OfficerComment;
                dtpOfficerDate.Value = appraisalGeneralReviewData.OfficerDate;

            }
            catch (Exception xi)
            {

                appraisalGeneralReviewData = new AppraisalGeneralReview();
            }
        }
        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            //ClearHalf();
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {

                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = true,
                            CriteriaOperator = CriteriaOperator.And
                        });

                        employees = dal.LazyLoadCriteria<Employee>(query);
                        if (employees.Count > 0)
                        {
                            foreach (Employee employee in employees)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    ctr++;
                                }
                            }
                            if (found)
                            {
                                if (searchGrid.RowCount == 2)
                                {
                                    searchGrid.Height = searchGrid.RowCount * 24;
                                }
                                else
                                {
                                    searchGrid.Height = searchGrid.RowCount * 23;
                                }
                                searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
                                searchGrid.BringToFront();
                                searchGrid.Visible = true;
                            }
                            else
                            {
                                searchGrid.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            staffIDtxt.Clear();
            nametxt.Clear();
            agetxt.Clear();
            gendertxt.Clear();
            txtEmail.Clear();
            txtPhoneNo.Clear();
            txtCurrentGrade.Clear();
            departmentTextBox.Clear();
            cmbPeriod.SelectedIndex = -1;
            txtAppraiseeID.Clear();
            txtAppraiserID.Clear();
            txtOfficerID.Clear();
            txtStrengths.Clear();
            txtWeeknesses.Clear();
            txtTrainings.Clear();
            txtAppraiseeComment.Clear();
            txtAppraiserComment.Clear();
            txtOfficerComment.Clear();
            gridB.Rows.Clear();
            gridC.Rows.Clear();

            tslBOveralRating.Text = "N/A";
            tslBRange.Text = "N/A";

            tslCOveralRating.Text = "N/A";
            tslCRange.Text = "N/A";

            tslRange.Text = "N/A";
            tslOveralRating.Text = "N/A";
            GrandRating = new AppraisalRating();
            txtStartDate.Clear();
            txtEndDate.Clear();
            this.pictureBox.Image = global::eMAS.Properties.Resources._default;
        }
        private void ClearHalf()
        {
            //staffIDtxt.Clear();
            //nametxt.Clear();
            agetxt.Clear();
            gendertxt.Clear();
            txtEmail.Clear();
            txtPhoneNo.Clear();
            txtCurrentGrade.Clear();
            departmentTextBox.Clear();
            cmbPeriod.SelectedIndex = -1;
            txtAppraiseeID.Clear();
            txtAppraiserID.Clear();
            txtOfficerID.Clear();
            txtStrengths.Clear();
            txtWeeknesses.Clear();
            txtTrainings.Clear();
            txtAppraiseeComment.Clear();
            txtAppraiserComment.Clear();
            txtOfficerComment.Clear();
            gridB.Rows.Clear();
            gridC.Rows.Clear();
        }

     public   void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;

                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;

                            departmentTextBox.Text = employee.Department.Description;

                            txtEmail.Text = employee.Email;

                            txtPhoneNo.Text = employee.TelNo;
                            txtCurrentGrade.Text = employee.GradeCategory.Description;

                            selectedEmployee = dal.ShowImageByStaffID<Employee>(employee);
                            pictureBox.Image = selectedEmployee.Photo;
                            txtAppraiseeID.Text = staffIDtxt.Text;

                            maxBPoints = getMaxEndPoint("B");
                            LoadObjectives();
                            LoadPerformance();
                            ShowOtherEntries();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            ClearHalf();
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {

                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            ctr++;
                        }
                    }
                    if (found)
                    {
                        if (searchGrid.RowCount == 2)
                        {
                            searchGrid.Height = searchGrid.RowCount * 24;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 22);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                    else
                    {
                        searchGrid.Visible = false;
                    }
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           /* cmbPeriod.SelectedIndex = -1;
            staffIDtxt.Clear();
            nametxt.Clear();*/
            Clear();

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void gridB_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ComputeTotal(gridB);
        }

        private void gridC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ComputeTotal(gridC);
        }

        private void gridB_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ComputeTotal(gridB);
        }

        private void gridC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ComputeTotal(gridC);
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dtpOfficerDate_ValueChanged(object sender, EventArgs e)
        {

        }
        Employee Appraiser;
        private void txtAppraiserID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAppraiserID.Text != string.Empty)
                {
                    Appraiser = staffDataMapper.GetByID(txtAppraiserID.Text.Trim());
                    txtAppraiserName.Text = (Appraiser.FirstName + " " + Appraiser.OtherName).Trim()+ " " + Appraiser.Surname;
                    txtAppraiserRank.Text = Appraiser.GradeCategory.Description;

                }
                else
                {
                    Appraiser = new Employee();
                    txtAppraiserName.Clear();
                    txtAppraiserRank.Clear();

                }
            }
            catch (Exception xi) {
                Logger.LogError(xi);
            }
          
        }
        Employee Appraisee;
        private void txtAppraiseeID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAppraiseeID.Text != string.Empty)
                {
                    Appraisee = staffDataMapper.GetByID(txtAppraiseeID.Text.Trim());
                    txtAppraiseeName.Text = (Appraisee.FirstName + " " + Appraisee.OtherName).Trim() +" "+ Appraisee.Surname;
                    txtAppraiseeRank.Text = Appraisee.GradeCategory.Description;

                }
                else
                {
                    Appraisee = new Employee();
                    txtAppraiseeID.Clear();
                    txtAppraiseeRank.Clear();
                    txtAppraiseeName.Clear();

                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }
        Employee Officer;
        private void txtOfficerID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOfficerID.Text != string.Empty)
                {
                    Officer = staffDataMapper.GetByID(txtOfficerID.Text.Trim());
                    txtOfficerName.Text = (Officer.FirstName + " " + Officer.OtherName).Trim() + " "+ Officer.Surname;
                    txtOfficerRank.Text = Officer.GradeCategory.Description;

                }
                else
                {
                    Officer = new Employee();
                    txtOfficerName.Clear();
                    txtOfficerRank.Clear();

                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }
        private bool isOthersValidated()
        {
            string error = string.Empty;
            if(cmbPeriod.SelectedItem==null)
            {
                error = "Appraisal Period Is Required!";
                errorProvider1.SetError(cmbPeriod, error);
                MessageBox.Show(error);
                //tabControl1.SelectedTab = tabPage1;
                return false;
            }
            else if (txtStrengths.Text == string.Empty)
            {
                error = "Appraisee's Strength Info Is Required!";
                errorProvider1.SetError(txtStrengths, error);
                tabControl1.SelectedTab = tabPage3;
                MessageBox.Show(error);
                return false;
            }
            else if (txtWeeknesses.Text == string.Empty)
            {
                error = "Appraisee's Weeknesses Info Is Required!";
                errorProvider1.SetError(txtWeeknesses, error);
                tabControl1.SelectedTab = tabPage3;
                MessageBox.Show(error);
                return false;
            }
            else if (txtTrainings.Text == string.Empty)
            {
                error = "Appraisee's Training Info Is Required!";
                errorProvider1.SetError(txtTrainings, error);
                tabControl1.SelectedTab = tabPage3;
                MessageBox.Show(error);
                return false;
            }
            else if (txtAppraiserID.Text == string.Empty)
            {
                error = "Appraiser's ID Is Required!";
                errorProvider1.SetError(txtAppraiserID, error);
                tabControl1.SelectedTab = tabPage4;
                MessageBox.Show(error);
                return false;
            }
            else if (txtAppraiserComment.Text == string.Empty)
            {
                error = "Appraiser's Comment Is Required!";
                errorProvider1.SetError(txtAppraiserComment, error);
                tabControl1.SelectedTab = tabPage4;
                MessageBox.Show(error);
                return false;
            }

            else if (txtAppraiseeID.Text == string.Empty)
            {
                error = "Appraisee's ID Is Required!";
                errorProvider1.SetError(txtAppraiseeID, error);
                tabControl1.SelectedTab = tabPage4;
                MessageBox.Show(error);
                return false;
            }
            else if (txtAppraiseeComment.Text == string.Empty)
            {
                error = "Appraisee's Comment Is Required!";
                errorProvider1.SetError(txtAppraiseeComment, error);
                tabControl1.SelectedTab = tabPage4;
                MessageBox.Show(error);
                return false;
            }

            else if (txtOfficerID.Text == string.Empty)
            {
                error = "Counter Signing Officer's ID Is Required!";
                errorProvider1.SetError(txtOfficerID, error);
                tabControl1.SelectedTab = tabPage5;
                MessageBox.Show(error);
                return false;
            }
            else if (txtOfficerComment.Text == string.Empty)
            {
                error = "Counter Signing Officer's Comment Is Required!";
                errorProvider1.SetError(txtOfficerComment, error);
                tabControl1.SelectedTab = tabPage5;
                MessageBox.Show(error);
                return false;
            }

            return true;

        }
        private bool isGridValidated(DataGridView grid)
        {
            grid.ShowRowErrors = false;
            int total = 0;
            foreach (DataGridViewRow dRow in grid.Rows)
            {
                dRow.ErrorText = string.Empty;
                if (gridB == grid)
                {
                    if (dRow.Cells["gridObjective"].Value != null && dRow.Cells["gridOBRating"].Value == null)
                    {
                        dRow.ErrorText = dRow.Cells["gridObjective"].Value + " Must Be Rated!";
                        MessageBox.Show(dRow.ErrorText);
                        grid.ShowRowErrors = true;
                        return false;
                    }
                    else
                        total++;
                }
                else
                {
                    if (dRow.Cells["gridFactor"].Value != null && dRow.Cells["gridCRating"].Value == null)
                    {
                        dRow.ErrorText = dRow.Cells["gridFactor"].Value + " Must Be Rated!";
                        MessageBox.Show(dRow.ErrorText);
                        grid.ShowRowErrors = true;
                        return false;
                    }
                    else
                        total++;
                }
               
            }
            return Convert.ToBoolean(total);
        }
        private void RateObjectives(DALHelper dalHelper)
        {
            try
            {
                foreach (DataGridViewRow dRow in gridB.Rows)
                {
                    if (dRow.Cells["gridID"].Value != null)
                    {
                        AppraisalRating appraisalRating = getRating(Convert.ToString(dRow.Cells["gridOBRating"].Value));
                        //dalHelper = new DALHelper();

                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@Id", Convert.ToInt32(dRow.Cells["gridID"].Value), DbType.Int32);
                        dalHelper.CreateParameter("@periodId", lstAppraisalPeriods[cmbPeriod.SelectedIndex].Id, DbType.Int32);
                        dalHelper.CreateParameter("@ratingId", appraisalRating.Id, DbType.Int32);
                        dalHelper.CreateParameter("@comment", Convert.ToString(dRow.Cells["gridComment"].Value), DbType.String);
                        dalHelper.CreateParameter("@dateModified", DateTime.Now.Date, DbType.Date);
                        dalHelper.CreateParameter("@modifiedBy", GlobalData.User.ID, DbType.Int32);

                        dalHelper.ExecuteNonQuery("update AppraisalObjectives set ratingId=@ratingId,comment=@comment,dateModified=@dateModified,modifiedBy=@modifiedBy where id=@Id");
                    }
                    
                }
            }
            catch (Exception xi)
            {
                dalHelper.RollBackTransaction();
                Logger.LogError(xi);
                throw (xi);
            }
            
        }
        private void RateFactors(DALHelper dalHelper)
        {
            try
            {
                foreach (DataGridViewRow dRow in gridC.Rows)
                {
                    if (dRow.Cells["gridFactorId"].Value != null)
                    {
                        AppraisalRating appraisalRating = getRating(Convert.ToString(dRow.Cells["gridCRating"].Value));
                        //dalHelper = new DALHelper();

                        dalHelper.ClearParameters();

                        dalHelper.CreateParameter("@periodId", lstAppraisalPeriods[cmbPeriod.SelectedIndex].Id, DbType.Int32);
                        dalHelper.CreateParameter("@ratingId", appraisalRating.Id, DbType.Int32);
                        dalHelper.CreateParameter("@staffId", selectedEmployee.ID, DbType.Int32);
                        dalHelper.CreateParameter("@comment", Convert.ToString(dRow.Cells["gridCComments"].Value), DbType.String);
                        dalHelper.CreateParameter("@entryDate", DateTime.Now.Date, DbType.Date);
                        dalHelper.CreateParameter("@enteredBy", GlobalData.User.ID, DbType.Int32);

                        dalHelper.CreateParameter("@factorId", Convert.ToInt32(dRow.Cells["gridFactorId"].Value), DbType.Int32);

                        if (Information.IsNumeric(dRow.Cells["gridCID"].Value) && Convert.ToInt32(dRow.Cells["gridCID"].Value)>0)
                        {
                            dalHelper.CreateParameter("@Id", Convert.ToInt32(dRow.Cells["gridCID"].Value), DbType.Int32);
                            dalHelper.ExecuteNonQuery("update AppraisalGeneralPerformanceRatings set ratingId=@ratingId,comment=@comment,entryDate=@entryDate,enteredBy=@enteredBy where factorId=@factorId and periodId=@periodId and staffId=@staffId");
                        }
                        else
                        {
                            dalHelper.CreateParameter("@archived",false, DbType.Boolean);
                            dalHelper.ExecuteNonQuery("insert AppraisalGeneralPerformanceRatings (periodId,ratingId,comment,entryDate,enteredBy,factorId,staffId,archived) values(@periodId,@ratingId,@comment,@entryDate,@enteredBy,@factorId,@staffId,@archived)");

                        }
                    
                    }
                }
            }
            catch (Exception xi)
            {
                dalHelper.RollBackTransaction();
                Logger.LogError(xi);
                throw (xi);

            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isGridValidated(gridB) && isGridValidated(gridC) && isOthersValidated())
                {
                    dalHelper = new DALHelper();

                    dalHelper.ClearParameters();

                    dalHelper.BeginTransaction();

                    RateObjectives(dalHelper);
                    RateFactors(dalHelper);
                    
                    computeGrand();

                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@strengths", txtStrengths.Text, DbType.String);
                    dalHelper.CreateParameter("@weeknesses", txtWeeknesses.Text, DbType.String);
                    dalHelper.CreateParameter("@recommendedTrainings", txtTrainings.Text, DbType.String);

                    dalHelper.CreateParameter("@ratingId", GrandRating.Id, DbType.Int32);

                    dalHelper.CreateParameter("@appraiserId", Appraiser.ID, DbType.Int32);
                    dalHelper.CreateParameter("@appraiserComment", txtAppraiserComment.Text, DbType.String);
                    dalHelper.CreateParameter("@appraiserDate", dtpAppraiserDate.Value.Date, DbType.Date);

                    dalHelper.CreateParameter("@appraiseeId", selectedEmployee.ID, DbType.Int32);
                    dalHelper.CreateParameter("@appraiseeComment", txtAppraiseeComment.Text, DbType.String);
                    dalHelper.CreateParameter("@appraiseeDate", dtpAppraiseeDate.Value.Date, DbType.Date);

                    dalHelper.CreateParameter("@officerId", Officer.ID, DbType.Int32);
                    dalHelper.CreateParameter("@officerComment", txtOfficerComment.Text, DbType.String);
                    dalHelper.CreateParameter("@officerDate", dtpOfficerDate.Value.Date, DbType.Date);

                    dalHelper.CreateParameter("@sectionBRate", avgB, DbType.Decimal);
                    dalHelper.CreateParameter("@sectionBRateDescription", tslBOveralRating.Text, DbType.String);

                    dalHelper.CreateParameter("@sectionCRate", avgC, DbType.Decimal);
                    dalHelper.CreateParameter("@sectionCRateDescription", tslCOveralRating.Text, DbType.String);

                    dalHelper.CreateParameter("@overalRate",GrandRating.Value, DbType.Decimal);
                    dalHelper.CreateParameter("@overalDescription",GrandRating.Description, DbType.String);

                    if (appraisalGeneralReviewData != null && appraisalGeneralReviewData.Id > 0)
                    {
                        dalHelper.CreateParameter("@Id", appraisalGeneralReviewData.Id, DbType.Int32);

                        dalHelper.ExecuteNonQuery("update AppraisalGeneralReviews set strengths=@strengths,weeknesses=@weeknesses," +
                            "recommendedTrainings=@recommendedTrainings,ratingId=@ratingId,appraiserId=@appraiserId,appraiserComment=@appraiserComment," +
                            "appraiserDate=@appraiserDate,appraiseeId=@appraiseeId,appraiseeComment=@appraiseeComment,appraiseeDate=@appraiseeDate," +
                            "officerId=@officerId,officerComment=@officerComment,officerDate=@officerDate,sectionBRate=@sectionBRate," +
                            "sectionBRateDescription=@sectionBRateDescription,sectionCRate=@sectionCRate, sectionCRateDescription=@sectionCRateDescription," +
                            "overalRate=@overalRate,overalDescription=@overalDescription " +
                            "where id=@Id");
                        dalHelper.CommitTransaction();
                        Clear();
                        MessageBox.Show("Appraisal edited Successfully!");
                    }
                    else
                    {
                        dalHelper.CreateParameter("@entryDate", DateTime.Now.Date, DbType.Date);
                        dalHelper.CreateParameter("@enteredBy", GlobalData.User.ID, DbType.Int32);

                        dalHelper.CreateParameter("@archived",false, DbType.Boolean);

                        dalHelper.CreateParameter("@periodId", lstAppraisalPeriods[cmbPeriod.SelectedIndex].Id, DbType.Int32);

                        dalHelper.ExecuteNonQuery("insert into AppraisalGeneralReviews(strengths,weeknesses,recommendedTrainings,ratingId,appraiserId," +
                            "appraiserComment,appraiserDate,appraiseeId,appraiseeComment,appraiseeDate,officerId,officerComment,officerDate,entryDate," +
                            "enteredBy,periodId,sectionBRate,sectionBRateDescription,sectionCRate,sectionCRateDescription,overalRate,overalDescription,archived) " +
                            "values (@strengths,@weeknesses,@recommendedTrainings,@ratingId,@appraiserId,@appraiserComment,@appraiserDate,@appraiseeId," +
                            "@appraiseeComment,@appraiseeDate,@officerId,@officerComment,@officerDate,@entryDate,@enteredBy,@periodId,@sectionBRate," +
                            "@sectionBRateDescription,@sectionCRate,@sectionCRateDescription,@overalRate,@overalDescription,@archived)");

                        dalHelper.CommitTransaction();
                        cmbPeriod_SelectionChangeCommitted(sender, e);
                        Clear();
                        MessageBox.Show("Appraisal Saved Successfully!");
                    }

                }
               
                //MessageBox.Show("Appraisal Saved Successfully!");
            }
            catch (Exception xi)
            {
                try
                {
                    if (!xi.Message.ToLower().Contains("duplicate")){
                        MessageBox.Show("Unable To Save Appraisal!");
                        dalHelper.RollBackTransaction();
                        Logger.LogError(xi);
                    }
                    else
                    {
                        MessageBox.Show("Appraisal Saved Successfully!");
                    }
                      
                    
                }
                catch (Exception xii)
                {

                }
               
            }
            
        }
       
        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewAppraisalForm reportForm;
            if(staffIDtxt.Text==string.Empty || nametxt.Text==string.Empty)
            {
                reportForm = new PreviewAppraisalForm(new AppraisalGeneralReview());
                reportForm.CanPrint = CanPrint;
            }
            else
            {
                reportForm = new PreviewAppraisalForm(appraisalGeneralReviewData);
                reportForm.CanPrint = CanPrint;
            }
            reportForm.Show(this);
        }

        private void btnViewEntries_Click(object sender, EventArgs e)
        {
            AppraisalFormView viewForm = new AppraisalFormView(this);
            viewForm.btnRemove.Enabled = CanDelete;
            viewForm.MdiParent = this.MdiParent;
            viewForm.Show();
        }

        public void updateDates()
        {
            try
            {
                txtStartDate.Text = lstAppraisalPeriods[cmbPeriod.SelectedIndex].StartDate.ToShortDateString();
                txtEndDate.Text = lstAppraisalPeriods[cmbPeriod.SelectedIndex].EndDate.ToShortDateString();

               //cmbPeriod.SelectedItem = cmbPeriod.Text = lstAppraisalPeriods[cmbPeriod.SelectedIndex].Description.Trim();
            }
            catch (Exception xi) { }
            
        }

        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridB.CurrentCell.ColumnIndex == 2)
                {
                    gridOBRating.Items.Clear();
                    getBRatings();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void getBRatings()
        {
            try
            {
                var appraisalRatings = GlobalData._context.AppraisalRatings.ToList();

                foreach (var rating in appraisalRatings)
                {
                    gridOBRating.Items.Add(rating.Rating);
                }
            }
            catch (Exception ex )
            {
                
                throw ex;
            }
        }

        private void getCRatings()
        {
            try
            {
                var appraisalRatings = GlobalData._context.AppraisalRatings.ToList();

                foreach (var rating in appraisalRatings)
                {
                    gridCRating.Items.Add(rating.Rating);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void gridC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridC.CurrentCell.ColumnIndex == 3)
                {
                    gridCRating.Items.Clear();
                    getCRatings();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmbPeriod_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cmbPeriod.SelectedItem != null)
                {
                    txtStartDate.Text = lstAppraisalPeriods[cmbPeriod.SelectedIndex].StartDate.ToShortDateString();
                    txtEndDate.Text = lstAppraisalPeriods[cmbPeriod.SelectedIndex].EndDate.ToShortDateString();
                    maxBPoints = getMaxEndPoint("B");
                    //var result = GlobalData._context.AppraisalGeneralReviews.Where(u =>u.appraiseeId.ToString == staffIDtxt.Text && u.periodId == lstAppraisalPeriods[cmbPeriod.SelectedIndex].Id && u.archived == false).ToList();
                    //if (result.Count > 0)
                    //{
                        LoadObjectives();
                        LoadPerformance();
                        ShowOtherEntries();
                        computeGrand();
                    //}
                    
                }
                else
                {
                    txtEndDate.Clear();
                    txtStartDate.Clear();
                }

            }
            catch (Exception xi)
            {
                txtEndDate.Clear();
                txtStartDate.Clear();
                Logger.LogError(xi);
                throw (xi);
            }
        }

        private void gridLast_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var loadObj = GlobalData._context.ViewAppraisalObjectives.FirstOrDefault(u => u.periodId == cmbPeriod.SelectedIndex && u.staffId.ToString() == selectedEmployee.StaffID);

                //foreach (var item in loadObj)
                //{
                //    gridLast.Rows[ctr].Cells["gridRating"].Value =
                //}
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //private void cboRating_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cboRating.Items.Clear();
        //        var appraisalRatings = GlobalData._context.AppraisalRatings.ToList();
        //        foreach (var rating in appraisalRatings)
        //        {
        //            cboRating.Items.Add(rating.Rating);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        private void cboRating_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
