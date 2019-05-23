using Blog.Core.Database.Pagination;
using Blog.infrastructure.Model;
using Blog.Service.infrastructure.Service;
using Blog.Service.infrastructure.SortPropertyMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.ViewModel.Articles;
using Blog.infrastructure.Entity;

namespace Blog.Core.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public ArticleRepository(MyDbContext myDbContext, ILoggerFactory logger,IPropertyMappingContainer propertyMappingContainer)
        {
            MyDbContext = myDbContext;
            Logger = logger;
            PropertyMappingContainer = propertyMappingContainer;
        }

        public MyDbContext MyDbContext { get; }
        public ILoggerFactory Logger { get; }
        public IPropertyMappingContainer PropertyMappingContainer { get; }

        //根据Id删除博客
        public void DeleteArticle(Article article)
        {
            MyDbContext.Articles.Remove(article);
        }

        //根据Id查找
        public async Task<Article> FindArticleByIdAsync(int Id)
        {
            return await MyDbContext.Articles.FirstOrDefaultAsync(x => x.Id == Id);
        }
        //查找所有的博客

        public async Task<PaginatedList<Article>> GetAllArticleAsync(ArticlePrameters articlePrameters)
        {
            var result = MyDbContext.Articles.AsQueryable();
            //执行过滤操作

            if (!string.IsNullOrEmpty(articlePrameters.Title))//标题
                result = result.Where(x => x.Title.ToLowerInvariant() == articlePrameters.Title.ToLowerInvariant());
            if (!string.IsNullOrEmpty(articlePrameters.Auther))//作者
                result = result.Where(x => x.Auther.ToLowerInvariant() == articlePrameters.Auther.ToLowerInvariant());
            if (articlePrameters.AfterTime != null)//在某个时间之后
                result = result.Where(x => x.Date.CompareTo(articlePrameters.AfterTime) >= 0);
            if (articlePrameters.BeforeTime != null)//在某个时间之前
                result = result.Where(x => x.Date.CompareTo(articlePrameters.BeforeTime) <= 0);

            //执行模糊查询操作
            if (!string.IsNullOrEmpty(articlePrameters.Contain))//标题包含
                result = result.Where(x => x.Title.ToLowerInvariant().Contains(articlePrameters.Contain.ToLowerInvariant()));
            
            //根据排序选项排序
            result = result.ApplySort(articlePrameters.OrderBy, PropertyMappingContainer.Resolve<ArticleViewModel,Article>());

            //计算文章数量
            var count = await result.CountAsync();

            //执行分页操作
            var data = await result.Skip(articlePrameters.PageSize * articlePrameters.PageIndex).Take(articlePrameters.PageSize).ToListAsync();

            return new PaginatedList<Article>(articlePrameters.PageSize, articlePrameters.PageIndex, count, data); 
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
