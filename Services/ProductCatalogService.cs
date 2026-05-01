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
                item.Price.ToString("$0,0"),
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
                "Hizli Ekle"))
            .ToListAsync(cancellationToken);

        return new ProductCatalogPageViewModel
        {
            FilterTitles = ["Kategori", "Fiyat Araligi", "Renk Paleti"],
            SortOptions = ["En Yeni", "Fiyat: Artan", "Fiyat: Azalan", "Populer"],
            SelectedSortOption = "En Yeni",
            Products = products
        };
    }
}
