using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Context
{
    public interface IFakeStoreApiContext
    {
        DbSet<Product> Product { get; set; }
        DbSet<Category> Category { get; set; }

        EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();

    }

    public class FakeStoreApiContext:DbContext,IFakeStoreApiContext
    {
        public FakeStoreApiContext() : base() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Products)
                .WithOne(x => x.Category).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade).HasPrincipalKey(x => x.CategoryId);
            modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DBConnection"));
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
