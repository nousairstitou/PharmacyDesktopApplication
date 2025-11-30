using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.DTOs.Response.Customer {

    public sealed record GetAllCustomersResponse(IEnumerable<CustomerViewModel> ViewModels);
}