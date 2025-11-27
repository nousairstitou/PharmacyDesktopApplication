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

    public class SaleRepository : BaseRepository<Sale> , ISaleRepository {

        private readonly IEntityMapper<Sale> _EntityMapper;
        private readonly IViewMapper<SaleViewModel> _ViewMapper;

        public SaleRepository(IDatabaseConnectionFactory databaseConnectionFactory , IEntityMapper<Sale> EntityMapper , IViewMapper<SaleViewModel> ViewMapper) : base(databaseConnectionFactory) {

            _EntityMapper = EntityMapper ?? throw new ArgumentNullException(nameof(EntityMapper));
            _ViewMapper = ViewMapper ?? throw new ArgumentNullException(nameof(ViewMapper));
        }

        public async Task<IEnumerable<SaleViewModel>> GetAllSales() {

            return await GetList("SELECT * FROM vw_GetAllSales ORDER BY saleDate;", _ViewMapper.MapToView);
        }

        public async Task<Sale?> GetSaleById(int? SaleId) {

            return await GetByValue("sp_GetSaleById", "@SaleId", SaleId, _EntityMapper.Map);
        }

        public async Task<Sale?> GetSaleByDate(DateTime SaleDate) {

            return await GetByValue("sp_GetSaleByDate", "@SaleDate", SaleDate, _EntityMapper.Map);
        }

        public async Task<int?> Add(Sale entity) {

            return await Insert("sp_AddSale" , "@NewSaleId" , Parameter => {

                Parameter.Parameters.AddWithValue("@CustomerId" , entity.CustomerId);
                Parameter.Parameters.AddWithValue("@Notes", entity.Note);
            });
        }

        public async Task<bool> Delete(int SaleId) {

            return await Delete("sp_DeleteSale", "@SaleId", SaleId);
        }
    }
}