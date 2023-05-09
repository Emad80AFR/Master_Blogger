using FrameWork.Infrastructure;
using MB.Application.Contract.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        List<ArticleViewModel> GetList();
        void Save();
        bool Exist(string title);
    }
}
