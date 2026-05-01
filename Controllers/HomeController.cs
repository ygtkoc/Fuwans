using System.Diagnostics;
using Fuwans.Models;
using Fuwans.Services;
using Fuwans.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fuwans.Controllers;

public class HomeController(
    ILogger<HomeController> logger,
    IHomePageService homePageService,
    IAboutPageService aboutPageService,
    INewsletterService newsletterService) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IHomePageService _homePageService = homePageService;
    private readonly IAboutPageService _aboutPageService = aboutPageService;
    private readonly INewsletterService _newsletterService = newsletterService;

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var model = await _homePageService.GetHomePageAsync(cancellationToken);
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> About(CancellationToken cancellationToken)
    {
        var model = await _aboutPageService.GetAboutPageAsync(cancellationToken);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Subscribe(HomePageViewModel model, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(model.SubscriptionEmail))
        {
            TempData["SubscriptionMessage"] = "Lutfen bir e-posta adresi girin.";
            return RedirectToAction(nameof(Index));
        }

        var created = await _newsletterService.SubscribeAsync(model.SubscriptionEmail, cancellationToken);
        TempData["SubscriptionMessage"] = created
            ? "Bulten listesine basariyla eklendiniz."
            : "Bu e-posta adresi zaten kayitli.";

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
