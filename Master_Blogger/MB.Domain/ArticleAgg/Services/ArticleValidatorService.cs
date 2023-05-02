﻿namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService:IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckThatThisRecordIsAlreadyExist(string title)
        {
            if (_articleRepository.Exist(title))
                throw new InvalidOperationException();

        }
    }
}
