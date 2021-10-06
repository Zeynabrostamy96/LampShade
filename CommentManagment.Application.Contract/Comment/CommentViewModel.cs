

namespace CommentManagment.Application.Contracts.Comment
{
  public  class CommentViewModel
  {
        public long  id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Website { get; set; }
        public string Message { get;  set; }
        public int Type { get;  set; }
        public bool ISConfiremed { get;  set; }
        public bool ISConceled { get;  set; }
        public long OwnerRecordId { get;  set; }
        public string OwnerRecordName { get; set; }
        public string  CommentDate { get; set; }
    }
}
