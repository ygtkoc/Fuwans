namespace Fuwans.Models;

public class Product : BaseEntity
{
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ListingBadge { get; set; } = string.Empty;
    public string CollectionNoteTitle { get; set; } = string.Empty;
    public string CollectionNoteText { get; set; } = string.Empty;
    public bool IsWideFeature { get; set; }
    public decimal Price { get; set; }
    public bool IsFeaturedOnHomePage { get; set; }
    public int DisplayOrder { get; set; }
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<ProductColor> Colors { get; set; } = new List<ProductColor>();
}
