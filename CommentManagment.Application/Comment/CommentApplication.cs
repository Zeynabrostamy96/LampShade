using _01_Farmework.Application;
using CommentManagment.Application.Contracts.Comment;
using CommentManagment.Domain.CommentAgg;
using System.Collections.Generic;

namespace CommentManagment.Application.Comment
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public OperationResult Add(AddComment command)
        {
            var operation = new OperationResult();
            var comment = new  Domain.CommentAgg.Comment(command.Name, command.Email,command.Website, command.Message,command.OwnerRecordId,command.Type,command.ParentId);
            _commentRepository.Create(comment);
            _commentRepository.Save();

            return  operation.Succedded();
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.Get(id);
            if (comment == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            comment.Canceled();
            _commentRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Confirem(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.Get(id);
            if (comment == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            comment.Confiremed();
            _commentRepository.Save();
            return operation.Succedded();

        }

        public List<CommentViewModel> Search(CommentSearchModel search)
        {
            return _commentRepository.Search(search);
        }
    }
}
