using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCEcommerceWebSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<TagImage> TagImages { get; set; }
        public virtual DbSet<CategoryImage> CategoryImages { get; set; }
        public virtual DbSet<FileUpload> FileUploads { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            



            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ProductId });

                entity.Property(e => e.CategoryId);

                entity.Property(e => e.ProductId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
                //.OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
                //.OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.User).WithMany()
                    .HasForeignKey(o => o.UserId).IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(o => o.OrderItems)
                    .WithOne(oi => oi.Order)
                    .HasForeignKey(o => o.OrderId).IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(o => o.Address).WithMany((string)null)
                    .HasForeignKey(o => o.AddressId).IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(oi => oi.User)
                    .WithMany((string)null).HasForeignKey(oi => oi.UserId)
                    .IsRequired(false).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(oi => oi.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId).IsRequired(true)
                    .OnDelete(DeleteBehavior.NoAction);
            });


            //I am not using it for the moment I really have my doubts on how to manage Rating / Comment / Replies feature.


            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Description);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.ProductId });

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<TagImage>(entity =>
            {
                entity.HasBaseType<FileUpload>();
                entity.HasOne(ti => ti.Tag)
                    .WithMany(t => t.TagImages)
                    .HasForeignKey(ti => ti.TagId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CategoryImage>(entity =>
            {
                entity.HasBaseType<FileUpload>();
                entity.HasOne(ti => ti.Category)
                    .WithMany(t => t.CategoryImages)
                    .HasForeignKey(ti => ti.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasBaseType<FileUpload>();
                entity.HasOne(pi => pi.Product)
                    .WithMany(t => t.ProductImages)
                    .HasForeignKey(ti => ti.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
