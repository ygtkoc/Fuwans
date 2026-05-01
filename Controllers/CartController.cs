using Fuwans.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fuwans.Controllers;

public class CartController(ICartService cartService) : Controller
{
    private readonly ICartService _cartService = cartService;

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var model = await _cartService.GetCartPageAsync(cancellationToken);
        ViewBag.CartItemCount = model.SelectedItemCount;
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateQuantity(int cartItemId, int delta, CancellationToken cancellationToken)
    {
        await _cartService.UpdateQuantityAsync(cartItemId, delta, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveItem(int cartItemId, CancellationToken cancellationToken)
    {
        await _cartService.RemoveItemAsync(cartItemId, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult BeginCheckout()
    {
        TempData["CheckoutMessage"] = "Odeme adimi bir sonraki asamada tamamlanacak.";
        return RedirectToAction(nameof(Index));
    }
}
