using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class TitlesDataMapper
    {
        private DALHelper dal;

        public TitlesDataMapper()
        {
            dal = new DALHelper();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Title title = (Title)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", title.Description, DbType.String);
                dal.CreateParameter("@GenderID", title.Gender.ID, DbType.Int32);
                dal.CreateParameter("@Active", title.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Titles (Description,GenderID,Active) Values(@Description,@GenderID,@Active)");
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
                Title title = (Title)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", title.ID, DbType.Int32);
                dal.CreateParameter("@Description", title.Description, DbType.String);
                dal.CreateParameter("@GenderID", title.Gender.ID, DbType.Int32);
                dal.CreateParameter("@Active", title.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Titles Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public IList<Title> GetAll()
        {
            IList<Title> titles = new List<Title>();
            try
            {
                DataTable table = dal.ExecuteReader("Select TitleView.* From TitleView Where Archived='False'");

                foreach (Title tit in BuildTitleFromData(table))
                {
                    titles.Add(tit);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return titles;
        }

        public Title GetByID(object key)
        {
            Title title = new Title();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", key.ToString(), DbType.String);
                DataTable table = dal.ExecuteReader("Select * from TitleView Where ID=@ID and Archived=@Archived");
                foreach (Title ti in BuildTitleFromData(table))
                {
                    title = ti;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return title;
        }

        #region GetByCriteria
        public IList<Title> GetByCriteria(Query query1)
        {
            IList<Title> titles = new List<Title>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from TitleView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  Archived='False' order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (Title tit in BuildTitleFromData(table))
                {
                    titles.Add(tit);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return titles;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Title title = (Title)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", title.ID, DbType.Int32);
                dal.CreateParameter("@Archived", title.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Titles Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion
        private IList<Title> BuildTitleFromData(DataTable table)
        {
            IList<Title> titles = new List<Title>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Title title = new Title()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Gender = new GenderGroup() { ID = int.Parse(row["GenderID"].ToString()), Description = row["Gender"].ToString() },
                        User = new User() { ID = int.Parse(row["UserID"].ToString())},
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    titles.Add(title);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return titles;
        }
    }
}
