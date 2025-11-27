using Business.Abstract.Common;
using Business.DTOs.Request.Category;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.CategoryMapper {

    public sealed class UpdateCategoryMapperToEntity : IEntityMapper<UpdateCategoryRequest , Category> {

        public Category Map(UpdateCategoryRequest request) {

            return new Category {

                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName,
                IsActive = request.IsActive,
                CreatedBy = request.CreatedBy,
                Description = request.Description,
            };
        }
    }
}