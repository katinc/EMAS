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
using HRBussinessLayer.System_Setup_Data_Control;

namespace eMAS.Forms.Reports
{
    public partial class TrainingBondReportFilter : Form
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

        private string connectionString;
        private DALHelper dalHelper;

        private Employee selectedEmployee;

        private IList<AttendedSchool> lstInstitutions;
        private AttendedSchoolDataMapper attendedSchoolAdapta;

        public TrainingBondReportFilter()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.selectedEmployee = new Employee();
                this.attendedSchoolAdapta = new AttendedSchoolDataMapper();

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
                    lblStatus.Visible = true;
                    cboStatus.Visible = true;
                    lblAttendanceMode.Visible = true;
                    cboAttendanceMode.Visible = true;
                   
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
                    lblStatus.Visible = false;
                    cboStatus.Visible = false;
                    lblAttendanceMode.Visible = false;
                    cboAttendanceMode.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            eMAS.Forms.OtherDataSets.HR2Dataset.reportFilterDataTable reportFilterDataTable=new OtherDataSets.HR2Dataset.reportFilterDataTable();
            
            DataRow reportFilterDataRow=reportFilterDataTable.NewRow();
             dalHelper.ClearParameters();
            try
            {

                string sql = "select * from ViewTrainingBond ";
                DataTable dt;
                string where=string.Empty;
                string errorText = string.Empty;

                reportFilterDataRow["filterDept"] = "All";
                reportFilterDataRow["filterUnit"] = "All";
                reportFilterDataRow["filterZone"] = "All";
                reportFilterDataRow["filterGradeCategory"] = "All";
                reportFilterDataRow["filterGrade"] = "All";

                reportFilterDataRow["filterBondedStatus"] = "All";
                reportFilterDataRow["filterInstitution"] = "All";
                reportFilterDataRow["filterQualification"] = "All";

                reportFilterDataRow["filterAttendanceMode"] = "All";

                if (cmbOption.Text == "Individual Employee")
                {
                    if (selectedEmployee == null || selectedEmployee.ID == 0){
                        errorText="Staff No Is Required";
                        staffErrorProvider.SetError(txtStaffNo,errorText);
                    }
                    else{
                        dalHelper.CreateParameter("@StaffId",selectedEmployee.ID,DbType.Int32);
                       
                        where="staffId=@StaffId and ";
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
                        dalHelper.CreateParameter("@Department", cboDepartment.SelectedItem, DbType.String);
                        reportFilterDataRow["filterDept"] = cboDepartment.SelectedItem;
                        where += " Department=@Department and ";
                    }

                    
                    if (cboUnit.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Unit", cboUnit.SelectedItem, DbType.String);
                        reportFilterDataRow["filterUnit"] = cboUnit.SelectedItem;
                        where += " Unit=@Unit and ";
                    }

                    
                    if (cboZone.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Zone", cboZone.SelectedItem, DbType.String);
                        reportFilterDataRow["filterZone"] = cboZone.SelectedItem;
                        where += " Zone=@Zone and ";
                    }

                    
                    if (cboGradeCategory.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@GradeCategory", cboGradeCategory.SelectedItem, DbType.String);
                        reportFilterDataRow["filterGradeCategory"] = cboGradeCategory.SelectedItem;
                        where += " GradeCategory=@GradeCategory and ";
                    }

                   
                    if (cboGrade.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Grade", cboGrade.SelectedItem, DbType.String);
                        reportFilterDataRow["filterGrade"] = cboGrade.SelectedItem;
                        where += " Grade=@Grade and ";
                    }

                    
                    if (cboAttendanceMode.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@AttendanceMode", cboAttendanceMode.SelectedItem, DbType.String);
                        reportFilterDataRow["filterAttendanceMode"] = cboAttendanceMode.SelectedItem;
                        where += " AttendanceMode=@AttendanceMode and ";
                    }

                    if (cboInstitution.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@School", cboInstitution.SelectedItem, DbType.String);
                        reportFilterDataRow["filterInstitution"] = cboInstitution.SelectedItem;
                        where += " School=@School and ";
                    }

                    if (cboQualification.SelectedItem != null)
                    {
                        dalHelper.CreateParameter("@Qualification", cboQualification.SelectedItem, DbType.String);
                        reportFilterDataRow["filterQualification"] = cboQualification.SelectedItem;
                        where += " Qualification=@Qualification and ";
                    }
                }

                if (errorText != string.Empty)
                    MessageBox.Show(errorText);
                else{
                 
                      

                        if (cboStatus.Text !="All" && cboStatus.Text!=string.Empty)
                        {
                            dalHelper.CreateParameter("@status", cboStatus.SelectedItem, DbType.String);
                            reportFilterDataRow["filterBondedStatus"] = cboStatus.SelectedItem;
                            where += " status=@status and ";
                        }
                       

                        if (datePickerFrom.Checked == true)
                        {
                            dalHelper.CreateParameter("@courseStartDate", datePickerFrom.Value.Date, DbType.Date);
                            where += " courseStartDate>=@courseStartDate and ";
                        }

                        if (datePickerTo.Checked == true)
                        {
                            dalHelper.CreateParameter("@courseEndDate", datePickerTo.Value.Date, DbType.Date);
                            where += " courseEndDate<=@courseEndDate and ";
                        }


                        reportFilterDataTable.Rows.Add(reportFilterDataRow);
                        if (where != string.Empty) where = " where " + where;
                        sql = sql + AppUtils.TrimEnd(where, "and ");
                        dt = new DataTable();
                        dt= dalHelper.ExecuteReader(sql);
                        reportForm = new TrainingBondReportForm(dt, reportFilterDataTable);
                    reportForm.Show();
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
                SqlDataAdapter adapta = new SqlDataAdapter("Select * from EmployeeGradeView where EmployeeGradeView.Archived='False' and GradeCategory=@GradeCategory Order By EmployeeGradeView.Description,EmployeeGradeView.GradeCategory ASC", new SqlConnection(connectionString));
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
                cboAttendanceMode.Items.Clear();
                cboStatus.Items.Clear();
                cboInstitution.Items.Clear();
                cboQualification.Items.Clear();
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
                connectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

       

        private void cboInstitution_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboInstitution.Items.Clear();
                lstInstitutions = attendedSchoolAdapta.getData(true, false);
                foreach (AttendedSchool school in lstInstitutions)
                {
                    cboInstitution.Items.Add(school.Description);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
         
        }
        private QualificationDataMapper qualificationDataMapper;
        private IList<Qualification> lstQualifications;

        private void cboQualification_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboQualification.Items.Clear();
                qualificationDataMapper = new QualificationDataMapper();
                lstQualifications = qualificationDataMapper.GetAllASRaw();
                foreach (var qualification in lstQualifications)
                {
                    cboQualification.Items.Add(qualification.CertificateObtained);

                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }
        private TrainingAttendanceModeMapper AttendanceModeMapper;
        private IList<TrainingAttendanceMode> lstAttendanceMode;

        private void cboAttendanceMode_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAttendanceMode.Items.Clear();
                AttendanceModeMapper = new TrainingAttendanceModeMapper();
                lstAttendanceMode = AttendanceModeMapper.GetData();
                foreach (var mode in lstAttendanceMode)
                {
                    cboAttendanceMode.Items.Add(mode.Description);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

       
    }
}
