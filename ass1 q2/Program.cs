using System;

class Program
{
    static void Main()
    {
        VehicleDatabase db = new VehicleDatabase();
        db.InitializeDatabase();

        while (true)
        {
            Console.WriteLine("\nDT DOBIE VEHICLE SALES SYSTEM");
            Console.WriteLine("1. Add New Vehicle Sale");
            Console.WriteLine("2. Display All Vehicles & Profit");
            Console.WriteLine("3. Exit");
            Console.Write("Select option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Vehicle v = new Vehicle();
                v.SetVehicle();

                db.AddVehicle(v);
                Console.WriteLine("Vehicle recorded successfully!");
            }
            else if (choice == "2")
            {
                db.DisplayVehicles();
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