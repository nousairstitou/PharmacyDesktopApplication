using Business.Abstract.Common;
using Business.DTOs.Request.Category;
using Business.DTOs.Request.Customer;
using Business.DTOs.Response.Category;
using Business.DTOs.Response.Customer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Abstract.Interfaces {

    public interface ICategoryService :
        IAddService<CreateCategoryRequest>,
        IUpdateService<UpdateCategoryRequest>,
        IDeleteService {

        Task<GetAllCategoriesResponse> GetAllCategories();
        Task<GetCategoryByIdResponse?> GetCategoryById(int? CustomerId);
    }
}