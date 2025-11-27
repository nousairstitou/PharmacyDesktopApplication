using Business.Abstract.Common;
using Business.DTOs.Request.Category;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.CategoryMapper {

    public sealed class CreateCategoryMapperToEntity : IEntityMapper<CreateCategoryRequest , Category> {

        public Category Map(CreateCategoryRequest request) {

            return new Category {

                CategoryName = request.CategoryName,
                IsActive = request.IsActive,
                CreatedBy = request.CreatedBy,
                Description = request.Description
            };
        }
    }
}