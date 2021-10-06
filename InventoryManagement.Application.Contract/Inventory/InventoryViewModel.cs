
namespace InventoryManagement.Application.Contract.Inventory
{
    public  class InventoryViewModel
    {
        public long  id { get; set; }
        public long productid { get; set; }
        public double  unitprice { get; set; }
        public  string Product { get; set; }
        public  bool  InStock { get; set; }
        public long CurrentCount { get; set; }
        public string Creationdate { get; set; }
    }
}
