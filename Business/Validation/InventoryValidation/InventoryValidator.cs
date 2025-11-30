using Azure.Core;
using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Inventory;
using Business.DTOs.Request.Supplier;
using Models;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.InventoryValidation {

    public class InventoryValidator : IAddServiceValidator<CreateInventoryRequest>,
        IUpdateServiceValidator<UpdateInventoryRequest>, IDeleteServiceValidator {

        private readonly IInventoryRepository _InventoryRepository;

        public InventoryValidator(IInventoryRepository InventoryRepository) {

            _InventoryRepository = InventoryRepository ?? throw new ArgumentNullException(nameof(InventoryRepository));
        }

        public async Task<Result<CreateInventoryRequest>> ValidateCreate(CreateInventoryRequest request) {

            if (request.Capacity < 0)
                return Result<CreateInventoryRequest>.Failure("Inventory Capacity cannot be less than zero.");

            if (await _InventoryRepository.LocationExists(request.Location))
                return Result<CreateInventoryRequest>.Failure("Inventory Location already exists.");

            return Result<CreateInventoryRequest>.Success(request);
        }

        public async Task<Result<UpdateInventoryRequest>> ValidateUpdate(UpdateInventoryRequest request) {

            var Inventory = await _InventoryRepository.GetInventoryById(request.InventoryId);

            if (Inventory is null)
                return Result<UpdateInventoryRequest>.Failure("Inventory does not exist.");

            if (Inventory.IsDeleted)
                return Result<UpdateInventoryRequest>.Failure("Inventory is deleted.");

            return Result<UpdateInventoryRequest>.Success(request);
        }

        public async Task<Result<bool>> ValidateDelete(int InventoryId) {

            var Inventory = await _InventoryRepository.GetInventoryById(InventoryId);

            if (Inventory is null)
                return Result<bool>.Failure("Inventory does not exist.");

            if (Inventory.IsDeleted)
                return Result<bool>.Failure("Inventory already delete.");

            return Result<bool>.Success(true);
        }
    }
}