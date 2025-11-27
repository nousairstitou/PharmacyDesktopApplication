using Business.Mapper.BillingMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Interfaces {

    public interface IPaymentService {

        Task<IEnumerable<Payment>> GetAllPayments();
        Task<Payment?> GetPaymentById(int PaymentId);
    }
}