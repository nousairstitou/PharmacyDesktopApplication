using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Mapper {

    public class SupplierMapper : IEntityMapper<Supplier> , IViewMapper<SupplierViewModel> {

        public Supplier Map(SqlDataReader Reader) {

            return new Supplier {

                SupplierId = Reader.GetInt32(Reader.GetOrdinal("SupplierId")),
                Name = Reader.GetString(Reader.GetOrdinal("SupplierName")),
                Phone = Reader.GetString(Reader.GetOrdinal("Phone")),
                Email = Reader["Email"] is DBNull ? null : Reader.GetString(Reader.GetOrdinal("Email")),
                AddressId = Reader["AddressId"] is DBNull ? null : Reader.GetInt32(Reader.GetOrdinal("AddressId"))
            };
        }

        public SupplierViewModel MapToView(SqlDataReader Reader) {

            return new SupplierViewModel {

                SupplierId = Reader.GetInt32(Reader.GetOrdinal("SupplierId")),
                Name = Reader.GetString(Reader.GetOrdinal("SupplierName")),
                Phone = Reader.GetString(Reader.GetOrdinal("Phone")),
                Email = Reader["Email"] is DBNull ? null : Reader.GetString(Reader.GetOrdinal("Email")),
                Street = Reader.GetString(Reader.GetOrdinal("Street")),
                BuildingNumber = Reader.GetInt32(Reader.GetOrdinal("BuildingNumber")),
                DepartmentNumber = Reader.GetInt32(Reader.GetOrdinal("DepartmentNumber"))
            };
        }
    }
}