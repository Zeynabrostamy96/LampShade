
using _01_Farmework.Application;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        EditInventory GetDetails(long id);
        OperationResult Increase(IncreaseInventory command);
        //ممکنه کاربر چند تا کالا را از توی انبارکم کند بنابراین باید لیست بگیریم 
        OperationResult Reduce( List<ReduceInventory>   command);
        //اینجا ممکنه کاربر انبار یک محصول را کم کند بنابراین لیست نیاز نیست
        OperationResult Reduce(ReduceInventory command);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryid);
    }
}
