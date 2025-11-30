using Business.Abstract.Common;
using Business.Abstract.Interfaces;
using Business.DTOs.Request.Customer;
using Business.DTOs.Request.Inventory;
using Business.DTOs.Response.Inventory;
using Business.Validation;
using Business.Validation.InventoryValidation;
using Models;
using Repositories.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.InventoryService {

    public class InventoryService : IInventoryService {

        private readonly IInventoryRepository _InventoryRepository;
        private readonly IEntityMapper<CreateInventoryRequest, Inventory> _EntityMapper;
        private readonly IEntityMapper<UpdateInventoryRequest, Inventory> _UpdateEntityMapper;
        private readonly IEntityToResponseMapper<GetInventoryByIdResponse, Inventory> _EntityToResponse;
        private readonly IServiceValidator<CreateInventoryRequest, UpdateInventoryRequest> _InventoryValidator;

        public InventoryService(IInventoryRepository InventoryRepository , IEntityMapper<CreateInventoryRequest, Inventory> EntityMapper ,
            IEntityMapper<UpdateInventoryRequest, Inventory> UpdateEntityMapper , 
            IEntityToResponseMapper<GetInventoryByIdResponse, Inventory> EntityToResponse ,
            IServiceValidator<CreateInventoryRequest, UpdateInventoryRequest> InventoryValidator) {
            
            _InventoryRepository = InventoryRepository ?? throw new ArgumentNullException(nameof(InventoryRepository));
            _EntityMapper = EntityMapper ?? throw new ArgumentNullException(nameof(EntityMapper));
            _UpdateEntityMapper = UpdateEntityMapper ?? throw new ArgumentNullException(nameof(UpdateEntityMapper));
            _EntityToResponse = EntityToResponse ?? throw new ArgumentNullException(nameof(EntityToResponse));
            _InventoryValidator = InventoryValidator ?? throw new ArgumentNullException(nameof(InventoryValidator));
        }

        public async Task<GetAllInventoriesResponse> GetAllInventories() {

            var inventories = await _InventoryRepository.GetAllInventories();
            return new GetAllInventoriesResponse(inventories);
        }

        public async Task<GetInventoryByIdResponse?> GetInventoryById(int? InventoryId) {

            var inventory = await _InventoryRepository.GetInventoryById(InventoryId);
            return _EntityToResponse.Map(inventory);
        }

        public async Task<int?> Add(CreateInventoryRequest request) {

            var result = await _InventoryValidator.ValidateCreate(request);

            if (!result.IsSuccess)
                return null;

            return await _InventoryRepository.Add(_EntityMapper.Map(request));
        }

        public async Task<bool> Update(int InventoryId , UpdateInventoryRequest request) {

            var result = await _InventoryValidator.ValidateUpdate(request);

            if (!result.IsSuccess) 
                return false;

            return await _InventoryRepository.Update(InventoryId , _UpdateEntityMapper.Map(request));
        }

        public async Task<bool> Delete(int InventoryId) {

            var result = await _InventoryValidator.ValidateDelete(InventoryId);

            if (!result.IsSuccess)
                return false;

            return await _InventoryRepository.Delete(InventoryId);
        }
    }
}