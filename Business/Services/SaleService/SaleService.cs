using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Sale;
using Business.DTOs.Response.Sale;
using Models;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.SaleService {

    public sealed class SaleService : ISaleService {

        private readonly ISaleRepository _SaleRepository;
        private readonly IEntityMapper<CreateSaleRequest ,TransactionSale> _EntityMapper;
        private readonly IEntityToResponseMapper<GetSaleByIdResponse , Sale> _EntityToResponse;
        private readonly IAddServiceValidator<CreateSaleRequest> _AddValidator;
        private readonly IDeleteServiceValidator _DeleteValidator;
   
        public SaleService(ISaleRepository SaleRepository , IEntityMapper<CreateSaleRequest, TransactionSale> EntityMapper ,
            IEntityToResponseMapper<GetSaleByIdResponse, Sale> EntityToResponse , IAddServiceValidator<CreateSaleRequest> AddValidator,
            IDeleteServiceValidator DeleteValidator) {

            _SaleRepository = SaleRepository ?? throw new ArgumentNullException(nameof(SaleRepository));
            _EntityMapper = EntityMapper ?? throw new ArgumentNullException(nameof(EntityMapper));
            _EntityToResponse = EntityToResponse ?? throw new ArgumentNullException(nameof(EntityToResponse));
            _AddValidator = AddValidator ?? throw new ArgumentNullException(nameof(AddValidator));
            _DeleteValidator = DeleteValidator ?? throw new ArgumentNullException(nameof(DeleteValidator));
        }

        public async Task<GetAllSalesResponse> GetAllSales() {

            var sales = await _SaleRepository.GetAllSales();
            return new GetAllSalesResponse(sales);
        }

        public async Task<GetSaleByIdResponse?> GetSaleById(int? SaleId) {

            var sale = await _SaleRepository.GetSaleById(SaleId);
            return _EntityToResponse.Map(sale);
        }

        public async Task<int?> Add(CreateSaleRequest request) {

            var result = await _AddValidator.ValidateCreate(request);

            if (!result.IsSuccess)
                return null;

            return await _SaleRepository.Add(_EntityMapper.Map(request));
        }

        public async Task<bool> Delete(int SaleId) {

            var result = await _DeleteValidator.ValidateDelete(SaleId);

            if(!result.IsSuccess)
                return false;

            return await _SaleRepository.Delete(SaleId);
        }
    }
}