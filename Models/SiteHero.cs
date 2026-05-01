namespace Fuwans.Models;

public class SiteHero : BaseEntity
{
    public string Eyebrow { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string PrimaryActionText { get; set; } = string.Empty;
    public string SecondaryActionText { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
