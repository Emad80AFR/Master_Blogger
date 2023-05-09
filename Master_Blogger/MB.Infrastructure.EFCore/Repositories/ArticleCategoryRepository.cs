using FrameWork.Infrastructure;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository:BaseRepository<long,ArticleCategory>,IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exist(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }
    }
}
