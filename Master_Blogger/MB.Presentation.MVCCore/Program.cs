using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using MB.Application.Contract.Comment;
using MB.Application;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.core;
using MB.Infrastructure.EFCore.Repositories;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

namespace MB.Presentation.MVCCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            Bootstrapper.Config(builder.Services, builder.Configuration.GetConnectionString("MasterBloggerDB"));

            var app = builder.Build();



            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}