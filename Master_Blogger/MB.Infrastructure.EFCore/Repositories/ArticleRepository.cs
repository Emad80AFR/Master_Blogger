using System.Globalization;
using MB.Application.Contract.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
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

        public void Create(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public Article Get(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id)!;
        }
    }
}
