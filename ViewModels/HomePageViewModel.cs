using System.ComponentModel.DataAnnotations;

namespace Fuwans.ViewModels;

public class HomePageViewModel
{
    public HeroViewModel Hero { get; set; } = new("", "", "", "", "");
    public IReadOnlyList<StoreFeatureViewModel> Features { get; set; } = [];
    public string FeaturedProductsDescription { get; set; } = "Our most coveted pieces, designed for the modern connoisseur of fine leather goods.";
    public IReadOnlyList<ProductCardViewModel> FeaturedProducts { get; set; } = [];
    public IReadOnlyList<CategoryHighlightViewModel> HighlightCategories { get; set; } = [];
    public BrandStoryViewModel BrandStory { get; set; } = new("", "", [], "", "");
    public string NewsletterDescription { get; set; } = "Receive exclusive access to new collections and invitations to private trunk shows.";
    public string FooterSummary { get; set; } = "Crafting the heirlooms of tomorrow through rigorous discipline and unparalleled artistry.";

    [EmailAddress]
    public string SubscriptionEmail { get; set; } = string.Empty;
}

public record HeroViewModel(
    string Eyebrow,
    string Title,
    string PrimaryActionText,
    string SecondaryActionText,
    string ImageUrl);

public record StoreFeatureViewModel(
    string Title,
    string IconName);

public record ProductCardViewModel(
    string Name,
    string ShortDescription,
    string PriceText,
    string PrimaryImageUrl);

public record CategoryHighlightViewModel(
    string Name,
    string HighlightImageUrl,
    string CallToActionText);

public record BrandStoryViewModel(
    string Eyebrow,
    string Title,
    IReadOnlyList<string> Paragraphs,
    string ActionText,
    string ImageUrl);
