using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Abstract.Interfaces {

    public interface ISaleRepository : IAddRepository<TransactionSale>, IDeleteRepository<Sale> {

        Task<IEnumerable<SaleViewModel>> GetAllSales();
        Task<Sale?> GetSaleById(int? SaleId);
        Task<Sale?> GetSaleByDate(DateTime SaleDate);
    }
}