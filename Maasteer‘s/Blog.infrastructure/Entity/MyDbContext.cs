using Blog.infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blog.infrastructure.Entity
{

    public  class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(x => x.Id);
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Auther = "admin",
                    Title = "First Welcome Article",
                    Context = "This is my first Article",
                    Date = DateTime.Now,
                },
                new Article
                {
                    Id = 2,
                    Auther = "管理员",
                    Title = "第二个博客",
                    Context = "这是我的第二篇博客",
                    Date = DateTime.Now,
                }
                );

        }

        public DbSet<Article> Articles{get;set;}
    }
}
