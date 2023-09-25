using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace HRDataAccessLayerBase
{
    internal class DataProviderFactory
    {
        private  DbProviderFactory providerFactory;
        private string connectionString;

        public DataProviderFactory()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
                providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["HRConnectionString"].ProviderName);
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


    }
}
