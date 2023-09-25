using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.Reports
{
    public partial class InternshipReportSelect : Form
    {
        private IList<Internship> internships;
        private IList<Internship> internshipList;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Zone> zones;
        private IList<InternshipType> internshipTypes;
        private IDAL dal;
        private Form reportForm;
        private Company company;
        private int ctr;
        private bool mechanised;

        public InternshipReportSelect()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.internships = new List<Internship>();
                this.internshipList = new List<Internship>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.zones = new List<Zone>();
                this.internshipTypes = new List<InternshipType>();
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

        private void InternshipReportSelect_Load(object sender, EventArgs e)
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
                Clear();
                if (cmbOption.Text == "All Employees")
                {
                    staffNoLabel.Visible = false;
                    nameLabel.Visible = false;
                    txtStaffName.Visible = false;
                    txtIDNumber.Visible = false;
                    searchGrid.Visible = false;
                    lblDepartment.Visible = true;
                    cboDepartment.Visible = true;
                    lblUnit.Visible = true;
                    cboUnit.Visible = true;
                    lblIDNumber.Visible = true;
                    txtStaffNo.Visible = true;
                    lblZone.Visible = true;
                    cboZone.Visible = true;
                    lblInternshipType.Visible = true;
                    cboInternshipType.Visible = true;

                }
                else
                {
                    staffNoLabel.Visible = true;
                    nameLabel.Visible = true;
                    txtStaffName.Visible = true;
                    txtIDNumber.Visible = true;
                    searchGrid.Visible = false;
                    lblDepartment.Visible = false;
                    cboDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboUnit.Visible = false;
                    lblZone.Visible = false;
                    cboZone.Visible = false;
                    lblIDNumber.Visible = false;
                    txtStaffNo.Visible = false;
                    lblInternshipType.Visible = false;
                    cboInternshipType.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }

                reportForm = new InternshipReportForm(txtIDNumber.Text.Trim(), cboInternshipType.Text.Trim(), datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboZone.Text.Trim(),txtStaffNo.Text.Trim());
                reportForm.Show();
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
                if (txtIDNumber.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    ctr = 0;
                    bool found = false;
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.IDNumber",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtIDNumber.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                    internships = dal.GetByCriteria<Internship>(query);
                    if (internships.Count > 0)
                    {
                        foreach (Internship internship in internships)
                        {
                            string name = (internship.OtherName == string.Empty ? string.Empty : " " + internship.OtherName) + " " + internship.Surname;
                            if (internship.IDNumber.Trim().ToLower().StartsWith(txtIDNumber.Text.Trim().ToLower()))
                            {
                                found = true;
                                searchGrid.Rows.Add(1);
                                searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                searchGrid.Rows[ctr].Cells["gridIDNumber"].Value = internship.IDNumber;
                                searchGrid.Rows[ctr].Cells["gridID"].Value = internship.ID;
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
                            searchGrid.Location = new Point(txtIDNumber.Location.X, txtIDNumber.Location.Y + 21);
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
                        MessageBox.Show("Intern with ID Number " + txtIDNumber.Text.Trim() + " is not Found");
                        txtIDNumber.Text = string.Empty;
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
                    internships = dal.GetAll<Internship>();
                    foreach (Internship internship in internships)
                    {
                        string name = (internship.OtherName == string.Empty ? string.Empty : " " + internship.OtherName) + " " + internship.Surname;
                        if (name.Trim().ToLower().StartsWith(txtStaffName.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridIDNumber"].Value = internship.IDNumber;
                            searchGrid.Rows[ctr].Cells["gridID"].Value = internship.ID;
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
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    txtIDNumber.Text = searchGrid.CurrentRow.Cells["gridIDNumber"].Value.ToString();
                    txtStaffName.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                txtStaffNo.Clear();
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                cboZone.Items.Clear();
                cboInternshipType.Items.Clear();
                datePickerFrom.ResetText();
                datePickerTo.ResetText();
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
                txtIDNumber.Clear();
                txtStaffName.Clear();
                searchGrid.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void cboInternshipType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboInternshipType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "InternshipTypeView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                internshipTypes = dal.GetByCriteria<InternshipType>(query);
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
    }
}
