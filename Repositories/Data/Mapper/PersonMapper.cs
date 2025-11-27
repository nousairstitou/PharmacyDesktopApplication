using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using Repositories.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Data.Mapper {

    public class PersonMapper : IEntityMapper<Person> {

        public Person Map(SqlDataReader Reader) {

            return new Person {

                PersonId = Reader.GetInt32(Reader.GetOrdinal("PersonId")),
                Name = Reader.GetString(Reader.GetOrdinal("Name")),
                Phone = Reader.GetString(Reader.GetOrdinal("Phone")),
                Email = Reader.IsDBNull(Reader.GetOrdinal("Email")) ? null : Reader.GetString(Reader.GetOrdinal("Email")),
                AddressId = Reader.GetInt32(Reader.GetOrdinal("AddressId"))
            }; 
        }
    }
}