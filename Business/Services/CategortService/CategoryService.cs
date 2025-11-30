using Azure.Core;
using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Category;
using Business.DTOs.Request.Customer;
using Business.DTOs.Response.Category;
using Business.Validation;
using Business.Validation.CategoryValidation;
using Models;
using Repositories.Abstract.Interfaces;
using Repositories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Services.CategoryService {

    public class CategoryService : ICategoryService {

        private readonly ICategoryRepository _CategoryRepository;
        private readonly IEntityMapper<CreateCategoryRequest, Category> _CreateEntityMapper;
        private readonly IEntityMapper<UpdateCategoryRequest, Category> _UpdateEntityMapper;
        private readonly IEntityToResponseMapper<GetCategoryByIdResponse, Category> _EntityToResponse;
        private readonly IServiceValidator<CreateCategoryRequest, UpdateCategoryRequest> _CategoryValidator;

        public CategoryService(ICategoryRepository CategoryRepository , IEntityMapper<CreateCategoryRequest, Category> CreateEntityMapper,
            IEntityMapper<UpdateCategoryRequest, Category> UpdateEntityMapper ,
            IEntityToResponseMapper<GetCategoryByIdResponse, Category> EntityToResponse , 
            IServiceValidator<CreateCategoryRequest, UpdateCategoryRequest> CategoryValidator) { 
        
            _CategoryRepository = CategoryRepository ?? throw new Exception(nameof(CategoryRepository));
            _CreateEntityMapper = CreateEntityMapper ?? throw new Exception(nameof(CreateEntityMapper));
            _UpdateEntityMapper = UpdateEntityMapper ?? throw new Exception(nameof(UpdateEntityMapper));
            _EntityToResponse = EntityToResponse ?? throw new Exception(nameof(EntityToResponse));
            _CategoryValidator = CategoryValidator ?? throw new Exception(nameof(CategoryValidator));
        }

        public async Task<GetAllCategoriesResponse> GetAllCategories() {

            var Category = await _CategoryRepository.GetAllCategories();
            return new GetAllCategoriesResponse(Category);
        }
        
        public async Task<GetCategoryByIdResponse?> GetCategoryById(int? CategoryId) {

            var Category = await _CategoryRepository.GetCategoryById(CategoryId);
            return _EntityToResponse.Map(Category);
        }

        public async Task<int?> Add(CreateCategoryRequest request) {

            var result = await _CategoryValidator.ValidateCreate(request);

            if (!result.IsSuccess)
                return null;

            return await _CategoryRepository.Add(_CreateEntityMapper.Map(request));
        }

        public async Task<bool> Update(int CategoryId, UpdateCategoryRequest request) {

            var result = await _CategoryValidator.ValidateUpdate(request);

            if (!result.IsSuccess)
                return false;

            return await _CategoryRepository.Update(CategoryId, _UpdateEntityMapper.Map(request));
        }

        public async Task<bool> Delete(int CategoryId) {

            var result = await _CategoryValidator.ValidateDelete(CategoryId);

            if (!result.IsSuccess)
                return false;

            return await _CategoryRepository.Delete(CategoryId);
        }
    }
}