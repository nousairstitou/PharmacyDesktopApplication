using Azure.Core;
using Business.Abstract.Common;
using Business.DTOs.Request.Supplier;
using Microsoft.VisualBasic;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.SupplierValidation {

    public class SupplierValidator : IAddServiceValidator<CreateSupplierRequest> , 
        IUpdateServiceValidator<UpdateSupplierRequest>, IDeleteServiceValidator {

        private readonly ISupplierRepository _SupplierRepository;

        public SupplierValidator(ISupplierRepository SupplierRepository) {

            _SupplierRepository = SupplierRepository ?? throw new ArgumentNullException(nameof(SupplierRepository));
        }

        public async Task<Result<CreateSupplierRequest>> ValidateCreate(CreateSupplierRequest request) {

            if (await _SupplierRepository.PhoneSupplierExists(request.SupplierPhone))
                return Result<CreateSupplierRequest>.Failure("Supplier Number already Exists");

            if (await _SupplierRepository.PhoneSupplierExists(request.SupplierEmail))
                return Result<CreateSupplierRequest>.Failure("Supplier Email already Exists");

            return Result<CreateSupplierRequest>.Success(request);
        }

        public async Task<Result<UpdateSupplierRequest>> ValidateUpdate(UpdateSupplierRequest request) {
            
            var Supplier = await _SupplierRepository.GetSupplierById(request.SupplierId);

            if(Supplier is null)
                return Result<UpdateSupplierRequest>.Failure("Supplier does not exist.");

            if (Supplier.IsDeleted)
                return Result<UpdateSupplierRequest>.Failure("Supplier already deleted.");

            return Result<UpdateSupplierRequest>.Success(request);
        }

        public async Task<Result<bool>> ValidateDelete(int SupplierId) {

            var Supplier = await _SupplierRepository.GetSupplierById(SupplierId);

            if (Supplier is null)
                return Result<bool>.Failure("Supplier does not exist.");

            if (Supplier.IsDeleted)
                return Result<bool>.Failure("Supplier already deleted.");

            return Result<bool>.Success(true);
        }
    }
}