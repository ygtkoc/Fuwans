using Fuwans.Data;
using Fuwans.Models;
using Microsoft.EntityFrameworkCore;

namespace Fuwans.Services;

public class DatabaseInitializer(AppDbContext dbContext)
{
    public async Task InitializeAsync()
    {
        await dbContext.Database.EnsureCreatedAsync();

        if (await dbContext.SiteHeroes.AnyAsync())
        {
            return;
        }

        var bags = new Category
        {
            Name = "Bags",
            Slug = "bags",
            Description = "Collection of timeless leather bags.",
            HighlightImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuCsnbvgZzRzgBWtZ1eiwuzcasVAwmeyC2dB2kHU8m-9AnK4dUMSBtli0xlVPalApOPQbLnG8HveRo9iJeAxnP43rc5Me-tl8NLEsvJMVJrXNUucFqh6GOWeIUvclMH62QoaqIR0ox4VCUo_tClACRMrOFVmfdv-7ErEr1Jhd2jor2dFWQdRQScwxu2-J1G2K2JzM7wTr2-v-ngkbGr3MX-YvjEE-zNUKX20-5KqzUBOUYp7zGONSF3hFlKmeuz7Sxt3HFOtpaltx19P",
            CallToActionText = "Shop Collection",
            IsHighlightedOnHomePage = true,
            DisplayOrder = 1
        };

        var arrivals = new Category
        {
            Name = "New Arrivals",
            Slug = "new-arrivals",
            Description = "Fresh seasonal drops from the atelier.",
            HighlightImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBY8_CZxe2ymvA8DKBNd09PNZ5hOrrpQf_ybwfJ0XKGTFTDzwL4ghQbZFZwXNRTIdIMPQHdMlvWVWTLzvuvQqtTt9Jzd9FCjrdO2BkiGSeDfj09coZugAEThf5KkjYUKqzujrsf-BXnoWTVxEr6WeiaCZvj7fMFir1k2XtUACYV9RdmqFMy7QuIrr-F9N_HemSzARLVHBztoxLhqy2AoQ76-eqVjRt7T6BCphYBHCZZtSPcql_Oq7cuaGqYFd4LwwD7Yt4ROtnkfo_7",
            CallToActionText = "Explore Seasonal",
            IsHighlightedOnHomePage = true,
            DisplayOrder = 2
        };

        var wallets = new Category
        {
            Name = "Wallets",
            Slug = "wallets",
            Description = "Compact pieces with meticulous finishing.",
            HighlightImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuD8QkIXQ8p9bGYzxKgw1j5Asnkt-KsgpsTjpVuWBtM3bVZT_KDcIDVZIo0fb1LUNEUvR246FjMQ7i4Sk-IE0_G_9MAERHLCayuUES_YTrHpIB_CSqR9BGNBluH5Wz2qmWFsxbSehFYD2UcxXlUQfrhBN5pUx_IGqvFZ3h7DNY2nFm9MJeUQ8ubMQyXiu6XyHLthiYxg_CSx5ZaqBVp1_NguiKPgqdLk70som5KyBJ6NUF03OnMkRXiOIQwFT3B8kcvuJtmZ3XtpJ8rn",
            CallToActionText = "View Selection",
            IsHighlightedOnHomePage = true,
            DisplayOrder = 3
        };

        dbContext.Categories.AddRange(bags, arrivals, wallets);

        dbContext.SiteHeroes.Add(new SiteHero
        {
            Eyebrow = "Heritage & Craft",
            Title = "Crafted for Timeless Elegance",
            PrimaryActionText = "Shop Now",
            SecondaryActionText = "Discover Collection",
            ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuByfA_tVunlbq9-xUfuygHrCJRzKApw_Ppsk1r1ONL-a4VlVErhGmXYqGpgtm9w-fPgSDyWCC_WdjmIa7u0kbLbw-sd9P0NxyGAT_EhxKwb1FTjXqUM6hcRpKCcnb0Zz2fc67CuWCvzFaRG6I8JZ97Mr4Vchb7iwYYjBFhwTCZKfYz8ioELlQDceCq9rvqOo2buUwIhUWFnhQ5nT_fXZ_mOnpdCanDw4nN5JnnBSgdeRztEM-KlufiGiDfx9XxF566nw9LSQt0NotAU"
        });

        dbContext.StoreFeatures.AddRange(
            new StoreFeature { Title = "Handcrafted", IconName = "front_hand", DisplayOrder = 1 },
            new StoreFeature { Title = "Premium Materials", IconName = "diamond", DisplayOrder = 2 },
            new StoreFeature { Title = "Global Shipping", IconName = "public", DisplayOrder = 3 });

        dbContext.Products.AddRange(
            new Product
            {
                Category = bags,
                Name = "The Heritage Tote",
                Slug = "the-heritage-tote",
                ShortDescription = "Full-Grain Italian Leather",
                Description = "A statement tote crafted from premium Italian leather.",
                Price = 1250m,
                IsFeaturedOnHomePage = true,
                DisplayOrder = 1,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuC3SMxUjryuT7iIduBpTE6m9Q5rRMZC_T5VP4GhdoVmtEIjhPvfEdMsMLlz_LcW0OagaNERiyYAiyZfUXTQ6Zkmt_fqS2-iUGVZSQMG68e5FfIkiuD72rmwy5t8ScIGrNoilMiYouA3qlT_FeU7DvJa2y7r1A_IbnkOS8K2BLc0eV_6Z7c4fxlk9n8LMT3xqu_NK0cT5Um_U-CSqzWGHkBKv6CsVsRLQ0zJDT0ea1X4YhQ7_0Loqb4q9hqCmUhlw2wP0VHn5SDB4HWj",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ]
            },
            new Product
            {
                Category = wallets,
                Name = "Slim Bifold Wallet",
                Slug = "slim-bifold-wallet",
                ShortDescription = "Hand-stitched Finish",
                Description = "A compact bifold wallet with clean lines and soft structure.",
                Price = 245m,
                IsFeaturedOnHomePage = true,
                DisplayOrder = 2,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuCBwW9Lqioyk4MgTImZKgzafdAvf17YNUkShlp1-FU7vm7Zh0pTRIQhIxwL840gZnoVa-wWDJT0X5X3tgqCL6vDQXzXTI0XOS-ZiwiMfEewCaPIUWiWOn0R6tSIHImIZcp04Jlr6B5RMzSMfTKRgnzP4fVBocSU49ktDo1Mmnj9bWIMxxtEAlMReBykLYCtaU7FmuG1GjYfTrPrAUtx9rWcfKNo1dWnhrHhrD2Kh4-6ffSHUcRl12VPaNijg66ndGS0gM8ymGHVfRbJ",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ]
            },
            new Product
            {
                Category = arrivals,
                Name = "The Weekender",
                Slug = "the-weekender",
                ShortDescription = "Reinforced Structure",
                Description = "A spacious travel companion shaped for short escapes.",
                Price = 1800m,
                IsFeaturedOnHomePage = true,
                DisplayOrder = 3,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDIhjch-QYJkyw4xeJX-vfODg8BAwan0w53eIwX3IiVepq-ccmc3QqHRNXoyXflzbDJLf8XdadBtJlX20pwkmUxZhvh3JY-hn5Ai3pkT926BafLCYNMMpmVwpd92d0ilB9qVptDLgYOTG5AxA6rAx4rkMQQArExWJMKi95FA6X8d8PxSid8i37toF-329z2mpkMS4nvJMrGBrgtsAjidQt7rJdUfErg3YoA_F_lvQ2fGJdZIYJeWV7xQa7eTLTIwHqIyix0CNF_4YOG",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ]
            });

        dbContext.BrandStories.Add(new BrandStory
        {
            Eyebrow = "Our Philosophy",
            Title = "Defining Modern Heritage",
            ParagraphOne = "At FUWANS, we believe that true luxury is found in the quiet details. Our journey began with a single vision: to revive the art of traditional leather-making for the modern era.",
            ParagraphTwo = "Every piece is born from a dialogue between raw materials and master artisans. We source our hides from ethical European tanneries and finish every edge by hand, ensuring each creation is as unique as the individual who carries it.",
            ActionText = "Our Craftsmanship Journey",
            ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBOOnnOIdBH8H6tmYl9le2TZq-wwXnv0ROrnR2MU0_5aiihrPUUDzqg9JzT19s9V39eRUBRvSa2li0SqRHGsjYvjrYENrck0lLQT5VD89BgwAYDzg45JHeMrc-Ir0D7YPkJRePrS1ZY2m2BLxuI8SJ7kqVr_DQIpI4MarCwVsgX60_J9VkFl7-y_UHbBHC2QVxtApqEAHrl4Nv3kvhlp5vGlB_VHZdGDPeLMeRJkc7ANLiLr9CwgaQvH6V9v5M6MvyTIwxeQocsE42H"
        });

        await dbContext.SaveChangesAsync();
    }
}
