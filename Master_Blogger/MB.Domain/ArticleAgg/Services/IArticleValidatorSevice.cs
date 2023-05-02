namespace MB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        void CheckThatThisRecordIsAlreadyExist(string title);
    }
}
