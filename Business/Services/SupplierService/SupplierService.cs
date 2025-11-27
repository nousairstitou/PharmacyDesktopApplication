using Azure.Core;
using Business.Abstract.Common;
using Business.Abstract.Interfaces;
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
        private readonly IServiceValidator<CreateSupplierRequest , UpdateSupplierRequest> _SupplierValidator;

        public SupplierService(ISupplierRepository supplierRepository , IEntityMapper<CreateSupplierRequest, Supplier> CreateEntityMapper,
            IEntityMapper<UpdateSupplierRequest, Supplier> UpdateEntityMapper, IEntityToResponseMapper<GetSupplierByIdResponse, Supplier> EntityToResponse ,
            IServiceValidator<CreateSupplierRequest, UpdateSupplierRequest> SupplierValidator) {
            
            _supplierRepository = supplierRepository ?? throw new ArgumentNullException(nameof(supplierRepository));
            _CreateEntityMapper = CreateEntityMapper ?? throw new ArgumentNullException(nameof(CreateEntityMapper));
            _UpdateEntityMapper = UpdateEntityMapper ?? throw new ArgumentNullException(nameof(UpdateEntityMapper));
            _EntityToResponse = EntityToResponse ?? throw new ArgumentNullException(nameof(EntityToResponse));
            _SupplierValidator = SupplierValidator ?? throw new ArgumentNullException(nameof(SupplierValidator));
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSuppliers() {

            return await _supplierRepository.GetAllSuppliers();
        }

        public async Task<GetSupplierByIdResponse?> GetSupplierById(int? SupplierId) {

            var Supplier = await _supplierRepository.GetSupplierById(SupplierId);
            return _EntityToResponse.Map(Supplier);
        }

        public async Task<int?> Add(CreateSupplierRequest request) {

            await _SupplierValidator.ValidateCreate(request);
            return await _supplierRepository.Add(_CreateEntityMapper.Map(request));
        }

        public async Task<bool> Update(int SupplierId, UpdateSupplierRequest request) {

            await _SupplierValidator.ValidateUpdate(request);
            return await _supplierRepository.Update(SupplierId, _UpdateEntityMapper.Map(request));
        }

        public async Task<bool> Delete(int SupplierId) {

            await _SupplierValidator.ValidateDelete(SupplierId);
            return await _supplierRepository.Delete(SupplierId);
        }
    }
}