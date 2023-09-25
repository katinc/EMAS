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
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.SMS;
using eMAS.Forms.Reports;
using HRDataAccessLayerBase;
using eMAS.Forms.Employment;
using System.IO;
using System.Configuration;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.SMS
{
    public partial class SMSForm : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<PhoneNumberType> phoneNumberTypeList;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Religion> religions;
        private IList<Denomination> denominations;
        private IList<Unit> units;
        private IList<Zone> zones;

        public SMSForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.phoneNumberTypeList = new List<PhoneNumberType>();
                this.departments = new List<Department>();
                this.religions = new List<Religion>();
                this.denominations = new List<Denomination>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.zones = new List<Zone>();
                this.dal.CloseConnection();
                this.dal.OpenConnection();
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

        private string getPhoneFormat(string PhoneNo)
        {
            string CorrectPhoneNumber = string.Empty;
            try
            {
                if (PhoneNo.Trim() != string.Empty && PhoneNo.Length == 13 && PhoneNo != null)
                {
                    string[] PhoneParts = PhoneNo.Split('-');
                    string FirstPart = PhoneParts[0].ToString().Trim();

                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PhoneNumberTypes.Code".Trim(),
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = FirstPart,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    phoneNumberTypeList = dal.GetByCriteria<PhoneNumberType>(query);
                    if (phoneNumberTypeList.Count > 0)
                    {

                        foreach (string PhonePart in PhoneParts)
                        {
                            CorrectPhoneNumber+=PhonePart;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return CorrectPhoneNumber;
        }

        public void WriteToLogFile(string content)
        {
            try
            {
                //if the directory does not exist create the directory
                if (!(Directory.Exists(ConfigurationManager.AppSettings["LogFilePath"].ToString())))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["LogFilePath"].ToString());
                }

                //get the path for the log file
                StringBuilder strLogFilePath = new StringBuilder();
                strLogFilePath.Append(ConfigurationManager.AppSettings["LogFilePath"].ToString());
                strLogFilePath.Append(@"\EmailLogFile.txt");

                //if the file doesnot exist create the file
                if (!File.Exists(strLogFilePath.ToString()))
                {
                    FileStream fsErrorLog = new FileStream(strLogFilePath.ToString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fsErrorLog.Close();
                }

                //write to the log file
                StreamWriter writer = new StreamWriter(strLogFilePath.ToString(), true);
                writer.WriteLine("********************************************************************");
                writer.WriteLine("Date " + DateTime.Now);
                writer.WriteLine("Content: " + content);
                writer.WriteLine("********************************************************************");
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                staffErrorProvider.Clear();
                if (cmbOption.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbOption, "Please Select the option");
                    cmbOption.Focus();
                }
                else if (cmbOption.Text.Trim().ToLower() == "single" && staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter the Staff ID");
                    staffIDtxt.Focus();
                }
                else if (txtMessage.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtMessage, "Please Enter the Message");
                    txtMessage.Focus();
                }              
                else if (checkBoxSendLater.Checked == true && dateTimePickerScheduleTime.Checked == false)
                {
                    result = false;
                    staffErrorProvider.SetError(dateTimePickerScheduleTime, "Please Enter The Schedule Date");
                    dateTimePickerScheduleTime.Focus();
                }
                else if (dateTimePickerScheduleTime.Checked && Validator.DateRangeValidator(dateTimePickerScheduleTime.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(dateTimePickerScheduleTime, "Please Scheduled Date cannot be leass than Today");
                    dateTimePickerScheduleTime.Focus();
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
                if (ValidateFields())
                {
                    if (cmbOption.Text.Trim().ToLower() == "bulk")
                    {
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "LEN(REPLACE(StaffPersonalInfoView.MobileNo,'-',''))".Trim(),
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = 10,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "REPLACE(StaffPersonalInfoView.MobileNo,'-','')".Trim(),
                            CriterionOperator = CriterionOperator.NotEqualTo,
                            Value = " ",
                            CriteriaOperator = CriteriaOperator.And
                        });
                        if (cboDepartment.Text.Trim() != string.Empty && cboDepartment.Text.Trim() != "All")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Department",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = cboDepartment.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        if (cboUnit.Text.Trim() != string.Empty && cboUnit.Text.Trim() != "All")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Unit",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = cboUnit.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        if (cboGradeCategory.Text.Trim() != string.Empty && cboGradeCategory.Text.Trim() != "All")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.GradeCategory",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = cboGradeCategory.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        if (cboGrade.Text.Trim() != string.Empty && cboGrade.Text.Trim() != "All")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Grade",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = cboGrade.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        if (cboZone.Text.Trim() != string.Empty && cboZone.Text.Trim() != "All")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Zone",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = cboZone.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        if (cboGender.Text.Trim() != string.Empty && cboGender.Text.Trim() != "All")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Gender",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = cboGender.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        if (cboReligion.Text.Trim() != string.Empty && cboReligion.Text.Trim() != "All")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Religion",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = cboReligion.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        if (cboDenomination.Text.Trim() != string.Empty && cboDenomination.Text.Trim() != "All")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Denomination",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = cboDenomination.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        employeeList = dal.GetByCriteria<Employee>(query);
                        if (employeeList.Count > 0)
                        {
                            int count = 0;
                            foreach (Employee employee in employeeList)
                            {
                                ScheduleMessage scheduleMessage = new ScheduleMessage();
                                scheduleMessage.To = employee.MobileNo;
                                scheduleMessage.From = "System";
                                scheduleMessage.Message = txtMessage.Text.Trim();
                                if (checkBoxSendLater.Checked == true)
                                {
                                    scheduleMessage.Schedule_time = dateTimePickerScheduleTime.Value;
                                    scheduleMessage.Status = "Scheduled";
                                }
                                else
                                {
                                    scheduleMessage.Schedule_time = DateTime.Now;
                                    scheduleMessage.Status = "Send";
                                }

                                dal.Save(scheduleMessage);
                                count++;
                            }
                            if (employeeList.Count == count)
                            {
                                MessageBox.Show(employeeList.Count.ToString() + "  Records targeted and All Staffs were sent Messages");
                            }
                            else if (count == 0)
                            {
                                MessageBox.Show(employeeList.Count.ToString() + "  Records targeted and None of the Staffs were sent Messages");
                            }
                            else
                            {
                                MessageBox.Show(employeeList.Count.ToString() + "  Records targeted but " + count.ToString() + " Staff(s) were sent Messages\n");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Records Exist,Please Check Whether Employees have Correct Phone Numbers");
                        }
                    }
                    else
                    {
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "LEN(REPLACE(StaffPersonalInfoView.MobileNo,'-',''))".Trim(),
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = 10,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "REPLACE(StaffPersonalInfoView.MobileNo,'-','')".Trim(),
                            CriterionOperator = CriterionOperator.NotEqualTo,
                            Value = " ",
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoView.StaffID".Trim(),
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = staffIDtxt.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                        employeeList = dal.GetByCriteria<Employee>(query);
                        if (employeeList.Count > 0)
                        {
                            int count = 0;
                            foreach (Employee employee in employeeList)
                            {
                                ScheduleMessage scheduleMessage = new ScheduleMessage();
                                scheduleMessage.To = employee.MobileNo;
                                scheduleMessage.From = "System";
                                scheduleMessage.Message = txtMessage.Text.Trim();
                                if (checkBoxSendLater.Checked == true)
                                {
                                    scheduleMessage.Schedule_time = dateTimePickerScheduleTime.Value;
                                    scheduleMessage.Status = "Scheduled";
                                }
                                else
                                {
                                    scheduleMessage.Schedule_time = DateTime.Now;
                                    scheduleMessage.Status = "Send";
                                }
                                dal.Save(scheduleMessage);
                                count++;
                            }
                            if (employeeList.Count == count)
                            {
                                MessageBox.Show(employeeList.Count.ToString() + " Record targeted and Message sent");
                                Clear();
                            }
                            else if (count == 0)
                            {
                                MessageBox.Show(employeeList.Count.ToString() + " Record targeted and No Message sent");
                            }
                            else
                            {
                                MessageBox.Show(employeeList.Count.ToString() + " Record targeted but " + count.ToString() + " Staffs were sent Messages\n Please Check the Phone Number of the Staff ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Records Exist,Please Check Whether Employee(s) have Correct Phone Numbers");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Message Could not be sent,Please See the System Administrator");
            }
        }

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
                string err = ex.Message;
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
                string err = ex.Message;
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
                Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbOption_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbOption.Items.Clear();
                cmbOption.Items.Add("Bulk");
                cmbOption.Items.Add("Single");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Options could not be loaded");
            }
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbOption.Text.ToLower().Trim() == "bulk")
                {
                    nametxt.Visible = false;
                    staffIDtxt.Visible = false;
                    nameLabel.Visible = false;
                    staffNoLabel.Visible = false;
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
                    lblGender.Visible = true;
                    cboGender.Visible = true;
                    lblReligion.Visible = true;
                    cboReligion.Visible = true;
                    lblDenomination.Visible = true;
                    cboDenomination.Visible = true;
                }
                else if (cmbOption.Text.ToLower().Trim() == "single")
                {
                    nametxt.Visible = true;
                    staffIDtxt.Visible = true;
                    nameLabel.Visible = true;
                    staffNoLabel.Visible = true;
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
                    lblGender.Visible = false;
                    cboGender.Visible = false;
                    lblReligion.Visible = false;
                    cboReligion.Visible = false;
                    lblDenomination.Visible = false;
                    cboDenomination.Visible = false;
                }
                else
                {
                    nametxt.Visible = false;
                    staffIDtxt.Visible = false;
                    nameLabel.Visible = false;
                    staffNoLabel.Visible = false;
                    searchGrid.Visible = false;
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
                    lblGender.Visible = false;
                    cboGender.Visible = false;
                    lblReligion.Visible = false;
                    cboReligion.Visible = false;
                    lblDenomination.Visible = false;
                    cboDenomination.Visible = false;
                }
            }
            catch (Exception ex)
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

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    if (employees.Count <= 0)
                    {
                        this.employees = dal.LazyLoad<Employee>();
                    }
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

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    if (employees.Count <= 0)
                    {
                        this.employees = dal.LazyLoad<Employee>();
                    }
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
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 24;
                        }
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 46);
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
                MessageBox.Show("Error:Search by Staff ID cannot be completed");
            }
        }

        private void Clear()
        {
            try
            {
                nametxt.Clear();
                staffIDtxt.Clear();
                staffIDtxt.Visible = false;
                nametxt.Visible = false;
                staffNoLabel.Visible = false;
                nameLabel.Visible = false;
                dateTimePickerScheduleTime.Value = DateTime.Now;
                checkBoxSendLater.Checked = false;
                txtMessage.Clear();
                dateTimePickerScheduleTime.Checked = false;
                cmbOption.Items.Clear();
                searchGrid.Visible = false;
                staffErrorProvider.Clear();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void checkBoxSendLater_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxSendLater.Checked)
                {
                    lblDate.Visible = true;
                    dateTimePickerScheduleTime.Visible = true;
                    dateTimePickerScheduleTime.Checked = true;
                }
                else
                {
                    lblDate.Visible = false;
                    dateTimePickerScheduleTime.Visible = false;
                    dateTimePickerScheduleTime.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                SMSFormView sMSFormView = new SMSFormView();
                sMSFormView.BringToFront();
                sMSFormView.Show();
            }
            catch(Exception ex)
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

        private void cboReligion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboDenomination.Items.Clear();
                cboDenomination.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "DenominationView.Religion",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboReligion.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                cboDenomination.Items.Add("All");
                denominations = dal.GetByCriteria<Denomination>(query);
                foreach (Denomination denomination in denominations)
                {
                    cboDenomination.Items.Add(denomination.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboReligion_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboReligion.Items.Clear();
                cboReligion.Text = string.Empty;
                cboReligion.Items.Add("All");
                religions = dal.GetAll<Religion>();
                foreach (Religion religion in religions)
                {
                    cboReligion.Items.Add(religion.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SMSForm_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}