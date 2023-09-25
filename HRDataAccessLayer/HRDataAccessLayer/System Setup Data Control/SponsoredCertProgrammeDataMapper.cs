using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
   public class SponsoredCertProgrammeDataMapper
    {
        private IList<SponsoredCertProgramme> lstSponsoredProgrammes;

        private DALHelper dalHelper;

        public SponsoredCertProgrammeDataMapper()
        {
            lstSponsoredProgrammes = new List<SponsoredCertProgramme>();
            dalHelper = new DALHelper();
            
        }
        public SponsoredCertProgramme getById(int Id)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Id", Id, DbType.Int32);

                DataTable dtSponsoredCertProgramme = dalHelper.ExecuteReader("select * from SponsoredCertProgrammesGroup where Id=@Id  order by programme");


                DataMapper(dtSponsoredCertProgramme);
            }
            catch (Exception ex) { }

            return lstSponsoredProgrammes.FirstOrDefault();
        }
        public IList<SponsoredCertProgramme> getData(bool active,bool archived)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@active", active, DbType.Boolean);
                dalHelper.CreateParameter("@archived", archived, DbType.Boolean);

                DataTable dtSponsoredCertProgramme = dalHelper.ExecuteReader("select * from SponsoredCertProgrammesGroup where active=@active and archived=@archived order by programme");


                DataMapper(dtSponsoredCertProgramme);
            }
            catch (Exception ex) { }
           
           return lstSponsoredProgrammes;
        }
        public IList<SponsoredCertProgramme> getData()
        {
            try
            {
                dalHelper.ClearParameters();
            

                DataTable dtSponsoredCertProgramme = dalHelper.ExecuteReader("select * from SponsoredCertProgrammesGroup order by programme");


                DataMapper(dtSponsoredCertProgramme);
            }
            catch (Exception ex) { }

            return lstSponsoredProgrammes;
        }
        void DataMapper(DataTable dtSponsoredCertProgramme)
        {
            try
            {
                SponsoredCertProgramme sponsoredCertProgramme;
                foreach (DataRow dRow in dtSponsoredCertProgramme.Rows)
                {
                    sponsoredCertProgramme = new SponsoredCertProgramme();
                    sponsoredCertProgramme.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : 0;
                    sponsoredCertProgramme.Description = dRow["programme"] != DBNull.Value ? Convert.ToString(dRow["programme"]) : string.Empty;
                    sponsoredCertProgramme.ProgrammeDuration = dRow["programme_duration"] != DBNull.Value ? Convert.ToInt32(dRow["programme_duration"]) : 0;
                    sponsoredCertProgramme.BondedDuration = dRow["bonded_duration"] != DBNull.Value ? Convert.ToInt32(dRow["bonded_duration"]) : 0;
                    sponsoredCertProgramme.Active = dRow["active"] != DBNull.Value ? Convert.ToBoolean(dRow["active"]) : false;
                    sponsoredCertProgramme.Archived = dRow["archived"] != DBNull.Value ? Convert.ToBoolean(dRow["archived"]) : false;
                    sponsoredCertProgramme.Comparator = dRow["comparator"] != DBNull.Value ? dRow["comparator"] .ToString(): sponsoredCertProgramme.Comparator;
                    lstSponsoredProgrammes.Add(sponsoredCertProgramme);
                }
            }
            catch (Exception exc)
            {

            }
            
        }
    }
}
