using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.DTOs.Response.Sale {

    public sealed record GetAllSalesResponse(IEnumerable<SaleViewModel> ViewModels);
}