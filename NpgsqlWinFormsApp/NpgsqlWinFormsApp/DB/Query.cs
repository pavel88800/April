using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using NpgsqlWinFormsApp.Interfaces;

namespace NpgsqlWinFormsApp.DB
{
    internal class Query : IDisposable
    {
        private NpgsqlCommand _command;
        private NpgsqlConnection _npgSqlConnection;
        private NpgsqlTransaction _transaction;

        public Query()
        {
            OpenConnection();
        }

        /// <inheritdoc cref="IDisposable" />
        public void Dispose()
        {
            CloseConnection();

            _command = null;
            _npgSqlConnection = null;
            _transaction = null;
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        public bool DeriveParameters()
        {
            try
            {
                NpgsqlCommandBuilder.DeriveParameters(_command);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        private bool OpenConnection()
        {
            try
            {
                var connectionString =
                    "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=TestDB;Pooling=false";
                _npgSqlConnection = new NpgsqlConnection(connectionString);
                _npgSqlConnection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        private bool CloseConnection()
        {
            try
            {
                _npgSqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        public bool Add(string parameterName, object parameterValue, NpgsqlDbType type)
        {
            try
            {
                var script = string.Empty;

                if (parameterValue == "" || parameterValue == null)
                {
                    script = "SELECT * FROM test";
                    _command = new NpgsqlCommand(script, _npgSqlConnection, _transaction);
                }
                else
                {
                    script = string.Format("SELECT * FROM test WHERE test.{0}  LIKE '%' || :{0} || '%' ",
                        parameterName);

                    _command = new NpgsqlCommand(script, _npgSqlConnection, _transaction);
                    _command.Parameters.AddWithValue(parameterName, type, parameterValue);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        public bool BeginTransaction()
        {
            try
            {
                _transaction = _npgSqlConnection.BeginTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        public bool CommitTransaction()
        {
            try
            {
                _transaction.Commit();

                if (_transaction.IsCompleted)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        public bool RollbackTransaction()
        {
            _transaction.Rollback();
            return false;
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        public bool ExecuteNonQuery()
        {
            if (BeginTransaction())
            {
                _command.CommandTimeout = 120;
                try
                {
                    _command.ExecuteNonQuery();
                    return CommitTransaction();
                }
                catch (Exception e)
                {
                    return RollbackTransaction();
                }
            }

            return false;
        }

        /// <inheritdoc cref="IPgConnectionInterfaces" />
        public DataTable FillData()
        {
            var dataTable = CreateDataTable();

            var dataReader = _command.ExecuteReader();

            DataRow row;
            while (dataReader.Read())
            {
                row = dataTable.NewRow();
                row["name"] = dataReader["name"];
                row["phone"] = dataReader["phone"];
                row["city"] = dataReader["city"];
                row["date_registration"] = dataReader["date_registration"];
                row["address"] = dataReader["address"];
                row["email"] = dataReader["email"];
                row["is_working"] = dataReader["is_working"];
                row["user"] = dataReader["user"];
                row["comment"] = dataReader["comment"];
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        /// <summary>
        ///     Создаем таблицу
        /// </summary>
        /// <returns>
        ///     <see cref="DataTable" />
        /// </returns>
        private static DataTable CreateDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("phone", typeof(string));
            dataTable.Columns.Add("city", typeof(string));
            dataTable.Columns.Add("date_registration", typeof(DateTime));
            dataTable.Columns.Add("address", typeof(string));
            dataTable.Columns.Add("email", typeof(string));
            dataTable.Columns.Add("is_working", typeof(bool));
            dataTable.Columns.Add("user", typeof(string));
            dataTable.Columns.Add("comment", typeof(string));

            return dataTable;
        }
    }
}