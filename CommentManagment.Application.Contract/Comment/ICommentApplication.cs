using _01_Farmework.Application;
using System.Collections.Generic;

namespace CommentManagment.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        OperationResult Add(AddComment command);
        OperationResult Confirem(long id);
        OperationResult Cancel(long id);

        List<CommentViewModel> Search(CommentSearchModel search);
    }
}
