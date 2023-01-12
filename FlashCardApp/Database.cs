using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FlashCardApp;

public class Database
{
    private string LoadConnectionString()
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
        string connectionString = configuration.GetConnectionString("SqlServerConnection")!;
        return connectionString!;
    }

    public IDbConnection DbConnection()
    {
        var connectionString = LoadConnectionString();
        var connection = new SqlConnection(connectionString);
        return connection;
    }
}