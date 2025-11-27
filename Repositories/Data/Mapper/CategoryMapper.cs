using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Mapper {

    public class CategoryMapper : IEntityMapper<Category> , IViewMapper<CategoryViewModel> {

        public CategoryViewModel MapToView(SqlDataReader Reader) {

            return new CategoryViewModel {

                CategoryId = Reader.GetInt32(Reader.GetOrdinal("CategoryId")),
                CategoryName = Reader.GetString(Reader.GetOrdinal("CategoryName")),
                IsActive = Reader.GetString(Reader.GetOrdinal("Status")),
                CreatedBy = Reader.GetString(Reader.GetOrdinal("CreatedByName")),
                IsDeactivatedAt = Reader.IsDBNull(Reader.GetOrdinal("DeactivatedAt")) ? DateTime.MinValue : Reader.GetDateTime(Reader.GetOrdinal("DeactivatedAt")),
                Description = Reader.IsDBNull(Reader.GetOrdinal("Description")) ? null : Reader.GetString(Reader.GetOrdinal("Description")),
                CreatedDate = Reader.GetDateTime(Reader.GetOrdinal("CreatedDate")),
            };
        }

        public Category Map(SqlDataReader Reader) {

            return new Category {

                CategoryId = Reader.GetInt32(Reader.GetOrdinal("CategoryId")),
                CategoryName = Reader.GetString(Reader.GetOrdinal("CategoryName")),
                IsActive = Reader.GetBoolean(Reader.GetOrdinal("IsActive")),
                DeactivatedAt = Reader.IsDBNull(Reader.GetOrdinal("DeactivatedAt")) ? DateTime.MinValue : Reader.GetDateTime(Reader.GetOrdinal("DeactivatedAt")),
                CreatedDate = Reader.GetDateTime(Reader.GetOrdinal("CreatedDate")),
                CreatedBy = Reader.GetInt32(Reader.GetOrdinal("CreatedBy")),
                Description = Reader.IsDBNull(Reader.GetOrdinal("Description")) ? null : Reader.GetString(Reader.GetOrdinal("Description"))
            };
        }
    }
}