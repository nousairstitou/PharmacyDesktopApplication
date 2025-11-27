using Models;
using Repositories.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Abstract.Interfaces {

    public interface IInventoryRepository : IAddRepository<Inventory> , 
        IUpdateRepository<Inventory> , 
        IDeleteRepository<Inventory> {

        Task<IEnumerable<InventoryViewModel>> GetAllInventories();
        Task<Inventory?> GetInventoryById(int? InventoryId);
    }
}