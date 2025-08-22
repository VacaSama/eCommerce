using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;

namespace eCommerce.Data;

public class eCommerceDatabaseContext
{
    // connection string for the database 
    public string connectionString = "Data Source=localhost;Initial Catalog=MilkmanFarmsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public eCommerceDatabaseContext()
    {
        // Initialize the database context here
        // This could include setting up a connection string, configuring options, etc.
        using (var connection = new SqlConnection(connectionString))
        {
            // open the connection to the database 
            connection.Open();
            // You can perform database operations here,
            // such as checking if the connection is successful


            // use a try -catch block to handle any exceptions that may occur?
        }
    }
}
