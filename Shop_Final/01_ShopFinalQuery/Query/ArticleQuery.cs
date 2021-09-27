using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_ShopFinalQuery.Contracts.Article;
using _01_ShopFinalQuery.Contracts.Comment;
using BlogManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_ShopFinalQuery.Query
{
    public class ArticleQuery:IArticleQuery
    {
        private readonly BlogContext _context;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext context, CommentContext commentContext)
        {
            _context = context;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article= _context.Articles
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryName = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    Slug = x.Slug,
                    CanonicalAddress = x.CanonicalAddress,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,
                }).FirstOrDefault(x=>x.Slug==slug);

            if (article != null && !string.IsNullOrWhiteSpace(article.Keywords))
                article.KeywordList = article.Keywords.Split(",").ToList();

            if (article != null)
            {
                var comments = _commentContext.Comments
                    .Where(x => !x.IsCanceled)
                    .Where(x => x.IsConfirmed)
                    .Where(x => x.Type == CommentType.Article)
                    .Where(x => x.OwnerRecordId == article.Id)
                    .Select(x => new CommentQueryModel
                    {
                        Id = x.Id,
                        Message = x.Message,
                        Name = x.Name,
                        CreationDate = x.CreationDate.ToFarsi(),
                        ParentId = x.ParentId,
                    }).OrderByDescending(x => x.Id).ToList();

                foreach (var comment in comments)
                {
                    if (comment.ParentId > 0)
                        comment.ParentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
                }

                article.Comments = comments;
            }
            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _context.Articles
                .Include(x=>x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Title = x.Title,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,
                }).ToList();
        }
    }
}
