using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using System.Data;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class EmployeeBanksDataMapper
    {
        DALHelper dal;

        public EmployeeBanksDataMapper()
        {
            dal = new DALHelper();
        }

        #region Save
        public void Save(object item)
        {
            EmployeeBank employeeBank = (EmployeeBank)item;

            dal.ClearParameters();
            dal.CreateParameter("@StaffID", employeeBank.StaffID, DbType.String);
            dal.CreateParameter("@AccountName", employeeBank.AccountName, DbType.String);
            dal.CreateParameter("@AccountNumber", employeeBank.AccountNumber, DbType.String);
            dal.CreateParameter("@BankName", employeeBank.BankName, DbType.String);
            dal.CreateParameter("@Branch", employeeBank.Branch, DbType.String);
            dal.CreateParameter("@InUse", employeeBank.InUse, DbType.String);
            try
            {
                dal.ExecuteNonQuery("Insert Into StaffBanks (StaffID,AccountName,AccountNumber,BankName,InUse,Branch) Values(@StaffID,@AccountName,@AccountNumber,@BankName,@InUse,@Branch)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            EmployeeBank employeeBank = (EmployeeBank)item;

            dal.ClearParameters();
            dal.CreateParameter("@ID", employeeBank.ID, DbType.Int32);
            dal.CreateParameter("@StaffID", employeeBank.StaffID, DbType.String);
            dal.CreateParameter("@AccountName", employeeBank.AccountName, DbType.String);
            dal.CreateParameter("@AccountNumber", employeeBank.AccountNumber, DbType.String);
            dal.CreateParameter("@BankName", employeeBank.BankName, DbType.String);
            dal.CreateParameter("@Branch", employeeBank.Branch, DbType.String);
            dal.CreateParameter("@InUse", employeeBank.InUse, DbType.String);
            try
            {
                dal.ExecuteNonQuery("Update StaffBanks Set StaffID=@StaffID,AccountName=@AccountName,AccountNumber=@AccountNumber,BankName=@BankName,InUse=@InUse,Branch=@Branch Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
