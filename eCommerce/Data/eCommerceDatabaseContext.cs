using System.Security.Cryptography.X509Certificates;
using eCommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data;

public class eCommerceDatabaseContext : DbContext
{
    /// <summary>
    /// Gets and or sets the collection of Product in the database
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Gets and or sets the collection of Customer in the database
    /// </summary>
    public DbSet<Customer> Customers { get; set; }
    /// <summary>
    /// Gets and or sets the collection of Order in the database
    /// </summary>

    public DbSet<Order> Orders { get; set; }

    /// <summary>
    /// Gets and or sets the collection of OrderDetail in the database
    /// </summary>
    public DbSet<OrderDetail> OrderDetails { get; set; }

    /// <summary> --- NOT IMPLEMENTED YET ---
    /// Gets and or sets the collection of OrderDetail in the database
    /// </summary>
    public DbSet<CartItem> CartItems { get; set; }

    public eCommerceDatabaseContext(DbContextOptions options) : base(options)
    { }
        // intentionally left blank
        // need to retrieve the products from the database
}
