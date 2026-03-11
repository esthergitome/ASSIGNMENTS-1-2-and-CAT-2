using System;

public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string EngineNumber { get; set; }
    public double SalePrice { get; set; }

    public void SetVehicle()
    {
        Console.Write("Enter Make: ");
        Make = Console.ReadLine();

        Console.Write("Enter Model: ");
        Model = Console.ReadLine();

        Console.Write("Enter Engine Number: ");
        EngineNumber = Console.ReadLine();

        Console.Write("Enter Sale Price (KSh): ");
        SalePrice = double.Parse(Console.ReadLine());
    }

    public double GetProfit()
    {
        return SalePrice * 0.15;
    }
}