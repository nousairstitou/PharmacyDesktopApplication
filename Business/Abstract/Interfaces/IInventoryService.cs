using Business.Abstract.Common;
using Business.DTOs.Request.Inventory;
using Business.DTOs.Response.Inventory;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Abstract.Interfaces {

    public interface IInventoryService : 
        IAddService<CreateInventoryRequest> , 
        IUpdateService<UpdateInventoryRequest> ,
        IDeleteService {

        Task<IEnumerable<InventoryViewModel>> GetAllInventories();
        Task<GetInventoryByIdResponse?> GetInventoryById(int? InventoryId);
    }
}