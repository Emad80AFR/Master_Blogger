﻿using MB.Application.Contract.Article;
using MB.Application.Contract.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            
            var comment= new Comment(command.Name,command.Email,command.Message,command.ArticleId);
            _commentRepository.Create(comment);
        }

        public List<CommentViewModel> GetList()
        {
            
            return _commentRepository.GetList();
        }

        public void Confirm(long id)
        {

            var comment=_commentRepository.Get(id);
            comment.Confirm();
            _commentRepository.Save();
        }

        public void Cancel(long id)
        {

            var comment = _commentRepository.Get(id);
            comment.Cancel();
            _commentRepository.Save();
        }
    }
}
