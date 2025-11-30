using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.DTOs.Response.Billing {

    public sealed class GetAllBillingsResponse(IEnumerable<BillingViewModel> ViewModels);
}