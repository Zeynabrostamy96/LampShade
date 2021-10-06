

using Microsoft.AspNetCore.Http;

namespace BlogManagment.Application.contract.ArticleCategory
{
    public   class ArticleCategoryViewModel
    {
        public long  id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string ShowOrder { get; set; }
        public string CrationDate { get; set; }
        public long ArticleCount { get; set; }
  

    }
}
