using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.DTOs.Response.Inventory {
    
    public sealed record GetAllInventoriesResponse(IEnumerable<InventoryViewModel> ViewModels);
}