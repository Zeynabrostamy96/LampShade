

namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryOperationViewModel
    {
        public long id { get;  set; }
        public long InventoryId { get;  set; }
        public long Count { get;  set; }
        public bool Operation { get;  set; }
        public string Description { get;  set; }
        public long OperatorId { get;  set; }
        public string Operator { get; set; }
        public long OrderId { get;set; }
        public long CurrentCount { get; set; }
        public string OperationDate { get;  set; }
    }
}
