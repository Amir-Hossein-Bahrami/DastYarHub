using DastYarHub.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DastYarHub.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ToolUsage> ToolUsages { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketTool> MarketTools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MarketTool>()
                .HasKey(mt => new { mt.MarketId, mt.ToolId });

            modelBuilder.Entity<MarketTool>()
                .HasOne(mt => mt.Market)
                .WithMany(m => m.MarketTools)
                .HasForeignKey(mt => mt.MarketId);

            modelBuilder.Entity<MarketTool>()
                .HasOne(mt => mt.Tool)
                .WithMany(t => t.MarketTools)
                .HasForeignKey(mt => mt.ToolId);
        }
    }
}