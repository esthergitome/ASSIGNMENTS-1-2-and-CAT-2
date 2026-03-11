using Microsoft.Data.Sqlite;
using System;

public class VehicleDatabase
{
    private string connectionString = "Data Source=vehicles.db";

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string tableCommand = @"
        CREATE TABLE IF NOT EXISTS Vehicles (
            EngineNumber TEXT PRIMARY KEY,
            Make TEXT,
            Model TEXT,
            SalePrice REAL,
            Profit REAL
        );";

        var command = new SqliteCommand(tableCommand, connection);
        command.ExecuteNonQuery();
    }

    public void AddVehicle(Vehicle v)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string insertCommand = @"
        INSERT INTO Vehicles 
        VALUES (@EngineNumber, @Make, @Model, @SalePrice, @Profit);";

        var command = new SqliteCommand(insertCommand, connection);

        command.Parameters.AddWithValue("@EngineNumber", v.EngineNumber);
        command.Parameters.AddWithValue("@Make", v.Make);
        command.Parameters.AddWithValue("@Model", v.Model);
        command.Parameters.AddWithValue("@SalePrice", v.SalePrice);
        command.Parameters.AddWithValue("@Profit", v.GetProfit());

        command.ExecuteNonQuery();
    }

    public void DisplayVehicles()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string selectCommand = "SELECT * FROM Vehicles;";
        var command = new SqliteCommand(selectCommand, connection);
        using var reader = command.ExecuteReader();

        Console.WriteLine("\n--- Vehicle Records ---");

        while (reader.Read())
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Make: {reader["Make"]}");
            Console.WriteLine($"Model: {reader["Model"]}");
            Console.WriteLine($"Engine No: {reader["EngineNumber"]}");
            Console.WriteLine($"Sale Price: {reader["SalePrice"]}");
            Console.WriteLine($"Profit: {reader["Profit"]}");
        }
    }
}