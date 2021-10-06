

using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using Infrastructure;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagment.Domain.InventoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastructure.Repository
{
    public   class InventoryRepository: RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;
        public InventoryRepository(InventoryContext inventoryContext,ShopContext shopContext):base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public Inventory GetBy(long ProductId)
        {
            return _inventoryContext.inventory.FirstOrDefault(x => x.ProductId == ProductId);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.inventory.Select(x => new EditInventory
            {
                id=x.id,
                productid=x.ProductId,
                unitprice=x.UnitPrice,

            }).FirstOrDefault(x => x.id == id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryid)
        {
            var inventory = _inventoryContext.inventory.FirstOrDefault(x=>x.id==inventoryid);
            return inventory.inventoryOperations.Select(x => new InventoryOperationViewModel
            {
                id = x.id,
                Description = x.Description,
                OperationDate = x.OperationDate.ToFarsi(),
                Count=x.Count,
                CurrentCount=x.CurrentCount,
                InventoryId=x.InventoryId,
                Operation=x.Operation,
                Operator="مدیرسیستم",
                OperatorId=x.OperatorId,
                OrderId=x.OrderId

            }).OrderByDescending(x=>x.id).ToList();

        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.id, x.Name }).ToList();
            var query = _inventoryContext.inventory.Select(x => new InventoryViewModel
            {
                id=x.id,
                InStock=x.InStock,
                CurrentCount=x.CalculateCurrentCount(),
                productid=x.ProductId,
                unitprice=x.UnitPrice,
                Creationdate=x.Crationdate.ToFarsi(),

            });
            if (searchModel.productid != 0)
                query = query.Where(x => x.productid == searchModel.productid);
            //یعنی اگر تیک زده بود ناموجود هار ابیاور
            if (searchModel.Instock)
                query = query.Where(x => !x.InStock );
            var inventory = query.OrderByDescending(x=>x.id).ToList();
            inventory.ForEach(x => x.Product = products.FirstOrDefault(z => z.id == x.productid)?.Name);
            return inventory;
        }
    }
}
