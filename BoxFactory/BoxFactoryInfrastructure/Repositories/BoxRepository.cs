using BoxFactoryDomain.Entities;
using BoxFactoryInfrastructure.Configuration;
using BoxFactoryInfrastructure.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace BoxFactoryInfrastructure.Repositories;

public sealed class BoxRepository : IBoxRepository
{
    private readonly string _connectionString;

    public BoxRepository(DatabaseConnectionString dbConnectionString)
    {
        _connectionString = dbConnectionString.ConnectionString;
    }

    private SqlConnection GetSqlConnection => new(_connectionString);

    public async Task<List<Box>> GetAllBoxes()
    {
        var result = new List<Box>();

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"
SELECT [Id]
      ,[Width]
      ,[Height]
      ,[Length]
      ,[Weight]
      ,[Color]
      ,[Price]
      ,[CreatedAt]
  FROM [BoxFactory].[dbo].[Box]";

            using (var command = new SqlCommand(query, connection))
            {
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    result.Add(new Box()
                    {
                        Id = reader.GetInt32(0),
                        Width = reader.GetInt16(1),
                        Height = reader.GetInt16(2),
                        Length = reader.GetInt16(3),
                        Weight = reader.GetInt32(4),
                        Color = (BoxColor)reader.GetByte(5),
                        Price = reader.GetDouble(6),
                        CreatedAt = reader.GetDateTime(7),
                    });
                }
            }

            await connection.CloseAsync();
        }

        return result;
    }

    public async Task<Box?> GetBoxById(int id)
    {
        Box? result = null;

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"
SELECT [Id]
      ,[Width]
      ,[Height]
      ,[Length]
      ,[Weight]
      ,[Color]
      ,[Price]
      ,[CreatedAt]
FROM [BoxFactory].[dbo].[Box]
WHERE [Id] = @Id";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows && await reader.ReadAsync())
                {
                    result = new Box()
                    {
                        Id = reader.GetInt32(0),
                        Width = reader.GetInt16(1),
                        Height = reader.GetInt16(2),
                        Length = reader.GetInt16(3),
                        Weight = reader.GetInt32(4),
                        Color = (BoxColor)reader.GetByte(5),
                        Price = reader.GetDouble(6),
                        CreatedAt = reader.GetDateTime(7),
                    };
                }
            }

            await connection.CloseAsync();
        }

        return result;
    }

    public async Task<Box?> UpdateBox(int id, short width, short height, short length, int weight, BoxColor color, double price)
    {
        Box? box = await GetBoxById(id);

        if (box is null)
            return null;

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"
UPDATE [BoxFactory].[dbo].[Box] 
SET 
    [Width] = @Width,
    [Height] = @Height,
    [Length] = @Length,
    [Weight] = @Weight,
    [Color] = @Color,
    [Price] = @Price
WHERE [Id] = @Id
";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Width", width);
                command.Parameters.AddWithValue("@Height", height);
                command.Parameters.AddWithValue("@Length", length);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Color", color);
                command.Parameters.AddWithValue("@Price", price);

                var rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    box.Id = id;
                    box.Width = width;
                    box.Height = height;
                    box.Length = length;
                    box.Weight = weight;
                    box.Color = color;
                    box.Price = price;
                }
            }

            await connection.CloseAsync();
        }

        return box;
    }

    public async Task<bool> DeleteBoxById(int id)
    {
        bool result = false;

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"DELETE FROM [BoxFactory].[dbo].[Box] WHERE [Id] = @Id";

            using (var command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@Id", id);

                var rowsAffected = await command.ExecuteNonQueryAsync();

                result = rowsAffected > 0;
            }

            await connection.CloseAsync();
        }

        return result;
    }

    public async Task<Box?> Create(short width, short height, short length, int weight, BoxColor color)
    {
        int? insertedId = null;

        using (var connection = GetSqlConnection)
        {
            await connection.OpenAsync();

            const string query = @"
INSERT INTO [Box] 
([Width], [Height], [Length], [Weight], [Color])
OUTPUT INSERTED.Id
VALUES (@Width, @Height, @Length, @Weight, @Color);
";

            using (var command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@Width", width);
                command.Parameters.AddWithValue("@Height", height);
                command.Parameters.AddWithValue("@Length", length);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Color", color);

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

        var result = await GetBoxById(insertedId.Value);

        return result;
    }
}
