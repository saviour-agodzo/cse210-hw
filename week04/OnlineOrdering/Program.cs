public class Program
{
    public static void Main()
    {
        Address domesticAddress = new Address(
            "123 Maple Street", "Rexburg", "Idaho", "USA");
        Customer domesticCustomer = new Customer("Alex Morgan", domesticAddress);

        Order domesticOrder = new Order(domesticCustomer);
        domesticOrder.AddProduct(new Product("Water Bottle", "WB-104", 18.50m, 2));
        domesticOrder.AddProduct(new Product("Trail Backpack", "TB-208", 42.00m, 1));

        Address internationalAddress = new Address(
            "45 Queen Street", "Auckland", "Auckland", "New Zealand");
        Customer internationalCustomer = new Customer("Jamie Taylor", internationalAddress);

        Order internationalOrder = new Order(internationalCustomer);
        internationalOrder.AddProduct(new Product("Travel Journal", "TJ-310", 12.00m, 3));
        internationalOrder.AddProduct(new Product("Pen Set", "PS-415", 8.75m, 2));

        List<Order> orders = new List<Order> { domesticOrder, internationalOrder };

        for (int i = 0; i < orders.Count; i++)
        {
            Order order = orders[i];
            Console.WriteLine($"ORDER {i + 1}");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total cost: {order.GetTotalCostFormatted()}");
            Console.WriteLine(new string('-', 40));
        }
    }
}