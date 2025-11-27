using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Mapper {

    public class CustomerMapper : IEntityMapper<Customer> , IViewMapper<CustomerViewModel> {

        public Customer Map (SqlDataReader Reader) {

            return new Customer {

                CustomerId = Reader.GetInt32(Reader.GetOrdinal("CustomerId")),
                PersonId = Reader.GetInt32(Reader.GetOrdinal("PersonId")),
                Name = Reader.GetString(Reader.GetOrdinal("Name")),
                Phone = Reader.GetString(Reader.GetOrdinal("Phone")),
                Email = Reader.IsDBNull(Reader.GetOrdinal("Email")) ? null : Reader.GetString(Reader.GetOrdinal("Email")),
                AddressId = Reader.IsDBNull(Reader.GetOrdinal("AddressId")) ? null : Reader.GetInt32(Reader.GetOrdinal("AddressId"))
            };
        }

        public CustomerViewModel MapToView(SqlDataReader Reader) {

            return new CustomerViewModel {

                CustomerId = Reader.GetInt32(Reader.GetOrdinal("CustomerId")),
                Name = Reader.GetString(Reader.GetOrdinal("Name")),
                Phone = Reader.GetString(Reader.GetOrdinal("Phone")),
                Email = Reader.IsDBNull(Reader.GetOrdinal("Email")) ? null : Reader.GetString(Reader.GetOrdinal("Email")),
                Street = Reader.GetString(Reader.GetOrdinal("Street")),
                BuildingNumber = Reader.GetInt32(Reader.GetOrdinal("BuildingNumber")),
                DepartmentNumber = Reader.GetInt32(Reader.GetOrdinal("DepartmentNumber")),
            };
        }
    }
}