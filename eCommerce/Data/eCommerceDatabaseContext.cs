using System.Security.Cryptography.X509Certificates;

namespace eCommerce.Data;

public class eCommerceDatabaseContext
{
    // connection string for the database 
    public string connectionString = "Data Source=localhost;Initial Catalog=MilkmanFarmsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public eCommerceDatabaseContext()
    {
        // Initialize the database context here
        // This could include setting up a connection string, configuring options, etc.
    }
}
