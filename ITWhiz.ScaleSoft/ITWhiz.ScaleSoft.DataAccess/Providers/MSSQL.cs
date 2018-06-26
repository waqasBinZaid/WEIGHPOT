using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.DataAccess.Providers
{
    public class MSSQL : IDbConnection
    {
        private SqlConnection _Connection;

        public MSSQL()
        {
            _Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScaleSoft"].ConnectionString);
        }

        public string ConnectionString { get; set;}

        public int ConnectionTimeout {get;}

        public string Database{ get;}

        public ConnectionState State{ get; }

        public IDbTransaction BeginTransaction()
        {
            return _Connection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _Connection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            _Connection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            _Connection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return _Connection.CreateCommand();
        }

        public void Dispose()
        {
            _Connection = null;
        }

        public void Open()
        {
            _Connection.Open();
        }
    }
}
