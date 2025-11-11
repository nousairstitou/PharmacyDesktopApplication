using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstract.Interfaces {

    public interface ICategoryRepository {

        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int? categoryId);
        Task<Category> GetCategoryByName(string categoryName);
    }
}