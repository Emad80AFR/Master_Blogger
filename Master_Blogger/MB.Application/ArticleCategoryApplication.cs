using System.Globalization;
using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;
        private readonly IArticleCategoryValidatorService _validatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository repository, IArticleCategoryValidatorService validatorService)
        {
            _repository = repository;
            _validatorService = validatorService;
        }

        public List<ArticleCategoryViewModel> List()
        {
            return _repository.GetAll().Select(x=>new ArticleCategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }

        public void Create(CreateArticleCategory command)
        {
            var category = new ArticleCategory(command.Title,_validatorService);
            _repository.Add(category);
        }

        public void Rename(RenameArticleCategory command)
        {
            
            var category = _repository.GetBy(command.Id);
            category.Rename(command.Title);
            _repository.Save();
        }

        public RenameArticleCategory Get(long id)
        {
            var category = _repository.GetBy(id);
            return new RenameArticleCategory
            {
                Id = category.Id,
                Title = category.Title
            };

        }

        public void Remove(long id)
        {
            var category=_repository.GetBy(id);
            category.Remove();
            _repository.Save();
        }

        public void Activate(long id)
        {
            var category=_repository.GetBy(id);
            category.Activate();    
            _repository.Save();
        }

    }
}