

using System;

namespace InventoryManagment.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public long id { get; private set; }
        public long InventoryId { get; private set;}
        public long Count { get; private set; }
        public bool Operation { get; private set;}
        public string Description { get; private set; }
        public long OperatorId { get; private set; }
        public long OrderId { get; private set; }
        public long CurrentCount { get; private set; }
        public DateTime OperationDate { get; private set; }
        public Inventory inventory { get; set; }
        public InventoryOperation()
        {

        }
        public InventoryOperation(long inventoryid,long count,string description,bool operation,long operatorid,long orderid,long currentcount)
        {
            InventoryId = inventoryid;
            Count = count;
            Description = description;
            Operation = operation;
            OperatorId = operatorid;
            OrderId = orderid;
            CurrentCount = currentcount;
            OperationDate = DateTime.Now;

        }
    }
}
