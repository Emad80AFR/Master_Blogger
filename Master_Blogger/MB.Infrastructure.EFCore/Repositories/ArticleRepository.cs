using System.Globalization;
using FrameWork.Infrastructure;
using MB.Application.Contract.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:BaseRepository<long,Article>,IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x=>x.ArticleCategory).Select(x=>new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),


            }).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
        public bool Exist(string title)
        {
           return _context.Articles.Any(x => x.Title == title);
        }
    }
}
