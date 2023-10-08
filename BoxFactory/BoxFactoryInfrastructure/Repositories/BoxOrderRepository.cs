using BoxFactoryDomain.Entities;
using BoxFactoryDomain.RequestModels;
using BoxFactoryInfrastructure.Configuration;
using BoxFactoryInfrastructure.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace BoxFactoryInfrastructure.Repositories;

public sealed class BoxOrderRepository : IBoxOrderRepository
{
    private readonly string _connectionString;

    public BoxOrderRepository(DatabaseConnectionString dbConnectionString)
    {
        _connectionString = dbConnectionString.ConnectionString;
    }

    private SqlConnection GetSqlConnection => new(_connectionString);

    public async Task<List<BoxOrder>> GetAllOrders()
    {
        var result = new List<BoxOrder>();

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"
SELECT [Id]
      ,[Street]
      ,[Number]
      ,[City]
      ,[Zip]
      ,[OrderedAt]
      ,[ShippedAt]
FROM [BoxFactory].[dbo].[Orders]
";

            using (var command = new SqlCommand(query, connection))
            {
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    result.Add(new BoxOrder()
                    {
                        Id = reader.GetInt32(0),
                        Street = reader.GetString(1),
                        Number = reader.GetString(2),
                        City = reader.GetString(3),
                        Zip = reader.GetString(4),
                        OrderedAt = reader.GetDateTime(5),
                        ShippedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6)
                    });
                }
            }

            await connection.CloseAsync();
        }

        foreach (var order in result)
        {
            order.Lines = await GetBoxOrderLines(order.Id);
        }

        return result;
    }

    private async Task<BoxOrder?> GetOrderById(int id)
    {
        BoxOrder? result = null;

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"
SELECT [Id]
      ,[Street]
      ,[Number]
      ,[City]
      ,[Zip]
      ,[OrderedAt]
      ,[ShippedAt]
FROM [BoxFactory].[dbo].[Orders]
WHERE [Id] = @Id;
";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows && await reader.ReadAsync())
                {
                    result = new BoxOrder()
                    {
                        Id = reader.GetInt32(0),
                        Street = reader.GetString(1),
                        Number = reader.GetString(2),
                        City = reader.GetString(3),
                        Zip = reader.GetString(4),
                        OrderedAt = reader.GetDateTime(5),
                        ShippedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6)
                    };
                }
            }

            await connection.CloseAsync();
        }

        if (result is null)
            return null;

        result.Lines = await GetBoxOrderLines(result.Id);

        return result;
    }

    public async Task<bool> DeleteOrderById(int orderId)
    {
        bool result = false;

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"DELETE FROM [BoxFactory].[dbo].[Orders] WHERE [Id] = @OrderId";

            using (var command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@OrderId", orderId);

                var rowsAffected = await command.ExecuteNonQueryAsync();

                result = rowsAffected > 0;
            }

            await connection.CloseAsync();
        }

        return result;
    }

    public async Task<BoxOrder?> CreateOrder(string street, string number, string city, string zip, List<CreateOrderLine> list)
    {
        int? insertedId = null;

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"
INSERT INTO
    [Orders] ([Street], [Number], [City], [Zip]) OUTPUT INSERTED.Id
VALUES
     (@Street, @Number, @City, @Zip);
";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Zip", zip);

                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows && await reader.ReadAsync())
                {
                    insertedId = reader.GetInt32(0);
                }
            }

            await connection.CloseAsync();
        }

        if (insertedId is null)
            return null;

        var result = await GetOrderById(insertedId.Value);

        foreach (var line in list)
        {
            // TODO: ADD LINES TO DB
        }

        return result;
    }

    private async Task<HashSet<BoxOrderLine>> GetBoxOrderLines(int orderId)
    {
        var result = new HashSet<BoxOrderLine>();

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"
SELECT [OL].[Id]
      ,[OL].[BoxId]
      ,[OL].[Amount]
      ,[OL].[Price]
      ,[B].[Id]
      ,[B].[Width]
      ,[B].[Height]
      ,[B].[Length]
      ,[B].[Weight]
      ,[B].[Color]
      ,[B].[Price]
      ,[B].[CreatedAt]
FROM [BoxFactory].[dbo].[OrderLines] AS [OL]
JOIN [BoxFactory].[dbo].[Orders] AS [O] ON [O].[Id] = [OL].[OrderId]
JOIN [BoxFactory].[dbo].[Box] AS [B] ON [B].[Id] = [OL].[BoxId]
WHERE [OL].[OrderId] = @OrderId
";

            using (var command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@OrderId", orderId);

                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    result.Add(new BoxOrderLine()
                    {
                        Id = reader.GetInt32(0),
                        Amount = reader.GetInt32(2),
                        Price = reader.GetDouble(3),
                        Box = new Box()
                        {
                            Id = reader.GetInt32(4),
                            Width = reader.GetInt16(5),
                            Height = reader.GetInt16(6),
                            Length = reader.GetInt16(7),
                            Weight = reader.GetInt32(8),
                            Color = (BoxColor)reader.GetByte(9),
                            Price = reader.GetDouble(10),
                            CreatedAt = reader.GetDateTime(11),
                        }
                    });
                }
            }

            await connection.CloseAsync();
        }

        return result;
    }
}
