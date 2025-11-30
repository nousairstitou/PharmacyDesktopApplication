using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Response.Billing;
using Business.DTOs.Response.Payment;
using Business.Mapper.BillingMapper;
using Business.Validation.CustomerValidation;
using Models;
using Repositories.Abstract.Interfaces;
using Repositories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Services.BillingService {

    public sealed class BillingService : IBillingService {

        private readonly IBillingRepository _BillingRepository;
        private readonly IEntityToResponseMapper<GetBillingByIdResponse, Billing> _entityToResponse;

        public BillingService(IBillingRepository BillingRepository , IEntityToResponseMapper<GetBillingByIdResponse, Billing> entityToResponse) {

            _BillingRepository = BillingRepository ?? throw new ArgumentNullException(nameof(BillingRepository));
            _entityToResponse = entityToResponse ?? throw new ArgumentNullException(nameof(entityToResponse));
        }

        public async Task<GetAllBillingsResponse> GetAllBillings() {

            var billing = await _BillingRepository.GetAllBillings();
            return new GetAllBillingsResponse(billing);
        }

        public async Task<GetBillingByIdResponse?> GetBillingById(int BillingId) {

            var billing = await _BillingRepository.GetBillingById(BillingId);
            return _entityToResponse.Map(billing);
        }
    }
}