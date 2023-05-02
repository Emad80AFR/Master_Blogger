using MB.Application.Contract.Article;

namespace MB.Application.Contract.Comment
{
    public interface ICommentApplication
    {
        void Add(AddComment command);
        List<CommentViewModel> GetList();
        void Confirm(long id);
        void Cancel(long id);
    }
}
