using AutoMapper;
using Blog.Core.ViewModel.Articles;
using Blog.infrastructure.Model;

namespace Blog.Core.ViewModel.EntityToViewModelPropertyMapping
{
    //使用AutoMapper进行Model-ViewModel之间的属性映射
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //创建双向属性映射
            CreateMap<Article, ArticleViewModel>();
            CreateMap<ArticleViewModel, Article>();
        }
    }
}
