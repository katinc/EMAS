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
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class TrainingBondView : Form
    {
        private DALHelper dalHelper;

        private TrainingBond trainingBond;
        private List<TrainingBond> lstTrainingBond;
        private TrainingBondDataMapper trainingBondMapper;

        private UserInfoDataMapper userInfo;
        private TrainingBondForm parentForm;
        private IDAL dal;
        private IList<Department> departments;
        private IList<EmployeeGrade> employeeGrades;
        private IList<GradeCategory> gradeCategories;
        private IList<Unit> units;
        private QualificationDataMapper qualificationsMapper;
        private IList<Qualification> lstQualifications;

        private IList<TrainingAttendanceMode> lstAttendanceModes;
        private TrainingAttendanceModeMapper trainingAttendanceDataMapper;

        public TrainingBondView()
        {
            InitializeComponent();
            trainingBond = new TrainingBond();
            this.lstTrainingBond = new List<TrainingBond>();
            this.trainingBondMapper = new TrainingBondDataMapper();
            this.userInfo = new UserInfoDataMapper();
            this.dalHelper = new DALHelper();
            this.dal = new DAL();
            this.gradeCategories = new List<GradeCategory>();
            this.units = new List<Unit>();
            this.qualificationsMapper = new QualificationDataMapper();
            this.lstQualifications = new List<Qualification>();
            this.lstAttendanceModes = new List<TrainingAttendanceMode>();
            this.trainingAttendanceDataMapper = new TrainingAttendanceModeMapper();
            this.departments = new List<Department>();
        }
        public TrainingBondView(TrainingBondForm parentForm)
        {
            InitializeComponent();
            trainingBond = new TrainingBond();
            this.lstTrainingBond = new List<TrainingBond>();
            this.trainingBondMapper = new TrainingBondDataMapper();
            this.userInfo = new UserInfoDataMapper();
            this.dalHelper = new DALHelper();
            this.parentForm = new TrainingBondForm();


            this.dal = new DAL();
            this.gradeCategories = new List<GradeCategory>();
            this.units = new List<Unit>();
            this.qualificationsMapper = new QualificationDataMapper();
            this.lstQualifications = new List<Qualification>();
            this.lstAttendanceModes = new List<TrainingAttendanceMode>();
            this.trainingAttendanceDataMapper = new TrainingAttendanceModeMapper();
            this.departments = new List<Department>();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Getting the data
        private void GetData()
        {
            gridViewInfo.Rows.Clear();
            dalHelper = new DALHelper();
            dalHelper.ClearParameters();
            var sql = "";
            try
            {
                if (datePickerEntryDate.Checked == true)
                {
                    sql += " entrydate=@entrydate and";
                    dalHelper.CreateParameter("@entrydate", datePickerEntryDate.Value.Date, DbType.DateTime);
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

                if (cmbAttendanceMode.Text != string.Empty)
                {
                    sql += " requestType=@requestType and";
                    dalHelper.CreateParameter("@requestType", cmbAttendanceMode.Text.Trim(), DbType.String);
                }

                if (cboQualification.Text != string.Empty)
                {
                    sql += " qualification=@qualification and";
                    dalHelper.CreateParameter("@qualification", cboQualification.Text, DbType.String);
                }
               
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
                    sql += " courseStartDate>=@StartDate and";
                    dalHelper.CreateParameter("@StartDate", datePickerStartDate.Value.Date, DbType.DateTime);
                }

                if (datePickerEndDate.Checked == true)
                {
                    sql += " courseEndDate<=@EndDate";
                    dalHelper.CreateParameter("@EndDate", datePickerEndDate.Value.Date, DbType.DateTime);
                }

                if (sql.Trim() != string.Empty)
                    sql = " where " + sql;

                sql = AppUtils.TrimEnd(sql, "and");
                sql = "select * from ViewTrainingBond " + sql;
                dalHelper.CurrentCommand.CommandText = sql;
               
                lstTrainingBond = trainingBondMapper.getData(dalHelper);
                gridViewInfo.Rows.Clear();
                PopulateGrid();
                gridViewInfo.ClearSelection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                // throw ex;
            }
        }
        //Populate Grid
        private void PopulateGrid()
        {
            try
            {

                int ctr = 0;

                foreach (var item in lstTrainingBond)
                {
                    userInfo = new UserInfoDataMapper();

                    gridViewInfo.Rows.Add(1);
                    gridViewInfo.Rows[ctr].Cells["gridID"].Value = item.Id;
                    gridViewInfo.Rows[ctr].Cells["gridStaffID"].Value = item.Staff.StaffID;
                    gridViewInfo.Rows[ctr].Cells["gridName"].Value = String.Concat(item.Staff.FirstName + " " + item.Staff.OtherName).Trim() + " " + item.Staff.Surname;
                    gridViewInfo.Rows[ctr].Cells["gridDepartment"].Value = item.Staff.Department.Description;
                    gridViewInfo.Rows[ctr].Cells["gridUnit"].Value = item.Staff.Unit.Description;
                    gridViewInfo.Rows[ctr].Cells["gridGradeCategory"].Value = item.Staff.GradeCategory.Description;
                    gridViewInfo.Rows[ctr].Cells["gridCourse"].Value = (item.AspiredQualification!=null)?item.AspiredQualification.CertificateObtained:string.Empty;
                    gridViewInfo.Rows[ctr].Cells["gridAttendanceMode"].Value =(item.CourseAttendanceMode!=null)? item.CourseAttendanceMode.Description:string.Empty;
                    gridViewInfo.Rows[ctr].Cells["gridForAdditionalQualification"].Value = item.ForAdditionalQualification;
                    gridViewInfo.Rows[ctr].Cells["gridTrainingCat"].Value = item.SponsoredProgrammeCategory.Description;

                    gridViewInfo.Rows[ctr].Cells["gridEntryDate"].Value = item.EntryDate.ToShortDateString();
                    gridViewInfo.Rows[ctr].Cells["gridStartDate"].Value = item.CourseStartDate.ToShortDateString();
                    gridViewInfo.Rows[ctr].Cells["gridEndDate"].Value = item.CourseEndDate.ToShortDateString();
                    gridViewInfo.Rows[ctr].Cells["gridWitnessName"].Value = item.WitnessedBy;
                    gridViewInfo.Rows[ctr].Cells["gridWitnessDate"].Value = item.WitnessDate.ToShortDateString();

                    if(item.EntryBy!=null)
                    gridViewInfo.Rows[ctr].Cells["gridEntryBy"].Value = item.EntryBy.NAME;
                    ctr++;
                }
            }
            catch (Exception exii)
            {
                Logger.LogError(exii);
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            gridViewInfo.ClearSelection();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            gridViewInfo.SelectAll();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (gridViewInfo.SelectedRows.Count > 0){
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Id", Convert.ToInt32(gridViewInfo.SelectedRows[0].Cells["gridID"].Value), DbType.Int32);
                dalHelper.ExecuteNonQuery("delete TrainingBonds where id=@Id");
                gridViewInfo.Rows.Remove(gridViewInfo.SelectedRows[0]);
               
                MessageBox.Show("Record Deleted Successfully!");
            }
            else
                MessageBox.Show("You Have To Select A Record");
        }
        //TrainingBond trainingBond = new TrainingBond();
        private void btnOpenMedicalSheet_Click(object sender, EventArgs e)
        {
            if (gridViewInfo.SelectedRows.Count > 0)
            {
                 trainingBond = trainingBondMapper.getById(Convert.ToInt32(gridViewInfo.SelectedRows[0].Cells["gridID"].Value));
                AppUtils.downloadFile(trainingBond.WitnessStamp, txtFirstName.Text.Trim() + ".jpg");
            }
            else
                MessageBox.Show("You Have To Select A Record");
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {

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

        private void cmbQualifications_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstQualifications = qualificationsMapper.GetAllASRaw();

                cboQualification.Items.Clear();
                foreach (Qualification qualification in lstQualifications)
                {
                    cboQualification.Items.Add(qualification.CertificateObtained);
                }
            }
            catch (Exception e1) { }

        }

        private void cmbAttendanceMode_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstAttendanceModes = trainingAttendanceDataMapper.GetData();

                cmbAttendanceMode.Items.Clear();
                foreach (TrainingAttendanceMode attendanceMode in lstAttendanceModes)
                {
                    cmbAttendanceMode.Items.Add(attendanceMode.Description);
                }
            }
            catch (Exception e1) { }
        }

        private void cboGradeCategory_TextChanged(object sender, EventArgs e)
        {

            cboGrade.Items.Clear();

        }

       

      
    }
}
