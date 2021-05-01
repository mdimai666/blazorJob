using System;
using System.Collections.Generic;
using System.Text;
using BlazorJob.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorJob.Data
{

    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
        {
            entity.ToTable("posts");

            entity.Property(e => e.Id)
                .HasColumnName("id");
                //.UseSerialColumn();


            entity.Property(e => e.Date)
                .HasColumnName("created_date")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Modified)
                .HasColumnName("updated_date")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Title)
                .HasColumnName("title")
                .IsRequired();

            entity.Property(e => e.Content)
                .HasColumnName("content")
                .HasDefaultValue("");

            entity.Property(e => e.Author)
                .HasColumnName("author");
                //.HasDefaultValue(0);

            entity.Property(e => e.Parent)
                .HasColumnName("parent");
                //.HasDefaultValue(0);

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValue(Post.defaultStatus);

            entity.Property(e => e.Type)
                .HasColumnName("type")
                .HasDefaultValue(Post.defaultType);

            ////
            entity.Property(e => e.Slug)
                .HasColumnName("slug");

            entity.Property(e => e.Tags)
                .HasColumnName("tags");

            entity.Property(e => e.Category)
                .HasColumnName("category");
                //.HasDefaultValue(0);

            entity.Property(e => e.Guid)
                .HasColumnName("guid");

            entity.Property(e => e.Excerpt)
                .HasColumnName("excerpt")
                .HasDefaultValue("");


        }


    }

}