using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Customer {

    [Serializable]
    public sealed class GetCustomerByIdResponse {  
        
        public int? CustomerId { get; init; }
        public string Name { get; init; } = null!;
        public string Phone { get; init; } = null!;
        public string? Email { get; init; }
        public int? AddressId { get; init; }
    }
}