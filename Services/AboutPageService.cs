using Fuwans.Data;
using Fuwans.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fuwans.Services;

public class AboutPageService(AppDbContext dbContext) : IAboutPageService
{
    public async Task<AboutPageViewModel> GetAboutPageAsync(CancellationToken cancellationToken)
    {
        var content = await dbContext.AboutPageContents
            .OrderBy(item => item.Id)
            .Select(item => new AboutPageViewModel
            {
                VisionEyebrow = item.VisionEyebrow,
                VisionTitle = item.VisionTitle,
                VisionDescription = item.VisionDescription,
                VisionImageUrl = item.VisionImageUrl,
                HeritageTitle = item.HeritageTitle,
                HeritageDescription = item.HeritageDescription,
                HeritageImagePrimaryUrl = item.HeritageImagePrimaryUrl,
                HeritageImageSecondaryUrl = item.HeritageImageSecondaryUrl,
                HeritageBadge = item.HeritageBadge,
                HeritageFeatureTitle = item.HeritageFeatureTitle,
                HeritageFeatureDescription = item.HeritageFeatureDescription,
                ProcessEyebrow = item.ProcessEyebrow,
                ProcessTitle = item.ProcessTitle,
                ProcessDescription = item.ProcessDescription,
                ProcessImagePrimaryUrl = item.ProcessImagePrimaryUrl,
                ProcessImageSecondaryUrl = item.ProcessImageSecondaryUrl,
                ProcessStatValue = item.ProcessStatValue,
                ProcessStatLabel = item.ProcessStatLabel,
                NarrativeTitle = item.NarrativeTitle,
                NarrativeQuote = item.NarrativeQuote,
                NarrativeAuthor = item.NarrativeAuthor
            })
            .FirstAsync(cancellationToken);

        return content;
    }
}
