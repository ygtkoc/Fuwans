namespace Fuwans.Models;

public class StoreFeature : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string IconName { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}
