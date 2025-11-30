using Business.Abstract.Common;
using Business.DTOs.Request.Sale;
using Business.DTOs.Response.Sale;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Abstract.Interfaces {

    public interface ISaleService : IAddService<CreateSaleRequest> , IDeleteService {

        Task<GetAllSalesResponse> GetAllSales();
        Task<GetSaleByIdResponse?> GetSaleById(int? SaleId);
    }
}