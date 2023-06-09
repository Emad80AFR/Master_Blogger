﻿using FrameWork.Infrastructure;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository:IRepository<long,ArticleCategory>
    {
        void Save();
        bool Exist(string title);
    }
}
