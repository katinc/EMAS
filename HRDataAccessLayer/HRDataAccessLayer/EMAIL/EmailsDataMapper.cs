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
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRBussinessLayer.EMAIL;

namespace HRDataAccessLayer.EMAILS
{
    public class EmailsDataMapper
    {
        private DALHelper dal;
        private StaffEmail staffEmail;

        public EmailsDataMapper()
        {
            try
            {
                dal = new DALHelper();
                staffEmail = new StaffEmail();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Get All Staffs With Emails
        public IList<StaffEmail> GetAll()
        {
            IList<StaffEmail> staffEmails = new List<StaffEmail>();
            try
            {
                DataTable table = dal.ExecuteReader("Select StaffID,Firstname,Surname,OtherName,DOB,Email from StaffPersonalInfoView");
                foreach (DataRow row in table.Rows)
                {
                    staffEmails.Add(new StaffEmail() 
                    { 
                        StaffID = row["StaffID"].ToString(), 
                        Email = row["Email"].ToString(), 
                        DOB = row["DOB"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                throw ex;
            }

            return staffEmails;
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
