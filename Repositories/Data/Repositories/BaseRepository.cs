using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Common {

    public abstract class BaseRepository<T> where T : class , IAddRepository<T>, IUpdateRepository<T> , IDeleteRepository<T> {

        protected BaseRepository() {


        }


        protected async Task<List<TResult>> GetList<TResult>(string query, Func<SqlDataReader, TResult> mapper) {
            
            var list = new List<TResult>();

            await using (var Connection = new SqlConnection()) {

                await using (var Command = new SqlCommand(query , Connection)) {

                    Command.CommandType = CommandType.Text;

                    try {

                        await Connection.OpenAsync();

                        await using (var Reader = await Command.ExecuteReaderAsync()) {

                            while (await Reader.ReadAsync()) {

                                list.Add(mapper(Reader));
                            }
                        }
                    }catch(Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][GetList] Error: {ex}");
                        throw;
                    }
                }
            }

            return list;
        }

        protected virtual async Task<T?> GetByValue(string procedureName, string parameterName, object? ParameterValue, Func<SqlDataReader, T> Mapper) {

            await using (var Connection = new SqlConnection()) {

                await using (var Command = new SqlCommand(procedureName, Connection)) {

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue(parameterName, ParameterValue);

                    try {

                        await Connection.OpenAsync();

                        await using(var Reader = await Command.ExecuteReaderAsync()) {

                            if(await Reader.ReadAsync())
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

        protected virtual async Task<int?> Insert(string procedureName, string outputParameterName, Action<SqlCommand> parameterBuilder) { return null; }

        protected virtual async Task<bool> Update(string procedureName, Action<SqlCommand> parameterBuilder) { return true; }

        protected virtual async Task<bool> Delete(string procedureName, string parameterName, object parameterValue) {

            int RowAffected = 0;

            await using (var Connection = new SqlConnection()) {

                await using (var Command = new SqlCommand(procedureName, Connection)) {

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue(parameterName, parameterValue);

                    try {

                        await Connection.OpenAsync();
                        RowAffected = await Command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex) {

                        Console.Error.WriteLine($"[{typeof(T).Name}Repository][Delete] Error: {ex}");
                        throw;
                    }
                }

                return RowAffected > 0;
            }
        }
    }
}