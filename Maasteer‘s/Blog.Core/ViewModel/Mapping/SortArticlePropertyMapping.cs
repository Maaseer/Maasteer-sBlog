using System;
using System.Collections.Generic;
using Blog.Core.ViewModel.Articles;
using Blog.infrastructure.Model;
using Blog.Service.infrastructure.Service;

//排序用属性映射
namespace Blog.Core.ViewModel.EntityToViewModelPropertyMapping
{
    public class SortArticlePropertyMapping : PropertyMapping<ArticleViewModel, Article>
    {
        public SortArticlePropertyMapping() : base(new Dictionary<string, List<MappedProperty>>
        (StringComparer.OrdinalIgnoreCase)
        {
            [nameof(ArticleViewModel.Title)] = new List<MappedProperty>
            {
                new MappedProperty { Name = nameof(Article.Title), Order = false }
            },
            [nameof(ArticleViewModel.Auther)] = new List<MappedProperty>
            {
                new MappedProperty{Name = nameof(Article.Auther),Order = false}
            },
            [nameof(ArticleViewModel.Date)] = new List<MappedProperty>
            {
                new MappedProperty{Name = nameof(Article.Date),Order = false}
            },
            [nameof(ArticleViewModel.Context)] = new List<MappedProperty>
            {
                new MappedProperty{Name = nameof(Article.Context),Order = false}
            }
        })
        {    
        }
    }
}
