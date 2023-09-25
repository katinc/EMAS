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

namespace eMAS
{
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
        private static string[] connectionParameters;
        private static User user;

        static GlobalData()
        {          
            try
            {
                dataAccessException = "A connection error occured please do the ff to troubleshoot:\n1. Make sure your network cable is plugged in properly.\n2. Ask your administrator to make sure the database service is running.";
                caption = "EMAS ";
                connectionParameters = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString.Split(';');
                connectionParameters[0] = connectionParameters[0].Remove(0, 12);
                connectionParameters[1] = connectionParameters[1].Remove(0,16);
                connectionParameters[2] = connectionParameters[2].Remove(0, 8);
                connectionParameters[3] = connectionParameters[3].Remove(0, 9);
                user=new User();
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

        public static  User User
        {
            get { return user; }
            set { user = value; }
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
            get { return connectionParameters[0];}
        }

        public static string DatabaseName
        {
            get {return connectionParameters[1];}
        }

        public static string UserID
        {
            get {return connectionParameters[2];}
        }

        public static string Password
        {
            get { return connectionParameters[3]; }
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

        public static void SetFormPermissions(Form f,IDAL dal,int userID)
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
            catch(Exception ex)
            {
                LogError(ex);
                throw ex;
            }
        }

        private static void ShowToolStipItems(ToolStripItemCollection toolStripItems, ToolStripItemCollection toolStripItems2, ControlToRole controlToRole, List<ControlToRole> parts)
        {
            try
            {
                ToolStripItem[] items;
                items = toolStripItems.Find(controlToRole.Controls.ControlID, true);
                if (items.Count() <= 0)
                {
                    foreach (ToolStripMenuItem mi in toolStripItems)
                    {
                        if (mi.DropDownItems.Count > 0)
                        {
                            ShowToolStipItems(mi.DropDownItems, toolStripItems2, controlToRole, parts);
                        }
                        items = mi.DropDownItems.Find(controlToRole.Controls.ControlID, true);
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
                        if (controlToRole.Controls.ControlID == item.Name)
                        {
                            if (parts.Exists(x => x.Controls.ControlID == item.Name))
                            {
                                var old = parts.Find(x => x.Controls.ControlID.Contains(item.Name));
                                var oldName = old.Controls.ControlID;
                                var oldInvisible = old.Invisible;
                                var oldDisabled = old.Disabled;
                                var newName = controlToRole.Controls.ControlID;
                                var newInvisible = controlToRole.Invisible;
                                var newDisabled = controlToRole.Disabled;
                                if (oldInvisible != newInvisible && oldInvisible == 1)
                                {
                                    item.Visible = newInvisible == 1 ? false : true;
                                }
                                else if (oldInvisible != newInvisible && newInvisible == 1)
                                {
                                    item.Visible = oldInvisible == 1 ? false : true;

                                }
                                if (oldDisabled != newDisabled && oldDisabled == 1)
                                {
                                    item.Enabled = newDisabled == 1 ? false : true;
                                }
                                else if (oldDisabled != newDisabled && newDisabled == 1)
                                {
                                    item.Enabled = oldDisabled == 1 ? false : true;
                                }
                                parts.Add(new ControlToRole() { Controls = new Controls { ControlID = controlToRole.Controls.ControlID }, Invisible = controlToRole.Invisible, Disabled = controlToRole.Disabled });
                            }
                            else
                            {
                                item.Visible = controlToRole.Invisible == 1 ? false : true;
                                item.Enabled = controlToRole.Disabled == 1 ? false : true;
                                parts.Add(new ControlToRole() { Controls = new Controls { ControlID = controlToRole.Controls.ControlID }, Invisible = controlToRole.Invisible, Disabled = controlToRole.Disabled });
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
                m=m2;
                IList<ControlToRole> controlToRoles = new List<ControlToRole>();
                List<ControlToRole> parts = new List<ControlToRole>();
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
                        if (m != null)
                        {
                            ShowToolStipItems(m,m2,controlToRole,parts);
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
            byte[] photoArray=null;
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
            catch(Exception ex)
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
                if (newMonth != string.Empty )
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

    }
}