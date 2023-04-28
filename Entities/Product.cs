namespace eShop.Catalog.Entities
{
    public class Product
    {
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsTrend { get; set; }
    public bool IsPopular { get; set; }
    public long RegularPrice { get; set; }
    public long SalesPrice { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string? SKU { get; set; }
    public bool StockStatus { get; set; }
    public int Quantity { get; set; }
    public string? PictureUrl { get; set; }

    public required string  Type { get; set; }
    public required string Brand { get; set; }

   
  
    }
}