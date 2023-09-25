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
    class SponsorDataMapper
    {
        private DALHelper dal;
        private Sponsor sponsor;

        public SponsorDataMapper()
        {
            this.dal = new DALHelper();
            this.sponsor = new Sponsor();
        }

        #region Get All
        public IList<Sponsor> GetAll()
        {
            IList<Sponsor> sponsors = new List<Sponsor>();
            try
            {
                dal.ClearParameters();
                DataTable table = dal.ExecuteReader("select * from Sponsors order BY Description ASC");
                foreach (DataRow row in table.Rows)
                {
                    sponsors.Add(new Sponsor()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return sponsors;
        }
        #endregion
    }
}
