using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FlashCardApp.Services;

public class Database
{
    private string LoadConnectionString()
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;
        return connectionString!;
    }

    public IDbConnection DbConnection()
    {
        var connectionString = LoadConnectionString();
        var connection = new SqlConnection(connectionString);
        return connection;
    }
}