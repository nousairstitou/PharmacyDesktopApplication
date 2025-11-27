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

    public class SupplierValidator : IServiceValidator<CreateSupplierRequest , UpdateSupplierRequest> {

        private readonly ISupplierRepository _SupplierRepository;

        public SupplierValidator(ISupplierRepository SupplierRepository) {

            _SupplierRepository = SupplierRepository ?? throw new ArgumentNullException(nameof(SupplierRepository));
        }

        public async Task ValidateCreate(CreateSupplierRequest request) {

            if (await _SupplierRepository.PhoneSupplierExists(request.SupplierPhone))
                throw new ArgumentNullException("Supplier Number already Exists");

            if (await _SupplierRepository.PhoneSupplierExists(request.SupplierEmail))
                throw new ArgumentNullException("Supplier Email already Exists");
        }

        public async Task ValidateUpdate(UpdateSupplierRequest request) {
            
            var Supplier = await _SupplierRepository.GetSupplierById(request.SupplierId);

            if(Supplier is null)
                throw new ArgumentNullException("Supplier does not exist.");

            if (Supplier.IsDeleted)
                throw new ArgumentNullException("Supplier already deleted.");
        }

        public async Task ValidateDelete(int SupplierId) {

            var Supplier = await _SupplierRepository.GetSupplierById(SupplierId);

            if (Supplier is null)
                throw new ArgumentNullException("Supplier does not exist.");

            if(Supplier.IsDeleted)
                throw new ArgumentNullException("Supplier already deleted.");
        }
    }
}