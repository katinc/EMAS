using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class LoansDataMapper
    {
        private DALHelper dal;

        public LoansDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
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
                Loan loansSetup = (Loan)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", loansSetup.Description, DbType.String);
                dal.CreateParameter("@TypeID", loansSetup.Type.ID, DbType.Int32);
                dal.CreateParameter("@Active", loansSetup.Inactive, DbType.Boolean);
                dal.CreateParameter("@UserID", loansSetup.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO Loans_Setup (Description,TypeID,Active,UserID) Values(@Description,@TypeID,@Active,@UserID)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UPDATE
        public void Update(object item)
        {
            try
            {
                Loan loansSetup = (Loan)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID",loansSetup.ID, DbType.Int32);
                dal.CreateParameter("@Description",loansSetup.Description, DbType.String);
                dal.CreateParameter("@TypeID",loansSetup.Type.ID, DbType.Int32);
                dal.CreateParameter("@Active",loansSetup.Inactive, DbType.Boolean);
                dal.CreateParameter("@UserID", loansSetup.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE Loans_Setup Set Description=@Description,Active=@Active,TypeID=@TypeID,UserID=@UserID Where LID = @ID ");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<Loan> GetAll()
        {
            IList<Loan> loans = new List<Loan>();
            try
            {
                DataTable table = dal.ExecuteReader("select * From Loan_SetupView Where Archived='False'");
                foreach (Loan L in BuildLoanFromData(table))
                {
                    loans.Add(L);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return loans;
        }
        #endregion

        #region GetByCriteria
        public IList<Loan> GetByCriteria(Query query1)
        {
            IList<Loan> loans = new List<Loan>();
            try
            {
                DataTable table = new DataTable();
                string query = "select * from Loan_SetupView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "where Archived='False' order BY Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Loan L in BuildLoanFromData(table))
                {
                    loans.Add(L);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return loans;
        }
        #endregion

        private IList<Loan> BuildLoanFromData(DataTable table)
        {
            IList<Loan> loans = new List<Loan>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Loan loan = new Loan()
                    {
                        ID = int.Parse(row["LID"].ToString()),
                        Description = row["Description"].ToString(),
                        Inactive = bool.Parse(row["Active"].ToString()),
                        Type = new LoanType() { ID = int.Parse(row["LoanTypeID"].ToString()), Description = row["LoanType"].ToString() },
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    loans.Add(loan);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return loans;
        }


        #region DELETE
        public void Delete(object item)
        {
            try
            {
                Loan loan = (Loan)item;
                dal.ExecuteNonQuery("Update Loans_Setup Set Archived ='True' Where LID = "+ loan.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region OpenConnection
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

        #region CloseConnection
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
