using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Abstract.Interfaces {

    public interface ISupplierRepository : IAddRepository<Supplier>,
        IUpdateRepository<Supplier>,
        IDeleteRepository<Supplier> {

        Task<IEnumerable<SupplierViewModel>> GetAllSuppliers();
        Task<Supplier?> GetSupplierById(int? SupplierId);
        Task<bool> PhoneSupplierExists(string? Phone);
        Task<bool> EmailSupplierExists(string? Email);
    }
}