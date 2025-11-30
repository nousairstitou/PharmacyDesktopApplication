using Business.Abstract.Common;
using Business.DTOs.Request.Sale;
using Microsoft.VisualBasic;
using Models;
using Repositories.Abstract.Interfaces;
using Repositories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.SaleValidation {

    public class SaleValidator : IAddServiceValidator<CreateSaleRequest> , IDeleteServiceValidator {

        private readonly ISaleRepository _SaleRepository;

        public SaleValidator(ISaleRepository SaleRepo) {

            _SaleRepository = SaleRepo ?? throw new ArgumentNullException(nameof(SaleRepo));
        }

        public async Task<Result<CreateSaleRequest>> ValidateCreate(CreateSaleRequest request) {

            if(request.AmountPaid < 0)
                return Result<CreateSaleRequest>.Failure("Amount paid cannot be negative");

            if (request.SaleItems is null || !request.SaleItems.Any())
                return Result<CreateSaleRequest>.Failure("Sale must contain at least one item.");

            foreach (var item in request.SaleItems) {

                if (item.Quantity <= 0)
                    return Result<CreateSaleRequest>.Failure("Quantity must be greater than zero.");

                if (item.UnitPrice <= 0)
                    return Result<CreateSaleRequest>.Failure("Unit price must be greater than zero.");
            }

            return Result<CreateSaleRequest>.Success(request);
        }

        public async Task<Result<bool>> ValidateDelete(int SaleId) {

            var sale = await _SaleRepository.GetSaleById(SaleId);

            if (sale is null)
                return Result<bool>.Failure("Sale does not exist");

            if (sale.IsDeleted)
                return Result<bool>.Failure("Sale is already deleted");

            return Result<bool>.Success(true);
        }
    }
}