using Azure.Core;
using Business.Abstract.Common;
using Business.DTOs.Request.Customer;
using Business.DTOs.Response.Customer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Abstract.Interfaces {

    public interface ICustomerService : 
        IAddService<CreateCustomerRequest> , 
        IUpdateService<UpdateCustomerRequest> , 
        IDeleteService {

        Task<IEnumerable<CustomerViewModel>> GetAllCustomers();
        Task<GetCustomerByIdResponse?> GetCustomerById(int? CustomerId);
    }
}