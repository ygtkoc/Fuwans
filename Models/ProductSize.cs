namespace Fuwans.Models;

public class ProductSize : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public string Label { get; set; } = string.Empty;
    public bool IsSelectedByDefault { get; set; }
    public int DisplayOrder { get; set; }
}
