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
                .HasColumnName("id")
                .UseSerialColumn();


            entity.Property(e => e.CreatedDate)
                .HasColumnName("created_date")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.UpdatedDate)
                .HasColumnName("updated_date")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasDefaultValueSql("0");

            entity.Property(e => e.Text)
                .HasColumnName("text")
                .HasDefaultValueSql("0");
        }


    }

}