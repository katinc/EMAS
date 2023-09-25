using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace HRDataAccessLayerBase
{
    public class DALHelper
    {
        private static DbProviderFactory providerFactory;
        private static DbConnection connection;
        public static DbCommand command;
        private static DbTransaction transaction;
        private static DbDataReader reader;

        static DALHelper()
        {
            DataProviderFactory dbfactory = new DataProviderFactory();
            providerFactory = dbfactory.ProviderFactory;
            connection = providerFactory.CreateConnection();
            connection.ConnectionString = dbfactory.ConnectionString;
            command = providerFactory.CreateCommand();
            command.Connection = connection;
            command.CommandTimeout = 3600;
        }

     

        #region ConnectionString
        public string ConnectionString()
        {
            try
            {
                DataProviderFactory dbfactory = new DataProviderFactory();
                providerFactory = dbfactory.ProviderFactory;
                connection = providerFactory.CreateConnection();
                connection.ConnectionString = dbfactory.ConnectionString;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            return connection.ConnectionString;
        }
        #endregion

        #region Open Connection
        public  void OpenConnection()
        {
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }
            }
            catch (DbException ex)
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
                if (command.Connection.State != ConnectionState.Closed)
                {
                    command.Connection.Close();
                    transaction = null;
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Prepare Command
        private void PrepareCommand(string commandText,CommandType commandType)
        {
            command.CommandText = commandText;
            command.CommandType = commandType;
        }
        public DbCommand CurrentCommand
        {
            get
            {
                return command;
            }
            set { command = value; }
        }

        #endregion

        #region Execute Non Query
        public void ExecuteNonQuery(string commandText)
        {
            OpenConnection();
            PrepareCommand(commandText, CommandType.Text);
            try
            {
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }
                command.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Transaction Management
        public void BeginTransaction()
        {
            if (!IsInTransaction)
            {
                OpenConnection();
                transaction = command.Connection.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            if (IsInTransaction)
            {
                transaction.Commit();
                transaction = null;
            }
            //else
            //    throw new Exception("There is no existing transaction");
        }

        public void RollBackTransaction()
        {
            if (IsInTransaction)
            {
                transaction.Rollback();
                transaction = null;
            }
            //else
            //    throw new Exception("There is no existing transaction");
        }

        public bool IsInTransaction
        {
            get
            {
                if (transaction == null)
                    return false;
                else
                    return true;
            }
        }
        #endregion


        #region Execute Reader
        public DataTable ExecuteReader(string commandText)
        {
            OpenConnection();
            DataTable dataTable = new DataTable();
            PrepareCommand(commandText, CommandType.Text);
            try
            {
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (DbException ex)
            {
                throw ex;
            }
            return dataTable;
        }

        #endregion

        #region Execute Scalar
        public object ExecuteScalar(string commandText)
        {
            OpenConnection();
            object result = null;
            PrepareCommand(commandText,CommandType.Text);
            try
            {
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }
                result = command.ExecuteScalar();
            }
            catch (DbException dbex)
            {
                throw dbex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region Create Parameter 
        public void CreateParameter(string name,int size,object value,DbType dbtype)
        {
            DbParameter parameter = providerFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Size =size;
            parameter.Value = value;
            parameter.DbType = dbtype;
            command.Parameters.Add(parameter);
        }
        public void CreateParameter(string name, object value, DbType dbtype)
        {
            DbParameter parameter = providerFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.DbType = dbtype;
            if(!command.Parameters.Contains(name))
            command.Parameters.Add(parameter);
        }
        #endregion

        #region Clear Parameters
        public void ClearParameters()
        {
            command.Parameters.Clear();
        }

        public DbParameterCollection Parameters
        {
            get
            {
                return command.Parameters;
            }
        }
        #endregion
    }
}
