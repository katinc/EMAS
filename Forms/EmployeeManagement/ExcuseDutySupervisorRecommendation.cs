using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using Microsoft.VisualBasic;

namespace eMAS.Forms
{
    public partial class ExcuseDutyRecommendation : Form
    {
        
        private ExcuseDutyRequest excuseDutyRequest;
        ExcuseDutyRecommendationRemarks excuseDutyRecommendRemakForm;
        private DALHelper dalHelper;
       
        private ExcuseDutyRequestDataMapper excuseDutyMapper;
        public List<ExcuseDutyRequest> lstExcuseDutyRequest;
        private IDAL dal;
        private UserInfoDataMapper userInfo;

        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;

        private IList<ExcuseDutyRequestType> lstexcuseDutyRequests;
        private ExcuseDutyRequestTypeDataMapper excuseDutyRequestTypeMapper;

        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public ExcuseDutyRecommendation()
        {
            InitializeComponent();
            excuseDutyMapper = new ExcuseDutyRequestDataMapper();
            //excuseDutyRequest = new ExcuseDutyRequest();
            this.dalHelper = new DALHelper();
           
            this.dal = new DAL();
            this.excuseDutyMapper = new ExcuseDutyRequestDataMapper();
            this.lstExcuseDutyRequest = new List<ExcuseDutyRequest>();
            this.departments = new List<Department>();
            this.units = new List<Unit>();
            this.gradeCategories = new List<GradeCategory>();
            this.employeeGrades = new List<EmployeeGrade>();
            this.lstexcuseDutyRequests = new List<ExcuseDutyRequestType>();
            this.excuseDutyRequestTypeMapper = new ExcuseDutyRequestTypeDataMapper();
        }

        private void btnRecommend_Click(object sender, EventArgs e)
        {
         
                if (grid.SelectedRows.Count == 0)
                    MessageBox.Show("Sorry You Must Select A Record!");
                else if(grid.SelectedRows.Count>0)
                {
                    excuseDutyRequest = excuseDutyMapper.getById(Convert.ToInt32(grid.SelectedRows[0].Cells["gridID"].Value));
                    excuseDutyRecommendRemakForm = new ExcuseDutyRecommendationRemarks();
                    excuseDutyRecommendRemakForm.setExcuseDutyRequest(excuseDutyRequest,this);
                    excuseDutyRecommendRemakForm.ShowDialog(this);
                    GetData();
                }
           
        }
        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
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
        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {

            try
            {
                Query query = new Query();
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        void cboGradeCategory_DropDown(object sender, EventArgs e)
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }
        //Getting the data
        private void GetData()
        {
            dalHelper = new DALHelper();
            dalHelper.ClearParameters();
            var sql = "";
            try
            {
                if (datePickerRequestDate.Checked == true)
                {
                    sql += " RequestDate=@RequestDate and";
                    dalHelper.CreateParameter("@RequestDate", datePickerRequestDate.Value.Date, DbType.DateTime);
                }

                if (cboDepartment.Text != string.Empty)
                {
                    sql += " Department=@Department and";
                    dalHelper.CreateParameter("@Department", cboDepartment.Text, DbType.String);
                }
                if (cboUnit.Text != string.Empty)
                {
                    sql += " Unit=@Unit and";
                    dalHelper.CreateParameter("@Unit", cboUnit.Text, DbType.String);
                }

                if (txtSurname.Text.Trim() != string.Empty)
                {
                    sql += " Surname=@Surname and";
                    dalHelper.CreateParameter("@Surname", txtSurname.Text.Trim(), DbType.String);
                }
                sql += " Returned=@Returned and";
                dalHelper.CreateParameter("@Returned", false, DbType.Boolean);
                if (cboRequestType.Text != string.Empty)
                {
                    sql += " requestType=@requestType and";
                    dalHelper.CreateParameter("@requestType", cboRequestType.Text.Trim(), DbType.String);
                }

                if (cboRecommended.Text != string.Empty)
                {
                    sql += " HRRecommended=@HRRecommended and";
                    dalHelper.CreateParameter("@HRRecommended", cboRecommended.Text, DbType.Boolean);
                }
               /* if (cboApproved.Text != string.Empty)
                {*/
                sql += " Approved=@Approved and Recommended='false' and";
                    dalHelper.CreateParameter("@Approved", false, DbType.Boolean);
                /*}*/

                if (cboGradeCategory.Text != string.Empty)
                {
                    sql += " GradeCategory=@GradeCategory and";
                    dalHelper.CreateParameter("@GradeCategory", cboGradeCategory.Text, DbType.String);
                }

                if (cboGrade.Text != string.Empty)
                {
                    sql += " Grade=@Grade and";
                    dalHelper.CreateParameter("@Grade", cboGrade.Text, DbType.String);
                }

                if (txtFirstName.Text != string.Empty)
                {
                    sql += " FirstName=@FirstName and";
                    dalHelper.CreateParameter("@FirstName", txtFirstName.Text, DbType.String);
                }

                if (txtStaffID.Text != string.Empty)
                {
                    sql += " StaffCode=@StaffCode and";
                    dalHelper.CreateParameter("@StaffCode", txtStaffID.Text, DbType.String);
                }

                if (datePickerStartDate.Checked == true)
                {
                    sql += " StartDate>=@StartDate and";
                    dalHelper.CreateParameter("@StartDate", datePickerStartDate.Value.Date, DbType.DateTime);
                }

                if (datePickerEndDate.Checked == true)
                {
                    sql += " EndDate<=@EndDate";
                    dalHelper.CreateParameter("@EndDate", datePickerEndDate.Value.Date, DbType.DateTime);
                }

                if (sql.Trim() != string.Empty)
                    sql = " where " + sql.Trim();
                sql = AppUtils.TrimEnd(sql, " and");
                sql = "select top 50 * from ViewExcuseDutyRequests " + sql;
                dalHelper.CurrentCommand.CommandText = sql;
                lstExcuseDutyRequest = excuseDutyMapper.getAll(dalHelper);
                grid.Rows.Clear();
                PopulateGrid();
                grid.ClearSelection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                // throw ex;
            }
        }

        private void cboUnit_DropDown(object sender, EventArgs e)
        {
            if (cboDepartment.Text == string.Empty)
            {
                cboUnit.Items.Clear();
                return;
            }

            try
            {
                Query query = new Query();

                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
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
        //Populate Grid
        private void PopulateGrid()
        {
            UserInfo recommendedApprovedEmp = null;
            try
            {

                int ctr = 0;

                foreach (var item in lstExcuseDutyRequest)
                {
                    userInfo = new UserInfoDataMapper();

                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = item.id;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = item.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridName"].Value = String.Concat(item.Employee.FirstName + " " + item.Employee.OtherName).Trim() + " " + item.Employee.Surname;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = item.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = item.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = item.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridLeaveStatus"].Value = item.LeaveStatus;
                    grid.Rows[ctr].Cells["gridRequestType"].Value = item.requestType.description;
                    grid.Rows[ctr].Cells["gridMedicalSheet"].Value = item.ExcuseDutyFileName;
                    grid.Rows[ctr].Cells["gridRequestDate"].Value = item.RequestDate.ToString("dd/MM/yyyy");
                    grid.Rows[ctr].Cells["gridStartDate"].Value = item.StartDate.ToString("dd/MM/yyyy");
                    grid.Rows[ctr].Cells["gridEndDate"].Value = item.EndDate.ToString("dd/MM/yyyy");
                    grid.Rows[ctr].Cells["gridRecommended"].Value = item.Recommended;


                    grid.Rows[ctr].Cells["gridResumed"].Value = item.Returned;
                    grid.Rows[ctr].Cells["gridResumptionReason"].Value = item.ResumptionReason;
                    //grid.Rows[ctr].Cells["gridResumptionDate"].Value = item.Returned == true? item.ResumptionDate : string.Empty;
                    grid.Rows[ctr].Cells["gridResumptionDate"].Value = item.ResumptionDate;

                    recommendedApprovedEmp = userInfo.GetById(item.RecommendedById);

                    if (recommendedApprovedEmp != null)
                        grid.Rows[ctr].Cells["gridRecommendedBy"].Value = recommendedApprovedEmp.NAME;

                    if (recommendedApprovedEmp.NAME != string.Empty)
                        grid.Rows[ctr].Cells["gridRecommendationDate"].Value = item.RecommendationDate;
                    //grid.Rows[ctr].Cells["gridRecommendationDate"].Value = Information.IsDate(item.RecommendationDate) ? item.RecommendationDate.Value : string.Empty;

                    grid.Rows[ctr].Cells["gridApproved"].Value = item.Approved;

                    recommendedApprovedEmp = userInfo.GetById(item.ApprovedById);

                    if (recommendedApprovedEmp.NAME != string.Empty)
                    {
                        grid.Rows[ctr].Cells["gridApprovedBy"].Value = recommendedApprovedEmp.NAME;

                        grid.Rows[ctr].Cells["gridApprovedOn"].Value = item.ApprovedDate;
                        //grid.Rows[ctr].Cells["gridApprovedOn"].Value = Information.IsDate(item.ApprovedDate) ? item.ApprovedDate.ToString("dd/MM/yyyy") : null;
                    }
                    ctr++;
                }
            }
            catch (Exception exii)
            {
                Logger.LogError(exii);
            }

        }
        private void cboRequestType_DropDown(object sender, EventArgs e)
        {
            cboRequestType.Items.Clear();
            lstexcuseDutyRequests = excuseDutyRequestTypeMapper.getAll(0);
            foreach (ExcuseDutyRequestType requestType in lstexcuseDutyRequests)
            {
                cboRequestType.Items.Add(requestType.description);
            }
        }
        private void cboGradeCategory_TextChanged(object sender, EventArgs e)
        {

            cboGrade.Items.Clear();

        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            grid.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExcuseDutyRecommendation_Load(object sender, EventArgs e)
        {
            cboApproved.Text="False";
            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnRecommend.Enabled = getPermissions.CanAdd;
                btnPreviewMedicalSheet.Enabled = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }

        private void btnPreviewMedicalSheet_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
                MessageBox.Show("Sorry You Have Not Selected Any Record!");
            else
            {
               excuseDutyRequest=excuseDutyMapper.getById(Convert.ToInt32(grid.SelectedRows[0].Cells["gridID"].Value));
               if (excuseDutyRequest.ExcuseDutySheet != null && excuseDutyRequest.ExcuseDutyFileName != null)
               {
                   AppUtils.downloadFile(excuseDutyRequest.ExcuseDutySheet, excuseDutyRequest.ExcuseDutyFileName);
               }
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

    }
}
