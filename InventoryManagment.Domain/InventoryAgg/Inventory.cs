using _01_Farmework;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagment.Domain.InventoryAgg
{
    public  class Inventory:EntityBase
    {
        public long  ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> inventoryOperations { get; set; }
        public Inventory()
        {

        }
        public Inventory(long productid,double unitprice)
        {
            ProductId = productid;
            UnitPrice = unitprice;
            InStock = false;
        }
        public  void Edit(long productid, double unitprice)
        {
            ProductId = productid;
            UnitPrice = unitprice;
        }
        public long CalculateCurrentCount()
        {
            var Plus = inventoryOperations.Where(x => x.Operation).Sum(x => x.Count);
            var Mains = inventoryOperations.Where(x => !x.Operation).Sum(x => x.Count);
            return Plus - Mains;
        }
        public void Increase(long count,long operatorid,string description)
        {
            var currentcount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(id,count,description,true,operatorid,0,currentcount);
            inventoryOperations.Add(operation);
            InStock = currentcount > 0;

        }
        public void Reduce(long count,string description,long operatorid,long orderid)
        {
            var currentcount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(id,count,description,false,operatorid,orderid,currentcount);
            inventoryOperations.Add(operation);
            InStock = currentcount < 0;
        }

    }
}
