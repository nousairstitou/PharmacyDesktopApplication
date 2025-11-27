using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels {

    public sealed record CustomerViewModel  {

        public int CustomerId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string? Email { get; init; }
        public string Street { get; init; } = string.Empty;
        public int BuildingNumber { get; init; }
        public int DepartmentNumber { get; init; }
    }
}