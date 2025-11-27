using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Abstract.Interfaces {

    public interface ICategoryRepository :
        IAddRepository<Category> , 
        IUpdateRepository<Category> ,
        IDeleteRepository<Category> {

        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
        Task<Category?> GetCategoryById(int? categoryId);
        Task<bool> CategoryNameExists(string? CategoryName);
    }
}