using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models.EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            var d = new Data(this);
            d.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseMySql(
                "server=localhost;uid=root;password=Password123!;database=ShoppingCartEF;",
                new MySqlServerVersion(new Version(8, 0, 31))
            );
        }

        public DbSet<UserModel> users { get; set; }
        public DbSet<SoftwareModel> softwares { get; set; }
        public DbSet<PurchaseModel> purchases { get; set; }
    }
}
