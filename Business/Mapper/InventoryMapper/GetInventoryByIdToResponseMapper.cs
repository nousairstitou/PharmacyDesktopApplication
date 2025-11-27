using Business.Abstract.Common;
using Business.DTOs.Request.Inventory;
using Business.DTOs.Response.Inventory;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.InventoryMapper {

    public class GetInventoryByIdToResponseMapper : IEntityToResponseMapper<GetInventoryByIdResponse , Inventory> {

        public GetInventoryByIdResponse Map(Inventory inventory) {

            return new GetInventoryByIdResponse {

                InventoryId = inventory.InventoryId,
                InventoryName = inventory.InventoryName,
                Location = inventory.Location,
                Capacity = inventory.Capacity
            };
        }
    }
}