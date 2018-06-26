using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ITWhiz.ScaleSoft.DataAccess
{
    public class SQLiteHelper : IDisposable
    {
        private bool disposed = false;
        private readonly SQLiteConnection _dbConnection;
        private SQLiteCommand _Command;
        private Logger _Logger = LogManager.GetCurrentClassLogger();

        public SQLiteHelper()
        {
            string ConnectionString = @"Data Source=|DataDirectory|\WeighPot.db3;Version=3;";

            _Logger.Info("Database connection string : " + ConnectionString);

            try
            {
                _dbConnection = new SQLiteConnection(ConnectionString);
                _dbConnection.Open();
                _Command = new SQLiteCommand(_dbConnection);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Gets the specified table from the Database.
        /// </summary>
        /// <param name="SQLQuery">The table to retrieve from the database.</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable GetDataTable(string SQLQuery)
        {
            var table = new DataTable();

            try
            {
                using (SQLiteTransaction transaction = _dbConnection.BeginTransaction())
                {
                    using (var cmd = new SQLiteCommand(_dbConnection) { Transaction = transaction, CommandText = SQLQuery })
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            table.Load(reader);
                            transaction.Commit();
                        }
                    }
                }

                return table;
            }
            catch (Exception e)
            {
                Console.WriteLine("SQLite Exception : {0}", e.Message);
            }
            finally
            {
                table.Dispose();
            }

            return null;
        }

        /// <summary>
        /// Gets a single value from the database.
        /// </summary>
        /// <param name="SQLQuery">The SQL to execute.</param>
        /// <returns>Returns the value retrieved from the database.</returns>
        public string ExecuteScalar(string SQLQuery)
        {
            try
            {
                using (SQLiteTransaction transaction = _dbConnection.BeginTransaction())
                {
                    using (var cmd = new SQLiteCommand(_dbConnection) { Transaction = transaction, CommandText = SQLQuery })
                    {
                        object value = cmd.ExecuteScalar();
                        transaction.Commit();
                        return value != null ? value.ToString() : "";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SQLite Exception : {0}", e.Message);
            }

            return null;
        }

        public void Dispose()
        {
            if (_dbConnection != null)
                _dbConnection.Dispose();

            GC.Collect();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbConnection.Close();
                    _dbConnection.Dispose();
                }
            }
            this.disposed = true;
        }

        #region public methods

        public void Begin()
        {
            _Command.CommandText = "begin transaction;";
            _Command.ExecuteNonQuery();
        }

        public void Commit()
        {
            _Command.CommandText = "commit;";
            _Command.ExecuteNonQuery();
        }

        public void Rollback()
        {
            _Command.CommandText = "rollback";
            _Command.ExecuteNonQuery();
        }

        public DataTable Select(string sql)
        {
            return Select(sql, new List<SQLiteParameter>());
        }

        public DataTable Select(string sql, Dictionary<string, object> dicParameters = null)
        {
            List<SQLiteParameter> lst = GetParametersList(dicParameters);
            return Select(sql, lst);
        }

        public DataTable Select(string sql, IEnumerable<SQLiteParameter> parameters = null)
        {
            Console.Write("Query:" + sql);
            _Logger.Info("Query: "+ sql);
            _Command.CommandText = sql;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    _Command.Parameters.Add(param);
                }
            }
            SQLiteDataAdapter da = new SQLiteDataAdapter(_Command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void Insert(string tableName, Dictionary<string, object> dic)
        {
            StringBuilder sbCol = new System.Text.StringBuilder();
            StringBuilder sbVal = new System.Text.StringBuilder();

            foreach (KeyValuePair<string, object> kv in dic)
            {
                if (sbCol.Length == 0)
                {
                    sbCol.Append("insert into ");
                    sbCol.Append(tableName);
                    sbCol.Append("(");
                }
                else
                {
                    sbCol.Append(",");
                }

                sbCol.Append("`");
                sbCol.Append(kv.Key);
                sbCol.Append("`");

                if (sbVal.Length == 0)
                {
                    sbVal.Append(" values(");
                }
                else
                {
                    sbVal.Append(", ");
                }

                sbVal.Append("@v");
                sbVal.Append(kv.Key);
            }

            sbCol.Append(") ");
            sbVal.Append(");");

            _Command.CommandText = sbCol.ToString() + sbVal.ToString();

            foreach (KeyValuePair<string, object> kv in dic)
            {
                _Command.Parameters.AddWithValue("@v" + kv.Key, kv.Value);
            }

            _Command.ExecuteNonQuery();
        }


        public void Update(string tableName, Dictionary<string, object> dicData, string colCond, object varCond)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic[colCond] = varCond;
            Update(tableName, dicData, dic);
        }

        public void Update(string tableName, Dictionary<string, object> dicData, Dictionary<string, object> dicCond)
        {
            if (dicData.Count == 0)
                throw new Exception("dicData is empty.");

            StringBuilder sbData = new System.Text.StringBuilder();

            Dictionary<string, object> _dicTypeSource = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> kv1 in dicData)
            {
                _dicTypeSource[kv1.Key] = null;
            }

            foreach (KeyValuePair<string, object> kv2 in dicCond)
            {
                if (!_dicTypeSource.ContainsKey(kv2.Key))
                    _dicTypeSource[kv2.Key] = null;
            }

            sbData.Append("update `");
            sbData.Append(tableName);
            sbData.Append("` set ");

            bool firstRecord = true;

            foreach (KeyValuePair<string, object> kv in dicData)
            {
                if (firstRecord)
                    firstRecord = false;
                else
                    sbData.Append(",");

                sbData.Append("`");
                sbData.Append(kv.Key);
                sbData.Append("` = ");

                sbData.Append("@v");
                sbData.Append(kv.Key);
            }

            sbData.Append(" where ");

            firstRecord = true;

            foreach (KeyValuePair<string, object> kv in dicCond)
            {
                if (firstRecord)
                    firstRecord = false;
                else
                {
                    sbData.Append(" and ");
                }

                sbData.Append("`");
                sbData.Append(kv.Key);
                sbData.Append("` = ");

                sbData.Append("@c");
                sbData.Append(kv.Key);
            }

            sbData.Append(";");

            _Command.CommandText = sbData.ToString();

            foreach (KeyValuePair<string, object> kv in dicData)
            {
                _Command.Parameters.AddWithValue("@v" + kv.Key, kv.Value);
            }

            foreach (KeyValuePair<string, object> kv in dicCond)
            {
                _Command.Parameters.AddWithValue("@c" + kv.Key, kv.Value);
            }

            _Command.ExecuteNonQuery();
        }

        public void Delete(string tableName, string colCondition)
        {
            StringBuilder sbData = new System.Text.StringBuilder();

            sbData.Append("DELETE FROM `");
            sbData.Append(tableName);
            sbData.Append("` WHERE ");
            sbData.Append(colCondition);
            sbData.Append(";");

            _Command.CommandText = sbData.ToString();
            _Command.ExecuteNonQuery();
        }

        public void Execute(string sql)
        {
            Execute(sql, new List<SQLiteParameter>());
        }

        public void Execute(string sql, Dictionary<string, object> dicParameters = null)
        {
            List<SQLiteParameter> lst = GetParametersList(dicParameters);
            Execute(sql, lst);
        }

        public void Execute(string sql, IEnumerable<SQLiteParameter> parameters = null)
        {
            _Command.CommandText = sql;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    _Command.Parameters.Add(param);
                }
            }
            _Command.ExecuteNonQuery();
        }

        //public object ExecuteScalar(string sql)
        //{
        //    _Command.CommandText = sql;
        //    return _Command.ExecuteScalar();
        //}

        public object ExecuteScalar(string sql, Dictionary<string, object> dicParameters = null)
        {
            List<SQLiteParameter> lst = GetParametersList(dicParameters);
            return ExecuteScalar(sql, lst);
        }

        public object ExecuteScalar(string sql, IEnumerable<SQLiteParameter> parameters = null)
        {
            _Command.CommandText = sql;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    _Command.Parameters.Add(parameter);
                }
            }
            return _Command.ExecuteScalar();
        }

        public dataType ExecuteScalar<dataType>(string sql, Dictionary<string, object> dicParameters = null)
        {
            List<SQLiteParameter> lst = null;
            if (dicParameters != null)
            {
                lst = new List<SQLiteParameter>();
                foreach (KeyValuePair<string, object> kv in dicParameters)
                {
                    lst.Add(new SQLiteParameter(kv.Key, kv.Value));
                }
            }
            return ExecuteScalar<dataType>(sql, lst);
        }

        public dataType ExecuteScalar<dataType>(string sql, IEnumerable<SQLiteParameter> parameters = null)
        {
            _Command.CommandText = sql;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    _Command.Parameters.Add(parameter);
                }
            }
            return (dataType)Convert.ChangeType(_Command.ExecuteScalar(), typeof(dataType));
        }

        public dataType ExecuteScalar<dataType>(string sql)
        {
            _Command.CommandText = sql;
            return (dataType)Convert.ChangeType(_Command.ExecuteScalar(), typeof(dataType));
        }

        public long LastInsertRowId()
        {
            return ExecuteScalar<long>("select last_insert_rowid();");
        }

        #endregion

        #region private methods

        private List<SQLiteParameter> GetParametersList(Dictionary<string, object> dicParameters)
        {
            List<SQLiteParameter> lst = new List<SQLiteParameter>();
            if (dicParameters != null)
            {
                foreach (KeyValuePair<string, object> kv in dicParameters)
                {
                    lst.Add(new SQLiteParameter(kv.Key, kv.Value));
                }
            }
            return lst;
        }

        private string Escape(string data)
        {
            data = data.Replace("'", "''");
            data = data.Replace("\\", "\\\\");
            return data;
        }
        #endregion
    }
}
