namespace Fuwans.Models;

public class CartItem : BaseEntity
{
    public int CartId { get; set; }
    public Cart? Cart { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public string SelectedColorName { get; set; } = string.Empty;
    public string? SelectedSizeLabel { get; set; }
    public int Quantity { get; set; }
}
