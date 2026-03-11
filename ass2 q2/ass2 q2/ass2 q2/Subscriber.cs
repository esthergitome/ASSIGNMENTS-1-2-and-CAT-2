using System;
using System.Collections.Generic;
using System.Text;

namespace Safaricom_Points
{
    public class Subscriber
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Amount { get; set; }
        public int BonusPoints { get; set; }

        public Subscriber(string name, string phone, int amount)
        {
            Name = name;
            PhoneNumber = phone;
            Amount = amount;
            BonusPoints = 0;
        }

        public void compute_bonuspoints()
        {
            if (Amount >= 2000)
                BonusPoints = 500;
            else if (Amount >= 1000)
                BonusPoints = 300;
            else if (Amount >= 500)
                BonusPoints = 100;
            else if (Amount >= 100)
                BonusPoints = 50;
            else
                BonusPoints = 0;
        }
    }
}
