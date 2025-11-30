using Azure.Core;
using Business.Abstract.Common;
using Business.DTOs.Request.Category;
using Business.DTOs.Request.Inventory;
using Business.DTOs.Request.Supplier;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.CategoryValidation {
    
    public class CategoryValidator : IAddServiceValidator<CreateCategoryRequest>,
        IUpdateServiceValidator<UpdateCategoryRequest>, IDeleteServiceValidator {

        private readonly ICategoryRepository _CategoryRepository;

        public CategoryValidator(ICategoryRepository CategoryRepository) {

            CategoryRepository = CategoryRepository ?? throw new ArgumentNullException(nameof(CategoryRepository));
        }

        public async Task<Result<CreateCategoryRequest>> ValidateCreate(CreateCategoryRequest request) {

            if(await _CategoryRepository.CategoryNameExists(request.CategoryName))
                return Result<CreateCategoryRequest>.Failure("Category name already exists.");

            return Result<CreateCategoryRequest>.Success(request);
        }

        public async Task<Result<UpdateCategoryRequest>> ValidateUpdate(UpdateCategoryRequest request) {

            var category = await _CategoryRepository.GetCategoryById(request.CategoryId);

            if (category is null)
                return Result<UpdateCategoryRequest>.Failure("Category does not exist.");

            if (!category.IsActive)
                return Result<UpdateCategoryRequest>.Failure("Category already Deactivated.");

            return Result<UpdateCategoryRequest>.Success(request);
        }

        public async Task<Result<bool>> ValidateDelete(int CategoryId) {

            var category = await _CategoryRepository.GetCategoryById(CategoryId);

            if (category is null)
                return Result<bool>.Failure("Category does not exist.");

            if (!category.IsActive)
                return Result<bool>.Failure("Category already Deactivated.");

            return Result<bool>.Success(true);
        }
    }
}