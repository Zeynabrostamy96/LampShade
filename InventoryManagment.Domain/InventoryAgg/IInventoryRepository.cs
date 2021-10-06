

using _01_Farmework.Domain;
using InventoryManagement.Application.Contract.Inventory;
using System.Collections.Generic;

namespace InventoryManagment.Domain.InventoryAgg
{
    public interface IInventoryRepository: IRepository<long, Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy(long ProductId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryid);
    }
}
