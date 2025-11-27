using Business.Mapper.BillingMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Interfaces {

    public interface IBillingService {

        Task<IEnumerable<Billing>> GetAllBillings();
        Task<GetBillingByIdToResponseMapper> GetBillingById(int BillingId);
    }
}