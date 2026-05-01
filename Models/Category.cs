namespace Fuwans.Models;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string HighlightImageUrl { get; set; } = string.Empty;
    public string CallToActionText { get; set; } = string.Empty;
    public bool IsHighlightedOnHomePage { get; set; }
    public int DisplayOrder { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
