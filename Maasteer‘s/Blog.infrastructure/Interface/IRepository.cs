using Blog.infrastructure.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.infrastructure.Interface
{
    public interface IRepository
    {
        //声明接口
        void PostArticle(Article article);
        Task<IEnumerable<Article>> GetAllArticleAsync();
        void PutArticle(Article article);
        void DeleteArticle(int Id);
        Task<Article> FindArticleByIdAsync(int Id);
    }
}
