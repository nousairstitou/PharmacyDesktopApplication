using Models;
using Repositories.Abstract.Common;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Data.Repositories {

    public class InventoryRepository : BaseRepository<Inventory> , IInventoryRepository {

        private readonly IEntityMapper<Inventory> _EntityMapper;
        private readonly IViewMapper<InventoryViewModel> _ViewMapper;

        public InventoryRepository(IDatabaseConnectionFactory databaseConnectionFactory , IEntityMapper<Inventory> EntityMapper , IViewMapper<InventoryViewModel> ViewMapper) : base(databaseConnectionFactory) {

            _EntityMapper = EntityMapper ?? throw new ArgumentNullException(nameof(EntityMapper));
            _ViewMapper = ViewMapper ?? throw new ArgumentNullException(nameof(ViewMapper));
        }

        public async Task<IEnumerable<InventoryViewModel>> GetAllInventories() {

            return await GetList("SELECT * FROM vw_GetAllInventories ORDER BY CreatedAt DESC;", _ViewMapper.MapToView);
        }

        public async Task<Inventory?> GetInventoryById(int? InventoryId) {

            return await GetByValue("sp_GetInventoryById", "@InventoryId", InventoryId, _EntityMapper.Map);
        }

        public async Task<int?> Add(Inventory entity) {

            return await Insert("sp_AddInventory", "@NewInventoryId", Parameter => {

                Parameter.Parameters.AddWithValue("@InventoryName", entity.InventoryName);
                Parameter.Parameters.AddWithValue("@Location", entity.Location);
                Parameter.Parameters.AddWithValue("@Capacity", entity.Capacity);
            });
        }

        public async Task<bool> Update(int InventoryId ,Inventory entity) {

            return await Update("sp_UpdateInventory", Parameter => {

                Parameter.Parameters.AddWithValue("@InventoryId", InventoryId);
                Parameter.Parameters.AddWithValue("@InventoryName", entity.InventoryName);
                Parameter.Parameters.AddWithValue("@Location", entity.Location);
                Parameter.Parameters.AddWithValue("@Capacity", entity.Capacity);
            });
        }

        public async Task<bool> Delete(int InventoryId) {

            return await Delete("sp_DeleteInventory", "@InventoryId" , InventoryId);
        }
    }
}