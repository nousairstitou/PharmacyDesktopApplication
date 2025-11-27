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

    public class PaymentRepository : BaseRepository<Payment> , IPaymentRepository {

        private readonly IEntityMapper<Payment> _EntityMapper;
        private readonly IViewMapper<PaymentViewModel> _ViewMapper;

        public PaymentRepository(IDatabaseConnectionFactory databaseConnectionFactory , IEntityMapper<Payment> EntityMapper , IViewMapper<PaymentViewModel> ViewMapper) : base(databaseConnectionFactory) {

            _EntityMapper = EntityMapper ?? throw new ArgumentNullException(nameof(EntityMapper));
            _ViewMapper = ViewMapper ?? throw new ArgumentNullException(nameof(ViewMapper));
        }

        public async Task<IEnumerable<PaymentViewModel>> GetAllPayments() {

            return await GetList("SELECT * FROM vw_GetAllPayments ORDER BY CreatedAt DESC", _ViewMapper.MapToView);
        }

        public async Task<Payment?> GetPaymentById(int? PaymentId) {

            return await GetByValue("sp_GetPaymentById", "@PaymentId", PaymentId, _EntityMapper.Map); 
        }
    }
}