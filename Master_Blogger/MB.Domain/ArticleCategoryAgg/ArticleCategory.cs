﻿namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreateDate { get; private set; }

        public ArticleCategory(string title)
        {
            Title = title;
            CreateDate=DateTime.Now;
            IsDeleted = default;
        }
    }
}