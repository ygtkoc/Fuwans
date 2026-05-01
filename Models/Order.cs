namespace Fuwans.Models;

public class Order : BaseEntity
{
    public int CustomerAccountId { get; set; }
    public CustomerAccount? CustomerAccount { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
