using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Data;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class LoanTypesDataMapper
    {
        private DALHelper dal;

        public LoanTypesDataMapper()
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

        public IList<LoanType> GetAll()
        {
            IList<LoanType> loanTypes = new List<LoanType>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From LoanTypeView");
                foreach (DataRow row in table.Rows)
                {
                    loanTypes.Add(new LoanType() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        Description = row["Description"].ToString() 
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return loanTypes;
        }
    }
}
