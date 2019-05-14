﻿// <auto-generated />
using System;
using Blog.infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.infrastructure.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20190514054549_AddModifyTimieAndRemark")]
    partial class AddModifyTimieAndRemark
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Blog.infrastructure.Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Auther");

                    b.Property<string>("Context");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("LastModeify");

                    b.Property<string>("Remark");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Auther = "admin",
                            Context = "This is my first Article",
                            Date = new DateTime(2019, 5, 14, 13, 45, 48, 243, DateTimeKind.Local).AddTicks(3116),
                            LastModeify = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "First Welcome Article"
                        },
                        new
                        {
                            Id = 2,
                            Auther = "管理员",
                            Context = "这是我的第二篇博客",
                            Date = new DateTime(2019, 5, 14, 13, 45, 48, 246, DateTimeKind.Local).AddTicks(4968),
                            LastModeify = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "第二个博客"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
