using MB.Application.Contract.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void Save();
        void Create(Article entity);
        Article Get(long id);
        bool Exist(string title);
    }
}
