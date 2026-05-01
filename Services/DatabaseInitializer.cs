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

        var cantaKategori = new Category
        {
            Name = "Cantalar",
            Slug = "cantalar",
            Description = "Zamansiz deri canta seckileri.",
            HighlightImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuCsnbvgZzRzgBWtZ1eiwuzcasVAwmeyC2dB2kHU8m-9AnK4dUMSBtli0xlVPalApOPQbLnG8HveRo9iJeAxnP43rc5Me-tl8NLEsvJMVJrXNUucFqh6GOWeIUvclMH62QoaqIR0ox4VCUo_tClACRMrOFVmfdv-7ErEr1Jhd2jor2dFWQdRQScwxu2-J1G2K2JzM7wTr2-v-ngkbGr3MX-YvjEE-zNUKX20-5KqzUBOUYp7zGONSF3hFlKmeuz7Sxt3HFOtpaltx19P",
            CallToActionText = "Koleksiyonu Incele",
            IsHighlightedOnHomePage = true,
            DisplayOrder = 1
        };

        var yeniSezonKategori = new Category
        {
            Name = "Yeni Gelenler",
            Slug = "yeni-gelenler",
            Description = "Atolyeden yeni cikmis sezon secimleri.",
            HighlightImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBY8_CZxe2ymvA8DKBNd09PNZ5hOrrpQf_ybwfJ0XKGTFTDzwL4ghQbZFZwXNRTIdIMPQHdMlvWVWTLzvuvQqtTt9Jzd9FCjrdO2BkiGSeDfj09coZugAEThf5KkjYUKqzujrsf-BXnoWTVxEr6WeiaCZvj7fMFir1k2XtUACYV9RdmqFMy7QuIrr-F9N_HemSzARLVHBztoxLhqy2AoQ76-eqVjRt7T6BCphYBHCZZtSPcql_Oq7cuaGqYFd4LwwD7Yt4ROtnkfo_7",
            CallToActionText = "Sezonu Kesfet",
            IsHighlightedOnHomePage = true,
            DisplayOrder = 2
        };

        var cuzdanKategori = new Category
        {
            Name = "Cuzdanlar",
            Slug = "cuzdanlar",
            Description = "Ince iscilikli kompakt parcalar.",
            HighlightImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuD8QkIXQ8p9bGYzxKgw1j5Asnkt-KsgpsTjpVuWBtM3bVZT_KDcIDVZIo0fb1LUNEUvR246FjMQ7i4Sk-IE0_G_9MAERHLCayuUES_YTrHpIB_CSqR9BGNBluH5Wz2qmWFsxbSehFYD2UcxXlUQfrhBN5pUx_IGqvFZ3h7DNY2nFm9MJeUQ8ubMQyXiu6XyHLthiYxg_CSx5ZaqBVp1_NguiKPgqdLk70som5KyBJ6NUF03OnMkRXiOIQwFT3B8kcvuJtmZ3XtpJ8rn",
            CallToActionText = "Seckiyi Gor",
            IsHighlightedOnHomePage = true,
            DisplayOrder = 3
        };

        var giyimKategori = new Category
        {
            Name = "Giyim",
            Slug = "giyim",
            Description = "Yumusak dokular ve rafine siluetler.",
            HighlightImageUrl = string.Empty,
            CallToActionText = string.Empty,
            IsHighlightedOnHomePage = false,
            DisplayOrder = 4
        };

        var aksesuarKategori = new Category
        {
            Name = "Aksesuar",
            Slug = "aksesuar",
            Description = "Stil tamamlayan detay parcalari.",
            HighlightImageUrl = string.Empty,
            CallToActionText = string.Empty,
            IsHighlightedOnHomePage = false,
            DisplayOrder = 5
        };

        dbContext.Categories.AddRange(cantaKategori, yeniSezonKategori, cuzdanKategori, giyimKategori, aksesuarKategori);

        dbContext.SiteHeroes.Add(new SiteHero
        {
            Eyebrow = "Miras ve Zanaat",
            Title = "Zamansiz Zarafet Icin Uretildi",
            PrimaryActionText = "Urunleri Incele",
            SecondaryActionText = "Koleksiyonu Kesfet",
            ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuByfA_tVunlbq9-xUfuygHrCJRzKApw_Ppsk1r1ONL-a4VlVErhGmXYqGpgtm9w-fPgSDyWCC_WdjmIa7u0kbLbw-sd9P0NxyGAT_EhxKwb1FTjXqUM6hcRpKCcnb0Zz2fc67CuWCvzFaRG6I8JZ97Mr4Vchb7iwYYjBFhwTCZKfYz8ioELlQDceCq9rvqOo2buUwIhUWFnhQ5nT_fXZ_mOnpdCanDw4nN5JnnBSgdeRztEM-KlufiGiDfx9XxF566nw9LSQt0NotAU"
        });

        dbContext.StoreFeatures.AddRange(
            new StoreFeature { Title = "El Isciligi", IconName = "front_hand", DisplayOrder = 1 },
            new StoreFeature { Title = "Premium Malzeme", IconName = "diamond", DisplayOrder = 2 },
            new StoreFeature { Title = "Dunya Capinda Teslimat", IconName = "public", DisplayOrder = 3 });

        dbContext.Products.AddRange(
            new Product
            {
                Category = cantaKategori,
                Name = "Miras Tote Canta",
                Slug = "miras-tote-canta",
                ShortDescription = "Tam damarlı Italyan derisi",
                Description = "Gunluk tempoya uyum saglayan, guclu duruslu deri tote canta.",
                ListingBadge = string.Empty,
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
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
                ],
                Colors =
                [
                    new ProductColor { Name = "Koyu Kahve", HexCode = "#5B3A29", DisplayOrder = 1 }
                ]
            },
            new Product
            {
                Category = cuzdanKategori,
                Name = "Ince Bifold Cuzdan",
                Slug = "ince-bifold-cuzdan",
                ShortDescription = "El dikimi bitis",
                Description = "Ince profil ve yumusak dokuya sahip kompakt deri cuzdan.",
                ListingBadge = string.Empty,
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
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
                ],
                Colors =
                [
                    new ProductColor { Name = "Kestane", HexCode = "#8A5A44", DisplayOrder = 1 }
                ]
            },
            new Product
            {
                Category = yeniSezonKategori,
                Name = "Hafta Sonu Cantasi",
                Slug = "hafta-sonu-cantasi",
                ShortDescription = "Guclendirilmis govde formu",
                Description = "Kisa kacamaklara uygun, genis hacimli ve dengeli bir yol cantasi.",
                ListingBadge = string.Empty,
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
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
                ],
                Colors =
                [
                    new ProductColor { Name = "Mat Siyah", HexCode = "#1F1F1F", DisplayOrder = 1 }
                ]
            },
            new Product
            {
                Category = giyimKategori,
                Name = "Imza Kemik Rengi Keten Gomlek",
                Slug = "imza-kemik-rengi-keten-gomlek",
                ShortDescription = "Hafif ve dogal doku",
                Description = "Yaz sezonu icin yumusak dokulu, nefes alabilen keten overshirt.",
                ListingBadge = "Sinirli Seri",
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
                Price = 340m,
                IsFeaturedOnHomePage = false,
                DisplayOrder = 4,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuA4w63RMSEwbQBOQ44bpv5h7eJ_1WyqXuN-ATQ5u4N60i3fr9nIA4AyB8zC87sqt0ORFU5L__4NHfIay-Fe30Q11dBz2DemiWSPb0-Js6PttMRvG4eb4FeS5OjQRQjRWzJngMmSm2rORlqYqgGbGnQJpo4qvLFpQ2OLdWleaWe-YHyUhdPCLTrK5cLNQEswtsMGWl0bVj9JvhrFfRLySS-8o-nlj5a1DDHFkZpvtmo_5c5Zsk2PZ2h3-DxCqHgN0AL9NiMEX1XLJAp0",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ],
                Colors =
                [
                    new ProductColor { Name = "Kemik", HexCode = "#E5E4E2", DisplayOrder = 1 },
                    new ProductColor { Name = "Antrasit", HexCode = "#2C2C2C", DisplayOrder = 2 }
                ]
            },
            new Product
            {
                Category = giyimKategori,
                Name = "Heykelsi Antrasit Pantolon",
                Slug = "heykelsi-antrasit-pantolon",
                ShortDescription = "Net hatli kalip",
                Description = "Yuksek bel ve akiskan dususe sahip modern kesim pantolon.",
                ListingBadge = string.Empty,
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
                Price = 480m,
                IsFeaturedOnHomePage = false,
                DisplayOrder = 5,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBYPww4tMW53XMoWfF0C5A_z-8QjXj4M6CJ6w_PZiuKRbIBgl3tKi8GteZhJ6SOB9tFxrvK182alB4yHylGFGcwc3ySyLDYtMOCcCDlVI6htrW-9YPzxJAayQe6fxvacIRCiEVb2SlnBvmGfcpQ8ZqtY-SqHstDZ1wM64MsqjkwxftJly2_KoaOhS2ebsNsbSiCrngRTTisheQYJc4g0m6toIQOWUmd3a4R2Bkisqatft15q6vmCBz33ztW47816qOH4tqL3xCJUOhc",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ],
                Colors =
                [
                    new ProductColor { Name = "Antrasit", HexCode = "#1A1A1A", DisplayOrder = 1 }
                ]
            },
            new Product
            {
                Category = yeniSezonKategori,
                Name = "Miras Takimi",
                Slug = "miras-takimi",
                ShortDescription = "Tum kombin bir arada",
                Description = "Sezonun ana gorunumunu bir araya getiren tam set kombin secimi.",
                ListingBadge = string.Empty,
                CollectionNoteTitle = "Miras Takimi",
                CollectionNoteText = "Tam kombin olarak sunulur",
                IsWideFeature = true,
                Price = 2100m,
                IsFeaturedOnHomePage = false,
                DisplayOrder = 6,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuAF3ShhGb3ezb_Kg_6Yd-LY7qcmX7eVEo3XYu9EaGavYauox_82_1M4y-lJ8ugOJ8q0EYEUDUUiJzutfbPTudlJGxaaZyM1Ri2-VZ4RTX9tRbK2CpIgJ_SYlQ0yYucFiq34cwWMTW8IQSDk2cXijAokbiYU9ZJFAJeCV4UIUnebNhwsw_lQvjyt2X0Es4D5wgkx0VW8g-japj8-outZz-IC_S5JK_8lQE_2_rdlmxpdOTG6CrI_JMMvUVf37SObH36jXnpmMJRCDAIY",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ]
            },
            new Product
            {
                Category = aksesuarKategori,
                Name = "Ham Ipek Kravat",
                Slug = "ham-ipek-kravat",
                ShortDescription = "Yumusak, mat bitis",
                Description = "El dokulu hissiyat veren ham ipekten uretilmis zarif kravat.",
                ListingBadge = string.Empty,
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
                Price = 185m,
                IsFeaturedOnHomePage = false,
                DisplayOrder = 7,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuAXNWnZT_7MteXQA64QL72QyThtXVUej9LjjjoyguPPhukyFjlKc40ipjwBxTfB5Tnddhn-3zOri-2TuMUMA38maQ_PS1tEUFVtmwTpTAxztaj6JiYhZsb0QJ7nzJtXjXsngGioPl5JMuclKEi4kOAPX-GwOrDGWiH9BtZP2KaPfbFtL-TTvVXcX1NC8TVpR9IV-Dctrq4xKDdSSkRRpTW_WH-uhF490TiCBjO2vKZQ684HhyLgx_P11cePBHknmvuMmmE3VEqEZq_N",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ],
                Colors =
                [
                    new ProductColor { Name = "Kirli Beyaz", HexCode = "#FAF9F6", DisplayOrder = 1 },
                    new ProductColor { Name = "Kum", HexCode = "#D2B48C", DisplayOrder = 2 }
                ]
            },
            new Product
            {
                Category = giyimKategori,
                Name = "Sokumlu Kum Trenckot",
                Slug = "sokumlu-kum-trenckot",
                ShortDescription = "Hafif yazlik form",
                Description = "Yapilandirilmis ama hafif hisli, yaz gecislerine uygun trenckot.",
                ListingBadge = "Yeni Sezon",
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
                Price = 820m,
                IsFeaturedOnHomePage = false,
                DisplayOrder = 8,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDP3k6NLnF6-dJbx1mySBhmIGqfTkTT0HfJCpaXIT9yPYlJHChk-s4-_g47djGXCFsX5VX2LjQVi8hsyGRkthDeAaIwiAel-v6sjdHbd5zaUqyvOoUM20WRx9vwn1o0KrzQ5BeVWLy-v3Bf0qiPjXGGdmNTJ1RSgyImtyrNmGQGrTibOCyNa2dhf3p0KIVGFDfxNstPu8HSEUTai_GNozSpZRc2hVwHSYPXmB_gizQ4G3kkFuDGnaPLzKBAUrsXl0C31Tx99V2p4H5I",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ]
            },
            new Product
            {
                Category = cantaKategori,
                Name = "Yapilandirilmis Dana Derisi Tote",
                Slug = "yapilandirilmis-dana-derisi-tote",
                ShortDescription = "Heykelsi siluet",
                Description = "Net cizgileri ve tok yapisiyla one cikan premium tote canta.",
                ListingBadge = string.Empty,
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
                Price = 1150m,
                IsFeaturedOnHomePage = false,
                DisplayOrder = 9,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDt6zOMb6MbnYRztUOzrn1QuH6rksCA_XjeejzdIzu3xAiFha9aeY2RaZP1CMK51SgNjcR5fIhIZIgw2KMdm_RFnWqEwWDNx-5kOFgbFekqG1-yfsOtVlNzWD48aT2EPZlpUa2Tr64rsAcH_T65kbMegJ3E8jzyt8l8iPqB33qsnu561njtawZYapYNUkiWR83WqErN-dEKGHRPlEF8fYEbjVI6aOuFAzDiudL2QAbMTJ0onJdA4l8SHJEvggnFdrMKqlLpbaZn94kT",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ]
            },
            new Product
            {
                Category = giyimKategori,
                Name = "Yulaf Tonlu Merino Triko",
                Slug = "yulaf-tonlu-merino-triko",
                ShortDescription = "Yogun orgu dokusu",
                Description = "Serin aksamlar icin yumusak, agir gramajli merino triko.",
                ListingBadge = string.Empty,
                CollectionNoteTitle = string.Empty,
                CollectionNoteText = string.Empty,
                IsWideFeature = false,
                Price = 310m,
                IsFeaturedOnHomePage = false,
                DisplayOrder = 10,
                Images =
                [
                    new ProductImage
                    {
                        ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuB-YVbq82jnK2-VTEfYxz7g1gYfP2KutJ09g_OhF3FU5dFjvNfqEhYaoUznJF9NkvQuKGE_e7Mp98qCsQ2H8yeQGkOoypH3QV92D0oSZb4m3tG_0h9go0s40WnUT8Klk29tZ08JseKqWPJr9pQ-W84IMFZmFdyUj6GNStNkRexlK0Tn9IVpLKcCJMlnZNVITWi2GqKrfqes1fokUdqFePG738s3AzW6uG0IC7H_DxKvq8xPjplGwpyxoDtj9dWi1r49gJ24Pqs61FB8",
                        IsPrimary = true,
                        DisplayOrder = 1
                    }
                ]
            });

        dbContext.BrandStories.Add(new BrandStory
        {
            Eyebrow = "Felsefemiz",
            Title = "Modern Mirasi Yeniden Tanimliyoruz",
            ParagraphOne = "FUWANS olarak gercek luksun sessiz detaylarda sakli olduguna inaniyoruz. Yolculugumuz, geleneksel deri isciligini bugunun yasamina yeniden kazandirma fikriyle basladi.",
            ParagraphTwo = "Her parca, ham malzeme ile usta zanaatkar arasindaki diyalogdan dogar. Derilerimizi etik Avrupa tabakhanelerinden seciyor, her kenari elde bitirerek urunlere karakter kazandiriyoruz.",
            ActionText = "Zanaat Yolculugumuzu Kesfet",
            ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBOOnnOIdBH8H6tmYl9le2TZq-wwXnv0ROrnR2MU0_5aiihrPUUDzqg9JzT19s9V39eRUBRvSa2li0SqRHGsjYvjrYENrck0lLQT5VD89BgwAYDzg45JHeMrc-Ir0D7YPkJRePrS1ZY2m2BLxuI8SJ7kqVr_DQIpI4MarCwVsgX60_J9VkFl7-y_UHbBHC2QVxtApqEAHrl4Nv3kvhlp5vGlB_VHZdGDPeLMeRJkc7ANLiLr9CwgaQvH6V9v5M6MvyTIwxeQocsE42H"
        });

        await dbContext.SaveChangesAsync();
    }
}
