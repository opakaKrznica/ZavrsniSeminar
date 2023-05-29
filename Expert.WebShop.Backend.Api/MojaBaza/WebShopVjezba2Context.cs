using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Expert.WebShop.Backend.Api.MojaBaza;

public partial class WebShopVjezba2Context : DbContext
{
    public WebShopVjezba2Context()
    {
    }

    public WebShopVjezba2Context(DbContextOptions<WebShopVjezba2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ShoppingCard> ShoppingCards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<ShoppingCard>(entity =>
        {
            entity.ToTable("ShoppingCard");

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCards)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCard_Product");
        });
    }
}