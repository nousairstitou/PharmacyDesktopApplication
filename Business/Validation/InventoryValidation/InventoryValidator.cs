using Azure.Core;
using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Inventory;
using Models;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.InventoryValidation {

    public class InventoryValidator : IServiceValidator<CreateInventoryRequest , UpdateInventoryRequest> {

        private readonly IInventoryRepository _InventoryRepository;

        public InventoryValidator(IInventoryRepository InventoryRepository) {

            _InventoryRepository = InventoryRepository ?? throw new ArgumentNullException(nameof(InventoryRepository));
        }

        public async Task ValidateCreate(CreateInventoryRequest request) {

            if (request.Capacity < 0)
                throw new ArgumentNullException("Capacity cannot be less than zero.");

            if (await _InventoryRepository.LocationExists(request.Location))
                throw new ArgumentNullException("Inventory Location already Exists");
        }

        public async Task ValidateUpdate(UpdateInventoryRequest request) {

            var Inventory = await _InventoryRepository.GetInventoryById(request.InventoryId);

            if(Inventory is null)
                throw new ArgumentNullException("Inventory does not exist.");

            if (Inventory.IsDeleted)
                throw new ArgumentNullException("Inventory already delete.");
        }

        public async Task ValidateDelete(int InventoryId) {

            var Inventory = await _InventoryRepository.GetInventoryById(InventoryId);

            if (Inventory is null)
                throw new ArgumentNullException("Inventory does not exist.");

            if (Inventory.IsDeleted)
                throw new ArgumentNullException("Inventory already delete.");
        }
    }
}