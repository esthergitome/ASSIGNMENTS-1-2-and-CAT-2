using Microsoft.Data.Sqlite;
using System;

public class DatabaseHelper
{
    private string connectionString = "Data Source=library.db";

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string tableCommand = @"
        CREATE TABLE IF NOT EXISTS Books (
            BookNumber TEXT PRIMARY KEY,
            Title TEXT,
            Author TEXT,
            Price REAL,
            Copies INTEGER
        );";

        var command = new SqliteCommand(tableCommand, connection);
        command.ExecuteNonQuery();
    }

    public void InsertBook(Book book)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string insertCommand = @"
        INSERT INTO Books 
        VALUES (@BookNumber, @Title, @Author, @Price, @Copies);";

        var command = new SqliteCommand(insertCommand, connection);

        command.Parameters.AddWithValue("@BookNumber", book.BookNumber);
        command.Parameters.AddWithValue("@Title", book.Title);
        command.Parameters.AddWithValue("@Author", book.Author);
        command.Parameters.AddWithValue("@Price", book.Price);
        command.Parameters.AddWithValue("@Copies", book.Copies);

        command.ExecuteNonQuery();
    }

    public void DisplayAllBooks()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string selectCommand = "SELECT * FROM Books;";
        var command = new SqliteCommand(selectCommand, connection);
        using var reader = command.ExecuteReader();

        Console.WriteLine("\n--- Book List ---");

        while (reader.Read())
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Book Number: {reader["BookNumber"]}");
            Console.WriteLine($"Title: {reader["Title"]}");
            Console.WriteLine($"Author: {reader["Author"]}");
            Console.WriteLine($"Price: {reader["Price"]}");
            Console.WriteLine($"Copies: {reader["Copies"]}");
        }
    }
}