using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class UserDataMapper
    {
        private DALHelper dal;

        public UserDataMapper()
        {
            this.dal = new DALHelper();
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                User user = (User)item;
                dal.ClearParameters();
                dal.CreateParameter("@Password", user.Password, DbType.String);
                dal.CreateParameter("@UserCategoryID", user.UserCategory.ID, DbType.Int32);
                dal.CreateParameter("@AccountBlocked", user.AccountBlocked, DbType.Boolean);
                dal.CreateParameter("@UserName", user.UserName, DbType.String);
                dal.CreateParameter("@BarCode", user.BarCode, DbType.String);
                dal.CreateParameter("@EmpID", user.EmpID, DbType.Int32);
                dal.CreateParameter("@SecurityQuestion", user.SecurityQuestion, DbType.String);
                dal.CreateParameter("@SecurityAnswer", user.SecurityAnswer, DbType.String);
                dal.CreateParameter("@Name", user.Name, DbType.String);
                dal.CreateParameter("@StaffID", user.StaffID, DbType.String);
                dal.CreateParameter("@CreateUserID", user.CreateUserID, DbType.Int32);
                dal.CreateParameter("@UpdateUserID", user.UpdateUserID, DbType.Int32);
                if (user.FingerPrint != null)
                {
                    dal.CreateParameter("@FingerPrint", user.FingerPrint, DbType.Binary);
                }
                else
                {
                    dal.CreateParameter("@FingerPrint", DBNull.Value, DbType.Binary);
                }
                dal.ExecuteNonQuery("Insert Into Users (FingerPrint,Password,SecurityAnswer,SecurityQuestion,UserCategoryID,UserName,BarCode,EmpID,Name,StaffID,CreateUserID,UpdateUserID) Values(@FingerPrint,@Password,@SecurityAnswer,@SecurityQuestion,@UserCategoryID,@UserName,@BarCode,@EmpID,@Name,@StaffID,@CreateUserID,@UpdateUserID)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                User user = (User)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", user.ID, DbType.Int32);
                dal.CreateParameter("@Password", user.Password, DbType.String);
                dal.CreateParameter("@UserCategoryID", user.UserCategory.ID, DbType.Int32);
                dal.CreateParameter("@AccountBlocked", user.AccountBlocked, DbType.Boolean);
                dal.CreateParameter("@UserName", user.UserName, DbType.String);
                dal.CreateParameter("@BarCode", user.BarCode, DbType.String);
                dal.CreateParameter("@EmpID", user.EmpID, DbType.Int32);
                dal.CreateParameter("@SecurityQuestion", user.SecurityQuestion, DbType.String);
                dal.CreateParameter("@SecurityAnswer", user.SecurityAnswer, DbType.String);
                dal.CreateParameter("@Name", user.Name, DbType.String);
                dal.CreateParameter("@StaffID", user.StaffID, DbType.String);
                dal.CreateParameter("@CreateUserID", user.CreateUserID, DbType.Int32);
                dal.CreateParameter("@UpdateUserID", user.UpdateUserID, DbType.Int32);
                if (user.FingerPrint != null)
                {
                    dal.CreateParameter("@FingerPrint", user.FingerPrint, DbType.Binary);
                }
                else
                {
                    dal.CreateParameter("@FingerPrint", DBNull.Value, DbType.Binary);
                }
                dal.ExecuteNonQuery("Update Users Set Name=@Name,StaffID=@StaffID,CreateUserID=@CreateUserID,UpdateUserID=@UpdateUserID,Password=@Password,UserCategoryID=@UserCategoryID,AccountBlocked=@AccountBlocked,UserName=@UserName,BarCode=@BarCode,EmpID=@EmpID,SecurityQuestion=@SecurityQuestion,SecurityAnswer=@SecurityAnswer,FingerPrint=@FingerPrint Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<User> GetAll()
        {
            IList<User> users = new List<User>();
            try
            {
                DataTable usersTable = dal.ExecuteReader("Select UsersView.* From UsersView Where UsersView.AccountBlocked='False' and UsersView.Archived='False'");
                foreach (User use in BuildUserFromData(usersTable))
                {
                    users.Add(use);
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return users;
        }
        #endregion

        #region GetByCriteria
        public IList<User> GetByCriteria(Query query1)
        {
            IList<User> users = new List<User>();
            try
            {
                DataTable usersTable = new DataTable();
                string query = "Select * From UsersView";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "   UsersView.Archived='False' order BY UsersView.UserName ASC";
                usersTable = dal.ExecuteReader(selectStatement);
                foreach (User use in BuildUserFromData(usersTable))
                {
                    users.Add(use);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return users;
        }
        #endregion

        public void Delete(object item)
        {
            try
            {
                User user = (User)item;
                dal.ExecuteNonQuery("Update Users Set Archived = '" + user.Archived + "' ,ArchivedUserID ='" + user.ArchivedUserID + "',ArchivedTime ='" + user.ArchivedTime + "'   Where ID =" + user.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #region BuildUserFromData
        private IList<User> BuildUserFromData(DataTable table)
        {
            IList<User> users = new List<User>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    User user = new User()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        UserName = row["UserName"].ToString(),
                        Password = row["Password"].ToString(),
                        SecurityQuestion = row["SecurityQuestion"].ToString(),
                        SecurityAnswer = row["SecurityAnswer"].ToString(),
                        //FingerPrint = row["FingerPrint"] == DBNull.Value ? null : (byte[])row["FingerPrint"],
                        UserCategory = new UserCategory() 
                        {
                            ID = row["UserCategoryID"] == DBNull.Value ? 0 : int.Parse(row["UserCategoryID"].ToString()),
                            Description = row["UserCategory"] == DBNull.Value ? string.Empty : row["UserCategory"].ToString() 
                        },
                        BarCode = row["BarCode"].ToString(),
                        Email = row["Email"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        EmpID = int.Parse(row["EmpID"].ToString()),
                        AccountBlocked = bool.Parse(row["AccountBlocked"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return users;
        }
        #endregion

        #region Open Connection
        public void OpenConnection()
        {
            try
            {
                dal.OpenConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Close Connection
        public void CloseConnection()
        {
            try
            {
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion


    }
}
