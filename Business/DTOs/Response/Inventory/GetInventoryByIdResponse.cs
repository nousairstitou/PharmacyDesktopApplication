using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Inventory {

    public sealed record GetInventoryByIdResponse {

        public int? InventoryId { get; init; }
        public string InventoryName { get; init; } = null!;
        public string Location { get; init; } = null!;
        public int Capacity { get; init; }
    }
}