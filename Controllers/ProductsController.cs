using Fuwans.Services;
using Fuwans.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fuwans.Controllers;

public class ProductsController(
    IProductCatalogService productCatalogService,
    ICartService cartService,
    INewsletterService newsletterService) : Controller
{
    private readonly IProductCatalogService _productCatalogService = productCatalogService;
    private readonly ICartService _cartService = cartService;
    private readonly INewsletterService _newsletterService = newsletterService;

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var model = await _productCatalogService.GetCatalogPageAsync(cancellationToken);
        model.CartItemCount = (await _cartService.GetCartSummaryAsync(cancellationToken)).TotalQuantity;
        return View(model);
    }

    public async Task<IActionResult> Details(string slug, CancellationToken cancellationToken)
    {
        var model = await _productCatalogService.GetProductDetailAsync(slug, cancellationToken);

        if (model is null)
        {
            return NotFound();
        }

        model.CartItemCount = (await _cartService.GetCartSummaryAsync(cancellationToken)).TotalQuantity;
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToCart(string slug, string? selectedColor, string? selectedSize, int quantity, CancellationToken cancellationToken)
    {
        await _cartService.AddItemAsync(slug, selectedColor, selectedSize, quantity, cancellationToken);
        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Subscribe(ProductCatalogPageViewModel model, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(model.SubscriptionEmail))
        {
            TempData["CatalogSubscriptionMessage"] = "Lutfen bir e-posta adresi girin.";
            return RedirectToAction(nameof(Index));
        }

        var created = await _newsletterService.SubscribeAsync(model.SubscriptionEmail, cancellationToken);
        TempData["CatalogSubscriptionMessage"] = created
            ? "Bulten listesine basariyla eklendiniz."
            : "Bu e-posta adresi zaten kayitli.";

        return RedirectToAction(nameof(Index));
    }
}
