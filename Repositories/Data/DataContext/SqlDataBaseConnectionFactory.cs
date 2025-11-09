using Microsoft.Data.SqlClient;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Data.DataContext {

    public class SqlDataBaseConnectionFactory : IDatabaseConnectionFactory {

        private readonly string _connectionString;

        public SqlDataBaseConnectionFactory(string connectionString) {

            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection() {

            return new SqlConnection(_connectionString);
        }
    }
}