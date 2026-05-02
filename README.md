# Fuwans

Laravel + FilamentPHP hedefiyle Blade frontend yapisi hazirlandi.

## Yapi

- `resources/views/layouts/app.blade.php`: Ana layout
- `resources/views/pages/home.blade.php`: Default acilan ana sayfa
- `resources/views/partials`: Site geneli header ve footer
- `resources/views/partials/home`: Home sayfasina ait partial bloklar
- `resources/css/app.css`: Tailwind katmanlari ve ortak component class'lari
- `resources/js/app.js`: jQuery, Swiper, Fancybox ve GSAP baslatmalari

## Kurulum

Bagimliliklar kurulduktan sonra iki terminal ac:

```bash
php artisan serve
```

```bash
npm run dev
```

Siteyi Vite adresinden degil, `php artisan serve` komutunun verdigi Laravel adresinden ac.

Backend tarafi daha sonra FilamentPHP ve PostgreSQL ile genisletilecek.
