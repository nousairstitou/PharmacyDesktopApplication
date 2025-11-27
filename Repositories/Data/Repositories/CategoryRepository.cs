using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Repositories {

    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository {

        private readonly IEntityMapper<Category> _CategoryMapper;
        private readonly IViewMapper<CategoryViewModel> _ViewMapper;

        public CategoryRepository(IDatabaseConnectionFactory databaseConnectionFactory , IEntityMapper<Category> CategoryMapper , IViewMapper<CategoryViewModel> ViewMapper) : base(databaseConnectionFactory) {

            _CategoryMapper = CategoryMapper ?? throw new ArgumentNullException(nameof(CategoryMapper));
            _ViewMapper = ViewMapper ?? throw new ArgumentNullException(nameof(ViewMapper));
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories() {

            return await GetList("SELECT * FROM vw_GetAllCategories", _ViewMapper.MapToView);
        }

        public async Task<Category?> GetCategoryById(int? CategoryId) {

            return await GetByValue("sp_GetCategoryById", "@CategoryId", CategoryId, _CategoryMapper.Map);
        }

        public async Task<bool> CategoryNameExists(string? CategoryName) {

            return await IsExist("sp_CategoryNameExists", parameter => {

                parameter.Parameters.AddWithValue("@CategoryName", CategoryName);
            });
        }

        public async Task<int?> Add(Category category) {

            return await Insert("sp_AddCategory", "@NewCategoryId", parameter => {

                parameter.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                parameter.Parameters.AddWithValue("@IsActive", category.IsActive);
                parameter.Parameters.AddWithValue("@CreatedBy", category.CreatedBy);
                parameter.Parameters.AddWithValue("@Description", category.Description ?? (object)DBNull.Value);
            });
        }

        public async Task<bool> Update(int CategoryId , Category category) {

            return await Update("sp_UpdateCategory", parameter => {

                parameter.Parameters.AddWithValue("@CategoryId", CategoryId);
                parameter.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                parameter.Parameters.AddWithValue("@IsActive", category.IsActive);
                parameter.Parameters.AddWithValue("@Description", category.Description ?? (object)DBNull.Value);
            });
        }

        public async Task<bool> Delete(int CategoryId) {

            return await Delete("sp_DeleteCategory", "@CategoryId", CategoryId);
        }

        public async Task<bool> CategoryActive(int CategoryId) {

            return await Active("sp_ActivateCategory", "@CategoryId", CategoryId);
        }
    }
}