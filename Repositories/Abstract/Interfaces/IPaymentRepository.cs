using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Abstract.Interfaces {

    public interface IPaymentRepository {

        Task<IEnumerable<PaymentViewModel>> GetAllPayments();
        Task<Payment?> GetPaymentById(int? PaymentId);
    }
}