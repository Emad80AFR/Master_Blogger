using System.Globalization;
using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<CommentViewModel> GetAll()
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

        public Comment GetBy(long id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id)!;
        }
    }
}
