using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Interfaces {
    
    public interface IPersonRepository {

        Task<Person?> GetPersonById(int? PersonId);
        Task<bool> PhoneExists(string Phone);
        Task<bool> EmailExists(string? Email);
    }
}