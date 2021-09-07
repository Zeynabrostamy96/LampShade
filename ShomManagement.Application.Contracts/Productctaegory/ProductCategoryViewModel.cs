using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShomManagement.Application.Contracts.Productctaegory
{
    public class ProductCategoryViewModel
    {
        //in panel modiriate
        public long id { get; set; }
        public string Name { get; set; }
        public string Crationdate { get; set; }
        public string Picture { get; set; }
        public int ProductsCount { get; set; }
    }
}
