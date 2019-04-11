using Blog.infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{

    public class MyDbContext : DbContext
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

                }
                );

        }

        public DbSet<Article> Articles{get;set;}
    }
}
