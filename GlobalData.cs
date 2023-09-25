using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Imaging;
using System.Drawing;
using HRDataAccessLayer;
using System.Collections;
using HRBussinessLayer.ErrorLogging;
using eMAS.Forms.EmployeeManagement;
using System.Globalization;
using System.Data;
using Microsoft.Win32;
using HRDataAccessLayerBase;
using System.Diagnostics;

namespace eMAS
{
    public class AccessLevelControles
    {
        public string Name;
    }

    public enum  Months
    {
        None,
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public static class GlobalData
    {
        private static string dataAccessException;
        private static string caption;
        private static User user;
        public static string ItemControl { get; set; }
        public static string Role { get; set; }
        private static List<AccessLevelControles> MyControlls;

        private static string password;
        private static string dataSource;
        private static string username;
        private static string databaseName;

        public static string payrollformat = "default";

        public static DataReference.hrContextDataContext _context = new DataReference.hrContextDataContext();

        private static System.Windows.Forms.ErrorProvider staffErrorProvider;

        private static DALHelper dal;

        static GlobalData()
        {
            dal = new DALHelper();
            try
            {

                RegistryKey keys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\IDNS\EMAS");
                if (keys != null)
                {
                    password = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(keys.GetValue("PASSWORD").ToString()));
                    dataSource = keys.GetValue("DATASOURCE").ToString();
                    username = keys.GetValue("USERNAME").ToString();
                    databaseName = keys.GetValue("DATABASENAME").ToString();

                    keys.Close();
                }

                dataAccessException = "A connection error occured please do the ff to troubleshoot:\n1. Make sure your network cable is plugged in properly.\n2. Ask your administrator to make sure the database service is running.";
                caption = "EMAS ";
                //connectionParameters = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString.Split(';');
                //connectionParameters = [4];
                //connectionParameters[0] = dataSource; // data source
                //connectionParameters[1] = DatabaseName; // db name
                //connectionParameters[2] = username; // user
                //connectionParameters[3] = password;
                user = new User();
                MyControlls = new List<AccessLevelControles>();
                _context.Connection.ConnectionString = string.Format(ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString, dataSource, databaseName, username,  password);


                staffErrorProvider = new System.Windows.Forms.ErrorProvider();

            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        #region Get Last Day Of Month
        public static int GetLastDayOfMonth(int month)
        {
            int result = 0;
            try
            {
                if (month == 1)
                {
                    return 31;
                }
                else if (month == 2)
                {
                    return 28;
                }
                else if (month == 3)
                {
                    return 31;
                }
                else if (month == 4)
                {
                    return 30;
                }
                else if (month == 5)
                {
                    return 31;
                }
                else if (month == 6)
                {
                    return 30;
                }
                else if (month == 7)
                {
                    return 31;
                }
                else if (month == 8)
                {
                    return 31;
                }
                else if (month == 9)
                {
                    return 30;
                }
                else if (month == 10)
                {
                    return 31;
                }
                else if (month == 11)
                {
                    return 30;
                }
                else if (month == 12)
                {
                    return 31;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return result;
        }

        public static int GetLastDayOfMonth(string month)
        {
            int result = 0;
            try
            {
                if (month.ToLower() == "january")
                {
                    return 31;
                }
                else if (month.ToLower() == "february")
                {
                    return 28;
                }
                else if (month.ToLower() == "march")
                {
                    return 31;
                }
                else if (month.ToLower() == "april")
                {
                    return 30;
                }
                else if (month.ToLower() == "may")
                {
                    return 31;
                }
                else if (month.ToLower() == "june")
                {
                    return 30;
                }
                else if (month.ToLower() == "july")
                {
                    return 31;
                }
                else if (month.ToLower() == "august")
                {
                    return 31;
                }
                else if (month.ToLower() == "september")
                {
                    return 30;
                }
                else if (month.ToLower() == "october")
                {
                    return 31;
                }
                else if (month.ToLower() == "november")
                {
                    return 30;
                }
                else if (month.ToLower() == "december")
                {
                    return 31;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return result;
        }

        #endregion

        public static User User
        {
            get { return user; }
            set { user = value; }
        }

        private static List<AccessLevelControles> AccessLevelControles
        {
            get { return MyControlls; }
            set { MyControlls = value; }
        }

        #region Data Access Execption
        public static string DataAccessException
        {
            get { return dataAccessException; }
        }

        #endregion

        #region Caption
        public static string Caption
        {
            get { return caption; }
            set { caption = value; }
        }
        #endregion

        #region Report Connection String
        public static string ServerName
        {
            get { return dataSource; }
        }

        public static string DatabaseName
        {
            get { return databaseName; }
        }

        public static string UserID
        {
            get { return username; }
        }

        public static string Password
        {
            get { return password; }
        }
        #endregion

        #region Date And Time
        public static DateTime ServerDate
        {
            get { return DateTime.Today; }
        }

        public static IList<string> GetYears()
        {
            IList<string> tempString = new List<string>();
            try
            {
                //for (int i = 1950; i <= ServerDate.Year-1; i++)
                //{
                //    tempString.Add(i.ToString());
                //}

                for (int i = ServerDate.Year; i >= 1950; i--)
                {
                    tempString.Add(i.ToString());
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return tempString;
        }
        #endregion

        public static void SetFormPermissions(Form f, IDAL dal, int userID)
        {
            try
            {
                List<ControlToRole> parts = new List<ControlToRole>();
                List<ControlToRole> part = new List<ControlToRole>();
                IList<ControlToRole> controlToRoles = new List<ControlToRole>();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "ID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = userID,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "Page",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = f.Name,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.None
                });
                controlToRoles = dal.GetByCriteria<ControlToRole>(query);
                if (controlToRoles.Count > 0)
                {
                    foreach (ControlToRole controlToRole in controlToRoles)
                    {
                        Control[] controls = f.Controls.Find(controlToRole.Controls.ControlID, true);
                        foreach (var control in controls)
                        {
                            if (control != null)
                            {
                                if (parts.Exists(x => x.Controls.ControlID == control.Name))
                                {
                                    var old = parts.Find(x => x.Controls.ControlID.Contains(control.Name));
                                    var oldName = old.Controls.ControlID;
                                    var oldInvisible = old.Invisible;
                                    var oldDisabled = old.Disabled;
                                    var newName = controlToRole.Controls.ControlID;
                                    var newInvisible = controlToRole.Invisible;
                                    var newDisabled = controlToRole.Disabled;
                                    if (oldInvisible != newInvisible && oldInvisible == 1)
                                    {
                                        control.Visible = newInvisible == 1 ? false : true;
                                    }
                                    else if (oldInvisible != newInvisible && newInvisible == 1)
                                    {
                                        control.Visible = oldInvisible == 1 ? false : true;

                                    }
                                    if (oldDisabled != newDisabled && oldDisabled == 1)
                                    {
                                        control.Enabled = newDisabled == 1 ? false : true;
                                    }
                                    else if (oldDisabled != newDisabled && newDisabled == 1)
                                    {
                                        control.Enabled = oldDisabled == 1 ? false : true;
                                    }
                                }
                                else
                                {
                                    control.Visible = controlToRole.Invisible == 1 ? false : true;
                                    control.Enabled = controlToRole.Disabled == 1 ? false : true;
                                }

                                part.Add(new ControlToRole() { Controls = new Controls { ControlID = controlToRole.Controls.ControlID }, Invisible = controlToRole.Invisible, Disabled = controlToRole.Disabled });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                //throw ex;
            }
        }

        public static void SetAccessControlls(string category)
        {
            MyControlls = new List<AccessLevelControles>();
            if (category == "Administrator")
            {
                var getAll = _context.UserAccessLevelsViews.ToList();
                foreach (var item in getAll)
                {
                    if (item.AccessLevel1ID.ToString() == "2" && item.AccessLevel2ID.ToString() == "65")
                    {

                    }

                    MyControlls.Add(new AccessLevelControles { Name = item.AccessLevel1Control });
                    MyControlls.Add(new AccessLevelControles { Name = item.AccessLevel2Control });
                    MyControlls.Add(new AccessLevelControles { Name = item.AccessLevel3Control });
                    MyControlls.Add(new AccessLevelControles { Name = item.AccessLevel4Control });
                }

            }
            else
            {
                var getAll = _context.UserAccessLevelsViews.Where(u => u.RoleName == category).ToList();
                foreach (var item in getAll)
                {
                    MyControlls.Add(new AccessLevelControles { Name = item.AccessLevel1Control });
                    MyControlls.Add(new AccessLevelControles { Name = item.AccessLevel2Control });
                    MyControlls.Add(new AccessLevelControles { Name = item.AccessLevel3Control });
                    MyControlls.Add(new AccessLevelControles { Name = item.AccessLevel4Control });
                }

            }
        }

        public static IDictionary<string, DataObjects> ProcessGridEdit(DataGridViewRow oldRow, DataGridViewRow newRow, int changeID, Form form)
        {
            IDictionary<string, DataObjects> values = new Dictionary<string, DataObjects>();

            for (int j = 0; j < oldRow.Cells.Count; j++)
            {
                if (!oldRow.Cells[j].Value.ToString().Equals(newRow.Cells[j].Value.ToString()))
                {
                    DataGridView dgv = oldRow.DataGridView;
                    DataObjects dataObjects = new DataObjects();
                    string controlName = oldRow.DataGridView.Columns[j].Name;
                    dataObjects.oldData = oldRow.Cells[j].Value.ToString();
                    dataObjects.newData = newRow.Cells[j].Value.ToString();
                    dataObjects.controlName = controlName;
                    values.Add(controlName, dataObjects);
                }
            }

            if (values.Count() > 0)
            {
                var dataset = GlobalData._context.EnforceDatasets.SingleOrDefault(u => u.Name == form.Name);

                SaveChangeRequests(values, dataset.ID, changeID, "", form.Name);

                if (!_context.EnforceDatasets.SingleOrDefault(u => u.Name == form.Name).RequireChangeRequestApproval)
                {
                    ProcessApprove(changeID);
                }
            }
            return values;
        }

        public static void SaveChangeRequests(IDictionary<string, DataObjects> values, decimal datasetID, int changeID, string staffID, string formName)
        {
            var grouping = Guid.NewGuid().ToString();

            for (int i = 0; i < values.Count; i++)
            {
                var getDatelement = GlobalData._context.EnforceDataElementsViews.SingleOrDefault(u => u.DatasetID == datasetID && u.Name == values.ElementAt(i).Value.controlName);

                var newRequest = new DataReference.StaffChangesRequest
                {
                    StaffID = staffID,
                    Form = formName,
                    DatasetID = datasetID,
                    ChangeID = changeID,
                    Control = values.ElementAt(i).Value.controlName,
                    OldValue = values.ElementAt(i).Value.oldData,
                    NewValue = values.ElementAt(i).Value.newData,
                    UserId = GlobalData.User.ID,
                    Archived = false,
                    DateAndTimeGenerated = DateTime.Now,
                    Date = DateTime.Now,
                    Approved = false,
                    ApprovedBy = "",
                    Grouping = grouping.ToString(),
                    NewValueID = null,
                    ControlType = getDatelement == null ? "DataGridView" : getDatelement.ControlType,
                    DataElementID = getDatelement == null ? 0 : getDatelement.ID,
                    Reason = "Form Edit",
                    SubDatasetID = getDatelement == null ? 0 : getDatelement.SubDatasetID,
                };
                GlobalData._context.StaffChangesRequests.InsertOnSubmit(newRequest);
            }
            GlobalData._context.SubmitChanges();
        }
        public static bool ProcessEdit(List<controlObject> oldValues, List<Control> controls, Form form, int editID, string staffID)
        {
            try
            {
                var dataset = GlobalData._context.EnforceDatasets.SingleOrDefault(u => u.Description == form.Name);
                if (CheckIfAwaitingApproval(dataset.ID, editID))
                {
                    MessageBox.Show("This staff has changes awaiting approval. \nThey must be approved or rejected first.", "Error Saving Changes.");
                    return false;
                }

                controls = new List<Control>();
                GlobalData.FillControls(controls, form);
                var newVals = extentions.ControlsCompare(oldValues, GlobalData.CloneControls(controls, null));
                GlobalData.SaveChangeRequests(newVals, dataset.ID, editID, staffID, form.Name);

                if (!dataset.RequireChangeRequestApproval)
                {
                    ProcessApprove(editID);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;

            }
            return true;
        }

        public static bool ProcessApprove(int ChangeId)
        {
            var getRequests = GlobalData._context.StaffChangesRequests.Where
            (u => u.ChangeID == Convert.ToDecimal(ChangeId) && u.Approved == false && u.Archived == false).ToList();

            foreach (var item in getRequests)
            {
                item.Approved = true;
                item.ApprovedBy = GlobalData.UserID;

                var approval = new DataReference.StaffChangesApproval
                {
                    ChangeRequestID = item.ID,
                    StaffID = item.StaffID,
                    Decision = "APPROVE",
                    SubDatasetID = 0,
                    DataElementID = 0,
                    OldValue = item.OldValue,
                    NewValue = item.NewValue,
                    Reason = "",
                    UserId = GlobalData.User.ID,
                    Archived = false,
                    Decided = true,
                    DecisionDate = DateTime.Today,
                    DecidedBy = GlobalData.User.ID.ToString(),
                    DateAndTimeGenerated = DateTime.Now,
                };
                GlobalData._context.StaffChangesApprovals.InsertOnSubmit(approval);

                RequestChangeApprovalForm form = new RequestChangeApprovalForm();
                form.CommitTransChanges(item);

                GlobalData._context.SubmitChanges();
            }

            return true;
        }

        public static bool ProcessDelete(string datasetName, int Id)
        {
            try
            {
                var dataElement = GlobalData._context.EnforceDataElementsViews.FirstOrDefault(u => u.DatasetName == datasetName && u.StaffDataTable != null);
                var staffDataTable = dataElement.StaffDataTable;
                ComboDataMapper combo = new ComboDataMapper();
                combo.Archive(staffDataTable, Id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
            return true;
        }

        private static void ShowToolStipItems(ToolStripItemCollection toolStripItems, ToolStripItemCollection toolStripItems2, Controls controlToRole, List<Controls> parts)
        {
            try
            {
                ToolStripItem[] items;
                items = toolStripItems.Find(controlToRole.ControlID, true);
                if (items.Count() <= 0)
                {
                    foreach (ToolStripMenuItem mi in toolStripItems)
                    {
                        if (mi.DropDownItems.Count > 0)
                        {
                            ShowToolStipItems(mi.DropDownItems, toolStripItems2, controlToRole, parts);
                        }
                        items = mi.DropDownItems.Find(controlToRole.ControlID, true);
                        if (items.Count() > 0)
                        {
                            break;
                        }
                    }
                }

                if (items.Count() > 0)
                {
                    foreach (var item in items)
                    {
                        if (controlToRole.ControlID == item.Name)
                        {

                            var exits = MyControlls.Where(u => u.Name == controlToRole.ControlID);
                            if (exits.Any())
                            {
                                if (parts.Exists(x => x.ControlID == item.Name))
                                {
                                    var old = parts.Find(x => x.ControlID.Contains(item.Name));
                                    var oldName = old.ControlID;
                                    var newName = controlToRole.ControlID;

                                    parts.Add(new Controls { ControlID = controlToRole.ControlID });
                                }
                                else
                                {
                                    item.Visible = true;
                                    item.Enabled = true;
                                    parts.Add(new Controls { ControlID = controlToRole.ControlID });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
                throw ex;
            }
        }


        public static void SetMenuPermissions(Form f, ToolStripItemCollection m, ToolStripItemCollection m2, IDAL dal, int userID)
        {
            try
            {
                m = m2;
                //IList<ControlToRole> controlToRoles = new List<ControlToRole>();
                //List<ControlToRole> parts = new List<ControlToRole>();
                IList<Controls> controlToRoles = new List<Controls>();
                List<Controls> parts = new List<Controls>();
                Query query = new Query();
                //query.Criteria.Add(new Criterion()
                //{
                //    Property = "ID",
                //    CriterionOperator = CriterionOperator.EqualTo,
                //    Value = userID,
                //    CriteriaOperator = CriteriaOperator.And
                //});
                query.Criteria.Add(new Criterion()
                {
                    Property = "Page",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = f.Name,
                    CriteriaOperator = CriteriaOperator.None
                });
                //query.Criteria.Add(new Criterion()
                //{
                //    Property = "Active",
                //    CriterionOperator = CriterionOperator.EqualTo,
                //    Value = true,
                //    CriteriaOperator = CriteriaOperator.None
                //});
                controlToRoles = dal.GetByCriteria<Controls>(query);
                if (controlToRoles.Count > 0)
                {
                    foreach (Controls controlToRole in controlToRoles)
                    {
                        if (m != null)
                        {
                            ShowToolStipItems(m, m2, controlToRole, parts);
                            //parts.Add(new ControlToRole() { Controls = new Controls { ControlID = controlToRole.Controls.ControlID }, Invisible = controlToRole.Invisible, Disabled = controlToRole.Disabled });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
        }

        #region ImageToArray
        public static byte[] ImageToArray(Image img)
        {
            byte[] photoArray = null;
            try
            {
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
                photoArray = ms.ToArray();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return photoArray;
        }
        #endregion

        #region ArrayToImage
        public static Image ArrayToImage(byte[] photoArray)
        {
            Image img = null;
            try
            {
                MemoryStream ms = new MemoryStream(photoArray);
                img = Image.FromStream(ms);

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return img;
        }
        #endregion

        #region ArrayToImage
        public static Image ArrayToImage(object photoArray)
        {
            Image img = null;
            try
            {
                System.Data.Linq.Binary test = (System.Data.Linq.Binary)photoArray;
                byte[] bytes = (byte[])test.ToArray();
                MemoryStream ms = new MemoryStream(bytes);
                img = Image.FromStream(ms);

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return img;
        }
        #endregion

        public static IList<string> GetMonthsToDate()
        {
            IList<string> months = new List<string>();
            try
            {
                int currentMonth = ServerDate.Month;
                for (int i = 1; i <= currentMonth; i++)
                {
                    months.Add(((Months)Enum.Parse(typeof(Months), i.ToString())).ToString());
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return months;
        }

        public static IList<string> GetMonths()
        {
            IList<string> months = new List<string>();
            try
            {
                months.Add("January");
                months.Add("February");
                months.Add("March");
                months.Add("April");
                months.Add("May");
                months.Add("June");
                months.Add("July");
                months.Add("August");
                months.Add("September");
                months.Add("October");
                months.Add("November");
                months.Add("December");
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ex;
            }
            return months;
        }

        public static int GetMonth(string newMonth)
        {
            int temp = 0;
            try
            {
                if (newMonth != string.Empty && newMonth.Trim().ToUpper() != "ALL")
                {
                    Months month = (Months)Enum.Parse(typeof(Months), newMonth);
                    switch (month)
                    {
                        case Months.January:
                            temp = 1;
                            break;
                        case Months.February:
                            temp = 2;
                            break;
                        case Months.March:
                            temp = 3;
                            break;
                        case Months.April:
                            temp = 4;
                            break;
                        case Months.May:
                            temp = 5;
                            break;
                        case Months.June:
                            temp = 6;
                            break;
                        case Months.July:
                            temp = 7;
                            break;
                        case Months.August:
                            temp = 8;
                            break;
                        case Months.September:
                            temp = 9;
                            break;
                        case Months.October:
                            temp = 10;
                            break;
                        case Months.November:
                            temp = 11;
                            break;
                        case Months.December:
                            temp = 12;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ex;
            }
            return temp;
        }

        public static string GetMonth(int newMonth)
        {
            string temp = string.Empty;
            try
            {
                if (newMonth >= 1 || newMonth <= 12)
                {

                    switch (newMonth)
                    {
                        case 1:
                            temp = "January";
                            break;
                        case 2:
                            temp = "February";
                            break;
                        case 3:
                            temp = "March";
                            break;
                        case 4:
                            temp = "April";
                            break;
                        case 5:
                            temp = "May";
                            break;
                        case 6:
                            temp = "June";
                            break;
                        case 7:
                            temp = "July";
                            break;
                        case 8:
                            temp = "August";
                            break;
                        case 9:
                            temp = "September";
                            break;
                        case 10:
                            temp = "October";
                            break;
                        case 11:
                            temp = "November";
                            break;
                        case 12:
                            temp = "December";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ex;
            }
            return temp;
        }

        public static string GetFullName(Employee employee)
        {
            try
            {
                string fullName = string.Empty;
                if (employee != null)
                {
                    fullName = employee.FirstName + (employee.OtherName == string.Empty ? " " : " " + employee.OtherName + " ") + employee.Surname;
                }
                return fullName;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw ex;
            }
        }

        public static string GetFullName(string surname, string firstname, string othername)
        {
            try
            {
                string fullname = string.Empty;
                if (firstname != string.Empty && surname != string.Empty)
                {
                    fullname = firstname + (othername == string.Empty ? " " : " " + othername + " ") + surname;
                }
                return fullname;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public static void LogError(Exception ex)
        {

        }

        public static string GetAge(DateTime birthDate)
        {
            string age = String.Empty;
            try
            {
                int yrcheck = GlobalData.ServerDate.Year - DateTime.Parse(birthDate.ToString()).Year;
                int monthcheck = GlobalData.ServerDate.Month - DateTime.Parse(birthDate.ToString()).Month;
                int daycheck = GlobalData.ServerDate.Day - DateTime.Parse(birthDate.ToString()).Day;
                if (yrcheck == 0)
                {
                    if (daycheck == 0 || daycheck > 0)
                        age = monthcheck + " months";
                    else
                        age = monthcheck - 1 + " months";
                }
                else if (yrcheck == 1)
                {
                    if (monthcheck < 0)
                    {
                        if (daycheck > 0 || daycheck == 0)
                            age = monthcheck + 12 + " months";
                        else if (daycheck < 1)
                            age = (monthcheck - 1) + 12 + " months";
                    }
                    else if (monthcheck == 0)
                    {
                        if (daycheck == 0 || daycheck > 0)
                            age = "1 yr";
                        else if (daycheck < 0)
                            age = "11 months";
                        else if (monthcheck > 0)
                            age = "1 yr";
                    }
                }
                else if (yrcheck > 1)
                {
                    if (monthcheck > 0)
                        age = yrcheck + " yrs";
                    else if (monthcheck < 0)
                        age = yrcheck - 1 + " yrs";
                    else if (monthcheck == 0)
                    {
                        if (daycheck == 0 && daycheck > 0)
                            age = yrcheck + " yrs";
                        else
                            age = yrcheck - 1 + " yrs";
                    }
                }
            }
            catch (Exception ex)
            {
                age = "N/A";
                ex.GetType();
                throw ex;
            }
            return age;
        }

        public static string GetAgeWithoutDescriptions(DateTime birthDate)
        {
            string age = String.Empty;
            try
            {
                int yrcheck = GlobalData.ServerDate.Year - DateTime.Parse(birthDate.ToString()).Year;
                int monthcheck = GlobalData.ServerDate.Month - DateTime.Parse(birthDate.ToString()).Month;
                int daycheck = GlobalData.ServerDate.Day - DateTime.Parse(birthDate.ToString()).Day;

                if (yrcheck == 0)
                {
                    age = "0";
                }
                else if (yrcheck == 1)
                {
                    if (monthcheck < 0)
                    {
                        age = "1";
                    }
                    else if (monthcheck == 0)
                    {
                        age = "1";
                    }
                }
                else if (yrcheck > 1)
                {
                    if (monthcheck > 0)
                        age = yrcheck.ToString();
                    else if (monthcheck < 0)
                        age = (yrcheck - 1).ToString();
                    else if (monthcheck == 0)
                    {
                        if (daycheck == 0 && daycheck > 0)
                            age = yrcheck.ToString();
                        else
                            age = (yrcheck - 1).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                age = "0";
                throw ex;
            }
            return age;
        }

        public static DialogResult QuestionMessage(string message)
        {
            return MessageBox.Show(message, GlobalData.caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, GlobalData.caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DataGridView CopyDataGridView(DataGridView dgv_org)
        {
            DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                    {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgv_copy.Rows.Add(row);
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return dgv_copy;
        }

        public static void FillDataGrid(DataGridView grid, Form form)
        {
            try
            {
                var getSubdataset = GlobalData._context.EnforceSubDatasetViews.First(u => u.DatasetName == form.Name);
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    var newDataElement = new DataReference.EnforceDataElement
                    {
                        SubDatasetID = getSubdataset.ID,
                        Name = column.Name,
                        Description = column.HeaderText,
                        DataType = "String",
                        Required = true,
                        MinimumValue = "1",
                        MaximumValue = "50",
                        MinimumLength = 1,
                        MaximumLength = 250,
                        AutoGenerated = true,
                        IsActive = true,
                        ControlType = column.GetType().Name,
                    };
                    GlobalData._context.EnforceDataElements.InsertOnSubmit(newDataElement);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            GlobalData._context.SubmitChanges();
        }

        public static void FillControls(List<Control> container, Control control)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in control.Controls)
            {
                //if (child is DataGridView)
                //{
                //    container.Add(child);
                //}
                string tags = string.Empty;
                if (child.Tag != null)
                {
                    container.Add(child);
                }

                if (child.HasChildren)
                {
                    if (child is GroupBox)
                    {
                        container.Add(child);
                    }

                    if (child is DataGridView)
                    {
                        container.Add(child);
                    }
                    FillControls(container, child);
                }
                else if ((child is TextBox || child is MaskedTextBox || child is ComboBox || child is DateTimePicker || child is CheckBox || child is CheckedListBox) && child.Name != string.Empty)
                {
                    container.Add(child);
                    FillControls(container, child);
                }
            }
        }

        public static void assignControls(Control form)
        {
            List<Control> container;
            container = new List<Control>();


            FillControls(container, form);

            try
            {
                List<DataReference.EnforceDataElementsView> dataElements = GlobalData._context.EnforceDataElementsViews.Where(u => u.DatasetName == form.Name).ToList();
                foreach (var ctrl in container)
                {
                    foreach (var element in dataElements)
                    {
                        if (ctrl.Name == element.Name)
                        {
                            ctrl.Enabled = Convert.ToBoolean(element.IsActive);
                            if (ctrl is TextBox)
                            {
                                ((TextBox)ctrl).Visible = Convert.ToBoolean(element.IsActive);
                                ((TextBox)ctrl).MaxLength = element.MaximumLength;
                            }
                            else if (ctrl is ComboBox)
                            {
                                ((ComboBox)ctrl).Visible = Convert.ToBoolean(element.IsActive);
                            }
                            else if (ctrl is DateTimePicker)
                            {
                                ((DateTimePicker)ctrl).Visible = Convert.ToBoolean(element.IsActive);
                                //((DateTimePicker)control).MaxDate = Convert.ToDateTime(element.MaximumValue);
                                //((DateTimePicker)control).MinDate = Convert.ToDateTime(element.MinimumValue);
                            }
                            else if (ctrl is CheckBox)
                            {
                                ((CheckBox)ctrl).Visible = Convert.ToBoolean(element.IsActive);
                            }
                            else if (ctrl is CheckedListBox)
                            {
                                ((CheckedListBox)ctrl).Visible = Convert.ToBoolean(element.IsActive);
                            }
                            else if (ctrl is Button)
                            {
                                ((Button)ctrl).Visible = Convert.ToBoolean(element.IsActive);
                            }
                            else if (ctrl is DataGridView)
                            {
                                ((DataGridView)ctrl).Visible = Convert.ToBoolean(element.IsActive);
                            }
                            else if (ctrl is NumericUpDown)
                            {
                                ((NumericUpDown)ctrl).Visible = Convert.ToBoolean(element.IsActive);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void SaveControl(Form form)
        {

            List<Control> controls;
            controls = new List<Control>();


            FillControls(controls, form);

            void saveSubs()
            {
                foreach (Control item in controls)
                {
                    if (item is GroupBox)
                    {
                        var datasetId = GlobalData._context.EnforceDatasets.SingleOrDefault(u => u.Name == form.Name).ID;

                        var newSubData = new DataReference.EnforceSubDataset
                        {
                            DatasetID = datasetId,
                            Name = item.Name,
                            Description = item.Text == string.Empty ? item.Name : item.Text,
                            IsActive = true,
                            Required = true,
                        };
                        GlobalData._context.EnforceSubDatasets.InsertOnSubmit(newSubData);
                        GlobalData._context.SubmitChanges();
                    }
                }

            }

            saveSubs();

            foreach (Control item in controls)
            {
                try
                {
                    if (!(item is GroupBox))
                    {
                        var subID = GlobalData._context.EnforceSubDatasetViews.SingleOrDefault(u => u.DatasetName == form.Name && u.Name == item.Parent.Name).ID;

                        var newDataElement = new DataReference.EnforceDataElement
                        {
                            SubDatasetID = subID,
                            Name = item.Name,
                            Description = item.Name,
                            DataType = "String",
                            Required = true,
                            MinimumValue = "1",
                            MaximumValue = "50",
                            MinimumLength = 1,
                            MaximumLength = 250,
                            AutoGenerated = true,
                            IsActive = true,
                            ControlType = "textbox",
                        };
                        GlobalData._context.EnforceDataElements.InsertOnSubmit(newDataElement);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    throw;
                }
            }
            GlobalData._context.SubmitChanges();
        }

        public static void SaveControls(List<Control> controls)
        {
            foreach (Control item in controls)
            {
                if (item.Parent.Name.ToLower() == "groupbox2")
                {
                    var newDataElement = new DataReference.EnforceDataElement
                    {
                        SubDatasetID = 51,
                        Name = item.Name,
                        Description = item.Name,
                        DataType = "String",
                        Required = true,
                        MinimumValue = "1",
                        MaximumValue = "50",
                        MinimumLength = 1,
                        MaximumLength = 250,
                        AutoGenerated = true,
                        IsActive = true,
                        ControlType = "textbox",
                    };
                    //GlobalData._context.EnforceDataElements.InsertOnSubmit(newDataElement);
                }
                else if (item.Parent.Name.ToLower() == "groupbox3")
                {
                    var newDataElement = new DataReference.EnforceDataElement
                    {
                        SubDatasetID = 52,
                        Name = item.Name,
                        Description = item.Name,
                        DataType = "String",
                        Required = true,
                        MinimumValue = "1",
                        MaximumValue = "50",
                        MinimumLength = 1,
                        MaximumLength = 250,
                        AutoGenerated = true,
                        IsActive = true,
                        ControlType = "textbox",
                    };
                    GlobalData._context.EnforceDataElements.InsertOnSubmit(newDataElement);
                }

            }
            GlobalData._context.SubmitChanges();
        }

        public static bool ValidateSave(List<Control> controls, Control ctrl)
        {
            bool result = true;
            List<DataReference.EnforceDataElementsView> dataElements = GlobalData._context.EnforceDataElementsViews.Where(u => u.DatasetName == ctrl.Name).ToList();
            try
            {
                foreach (Control control in controls)
                {
                    foreach (var element in dataElements)
                    {
                        if (control.Name == element.Name)
                        {
                            if (element.SubDatasetRequired)
                            {
                                if (control is TextBox)
                                {
                                    if ((element.Required && element.IsActive) && (control.Text.Trim() == string.Empty || ((TextBox)control).TextLength > element.MaximumLength))
                                    {
                                        staffErrorProvider.SetError(control, "This is a required field, kindly fill it");
                                        control.Focus();
                                        return result = false;
                                    }
                                }
                                else if (control is ComboBox)
                                {
                                    if ((element.Required && element.IsActive) && ((ComboBox)control).SelectedIndex == -1)
                                    {
                                        staffErrorProvider.SetError(control, "This is a required field, kindly select an option");
                                        control.Focus();
                                        return result = false;
                                    }
                                }
                                else if (control is DateTimePicker)
                                {
                                    if ((element.Required && element.IsActive) && ((DateTimePicker)control).Value < DateTime.MinValue)
                                    {
                                        staffErrorProvider.SetError(control, "This is a required field, kindly select a valid date");
                                        control.Focus();
                                        return result = false;
                                    }
                                }
                                else if (control is NumericUpDown)
                                {
                                    if ((element.Required && element.IsActive) && ((NumericUpDown)control).Value < 0)
                                    {
                                        staffErrorProvider.SetError(control, "The value cannot be less than 1");
                                        control.Focus();
                                        return result = false;
                                    }
                                }
                                else if (control is MaskedTextBox)
                                {
                                    if ((element.Required && element.IsActive) && !((MaskedTextBox)control).MaskCompleted)
                                    {
                                        staffErrorProvider.SetError(control, "This is a required field, kindly fill it");
                                        control.Focus();
                                        return result = false;
                                    }
                                }
                                else if (control is DataGridView)
                                {
                                    foreach (DataGridViewRow row in ((DataGridView)control).Rows)
                                    {
                                        if (!row.IsNewRow)
                                        {
                                            List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
                                            //get visible (required columns only)
                                            foreach (DataGridViewColumn column in ((DataGridView)control).Columns)
                                            {
                                                if (column.Visible == true && column.ReadOnly == false)
                                                {
                                                    columns.Add(column);
                                                    if (row.Cells[column.Name].Value == null)
                                                    {
                                                        //tabOtherDetails.SelectedTab = dependentsTabPage;
                                                        ((DataGridView)control).Rows[row.Index + 1].Selected = true;
                                                        MessageBox.Show("Please enter a value on " + (row.Index + 1));
                                                        return result = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return result;
        }

        public static List<controlObject> CloneControls(List<Control> controls, Form form)
        {
            List<controlObject> oldControlValue = new List<controlObject>();
            try
            {
                if (controls.Count() < 1)
                {
                    GlobalData.FillControls(controls, form);
                }

                foreach (Control control in controls)
                {
                    controlObject obj = new controlObject();
                    obj.Name = control.Name;
                    if (control is DateTimePicker)
                    {
                        DateTime d;
                        var forma = DateTime.TryParseExact(control.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d);

                        if (forma)
                        {
                            obj.Value = DateTime.ParseExact(control.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            obj.Value = Convert.ToDateTime(control.Text).ToString();
                        }


                    }
                    else if (control is CheckBox)
                    {
                        obj.Value = ((CheckBox)control).Checked ? "True" : "False";
                    }
                    else if (control is ComboBox)
                    {
                        obj.Value = ((ComboBox)control).SelectedValue == null ? ((ComboBox)control).Text : ((ComboBox)control).SelectedValue.ToString();
                    }
                    //else if (control is DataGridView)
                    //{
                    //    foreach (DataGridViewColumn item in ((DataGridView)control).Columns)
                    //    {
                    //        obj.Value = item.
                    //    }
                    //}
                    else
                    {
                        obj.Value = control.Text;
                    }

                    oldControlValue.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return oldControlValue;
        }


        public static Permissions CheckPermissions(int accessLevel)
        {
            Permissions permissions = new Permissions();

            var getPermissions = new DataReference.UserAccessLevelsView();

            if (accessLevel == 2)
            {
                getPermissions = GlobalData._context.UserAccessLevelsViews.
                SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            }
            else if (accessLevel == 3)
            {
                getPermissions = GlobalData._context.UserAccessLevelsViews.
                SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            }
            else if (accessLevel == 4)
            {
                getPermissions = GlobalData._context.UserAccessLevelsViews.
                SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            }

            if (getPermissions != null)
            {
                permissions.CanDelete = getPermissions.CanDelete;
                permissions.CanEdit = getPermissions.CanEdit;
                permissions.CanAdd = getPermissions.CanAdd;
                permissions.CanPrint = getPermissions.CanPrint;
                permissions.CanView = getPermissions.CanView;
            }

            return permissions;

        }

        public static bool CheckIfAwaitingApproval(decimal datasetId, decimal changeID) 
        {
            var getRequest = GlobalData._context.StaffChangesRequests.
                Where(u => u.DatasetID == datasetId && u.ChangeID == changeID && u.Approved == false).ToList();
            if (getRequest.Count() > 0)
                return true;
            
            return false;
        }
    }
}