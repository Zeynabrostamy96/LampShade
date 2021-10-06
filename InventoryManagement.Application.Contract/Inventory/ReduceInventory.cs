

namespace InventoryManagement.Application.Contract.Inventory
{
    public   class ReduceInventory
    {
        public long Inventoryid { get; set; }
        public long Productid { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
        public long orderid { get; set; }

    }
}
