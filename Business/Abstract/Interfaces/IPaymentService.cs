using Business.DTOs.Response.Payment;
using Business.Mapper.BillingMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Abstract.Interfaces {

    public interface IPaymentService {

        Task<GetAllPaymentsResponse> GetAllPayments();
        Task<GetPaymentByIdResponse?> GetPaymentById(int PaymentId);
    }
}