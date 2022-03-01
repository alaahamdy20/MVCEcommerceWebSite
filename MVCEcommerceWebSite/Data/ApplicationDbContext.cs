using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCEcommerceWebSite.Models.Entities;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<FileUpload> FileUploads { get; set; }
        public virtual DbSet<ShoppingSession> ShoppingSessions { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            

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
