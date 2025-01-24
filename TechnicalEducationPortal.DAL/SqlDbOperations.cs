using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TechnicalEducationPortal.DAL
{
    public class SqlDbOperations : IDbOperations
    {
        private readonly string _connection;

        public SqlDbOperations(IDbConnection dbConnection)
        {
            _connection = dbConnection.ConnectionString;
        }
        public void Update(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            string connectionString = _connection;
            DataAccessHandler dataAccessHandler = new(connectionString);

            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();

                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
        public int Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out int id)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            id = 0;
            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();
                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    object generatedId = command.ExecuteScalar();
                    id = Convert.ToInt32(generatedId);
                }
            }
            return id;
        }
        public DataTable InsertWithReturnRecord(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();
                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    var dataset = new DataSet();
                    var dataAdaper = dataAccessHandler.CreateAdapter(command);
                    dataAdaper.Fill(dataset);

                    if (dataset != null && dataset.Tables.Count > 0)
                        return dataset.Tables[0];
                    else
                        return new DataTable();
                }
            }
        }
        public void Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();

                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
        }
        public object GetScalarValue(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();

                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    return command.ExecuteScalar();
                }
            }
        }
        public DataTable GetDataTable(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            try
            {
                using (var connection = dataAccessHandler.CreateConnection())
                {
                    connection.Open();

                    using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        var dataset = new DataSet();
                        var dataAdaper = dataAccessHandler.CreateAdapter(command);
                        dataAdaper.Fill(dataset);

                        if (dataset != null && dataset.Tables.Count > 0)
                            return dataset.Tables[0];
                        else
                            return new DataTable();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public DataSet GetDataSet(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            try
            {
                using (var connection = dataAccessHandler.CreateConnection())
                {
                    connection.Open();

                    using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        var dataset = new DataSet();
                        var dataAdaper = dataAccessHandler.CreateAdapter(command);
                        dataAdaper.Fill(dataset);

                        if (dataset != null && dataset.Tables.Count > 0)
                            return dataset;
                        else
                            return new DataSet();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void Delete(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();

                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public int InsertwithUserDefineTableType(string commandText, CommandType commandType, IDbDataParameter[] parameters, string TableParam, DataTable TableType)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            int id = 0;
            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();
                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                    }

                    //Assuming SQL Server, cast to SqlParameter
                    if (command is SqlCommand sqlCommand)
                    {
                        var tvpParameter = sqlCommand.Parameters.AddWithValue("@" + TableParam, TableType);
                        tvpParameter.SqlDbType = SqlDbType.Structured;
                        tvpParameter.TypeName = "dbo." + TableParam; // Replace with your actual TVP type
                    }

                    object generatedId = command.ExecuteScalar();
                    id = Convert.ToInt32(generatedId);
                }
            }
            return id;
        }

        public void InsertUDTableType(string commandText, CommandType commandType, IDbDataParameter[] parameters, string TableParam, DataTable TableType)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            int id = 0;
            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();
                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                    }

                    //Assuming SQL Server, cast to SqlParameter
                    if (command is SqlCommand sqlCommand)
                    {
                        var tvpParameter = sqlCommand.Parameters.AddWithValue("@" + TableParam, TableType);
                        tvpParameter.SqlDbType = SqlDbType.Structured;
                        tvpParameter.TypeName = "dbo." + TableParam; // Replace with your actual TVP type
                    }

                    object generatedId = command.ExecuteScalar();
                    //  id = Convert.ToInt32(generatedId);
                }
            }

        }

        public void UpdateWithUserDefineTableType(string commandText, CommandType commandType, IDbDataParameter[] parameters, string TableParam, DataTable TableType)
        {
            string connectionString = Convert.ToString(_connection);
            DataAccessHandler dataAccessHandler = new DataAccessHandler(connectionString);
            int id = 0;
            using (var connection = dataAccessHandler.CreateConnection())
            {
                connection.Open();
                using (var command = dataAccessHandler.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                    }

                    //Assuming SQL Server, cast to SqlParameter
                    if (command is SqlCommand sqlCommand)
                    {
                        var tvpParameter = sqlCommand.Parameters.AddWithValue("@" + TableParam, TableType);
                        tvpParameter.SqlDbType = SqlDbType.Structured;
                        tvpParameter.TypeName = "dbo." + TableParam; // Replace with your actual TVP type
                    }
                    object generatedId = command.ExecuteScalar();
                    //id = Convert.ToInt32(generatedId);


                }
            }

        }
    }
}
