using Business.Abstract.Common;
using Business.DTOs.Response.Payment;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.PaymentMapper {

    public sealed class GetPaymentByIdToResponseMapper : IEntityToResponseMapper<GetPaymentByIdResponse , Payment> {

        public GetPaymentByIdResponse Map(Payment payment) {

            return new GetPaymentByIdResponse {

                PaymentId = payment.PaymentId,
                SaleId = payment.SaleId,
                PaymentMethodId = payment.PaymentMethodId,
                PaymentDate = payment.PaymentDate,
                AmountPaid = payment.AmountPaid,
                PaymentStatus = payment.Status
            };
        }
    }
}