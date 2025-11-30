using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Response.Payment;
using Business.Validation.CategoryValidation;
using Models;
using Repositories.Abstract.Interfaces;
using Repositories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Services.PaymentService {

    public sealed class PaymentService : IPaymentService {

        private readonly IPaymentRepository _PaymentRepository;
        private readonly IEntityToResponseMapper<GetPaymentByIdResponse, Payment> _EntityToResponse;

        public PaymentService(IPaymentRepository PaymentRepository , IEntityToResponseMapper<GetPaymentByIdResponse, Payment> EntityToResponse) {

            _PaymentRepository = PaymentRepository ?? throw new Exception(nameof(PaymentRepository));
            _EntityToResponse = EntityToResponse ?? throw new Exception(nameof(EntityToResponse));
        }

        public async Task<GetAllPaymentsResponse> GetAllPayments() {

            var payments = await _PaymentRepository.GetAllPayments();
            return new GetAllPaymentsResponse(payments);
        }

        public async Task<GetPaymentByIdResponse?> GetPaymentById(int PaymentId) {

            var payment = await _PaymentRepository.GetPaymentById(PaymentId);
            return _EntityToResponse.Map(payment);
        }
    }
}