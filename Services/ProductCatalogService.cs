using Fuwans.Data;
using Fuwans.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fuwans.Services;

public class ProductCatalogService(AppDbContext dbContext) : IProductCatalogService
{
    public async Task<ProductCatalogPageViewModel> GetCatalogPageAsync(CancellationToken cancellationToken)
    {
        var products = await dbContext.Products
            .OrderBy(item => item.DisplayOrder)
            .Select(item => new ProductCatalogItemViewModel(
                item.Name,
                item.Price.ToString("$0,0.00"),
                item.Images
                    .OrderBy(image => image.DisplayOrder)
                    .Select(image => image.ImageUrl)
                    .FirstOrDefault() ?? string.Empty,
                item.Colors
                    .OrderBy(color => color.DisplayOrder)
                    .Select(color => new ProductColorViewModel(color.Name, color.HexCode))
                    .ToList(),
                item.ListingBadge,
                item.IsWideFeature,
                item.CollectionNoteTitle,
                item.CollectionNoteText,
                "Hizli Ekle",
                item.Slug))
            .ToListAsync(cancellationToken);

        return new ProductCatalogPageViewModel
        {
            FilterTitles = ["Kategori", "Fiyat Araligi", "Renk Paleti"],
            SortOptions = ["En Yeni", "Fiyat: Artan", "Fiyat: Azalan", "Populer"],
            SelectedSortOption = "En Yeni",
            Products = products
        };
    }

    public async Task<ProductDetailPageViewModel?> GetProductDetailAsync(string slug, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products
            .Where(item => item.Slug == slug)
            .AsSplitQuery()
            .Select(item => new ProductDetailPageViewModel
            {
                Slug = item.Slug,
                CollectionLabel = item.CollectionLabel,
                Name = item.Name,
                PriceText = item.Price.ToString("$0,0.00"),
                Description = item.Description,
                SelectedColorName = item.SelectedColorName,
                SizeGuideText = item.SizeGuideText,
                DetailsText = item.DetailsText,
                MaterialsText = item.MaterialsText,
                ShippingReturnsText = item.ShippingReturnsText,
                GalleryImages = item.Images
                    .OrderBy(image => image.DisplayOrder)
                    .Select(image => new ProductGalleryImageViewModel(
                        image.ImageUrl,
                        item.Name,
                        image.DisplayOrder == 1))
                    .ToList(),
                Colors = item.Colors
                    .OrderBy(color => color.DisplayOrder)
                    .Select(color => new ProductColorOptionViewModel(
                        color.Name,
                        color.HexCode,
                        color.Name == item.SelectedColorName))
                    .ToList(),
                Sizes = item.Sizes
                    .OrderBy(size => size.DisplayOrder)
                    .Select(size => new ProductSizeOptionViewModel(
                        size.Label,
                        size.IsSelectedByDefault))
                    .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
        {
            return null;
        }

        var relatedProducts = await dbContext.Products
            .Where(item => item.Slug != slug)
            .OrderBy(item => item.DisplayOrder)
            .Take(4)
            .Select(item => new RelatedProductViewModel(
                item.Name,
                item.Price.ToString("$0,0.00"),
                item.Images
                    .OrderBy(image => image.DisplayOrder)
                    .Select(image => image.ImageUrl)
                    .FirstOrDefault() ?? string.Empty,
                item.Slug))
            .ToListAsync(cancellationToken);

        product.RelatedProducts = relatedProducts;
        return product;
    }
}
