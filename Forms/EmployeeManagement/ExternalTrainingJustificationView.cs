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
using HRBussinessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using HRDataAccessLayer.Staff_Info_Data_Control;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ExternalTrainingJustificationView : Form
    {
        private IDAL dal;
        private IList<Department> departments;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Unit> units;
        private IList<TrainingOrganizer> lstTrainingOrganizers;
        private TrainingOrganizersDataMapper trainingOrganizerDataMapper;
        private IList<TrainingSponsor> lstTrainingSponsors;
        private TrainingSponsorDataMapper trainingSponsorDataMapper;
        private IList<Qualification> lstQualifications;
        private QualificationDataMapper qualificationMapper;
        private IList<GradeCategory> gradeCategories;
        private ExternalTrainingForm parentForm;
        private DALHelper dalHelper;
        private IList<ExternalTraining> lstExternalTrainings;
        private ExternalTrainingDataMapper externalTrainingMapper;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        /*public ExternalTrainingJustificationView()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.employeeGrades = new List<EmployeeGrade>();
            this.units = new List<Unit>();
            this.lstTrainingOrganizers = new List<TrainingOrganizer>();
            this.trainingOrganizerDataMapper = new TrainingOrganizersDataMapper();
            this.lstTrainingSponsors = new List<TrainingSponsor>();
            this.trainingSponsorDataMapper = new TrainingSponsorDataMapper();
            this.lstQualifications = new List<Qualification>();
            this.qualificationMapper = new QualificationDataMapper();
            this.gradeCategories = new List<GradeCategory>();
            this.parentForm = new ExternalTrainingForm();
            this.lstExternalTrainings = new List<ExternalTraining>();
        }*/
        public ExternalTrainingJustificationView()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.employeeGrades = new List<EmployeeGrade>();
            this.units = new List<Unit>();
            this.lstTrainingOrganizers = new List<TrainingOrganizer>();
            this.trainingOrganizerDataMapper = new TrainingOrganizersDataMapper();
            this.lstTrainingSponsors = new List<TrainingSponsor>();
            this.trainingSponsorDataMapper = new TrainingSponsorDataMapper();
            this.lstQualifications = new List<Qualification>();
            this.qualificationMapper = new QualificationDataMapper();
            this.gradeCategories = new List<GradeCategory>();

           // this.parentForm = parentForm;
            
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

        private void cboGradeCategory_TextChanged(object sender, EventArgs e)
        {

            cboGrade.Items.Clear();

        }

        private void cmbSchool_DropDown(object sender, EventArgs e)
        {

        }
        private void cmbOrganizers_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboOrganizers.Items.Clear();
                lstTrainingOrganizers = trainingOrganizerDataMapper.getAll(true);
                foreach (var item in lstTrainingOrganizers)
                {
                    cboOrganizers.Items.Add(item.Description);
                }
            }
            catch (Exception e1) { }

        }
        private void cmbSponsor_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbSponsor.Items.Clear();
                lstTrainingSponsors = trainingSponsorDataMapper.getAll(true);
                foreach (var item in lstTrainingSponsors)
                {
                    cmbSponsor.Items.Add(item.Description);
                }
            }
            catch (Exception e1) { }

        }
        private void cmbQualification_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstQualifications = qualificationMapper.GetAllASRaw();
                cmbQualification.Items.Clear();
                foreach (var Row in lstQualifications)
                {
                    cmbQualification.Items.Add(Row.CertificateObtained);
                }
            }
            catch (Exception e1) { }

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

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExternalTrainingView_Load(object sender, EventArgs e)
        {
            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnJustify.Enabled = getPermissions.CanAdd;
                //findbtn.Visible = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
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
                    sql += " DateEntered=@DateEntered and";
                    dalHelper.CreateParameter("@DateEntered", datePickerRequestDate.Value.Date, DbType.DateTime);
                }

                if (cboDepartment.Text != string.Empty)
                {
                    sql += " Department=@Department and";
                    dalHelper.CreateParameter("@Department", cboDepartment.Text, DbType.String);
                }
                if (cboUnit.Text != string.Empty)
                {
                    sql += " Unit=@Unit";
                    dalHelper.CreateParameter("@Unit", cboUnit.Text, DbType.String);
                }

                if (txtSurname.Text.Trim() != string.Empty)
                {
                    sql += " Surname=@Surname and";
                    dalHelper.CreateParameter("@Surname", txtSurname.Text.Trim(), DbType.String);
                }

                if (cmbSchool.Text != string.Empty)
                {
                    sql += " School=@School and";
                    dalHelper.CreateParameter("@School", cmbSchool.Text.Trim(), DbType.String);
                }

                if (cboOrganizers.Text != string.Empty)
                {
                    sql += " Organizer=@Organizer and";
                    dalHelper.CreateParameter("@Organizer", cboOrganizers.Text, DbType.String);
                }


                if (cmbQualification.Text != string.Empty)
                {
                    sql += " Qualification=@Qualification and";
                    dalHelper.CreateParameter("@Qualification", cmbQualification.Text, DbType.String);
                }

                sql += " Active=@Active and";
                    dalHelper.CreateParameter("@Active", Convert.ToBoolean(chkActive.Checked), DbType.Boolean);
                    sql += " isJustified=@isJustified and";
                    dalHelper.CreateParameter("@isJustified", false, DbType.Boolean);

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
                    sql = " where " + sql;

                sql = AppUtils.TrimEnd(sql, "and");
                sql = "select top 50 * from ViewExternalTrainings " + sql;
                dalHelper.CurrentCommand.CommandText = sql;
                externalTrainingMapper = new ExternalTrainingDataMapper();
                lstExternalTrainings = externalTrainingMapper.getExternalTrainings(dalHelper);
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

        private void PopulateGrid()
        {
            gridViewInfo.Rows.Clear();
            int ctr = 0;
            foreach (ExternalTraining item in lstExternalTrainings)
            {
                gridViewInfo.Rows.Add(1);
                gridViewInfo.Rows[ctr].Cells["gridID"].Value = item.ID;
                gridViewInfo.Rows[ctr].Cells["gridStaffID"].Value = item.Staff.StaffID;
                gridViewInfo.Rows[ctr].Cells["gridName"].Value = String.Concat(item.Staff.FirstName + " " + item.Staff.OtherName).Trim() + " " + item.Staff.Surname;
                gridViewInfo.Rows[ctr].Cells["gridDepartment"].Value = item.Staff.Department.Description;
                gridViewInfo.Rows[ctr].Cells["gridUnit"].Value = item.Staff.Unit.Description;
                gridViewInfo.Rows[ctr].Cells["gridGradeCategory"].Value = item.Staff.GradeCategory.Description;
                gridViewInfo.Rows[ctr].Cells["gridCourse"].Value = item.AspiredQualification.CertificateObtained;
                gridViewInfo.Rows[ctr].Cells["gridSchool"].Value =item.School!=null? item.School.Description:string.Empty;
                gridViewInfo.Rows[ctr].Cells["gridVenue"].Value = item.Venue;
                gridViewInfo.Rows[ctr].Cells["gridHODName"].Value =item.HOD!=null? (item.HOD.FirstName + " " + item.HOD.OtherName).Trim() + " " + item.HOD.Surname:string.Empty;
                gridViewInfo.Rows[ctr].Cells["gridHODJustificationDate"].Value = item.JustificationDate.ToShortDateString();
                gridViewInfo.Rows[ctr].Cells["gridHODJustification"].Value = item.Justification;


                gridViewInfo.Rows[ctr].Cells["gridEntryDate"].Value = item.EnteredDate.ToShortDateString();
                gridViewInfo.Rows[ctr].Cells["gridStartDate"].Value = item.StartDate.ToShortDateString();
                gridViewInfo.Rows[ctr].Cells["gridEndDate"].Value = item.EndDate.ToShortDateString();
               

                if (item.EntryBy != null)
                    gridViewInfo.Rows[ctr].Cells["gridEntryBy"].Value = item.EntryBy.NAME;
                ctr++;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewInfo.CurrentRow != null)
                {
                    var externalTraining = externalTrainingMapper.getById(Convert.ToInt32(gridViewInfo.CurrentRow.Cells["gridID"].Value));
                    /*dalHelper = new DALHelper();
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@Id", externalTraining.ID, DbType.Int32);
                    dalHelper.ExecuteNonQuery("delete ExternalTraining  where id=@Id");
                    gridViewInfo.Rows.Remove(gridViewInfo.CurrentRow);
                    MessageBox.Show("Record Deleted Successfully!");*/
                    ExternalTrainingJustification justificationForm = new ExternalTrainingJustification(externalTraining,this);
                    justificationForm.ShowDialog(this);
                }
                else
                    MessageBox.Show("Sorry You Must Select A Row");
            }
            catch (Exception e1) { }
           
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            gridViewInfo.ClearSelection();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            gridViewInfo.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void gridViewInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var externalTraining = externalTrainingMapper.getById(Convert.ToInt32(gridViewInfo.CurrentRow.Cells["gridID"].Value));
            parentForm.FillEntries(externalTraining);
        }
    }
}
