using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Category {

    [Serializable]
    public sealed record GetCategoryByIdResponse {

        public int? CategoryId { get; init; }
        public string CategoryName { get; init; } = null!;
        public bool IsActive { get; init; }
        public int? CreatedBy { get; init; }
        public string? Description { get; init; }
    }
}