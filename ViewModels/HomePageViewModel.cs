using System.ComponentModel.DataAnnotations;

namespace Fuwans.ViewModels;

public class HomePageViewModel
{
    public int CartItemCount { get; set; }
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
    public int CartItemCount { get; set; }
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
    public int CartItemCount { get; set; }
    public string Slug { get; set; } = string.Empty;
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
    public int CartItemCount { get; set; }
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

public class CartPageViewModel
{
    public int SelectedItemCount { get; set; }
    public IReadOnlyList<CartItemViewModel> Items { get; set; } = [];
    public string SubtotalText { get; set; } = "$0.00";
    public string TotalText { get; set; } = "$0.00";
}

public class CheckoutShippingPageViewModel
{
    public int CartItemCount { get; set; }
    public string StepTitle { get; set; } = "Kargo";
    public string EmailAddress { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string StreetAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string DeliveryMethod { get; set; } = "standard";
    public IReadOnlyList<CheckoutDeliveryOptionViewModel> DeliveryOptions { get; set; } = [];
    public CheckoutSummaryViewModel Summary { get; set; } = new();
}

public class CheckoutPaymentPageViewModel
{
    public int CartItemCount { get; set; }
    public string StepTitle { get; set; } = "Odeme";
    public string CardholderName { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public string ExpirationMonth { get; set; } = string.Empty;
    public string ExpirationYear { get; set; } = string.Empty;
    public string SecurityCode { get; set; } = string.Empty;
    public string InstallmentText { get; set; } = "Tek cekim";
    public CheckoutShippingPreviewViewModel ShippingPreview { get; set; } = new();
    public CheckoutSummaryViewModel Summary { get; set; } = new();
}

public class CheckoutReviewPageViewModel
{
    public int CartItemCount { get; set; }
    public string StepTitle { get; set; } = "Onay";
    public CheckoutShippingPreviewViewModel ShippingPreview { get; set; } = new();
    public CheckoutPaymentPreviewViewModel PaymentPreview { get; set; } = new();
    public CheckoutSummaryViewModel Summary { get; set; } = new();
}

public class CheckoutDeliveryOptionViewModel
{
    public string Code { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PriceText { get; set; } = string.Empty;
    public bool IsSelected { get; set; }
}

public class CheckoutSummaryViewModel
{
    public IReadOnlyList<CartItemViewModel> Items { get; set; } = [];
    public string PromoCode { get; set; } = string.Empty;
    public string DeliveryTitle { get; set; } = string.Empty;
    public string SubtotalText { get; set; } = "$0.00";
    public string ShippingText { get; set; } = "Ucretsiz";
    public string TaxText { get; set; } = "$0.00";
    public string TotalText { get; set; } = "$0.00";
}

public class CheckoutShippingPreviewViewModel
{
    public string FullName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string StreetAddress { get; set; } = string.Empty;
    public string CityPostalCode { get; set; } = string.Empty;
    public string DeliveryTitle { get; set; } = string.Empty;
    public string DeliveryDescription { get; set; } = string.Empty;
}

public class CheckoutPaymentPreviewViewModel
{
    public string CardholderName { get; set; } = string.Empty;
    public string MaskedCardNumber { get; set; } = string.Empty;
    public string ExpirationText { get; set; } = string.Empty;
    public string InstallmentText { get; set; } = string.Empty;
}

public class CartItemViewModel
{
    public int CartItemId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductSlug { get; set; } = string.Empty;
    public string ProductImageUrl { get; set; } = string.Empty;
    public string DetailText { get; set; } = string.Empty;
    public string PriceText { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
