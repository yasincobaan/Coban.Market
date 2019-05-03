using System.Data.Entity;
using Coban.Market.Entities;

namespace Coban.Market.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MarketUser> MarketUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liked> Likes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<FAQ> Faqs { get; set; }
        public DbSet<ProductWishlist> ProductWishlists { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserAddress> UserAddresss { get; set; }
        public DbSet<CargoNames> Cargo { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
