using System.ComponentModel.DataAnnotations;

namespace Fuwans.ViewModels;

public class HomePageViewModel
{
    public HeroViewModel Hero { get; set; } = new("", "", "", "", "");
    public IReadOnlyList<StoreFeatureViewModel> Features { get; set; } = [];
    public string FeaturedProductsDescription { get; set; } = "Modern yasamin ritmine uyum saglayan, en cok ilgi goren seckilerimiz.";
    public IReadOnlyList<ProductCardViewModel> FeaturedProducts { get; set; } = [];
    public IReadOnlyList<CategoryHighlightViewModel> HighlightCategories { get; set; } = [];
    public BrandStoryViewModel BrandStory { get; set; } = new("", "", [], "", "");
    public string NewsletterDescription { get; set; } = "Yeni koleksiyonlara ve ozel davetlere erken erisim icin bultenimize katilin.";
    public string FooterSummary { get; set; } = "Yarinin miras parcalarini disiplinli zanaat ve rafine bir yaklasimla uretiyoruz.";

    [EmailAddress]
    public string SubscriptionEmail { get; set; } = string.Empty;
}

public class ProductCatalogPageViewModel
{
    public string Eyebrow { get; set; } = "2024 Yaz Seckisi";
    public string Title { get; set; } = "Ozenle Secilmis Modern Miras";
    public IReadOnlyList<string> FilterTitles { get; set; } = [];
    public IReadOnlyList<string> SortOptions { get; set; } = [];
    public string SelectedSortOption { get; set; } = string.Empty;
    public IReadOnlyList<ProductCatalogItemViewModel> Products { get; set; } = [];
    public string NewsletterTitle { get; set; } = "Ozel Erisim";
    public string NewsletterDescription { get; set; } = "Yeni koleksiyonlara ve ozel etkinliklere erken erisim icin bultenimize katilin.";

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

public record ProductCatalogItemViewModel(
    string Name,
    string PriceText,
    string PrimaryImageUrl,
    IReadOnlyList<ProductColorViewModel> Colors,
    string Badge,
    bool IsWideFeature,
    string CollectionNoteTitle,
    string CollectionNoteText,
    string QuickActionText);

public record ProductColorViewModel(
    string Name,
    string HexCode);
