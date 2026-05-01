namespace Fuwans.Models;

public class CustomerAddress : BaseEntity
{
    public int CustomerAccountId { get; set; }
    public CustomerAccount? CustomerAccount { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Line1 { get; set; } = string.Empty;
    public string Line2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
}
