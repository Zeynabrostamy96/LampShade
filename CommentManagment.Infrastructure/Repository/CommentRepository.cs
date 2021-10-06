using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using CommentManagment.Application.Contracts.Comment;
using CommentManagment.Domain.CommentAgg;
using CommentManagment.Infrastructure;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
   public  class CommentRepository:RepositoryBase<long,Comment>, ICommentRepository
    {
        private readonly CommentContext _commentContext;
        public CommentRepository(CommentContext commentContext):base(commentContext)
        {
            _commentContext = commentContext;
        }

        public List<CommentViewModel> Search(CommentSearchModel search)
        {
            var query = _commentContext.comments.Select(x => new CommentViewModel
            {
                id=x.id,
                Name = x.Name,
                Email = x.Email,
                Website = x.Website,
                Message = x.Message,
                ISConfiremed = x.ISConfiremed,
                ISConceled = x.ISConceled,
                OwnerRecordId=x.OwnerRecordId,
                Type=x.Type,
                CommentDate = x.Crationdate.ToFarsi()
            });
            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name));

            if (!string.IsNullOrWhiteSpace(search.Email))
                query = query.Where(x => x.Email.Contains(search.Email));

            return query.OrderByDescending(x => x.id).ToList();

        }

      
    }
}
