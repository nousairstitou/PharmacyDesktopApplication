using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Repositories {

    public class CustomerRepository : BaseRepository<Customer> , ICustomerRepository {

        private readonly IEntityMapper<Customer> _customerMapper;
        private readonly IViewMapper<CustomerViewModel> _ViewMapper;

        public CustomerRepository(IDatabaseConnectionFactory databaseConnectionFactory , IEntityMapper<Customer> customerMapper,
            IViewMapper<CustomerViewModel> ViewMapper) : base(databaseConnectionFactory) {

            _customerMapper = customerMapper ?? throw new ArgumentNullException(nameof(customerMapper));
            _ViewMapper = ViewMapper ?? throw new ArgumentNullException(nameof(ViewMapper));
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomers() {

            return await GetList("SELECT * FROM vw_GetAllCustomers", _ViewMapper.MapToView);
        }

        public async Task<Customer?> GetCustomerById(int? CustomerId) {

            return await GetByValue("sp_GetCustomerById", "@CustomerId" ,CustomerId ?? (object)DBNull.Value , _customerMapper.Map);
        }

        public async Task<int?> Add(Customer customer) {

            return await Insert("sp_AddCustomer", "@NewCustomerId", parameter => {

                parameter.Parameters.AddWithValue("@City", customer.PersonAddress?.City);
                parameter.Parameters.AddWithValue("@Street", customer.PersonAddress?.Street);
                parameter.Parameters.AddWithValue("@BuildingNumber", customer.PersonAddress?.BuildingNumber);
                parameter.Parameters.AddWithValue("@DepartmentNumber", customer.PersonAddress?.DepartmentNumber);
                parameter.Parameters.AddWithValue("@ZipCode", customer.PersonAddress?.ZipCode ?? (object)DBNull.Value);
                parameter.Parameters.AddWithValue("@Name", customer.Name);
                parameter.Parameters.AddWithValue("@Phone", customer.Phone);
                parameter.Parameters.AddWithValue("@Email", customer.Email ?? (object)DBNull.Value);
            });
        }

        public async Task<bool> Update(int CustomerId ,Customer customer) {

            return await Update("sp_UpdateCustomer", parameter => {

                parameter.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                parameter.Parameters.AddWithValue("@Name", customer.Name);
                parameter.Parameters.AddWithValue("@Phone", customer.Phone);
                parameter.Parameters.AddWithValue("@Email", customer.Email ?? (object)DBNull.Value);
                parameter.Parameters.AddWithValue("@Street", customer?.PersonAddress?.Street);
                parameter.Parameters.AddWithValue("@BuildingNumber", customer?.PersonAddress?.BuildingNumber);
                parameter.Parameters.AddWithValue("@DepartmentNumber", customer?.PersonAddress?.DepartmentNumber);
            });
        }

        public async Task<bool> Delete(int CustomerId) {

            return await Delete("sp_DeleteCustomer", "@CustomerId", CustomerId);
        }
    }
}