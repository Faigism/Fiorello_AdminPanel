using Fiorello_AdminPanel.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fiorello_AdminPanel.DAL
{
    public class FiorelloDbContext:IdentityDbContext
    {
        public FiorelloDbContext(DbContextOptions<FiorelloDbContext> options):base(options) { }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<FlowerCategory> FlowerCategories { get; set; }
        public DbSet<FlowerImage> FlowerImages { get; set; }
        public DbSet<FlowerTag> FlowerTags { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlowerCategory>().HasKey(x => new { x.FlowerId, x.CategoryId });
            modelBuilder.Entity<FlowerTag>().HasKey(x => new { x.FlowerId, x.TagId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
