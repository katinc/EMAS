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
    public class StepDataMapper
    {
        private DALHelper dal;
        private Step step;

        public StepDataMapper()
        {
            this.dal = new DALHelper();
            this.step = new Step();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Step step = (Step)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", step.Description, DbType.String);
                dal.CreateParameter("@Active", step.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", step.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", step.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Step(Description,Active,UserID,Archived) Values(@Description,@Active,@UserID,@Archived)");
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
                Step step = (Step)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", step.ID, DbType.Int32);
                dal.CreateParameter("@Description", step.Description, DbType.String);
                dal.CreateParameter("@Active", step.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", step.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", step.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Step Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Step> GetAll()
        {
            IList<Step> steps = new List<Step>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", step.Archived, DbType.String);
                DataTable table = dal.ExecuteReader("select * From StepView WHERE StepView.Archived=@Archived order BY StepView.ID ASC");
                foreach (Step st in BuildStepFromData(table))
                {
                    steps.Add(st);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return steps;
        }
        #endregion

        #region GetByCriteria
        public IList<Step> GetByCriteria(Query query1)
        {
            IList<Step> steps = new List<Step>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", step.Archived, DbType.Boolean);
                string query = "select * from StepView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StepView.Archived=@Archived order BY StepView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Step st in BuildStepFromData(table))
                {
                    steps.Add(st);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return steps;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                Step step = (Step)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", step.ID, DbType.Int32);
                dal.CreateParameter("@Archived", true, DbType.Boolean);
                dal.CreateParameter("@Active", false, DbType.Boolean);

                dal.ExecuteNonQuery("Update Step Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region BuildStepFromData
        private IList<Step> BuildStepFromData(DataTable table)
        {
            IList<Step> steps = new List<Step>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Step step = new Step()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() }
                    };
                    steps.Add(step);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return steps;
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
