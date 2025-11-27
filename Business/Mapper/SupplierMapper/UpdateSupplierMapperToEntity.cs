using Business.Abstract.Common;
using Business.DTOs.Request.Supplier;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.SupplierMapper {

    public sealed class UpdateSupplierMapperToEntity : IEntityMapper<UpdateSupplierRequest, Supplier> {

        public Supplier Map(UpdateSupplierRequest request) {

            return new Supplier {

                SupplierId = request.SupplierId,
                Name = request.SupplierName,
                Phone = request.SupplierPhone,
                Email = request.SupplierEmail,
                AddressId = request.AddressId
            };
        }
    }
}