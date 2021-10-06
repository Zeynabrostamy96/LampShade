
namespace _01_Query.Contract.Comment
{
    public  class CommentQueryViewModel
    {
        public long id { get; set; }
        public long  CommentId { get; set; }
        public string  Email { get; set; }
        public  string Name { get; set; }
        public  string Message { get; set; }
        public string  Website { get; set; }
        public string  CreationDate { get; set; }
        public long  Parentid { get; set; }
        public string ParentName { get; set; }
    }
}
