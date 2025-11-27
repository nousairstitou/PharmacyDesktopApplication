using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Abstract.Interfaces {

    public interface ICustomerRepository : IAddRepository<Customer>,
        IUpdateRepository<Customer>,
        IDeleteRepository<Customer> {

        Task<IEnumerable<CustomerViewModel>> GetAllCustomers();
        Task<Customer?> GetCustomerById(int? CustomerId);
    }
}