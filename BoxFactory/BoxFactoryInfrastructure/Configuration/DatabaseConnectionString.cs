namespace BoxFactoryInfrastructure.Configuration;

public sealed class DatabaseConnectionString
{
    public string ConnectionString { get; }

    public DatabaseConnectionString(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
