using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Query.Contract.Product
{
     public interface IProductQuery
    {
        List<ProductViewModel> GetLastArrivals();
        List<ProductViewModel> Search(string Value);
        ProductViewModel GetDetailsby(string slug);
    }
}
