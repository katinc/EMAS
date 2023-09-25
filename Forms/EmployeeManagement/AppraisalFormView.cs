using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;
using eMAS.Forms.OtherDataSets.HR2DatasetTableAdapters;
using HRDataAccessLayer.System_Setup_Data_Control;
using eMAS.Forms.EmployeeManagement;

namespace eMAS.Forms.Reports
{
    public partial class AppraisalFormView : Form
    {
       		private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Zone> zones;

        private IList<ExcuseDutyRequestType> requestTypes;
        private ExcuseDutyRequestTypeDataMapper requestTypesDataMapper;

        private IDAL dal;
        private Form reportForm;
        private Company company;
        private int ctr;

        private DALHelper dalHelper;

        private Employee selectedEmployee;

        private ApraisalForm parentForm;

        public AppraisalFormView(ApraisalForm parentForm)
        {
            try
            {
                InitializeComponent();
                this.periodDataMapper = new AppraisalPeriodDataMapper();
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.selectedEmployee = new Employee();

                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.zones = new List<Zone>();
                this.requestTypes = new List<ExcuseDutyRequestType>();
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.ctr = 0;
                this.company = new Company();

                this.parentForm = parentForm;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbOption.Text == "All Employees")
                {
                    staffNoLabel.Visible = false;
                    nameLabel.Visible = false;
                    txtStaffName.Visible = false;
                    txtStaffNo.Visible = false;
                    searchGrid.Visible = false;
                    lblDepartment.Visible = true;
                    cboDepartment.Visible = true;
                    lblUnit.Visible = true;
                    cboUnit.Visible = true;
                    lblGradeCategory.Visible = true;
                    cboGradeCategory.Visible = true;
                    lblGrade.Visible = true;
                    cboGrade.Visible = true;
                    lblZone.Visible = true;
                    cboZone.Visible = true;
                    lblLeaveType.Visible = true;
                    cboAppraisalPeriod.Visible = true;
                   
                }
                else
                {
                    staffNoLabel.Visible = true;
                    nameLabel.Visible = true;
                    txtStaffName.Visible = true;
                    txtStaffNo.Visible = true;
                    searchGrid.Visible = true;
                    lblDepartment.Visible = false;
                    cboDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboUnit.Visible = false;
                    lblGradeCategory.Visible = false;
                    cboGradeCategory.Visible = false;
                    lblGrade.Visible = false;
                    cboGrade.Visible = false;
                    lblZone.Visible = false;
                    cboZone.Visible = false;
                    lblLeaveType.Visible = false;
                    cboAppraisalPeriod.Visible = false;
                  
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private IList<AppraisalPeriod> lstAppraisalPeriods;
        private AppraisalPeriodDataMapper periodDataMapper;
        private void btnOK_Click(object sender, EventArgs e)
        {
            

            //eMAS.Forms.OtherDataSets.HR2Dataset.reportFilterDataTable reportFilterDataTable=new OtherDataSets.HR2Dataset.reportFilterDataTable();
            
            //DataRow reportFilterDataRow=reportFilterDataTable.NewRow();
             dalHelper.ClearParameters();
            try
            {

                string sql = "select top 50 * from ViewAppraisalGeneralReviews";
                DataTable dt;
                string where=string.Empty;
                string errorText = string.Empty;

                //reportFilterDataRow["filterDept"] = "All";
                //reportFilterDataRow["filterUnit"] = "All";
                //reportFilterDataRow["filterZone"] = "All";
                //reportFilterDataRow["filterGradeCategory"] = "All";
                //reportFilterDataRow["filterGrade"] = "All";
               
                //reportFilterDataRow["filterAppraisalType"] = "All";
                if (cmbOption.Text == "Individual Employee")
                {
                    if (selectedEmployee == null || selectedEmployee.ID == 0){
                        errorText="Staff No Is Required";
                        staffErrorProvider.SetError(txtStaffNo,errorText);
                    }
                    else{
                        dalHelper.CreateParameter("@appraiseeId", selectedEmployee.ID, DbType.Int32);
                        where = "appraiseeId=@appraiseeId and ";
                    }
                    //dt=excuseDutyAdapta.GetDataByStaffId(selectedEmployee.ID);
                }
                else if(cmbOption.SelectedIndex==-1)
                {
                    errorText="Please Select Report Option";
                    staffErrorProvider.SetError(cmbOption,errorText);
                }
                else
                {
                   
                    if (cboDepartment.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Appraisee_Department", cboDepartment.SelectedItem, DbType.String);
                        //reportFilterDataRow["filterDept"] = cboDepartment.SelectedItem;
                        where += " Appraisee_Department=@Appraisee_Department and ";
                    }

                    
                    if (cboUnit.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Appraisee_Unit", cboUnit.SelectedItem, DbType.String);
                        //reportFilterDataRow["filterUnit"] = cboUnit.SelectedItem;
                        where += " Appraisee_Unit=@Appraisee_Unit and ";
                    }

                    
                    if (cboZone.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Appraisee_Zone", cboZone.SelectedItem, DbType.String);
                        //reportFilterDataRow["filterZone"] = cboZone.SelectedItem;
                        where += " Appraisee_Zone=@Appraisee_Zone and ";
                    }

                    
                    if (cboGradeCategory.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Appraisee_GradeCategory", cboGradeCategory.SelectedItem, DbType.String);
                        //reportFilterDataRow["filterGradeCategory"] = cboGradeCategory.SelectedItem;
                        where += " Appraisee_GradeCategory=@Appraisee_GradeCategory and ";
                    }

                   
                    if (cboGrade.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Appraisee_Grade", cboGrade.SelectedItem, DbType.String);
                        //reportFilterDataRow["filterGrade"] = cboGrade.SelectedItem;
                        where += " Appraisee_Grade=@Appraisee_Grade and ";
                    }

                    
                    //if (cboAppraisalPeriod.SelectedItem != null)
                    //{
                    //    dalHelper.CreateParameter("@RequestType", cboAppraisalPeriod.SelectedItem, DbType.String);
                    //    reportFilterDataRow["filterRequestType"] = cboAppraisalPeriod.SelectedItem;
                    //    where += " RequestType=@RequestType and ";
                    //}
                }

                if (errorText != string.Empty)
                    MessageBox.Show(errorText);
                else{

                        if (cboAppraisalPeriod.Text != string.Empty)
                        {
                            //reportFilterDataRow["filterAppraisalType"] = cboAppraisalPeriod.Text;
                            dalHelper.CreateParameter("@PeriodId", lstAppraisalPeriods[cboAppraisalPeriod.SelectedIndex].Id, DbType.Int32);
                            where += " PeriodId=@PeriodId and ";
                        }
                        if (datePickerFrom.Checked == true)
                        {
                            dalHelper.CreateParameter("@entryDate", datePickerFrom.Value.Date, DbType.Date);
                            where += " entryDate>=@entryDate and ";
                        }

                        if (datePickerTo.Checked == true)
                        {
                            dalHelper.CreateParameter("@entryDate", datePickerTo.Value.Date, DbType.Date);
                            where += " entryDate<=@entryDate and ";
                        }

                        dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                        where += " Archived<=@Archived and ";



                        //reportFilterDataTable.Rows.Add(reportFilterDataRow);
                        if (where != string.Empty) where = " where " + where;
                        sql = sql + AppUtils.TrimEnd(where, "and ");
                        dt = new DataTable();
                        dt= dalHelper.ExecuteReader(sql);

                        fillGrid(dt);
                     //reportForm = new AppraisalReportForm(dt,reportFilterDataTable);
                    //reportForm.Show();
                }
             
               // reportForm = new LeaveReportForm(txtStaffNo.Text.Trim(), cboRequestType.Text.Trim(), datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim(),cboRecommended.Text.Trim(),cboApproved.Text.Trim());
                //reportForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }
        private void fillGrid(DataTable dt)
        {
            try
            {
                gridAppraisalView.Rows.Clear();
                int ctr = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    gridAppraisalView.Rows.Add(1);
                    
                    gridAppraisalView.Rows[ctr].Cells["gridID"].Value = dr["id"];
                    gridAppraisalView.Rows[ctr].Cells["gridStaffID"].Value = dr["Appraisee_StaffID"];
                    gridAppraisalView.Rows[ctr].Cells["gridStaffName"].Value = (dr["Appraisee_FirstName"] + " " + dr["Appraisee_OtherName"] ).Trim()+ " " + dr["Appraisee_Surname"];
                    gridAppraisalView.Rows[ctr].Cells["gridPeriod"].Value = dr["Period"] + "-" + dr["PeriodYear"];
                    gridAppraisalView.Rows[ctr].Cells["gridWeekness"].Value = dr["weeknesses"];
                    gridAppraisalView.Rows[ctr].Cells["gridStrength"].Value = dr["strengths"];

                    gridAppraisalView.Rows[ctr].Cells["gridSectionBValue"].Value = dr["sectionBRate"];
                    gridAppraisalView.Rows[ctr].Cells["gridSectionBRemarks"].Value = dr["sectionBRateDescription"];

                    gridAppraisalView.Rows[ctr].Cells["gridSectionCValue"].Value = dr["sectionCRate"];
                    gridAppraisalView.Rows[ctr].Cells["gridSectionCRemarks"].Value = dr["sectionCRateDescription"];

                    gridAppraisalView.Rows[ctr].Cells["gridOveralRate"].Value = dr["overalRate"];
                    gridAppraisalView.Rows[ctr].Cells["gridOveralRemarks"].Value = dr["overalDescription"];

                    gridAppraisalView.Rows[ctr].Cells["gridEntryDate"].Value = Convert.ToDateTime(dr["entryDate"]).ToShortDateString();

                    gridAppraisalView.Rows[ctr].Cells["gridPeriodId"].Value = dr["PeriodId"];
                    gridAppraisalView.Rows[ctr].Cells["gridStaffNum"].Value = dr["AppraiseeId"];

                    ctr++;
                }
                gridAppraisalView.ClearSelection();
            }
            catch (Exception xi) { }
           
        }
        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffNo.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (txtStaffNo.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffNo.Text.Trim() + '%',
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
                                if (employee.StaffID.Trim().ToLower().StartsWith(txtStaffNo.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
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
                                searchGrid.Location = new Point(txtStaffNo.Location.X, txtStaffNo.Location.Y + 21);
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
                            MessageBox.Show("Employee with StaffID " + txtStaffNo.Text.Trim() + " is not Found");
                            txtStaffNo.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    ClearStaffInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffName.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(txtStaffName.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
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
                        searchGrid.Location = new Point(txtStaffName.Location.X, txtStaffName.Location.Y + 21);
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
                    ClearStaffInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEmployee = new Employee();
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    ClearStaffInfo();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            txtStaffName.Text = name;
                            txtStaffNo.Text = employee.StaffID;

                            selectedEmployee = employee;
                            searchGrid.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
                cboZone.Text = string.Empty;
                cboZone.Items.Add("All");
                zones = dal.GetAll<Zone>();
                foreach (Zone zone in zones)
                {
                    cboZone.Items.Add(zone.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboDepartment.Items.Add("All");
                departments = dal.GetAll<Department>();

                foreach (Department department in departments)
                {
                    cboDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    cboGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
               /* Query query = new Query();
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });*/
                //Pulling Employee Grade
                SqlDataAdapter adapta = new SqlDataAdapter("Select * from EmployeeGradeView where EmployeeGradeView.Archived='False' and GradeCategory=@GradeCategory Order By EmployeeGradeView.Description,EmployeeGradeView.GradeCategory ASC", dalHelper.ConnectionString());
                adapta.SelectCommand.Parameters.AddWithValue("@GradeCategory", cboGradeCategory.SelectedItem);

                var dtEmpGrade = new DataTable();

                adapta.Fill(dtEmpGrade);

                foreach(DataRow dRow in dtEmpGrade.Rows){

                    var empGrade = new EmployeeGrade()
                    {
                        ID=int.Parse(dRow["ID"].ToString()),
                        Grade=dRow["Description"].ToString(),
                    };
                    cboGrade.Items.Add(empGrade.Grade);
                    employeeGrades.Add(empGrade);
                }
                
            
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
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
                    Value = cboDepartment.SelectedItem,
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

        private void Clear()
        {
            try
            {
                ClearStaffInfo();
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                cboZone.Items.Clear();
                datePickerFrom.ResetText();
                datePickerTo.ResetText();
                searchGrid.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        private void ClearStaffInfo()
        {
            try
            {
                txtStaffNo.Clear();
                txtStaffName.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

      
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ExcuseDutyReportFilter_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

     
        private void cboAppraisalPeriod_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAppraisalPeriod.Items.Clear();
                lstAppraisalPeriods = periodDataMapper.getData(true, false);
                foreach (var period in lstAppraisalPeriods)
                {
                    cboAppraisalPeriod.Items.Add(period.Description+"("+period.Year+")");
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }

        private void btnClearSeletion_Click(object sender, EventArgs e)
        {
            gridAppraisalView.ClearSelection();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
           
            if (gridAppraisalView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(this, "Do you really want to delete record", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                     dalHelper = new DALHelper();
                                        dalHelper.ClearParameters();

                                        dalHelper.BeginTransaction();
                                        dalHelper.CreateParameter("@PeriodId", Convert.ToInt32(gridAppraisalView.SelectedRows[0].Cells["gridPeriodId"].Value), DbType.Int32);
                                        dalHelper.CreateParameter("@StaffID", Convert.ToInt32(gridAppraisalView.SelectedRows[0].Cells["gridStaffNum"].Value), DbType.Int32);

                                        dalHelper.ExecuteNonQuery("update AppraisalGeneralReviews set archived='true' where periodId=@PeriodId and appraiseeId=@StaffID");

                                        dalHelper.ExecuteNonQuery("update AppraisalGeneralPerformanceRatings set archived='true' where periodId=@PeriodId and staffId=@StaffID");

                                        dalHelper.ExecuteNonQuery("update AppraisalObjectives set archived='true' where periodId=@PeriodId and staffId=@StaffID");

                                        dalHelper.CommitTransaction();
                                        MessageBox.Show("Record Removed Successfully!");
                                        gridAppraisalView.Rows.Remove(gridAppraisalView.SelectedRows[0]);
                    }
                    catch (Exception xi) {

                        MessageBox.Show("Unable To Remove Record!");
                    }
                   
                }
            }
        }
        //private AppraisalPeriodDataMapper periodMapper;
        void gridDoubleClick()
        {
            try
            {
                if (gridAppraisalView.SelectedRows.Count > 0)
                {

                    //periodDataMapper = new AppraisalPeriodDataMapper();
                    parentForm.staffIDtxt.Text = Convert.ToString(gridAppraisalView.SelectedRows[0].Cells["gridStaffID"].Value);

                    var selectedPeriodId = Convert.ToInt32(gridAppraisalView.SelectedRows[0].Cells["gridPeriodId"].Value);

                    parentForm.cmbPeriod.SelectedItem = parentForm.cmbPeriod.Text = parentForm.lstAppraisalPeriods.Where(r => r.Id == selectedPeriodId).FirstOrDefault().Description.Trim();



                    parentForm.updateDates();

                    parentForm.searchGrid.Rows[0].Selected = true;

                    DataGridViewCellEventArgs arg = new DataGridViewCellEventArgs(0, 0);
                    parentForm.searchGrid_CellClick(this, arg);
                    //parentForm.searchGrid.se
                    //gridAppraisalView_DoubleClick(sender, e);

                    
                }
                else
                    MessageBox.Show("Sorry No Record was selected!");
            }
            catch (Exception xi)
            {
                parentForm.cmbPeriod.SelectedIndex = -1;
            }
        }
        private void gridAppraisalView_DoubleClick(object sender, EventArgs e)
        {
            if (parentForm.CanEdit)
            {
                gridDoubleClick();
                if (parentForm.cmbPeriod.Text == string.Empty)
                    gridDoubleClick();

                this.Close();
            }
            else
            {
                MessageBox.Show("Sorry you do not have permission to edit this data.");
            }

        }
    }
}
