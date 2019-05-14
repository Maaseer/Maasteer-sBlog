using Blog.Core.Database.Pagination;
using Blog.Core.ViewModel.Articles;
using Blog.infrastructure.Model;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public interface IArticleRepository
    {
        //声明接口
        void PostArticle(Article article);
        Task<PaginatedList<Article>> GetAllArticleAsync(ArticlePrameters articlePrameters);
        void PutArticle(Article article);
        void DeleteArticle(Article article);
        Task<Article> FindArticleByIdAsync(int Id);
    }
}
