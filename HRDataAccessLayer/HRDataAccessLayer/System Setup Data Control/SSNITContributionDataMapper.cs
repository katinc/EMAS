using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class SSNITContributionDataMapper
    {
        DALHelper dal;

        public SSNITContributionDataMapper()
        {
            dal = new DALHelper();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                SSNITContribution ssnitContribution = (SSNITContribution)item;
                dal.ClearParameters();
                dal.CreateParameter("@EmployerPercentage",ssnitContribution.EmployerPercentage, DbType.Decimal);
                dal.CreateParameter("@EmployeePercentage",ssnitContribution.EmployeePercentage, DbType.Decimal);
                dal.CreateParameter("@ExemptEmployerPercentage", ssnitContribution.ExemptEmployerPercentage, DbType.Decimal);
                dal.CreateParameter("@ExemptEmployeePercentage", ssnitContribution.ExemptEmployeePercentage, DbType.Decimal);
                dal.CreateParameter("@SSNITFirstTierRate",ssnitContribution.SSNITFirstTierRate, DbType.Decimal);
                dal.CreateParameter("@SecondTierRate",ssnitContribution.SecondTierRate, DbType.Decimal);
                dal.CreateParameter("@ProvidentFundEmployeeRate", ssnitContribution.ProvidentFundEmployeeRate, DbType.Decimal);
                dal.CreateParameter("@ProvidentFundEmployerRate", ssnitContribution.ProvidentFundEmployerRate, DbType.Decimal);
                dal.CreateParameter("@ExemptSSNITFirstTierRate", ssnitContribution.ExemptSSNITFirstTierRate, DbType.Decimal);
                if (dal.ExecuteReader("Select * from SSNITContribution").Rows.Count > 0)
                {
                    dal.ExecuteNonQuery("Update SSNITContribution Set ExemptSSNITFirstTierRate=@ExemptSSNITFirstTierRate,ExemptEmployeePercentage=@ExemptEmployeePercentage,ExemptEmployerPercentage=@ExemptEmployerPercentage,EmployerPercentage=@EmployerPercentage,EmployeePercentage=@EmployeePercentage,SSNITFirstTierRate=@SSNITFirstTierRate,SecondTierRate=@SecondTierRate,ProvidentFundEmployeeRate=@ProvidentFundEmployeeRate,ProvidentFundEmployerRate=@ProvidentFundEmployerRate");
                }
                else
                {
                    dal.ExecuteNonQuery("Insert Into SSNITContribution(ExemptSSNITFirstTierRate,ExemptEmployerPercentage,ExemptEmployeePercentage,EmployerPercentage,EmployeePercentage,SSNITFirstTierRate,SecondTierRate,ProvidentFundEmployeeRate,ProvidentFundEmployerRate ) Values(@ExemptSSNITFirstTierRate,@ExemptEmployerPercentage,@ExemptEmployeePercentage,@EmployerPercentage,@EmployeePercentage,@SSNITFirstTierRate,@SecondTierRate,@ProvidentFundEmployeeRate,@ProvidentFundEmployerRate)");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
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

        #region GetAll
        public IList<SSNITContribution> GetAll()
        {
            IList<SSNITContribution> ssnitContributions = new List<SSNITContribution>();
            try
            {
                DataTable ssnitTable = dal.ExecuteReader("Select Top(1) SSNITContribution.* From SSNITContribution");
                foreach (DataRow row in ssnitTable.Rows)
                {
                    ssnitContributions.Add(new SSNITContribution() 
                    { 
                        ID = int.Parse(row["SCID"].ToString()), 
                        EmployeePercentage = decimal.Parse(row["EmployeePercentage"].ToString()), 
                        EmployerPercentage = decimal.Parse(row["EmployerPercentage"].ToString()),
                        ExemptEmployeePercentage = decimal.Parse(row["ExemptEmployeePercentage"].ToString()),
                        ExemptEmployerPercentage = decimal.Parse(row["ExemptEmployerPercentage"].ToString()),
                        SSNITFirstTierRate = decimal.Parse(row["SSNITFirstTierRate"].ToString()),
                        SecondTierRate = decimal.Parse(row["SecondTierRate"].ToString()),
                        ProvidentFundEmployeeRate = decimal.Parse(row["ProvidentFundEmployeeRate"].ToString()),
                        ProvidentFundEmployerRate = decimal.Parse(row["ProvidentFundEmployerRate"].ToString()),
                        ExemptSSNITFirstTierRate = decimal.Parse(row["ExemptSSNITFirstTierRate"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return ssnitContributions;
        }
        #endregion
    }
}
