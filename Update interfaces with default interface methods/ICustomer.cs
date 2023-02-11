

// Interface for the customers, but we want to updte it to add a feature, so we enhance this interface with a method
//update it - the loyalty discount
namespace customer_relationship
{
    public interface ICustomer
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }


        public static void SetLoyaltyThresholds(TimeSpan ago, int minimumOrders = 10, decimal percentageDiscount = 0.10m)
        {
            length = ago;
            orderCount = minimumOrders;
            discountPercent = percentageDiscount;
        }
        private static TimeSpan length = new TimeSpan(365 * 2, 0, 0, 0);
        private static int orderCount = 10;
        private static decimal discountPercent = 0.10m;

        //Version 1 
        //public decimal ComputeloyaltyDiscount()
        //{
        //    DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
        //    if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
        //    {
        //        return 0.10m;
        //    }
        //    return 0;
        //}

        public decimal ComputeLoyaltyDiscount() => DefaultLoyaltyDiscount(this);

        protected static decimal DefaultLoyaltyDiscount(ICustomer c)
        {
            DateTime start = DateTime.Now - length;

            if ((c.DateJoined < start) && (c.PreviousOrders.Count() > orderCount))
            {
                return discountPercent;
            }
            return 0;
        }
         
    }
}