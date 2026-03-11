using Microsoft.Data.Sqlite;
using System;

public class DatabaseHelper
{
    private string connectionString = "Data Source=voters.db";

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string tableCommand = @"
        CREATE TABLE IF NOT EXISTS Voters (
            VoterCardId TEXT PRIMARY KEY,
            NationalIdNumber TEXT,
            FirstName TEXT,
            MiddleName TEXT,
            Surname TEXT,
            PollingStation TEXT,
            DateOfBirth TEXT,
            Gender TEXT
        );";

        var command = new SqliteCommand(tableCommand, connection);
        command.ExecuteNonQuery();
    }

    public void AddVoter(Voter voter)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string insertCommand = @"
        INSERT INTO Voters 
        VALUES (@VoterCardId, @NationalIdNumber, @FirstName, @MiddleName, @Surname, @PollingStation, @DateOfBirth, @Gender);";

        var command = new SqliteCommand(insertCommand, connection);

        command.Parameters.AddWithValue("@VoterCardId", voter.VoterCardId);
        command.Parameters.AddWithValue("@NationalIdNumber", voter.NationalIdNumber);
        command.Parameters.AddWithValue("@FirstName", voter.FirstName);
        command.Parameters.AddWithValue("@MiddleName", voter.MiddleName);
        command.Parameters.AddWithValue("@Surname", voter.Surname);
        command.Parameters.AddWithValue("@PollingStation", voter.PollingStation);
        command.Parameters.AddWithValue("@DateOfBirth", voter.DateOfBirth.ToString("dd-MM-yyyy"));
        command.Parameters.AddWithValue("@Gender", voter.Gender);

        command.ExecuteNonQuery();
    }

    public void DisplayVoters()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string selectCommand = "SELECT * FROM Voters;";
        var command = new SqliteCommand(selectCommand, connection);
        using var reader = command.ExecuteReader();

        Console.WriteLine("\nREGISTERED VOTERS:");
        while (reader.Read())
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Voter Card ID: {reader["VoterCardId"]}");
            Console.WriteLine($"National ID: {reader["NationalIdNumber"]}");
            Console.WriteLine($"Name: {reader["FirstName"]} {reader["MiddleName"]} {reader["Surname"]}");
            Console.WriteLine($"Polling Station: {reader["PollingStation"]}");
            Console.WriteLine($"Date of Birth: {reader["DateOfBirth"]}");
            Console.WriteLine($"Gender: {reader["Gender"]}");
        }
    }
}