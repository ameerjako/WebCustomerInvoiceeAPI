using Microsoft.EntityFrameworkCore;
using WebCustomerInvoiceAPI.Models;

namespace WebCustomerInvoiceAPI.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customer {  get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Orderdetail> Orderdetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

    }
}
