using Azure.Core;
using Business.Abstract.Common;
using Business.DTOs.Request.Category;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.CategoryValidation {
    
    public class CategoryValidator : IServiceValidator<CreateCategoryRequest , UpdateCategoryRequest> {

        private readonly ICategoryRepository _CategoryRepository;

        public CategoryValidator(ICategoryRepository CategoryRepository) {

            CategoryRepository = CategoryRepository ?? throw new ArgumentNullException(nameof(CategoryRepository));
        }

        public async Task ValidateCreate(CreateCategoryRequest request) {

            if(await _CategoryRepository.CategoryNameExists(request.CategoryName))
                throw new ArgumentNullException("Category name already exists.");
        }

        public async Task ValidateUpdate(UpdateCategoryRequest request) {

            var category = await _CategoryRepository.GetCategoryById(request.CategoryId);

            if (category is null)
                throw new ArgumentNullException("Category does not exist.");

            if (category.IsDeleted)
                throw new ArgumentNullException("Category is deleted.");
        }

        public async Task ValidateDelete(int CategoryId) {

            var category = await _CategoryRepository.GetCategoryById(CategoryId);

            if (category is null)
                throw new ArgumentNullException("Category does not exist.");

            if (category.IsDeleted)
                throw new ArgumentNullException("Category already deleted.");
        }
    }
}