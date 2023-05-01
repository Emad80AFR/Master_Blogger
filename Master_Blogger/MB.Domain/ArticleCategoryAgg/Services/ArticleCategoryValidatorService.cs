using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services;

public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public void CheckThatThisRecordIsAlreadyExist(string title)
    {
        if (_articleCategoryRepository.Exist(title))
        {
            throw new DuplicationExeption("This record is already exists");
        }
    }
}