

using _01_Query.Contract.Product;
using System.Collections.Generic;

namespace _01_Query.Contract.ProductCategory
{
    public   class ProductCategoryViewModel
    {
        public long id { get; set; }
        public string Name { get;  set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string Picture { get;  set; }
        public string PictureTitle { get;  set; }
        public string PictureAlt { get;  set; }
        public string Slug { get;  set; }
        
        public List<ProductViewModel> products { get; set; }
    }
}
