using SqliteExample;
using Safaricom_Points;

namespace Safaricom_Points
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Airtime Amount (Ksh): ");
            int amount = int.Parse(Console.ReadLine());

            Subscriber sub = new Subscriber(name, phone, amount);
            sub.compute_bonuspoints();

            Console.WriteLine($"\n{sub.Name.ToUpper()} :(PHONE NO:{sub.PhoneNumber}): AWARDED {sub.BonusPoints} BONGA POINTS. STAY WITH SAFARICOM. THE BETTER OPTION!");

            DataContext context = new DataContext();

            Subscriptions record = new Subscriptions
            {
                Name = sub.Name,
                PhoneNumber = sub.PhoneNumber,
                Amount = sub.Amount,
                AwardedPoints = sub.BonusPoints
            };

            context.Subscription.Add(record);
            context.SaveChanges();

            Console.WriteLine("\nRecord saved to database!");

            Console.WriteLine("\n--- DATABASE RECORDS ---");
            foreach (var r in context.Subscription)
            {
                Console.WriteLine($"{r.Name} | {r.PhoneNumber} | Ksh.{r.Amount} | {r.AwardedPoints} Points");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}