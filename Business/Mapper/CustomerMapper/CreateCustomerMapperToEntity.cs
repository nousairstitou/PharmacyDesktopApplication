using Business.Abstract.Common;
using Business.DTOs.Request.Customer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.CustomerMapper {

    public sealed class CreateCustomerMapperToEntity : IEntityMapper<CreateCustomerRequest , Customer> {

        public Customer Map(CreateCustomerRequest request) {

            return new Customer {

                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email,
                AddressId = request.AddressId
            };
        }
    }
}