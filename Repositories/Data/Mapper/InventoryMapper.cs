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

    public class InventoryMapper : IEntityMapper<Inventory> , IViewMapper<InventoryViewModel> {

        public InventoryViewModel MapToView(SqlDataReader Reader) {

            return new InventoryViewModel {

                InventoryId = Reader.GetInt32(Reader.GetOrdinal("InventoryId")),
                InventoryName = Reader.GetString(Reader.GetOrdinal("InventoryName")),
                Location = Reader.GetString(Reader.GetOrdinal("Location")),
                Capacity = Reader.GetInt32(Reader.GetOrdinal("Capacity")),
                CreatedAt = Reader.GetDateTime(Reader.GetOrdinal("CreatedAt")),
                UpdatedAt = Reader.GetDateTime(Reader.GetOrdinal("UpdatedAt"))
            };
        }

        public Inventory Map(SqlDataReader Reader) {

            return new Inventory {

                InventoryId = Reader.GetInt32(Reader.GetOrdinal("InventoryId")),
                InventoryName = Reader.GetString(Reader.GetOrdinal("InventoryName")),
                Location = Reader.GetString(Reader.GetOrdinal("Location")),
                Capacity = Reader.GetInt32(Reader.GetOrdinal("Capacity"))
            };
        }
    }
}