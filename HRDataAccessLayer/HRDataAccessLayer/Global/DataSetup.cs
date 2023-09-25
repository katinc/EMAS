using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace HRDataAccessLayer.Global
{
    public class DataSetup
    {
        #region POPULATE DEPARTMENT DATA IN COMBO
        public List<string> GetDepartments() //not implemented
        {
            try
            {
                List<string> departments = new List<string>();

                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Department FROM Setup_Departments ORDER by Department ASC"; 

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                while (rdr.Read())
                {
                    departments.Add(rdr.GetString(0));
                }

                return departments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region POPULATE DEPARTMENT DATA IN COMBO
        public List<string> GetGradeCategory() 
        {
            try
            {
                List<string> gradeCategory = new List<string>();

                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT description FROM GradeCategory_Setup"; 

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                while (rdr.Read())
                {
                    gradeCategory.Add(rdr.GetString(0));
                }

                return gradeCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
