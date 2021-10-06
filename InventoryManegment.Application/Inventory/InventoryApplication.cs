using _01_Farmework.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagment.Domain.InventoryAgg;
using System.Collections.Generic;

namespace InventoryManagment.Application.Inventory
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public OperationResult Create(CreateInventory command)
        {
            var operations = new OperationResult();
            if (_inventoryRepository.Exists(x=>x.ProductId==command.productid))
                return operations.Faild(ApplicationMessage.DuplicatedRecord);
            var inventory = new Domain.InventoryAgg.Inventory(command.productid,command.unitprice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.Save();
            return operations.Succedded();


        }

        public OperationResult Edit(EditInventory command)
        {
            var operations = new OperationResult();
            var inventory = _inventoryRepository.Get(command.id);
            if (inventory == null)
                return operations.Faild(ApplicationMessage.RecordNotFound);
            if(_inventoryRepository.Exists(x=>x.ProductId==command.productid && x.id!=command.id))
                return operations.Faild(ApplicationMessage.DuplicatedRecord);
            inventory.Edit(command.productid, command.unitprice);
            _inventoryRepository.Save();
            return operations.Succedded();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryid)
        {
            return _inventoryRepository.GetOperationLog(inventoryid);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operations = new OperationResult();
            var inventory = _inventoryRepository.Get(command.Inventoryid);
            if(inventory == null)
                return operations.Faild(ApplicationMessage.RecordNotFound);
            var operatorid = 1;
            inventory.Increase(command.Count,1, command.Description);
            _inventoryRepository.Save();
            return operations.Succedded();
        }
        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operations = new OperationResult();
            var operatorid = 1;
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.Productid);
                inventory.Reduce(item.Count, item.Description, operatorid, item.orderid);
            }
            _inventoryRepository.Save();
            return operations.Succedded();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operations = new OperationResult();
            var inventory = _inventoryRepository.Get(command.Inventoryid);
            if (inventory == null)
                return operations.Faild(ApplicationMessage.RecordNotFound);
            var operatorid = 1;
            inventory.Reduce(command.Count,command.Description,1,0);
            _inventoryRepository.Save();
            return operations.Succedded();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
}
