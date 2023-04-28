namespace eShop.Catalog.Entities
{
    public class Image
    {
    public int Id { get; set; }
    public string Url { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    }
}