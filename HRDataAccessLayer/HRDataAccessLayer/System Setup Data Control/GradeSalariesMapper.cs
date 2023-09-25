using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class GradeSalariesMapper
    {

        private DALHelper dal;
        private GradeSalaries salary;

        public GradeSalariesMapper()
        {
            this.dal = new DALHelper();
            this.salary = new GradeSalaries();
        }

        #region SAVE
        public void Save(GradeSalaries gradeSalaries)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@CategoryID", gradeSalaries.CategoryID, DbType.Int32);
                dal.CreateParameter("@GradeID", gradeSalaries.GradeID, DbType.Int32);
                dal.CreateParameter("@Step", gradeSalaries.Step, DbType.Int32);
                dal.CreateParameter("@BasicSalary", gradeSalaries.BasicSalary, DbType.Double);
                dal.CreateParameter("@HourlyRate", gradeSalaries.HourlyRate, DbType.Double);
                dal.CreateParameter("@UserID", gradeSalaries.UserID, DbType.Double);

                dal.ExecuteNonQuery("Insert Into GradeSalaries(CategoryID,GradeID,Step,BasicSalary,HourlyRate,UserID) Values(@CategoryID,@GradeID,@Step,@BasicSalary,@HourlyRate,@UserID)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(GradeSalaries gradeSalaries)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@CategoryID", gradeSalaries.CategoryID, DbType.Int32);
                dal.CreateParameter("@GradeID", gradeSalaries.GradeID, DbType.Int32);
                dal.CreateParameter("@Step", gradeSalaries.Step, DbType.Int32);
                dal.CreateParameter("@BasicSalary", gradeSalaries.BasicSalary, DbType.Double);
                dal.CreateParameter("@HourlyRate", gradeSalaries.HourlyRate, DbType.Double);               
                dal.CreateParameter("@UserID", gradeSalaries.UserID, DbType.Double);

                dal.ExecuteNonQuery("Update GradeSalaries Set BasicSalary=@BasicSalary,HourlyRate=@HourlyRate,UserID=@UserID where CategoryID=@CategoryID and GradeID=@GradeID and Step=@Step");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get 1

        public GradeSalaries  getSalary(int CategoryID, int GradeID, int Step)
        {
            GradeSalaries gradesalary = null;
            dal.ClearParameters();
            dal.CreateParameter("@CategoryID", CategoryID, DbType.Int32);
            dal.CreateParameter("@GradeID", GradeID, DbType.Int32);
            dal.CreateParameter("@Step", Step, DbType.Int32);
           

            DataTable tbl= dal.ExecuteReader("Select * from GradeSalaries Where CategoryID = @CategoryID and GradeID = @GradeID and Step=@Step");
            if (tbl.Rows.Count > 0)
            {
                DataRow row = tbl.Rows[0];
                gradesalary = new GradeSalaries() { CategoryID = int.Parse(row["CategoryID"].ToString()),
                                                    GradeID = int.Parse(row["GradeID"].ToString()),
                                                    Step = int.Parse(row["Step"].ToString()),
                                                    BasicSalary = Convert.ToDouble(row["BasicSalary"]),
                                                    HourlyRate = Convert.ToDouble(row["HourlyRate"])
                };
            }

            return gradesalary;
        }

        /*public IList<GradeSalaries> GetAll()
        {
            IList<GradeSalaries> gradeSalaries = new List<GradeSalaries>();
            try
            {
                dal.ClearParameters();
                DataTable table = dal.ExecuteReader("select * from GradeSalaries");
                foreach (DataRow row in table.Rows)
                {
                    countries.Add(new GradeSalaries() { ID = int.Parse(row["ID"].ToString()), Description = row["Description"].ToString(), Active = bool.Parse(row["Active"].ToString()) });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return countries;
        }
         * */
        #endregion

        #region DELETE

       /* public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", true, DbType.Boolean);
                dal.CreateParameter("@Active", false, DbType.Boolean);

                dal.ExecuteNonQuery("Update Countries Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

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
