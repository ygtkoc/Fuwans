using Fuwans.Data;
using Fuwans.Models;
using Fuwans.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fuwans.Services;

public class CartService(IHttpContextAccessor httpContextAccessor, AppDbContext dbContext) : ICartService
{
    private const string GuestCustomerIdSessionKey = "GuestCustomerId";

    public async Task<CartSummary> GetCartSummaryAsync(CancellationToken cancellationToken)
    {
        var customerId = GetGuestCustomerId();
        if (customerId is null)
        {
            return new CartSummary();
        }

        var quantity = await dbContext.CartItems
            .Where(item => item.Cart!.CustomerAccountId == customerId.Value)
            .SumAsync(item => (int?)item.Quantity, cancellationToken) ?? 0;

        return new CartSummary
        {
            TotalQuantity = quantity
        };
    }

    public async Task AddItemAsync(string productSlug, string? selectedColor, string? selectedSize, int quantity, CancellationToken cancellationToken)
    {
        if (quantity <= 0)
        {
            quantity = 1;
        }

        var product = await dbContext.Products
            .FirstOrDefaultAsync(item => item.Slug == productSlug, cancellationToken)
            ?? throw new InvalidOperationException("Urun bulunamadi.");

        var customerId = await GetOrCreateGuestCustomerIdAsync(cancellationToken);
        var cart = await GetOrCreateCartAsync(customerId, cancellationToken);

        var normalizedColor = string.IsNullOrWhiteSpace(selectedColor) ? product.SelectedColorName : selectedColor.Trim();
        var normalizedSize = string.IsNullOrWhiteSpace(selectedSize) ? null : selectedSize.Trim();

        var existingItem = await dbContext.CartItems
            .FirstOrDefaultAsync(
                item => item.CartId == cart.Id &&
                        item.ProductId == product.Id &&
                        item.SelectedColorName == normalizedColor &&
                        item.SelectedSizeLabel == normalizedSize,
                cancellationToken);

        if (existingItem is null)
        {
            dbContext.CartItems.Add(new CartItem
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = quantity,
                SelectedColorName = normalizedColor,
                SelectedSizeLabel = normalizedSize
            });
        }
        else
        {
            existingItem.Quantity += quantity;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<CartPageViewModel> GetCartPageAsync(CancellationToken cancellationToken)
    {
        var customerId = await GetOrCreateGuestCustomerIdAsync(cancellationToken);
        var cart = await GetOrCreateCartAsync(customerId, cancellationToken);

        var cartItems = await dbContext.CartItems
            .Where(item => item.CartId == cart.Id)
            .Include(item => item.Product)
            .ThenInclude(product => product!.Images)
            .OrderBy(item => item.CreatedAtUtc)
            .AsSplitQuery()
            .ToListAsync(cancellationToken);

        var items = cartItems.Select(item => new CartItemViewModel
        {
            CartItemId = item.Id,
            ProductName = item.Product!.Name,
            ProductSlug = item.Product.Slug,
            ProductImageUrl = item.Product.Images
                .OrderBy(image => image.DisplayOrder)
                .Select(image => image.ImageUrl)
                .FirstOrDefault() ?? string.Empty,
            DetailText = string.Join(" / ",
                new[]
                {
                    item.SelectedColorName,
                    item.SelectedSizeLabel
                }.Where(text => !string.IsNullOrWhiteSpace(text))),
            PriceText = item.Product.Price.ToString("$0,0.00"),
            UnitPrice = item.Product.Price,
            Quantity = item.Quantity
        }).ToList();

        var subtotal = items.Sum(item => item.UnitPrice * item.Quantity);

        return new CartPageViewModel
        {
            Items = items,
            SelectedItemCount = items.Sum(item => item.Quantity),
            SubtotalText = subtotal.ToString("$0,0.00"),
            TotalText = subtotal.ToString("$0,0.00")
        };
    }

    public async Task UpdateQuantityAsync(int cartItemId, int delta, CancellationToken cancellationToken)
    {
        var customerId = await GetOrCreateGuestCustomerIdAsync(cancellationToken);
        var item = await dbContext.CartItems
            .Include(cartItem => cartItem.Cart)
            .FirstOrDefaultAsync(
                cartItem => cartItem.Id == cartItemId && cartItem.Cart!.CustomerAccountId == customerId,
                cancellationToken);

        if (item is null)
        {
            return;
        }

        item.Quantity += delta;
        if (item.Quantity <= 0)
        {
            dbContext.CartItems.Remove(item);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveItemAsync(int cartItemId, CancellationToken cancellationToken)
    {
        var customerId = await GetOrCreateGuestCustomerIdAsync(cancellationToken);
        var item = await dbContext.CartItems
            .Include(cartItem => cartItem.Cart)
            .FirstOrDefaultAsync(
                cartItem => cartItem.Id == cartItemId && cartItem.Cart!.CustomerAccountId == customerId,
                cancellationToken);

        if (item is null)
        {
            return;
        }

        dbContext.CartItems.Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private int? GetGuestCustomerId()
    {
        return httpContextAccessor.HttpContext?.Session.GetInt32(GuestCustomerIdSessionKey);
    }

    private async Task<int> GetOrCreateGuestCustomerIdAsync(CancellationToken cancellationToken)
    {
        var httpContext = httpContextAccessor.HttpContext
            ?? throw new InvalidOperationException("HttpContext kullanilamiyor.");

        var existingCustomerId = httpContext.Session.GetInt32(GuestCustomerIdSessionKey);
        if (existingCustomerId.HasValue)
        {
            return existingCustomerId.Value;
        }

        var guestToken = Guid.NewGuid().ToString("N");
        var customer = new CustomerAccount
        {
            FirstName = "Misafir",
            LastName = guestToken[..8],
            Email = $"guest-{guestToken}@fuwans.local"
        };

        dbContext.CustomerAccounts.Add(customer);
        await dbContext.SaveChangesAsync(cancellationToken);

        httpContext.Session.SetInt32(GuestCustomerIdSessionKey, customer.Id);
        return customer.Id;
    }

    private async Task<Cart> GetOrCreateCartAsync(int customerId, CancellationToken cancellationToken)
    {
        var cart = await dbContext.Carts
            .FirstOrDefaultAsync(item => item.CustomerAccountId == customerId, cancellationToken);

        if (cart is not null)
        {
            return cart;
        }

        cart = new Cart
        {
            CustomerAccountId = customerId
        };

        dbContext.Carts.Add(cart);
        await dbContext.SaveChangesAsync(cancellationToken);
        return cart;
    }
}
