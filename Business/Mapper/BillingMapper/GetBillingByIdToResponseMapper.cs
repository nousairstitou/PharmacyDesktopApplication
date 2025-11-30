using Business.Abstract.Common;
using Business.DTOs.Response.Billing;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.BillingMapper {

    public sealed class GetBillingByIdToResponseMapper : IEntityToResponseMapper<GetBillingByIdResponse , Billing> {

        public GetBillingByIdResponse Map(Billing entity) {

            return new GetBillingByIdResponse {

                BillingId = entity.BillingId,
                BillingDate = entity.BillingDate,
                CreatedBy = entity.CreatedBy,
                Note = entity.Note,
                PaymentId = entity.PaymentId,
                status = entity.Status
            };
        }
    }
}