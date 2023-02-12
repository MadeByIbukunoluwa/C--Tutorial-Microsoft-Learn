
//https:\//learn.microsoft.com\/en-us/dotnet/csharp/tutorials/default-interface-methods-versions
// Safely add members to an interface already released and used by innumerable clients




namespace customer_relationship
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleCustomer c = new SampleCustomer("customer one", new DateTime(2023, 6, 7)){
                Reminders =
                {
                    {new DateTime(2010,07,12),"childs birthday" },
                    {new DateTime(2001,11,12),"anniversary" }
                }
            };

            SampleOrder o = new SampleOrder(new DateTime(2012, 8, 9), 5m);

            c.AddOrder(o);

            o = new SampleOrder(new DateTime(2012, 7, 4), 25m);


            c.AddOrder(o);

            ICustomer theCustomer = c;

            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");

            DateTime recurring = new DateTime(2013, 3, 15);


            for (int i = 0; i < 15; i++)
            {
                o = new SampleOrder(recurring, 17.48m * i);
            }

            Console.WriteLine($"Data about {c.Name}");
            Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
            Console.WriteLine("Reminders:");

            foreach (var item in c.Reminders)
            {
                Console.WriteLine($"\t{item.Value} on {item.Key}");
            }
            foreach (IOrder order in c.PreviousOrders)
            {
                Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");
            }

            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");

            ICustomer.SetLoyaltyThresholds(new TimeSpan(30, 0, 0, 0), 1, 0.25m);
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
        }
    }
} 