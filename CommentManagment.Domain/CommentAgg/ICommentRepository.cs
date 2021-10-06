
using _01_Farmework.Domain;
using CommentManagment.Application.Contracts.Comment;
using System.Collections.Generic;

namespace CommentManagment.Domain.CommentAgg
{
    public  interface ICommentRepository: IRepository<long ,Comment>
    {

        List<CommentViewModel> Search(CommentSearchModel search);

    }
}
