using System;
using System.Collections.Generic;
using Blog.Core.ViewModel.Articles;
using Blog.infrastructure.Model;
using Blog.Service.infrastructure.Service;

namespace Blog.Core.ViewModel.EntityToViewModelPropertyMapping
{
    public class ArticlePropertyMapping : PropertyMapping<ArticleViewModel, Article>
    {
        public ArticlePropertyMapping() : base(new Dictionary<string, List<MappedProperty>>
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
