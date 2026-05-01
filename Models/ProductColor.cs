namespace Fuwans.Models;

public class ProductColor : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HexCode { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}
