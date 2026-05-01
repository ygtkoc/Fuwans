namespace Fuwans.Models;

public class Cart : BaseEntity
{
    public int CustomerAccountId { get; set; }
    public CustomerAccount? CustomerAccount { get; set; }
    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}
