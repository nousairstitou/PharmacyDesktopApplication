using Business.Abstract.Common;
using Business.DTOs.Response.Category;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.CategoryMapper {

    public sealed class GetCategoryByIdToResponseMapper : IEntityToResponseMapper<GetCategoryByIdResponse , Category> {

        public GetCategoryByIdResponse Map(Category category) {

            return new GetCategoryByIdResponse {

                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                IsActive = category.IsActive,
                CreatedBy = category.CreatedBy,
                Description = category.Description
            };
        }
    }
}