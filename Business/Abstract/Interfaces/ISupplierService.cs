using Business.Abstract.Common;
using Business.DTOs.Request.Category;
using Business.DTOs.Request.Supplier;
using Business.DTOs.Response.Supplier;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business.Abstract.Interfaces {

    public interface ISupplierService :
        IAddService<CreateSupplierRequest>,
        IUpdateService<UpdateSupplierRequest>,
        IDeleteService {

        Task<GetAllSuppliersResponse> GetAllSuppliers();
        Task<GetSupplierByIdResponse?> GetSupplierById(int? SupplierId);
    }
}