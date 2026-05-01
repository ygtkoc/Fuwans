using Fuwans.Data;
using Fuwans.Models;
using Microsoft.EntityFrameworkCore;

namespace Fuwans.Services;

public class NewsletterService(AppDbContext dbContext) : INewsletterService
{
    public async Task<bool> SubscribeAsync(string email, CancellationToken cancellationToken)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        var existingSubscriber = await dbContext.NewsletterSubscribers
            .AnyAsync(item => item.Email == normalizedEmail, cancellationToken);

        if (existingSubscriber)
        {
            return false;
        }

        dbContext.NewsletterSubscribers.Add(new NewsletterSubscriber
        {
            Email = normalizedEmail
        });

        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
