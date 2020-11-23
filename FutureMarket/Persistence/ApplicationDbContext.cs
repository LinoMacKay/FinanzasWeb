using Microsoft.EntityFrameworkCore;
using FoodYeah.Model;
using FoodYeah.Persistence.Config;
using FoodYeah.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace FoodYeah.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser, 
        ApplicationRole, 
        string,
        IdentityUserClaim<string>,
        ApplicationUserRole,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product_Category> Product_Categories { get; set; }
        public DbSet<QuoteDetail> QuoteDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer_Category> Customer_Categories { get; set; }
        public DbSet<LOC> LOCs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new TransactionConfig(builder.Entity<Transaction>());
            new CardConfig(builder.Entity<Card>());
            new CustomerConfig(builder.Entity<Customer>());
            new OrderConfig(builder.Entity<Order>()); 
            new OrderDetailConfig(builder.Entity<OrderDetail>());
            new QuoteDetailsConfig(builder.Entity<QuoteDetail>());
            new Product_CategoryConfig(builder.Entity<Product_Category>());
            new ProductConfig(builder.Entity<Product>());
            new Customer_CategoryConfig(builder.Entity<Customer_Category>());
            new ApplicationUserConfig(builder.Entity<ApplicationUser>());
            new ApplicationRoleConfig(builder.Entity<ApplicationRole>());
            new LOCConfig(builder.Entity<LOC>());

        }
    }
}
