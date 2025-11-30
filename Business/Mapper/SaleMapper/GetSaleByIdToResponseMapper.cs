using Business.Abstract.Common;
using Business.DTOs.Response.Sale;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.SaleMapper {

    public sealed class GetSaleByIdToResponseMapper : IEntityToResponseMapper<GetSaleByIdResponse , Sale> {

        public GetSaleByIdResponse Map(Sale sale) {

            return new GetSaleByIdResponse {

                SaleId = sale.SaleId,
                CustomerId = sale.CustomerId,
                SaleDate = sale.SaleDate,
                Note = sale.Note,
                Status = sale.Status,
                TotalAmount = sale.TotalAmount
            };
        }
    }
}