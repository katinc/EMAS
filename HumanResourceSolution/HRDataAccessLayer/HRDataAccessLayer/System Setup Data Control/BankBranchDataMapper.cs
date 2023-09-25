using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using System.ComponentModel;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class BankBranchDataMapper
    {
        private DALHelper dal;
        private BankBranch bankBranch;

        public BankBranchDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.bankBranch = new BankBranch();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                BankBranch bankBranch = (BankBranch)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", bankBranch.Code, DbType.String);
                dal.CreateParameter("@Description", bankBranch.Description, DbType.String);
                dal.CreateParameter("@BankID", bankBranch.Bank.ID, DbType.Int32);
                dal.CreateParameter("@UserID", bankBranch.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", bankBranch.Active, DbType.Boolean);
                
                dal.ExecuteNonQuery("Insert Into BankBranches(Code,Description,BankID,UserID,Active) Values(@Code,@Description,@BankID,@UserID,@Active)");
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
                BankBranch bankBranch = (BankBranch)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", bankBranch.ID, DbType.Int32);
                dal.CreateParameter("@Code", bankBranch.Code, DbType.String);
                dal.CreateParameter("@Description", bankBranch.Description, DbType.String);
                dal.CreateParameter("@BankID", bankBranch.Bank.ID, DbType.Int32);
                dal.CreateParameter("@UserID", bankBranch.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", bankBranch.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", bankBranch.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update BankBranches Set Code=@Code,UserID=@UserID,Description=@Description,BankID=@BankID,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<BankBranch> GetAll()
        {
            IList<BankBranch> bankBranches = new List<BankBranch>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", bankBranch.Archived, DbType.String);
                string query = "select BankBranchView.*,BankView.Description as Bank,BankView.Code as BankCode from BankBranchView ";
                query += "left outer join BankView on BankView.id=BankBranchView.BankID ";
                query += "WHERE BankBranchView.Archived=@Archived order BY BankBranchView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    bankBranches.Add(new BankBranch() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        Code=row["Code"].ToString(),
                        Description = row["Description"].ToString(), 
                        Bank=new Bank(){ID=int.Parse(row["BankID"].ToString()),Description=row["Bank"].ToString(),Code=row["BankCode"].ToString()},
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString()},
                        Active = bool.Parse(row["Active"].ToString()) ,
                        Archived = bool.Parse(row["Archived"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return bankBranches;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                BankBranch bankBranch = (BankBranch)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", bankBranch.ID, DbType.Int32);
                dal.CreateParameter("@Archived", bankBranch.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", bankBranch.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update BankBranches Set Active=@Active,Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<BankBranch> GetByCriteria(Query query1)
        {
            IList<BankBranch> bankBranches = new List<BankBranch>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", bankBranch.Archived, DbType.Boolean);
                string query = "select BankBranchView.*,BankView.Description as Bank,BankView.Code as BankCode from BankBranchView ";
                query += "left outer join BankView on BankView.id=BankBranchView.BankID ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  BankBranchView.Archived=@Archived order BY BankBranchView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (BankBranch bankB in BuildBankBranchFromData(table))
                {
                    bankBranches.Add(bankB);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return bankBranches;
        }
        #endregion

        #region BuildBankBranchFromData
        private IList<BankBranch> BuildBankBranchFromData(DataTable table)
        {
            IList<BankBranch> bankBranches = new List<BankBranch>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    BankBranch bankBranch = new BankBranch()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Bank = new Bank() 
                        { 
                            ID = int.Parse(row["BankID"].ToString()), 
                            Description = row["Bank"].ToString(), 
                            Code = row["BankCode"].ToString() 
                        },
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    bankBranches.Add(bankBranch);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return bankBranches;
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
