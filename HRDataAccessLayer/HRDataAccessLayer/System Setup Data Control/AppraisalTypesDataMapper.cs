using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public  class AppraisalTypesDataMapper
    {
        private IList<AppraisalType> lstAppraisalTypes;
        private DALHelper dalHelper;
        private UserInfoDataMapper userDataMapper;

        public AppraisalTypesDataMapper()
        {
            lstAppraisalTypes=new List<AppraisalType>();
            dalHelper = new DALHelper();
            userDataMapper = new UserInfoDataMapper();
        }

        public IList<AppraisalType> getAppraisalTypes(bool Active,bool Archived)
        {
            try
            {
                lstAppraisalTypes.Clear();
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", Archived, DbType.Boolean);
                dalHelper.CreateParameter("@Active", Active, DbType.Boolean);

                DataTable dt = dalHelper.ExecuteReader("select * from AppraisalTypes where Active=@Active and Archived=@Archived");
                MappData(dt);
            }
            catch (Exception xi) { }
          
          return lstAppraisalTypes;
        }
        public AppraisalType getAppraisalTypeById(int Id)
        {
            try
            {
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Id", Id, DbType.Int32);

                DataTable dt = dalHelper.ExecuteReader("select * from AppraisalTypes where id=@Id");
                MappData(dt);
            }
            catch (Exception xi) { }

            return lstAppraisalTypes.FirstOrDefault();
        }
        private void MappData(DataTable dt)
        {
            lstAppraisalTypes.Clear();
            foreach(DataRow dRow in dt.Rows){
                AppraisalType appraisalType = new AppraisalType();
                appraisalType.ID = dRow["ID"] != DBNull.Value ? Convert.ToInt32(dRow["ID"]) : appraisalType.ID;
                appraisalType.Description = dRow["Description"] != DBNull.Value ? Convert.ToString(dRow["Description"]) : appraisalType.Description;
                appraisalType.DateModified = dRow["DateModified"] != DBNull.Value ? Convert.ToDateTime(dRow["DateModified"]) : appraisalType.DateModified;

                appraisalType.Active = dRow["Active"] != DBNull.Value ? Convert.ToBoolean(dRow["Active"]) : appraisalType.Active;
                appraisalType.Archived = dRow["Archived"] != DBNull.Value ? Convert.ToBoolean(dRow["Archived"]) : appraisalType.Archived;

                appraisalType.User = dRow["UserID"] != DBNull.Value ? userDataMapper.GetById (Convert.ToInt32(dRow["UserID"]) ): appraisalType.User;
                lstAppraisalTypes.Add(appraisalType);
            }
        }
    }
}
