using Fuwans.ViewModels;

namespace Fuwans.Services;

public interface IProductCatalogService
{
    Task<ProductCatalogPageViewModel> GetCatalogPageAsync(CancellationToken cancellationToken);
}
