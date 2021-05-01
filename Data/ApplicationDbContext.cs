using System;
using System.Collections.Generic;
using System.Text;
using BlazorJob.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorJob.Data;

namespace BlazorJob.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Meta> MetaList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.UseSerialColumns();
            builder.ApplyConfiguration(new PostEntityConfiguration());
            builder.ApplyConfiguration(new OptionEntityConfiguration());
            builder.ApplyConfiguration(new MetaEntityConfiguration());

            //builder.Entity<ApplicationUser>(b =>
            //{
            //    b.Property(u => u.Id);//.HasDefaultValueSql("newsequentialid()");
            //});

            //builder.Entity<Role>(b =>
            //{
            //    b.Property(u => u.Id);//.HasDefaultValueSql("newsequentialid()");
            //});

            //builder.Entity<RoleClaim>(b =>
            //{
            //    b.Property(u => u.Id);//.HasDefaultValueSql("newsequentialid()");
            //});
            //builder.Entity<UserClaim>(b =>
            //{
            //    b.Property(u => u.Id);//.HasDefaultValueSql("newsequentialid()");
            //});
            //builder.Entity<UserToken>(b =>
            //{
            //    b.Property(u => u.UserId);//.HasDefaultValueSql("newsequentialid()");
            //});
            //builder.Entity<UserLogin>(b =>
            //{
            //    b.Property(u => u.UserId);//.HasDefaultValueSql("newsequentialid()");
            //});

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
