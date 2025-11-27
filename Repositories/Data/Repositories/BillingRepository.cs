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

    public class BillingRepository : BaseRepository<Billing> , IBillingRepository {

        private readonly IEntityMapper<Billing> _BillingMapper;
        private readonly IViewMapper<BillingViewModel> _ViewMapper;

        public BillingRepository(IDatabaseConnectionFactory databaseConnectionFactory, IEntityMapper<Billing> billingMapper , IViewMapper<BillingViewModel> ViewMapper) : base(databaseConnectionFactory) {

            _BillingMapper = billingMapper ?? throw new ArgumentNullException(nameof(billingMapper));
            _ViewMapper = ViewMapper ?? throw new ArgumentNullException(nameof(ViewMapper));
        }

        public async Task<IEnumerable<BillingViewModel>> GetAllBillings() {

            return await GetList("SELECT * FROM vw_GetAllBillings ORDER BY CreatedAt DESC", _ViewMapper.MapToView);
        }

        public async Task<Billing?> GetBillingById(int? BillingId) {

            return await GetByValue("sp_GetBillingById", "@BillingId", BillingId , _BillingMapper.Map);
        }
    }
}