using System.Globalization;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal productTotal = _products.Sum(product => product.GetTotalCost());
        decimal shippingCost = _customer.IsInUSA() ? 5m : 35m;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string productLines = string.Join(
            Environment.NewLine,
            _products.Select(product => $"{product.GetName()} (ID: {product.GetProductId()})"));

        return $"Packing Label\n{productLines}";
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }

    public string GetTotalCostFormatted()
    {
        return GetTotalCost().ToString("C", CultureInfo.GetCultureInfo("en-US"));
    }
}