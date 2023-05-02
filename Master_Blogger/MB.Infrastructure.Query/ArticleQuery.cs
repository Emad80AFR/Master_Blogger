
using System.Globalization;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;

namespace MB.Infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBloggerContext _context;

    public ArticleQuery(MasterBloggerContext context)
    {
        _context = context;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return _context.Articles.Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            Image = x.Image,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ArticleCategory = x.ArticleCategory.Title,
            CommentsCount = x.Comments.Count(x=>x.Status==Statuses.Confirmed),
        }).ToList();
    }

    public ArticleQueryView GetArticle(long id)
    {
        return _context.Articles.Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            Image = x.Image,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ArticleCategory = x.ArticleCategory.Title,
            Content = x.Content,
            CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),
            Comments = MapComments(x.Comments.Where(x=>x.Status==Statuses.Confirmed))

        }).FirstOrDefault(x=>x.Id==id)!;
    }

    private List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
    {
        
        return comments.Select(x=>new CommentQueryView
        {
            Name = x.Name,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            Message = x.Message

        }).ToList();
    }
}