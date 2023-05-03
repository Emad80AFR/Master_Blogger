using FrameWork.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory() { }
        public ArticleCategory(string title,IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);
            validatorService.CheckThatThisRecordIsAlreadyExist(Title!);

            Title = title;
            IsDeleted = default;
            Articles = new List<Article>();
        }

        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);

            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
        void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();

        }
    }
}