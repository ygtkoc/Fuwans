using System.Text.Json;
using Fuwans.ViewModels;

namespace Fuwans.Services;

public class CheckoutService(IHttpContextAccessor httpContextAccessor, ICartService cartService) : ICheckoutService
{
    private const string CheckoutShippingSessionKey = "CheckoutShipping";
    private const string CheckoutPaymentSessionKey = "CheckoutPayment";
    private const decimal ExpressShippingCost = 45m;
    private const decimal EstimatedTaxRate = 0.08m;

    public async Task<CheckoutShippingPageViewModel?> GetShippingPageAsync(CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartPageAsync(cancellationToken);
        if (cart.Items.Count == 0)
        {
            return null;
        }

        var shippingState = GetSessionState<CheckoutShippingState>(CheckoutShippingSessionKey) ?? new CheckoutShippingState();
        return new CheckoutShippingPageViewModel
        {
            CartItemCount = cart.SelectedItemCount,
            EmailAddress = shippingState.EmailAddress,
            FirstName = shippingState.FirstName,
            LastName = shippingState.LastName,
            StreetAddress = shippingState.StreetAddress,
            City = shippingState.City,
            PostalCode = shippingState.PostalCode,
            DeliveryMethod = shippingState.DeliveryMethod,
            DeliveryOptions = BuildDeliveryOptions(shippingState.DeliveryMethod),
            Summary = BuildSummary(cart, shippingState.DeliveryMethod)
        };
    }

    public Task SaveShippingAsync(CheckoutShippingPageViewModel model, CancellationToken cancellationToken)
    {
        var shippingState = new CheckoutShippingState
        {
            EmailAddress = model.EmailAddress.Trim(),
            FirstName = model.FirstName.Trim(),
            LastName = model.LastName.Trim(),
            StreetAddress = model.StreetAddress.Trim(),
            City = model.City.Trim(),
            PostalCode = model.PostalCode.Trim(),
            DeliveryMethod = NormalizeDeliveryMethod(model.DeliveryMethod)
        };

        SetSessionState(CheckoutShippingSessionKey, shippingState);
        return Task.CompletedTask;
    }

    public async Task<CheckoutPaymentPageViewModel?> GetPaymentPageAsync(CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartPageAsync(cancellationToken);
        if (cart.Items.Count == 0)
        {
            return null;
        }

        var shippingState = GetSessionState<CheckoutShippingState>(CheckoutShippingSessionKey);
        if (shippingState is null)
        {
            return null;
        }

        var paymentState = GetSessionState<CheckoutPaymentState>(CheckoutPaymentSessionKey) ?? new CheckoutPaymentState();

        return new CheckoutPaymentPageViewModel
        {
            CartItemCount = cart.SelectedItemCount,
            CardholderName = paymentState.CardholderName,
            CardNumber = paymentState.CardNumber,
            ExpirationMonth = paymentState.ExpirationMonth,
            ExpirationYear = paymentState.ExpirationYear,
            SecurityCode = paymentState.SecurityCode,
            InstallmentText = paymentState.InstallmentText,
            ShippingPreview = BuildShippingPreview(shippingState),
            Summary = BuildSummary(cart, shippingState.DeliveryMethod)
        };
    }

    public Task SavePaymentAsync(CheckoutPaymentPageViewModel model, CancellationToken cancellationToken)
    {
        var paymentState = new CheckoutPaymentState
        {
            CardholderName = model.CardholderName.Trim(),
            CardNumber = model.CardNumber.Trim(),
            ExpirationMonth = model.ExpirationMonth.Trim(),
            ExpirationYear = model.ExpirationYear.Trim(),
            SecurityCode = model.SecurityCode.Trim(),
            InstallmentText = string.IsNullOrWhiteSpace(model.InstallmentText) ? "Tek cekim" : model.InstallmentText.Trim()
        };

        SetSessionState(CheckoutPaymentSessionKey, paymentState);
        return Task.CompletedTask;
    }

    public async Task<CheckoutReviewPageViewModel?> GetReviewPageAsync(CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartPageAsync(cancellationToken);
        if (cart.Items.Count == 0)
        {
            return null;
        }

        var shippingState = GetSessionState<CheckoutShippingState>(CheckoutShippingSessionKey);
        var paymentState = GetSessionState<CheckoutPaymentState>(CheckoutPaymentSessionKey);
        if (shippingState is null || paymentState is null)
        {
            return null;
        }

        return new CheckoutReviewPageViewModel
        {
            CartItemCount = cart.SelectedItemCount,
            ShippingPreview = BuildShippingPreview(shippingState),
            PaymentPreview = BuildPaymentPreview(paymentState),
            Summary = BuildSummary(cart, shippingState.DeliveryMethod)
        };
    }

    private CheckoutSummaryViewModel BuildSummary(CartPageViewModel cart, string deliveryMethod)
    {
        var subtotal = cart.Items.Sum(item => item.UnitPrice * item.Quantity);
        var shippingCost = NormalizeDeliveryMethod(deliveryMethod) == "express" ? ExpressShippingCost : 0m;
        var tax = Math.Round(subtotal * EstimatedTaxRate, 2, MidpointRounding.AwayFromZero);
        var total = subtotal + shippingCost + tax;

        return new CheckoutSummaryViewModel
        {
            Items = cart.Items,
            DeliveryTitle = shippingCost == 0m ? "Standart Teslimat" : "Hizli Kurye",
            SubtotalText = subtotal.ToString("$0,0.00"),
            ShippingText = shippingCost == 0m ? "Ucretsiz" : shippingCost.ToString("$0,0.00"),
            TaxText = tax.ToString("$0,0.00"),
            TotalText = total.ToString("$0,0.00")
        };
    }

    private static IReadOnlyList<CheckoutDeliveryOptionViewModel> BuildDeliveryOptions(string selectedCode)
    {
        var normalized = NormalizeDeliveryMethod(selectedCode);
        return
        [
            new CheckoutDeliveryOptionViewModel
            {
                Code = "standard",
                Title = "Standart Miras Teslimati",
                Description = "3-5 is gunu",
                PriceText = "Ucretsiz",
                IsSelected = normalized == "standard"
            },
            new CheckoutDeliveryOptionViewModel
            {
                Code = "express",
                Title = "Hizli Kurye",
                Description = "Ertesi gun teslimat",
                PriceText = "$45.00",
                IsSelected = normalized == "express"
            }
        ];
    }

    private static CheckoutShippingPreviewViewModel BuildShippingPreview(CheckoutShippingState shippingState)
    {
        return new CheckoutShippingPreviewViewModel
        {
            FullName = $"{shippingState.FirstName} {shippingState.LastName}".Trim(),
            EmailAddress = shippingState.EmailAddress,
            StreetAddress = shippingState.StreetAddress,
            CityPostalCode = $"{shippingState.City} / {shippingState.PostalCode}".Trim(' ', '/'),
            DeliveryTitle = NormalizeDeliveryMethod(shippingState.DeliveryMethod) == "express" ? "Hizli Kurye" : "Standart Miras Teslimati",
            DeliveryDescription = NormalizeDeliveryMethod(shippingState.DeliveryMethod) == "express" ? "Ertesi gun teslimat" : "3-5 is gunu"
        };
    }

    private static CheckoutPaymentPreviewViewModel BuildPaymentPreview(CheckoutPaymentState paymentState)
    {
        var digits = new string(paymentState.CardNumber.Where(char.IsDigit).ToArray());
        var lastFour = digits.Length >= 4 ? digits[^4..] : digits;

        return new CheckoutPaymentPreviewViewModel
        {
            CardholderName = paymentState.CardholderName,
            MaskedCardNumber = string.IsNullOrWhiteSpace(lastFour) ? "Kart girilmedi" : $"**** **** **** {lastFour}",
            ExpirationText = $"{paymentState.ExpirationMonth}/{paymentState.ExpirationYear}",
            InstallmentText = paymentState.InstallmentText
        };
    }

    private TState? GetSessionState<TState>(string sessionKey)
    {
        var json = httpContextAccessor.HttpContext?.Session.GetString(sessionKey);
        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<TState>(json);
    }

    private void SetSessionState<TState>(string sessionKey, TState state)
    {
        var json = JsonSerializer.Serialize(state);
        httpContextAccessor.HttpContext?.Session.SetString(sessionKey, json);
    }

    private static string NormalizeDeliveryMethod(string? deliveryMethod)
    {
        return string.Equals(deliveryMethod, "express", StringComparison.OrdinalIgnoreCase)
            ? "express"
            : "standard";
    }

    private sealed class CheckoutShippingState
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string DeliveryMethod { get; set; } = "standard";
    }

    private sealed class CheckoutPaymentState
    {
        public string CardholderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string ExpirationMonth { get; set; } = string.Empty;
        public string ExpirationYear { get; set; } = string.Empty;
        public string SecurityCode { get; set; } = string.Empty;
        public string InstallmentText { get; set; } = "Tek cekim";
    }
}
