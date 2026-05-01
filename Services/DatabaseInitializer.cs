using Fuwans.Data;
using Fuwans.Models;
using Microsoft.EntityFrameworkCore;

namespace Fuwans.Services;

public class DatabaseInitializer(AppDbContext dbContext)
{
    public async Task InitializeAsync()
    {
        await dbContext.Database.EnsureCreatedAsync();
        await EnsureSchemaUpdatesAsync();
        await SeedAsync();
    }

    private async Task EnsureSchemaUpdatesAsync()
    {
        await dbContext.Database.ExecuteSqlRawAsync("""
            IF COL_LENGTH('Products', 'CollectionLabel') IS NULL
                ALTER TABLE Products ADD CollectionLabel nvarchar(max) NOT NULL CONSTRAINT DF_Products_CollectionLabel DEFAULT '';
            IF COL_LENGTH('Products', 'SelectedColorName') IS NULL
                ALTER TABLE Products ADD SelectedColorName nvarchar(max) NOT NULL CONSTRAINT DF_Products_SelectedColorName DEFAULT '';
            IF COL_LENGTH('Products', 'SizeGuideText') IS NULL
                ALTER TABLE Products ADD SizeGuideText nvarchar(max) NOT NULL CONSTRAINT DF_Products_SizeGuideText DEFAULT '';
            IF COL_LENGTH('Products', 'DetailsText') IS NULL
                ALTER TABLE Products ADD DetailsText nvarchar(max) NOT NULL CONSTRAINT DF_Products_DetailsText DEFAULT '';
            IF COL_LENGTH('Products', 'MaterialsText') IS NULL
                ALTER TABLE Products ADD MaterialsText nvarchar(max) NOT NULL CONSTRAINT DF_Products_MaterialsText DEFAULT '';
            IF COL_LENGTH('Products', 'ShippingReturnsText') IS NULL
                ALTER TABLE Products ADD ShippingReturnsText nvarchar(max) NOT NULL CONSTRAINT DF_Products_ShippingReturnsText DEFAULT '';
            IF OBJECT_ID('ProductSizes', 'U') IS NULL
            BEGIN
                CREATE TABLE ProductSizes (
                    Id int NOT NULL IDENTITY,
                    ProductId int NOT NULL,
                    Label nvarchar(max) NOT NULL,
                    IsSelectedByDefault bit NOT NULL,
                    DisplayOrder int NOT NULL,
                    CreatedAtUtc datetime2 NOT NULL,
                    CONSTRAINT PK_ProductSizes PRIMARY KEY (Id),
                    CONSTRAINT FK_ProductSizes_Products_ProductId FOREIGN KEY (ProductId) REFERENCES Products (Id) ON DELETE CASCADE
                );
                CREATE INDEX IX_ProductSizes_ProductId ON ProductSizes (ProductId);
            END
            """);
    }

    private async Task SeedAsync()
    {
        var categories = new Dictionary<string, Category>
        {
            ["cantalar"] = await UpsertCategoryAsync("cantalar", "Cantalar", "Zamansiz deri canta seckileri.", "https://lh3.googleusercontent.com/aida-public/AB6AXuCsnbvgZzRzgBWtZ1eiwuzcasVAwmeyC2dB2kHU8m-9AnK4dUMSBtli0xlVPalApOPQbLnG8HveRo9iJeAxnP43rc5Me-tl8NLEsvJMVJrXNUucFqh6GOWeIUvclMH62QoaqIR0ox4VCUo_tClACRMrOFVmfdv-7ErEr1Jhd2jor2dFWQdRQScwxu2-J1G2K2JzM7wTr2-v-ngkbGr3MX-YvjEE-zNUKX20-5KqzUBOUYp7zGONSF3hFlKmeuz7Sxt3HFOtpaltx19P", "Koleksiyonu Incele", true, 1),
            ["yeni-gelenler"] = await UpsertCategoryAsync("yeni-gelenler", "Yeni Gelenler", "Atolyeden yeni cikmis sezon secimleri.", "https://lh3.googleusercontent.com/aida-public/AB6AXuBY8_CZxe2ymvA8DKBNd09PNZ5hOrrpQf_ybwfJ0XKGTFTDzwL4ghQbZFZwXNRTIdIMPQHdMlvWVWTLzvuvQqtTt9Jzd9FCjrdO2BkiGSeDfj09coZugAEThf5KkjYUKqzujrsf-BXnoWTVxEr6WeiaCZvj7fMFir1k2XtUACYV9RdmqFMy7QuIrr-F9N_HemSzARLVHBztoxLhqy2AoQ76-eqVjRt7T6BCphYBHCZZtSPcql_Oq7cuaGqYFd4LwwD7Yt4ROtnkfo_7", "Sezonu Kesfet", true, 2),
            ["cuzdanlar"] = await UpsertCategoryAsync("cuzdanlar", "Cuzdanlar", "Ince iscilikli kompakt parcalar.", "https://lh3.googleusercontent.com/aida-public/AB6AXuD8QkIXQ8p9bGYzxKgw1j5Asnkt-KsgpsTjpVuWBtM3bVZT_KDcIDVZIo0fb1LUNEUvR246FjMQ7i4Sk-IE0_G_9MAERHLCayuUES_YTrHpIB_CSqR9BGNBluH5Wz2qmWFsxbSehFYD2UcxXlUQfrhBN5pUx_IGqvFZ3h7DNY2nFm9MJeUQ8ubMQyXiu6XyHLthiYxg_CSx5ZaqBVp1_NguiKPgqdLk70som5KyBJ6NUF03OnMkRXiOIQwFT3B8kcvuJtmZ3XtpJ8rn", "Seckiyi Gor", true, 3),
            ["giyim"] = await UpsertCategoryAsync("giyim", "Giyim", "Yumusak dokular ve rafine siluetler.", string.Empty, string.Empty, false, 4),
            ["aksesuar"] = await UpsertCategoryAsync("aksesuar", "Aksesuar", "Stil tamamlayan detay parcalari.", string.Empty, string.Empty, false, 5)
        };

        await UpsertHeroAsync();
        await UpsertFeaturesAsync();
        await UpsertBrandStoryAsync();

        await UpsertProductAsync(new ProductSeed(
            "miras-yun-topkaban",
            categories["giyim"].Id,
            "Miras Yun Topkaban",
            "Ana Koleksiyon",
            "Sessiz guc sunan heykelsi kesim",
            "Yuzde 100 surdurulebilir Italyan kasmir-yun karisimindan uretilen bu parca, sessiz bir durusla dikkat ceken modern bir miras yorumu sunar.",
            1850m,
            "Kemik",
            "Olcu rehberimiz dar omuz ve rahat govde dengesi icin normal bedeninizi onermektedir.",
            "Rahat kalip, belirgin omuz formu, cift sira dugme kapama ve elde tamamlanmis ic dikiş detaylari.",
            "Yuzde 85 yeni yun, yuzde 15 kasmir. Astar: yuzde 100 cupro.",
            "Dunya genelinde ucretsiz teslimat sunulur. Koleksiyon urunlerinde 14 gun icinde iade kabul edilir.",
            string.Empty,
            string.Empty,
            string.Empty,
            false,
            false,
            1,
            [
                new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuCINUj5MwR2zHHsSfwAapOMWu3j97Oaf890ZzGMkxlRXRulc_GFVnOBAx9s6giVt9ob5NUNgeEth8k_wHGYzYo6qD2DZMwyvUtt0WeMPVh37sFYXF2gJjt6cEM1dLSujkh3ZFqwdbTqg70Cpz2LugJTzuqB6OVdIq0X4FWhtxSPW94-xuEzv_mL2evb8sL71JdaPgtCLuhNODLkOr8Dg3a-oflEnWjqygfHwNlg_SYkZLTqeC8jMlv7L45BkJCjMrITbmjm8uIq_XkH", true),
                new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuCihogzv5-RIZnz386y-IteuVMwlnDj-YnlVUJfWuFNOHZeV8ZaoiLXJmmVQ0l3nTuBYqQBTcRjCcsK1fof94igPNSOWEbMTpXmhuKdg89Ea4BnpkBHqw-LxvCivuQLKi47_LFpYa3BM7y2w8eccYnYR5BfOniwjNG_zT9qm3RRpj6czUqIkhoSg7MSUzHGmlZ9EmjheefEI2GVJZjNXHlxeLtyBLbQNGziC_XVS2MT6v8uiw6HILBs1FTwu5i6sUc4-FSHpWRhcdRN", false),
                new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuB-QSX-jWu2Uf5PJR2X5SdJmIk9djTNRgWuxeGnL_JRq0E6U4ZQ9jJvvHtIUqbMZnHWQmXdMEYJc8cJN7dJQvB0GcCTOYwyJq-MvY4qYGl8yHhpTivn58VAR4K1YtTmQqiFwVyCgP8yexxk5tD3tOA6rVbAkEC98K2gapXaXKs4be2ETNQeXpRt8F9l0HKHvsRQBSZHUG7GhA5Gwvw1kYZvQmvwiT63rZHacH3BsDzKk-tzimDGxezP7G2vXKkj_SNOd8z7gILHgJIu", false)
            ],
            [
                new ProductColorSeed("Kemik", "#E5E4DF"),
                new ProductColorSeed("Siyah", "#1B1B1C"),
                new ProductColorSeed("Koyu Kahve", "#4A2C2A")
            ],
            [
                new ProductSizeSeed("XS", false),
                new ProductSizeSeed("S", true),
                new ProductSizeSeed("M", false),
                new ProductSizeSeed("L", false)
            ]));

        await UpsertProductAsync(new ProductSeed("miras-tote-canta", categories["cantalar"].Id, "Miras Tote Canta", "Ana Koleksiyon", "Tam damarli Italyan derisi", "Gunluk tempoya uyum saglayan, guclu duruslu deri tote canta.", 1250m, "Koyu Kahve", "Bu model tek beden olarak sunulur.", "Yapilandirilmis govde ve elde bitirilmis kenarlarla gunluk kullanim icin tasarlandi.", "Tam damarli Italyan derisi.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", string.Empty, string.Empty, string.Empty, false, true, 2, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuC3SMxUjryuT7iIduBpTE6m9Q5rRMZC_T5VP4GhdoVmtEIjhPvfEdMsMLlz_LcW0OagaNERiyYAiyZfUXTQ6Zkmt_fqS2-iUGVZSQMG68e5FfIkiuD72rmwy5t8ScIGrNoilMiYouA3qlT_FeU7DvJa2y7r1A_IbnkOS8K2BLc0eV_6Z7c4fxlk9n8LMT3xqu_NK0cT5Um_U-CSqzWGHkBKv6CsVsRLQ0zJDT0ea1X4YhQ7_0Loqb4q9hqCmUhlw2wP0VHn5SDB4HWj", true)], [new ProductColorSeed("Koyu Kahve", "#5B3A29")], []));
        await UpsertProductAsync(new ProductSeed("ince-bifold-cuzdan", categories["cuzdanlar"].Id, "Ince Bifold Cuzdan", "Ana Koleksiyon", "El dikimi bitis", "Ince profil ve yumusak dokuya sahip kompakt deri cuzdan.", 245m, "Kestane", "Bu model tek beden olarak sunulur.", "Kart ve nakit bolmeleriyle sade bir duzen sunar.", "Dogal dana derisi.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", string.Empty, string.Empty, string.Empty, false, true, 3, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuCBwW9Lqioyk4MgTImZKgzafdAvf17YNUkShlp1-FU7vm7Zh0pTRIQhIxwL840gZnoVa-wWDJT0X5X3tgqCL6vDQXzXTI0XOS-ZiwiMfEewCaPIUWiWOn0R6tSIHImIZcp04Jlr6B5RMzSMfTKRgnzP4fVBocSU49ktDo1Mmnj9bWIMxxtEAlMReBykLYCtaU7FmuG1GjYfTrPrAUtx9rWcfKNo1dWnhrHhrD2Kh4-6ffSHUcRl12VPaNijg66ndGS0gM8ymGHVfRbJ", true)], [new ProductColorSeed("Kestane", "#8A5A44")], []));
        await UpsertProductAsync(new ProductSeed("hafta-sonu-cantasi", categories["yeni-gelenler"].Id, "Hafta Sonu Cantasi", "Sezon Seckisi", "Guclendirilmis govde formu", "Kisa kacamaklara uygun, genis hacimli ve dengeli bir yol cantasi.", 1800m, "Mat Siyah", "Bu model tek beden olarak sunulur.", "Genis ic hacim ve destekli taban formuyla dikkat ceker.", "Yumusak ama dayanikli deri govde.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", string.Empty, string.Empty, string.Empty, false, true, 4, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuDIhjch-QYJkyw4xeJX-vfODg8BAwan0w53eIwX3IiVepq-ccmc3QqHRNXoyXflzbDJLf8XdadBtJlX20pwkmUxZhvh3JY-hn5Ai3pkT926BafLCYNMMpmVwpd92d0ilB9qVptDLgYOTG5AxA6rAx4rkMQQArExWJMKi95FA6X8d8PxSid8i37toF-329z2mpkMS4nvJMrGBrgtsAjidQt7rJdUfErg3YoA_F_lvQ2fGJdZIYJeWV7xQa7eTLTIwHqIyix0CNF_4YOG", true)], [new ProductColorSeed("Mat Siyah", "#1F1F1F")], []));
        await UpsertProductAsync(new ProductSeed("imza-kemik-rengi-keten-gomlek", categories["giyim"].Id, "Imza Kemik Rengi Keten Gomlek", "Yaz Seckisi", "Hafif ve dogal doku", "Yaz sezonu icin yumusak dokulu, nefes alabilen keten overshirt.", 340m, "Kemik", "Rahat kalip. Daha dar bir gorunum icin bir beden kucuk tercih edebilirsiniz.", "Gunluk kullanima uygun rahat kesim.", "Yuzde 100 keten.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", "Sinirli Seri", string.Empty, string.Empty, false, false, 5, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuA4w63RMSEwbQBOQ44bpv5h7eJ_1WyqXuN-ATQ5u4N60i3fr9nIA4AyB8zC87sqt0ORFU5L__4NHfIay-Fe30Q11dBz2DemiWSPb0-Js6PttMRvG4eb4FeS5OjQRQjRWzJngMmSm2rORlqYqgGbGnQJpo4qvLFpQ2OLdWleaWe-YHyUhdPCLTrK5cLNQEswtsMGWl0bVj9JvhrFfRLySS-8o-nlj5a1DDHFkZpvtmo_5c5Zsk2PZ2h3-DxCqHgN0AL9NiMEX1XLJAp0", true)], [new ProductColorSeed("Kemik", "#E5E4E2"), new ProductColorSeed("Antrasit", "#2C2C2C")], [new ProductSizeSeed("XS", false), new ProductSizeSeed("S", true), new ProductSizeSeed("M", false), new ProductSizeSeed("L", false)]));
        await UpsertProductAsync(new ProductSeed("heykelsi-antrasit-pantolon", categories["giyim"].Id, "Heykelsi Antrasit Pantolon", "Yaz Seckisi", "Net hatli kalip", "Yuksek bel ve akiskan dususe sahip modern kesim pantolon.", 480m, "Antrasit", "Normal kalip. Bedeninizi secmeniz onerilir.", "Akici kumas ve guclu cizgilerle modern siluet sunar.", "Yun karisimli dokuma kumas.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", string.Empty, string.Empty, string.Empty, false, false, 6, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuBYPww4tMW53XMoWfF0C5A_z-8QjXj4M6CJ6w_PZiuKRbIBgl3tKi8GteZhJ6SOB9tFxrvK182alB4yHylGFGcwc3ySyLDYtMOCcCDlVI6htrW-9YPzxJAayQe6fxvacIRCiEVb2SlnBvmGfcpQ8ZqtY-SqHstDZ1wM64MsqjkwxftJly2_KoaOhS2ebsNsbSiCrngRTTisheQYJc4g0m6toIQOWUmd3a4R2Bkisqatft15q6vmCBz33ztW47816qOH4tqL3xCJUOhc", true)], [new ProductColorSeed("Antrasit", "#1A1A1A")], [new ProductSizeSeed("S", false), new ProductSizeSeed("M", true), new ProductSizeSeed("L", false)]));
        await UpsertProductAsync(new ProductSeed("miras-takimi", categories["yeni-gelenler"].Id, "Miras Takimi", "Sezon Seckisi", "Tum kombin bir arada", "Sezonun ana gorunumunu bir araya getiren tam set kombin secimi.", 2100m, "Coklu Ton", "Beden secimi urun detayinda ayri ayri belirlenir.", "Tam kombin olarak sunulan editor secimi.", "Karismali premium kumas secimi.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", string.Empty, "Miras Takimi", "Tam kombin olarak sunulur", true, false, 7, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuAF3ShhGb3ezb_Kg_6Yd-LY7qcmX7eVEo3XYu9EaGavYauox_82_1M4y-lJ8ugOJ8q0EYEUDUUiJzutfbPTudlJGxaaZyM1Ri2-VZ4RTX9tRbK2CpIgJ_SYlQ0yYucFiq34cwWMTW8IQSDk2cXijAokbiYU9ZJFAJeCV4UIUnebNhwsw_lQvjyt2X0Es4D5wgkx0VW8g-japj8-outZz-IC_S5JK_8lQE_2_rdlmxpdOTG6CrI_JMMvUVf37SObH36jXnpmMJRCDAIY", true)], [], []));
        await UpsertProductAsync(new ProductSeed("ham-ipek-kravat", categories["aksesuar"].Id, "Ham Ipek Kravat", "Aksesuar", "Yumusak, mat bitis", "El dokulu hissiyat veren ham ipekten uretilmis zarif kravat.", 185m, "Kirli Beyaz", "Bu model tek beden olarak sunulur.", "Ince dokulu ve hafif yapili aksesuar.", "Ham ipek dokuma.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", string.Empty, string.Empty, string.Empty, false, false, 8, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuAXNWnZT_7MteXQA64QL72QyThtXVUej9LjjjoyguPPhukyFjlKc40ipjwBxTfB5Tnddhn-3zOri-2TuMUMA38maQ_PS1tEUFVtmwTpTAxztaj6JiYhZsb0QJ7nzJtXjXsngGioPl5JMuclKEi4kOAPX-GwOrDGWiH9BtZP2KaPfbFtL-TTvVXcX1NC8TVpR9IV-Dctrq4xKDdSSkRRpTW_WH-uhF490TiCBjO2vKZQ684HhyLgx_P11cePBHknmvuMmmE3VEqEZq_N", true)], [new ProductColorSeed("Kirli Beyaz", "#FAF9F6"), new ProductColorSeed("Kum", "#D2B48C")], []));
        await UpsertProductAsync(new ProductSeed("sokumlu-kum-trenckot", categories["giyim"].Id, "Sokumlu Kum Trenckot", "Yeni Gelenler", "Hafif yazlik form", "Yapilandirilmis ama hafif hisli, yaz gecislerine uygun trenckot.", 820m, "Kum", "Normal kalip. Katmanli kullanim icin kendi bedeninizi secin.", "Yumusak omuz ve hafif govde ile sezon gecislerine uygundur.", "Pamuk karisimli dis yuzey.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", "Yeni Sezon", string.Empty, string.Empty, false, false, 9, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuDP3k6NLnF6-dJbx1mySBhmIGqfTkTT0HfJCpaXIT9yPYlJHChk-s4-_g47djGXCFsX5VX2LjQVi8hsyGRkthDeAaIwiAel-v6sjdHbd5zaUqyvOoUM20WRx9vwn1o0KrzQ5BeVWLy-v3Bf0qiPjXGGdmNTJ1RSgyImtyrNmGQGrTibOCyNa2dhf3p0KIVGFDfxNstPu8HSEUTai_GNozSpZRc2hVwHSYPXmB_gizQ4G3kkFuDGnaPLzKBAUrsXl0C31Tx99V2p4H5I", true)], [new ProductColorSeed("Kum", "#CBB38A")], [new ProductSizeSeed("S", false), new ProductSizeSeed("M", true), new ProductSizeSeed("L", false)]));
        await UpsertProductAsync(new ProductSeed("yapilandirilmis-dana-derisi-tote", categories["cantalar"].Id, "Yapilandirilmis Dana Derisi Tote", "Cantalar", "Heykelsi siluet", "Net cizgileri ve tok yapisiyla one cikan premium tote canta.", 1150m, "Siyah", "Bu model tek beden olarak sunulur.", "Dik duruslu govde ve geometrik form.", "Dana derisi ve metal donanim.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", string.Empty, string.Empty, string.Empty, false, false, 10, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuDt6zOMb6MbnYRztUOzrn1QuH6rksCA_XjeejzdIzu3xAiFha9aeY2RaZP1CMK51SgNjcR5fIhIZIgw2KMdm_RFnWqEwWDNx-5kOFgbFekqG1-yfsOtVlNzWD48aT2EPZlpUa2Tr64rsAcH_T65kbMegJ3E8jzyt8l8iPqB33qsnu561njtawZYapYNUkiWR83WqErN-dEKGHRPlEF8fYEbjVI6aOuFAzDiudL2QAbMTJ0onJdA4l8SHJEvggnFdrMKqlLpbaZn94kT", true)], [new ProductColorSeed("Siyah", "#232323")], []));
        await UpsertProductAsync(new ProductSeed("yulaf-tonlu-merino-triko", categories["giyim"].Id, "Yulaf Tonlu Merino Triko", "Triko", "Yogun orgu dokusu", "Serin aksamlar icin yumusak, agir gramajli merino triko.", 310m, "Yulaf", "Rahat kalip. Daha fit bir durus icin bir beden kucultulebilir.", "Yogun orgu ve dusuk omuz yapisi ile tamamlanir.", "Yuzde 100 merino yun.", "Dunya genelinde ucretsiz teslimat ve 14 gun iade.", string.Empty, string.Empty, string.Empty, false, false, 11, [new ProductImageSeed("https://lh3.googleusercontent.com/aida-public/AB6AXuB-YVbq82jnK2-VTEfYxz7g1gYfP2KutJ09g_OhF3FU5dFjvNfqEhYaoUznJF9NkvQuKGE_e7Mp98qCsQ2H8yeQGkOoypH3QV92D0oSZb4m3tG_0h9go0s40WnUT8Klk29tZ08JseKqWPJr9pQ-W84IMFZmFdyUj6GNStNkRexlK0Tn9IVpLKcCJMlnZNVITWi2GqKrfqes1fokUdqFePG738s3AzW6uG0IC7H_DxKvq8xPjplGwpyxoDtj9dWi1r49gJ24Pqs61FB8", true)], [new ProductColorSeed("Yulaf", "#D6C8B0")], [new ProductSizeSeed("S", false), new ProductSizeSeed("M", true), new ProductSizeSeed("L", false)]));
    }

    private async Task<Category> UpsertCategoryAsync(string slug, string name, string description, string highlightImageUrl, string ctaText, bool isHighlighted, int displayOrder)
    {
        var category = await dbContext.Categories.FirstOrDefaultAsync(item => item.Slug == slug)
            ?? new Category { Slug = slug };

        category.Name = name;
        category.Description = description;
        category.HighlightImageUrl = highlightImageUrl;
        category.CallToActionText = ctaText;
        category.IsHighlightedOnHomePage = isHighlighted;
        category.DisplayOrder = displayOrder;

        if (category.Id == 0)
        {
            dbContext.Categories.Add(category);
        }

        await dbContext.SaveChangesAsync();
        return category;
    }

    private async Task UpsertHeroAsync()
    {
        var hero = await dbContext.SiteHeroes.OrderBy(item => item.Id).FirstOrDefaultAsync() ?? new SiteHero();
        hero.Eyebrow = "Miras ve Zanaat";
        hero.Title = "Zamansiz Zarafet Icin Uretildi";
        hero.PrimaryActionText = "Urunleri Incele";
        hero.SecondaryActionText = "Koleksiyonu Kesfet";
        hero.ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuByfA_tVunlbq9-xUfuygHrCJRzKApw_Ppsk1r1ONL-a4VlVErhGmXYqGpgtm9w-fPgSDyWCC_WdjmIa7u0kbLbw-sd9P0NxyGAT_EhxKwb1FTjXqUM6hcRpKCcnb0Zz2fc67CuWCvzFaRG6I8JZ97Mr4Vchb7iwYYjBFhwTCZKfYz8ioELlQDceCq9rvqOo2buUwIhUWFnhQ5nT_fXZ_mOnpdCanDw4nN5JnnBSgdeRztEM-KlufiGiDfx9XxF566nw9LSQt0NotAU";

        if (hero.Id == 0)
        {
            dbContext.SiteHeroes.Add(hero);
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task UpsertFeaturesAsync()
    {
        await UpsertFeatureAsync("El Isciligi", "front_hand", 1);
        await UpsertFeatureAsync("Premium Malzeme", "diamond", 2);
        await UpsertFeatureAsync("Dunya Capinda Teslimat", "public", 3);
    }

    private async Task UpsertFeatureAsync(string title, string iconName, int displayOrder)
    {
        var feature = await dbContext.StoreFeatures.FirstOrDefaultAsync(item => item.DisplayOrder == displayOrder)
            ?? new StoreFeature();

        feature.Title = title;
        feature.IconName = iconName;
        feature.DisplayOrder = displayOrder;

        if (feature.Id == 0)
        {
            dbContext.StoreFeatures.Add(feature);
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task UpsertBrandStoryAsync()
    {
        var story = await dbContext.BrandStories.OrderBy(item => item.Id).FirstOrDefaultAsync() ?? new BrandStory();
        story.Eyebrow = "Felsefemiz";
        story.Title = "Modern Mirasi Yeniden Tanimliyoruz";
        story.ParagraphOne = "FUWANS olarak gercek luksun sessiz detaylarda sakli olduguna inaniyoruz. Yolculugumuz, geleneksel deri isciligini bugunun yasamina yeniden kazandirma fikriyle basladi.";
        story.ParagraphTwo = "Her parca, ham malzeme ile usta zanaatkar arasindaki diyalogdan dogar. Derilerimizi etik Avrupa tabakhanelerinden seciyor, her kenari elde bitirerek urunlere karakter kazandiriyoruz.";
        story.ActionText = "Zanaat Yolculugumuzu Kesfet";
        story.ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBOOnnOIdBH8H6tmYl9le2TZq-wwXnv0ROrnR2MU0_5aiihrPUUDzqg9JzT19s9V39eRUBRvSa2li0SqRHGsjYvjrYENrck0lLQT5VD89BgwAYDzg45JHeMrc-Ir0D7YPkJRePrS1ZY2m2BLxuI8SJ7kqVr_DQIpI4MarCwVsgX60_J9VkFl7-y_UHbBHC2QVxtApqEAHrl4Nv3kvhlp5vGlB_VHZdGDPeLMeRJkc7ANLiLr9CwgaQvH6V9v5M6MvyTIwxeQocsE42H";

        if (story.Id == 0)
        {
            dbContext.BrandStories.Add(story);
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task UpsertProductAsync(ProductSeed seed)
    {
        var product = await dbContext.Products
            .Include(item => item.Images)
            .Include(item => item.Colors)
            .Include(item => item.Sizes)
            .FirstOrDefaultAsync(item => item.Slug == seed.Slug)
            ?? new Product { Slug = seed.Slug };

        product.CategoryId = seed.CategoryId;
        product.Name = seed.Name;
        product.CollectionLabel = seed.CollectionLabel;
        product.ShortDescription = seed.ShortDescription;
        product.Description = seed.Description;
        product.Price = seed.Price;
        product.SelectedColorName = seed.SelectedColorName;
        product.SizeGuideText = seed.SizeGuideText;
        product.DetailsText = seed.DetailsText;
        product.MaterialsText = seed.MaterialsText;
        product.ShippingReturnsText = seed.ShippingReturnsText;
        product.ListingBadge = seed.ListingBadge;
        product.CollectionNoteTitle = seed.CollectionNoteTitle;
        product.CollectionNoteText = seed.CollectionNoteText;
        product.IsWideFeature = seed.IsWideFeature;
        product.IsFeaturedOnHomePage = seed.IsFeaturedOnHomePage;
        product.DisplayOrder = seed.DisplayOrder;

        if (product.Id == 0)
        {
            dbContext.Products.Add(product);
        }

        await dbContext.SaveChangesAsync();

        dbContext.ProductImages.RemoveRange(product.Images);
        dbContext.ProductColors.RemoveRange(product.Colors);
        dbContext.ProductSizes.RemoveRange(product.Sizes);
        await dbContext.SaveChangesAsync();

        dbContext.ProductImages.AddRange(seed.Images.Select((image, index) => new ProductImage
        {
            ProductId = product.Id,
            ImageUrl = image.ImageUrl,
            IsPrimary = image.IsPrimary,
            DisplayOrder = index + 1
        }));

        dbContext.ProductColors.AddRange(seed.Colors.Select((color, index) => new ProductColor
        {
            ProductId = product.Id,
            Name = color.Name,
            HexCode = color.HexCode,
            DisplayOrder = index + 1
        }));

        dbContext.ProductSizes.AddRange(seed.Sizes.Select((size, index) => new ProductSize
        {
            ProductId = product.Id,
            Label = size.Label,
            IsSelectedByDefault = size.IsSelectedByDefault,
            DisplayOrder = index + 1
        }));

        await dbContext.SaveChangesAsync();
    }

    private sealed record ProductSeed(
        string Slug,
        int CategoryId,
        string Name,
        string CollectionLabel,
        string ShortDescription,
        string Description,
        decimal Price,
        string SelectedColorName,
        string SizeGuideText,
        string DetailsText,
        string MaterialsText,
        string ShippingReturnsText,
        string ListingBadge,
        string CollectionNoteTitle,
        string CollectionNoteText,
        bool IsWideFeature,
        bool IsFeaturedOnHomePage,
        int DisplayOrder,
        IReadOnlyList<ProductImageSeed> Images,
        IReadOnlyList<ProductColorSeed> Colors,
        IReadOnlyList<ProductSizeSeed> Sizes);

    private sealed record ProductImageSeed(string ImageUrl, bool IsPrimary);
    private sealed record ProductColorSeed(string Name, string HexCode);
    private sealed record ProductSizeSeed(string Label, bool IsSelectedByDefault);
}
