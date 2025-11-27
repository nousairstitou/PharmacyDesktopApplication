using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs.Request.Category {

    public sealed record CreateCategoryRequest {

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; init; } = null!;
        
        [Required]
        public bool IsActive { get; init; }
       
        [Required]
        public int CreatedBy { get; init; }

        [MaxLength(255)]
        public string? Description { get; init; }
    }
}