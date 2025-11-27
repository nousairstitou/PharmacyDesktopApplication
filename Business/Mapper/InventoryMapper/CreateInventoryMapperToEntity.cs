using Business.Abstract.Common;
using Business.DTOs.Request.Inventory;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.InventoryMapper {

    public class CreateInventoryMapperToEntity : IEntityMapper<CreateInventoryRequest , Inventory> {

        public Inventory Map(CreateInventoryRequest request) {

            return new Inventory {

                InventoryName = request.InventoryName,
                Location = request.Location,
                Capacity = request.Capacity
            };
        }
    }
}