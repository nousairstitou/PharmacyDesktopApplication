using Azure.Core;
using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Category;
using Business.DTOs.Request.Customer;
using Business.DTOs.Request.Inventory;
using Business.DTOs.Request.Supplier;
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

    public class CustomerValidator : IAddServiceValidator<CreateCustomerRequest>,
        IUpdateServiceValidator<UpdateCustomerRequest>, IDeleteServiceValidator {

        private readonly ICustomerRepository _CustomerRepository;
        private readonly IPersonRepository _PersonRepository;

        public CustomerValidator(ICustomerRepository customerRepo, IPersonRepository personRepo) {

            _CustomerRepository = customerRepo ?? throw new ArgumentNullException(nameof(customerRepo));
            _PersonRepository = personRepo ?? throw new ArgumentNullException(nameof(personRepo));
        }

        public async Task<Result<CreateCustomerRequest>> ValidateCreate(CreateCustomerRequest request) {

            if (await _PersonRepository.PhoneExists(request.Phone))
                return Result<CreateCustomerRequest>.Failure("Phone already exists");

            if (await _PersonRepository.EmailExists(request.Email))
                return Result<CreateCustomerRequest>.Failure("Email already exists");

            return Result<CreateCustomerRequest>.Success(request);
        }

        public async Task<Result<UpdateCustomerRequest>> ValidateUpdate(UpdateCustomerRequest request) {

            var customer = await _CustomerRepository.GetCustomerById(request.CustomerId);

            if (customer is null)
                return Result<UpdateCustomerRequest>.Failure("Customer does not exist");

            if (customer.IsDeleted)
                return Result<UpdateCustomerRequest>.Failure("Customer is deleted");

            return Result<UpdateCustomerRequest>.Success(request);
        }

        public async Task<Result<bool>> ValidateDelete(int CustomerId) {

            var customer = await _CustomerRepository.GetCustomerById(CustomerId);

            if (customer is null)
                return Result<bool>.Failure("Customer does not exist");

            if (customer.IsDeleted)
                return Result<bool>.Failure("Customer already deleted");

            return Result<bool>.Success(true);
        }
    }
}