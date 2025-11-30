using Azure.Core;
using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Sale;
using Business.DTOs.Request.Supplier;
using Business.DTOs.Response.Category;
using Business.DTOs.Response.Supplier;
using Business.Validation.SupplierValidation;
using Models;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Services.SupplierService {

    public class SupplierService : ISupplierService {

        private readonly ISupplierRepository _supplierRepository;
        private readonly IEntityMapper<CreateSupplierRequest, Supplier> _CreateEntityMapper;
        private readonly IEntityMapper<UpdateSupplierRequest, Supplier> _UpdateEntityMapper;
        private readonly IEntityToResponseMapper<GetSupplierByIdResponse, Supplier> _EntityToResponse;
        private readonly IAddServiceValidator<CreateSupplierRequest> _AddValidator;
        private readonly IUpdateServiceValidator<UpdateSupplierRequest> _UpdateValidator;
        private readonly IDeleteServiceValidator _DeleteValidator;

        public SupplierService(ISupplierRepository supplierRepository , IEntityMapper<CreateSupplierRequest, Supplier> CreateEntityMapper,
            IEntityMapper<UpdateSupplierRequest, Supplier> UpdateEntityMapper, IEntityToResponseMapper<GetSupplierByIdResponse, Supplier> EntityToResponse ,
            IAddServiceValidator<CreateSupplierRequest> AddValidator , IUpdateServiceValidator<UpdateSupplierRequest> UpdateValidator,
            IDeleteServiceValidator DeleteValidator) {
            
            _supplierRepository = supplierRepository ?? throw new ArgumentNullException(nameof(supplierRepository));
            _CreateEntityMapper = CreateEntityMapper ?? throw new ArgumentNullException(nameof(CreateEntityMapper));
            _UpdateEntityMapper = UpdateEntityMapper ?? throw new ArgumentNullException(nameof(UpdateEntityMapper));
            _EntityToResponse = EntityToResponse ?? throw new ArgumentNullException(nameof(EntityToResponse));
            _AddValidator = AddValidator ?? throw new ArgumentNullException(nameof(AddValidator));
            _UpdateValidator = UpdateValidator ?? throw new ArgumentNullException(nameof(UpdateValidator));
            _DeleteValidator = DeleteValidator ?? throw new ArgumentNullException(nameof(DeleteValidator));
        }

        public async Task<GetAllSuppliersResponse> GetAllSuppliers() {

            var Supplier = await _supplierRepository.GetAllSuppliers();
            return new GetAllSuppliersResponse(Supplier);
        }

        public async Task<GetSupplierByIdResponse?> GetSupplierById(int? SupplierId) {

            var Supplier = await _supplierRepository.GetSupplierById(SupplierId);
            return _EntityToResponse.Map(Supplier);
        }

        public async Task<int?> Add(CreateSupplierRequest request) {

            var result = await _AddValidator.ValidateCreate(request);

            if (!result.IsSuccess)
                return null;

            return await _supplierRepository.Add(_CreateEntityMapper.Map(request));
        }

        public async Task<bool> Update(int SupplierId, UpdateSupplierRequest request) {

            var result = await _UpdateValidator.ValidateUpdate(request);

            if (!result.IsSuccess)
                return false;

            return await _supplierRepository.Update(SupplierId, _UpdateEntityMapper.Map(request));
        }

        public async Task<bool> Delete(int SupplierId) {

            var result = await _DeleteValidator.ValidateDelete(SupplierId);

            if (!result.IsSuccess)
                return false;

            return await _supplierRepository.Delete(SupplierId);
        }
    }
}