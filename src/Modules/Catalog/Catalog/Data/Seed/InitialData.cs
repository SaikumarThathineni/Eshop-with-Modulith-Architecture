namespace Catalog.Data.Seed;
public static class InitialData
{
    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(Guid.NewGuid(), "Laptop", new List<string> { "Electronics", "Computers" }, "A high-performance laptop for work and play.", "laptop.jpg", 999.99m),
        Product.Create(Guid.NewGuid(), "Apple iPhone 13", new List<string> { "Electronics", "Mobile Phones" }, "The latest iPhone with A15 Bionic chip and improved camera.", "iphone13.jpg", 999.99m),
        Product.Create(Guid.NewGuid(), "Samsung Galaxy S21", new List<string> { "Electronics", "Mobile Phones" }, "Samsung's flagship phone with a stunning display and powerful performance.", "galaxy_s21.jpg", 899.99m),
        Product.Create(Guid.NewGuid(), "Sony WH-1000XM4", new List<string> { "Electronics", "Headphones" }, "Industry-leading noise canceling headphones with exceptional sound quality.", "sony_wh1000xm4.jpg", 349.99m)
    };
}
