using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Data.Mapper {


    public class CustomerMapper : IEntityMapper<Customer> {

        public Customer Map (SqlDataReader Reader) {

            return new Customer {

                CustomerId = Reader.GetInt32(Reader.GetOrdinal("CustomerId")),
                PersonId = Reader.GetInt32(Reader.GetOrdinal("PersonId")),
            };
        }
    }
}