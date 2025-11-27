using Business.Abstract.Common;
using Business.DTOs.Response.Customer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.CustomerMapper {

    public sealed class GetCustomerByIdToResponseMapper : IEntityToResponseMapper<GetCustomerByIdResponse , Customer> {

        public GetCustomerByIdResponse Map(Customer customer) {

            return new GetCustomerByIdResponse {

                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email,
                AddressId = customer.AddressId,
            };
        }
    }
}