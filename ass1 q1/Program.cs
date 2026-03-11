using System;

class Program
{
    static void Main()
    {
        DatabaseHelper db = new DatabaseHelper();
        db.InitializeDatabase();

        while (true)
        {
            Console.WriteLine("\nBOOKER UNIVERSITY LIBRARY");
            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. Display All Books");
            Console.WriteLine("3. Exit");
            Console.Write("Choose option (1-3): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Book book = new Book();

                Console.Write("Enter Book Number: ");
                book.BookNumber = Console.ReadLine();

                Console.Write("Enter Title: ");
                book.Title = Console.ReadLine();

                Console.Write("Enter Author: ");
                book.Author = Console.ReadLine();

                Console.Write("Enter Price: ");
                book.Price = double.Parse(Console.ReadLine());

                Console.Write("Enter Number of Copies: ");
                book.Copies = int.Parse(Console.ReadLine());

                db.InsertBook(book);
                Console.WriteLine("Book added successfully!");
            }
            else if (choice == "2")
            {
                db.DisplayAllBooks();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Thank you! Goodbye.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}