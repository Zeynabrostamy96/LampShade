using _01_Query.Contract.Article;
using System.Collections.Generic;

namespace _01_Query.Contract.ArticleCategory
{
    public  class ArticleCategoryViewModel
    {
        public string Name { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Description { get;  set; }
        public string ShowOrder { get;  set; }
        public string Slug { get;  set; }
        public string KeyWords { get;  set; }
        public string MetaDesCription { get;  set; }
        public string CanonicalAddress { get;  set; }
        public long  ArticleCount  { get; set; }
        public   List<ArticleQueryView> articles { get; set; }
        public List<string> KeywordList { get; set; }

    }
}
