using Fuwans.Models;
using Fuwans.ViewModels;

namespace Fuwans.Services;

public interface ICartService
{
    Task<CartSummary> GetCartSummaryAsync(CancellationToken cancellationToken);
    Task AddItemAsync(string productSlug, string? selectedColor, string? selectedSize, int quantity, CancellationToken cancellationToken);
    Task<CartPageViewModel> GetCartPageAsync(CancellationToken cancellationToken);
    Task UpdateQuantityAsync(int cartItemId, int delta, CancellationToken cancellationToken);
    Task RemoveItemAsync(int cartItemId, CancellationToken cancellationToken);
}
