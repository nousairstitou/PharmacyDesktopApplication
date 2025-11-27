using Microsoft.Data.SqlClient;
using Repositories.Abstract.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Data.Repositories {

    public abstract class BaseRepository<T> where T : class {

        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        protected BaseRepository(IDatabaseConnectionFactory databaseConnectionFactory) {

            _databaseConnectionFactory = databaseConnectionFactory ?? throw new ArgumentNullException(nameof(databaseConnectionFactory));
        }

        // GetList method to retrieve all records from a table
        protected async Task<IEnumerable<TResult>> GetList<TResult>(string query, Func<SqlDataReader, TResult> mapper) {

            var list = new List<TResult>();

            await using (var Connection = _databaseConnectionFactory.CreateConnection()) {

                await using (var Command = new SqlCommand(query, Connection)) {

                    Command.CommandType = CommandType.Text;

                    try {

                        await Connection.OpenAsync();
                        await using (var Reader = await Command.ExecuteReaderAsync()) {

                            while (await Reader.ReadAsync()) {

                                list.Add(mapper(Reader));
                            }
                        }
                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][GetList] Error: {ex}");
                        throw;
                    }
                }
            }

            return list;
        }

        // GetListByValue method to retrieve a list of records based on a given condition
        protected async Task<IReadOnlyList<TResult>> GetListByValue<TResult>(string query, Func<SqlDataReader, TResult> mapper) {

            var list = new List<TResult>();

            await using (var Connection = _databaseConnectionFactory.CreateConnection()) {

                await using (var Command = new SqlCommand(query, Connection)) {

                    Command.CommandType = CommandType.Text;

                    try {

                        await Connection.OpenAsync();
                        await using (var Reader = await Command.ExecuteReaderAsync()) {

                            while (await Reader.ReadAsync()) {

                                list.Add(mapper(Reader));
                            }
                        }

                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][GetListByValue] Error: {ex}");
                        throw;
                    }
                }
            }

            return list;
        }

        // GetByValue method to retrieve a single record based on a given condition
        protected virtual async Task<T?> GetByValue(string procedureName, string parameterName, object? ParameterValue, Func<SqlDataReader, T> Mapper) {

            await using (var Connection = _databaseConnectionFactory.CreateConnection()) {

                await using (var Command = new SqlCommand(procedureName, Connection)) {

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue(parameterName, ParameterValue ?? DBNull.Value);

                    try {

                        await Connection.OpenAsync();

                        await using (var Reader = await Command.ExecuteReaderAsync()) {

                            if (await Reader.ReadAsync())
                                return Mapper(Reader);
                        }
                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][GetByValue] Error: {ex}");
                        throw;
                    }
                }
            }

            return null;
        }

        // Insert method to add a new record and return the newly generated identifier
        protected virtual async Task<int?> Insert(string procedureName, string outputParameterName, Action<SqlCommand> parameterBuilder) {

            int? NewId = null;

            await using (var Connection = _databaseConnectionFactory.CreateConnection()) {

                await using (var Command = new SqlCommand(procedureName, Connection)) {

                    Command.CommandType = CommandType.StoredProcedure;
                    parameterBuilder(Command);

                    SqlParameter outputParameter = new SqlParameter(outputParameterName, SqlDbType.Int) {

                        Direction = ParameterDirection.Output
                    };

                    Command.Parameters.Add(outputParameter);

                    try {

                        await Connection.OpenAsync();
                        await Command.ExecuteNonQueryAsync();

                        if (outputParameter.Value != DBNull.Value)
                            NewId = Convert.ToInt32(outputParameter.Value);
                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][Insert] Error: {ex}");
                        throw;
                    }
                }
            }

            return NewId;
        }

        // Update method to modify an existing record based on a given condition
        protected virtual async Task<bool> Update(string procedureName, Action<SqlCommand> parameterBuilder) {

            int RowAffected = 0;

            await using (var Connection = _databaseConnectionFactory.CreateConnection()) {

                await using (var Command = new SqlCommand(procedureName, Connection)) {

                    Command.CommandType = CommandType.StoredProcedure;
                    parameterBuilder(Command);

                    try {

                        await Connection.OpenAsync();
                        RowAffected = await Command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][Update] Error: {ex}");
                        throw;
                    }
                }
            }

            return RowAffected > 0;
        }

        // Delete method to remove a record based on a given condition
        protected virtual async Task<bool> Delete(string procedureName, string parameterName, object ParameterValue) {

            int RowAffected = 0;

            await using (var Connection = _databaseConnectionFactory.CreateConnection()) {

                await using (var Command = new SqlCommand(procedureName, Connection)) {

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue(parameterName ,ParameterValue ?? DBNull.Value);

                    try {

                        await Connection.OpenAsync();
                        RowAffected = await Command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][Delete] Error: {ex}");
                        throw;
                    }
                }
            }

            return RowAffected > 0;
        }

        // Is Exist method to check if a record exists based on a given condition
        protected virtual async Task<bool> IsExist(string procedureName, Action<SqlCommand> parameterBuilder) {

            int rowAffected = 0;

            await using (var Connection = _databaseConnectionFactory.CreateConnection()) {

                await using (var Command = new SqlCommand(procedureName, Connection)) {

                    Command.CommandType = CommandType.StoredProcedure;
                    parameterBuilder(Command);

                    try {

                        await Connection.OpenAsync();
                        object? result = await Command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                            rowAffected = Convert.ToInt32(result);
                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][IsExist] Error: {ex}");
                        throw;
                    }
                }
            }

            return rowAffected > 0;
        }

        // Is Active method to check if a record is active based on a given condition
        protected virtual async Task<bool> Active(string procedureName, string parameterName , object ParameterValue) {

            int RowAffected = 0;

            await using (var Connection = _databaseConnectionFactory.CreateConnection()) {

                await using (var Command = new SqlCommand(procedureName, Connection)) {

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue(parameterName, ParameterValue ?? DBNull.Value);

                    try {

                        await Connection.OpenAsync();
                        RowAffected = await Command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][Active] Error: {ex}");
                        throw;
                    }
                }
            }

            return RowAffected > 0;
        }
    }
}