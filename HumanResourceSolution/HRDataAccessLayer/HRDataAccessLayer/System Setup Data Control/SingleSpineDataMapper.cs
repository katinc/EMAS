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

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class SingleSpineDataMapper
    {
        private DALHelper dal;
        private SingleSpine singleSpine;

        public SingleSpineDataMapper()
        {
            dal = new DALHelper();
            singleSpine = new SingleSpine();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                SingleSpine singleSpine = (SingleSpine)item;
                dal.ClearParameters();
                dal.CreateParameter("@GradeCategoryID", singleSpine.GradeCategory.ID, DbType.String);
                dal.CreateParameter("@EmployeeGradeID", singleSpine.EmployeeGrade.ID, DbType.String);
                dal.CreateParameter("@SalaryLevelID", singleSpine.SalaryLevel.ID, DbType.Int32);
                dal.CreateParameter("@BandID", singleSpine.Band.ID, DbType.Int32);
                dal.CreateParameter("@StepID", singleSpine.Step.ID, DbType.Int32);
                dal.CreateParameter("@UserID", singleSpine.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", singleSpine.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into SingleSpineSalary(GradeCategoryID,EmployeeGradeID,SalaryLevelID,BandID,StepID,UserID,Archived) Values(@GradeCategoryID,@EmployeeGradeID,@SalaryLevelID,@BandID,@StepID,@UserID,@Archived)");
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
            try
            {
                SingleSpine singleSpine = (SingleSpine)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", singleSpine.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryID", singleSpine.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@EmployeeGradeID", singleSpine.EmployeeGrade.ID, DbType.Int32);
                dal.CreateParameter("@SalaryLevelID", singleSpine.SalaryLevel.ID, DbType.Int32);
                dal.CreateParameter("@BandID", singleSpine.Band.ID, DbType.Int32);
                dal.CreateParameter("@StepID", singleSpine.Step.ID, DbType.Int32);
                dal.CreateParameter("@UserID", singleSpine.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", singleSpine.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update SingleSpineSalary Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<SingleSpine> GetAll()
        {
            IList<SingleSpine> singleSpines = new List<SingleSpine>();
            try
            {
                string query = "select SingleSpineSalaryView.* From SingleSpineSalaryView Where Archived='False'";
                DataTable table = dal.ExecuteReader(query);
                foreach (SingleSpine sing in BuildSingleSpineData(table))
                {
                    singleSpines.Add(sing);
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return singleSpines;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                SingleSpine singleSpine=(SingleSpine)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", singleSpine.ID, DbType.Int32);
                dal.CreateParameter("@Archived", singleSpine.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update SingleSpineSalary Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Salary Amount
        public SingleSpine GetSalaryAmount(object gradeCategoryID,object gradeID,object stepID)
        {
            dal.CreateParameter("@arch", "False", DbType.String);
            dal.CreateParameter("@gradeCatID", gradeCategoryID.ToString(), DbType.String);
            dal.CreateParameter("@gradID", gradeID.ToString(), DbType.String);
            dal.CreateParameter("@stpID", stepID.ToString(), DbType.String);
            string query = "select SingleSpineSalaryView.* From SingleSpineSalaryView ";
            query += "WHERE SingleSpineSalaryView.GradeID=@gradID AND SingleSpineSalaryView.GradeCategoryID=@gradeCatID AND SingleSpineSalaryView.StepID=@stpID and SingleSpineSalaryView.Archived=@Arch";
            
            DataTable table = dal.ExecuteReader(query);
            SingleSpine singleSpine = new SingleSpine();
            foreach (SingleSpine ss in BuildSingleSpineData(table))
            {
                singleSpine = ss;
            }
            return singleSpine;
        }
        #endregion

        #region GetByCriteria
        public IList<SingleSpine> GetByCriteria(Query query1)
        {
            IList<SingleSpine> singleSpines = new List<SingleSpine>();
            DataTable table = new DataTable();

            dal.ClearParameters();
            dal.CreateParameter("@Archived", false, DbType.Boolean);

            string query = "select SingleSpineSalaryView.* From SingleSpineSalaryView";
            string selectStatement = QueryTranslater.TranslateQuery(query, query1);
            selectStatement += "  SingleSpineSalaryView.Archived=@Archived";
            table = dal.ExecuteReader(selectStatement);
            foreach (SingleSpine sing in BuildSingleSpineData(table))
            {
                singleSpines.Add(sing);
            }
            return singleSpines;
        }
        #endregion

        #region BuildSingleSpineData
        private IList<SingleSpine> BuildSingleSpineData(DataTable table)
        {
            IList<SingleSpine> singleSpines = new List<SingleSpine>();
            foreach (DataRow row in table.Rows)
            {
                SingleSpine singleSpine = new SingleSpine()
                {
                    //Personal Info
                    ID = int.Parse(row["ID"].ToString()),
                    GradeCategory = new GradeCategory() { ID = int.Parse(row["GradeCategoryID"].ToString()), Description = row["GradeCategory"].ToString() },
                    EmployeeGrade = new EmployeeGrade() { ID = int.Parse(row["GradeID"].ToString()), Grade = row["Grade"].ToString()},
                    Step = new Step() { ID = int.Parse(row["StepID"].ToString()), Description = row["Step"].ToString() },
                    Band = new Band() { ID = int.Parse(row["BandID"].ToString()), Description = row["Band"].ToString() },
                    SalaryLevel = new Level() { ID = int.Parse(row["SalaryLevelID"].ToString()), Description = row["SalaryLevel"].ToString() },
                    BasicSalary = float.Parse(row["BasicSalary"].ToString()),
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                };
                singleSpines.Add(singleSpine);
            }
            return singleSpines;
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
