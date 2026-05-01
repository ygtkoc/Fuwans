namespace Fuwans.Services;

public interface INewsletterService
{
    Task<bool> SubscribeAsync(string email, CancellationToken cancellationToken);
}
