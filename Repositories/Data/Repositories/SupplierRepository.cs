using Microsoft.Data.SqlClient;
using Models;
using Repositories.Abstract.Common;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Repositories {

    public class SupplierRepository : BaseRepository<Supplier> , ISupplierRepository {

        private readonly IEntityMapper<Supplier> _supplierMapper;
        private readonly IViewMapper<SupplierViewModel> _ViewMapper;

        public SupplierRepository(IDatabaseConnectionFactory databaseConnectionFactory , IEntityMapper<Supplier> SupplierMapper , IViewMapper<SupplierViewModel> ViewMapper) : base(databaseConnectionFactory) {

            _supplierMapper = SupplierMapper ?? throw new ArgumentNullException(nameof(SupplierMapper));
            _ViewMapper = ViewMapper ?? throw new ArgumentNullException(nameof(ViewMapper));
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSuppliers() {

            return await GetList("SELECT * FROM vw_GetAllSuppliers", _ViewMapper.MapToView);
        }

        public async Task<Supplier?> GetSupplierById(int? SupplierId) {

            return await  GetByValue("sp_GetSupplierById", "@SupplierId", SupplierId, _supplierMapper.Map);
        }

        public async Task<bool> PhoneSupplierExists(string? Phone) {

            return await IsExist("sp_PhoneSupplierExists", parameter => {

                parameter.Parameters.AddWithValue("@Phone", Phone);
            });
        }

        public async Task<bool> EmailSupplierExists(string? Email) {

            return await IsExist("sp_EmailSupplierExists", parameter => {

                parameter.Parameters.AddWithValue("@Email", Email);
            });
        }

        public async Task<int?> Add(Supplier supplier) {

            return await Insert("sp_AddSupplier", "@NewSupplierId" , parameter => {

                parameter.Parameters.AddWithValue("@SupplierName", supplier.Name);
                parameter.Parameters.AddWithValue("@Phone", supplier.Phone);
                parameter.Parameters.AddWithValue("@Email", supplier.Email ?? (object)DBNull.Value);
                parameter.Parameters.AddWithValue("@Address", supplier.Address);
            });
        }

        public async Task<bool> Update(int SupplierId , Supplier supplier) {

            return await Update("sp_UpdateSupplier", parameter => {

                parameter.Parameters.AddWithValue("@SupplierId", SupplierId);
                parameter.Parameters.AddWithValue("@Phone", supplier.Phone);
                parameter.Parameters.AddWithValue("@Email", supplier.Email ?? (object)DBNull.Value);
                parameter.Parameters.AddWithValue("@Address", supplier.Address);
            });
        }

        public async Task<bool> Delete(int SupplierId) {

            return await Delete("sp_DeleteSupplier", "@SupplierId", SupplierId);
        }
    }
}