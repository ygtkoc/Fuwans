namespace Fuwans.Models;

public class WishlistItem : BaseEntity
{
    public int CustomerAccountId { get; set; }
    public CustomerAccount? CustomerAccount { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
