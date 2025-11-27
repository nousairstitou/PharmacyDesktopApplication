using Models;
using Repositories.Abstract.Common;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Data.Repositories {

    public class PersonRepository : BaseRepository<Person> , IPersonRepository {

        private readonly IEntityMapper<Person> _PersonMapper;

        public PersonRepository(IDatabaseConnectionFactory databaseConnectionFactory , IEntityMapper<Person> PersonMapper) : base(databaseConnectionFactory) {
        
            _PersonMapper = PersonMapper ?? throw new ArgumentNullException(nameof(PersonMapper));
        }

        public async Task<Person?> GetPersonById(int? PersonId) {

            return await GetByValue("sp_GetPersonById", "@PersonId" , PersonId , _PersonMapper.Map);
        }

        public async Task<bool> PhoneExists(string Phone) {

            return await IsExist("sp_PhoneExists", parameter => {

                parameter.Parameters.AddWithValue("@Phone" , Phone);
            });
        }

        public async Task<bool> EmailExists(string? Email) {

            return await IsExist("sp_EmailExists", parameter => {

                parameter.Parameters.AddWithValue("@Email", Email);
            });
        }
    }
}