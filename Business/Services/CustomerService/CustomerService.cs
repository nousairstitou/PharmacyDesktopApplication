using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Customer;
using Business.DTOs.Response.Customer;
using Business.Mapper.CustomerMapper;
using Business.Validation.CustomerValidation;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Services.CustomerService {

    public class CustomerService : ICustomerService {

        private readonly ICustomerRepository _CustomerRepository;
        private readonly IEntityMapper<CreateCustomerRequest, Customer> _CreateEntityMapper;
        private readonly IEntityMapper<UpdateCustomerRequest, Customer> _UpdateEntityMapper;
        private readonly IEntityToResponseMapper<GetCustomerByIdResponse, Customer> _EntityToResponse;
        private readonly IServiceValidator<CreateCustomerRequest ,UpdateCustomerRequest> _CustomerValidator;

        public CustomerService(ICustomerRepository CustomerRepository , IEntityMapper<CreateCustomerRequest, Customer> CreateEntityMapper , 
            IEntityMapper<UpdateCustomerRequest, Customer> UpdateEntityMapper , 
            IEntityToResponseMapper<GetCustomerByIdResponse,Customer> EntityToResponse,
            IServiceValidator<CreateCustomerRequest, UpdateCustomerRequest> CustomerValidator) {

            _CustomerRepository = CustomerRepository ?? throw new ArgumentNullException(nameof(CustomerRepository));
            _CreateEntityMapper = CreateEntityMapper ?? throw new ArgumentNullException(nameof(CreateEntityMapper));
            _UpdateEntityMapper = UpdateEntityMapper ?? throw new ArgumentNullException(nameof(UpdateEntityMapper));
            _EntityToResponse = EntityToResponse ?? throw new ArgumentNullException(nameof(EntityToResponse));
            _CustomerValidator = CustomerValidator ?? throw new ArgumentNullException(nameof(CustomerValidator));
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomers() {

            return await _CustomerRepository.GetAllCustomers();
        }

        public async Task<GetCustomerByIdResponse?> GetCustomerById(int? CustomerId) {

            var customer = await _CustomerRepository.GetCustomerById(CustomerId);
            return _EntityToResponse.Map(customer);
        }

        public async Task<int?> Add(CreateCustomerRequest request) {

            await _CustomerValidator.ValidateCreate(request);
            return await _CustomerRepository.Add(_CreateEntityMapper.Map(request));
        }

        public async Task<bool> Update(int CustomerId , UpdateCustomerRequest request) { 
            
            await _CustomerValidator.ValidateUpdate(request);
            return await _CustomerRepository.Update(CustomerId, _UpdateEntityMapper.Map(request)); 
        }

        public async Task<bool> Delete(int CustomerId) {
            
            await _CustomerValidator.ValidateDelete(CustomerId);
            return await _CustomerRepository.Delete(CustomerId);
        }
    }
}