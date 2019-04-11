using System;

namespace Blog.infrastructure.Model
{
    public class Article
    {
        
        public int Id { get; set; }
        public string Auther { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime Date { get; set; }

    }
}
