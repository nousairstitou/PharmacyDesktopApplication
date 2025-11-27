using Business.Abstract.Common;
using Business.DTOs.Request.Supplier;
using Business.DTOs.Response.Supplier;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.SupplierMapper {

    public sealed class GetSupplierByIdToResponseMapper : IEntityToResponseMapper<GetSupplierByIdResponse , Supplier> {

        public GetSupplierByIdResponse Map(Supplier supplier) {

            return new GetSupplierByIdResponse {

                SupplierId = supplier.SupplierId,
                SupplierName = supplier.Name,
                SupplierPhone = supplier.Phone,
                SupplierEmail = supplier.Email,
                AddressId  = supplier.AddressId
            };
        }
    }
}