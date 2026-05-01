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

public class ProductDetailPageViewModel
{
    public string CollectionLabel { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PriceText { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SelectedColorName { get; set; } = string.Empty;
    public IReadOnlyList<ProductColorOptionViewModel> Colors { get; set; } = [];
    public IReadOnlyList<ProductSizeOptionViewModel> Sizes { get; set; } = [];
    public string SizeGuideText { get; set; } = string.Empty;
    public string DetailsText { get; set; } = string.Empty;
    public string MaterialsText { get; set; } = string.Empty;
    public string ShippingReturnsText { get; set; } = string.Empty;
    public IReadOnlyList<ProductGalleryImageViewModel> GalleryImages { get; set; } = [];
    public IReadOnlyList<RelatedProductViewModel> RelatedProducts { get; set; } = [];
    public string NewsletterPrompt { get; set; } = "Kayit listemize katil";
}

public class AboutPageViewModel
{
    public string VisionEyebrow { get; set; } = string.Empty;
    public string VisionTitle { get; set; } = string.Empty;
    public string VisionDescription { get; set; } = string.Empty;
    public string VisionImageUrl { get; set; } = string.Empty;
    public string HeritageTitle { get; set; } = string.Empty;
    public string HeritageDescription { get; set; } = string.Empty;
    public string HeritageImagePrimaryUrl { get; set; } = string.Empty;
    public string HeritageImageSecondaryUrl { get; set; } = string.Empty;
    public string HeritageBadge { get; set; } = string.Empty;
    public string HeritageFeatureTitle { get; set; } = string.Empty;
    public string HeritageFeatureDescription { get; set; } = string.Empty;
    public string ProcessEyebrow { get; set; } = string.Empty;
    public string ProcessTitle { get; set; } = string.Empty;
    public string ProcessDescription { get; set; } = string.Empty;
    public string ProcessImagePrimaryUrl { get; set; } = string.Empty;
    public string ProcessImageSecondaryUrl { get; set; } = string.Empty;
    public string ProcessStatValue { get; set; } = string.Empty;
    public string ProcessStatLabel { get; set; } = string.Empty;
    public string NarrativeTitle { get; set; } = string.Empty;
    public string NarrativeQuote { get; set; } = string.Empty;
    public string NarrativeAuthor { get; set; } = string.Empty;
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
    string PrimaryImageUrl,
    string Slug);

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
    string QuickActionText,
    string Slug);

public record ProductColorViewModel(
    string Name,
    string HexCode);

public record ProductGalleryImageViewModel(
    string ImageUrl,
    string AltText,
    bool IsLarge);

public record ProductColorOptionViewModel(
    string Name,
    string HexCode,
    bool IsSelected);

public record ProductSizeOptionViewModel(
    string Label,
    bool IsSelected);

public record RelatedProductViewModel(
    string Name,
    string PriceText,
    string ImageUrl,
    string Slug);
