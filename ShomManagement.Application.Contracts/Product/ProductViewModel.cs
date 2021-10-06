using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public   class ProductViewModel
    {
        public long  id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ProductCategory { get; set; }
        public string Picture { get; set; }
        public long CategoryId { get; set; }
        public string CrationDate { get; set; }
       

    }
}
