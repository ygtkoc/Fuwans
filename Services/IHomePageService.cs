using Fuwans.ViewModels;

namespace Fuwans.Services;

public interface IHomePageService
{
    Task<HomePageViewModel> GetHomePageAsync(CancellationToken cancellationToken);
}
