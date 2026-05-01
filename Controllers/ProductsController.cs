using Fuwans.Services;
using Fuwans.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fuwans.Controllers;

public class ProductsController(
    IProductCatalogService productCatalogService,
    INewsletterService newsletterService) : Controller
{
    private readonly IProductCatalogService _productCatalogService = productCatalogService;
    private readonly INewsletterService _newsletterService = newsletterService;

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var model = await _productCatalogService.GetCatalogPageAsync(cancellationToken);
        return View(model);
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
