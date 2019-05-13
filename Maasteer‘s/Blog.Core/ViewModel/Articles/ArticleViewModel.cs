using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.ViewModel.Articles
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Auther { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime Date { get; set; }

    }
}
