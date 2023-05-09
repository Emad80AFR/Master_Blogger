using System.Globalization;
using FrameWork.Infrastructure;
using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository:BaseRepository<long,Comment>,ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title,
                Status = x.Status,
                Message = x.Message

            }).ToList();
        }

        
    }
}
