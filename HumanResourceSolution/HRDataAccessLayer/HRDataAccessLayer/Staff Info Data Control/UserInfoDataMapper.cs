using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class UserInfoDataMapper 
    {
        private DALHelper dal;
        private IDAL idal;
        private IList<UserInfo> userInfos;
        private UserInfo userInfo;


        public UserInfoDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.idal = new DAL();
                this.userInfos = new List<UserInfo>();
                this.userInfo = new UserInfo();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Save
        public void Save(object item)
        {
            UserInfo userInfo = (UserInfo)item;
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@USERID", userInfo.USERID, DbType.Int32);
                dal.CreateParameter("@StaffPersonalInfoID", userInfo.Employee.ID, DbType.Int32);
                dal.CreateParameter("@BADGENUMBER", userInfo.BADGENUMBER, DbType.String);
                dal.CreateParameter("@SSN", userInfo.SSN, DbType.String);
                dal.CreateParameter("@NAME", userInfo.NAME, DbType.String);
                dal.CreateParameter("@GENDER", userInfo.GENDER, DbType.String);
                dal.CreateParameter("@TITLE", userInfo.Title.Description, DbType.String);
                dal.CreateParameter("@PAGER", userInfo.PAGER, DbType.String);
                dal.CreateParameter("@BIRTHDAY", userInfo.BIRTHDATE, DbType.DateTime);
                dal.CreateParameter("@HIREDDAY", userInfo.HIREDDAY, DbType.DateTime);
                dal.CreateParameter("@STREET", userInfo.STREET, DbType.String);
                dal.CreateParameter("@CITY", userInfo.CITY, DbType.String);
                dal.CreateParameter("@STATE", userInfo.STATE, DbType.String);
                dal.CreateParameter("@ZIP", userInfo.ZIP, DbType.String);
                dal.CreateParameter("@OPHONE", userInfo.OPHONE, DbType.String);
                dal.CreateParameter("@FPHONE", userInfo.FPHONE, DbType.String);
                dal.CreateParameter("@VERIFICATIONMETHOD", userInfo.VERIFICATIONMETHOD, DbType.Int32);
                dal.CreateParameter("@DEFAULTDEPTID", userInfo.Department.ID, DbType.Int32);
                dal.CreateParameter("@SECURITYFLAGS", userInfo.SECURITYFLAGS, DbType.Int32);
                dal.CreateParameter("@ATT", userInfo.ATT, DbType.Int32);
                dal.CreateParameter("@INLATE", userInfo.INLATE, DbType.Int32);
                dal.CreateParameter("@OUTEARLY", userInfo.OUTEARLY, DbType.Int32);
                dal.CreateParameter("@OVERTIME", userInfo.OVERTIME, DbType.Int32);
                dal.CreateParameter("@SEP", userInfo.SEP, DbType.Int32);
                dal.CreateParameter("@HOLIDAY", userInfo.HOLIDAY, DbType.Int32);

                dal.CreateParameter("@MINZU", userInfo.MINZU, DbType.String);
                dal.CreateParameter("@PASSWORD", userInfo.PASSWORD, DbType.String);
                dal.CreateParameter("@LUNCHDURATION", userInfo.LUNCHDURATION, DbType.Int32);
                dal.CreateParameter("@MVerifyPass", userInfo.MVerifyPass, DbType.String);
                dal.CreateParameter("@PHOTO", userInfo.PHOTO, DbType.Binary);
                dal.CreateParameter("@Notes", userInfo.Notes, DbType.Binary);
                dal.CreateParameter("@privilge", userInfo.Privilege, DbType.Int32);
                dal.CreateParameter("@InheritDeptSch", userInfo.InheritDeptSch, DbType.Int32);
                dal.CreateParameter("@InheritDeptSchClass", userInfo.InheritDeptSchClass, DbType.Int32);
                dal.CreateParameter("@AutoSchPlan", userInfo.AutoSchPlan, DbType.Int32);
                dal.CreateParameter("@MinAutoSchInterval", userInfo.MinAutoSchInterval, DbType.Int32);
                dal.CreateParameter("@RegisterOT", userInfo.RegisterOT, DbType.Int32);
                dal.CreateParameter("@InheritDeptRule", userInfo.InheritDeptRule, DbType.Int32);
                dal.CreateParameter("@EMPPRIVILEGE", userInfo.EMPRIVILEGE, DbType.Int32);
                dal.CreateParameter("@CardNo", userInfo.CardNo, DbType.String);

                dal.ExecuteNonQuery("Insert Into USERINFO(USERID,StaffPersonalInfoID,BADGENUMBER,SSN,NAME,GENDER,TITLE,PAGER,BIRTHDAY,HIREDDAY,STREET,CITY,STATE,ZIP,OPHONE,FPHONE,VERIFICATIONMETHOD,DEFAULTDEPTID,SECURITYFLAGS,ATT,INLATE,OUTEARLY,OVERTIME,SEP,HOLIDAY,MINZU,PASSWORD,LUNCHDURATION,MVerifyPass,PHOTO,Notes,privilege,InheritDeptSch,InheritDeptSchClass,AutoSchPlan,MinAutoSchInterval,RegisterOT,InheritDeptRule,EMPRIVILEGE,CardNo) Values(@USERID,@StaffPersonalInfoID,@BADGENUMBER,@SSN,@NAME,@GENDER,@TITLE,@PAGER,@BIRTHDAY,@HIREDDAY,@STREET,@CITY,@STATE,@ZIP,@OPHONE,@FPHONE,@VERIFICATIONMETHOD,@DEFAULTDEPTID,@SECURITYFLAGS,@ATT,@INLATE,@OUTEARLY,@OVERTIME,@SEP,@HOLIDAY,@MINZU,@PASSWORD,@LUNCHDURATION,@MVerifyPass,@PHOTO,@Notes,@Privilege,@InheritDeptSch,@InheritDeptSchClass,@AutoSchPlan,@MinAutoSchInterval,@RegisterOT,@InheritDeptRule,@EMPRIVILEGE,@CardNo)");
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region UPDATE
        public void Update(object item)
        {
            UserInfo userInfo = (UserInfo)item;
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@USERID", userInfo.USERID, DbType.Int32);
                dal.CreateParameter("@StaffPersonalInfoID", userInfo.Employee.ID, DbType.Int32);
                dal.CreateParameter("@BADGENUMBER", userInfo.BADGENUMBER, DbType.String);
                dal.CreateParameter("@SSN", userInfo.SSN, DbType.String);
                dal.CreateParameter("@NAME", userInfo.NAME, DbType.String);
                dal.CreateParameter("@GENDER", userInfo.GENDER, DbType.String);
                dal.CreateParameter("@TITLE", userInfo.Title.Description, DbType.String);
                dal.CreateParameter("@PAGER", userInfo.PAGER, DbType.String);
                dal.CreateParameter("@BIRTHDAY", userInfo.BIRTHDATE, DbType.DateTime);
                dal.CreateParameter("@HIREDDAY", userInfo.HIREDDAY, DbType.DateTime);
                dal.CreateParameter("@STREET", userInfo.STREET, DbType.String);
                dal.CreateParameter("@CITY", userInfo.CITY, DbType.String);
                dal.CreateParameter("@STATE", userInfo.STATE, DbType.String);
                dal.CreateParameter("@ZIP", userInfo.ZIP, DbType.String);
                dal.CreateParameter("@OPHONE", userInfo.OPHONE, DbType.String);
                dal.CreateParameter("@FPHONE", userInfo.FPHONE, DbType.String);
                dal.CreateParameter("@VERIFICATIONMETHOD", userInfo.VERIFICATIONMETHOD, DbType.Int32);
                dal.CreateParameter("@DEFAULTDEPTID", userInfo.Department.ID, DbType.Int32);
                dal.CreateParameter("@SECURITYFLAGS", userInfo.SECURITYFLAGS, DbType.Int32);
                dal.CreateParameter("@ATT", userInfo.ATT, DbType.Int32);
                dal.CreateParameter("@INLATE", userInfo.INLATE, DbType.Int32);
                dal.CreateParameter("@OUTEARLY", userInfo.OUTEARLY, DbType.Int32);
                dal.CreateParameter("@OVERTIME", userInfo.OVERTIME, DbType.Int32);
                dal.CreateParameter("@SEP", userInfo.SEP, DbType.Int32);
                dal.CreateParameter("@HOLIDAY", userInfo.HOLIDAY, DbType.Int32);

                dal.CreateParameter("@MINZU", userInfo.MINZU, DbType.String);
                dal.CreateParameter("@PASSWORD", userInfo.PASSWORD, DbType.String);
                dal.CreateParameter("@LUNCHDURATION", userInfo.LUNCHDURATION, DbType.Int32);
                dal.CreateParameter("@MVerifyPass", userInfo.MVerifyPass, DbType.String);
                dal.CreateParameter("@PHOTO", userInfo.PHOTO, DbType.Binary);
                dal.CreateParameter("@Notes", userInfo.Notes, DbType.Binary);
                dal.CreateParameter("@privilge", userInfo.Privilege, DbType.Int32);
                dal.CreateParameter("@InheritDeptSch", userInfo.InheritDeptSch, DbType.Int32);
                dal.CreateParameter("@InheritDeptSchClass", userInfo.InheritDeptSchClass, DbType.Int32);
                dal.CreateParameter("@AutoSchPlan", userInfo.AutoSchPlan, DbType.Int32);
                dal.CreateParameter("@MinAutoSchInterval", userInfo.MinAutoSchInterval, DbType.Int32);
                dal.CreateParameter("@RegisterOT", userInfo.RegisterOT, DbType.Int32);
                dal.CreateParameter("@InheritDeptRule", userInfo.InheritDeptRule, DbType.Int32);
                dal.CreateParameter("@EMPPRIVILEGE", userInfo.EMPRIVILEGE, DbType.Int32);
                dal.CreateParameter("@CardNo", userInfo.CardNo, DbType.String);

                dal.ExecuteNonQuery("Update USERINFO Set USERID=@USERID,StaffPersonalInfoID=@StaffPersonalInfoID,BADGENUMBER=@BADGENUMBER,SSN=@SSN,NAME=@NAME,GENDER=@GENDER,TITLE=@TITLE,PAGER=@PAGER,BIRTHDAY=@BIRTHDAY,HIREDDAY=@HIREDDAY,STREET=@STREET,CITY=@CITY,STATE=@STATE,ZIP=@ZIP,OPHONE=@OPHONE,FPHONE=@FPHONE,VERIFICATIONMETHOD=@VERIFICATIONMETHOD,DEFAULTDEPTID=@DEFAULTDEPTID,SECURITYFLAGS = @SECURITYFLAGS, ATT= @ATT,INLATE=@INLATE,OUTEARLY=@OUTEARLY,OVERTIME=@OVERTIME,SEP=@SEP,HOLIDAY=@HOLIDAY,MINZU=@MINZU,PASSWORD=@PASSWORD,LUNCHDURATION=@LUNCHDURATION,MVerifyPass=@MVerifyPass,PHOTO=@PHOTO,Notes=@Notes,privilege=@Privilege,InheritDeptSch=@InheritDeptSch,InheritDeptSchClass=@InheritDeptSchClass,AutoSchPlan=@AutoSchPlan,MinAutoSchInterval=@MinAutoSchInterval,RegisterOT=@RegisterOT,InheritDeptRule=@InheritDeptRule,EMPRIVILEGE=@EMPRIVILEGE,CardNo=@CardNo Where USERID=@USERID");        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        #endregion

        #region GetAll
        public IList<UserInfo> GetAll()
        {
            IList<UserInfo> userInfos = new List<UserInfo>();
            string query = "Select * from USERINFOView where Archived='False'";
            DataTable table = dal.ExecuteReader(query);

            foreach (UserInfo userInfo in BuildUserInfoFromData(table))
            {
                userInfos.Add(userInfo);
            }
            return userInfos;
        }
        #endregion

        #region GetByCriteria
        public IList<Employee> GetByCriteria(Query query1)
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from USERINFOView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Order By USERINFOView.NAME ";
                table = dal.ExecuteReader(selectStatement);
                foreach (UserInfo userIn in BuildUserInfoFromData(table))
                {
                    userInfos.Add(userIn);
                }
            }
            catch(Exception ex)
            {
                string str = ex.Message;
            }
            return employees;
        }
        #endregion
       
        #region Delete
        public void Delete(object item)
        {
            Employee employee = (Employee) item;
            try
            {
                dal.ExecuteNonQuery("Update USERINFO Set Archived = 'True' Where StaffPersonalInfoID ='" + employee.ID + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BuildUserInfoFromData
        private IList<UserInfo> BuildUserInfoFromData(DataTable table)
        {
            IList<UserInfo> userInfos = new List<UserInfo>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    UserInfo userInfo = new UserInfo()
                    {
                        //Personal Info
                        USERID = int.Parse(row["USERID"].ToString()),
                        Employee = new Employee() 
                        {
                            ID = row["ID"] == DBNull.Value ? 0 : int.Parse(row["ID"].ToString()),
                            StaffID = row["StaffID"] == DBNull.Value ? null : row["StaffID"].ToString() 
                        },
                        BADGENUMBER = row["BADGENUMBER"] == DBNull.Value ? null : row["BADGENUMBER"].ToString(),
                        SSN = row["SSN"] == DBNull.Value ? null : row["SSN"].ToString(),
                        NAME = row["NAME"] == DBNull.Value ? null : row["NAME"].ToString(),
                        GENDER = (GenderGroups)Enum.Parse(typeof(GenderGroups), row["GENDER"].ToString()),
                        Title = new Title() { Description = row["TITLE"] == DBNull.Value ? null : row["TITLE"].ToString() },
                        PAGER = row["PAGER"] == DBNull.Value ? null : row["PAGER"].ToString(),
                        BIRTHDATE = row["BIRTHDATE"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["BIRTHDATE"].ToString()),
                        HIREDDAY = row["HIREDDAY"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["HIREDDAY"].ToString()),
                        STREET = row["STREET"] == DBNull.Value ? null : row["STREET"].ToString(),
                        CITY = row["CITY"] == DBNull.Value ? null : row["CITY"].ToString(),
                        STATE = row["STATE"] == DBNull.Value ? null : row["STATE"].ToString(),

                        ZIP = row["ZIP"] == DBNull.Value ? null : row["ZIP"].ToString(),
                        OPHONE = row["OPHONE"] == DBNull.Value ? null : row["OPHONE"].ToString(),
                        FPHONE = row["FPHONE"] == DBNull.Value ? null : row["FPHONE"].ToString(),

                        VERIFICATIONMETHOD = row["VERIFICATIONMETHOD"] == DBNull.Value ? 0 : int.Parse(row["VERIFICATIONMETHOD"].ToString()),
                        Department = new Department() { ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), Description = row["Department"] == DBNull.Value ? null : row["Department"].ToString() },
                        SECURITYFLAGS = row["SECURITYFLAGS"] == DBNull.Value ? 0 : int.Parse(row["SECURITYFLAGS"].ToString()),
                        ATT = row["ATT"] == DBNull.Value ? 0 : int.Parse(row["ATT"].ToString()),
                        INLATE = row["INLATE"] == DBNull.Value ? 0 : int.Parse(row["INLATE"].ToString()),
                        OUTEARLY = row["OUTEARLY"] == DBNull.Value ? 0 : int.Parse(row["OUTEARLY"].ToString()),
                        OVERTIME = row["OVERTIME"] == DBNull.Value ? 0 : int.Parse(row["OVERTIME"].ToString()),
                        SEP = row["SEP"] == DBNull.Value ? 0 : int.Parse(row["SEP"].ToString()),
                        HOLIDAY = row["HOLIDAY"] == DBNull.Value ? 0 : int.Parse(row["HOLIDAY"].ToString()),
                        MINZU = row["MINZU"] == DBNull.Value ? null : row["MINZU"].ToString(),
                        PASSWORD = row["PASSWORD"] == DBNull.Value ? null : row["PASSWORD"].ToString(),
                        LUNCHDURATION = row["LUNCHDURATION"] == DBNull.Value ? 0 : int.Parse(row["LUNCHDURATION"].ToString()),
                        MVerifyPass = row["MVerifyPass"] == DBNull.Value ? null : row["MVerifyPass"].ToString(),
                        PHOTO = row["PHOTO"] is DBNull ? null : Global.ArrayToImage((byte[])row["PHOTO"]),
                        Notes = row["Notes"] is DBNull ? null : Global.ArrayToImage((byte[])row["Notes"]),
                        Privilege = row["OVERTIME"] == DBNull.Value ? 0 : int.Parse(row["OVERTIME"].ToString()),
                        InheritDeptSch = row["OVERTIME"] == DBNull.Value ? 0 : int.Parse(row["OVERTIME"].ToString()),
                        InheritDeptSchClass = row["OVERTIME"] == DBNull.Value ? 0 : int.Parse(row["OVERTIME"].ToString()),
                        AutoSchPlan = row["AutoSchPlan"] == DBNull.Value ? 0 : int.Parse(row["AutoSchPlan"].ToString()),
                        MinAutoSchInterval = row["MinAutoSchInterval"] == DBNull.Value ? 0 : int.Parse(row["MinAutoSchInterval"].ToString()),
                        RegisterOT = row["RegisterOT"] == DBNull.Value ? 0 : int.Parse(row["RegisterOT"].ToString()),
                        InheritDeptRule = row["InheritDeptRule"] == DBNull.Value ? 0 : int.Parse(row["InheritDeptRule"].ToString()),
                        EMPRIVILEGE = row["EMPRIVILEGE"] == DBNull.Value ? 0 : int.Parse(row["EMPRIVILEGE"].ToString()),
                        CardNo = row["CardNo"] == DBNull.Value ? null : row["CardNo"].ToString(),
                    };

                    userInfos.Add(userInfo);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userInfos;
        }
        #endregion

        #region LazyLoad
        public IList<Employee> LazyLoad()
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@TransferredOut", "False", DbType.String);
                dal.CreateParameter("@OnLeave", "False", DbType.String);
                dal.CreateParameter("@Terminated", "False", DbType.String);
                string query = "SELECT * From StaffPersonalInfoLazyLoadView ";
                query += "Where StaffPersonalInfoLazyLoadView.Terminated = @Terminated And StaffPersonalInfoLazyLoadView.OnLeave=@OnLeave And StaffPersonalInfoLazyLoadView.TransferredOut =@TransferredOut And StaffPersonalInfoLazyLoadView.Archived=@Archived ";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    Employee employee = new Employee()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        StaffID = row["StaffID"].ToString(),
                        Title = new Titles() { ID = row["TitleID"] == DBNull.Value ? 0 : int.Parse(row["TitleID"].ToString()), Description = row["Title"] == DBNull.Value ? null : row["Title"].ToString() },
                        Surname = row["Surname"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        OtherName = row["OtherName"].ToString(),
                        FingerPrint = row["FingerPrint"] is DBNull ? null : (byte[])row["FingerPrint"],
                        Terminated = bool.Parse(row["Terminated"].ToString()),
                        OnLeave = bool.Parse(row["OnLeave"].ToString()),
                        SSNITNo = row["SSNITNo"] == DBNull.Value ? null : row["SSNITNo"].ToString(),
                        TIN = row["TIN"] == DBNull.Value ? null : row["TIN"].ToString(),
                        TelNo = row["TelNo"] == DBNull.Value ? null : row["TelNo"].ToString(),
                        MobileNo = row["MobileNo"] == DBNull.Value ? null : row["MobileNo"].ToString(),
                        MaritalStatus = row["MaritalStatus"] == DBNull.Value ? null : row["MaritalStatus"].ToString(),
                        FileNumber = new FileNumber() { ID = row["FileNumberID"] == DBNull.Value ? 0 : int.Parse(row["FileNumberID"].ToString()), Description = row["FileNumber"] == DBNull.Value ? null : row["FileNumber"].ToString() },
                        PIN = row["PIN"] == DBNull.Value ? null : row["PIN"].ToString(),
                        MaidenName = row["MaidenName"] == DBNull.Value ? null : row["MaidenName"].ToString(),
                        GradeCategory = new GradeCategory() { ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()), Description = row["GradeCategory"] == DBNull.Value ? null : row["GradeCategory"].ToString() },
                        Grade = new EmployeeGrade() { ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()), Grade = row["Grade"] == DBNull.Value ? null : row["Grade"].ToString() },
                        Step = new Step() { ID = row["StepID"] == DBNull.Value ? 0 : int.Parse(row["StepID"].ToString()), Description = row["Step"] == DBNull.Value ? null : row["Step"].ToString() },
                        Band = new Band() { ID = row["BandID"] == DBNull.Value ? 0 : int.Parse(row["BandID"].ToString()), Description = row["Band"] == DBNull.Value ? null : row["Band"].ToString() },
                        BasicSalary = row["BasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["BasicSalary"].ToString()),
                        DOB = row["DOB"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString()),
                        Gender = row["Gender"] == DBNull.Value ? null : row["Gender"].ToString(),
                        Department = new Department() { ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), Description = row["Department"] == DBNull.Value ? null : row["Department"].ToString() },
                        Specialty = new Specialty() { ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()), Description = row["Specialty"] == DBNull.Value ? null : row["Specialty"].ToString() },
                        Unit = new Unit() { ID = row["Specialty"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()), Description = row["Unit"] == DBNull.Value ? null : row["Unit"].ToString() },
                        JobTitle = new JobTitle() { ID = row["JobTitleID"] == DBNull.Value ? 0 : int.Parse(row["JobTitleID"].ToString()), Description = row["JobTitle"] == DBNull.Value ? null : row["JobTitle"].ToString() },
                        OccupationGroup = new OccupationGroup() { ID = row["OccupationGroupID"] == DBNull.Value ? 0 : int.Parse(row["OccupationGroupID"].ToString()), Description = row["OccupationGroup"] == DBNull.Value ? null : row["OccupationGroup"].ToString() },
                        Photo = row["Image"] is DBNull ? null : Global.ArrayToImage((byte[])row["Image"]),
                    };
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employees;
        }
        #endregion
    }
}
