using System.ComponentModel.DataAnnotations;

namespace Business.DTOs.Request.Category {

    [Serializable]
    public sealed record UpdateCategoryRequest {

        public int? CategoryId { get; init; }

        [Required(ErrorMessage = "CategoryName is required")]
        [MaxLength(100, ErrorMessage = "CategoryName cannot exceed 100 characters")]
        public string CategoryName { get; init; } = null!;

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; init; }

        [Required(ErrorMessage = "CreatedBy is required")]
        public int CreatedBy { get; init; }

        [MaxLength(255)]
        public string? Description { get; init; }
    }
}