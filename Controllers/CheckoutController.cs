using Fuwans.Services;
using Fuwans.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fuwans.Controllers;

public class CheckoutController(ICheckoutService checkoutService) : Controller
{
    private readonly ICheckoutService _checkoutService = checkoutService;

    public async Task<IActionResult> Shipping(CancellationToken cancellationToken)
    {
        var model = await _checkoutService.GetShippingPageAsync(cancellationToken);
        if (model is null)
        {
            return RedirectToAction("Index", "Cart");
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Shipping(CheckoutShippingPageViewModel model, CancellationToken cancellationToken)
    {
        await _checkoutService.SaveShippingAsync(model, cancellationToken);
        return RedirectToAction(nameof(Payment));
    }

    public async Task<IActionResult> Payment(CancellationToken cancellationToken)
    {
        var model = await _checkoutService.GetPaymentPageAsync(cancellationToken);
        if (model is null)
        {
            return RedirectToAction(nameof(Shipping));
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Payment(CheckoutPaymentPageViewModel model, CancellationToken cancellationToken)
    {
        await _checkoutService.SavePaymentAsync(model, cancellationToken);
        return RedirectToAction(nameof(Review));
    }

    public async Task<IActionResult> Review(CancellationToken cancellationToken)
    {
        var model = await _checkoutService.GetReviewPageAsync(cancellationToken);
        if (model is null)
        {
            return RedirectToAction(nameof(Shipping));
        }

        return View(model);
    }
}
