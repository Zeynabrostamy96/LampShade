using _01_Query.Contract.Comment;
using System.Collections.Generic;

namespace _01_Query.Contract.Article
{
    public  class ArticleQueryView
    {
        public long  id { get; set; }
        public string Title { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureTitle { get;  set; }
        public string PictureAlt { get;  set; }
        public string Slug { get;  set; }
        public string KeyWords { get;  set; }
        public string MetaDescription { get;  set; }
        public string CanonicalAddres { get;  set; }
        public string PublishDate { get;  set; }
        public long AricleCategoryId { get;  set; }
        public string  CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public List<string> keywords { get; set; }
        public List<CommentQueryViewModel> comments { get; set; }


    }
}
