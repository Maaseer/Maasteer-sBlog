using Blog.infrastructure.Interface;
using Blog.infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.Database
{
    public class ArticleRepository : IRepository
    {
        public ArticleRepository(MyDbContext myDbContext)
        {
            MyDbContext = myDbContext;
        }

        public MyDbContext MyDbContext { get; }
        
        //根据Id删除博客
        public async void DeleteArticle(int Id)
        {
            var result = await FindArticleByIdAsync(Id);
            MyDbContext.Articles.Remove(result);
        }

        //根据Id查找
        public async Task<Article> FindArticleByIdAsync(int Id)
        {
            return await MyDbContext.Articles.FirstOrDefaultAsync(x => x.Id == Id);
        }
        //查找所有的博客

        public async Task<IEnumerable<Article>> GetAllArticleAsync()
        {
            return await MyDbContext.Articles.ToListAsync();
        }

        //添加博客
        public void PostArticle(Article article)
        {
            MyDbContext.Articles.AddAsync(article);
        }
        //修改博客
        public async void PutArticle(Article article)
        {
            var result =  await MyDbContext.Articles.FirstOrDefaultAsync(x => x.Id == article.Id);
            result.Title = article.Title;
            result.Context = article.Context;
        }
    }
}
