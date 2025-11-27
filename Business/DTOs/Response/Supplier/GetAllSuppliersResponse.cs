using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.DTOs.Response.Supplier {

    public sealed record GetAllSuppliersResponse (IEnumerable<SupplierViewModel> ViewModels);
}