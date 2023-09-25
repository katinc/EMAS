using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;

namespace HRDataAccessLayerBase
{
    public class DataProviderFactory
    {
        private  DbProviderFactory providerFactory;
        private string connectionString;

        private string password;
        private string dataSource;
        private string username;
        private string databaseName;

        public DataProviderFactory()
        {
            try
            {
                RegistryKey keys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\IDNS\EMAS");
                if (keys != null)
                {
                    password = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(keys.GetValue("Password").ToString()));
                    dataSource = keys.GetValue("DataSource").ToString();
                    username = keys.GetValue("Username").ToString();
                    databaseName = keys.GetValue("DatabaseName").ToString();

                    keys.Close();
                }

                //password = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(ConfigurationManager.AppSettings["dbPassword"]));
                providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["HRConnectionString"].ProviderName);
                connectionString = string.Format(ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString, dataSource, databaseName, username, password);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        
        public DbProviderFactory ProviderFactory
        {
            get { return providerFactory; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
        }

        public string Password
        {
            get { return password; }
        }
    }
}
