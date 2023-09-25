using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace EMASDeviceConsoleService.Libs
{
   public class DBLib
    {
       public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString);

       public bool  OpenConnection()
       {
           try
           {
               if( con.State == System.Data.ConnectionState.Closed)
               {
                    con.Open();
               }

               return true;
           }
           catch (Exception ex) { return false; }
          
       }

       public static string getConString
       {
           get 
           {
               return ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
           }
       }
    }
}
