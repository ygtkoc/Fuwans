using Fuwans.ViewModels;

namespace Fuwans.Services;

public interface ICheckoutService
{
    Task<CheckoutShippingPageViewModel?> GetShippingPageAsync(CancellationToken cancellationToken);
    Task SaveShippingAsync(CheckoutShippingPageViewModel model, CancellationToken cancellationToken);
    Task<CheckoutPaymentPageViewModel?> GetPaymentPageAsync(CancellationToken cancellationToken);
    Task SavePaymentAsync(CheckoutPaymentPageViewModel model, CancellationToken cancellationToken);
    Task<CheckoutReviewPageViewModel?> GetReviewPageAsync(CancellationToken cancellationToken);
}
