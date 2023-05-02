using MB.Application.Contract.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment entity);
        void Save();
        List<CommentViewModel> GetAll();
        Comment GetBy(long id);
    }
}
