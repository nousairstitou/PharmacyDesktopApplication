using Business.Abstract.Common;
using Business.DTOs.Request.Inventory;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.InventoryMapper {

    public class UpdateInventoryMapperToEntity : IEntityMapper<UpdateInventoryRequest, Inventory> {

        public Inventory Map(UpdateInventoryRequest request) {

            return new Inventory {

                InventoryId = request.InventoryId,
                InventoryName = request.InventoryName,
                Location = request.Location,
                Capacity = request.Capacity
            };
        }
    }
}