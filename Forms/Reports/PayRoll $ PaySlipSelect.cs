using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRDataAccessLayer;
using eMAS.Forms.Reports;
using HRDataAccessLayerBase;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using eMAS.Forms.PayRollProcessing;

namespace eMAS.All_UIs.PayRoll_Processing_FORMS.Staff_Attendance_FORMS
{
    public partial class PayRoll_PaySlip : Form
    {
        private IDAL dal;
        private PayRoll existingPayRoll;
        private PayRoll payRoll;
        private PayRollAttendance payRollAttendance;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<PayRoll> payRolls;
        private IList<PayRollAttendance> payRollAttendances;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Zone> zones;
        private Form reportForm;
        private DALHelper dalHelper;
        private Company company;
        private int ctr;
        private bool mechanised;

        public PayRoll_PaySlip()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.existingPayRoll = new PayRoll();
                this.payRoll = new PayRoll();
                this.payRollAttendance = new PayRollAttendance();
                this.payRolls = new List<PayRoll>();
                this.payRollAttendances = new List<PayRollAttendance>();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.zones = new List<Zone>();
                this.dalHelper = new DALHelper();
                this.company = new Company();
                this.ctr = 0;
                this.mechanised = false;
                this.reportForm = new Form();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    staffIDtxt.Text = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString();
                    nametxt.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool Exists(PayRoll payRoll)
        {
            bool result = true;
            try
            {
                existingPayRoll = dal.GetByID<PayRoll>(payRoll);

                if (existingPayRoll == null)
                {
                    result=false;
                }
                else
                {
                    payRoll = existingPayRoll;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();

                payRoll.Month = GlobalData.GetMonth(monthComboBox.Text).ToString();
                payRoll.Year = yearComboBox.Text;
                if (cmbOption.Text.Trim() == string.Empty  || cmbOption.Text.Trim().ToLower() == "payroll")
                {
                    try
                    {
                        PayRollStatus status = Exists(monthComboBox.Text, yearComboBox.Text);
                        if (status == PayRollStatus.Closed || status == PayRollStatus.Open)
                        {
                            ReprtData data = new ReprtData();

                            data.report = reportForm;
                            data.StaffID = staffIDtxt.Text.Trim();
                            data.Mechanised = cboMechanised.Text.Trim();
                            data.Depart = cboDepartment.Text;
                            data.Unit = cboUnit.Text;
                            data.Grade = cboGrade.Text;
                            data.GradeCat = cboGradeCategory.Text;
                            data.Year = payRoll.Year;
                            data.Zone = cboZone.Text;
                            data.Bank = cmbBank.Text.Trim();
                            data.Format = cboFormat.Text.Trim();
                            data.PaymentAccType = paymentacctype.Text.Trim();

                            //data.SalaryPaymentAccount = cmbPaymentAccount.Text;

                            if (reportForm != null && !reportForm.IsDisposed)
                            {
                                reportForm.Close();
                            }
                            data.Month = monthComboBox.Text.Trim();

                            frm.Close();
                            ThreadStart threadStart = delegate() { PayRoll_PaySlip.RunReport(data); };
                            Thread reportThread = new Thread(threadStart);
                            reportThread.SetApartmentState(ApartmentState.STA);
                            reportThread.IsBackground = true;
                            reportThread.Start();
                        }
                        else
                        {
                            MessageBox.Show("The payroll attendance for the specified period has not been generated", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frm.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        dal.RollBackTransaction();
                        Logger.LogError(ex);
                        frm.Close();
                    }
                }
                else if (cmbOption.Text.Trim().ToLower() == "payslip")
                {
                    try
                    {
                        if (staffIDtxt.Text.Trim() != string.Empty)
                        {
                            int paymentID = 0;
                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryPaymentView.StaffID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = staffIDtxt.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });

                           
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffSalaryPaymentView.Month",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = GlobalData.GetMonth(monthComboBox.Text.Trim()).ToString(),
                                    CriteriaOperator = CriteriaOperator.And
                                });
                            
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryPaymentView.Year",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = yearComboBox.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.None
                            });
                            payRollAttendances = dal.GetByCriteria<PayRollAttendance>(query);

                            if (payRollAttendances.Count <= 0)
                            {
                                MessageBox.Show("PayRoll is not generated for " + "Staff ID" + " " + staffIDtxt.Text.Trim() + "( " + nametxt.Text.Trim() + ")");
                                frm.Close();
                            }
                            else
                            {
                                foreach (PayRollAttendance payRollAttendance in payRollAttendances)
                                {
                                    paymentID = payRollAttendance.PaymentID;
                                }
                                if (cboFormat.Text.ToLower().Trim() == "payslip format 1")
                                {
                                    if (reportForm != null && !reportForm.IsDisposed)
                                    {
                                        reportForm.Close();
                                    }
                                    reportForm = new PaySlipFormatReportForm(staffIDtxt.Text.Trim(), paymentID, monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim(), cboMechanised.Text.Trim());
                                    reportForm.Show();
                                    frm.Close();
                                }
                                else
                                {
                                    if (reportForm != null && !reportForm.IsDisposed)
                                    {
                                        reportForm.Close();
                                    }
                                    reportForm = new PaySlipReportForm(staffIDtxt.Text.Trim(), paymentID, monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim(), cboMechanised.Text.Trim(),"");
                                    reportForm.Show();
                                    frm.Close();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter StaffID");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                }
                frm.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private PayRollStatus Exists(string month, string year)
        {
            PayRollStatus result = PayRollStatus.None;
            try
            {
                dalHelper.OpenConnection();
                if (dalHelper.ExecuteReader(" Select ID From StaffSalaryPayments Where Month =" + GlobalData.GetMonth(month) + " And Year=" + year + " And Status= 2").Rows.Count > 0)
                {
                    result = PayRollStatus.Closed;
                }
                else if (dalHelper.ExecuteReader(" Select ID From StaffSalaryPayments Where Month =" + GlobalData.GetMonth(month) + " And Year=" + year + " And Status= 1").Rows.Count > 0)
                {
                    result = PayRollStatus.Open;
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
                throw ex;
            }
            return result;
        }

        #region GeneratePayRoll
        private void GeneratePayRoll()
        {
            try
            {
                dal.BeginTransaction();
                dal.Save(payRoll);
                dal.CommitTransaction();
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Payroll could not be generated successfully");
            }
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Reset not completed");
            }
        }

        void monthComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                monthComboBox.Items.Clear();
                monthComboBox.Items.Add("All");
                if (company.PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";

                    foreach (string item in GlobalData.GetMonths())
                    {
                        monthComboBox.Items.Add(item);
                    }
                }
                else
                {
                    for (int i = 0; i <= 52; i++)
                    {
                        periodLabel.Text = "Week:";
                        monthComboBox.Items.Add("Week " + i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
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

        private void Reset()
        {
            try
            {
                monthComboBox.Items.Add(((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString());
                monthComboBox.Text = ((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString();
                yearComboBox.Items.Add(GlobalData.ServerDate.Year.ToString());
                yearComboBox.Text = GlobalData.ServerDate.Year.ToString();
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PayRoll___PaySlip_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                company = dal.GetAll<Company>()[0];
                if (company.PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                }
                else
                {
                    periodLabel.Text = "Week:";
                }
                searchGrid.Hide();
                Reset();
                staffIDtxt.Select();
                cmbOption.DropDown += new EventHandler(cmbOption_DropDown);
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Loading not completed");
            }
        }

        void cmbOption_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbOption.Items.Clear();
                cmbOption.Items.Add("Payroll");
                cmbOption.Items.Add("Payslip");
                //cmbOption.Items.Add("All Pay Slips");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Options could not be loaded");
            }
        }

        private void Clear()
        {
            try
            {
                nametxt.Clear();
                staffIDtxt.Clear();
                searchGrid.Visible = false;
                staffErrorProvider.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Clear();
                if (cmbOption.Text.ToLower() != "payslip")
                {
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
                    lblMechanised.Visible = true;
                    cboMechanised.Visible = true;
                    label3.Visible = true;
                    paymentacctype.Visible = true;
                }
                else
                {
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
                    lblMechanised.Visible = false;
                    cboMechanised.Visible = false;
                    label3.Visible = false;
                    paymentacctype.Visible = false;
                }

                if (cmbOption.Text.ToLower() == "payroll")
                {
                    cmbBank.Visible = true;
                    lblBank.Visible = true;
                }
                else
                {
                    cmbBank.Visible = false;
                    lblBank.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Options could not be changed");
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
                MessageBox.Show("Error:The form cannot close");
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (nametxt.Text.Length >= company.MinimumCharacter)
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
                            searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
                            searchGrid.BringToFront();
                            searchGrid.Visible = true;
                        }
                        else
                        {
                            searchGrid.Visible = false;
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
                MessageBox.Show("Error:Search by Staff Name cannot be completed");
            }
        }

        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text.Trim() + " is not Found");
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
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }

        private static void RunReport(object value)
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show();
                Application.DoEvents();

                ReprtData data = (ReprtData)value;
                if (data.Format.ToLower().Trim() == "payroll and medical claims".Trim())
                {
                    data.report = new PayRollOldReportForm2(data.StaffID,data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised,data.Bank,data.PaymentAccType, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll register".Trim())
                {
                    data.report = new PayRollOldReportForm3(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised, data.Bank, data.PaymentAccType, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll cross tab".Trim())
                {
                    //data.dal = new DAL();
                    //data.dal.BeginTransaction();
                    //data.payRoll = new PayRoll();
                    //data.payRoll.Month = GlobalData.GetMonth(data.Month).ToString();
                    //data.payRoll.Year = data.Year;
                    //data.payRoll = data.dal.GetByID<PayRoll>(data.payRoll);
                    //data.dal.Save(data.payRoll);
                    //data.dal.CommitTransaction();
                    data.report = new PayRollReportForm(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll combined register".Trim())
                {
                    data.report = new PayRollCombinedRegisterReportForm(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised,data.Bank, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll summary".Trim())
                {
                    data.report = new PayRollSummaryReportForm(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll summary by grade".Trim())
                {
                    data.report = new PayRollSummaryByGradeReportForm(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll summary by unit".Trim())
                {
                    data.report = new PayRollSummaryByUnitReportForm(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll master list".Trim())
                {
                    data.report = new PayRollMasterListReportForm(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised,data.Bank, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll combined register summary".Trim())
                {
                    data.report = new PayrollCombineRegisterSummaryReportForm(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll combined register detail".Trim())
                {
                    data.report = new PayrollCombineRegisterDetailReportForm(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised,data.Bank, frm);
                }
                else if (data.Format.ToLower().Trim() == "payroll summary by salary".Trim())
                {
                    data.report = new PayrollSummarySalary(data.StaffID, data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised, frm);
                }
                else
                {
                    data.report = new PayRollOldReportForm(data.StaffID,data.Month, data.Year, data.Depart, data.Unit, data.GradeCat, data.Grade, data.Zone, data.Mechanised, frm);
                }
                Application.Run(data.report);
                frm.Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
          
        }

        class ReprtData
        {
            public Form report;
            public string StaffID;
            public string Format;
            public string Month;
            public string Year;
            public string Depart;
            public string Unit;
            public string Zone;
            public string GradeCat;
            public string Grade;
            public string Mechanised;
            public string PaymentAccType;
            public string Bank;
            
            public PayRoll payRoll;
            public PayRoll existingPayRoll;
            public IDAL dal;
        }

        private void cboMechanised_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMechanised.Text.Trim() == "Yes")
                {
                    mechanised = true;
                }
                else if (cboMechanised.Text.Trim() == "No")
                {
                    mechanised = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMechanised_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboMechanised.Items.Clear();
                cboMechanised.Text = string.Empty;
                cboMechanised.Items.Add("All");
                cboMechanised.Items.Add("Yes");
                cboMechanised.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboFormat_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboFormat.Items.Clear();
                if(cmbOption.Text.ToLower().Trim() == "payroll")
                {
                    cboFormat.Items.Add("Default");
                    cboFormat.Items.Add("Payroll Register");
                    cboFormat.Items.Add("Payroll and Medical Claims");
                    cboFormat.Items.Add("Payroll Combined Register");
                    cboFormat.Items.Add("Payroll Combined Register Summary");
                    cboFormat.Items.Add("Payroll Combined Register Detail");
                    cboFormat.Items.Add("Payroll Summary");
                    cboFormat.Items.Add("Payroll Summary By Grade");
                    cboFormat.Items.Add("Payroll Summary By Unit");
                    cboFormat.Items.Add("Payroll Master List");
                    cboFormat.Items.Add("Payroll Cross Tab");
                    cboFormat.Items.Add("Payroll Summary By Salary");
                    

                }
                else if (cmbOption.Text.ToLower().Trim() == "payslip")
                {
                    cboFormat.Items.Add("Default");
                    cboFormat.Items.Add("Payslip Format 1");
                }
                else
                {
                    MessageBox.Show("Please Select Option");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        IList<Bank> lstBanks;
        private void cmbBank_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (lstBanks == null)
                    lstBanks = dal.GetAll<Bank>();

                cmbBank.Items.Clear();
                foreach (var bank in lstBanks)
                {
                    cmbBank.Items.Add(bank.Description);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }
        StaffSalaryHistoryDataMapper staffSalaryHistoryMapper;
        IList<SalaryPaymentAccount> lstSalaryPaymentAccounts;
        private void cmbPaymentAccount_DropDown(object sender, EventArgs e)
        {
            /*
            try
            {
                cmbPaymentAccount.Items.Clear();
                staffSalaryHistoryMapper = new StaffSalaryHistoryDataMapper();
                lstSalaryPaymentAccounts = staffSalaryHistoryMapper.GetAllSalaryPaymentAccounts();

                foreach (var salaryPaymentAcct in lstSalaryPaymentAccounts)
                {
                    cmbPaymentAccount.Items.Add(salaryPaymentAcct.AccountName);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }*/
        }

        private void cboFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormat.Text.ToLower().Trim() == "payroll register" || cboFormat.Text.ToLower().Trim() == "payroll and medical claims" || cboFormat.Text.ToLower().Trim() == "payroll combined register" || cboFormat.Text.ToLower().Trim() == "payroll combined register detail" || cboFormat.Text.ToLower().Trim() == "payroll master list")

                grpPaymentAccount.Visible = true;
            else
                grpPaymentAccount.Visible = false;
        }
    }
}
