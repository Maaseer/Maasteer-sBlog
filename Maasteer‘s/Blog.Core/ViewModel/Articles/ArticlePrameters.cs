using Blog.Core.Database.Pagination;
using System;

//执行过滤操作的属性类
namespace Blog.Core.ViewModel.Articles
{
    public class ArticlePrameters:QueryParameters
    {
        public string  Title { get; set; }
        public string Contain { get; set; }
        public string Auther { get; set; }

        public DateTime? BeforeTime { get; set; }

        public DateTime? AfterTime { get; set; }

    }
}
