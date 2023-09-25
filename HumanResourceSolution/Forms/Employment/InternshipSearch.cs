using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using eMAS.All_UIs.Applicants;
using eMAS.All_UIs.Staff_Information_FORMS;
using eMAS.Forms.Employment;

namespace eMAS.Forms.Employment
{
    public partial class InternshipSearch : Form
    {
        private IDAL dal;
        private DALHelper dalHelper;
        private InternshipNewForm internshipNewForm;
        private Internship internship;
        private IList<Internship> internships;
        private IList<Internship> foundInternships;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<InternshipType> internshipTypes;
        private int ctr;
        private bool found;

        public InternshipSearch(IDAL dal,InternshipNewForm internshipNewForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.ctr = 0;
                this.dalHelper = new DALHelper();
                this.internshipNewForm = internshipNewForm;
                this.internship = new Internship();
                this.internships = new List<Internship>();
                this.foundInternships=new List<Internship>();
                this.departments=new List<Department>();
                this.units = new List<Unit>();
                this.internshipTypes=new List<InternshipType>();
                this.found = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    Internship internship = new Internship();
                    internship.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    internship.IDNumber = grid.CurrentRow.Cells["gridIDNumber"].Value.ToString();
                    internship.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    internship.MobileNo = grid.CurrentRow.Cells["gridMobileNumber"].Value.ToString();
                    internship.Address = grid.CurrentRow.Cells["gridAddress"].Value.ToString();
                    internship.AreaOfStudy = grid.CurrentRow.Cells["gridAreaOfStudy"].Value.ToString();
                    internship.Institution = grid.CurrentRow.Cells["gridInstitution"].Value.ToString();
                    internship.InternshipType.Description = grid.CurrentRow.Cells["gridInternshipType"].Value.ToString();
                    internship.InternshipType.ID = int.Parse(grid.CurrentRow.Cells["gridInternshipTypeID"].Value.ToString());
                    internship.MaritalStatus = (MaritalStatusGroups)Enum.Parse(typeof(MaritalStatusGroups), grid.CurrentRow.Cells["gridMaritalStatus"].Value.ToString());
                    internship.OtherName = grid.CurrentRow.Cells["gridOtherName"].Value.ToString();
                    internship.ReportingDate = DateTime.Parse(grid.CurrentRow.Cells["gridReportingDate"].Value.ToString());
                    internship.StartDate = DateTime.Parse(grid.CurrentRow.Cells["gridStartDate"].Value.ToString());
                    internship.Surname = grid.CurrentRow.Cells["gridSurname"].Value.ToString();
                    internship.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    internship.Age = grid.CurrentRow.Cells["gridAge"].Value.ToString();
                    internship.Archived = bool.Parse(grid.CurrentRow.Cells["gridArchived"].Value.ToString());
                    internship.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                    internship.Department.ID = int.Parse(grid.CurrentRow.Cells["gridDepartmentID"].Value.ToString());
                    internship.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                    internship.Unit.ID = int.Parse(grid.CurrentRow.Cells["gridUnitID"].Value.ToString());
                    internship.Zone.Description = grid.CurrentRow.Cells["gridZone"].Value.ToString();
                    internship.SupervisorCode = int.Parse(grid.CurrentRow.Cells["gridSupervisorCode"].Value.ToString());
                    internship.SupervisorStaffID = grid.CurrentRow.Cells["gridSupervisorStaffID"].Value.ToString();
                    internship.SupervisorName = grid.CurrentRow.Cells["gridSupervisorName"].Value.ToString();
                    internship.Overseer = grid.CurrentRow.Cells["gridOverseer"].Value.ToString();
                    internship.YearStudied = decimal.Parse(grid.CurrentRow.Cells["gridYearStudied"].Value.ToString());
                    internship.Zone.ID = int.Parse(grid.CurrentRow.Cells["gridZoneID"].Value.ToString());
                    internship.DOB = DateTime.Parse(grid.CurrentRow.Cells["gridDOB"].Value.ToString());
                    internship.EndDate = DateTime.Parse(grid.CurrentRow.Cells["gridEndDate"].Value.ToString());
                    internship.Gender = (GenderGroups)Enum.Parse(typeof(GenderGroups), grid.CurrentRow.Cells["gridGender"].Value.ToString());

                    internshipNewForm.EditInternship(internship);
                    internshipNewForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void InternshipSearch_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
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

        private void PopulateView(IList<Internship> internships)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Internship internship in internships)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = internship.ID;
                    grid.Rows[ctr].Cells["gridIDNumber"].Value = internship.IDNumber;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = internship.StaffID;
                    grid.Rows[ctr].Cells["gridMobileNumber"].Value = internship.MobileNo;
                    grid.Rows[ctr].Cells["gridAddress"].Value = internship.Address;
                    grid.Rows[ctr].Cells["gridAreaOfStudy"].Value = internship.AreaOfStudy;
                    grid.Rows[ctr].Cells["gridInstitution"].Value = internship.Institution;
                    grid.Rows[ctr].Cells["gridInternshipTypeID"].Value = internship.InternshipType.ID;
                    grid.Rows[ctr].Cells["gridInternshipType"].Value = internship.InternshipType.Description;
                    grid.Rows[ctr].Cells["gridMaritalStatus"].Value = internship.MaritalStatus;
                    grid.Rows[ctr].Cells["gridOtherName"].Value = internship.OtherName;
                    grid.Rows[ctr].Cells["gridReportingDate"].Value = internship.ReportingDate;
                    grid.Rows[ctr].Cells["gridStartDate"].Value = internship.StartDate;
                    grid.Rows[ctr].Cells["gridSurname"].Value = internship.Surname;
                    grid.Rows[ctr].Cells["gridUserID"].Value = internship.User.ID;
                    grid.Rows[ctr].Cells["gridAge"].Value = internship.Age;
                    grid.Rows[ctr].Cells["gridArchived"].Value = internship.Archived;
                    grid.Rows[ctr].Cells["gridDepartmentID"].Value = internship.Department.ID;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = internship.Department.Description;
                    grid.Rows[ctr].Cells["gridUnitID"].Value = internship.Unit.ID;
                    grid.Rows[ctr].Cells["gridUnit"].Value = internship.Unit.Description;
                    grid.Rows[ctr].Cells["gridZoneID"].Value = internship.Zone.ID;
                    grid.Rows[ctr].Cells["gridZone"].Value = internship.Zone.Description;
                    grid.Rows[ctr].Cells["gridDOB"].Value = internship.DOB;
                    grid.Rows[ctr].Cells["gridEndDate"].Value = internship.EndDate;
                    grid.Rows[ctr].Cells["gridGender"].Value = internship.Gender;
                    grid.Rows[ctr].Cells["gridSupervisorCode"].Value = internship.SupervisorCode;
                    grid.Rows[ctr].Cells["gridSupervisorStaffID"].Value = internship.SupervisorStaffID;
                    grid.Rows[ctr].Cells["gridSupervisorName"].Value = internship.SupervisorName;
                    grid.Rows[ctr].Cells["gridOverseer"].Value = internship.Overseer;
                    grid.Rows[ctr].Cells["gridYearStudied"].Value = internship.YearStudied;
                    grid.Rows[ctr].Cells["gridUserID"].Value = internship.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetData()
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
                        Property = "ApplicantView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboInternshipType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.InternshipType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = internshipTypes[cboInternshipType.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboMaritalStatus.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.MaritalStatus",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = Enum.GetValues(typeof(MaritalStatusGroups)),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGender.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.Gender",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = Enum.GetValues(typeof(GenderGroups)),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateStartDate.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.StartDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateStartDate.Value.Date,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEndDate.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.EndDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEndDate.Value.Date,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateReportingDate.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.ReportingDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateReportingDate.Value.Date,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtOtherName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.OtherName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtOtherName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtIDNumber.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.IDNumber",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtIDNumber.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtStaffID.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.StaffID",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtStaffID.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtInstitutionAttended.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.Institution",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtInstitutionAttended.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtAreaOfStudy.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.AreaOfStudy",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtAreaOfStudy.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtMobileNumber.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.MobileNo",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtMobileNumber.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                internships = dal.GetByCriteria<Internship>(query);
                PopulateView(internships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
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
                internship = new Internship();
                cboInternshipType.Items.Clear();
                cboInternshipType.Text = string.Empty;
                txtIDNumber.Clear();
                txtSurname.Clear();
                txtOtherName.Clear();
                txtStaffID.Clear();
                txtAreaOfStudy.Clear();
                txtInstitutionAttended.Clear();
                cboGender.Items.Clear();
                cboGender.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                dateStartDate.ResetText();
                dateEndDate.ResetText();
                dateReportingDate.ResetText();
                cboMaritalStatus.Items.Clear();
                cboMaritalStatus.Text = string.Empty;
                label13.Text = "Edit Internship / Attachment";
                txtMobileNumber.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void txtIDNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if ((internship.IDNumber.Trim().ToLower().StartsWith(txtIDNumber.Text.Trim().ToLower())))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if ((internship.Surname.Trim().ToLower().StartsWith(txtSurname.Text.Trim().ToLower())))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtOtherName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if ((internship.OtherName.Trim().ToLower().StartsWith(txtOtherName.Text.Trim().ToLower())))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if ((internship.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower())))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dateStartDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.StartDate.Value.Date == dateStartDate.Value.Date)
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dateEndDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.EndDate.Value.Date == dateEndDate.Value.Date)
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dateReportingDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.ReportingDate.Value.Date == dateReportingDate.Value.Date)
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtInstitutionAttended_TextChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if ((internship.Institution.Trim().ToLower().StartsWith(txtInstitutionAttended.Text.Trim().ToLower())))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtAreaOfStudy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if ((internship.AreaOfStudy.Trim().ToLower().StartsWith(txtAreaOfStudy.Text.Trim().ToLower())))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboInternshipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.InternshipType.ID == internshipTypes[cboInternshipType.SelectedIndex].ID)
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboInternshipType_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.InternshipType.ID == internshipTypes[cboInternshipType.SelectedIndex].ID)
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.Department.ID == departments[cboDepartment.SelectedIndex].ID)
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.Unit.ID == units[cboUnit.SelectedIndex].ID)
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.Gender == (GenderGroups)Enum.Parse(typeof(GenderGroups), cboGender.Text))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGender_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.Gender == (GenderGroups)Enum.Parse(typeof(GenderGroups), cboGender.Text))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.MaritalStatus == (MaritalStatusGroups)Enum.Parse(typeof(MaritalStatusGroups), cboMaritalStatus.Text.Trim()))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboMaritalStatus_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.MaritalStatus == (MaritalStatusGroups)Enum.Parse(typeof(MaritalStatusGroups), cboMaritalStatus.Text.Trim()))
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGender_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGender.Items.Clear();
                foreach (GenderGroups item in Enum.GetValues(typeof(GenderGroups)))
                {
                    if (item != GenderGroups.All && item != GenderGroups.None)
                    {
                        cboGender.Items.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMaritalStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboMaritalStatus.Items.Clear();
                foreach (MaritalStatusGroups item in Enum.GetValues(typeof(MaritalStatusGroups)))
                {
                    if (item != MaritalStatusGroups.None)
                    {
                        cboMaritalStatus.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboInternshipType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboInternshipType.Items.Clear();
                internshipTypes = dal.GetAll<InternshipType>();
                foreach (InternshipType internshipType in internshipTypes)
                {
                    cboInternshipType.Items.Add(internshipType.Description);
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

        private void cboDepartment_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                internships = dal.GetAll<Internship>();
                foundInternships.Clear();
                foreach (Internship internship in internships)
                {
                    if (internship.Department.ID == departments[cboDepartment.SelectedIndex].ID)
                    {
                        foundInternships.Add(internship);
                    }
                }
                PopulateView(foundInternships);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are you sure you want to delete the Staff " + grid.CurrentRow.Cells["gridSurname"].Value.ToString() + grid.CurrentRow.Cells["gridOtherName"].Value.ToString() + "?") == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                internship.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                internship.Archived = true;
                                dal.Delete(internship);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                internship.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                internship.Archived = true;
                                dal.Delete(internship);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
