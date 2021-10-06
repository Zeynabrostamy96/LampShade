
namespace BlogManagment.Application.contract.Article
{
    public  class ArticleViewModel
    {
        public long id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string  Picture { get; set; }
        public string PublishDate { get; set; }
        public long ArticleCategoryId { get; set; }
        public string ArticleCategoryName { get; set; }
    }
}
