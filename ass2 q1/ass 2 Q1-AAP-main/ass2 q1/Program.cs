using System;

class Program
{
    static void Main()
    {
        DatabaseHelper db = new DatabaseHelper();
        db.InitializeDatabase();

        while (true)
        {
            Console.WriteLine("\n=== EVMS MENU ===");
            Console.WriteLine("1. Add Voter");
            Console.WriteLine("2. Display Voters");
            Console.WriteLine("3. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                Voter voter = new Voter();

                Console.Write("Voter Card ID: ");
                voter.VoterCardId = Console.ReadLine() ?? "";

                Console.Write("National ID Number: ");
                voter.NationalIdNumber = Console.ReadLine() ?? "";

                Console.Write("First Name: ");
                voter.FirstName = Console.ReadLine() ?? "";

                Console.Write("Middle Name: ");
                voter.MiddleName = Console.ReadLine() ?? "";

                Console.Write("Surname: ");
                voter.Surname = Console.ReadLine() ?? "";

                Console.Write("Polling Station: ");
                voter.PollingStation = Console.ReadLine() ?? "";

                Console.Write("Date of Birth (dd-mm-yyyy): ");
                voter.DateOfBirth = DateTime.ParseExact(Console.ReadLine() ?? "", "dd-MM-yyyy", null);

                Console.Write("Gender: ");
                voter.Gender = Console.ReadLine() ?? "";

                db.AddVoter(voter);
                Console.WriteLine("Voter added successfully!");
            }
            else if (choice == "2")
            {
                db.DisplayVoters();
            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}