using System;
using System.Collections.Generic;
using System.Text;

namespace Safaricom_Points
{
    public class Subscriptions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Amount { get; set; }
        public int AwardedPoints { get; set; }
    }
}
