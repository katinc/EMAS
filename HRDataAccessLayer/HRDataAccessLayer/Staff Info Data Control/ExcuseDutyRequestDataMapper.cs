using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;
using HRBussinessLayer.System_Setup_Class;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
   public class ExcuseDutyRequestDataMapper
    {
        private DALHelper dalHelper;
        private ExcuseDutyRequest excuseDutyRequest;
        private List<ExcuseDutyRequest> lstExcuseDutyRequest;
        private DataTable dtExcuseRequests = null;
        private ExcuseDutyRequestTypeDataMapper requestTypeMapper;
        private EmployeeDataMapper employeeMapper;
        private String query;

        public ExcuseDutyRequestDataMapper()
        {
            this.dalHelper = new DALHelper();
            this.excuseDutyRequest = new ExcuseDutyRequest();
            this.lstExcuseDutyRequest = new List<ExcuseDutyRequest>();
            this.dtExcuseRequests = new DataTable();
            this.requestTypeMapper = new ExcuseDutyRequestTypeDataMapper();
            this.employeeMapper = new EmployeeDataMapper();
            this.query = string.Empty;
        }

        public List<ExcuseDutyRequest> getAll()
        {
            var query = string.Empty;
          
                query = "select * from ViewExcuseDutyRequests order by id desc";
                dtExcuseRequests=dalHelper.ExecuteReader(query);
                MappData(dtExcuseRequests);
                return lstExcuseDutyRequest;
        }
        public bool deleteRecord(int id)
        {
            try
            {
                this.query = "delete from ExcusedDutyRequest where id=@id";
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@id", id, DbType.Int32);

                dalHelper.ExecuteNonQuery(this.query);
                return true;
            }
            catch (Exception exi)
            {
                return false;
            }
        } 
        public List<ExcuseDutyRequest> getAll(DALHelper NewdalHelper)
        {
           
            if (NewdalHelper != null)
            {
                this.dalHelper = NewdalHelper;
                this.query = NewdalHelper.CurrentCommand.CommandText;
            }
            else
            {
                query = "select * from ViewExcuseDutyRequests  order by id desc";
            }

            dtExcuseRequests = dalHelper.ExecuteReader(query);
            MappData(dtExcuseRequests);
            return lstExcuseDutyRequest;
        }

        public ExcuseDutyRequest getById(int id)
        {
            dalHelper.ClearParameters();
            var query = "select * from ViewExcuseDutyRequests where id=@id  order by id desc";
            dalHelper.CreateParameter("@id", id, DbType.Int32);
            dtExcuseRequests = dalHelper.ExecuteReader(query);
            MappData(dtExcuseRequests);
           return lstExcuseDutyRequest.FirstOrDefault();
        }

        private void MappData(DataTable dt)
        {
            try
            {
                lstExcuseDutyRequest = new List<ExcuseDutyRequest>();
                foreach (DataRow dr in dt.Rows)
                {
                    ExcuseDutyRequest excuseDutyRequest = new ExcuseDutyRequest() { 
                    
                        id = Convert.ToInt32(dr["id"]),

                        Employee = new Employee()
                            {
                                StaffID = dr["StaffId"].ToString(),
                                FirstName = dr["Firstname"].ToString(),
                                Surname = dr["Surname"].ToString(),
                                OtherName = dr["OtherName"].ToString(),
                                Department = new Department() { Description = dr["Department"] == DBNull.Value ? string.Empty : dr["Department"].ToString() },
                                Unit = new Unit() { Description = dr["Unit"] == DBNull.Value ? string.Empty : dr["Unit"].ToString() },
                                GradeCategory = new GradeCategory() { Description = dr["GradeCategory"] == DBNull.Value ? string.Empty : dr["GradeCategory"].ToString() },
                                Grade = new EmployeeGrade() { Grade = dr["Grade"] == DBNull.Value ? string.Empty : dr["Grade"].ToString() },
                            },

                        LeaveStatus = dr["LeaveStatus"].ToString(),
                    LeaveYear = Convert.ToInt32(dr["LeaveYear"]),
                    ExcuseDutySheet = dr["ExcuseDutySheet"] != DBNull.Value ? (byte[])dr["ExcuseDutySheet"] : null,
                    ExcuseDutyFileName = dr["ExcuseDutyFileName"] != DBNull.Value ? dr["ExcuseDutyFileName"].ToString() : string.Empty,
                    SpecifyOther = dr["SpecifyOther"] != null ? dr["SpecifyOther"].ToString() : string.Empty,
                    StartDate = Convert.ToDateTime(dr["StartDate"]),
                    NumOfDays = dr["NumOfDays"] != DBNull.Value ? Convert.ToInt32(dr["NumOfDays"]) : 0,
                    EndDate = Convert.ToDateTime(dr["EndDate"]),
                    RequestDate = Convert.ToDateTime(dr["RequestDate"]),
                    Recommended =dr["Recommended"]!=DBNull.Value? Convert.ToBoolean(dr["Recommended"]) : false,
                    AdditionalComment = dr["AdditionalComment"] != DBNull.Value ? dr["AdditionalComment"].ToString() : string.Empty,
                   
                    SupervisorId = dr["SupervisorId"] != DBNull.Value ? Convert.ToInt32(dr["SupervisorId"]): 0,
                    SupervisorName = dr["SupervisorName"] != DBNull.Value ? dr["SupervisorName"].ToString() : string.Empty,
                    SupervisorEmpCode = dr["SupervisorEmpCode"] != DBNull.Value ? dr["SupervisorEmpCode"].ToString() : string.Empty,

                    RecommendationDate = dr["RecommendationDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(dr["RecommendationDate"].ToString()),
                    RecommendedById = dr["RecommendedById"] != DBNull.Value ? Convert.ToInt32(dr["RecommendedById"]) : 0,
                    RecommendedByName = dr["RecommendedByName"] != DBNull.Value ? Convert.ToString(dr["RecommendedByName"]) : string.Empty,


                    HRAdditionalComment = dr["HRAdditionalComment"] != DBNull.Value ? dr["HRAdditionalComment"].ToString() : string.Empty,
                    HRAssessmentDate = dr["HRAssessmentDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(dr["HRAssessmentDate"].ToString()),
                    HREligibility = dr["HREligibility"] != DBNull.Value ? Convert.ToBoolean(dr["HREligibility"]) : false,
                    HRRecommendedById = dr["HRRecommendedById"] != DBNull.Value ? Convert.ToInt32(dr["HRRecommendedById"]) : 0,
                    HRRecommended = dr["HRRecommended"] != DBNull.Value ? Convert.ToBoolean(dr["HRRecommended"]) : false,

                    ApprovedById = dr["ApprovedById"] != DBNull.Value ? Convert.ToInt32(dr["ApprovedById"]) : 0,
                    Approved = dr["Approved"] != DBNull.Value ? Convert.ToBoolean(dr["Approved"]) : false,
                    ApprovedDate = dr["ApprovalDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(dr["ApprovalDate"].ToString()),
                    ApprovedByName = dr["ApprovedByName"] != DBNull.Value ? Convert.ToString(dr["ApprovedByName"]) : string.Empty,
                    ApprovalComment = dr["ApprovalComment"] != DBNull.Value ? Convert.ToString(dr["ApprovalComment"]) : string.Empty,

                    requestType = requestTypeMapper.getById(Convert.ToInt32(dr["RequestTypeId"])),
                    
                    Returned = dr["Returned"]!=DBNull.Value?Convert.ToBoolean(dr["Returned"]):false,
                    ResumptionDate = dr["ResumptionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(dr["ResumptionDate"].ToString()),
                    ResumptionReason = dr["ResumptionReason"] != DBNull.Value ? Convert.ToString(dr["ResumptionReason"]) : string.Empty
                        
                    };
                    lstExcuseDutyRequest.Add(excuseDutyRequest);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            
        }
    }
}
