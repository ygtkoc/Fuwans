using Fuwans.Data;
using Fuwans.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fuwans.Services;

public class HomePageService(AppDbContext dbContext) : IHomePageService
{
    public async Task<HomePageViewModel> GetHomePageAsync(CancellationToken cancellationToken)
    {
        var hero = await dbContext.SiteHeroes
            .OrderBy(item => item.Id)
            .Select(item => new HeroViewModel(
                item.Eyebrow,
                item.Title,
                item.PrimaryActionText,
                item.SecondaryActionText,
                item.ImageUrl))
            .FirstAsync(cancellationToken);

        var features = await dbContext.StoreFeatures
            .OrderBy(item => item.DisplayOrder)
            .Select(item => new StoreFeatureViewModel(item.Title, item.IconName))
            .ToListAsync(cancellationToken);

        var featuredProducts = await dbContext.Products
            .Where(item => item.IsFeaturedOnHomePage)
            .OrderBy(item => item.DisplayOrder)
            .Select(item => new ProductCardViewModel(
                item.Name,
                item.ShortDescription,
                item.Price.ToString("$0,0"),
                item.Images
                    .OrderBy(image => image.DisplayOrder)
                    .Select(image => image.ImageUrl)
                    .FirstOrDefault() ?? string.Empty))
            .ToListAsync(cancellationToken);

        var highlightCategories = await dbContext.Categories
            .Where(item => item.IsHighlightedOnHomePage)
            .OrderBy(item => item.DisplayOrder)
            .Select(item => new CategoryHighlightViewModel(
                item.Name,
                item.HighlightImageUrl,
                item.CallToActionText))
            .ToListAsync(cancellationToken);

        var story = await dbContext.BrandStories
            .OrderBy(item => item.Id)
            .Select(item => new BrandStoryViewModel(
                item.Eyebrow,
                item.Title,
                new[] { item.ParagraphOne, item.ParagraphTwo },
                item.ActionText,
                item.ImageUrl))
            .FirstAsync(cancellationToken);

        return new HomePageViewModel
        {
            Hero = hero,
            Features = features,
            FeaturedProducts = featuredProducts,
            HighlightCategories = highlightCategories,
            BrandStory = story
        };
    }
}
