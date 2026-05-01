using Fuwans.ViewModels;

namespace Fuwans.Services;

public interface IAboutPageService
{
    Task<AboutPageViewModel> GetAboutPageAsync(CancellationToken cancellationToken);
}
