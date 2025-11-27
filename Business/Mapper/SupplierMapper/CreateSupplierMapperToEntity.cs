using Business.Abstract.Common;
using Business.DTOs.Request.Supplier;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.SupplierMapper {

    public sealed class CreateSupplierMapperToEntity : IEntityMapper<CreateSupplierRequest , Supplier> {

        public Supplier Map(CreateSupplierRequest request) {

            return new Supplier {

                Name = request.SupplierName,
                Phone = request.SupplierPhone,
                Email = request.SupplierEmail,
                AddressId = request.AddressId
            };
        }
    }
}