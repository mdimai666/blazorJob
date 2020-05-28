using System;
using System.Collections.Generic;
using System.Text;
using BlazorJob.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorJob.Data
{

    public class OptionEntityConfiguration : IEntityTypeConfiguration<OptionEntity>
    {
        public void Configure(EntityTypeBuilder<OptionEntity> entity)
        {
            entity.ToTable("options");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseSerialColumn();


            entity.Property(e => e.Date)
                .HasColumnName("created_date")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Modified)
                .HasColumnName("updated_date")
                .HasDefaultValueSql("now()");


            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValue(OptionEntity.defaultStatus);

            entity.Property(e => e.Type)
                .HasColumnName("type")
                .HasDefaultValue(OptionEntity.defaultType);

            entity.Property(e => e.Key)
                .HasColumnName("key")
                .IsRequired();

            entity.Property(e => e.Value)
                .HasColumnName("value");

            entity.Property(e => e.Author)
                .HasColumnName("author");



        }


    }

}