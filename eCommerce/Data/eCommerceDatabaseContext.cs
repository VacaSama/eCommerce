using System.Security.Cryptography.X509Certificates;
using eCommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data;

public class eCommerceDatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public eCommerceDatabaseContext(DbContextOptions options) : base(options)
    { }
        // intentionally left blank

        // need to retrieve the products from the database
}
