using Fuwans.Models;
using Microsoft.EntityFrameworkCore;

namespace Fuwans.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SiteHero> SiteHeroes => Set<SiteHero>();
    public DbSet<StoreFeature> StoreFeatures => Set<StoreFeature>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<BrandStory> BrandStories => Set<BrandStory>();
    public DbSet<NewsletterSubscriber> NewsletterSubscribers => Set<NewsletterSubscriber>();
    public DbSet<CustomerAccount> CustomerAccounts => Set<CustomerAccount>();
    public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasIndex(category => category.Slug)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasIndex(product => product.Slug)
            .IsUnique();

        modelBuilder.Entity<NewsletterSubscriber>()
            .HasIndex(subscriber => subscriber.Email)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .Property(product => product.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>()
            .Property(order => order.TotalAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<OrderItem>()
            .Property(item => item.UnitPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>()
            .HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductImage>()
            .HasOne(image => image.Product)
            .WithMany(product => product.Images)
            .HasForeignKey(image => image.ProductId);

        modelBuilder.Entity<CustomerAddress>()
            .HasOne(address => address.CustomerAccount)
            .WithMany(account => account.Addresses)
            .HasForeignKey(address => address.CustomerAccountId);

        modelBuilder.Entity<WishlistItem>()
            .HasOne(item => item.CustomerAccount)
            .WithMany(account => account.WishlistItems)
            .HasForeignKey(item => item.CustomerAccountId);

        modelBuilder.Entity<WishlistItem>()
            .HasOne(item => item.Product)
            .WithMany()
            .HasForeignKey(item => item.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cart>()
            .HasOne(cart => cart.CustomerAccount)
            .WithMany(account => account.Carts)
            .HasForeignKey(cart => cart.CustomerAccountId);

        modelBuilder.Entity<CartItem>()
            .HasOne(item => item.Cart)
            .WithMany(cart => cart.Items)
            .HasForeignKey(item => item.CartId);

        modelBuilder.Entity<CartItem>()
            .HasOne(item => item.Product)
            .WithMany()
            .HasForeignKey(item => item.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(order => order.CustomerAccount)
            .WithMany(account => account.Orders)
            .HasForeignKey(order => order.CustomerAccountId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(item => item.Order)
            .WithMany(order => order.Items)
            .HasForeignKey(item => item.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(item => item.Product)
            .WithMany()
            .HasForeignKey(item => item.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
