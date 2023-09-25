using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class RefereesDataMapper
    {
        private DALHelper dal;
        private Referee referee;

        public RefereesDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.referee = new Referee();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        public IList<Referee> GetAll()
        {
            IList<Referee> referees = new List<Referee>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * from StaffRefereeView Where StaffRefereeView.Archived='False'");
                foreach (Referee refe in BuildRefereeFromData(table))
                {
                    referees.Add(refe);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return referees;
        }

        public Referee GetByID(object key)
        {
            IList<Referee> referees = new List<Referee>();
            Referee referee = new Referee();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                DataTable table = dal.ExecuteReader("Select * from StaffRefereeView Where StaffRefereeView.StaffID=@StaffID and StaffRefereeView.Archived=@Archived");
                
                foreach (Referee wk in BuildRefereeFromData(table))
                {
                    referee = wk;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return referee;
        }

        #region GetByCriteria
        public IList<Referee> GetByCriteria(Query query1)
        {
            IList<Referee> referees = new List<Referee>();
            Referee referee = new Referee();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", referee.Archived, DbType.Boolean);
                string query = "select * from StaffRefereeView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffRefereeView.Archived=@Archived order BY StaffRefereeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Referee refer in BuildRefereeFromData(table))
                {
                    referees.Add(refer);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return referees;
        }
        #endregion

        private IList<Referee> BuildRefereeFromData(DataTable table)
        {
            IList<Referee> referees = new List<Referee>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Referee referee = new Referee()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Name = row["Name"].ToString(),
                        Address = row["Address"].ToString(),
                        Occupation = row["Occupation"].ToString(),
                        TelNo = row["TelNumber"] == DBNull.Value ? null : row["TelNumber"].ToString(),
                        Email = row["Email"] == DBNull.Value ? null : row["Email"].ToString(),
                        DateAndTimeGenerated = DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                        },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    };
                    referees.Add(referee);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return referees;
        }

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                Referee referee = (Referee)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", referee.ID, DbType.Int32);
                dal.CreateParameter("@Archived", referee.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update StaffReferees Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
