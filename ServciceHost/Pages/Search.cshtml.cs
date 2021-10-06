using _01_Query.Contract.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServciceHost.Pages
{
    public class SearchModel : PageModel
    {

        private readonly IProductQuery _productQuery;
        public SearchModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public string Value { get; set; }
        public List<ProductViewModel> Producs { get; set; }
        public void OnGet(string value)
        {
            Producs = _productQuery.Search(value);
            Value = value;
        }
    }
}
