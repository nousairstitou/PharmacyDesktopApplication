using Business.DTOs.Response.Billing;
using Business.Mapper.BillingMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Abstract.Interfaces {

    public interface IBillingService {

        Task<GetAllBillingsResponse> GetAllBillings();
        Task<GetBillingByIdResponse?> GetBillingById(int BillingId);
    }
}