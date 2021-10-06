using _01_Farmework;
using System.Collections.Generic;

namespace CommentManagment.Domain.CommentAgg
{
    public   class Comment: EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Website { get; private set; }
        public string  Message { get; private set; }
        public bool ISConfiremed { get; private set; }
        public bool ISConceled { get; private set; }
        public long OwnerRecordId { get; private set; }
        public int  Type { get; private set; }
        public long  ParentId { get; private set; }
        public  Comment Parent { get; private set; }
   

        public Comment()
        {

        }
        public Comment(string name,string email,string website,string message,long ownerrecordid,int type,long parentid)
        {
            Name = name;
            Email = email;
            Website = website;
            Message = message;
            OwnerRecordId = ownerrecordid;
            Type = type;
            ParentId = parentid;
           
        }
        public void Confiremed()
        {
            ISConfiremed = true;
        }
        public void Canceled()
        {
            ISConceled = true;
        }
    }
}
