using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Customer;
using Business.DTOs.Response.Customer;
using Microsoft.VisualBasic;
using Models;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Validation.CustomerValidation {

    public class CustomerValidator : IServiceValidator<CreateCustomerRequest, UpdateCustomerRequest> {

        private readonly ICustomerRepository _CustomerRepository;
        private readonly IPersonRepository _PersonRepository;

        public CustomerValidator(ICustomerRepository customerRepo, IPersonRepository personRepo) {

            _CustomerRepository = customerRepo ?? throw new ArgumentNullException(nameof(customerRepo));
            _PersonRepository = personRepo ?? throw new ArgumentNullException(nameof(personRepo));
        }

        public async Task ValidateCreate(CreateCustomerRequest request) {

            if (await _PersonRepository.PhoneExists(request.Phone))
                throw new ArgumentNullException("Phone already exists");

            if (await _PersonRepository.EmailExists(request.Email))
                throw new ArgumentNullException("Email already exists");
        }

        public async Task ValidateUpdate(UpdateCustomerRequest request) {

            var customer = await _CustomerRepository.GetCustomerById(request.CustomerId);

            if (customer is null)
                throw new ArgumentNullException("Customer does not exist");

            if (customer.IsDeleted)
                throw new ArgumentNullException("Customer is deleted");
        }

        public async Task ValidateDelete(int CustomerId) {

            var customer = await _CustomerRepository.GetCustomerById(CustomerId);

            if (customer is null)
                throw new ArgumentNullException("Customer does not exist");

            if (customer.IsDeleted)
                throw new ArgumentNullException("Customer already deleted");
        }
    }
}