<!doctype html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Sayfa Bulunamadi | Fuwans</title>
    @vite(['resources/css/app.css', 'resources/js/app.js'])
    <style>
        .error-404__ring {
            animation: ring-drift 12s ease-in-out infinite alternate;
        }

        .error-404__ring:nth-child(2) {
            animation-delay: -3s;
        }

        .error-404__number {
            animation: number-rise 900ms cubic-bezier(.16, 1, .3, 1) both;
        }

        .error-404__copy {
            animation: copy-rise 780ms cubic-bezier(.16, 1, .3, 1) 180ms both;
        }

        .error-404__button {
            animation: copy-rise 780ms cubic-bezier(.16, 1, .3, 1) 320ms both;
        }

        .error-404__shine {
            animation: shine-sweep 4.6s ease-in-out infinite;
        }

        @keyframes ring-drift {
            0% {
                transform: translate3d(-1.2rem, .6rem, 0) rotate(-3deg) scale(.98);
            }

            100% {
                transform: translate3d(1rem, -.8rem, 0) rotate(4deg) scale(1.03);
            }
        }

        @keyframes number-rise {
            0% {
                opacity: 0;
                transform: translateY(26px) scale(.96);
            }

            100% {
                opacity: 1;
                transform: translateY(0) scale(1);
            }
        }

        @keyframes copy-rise {
            0% {
                opacity: 0;
                transform: translateY(18px);
            }

            100% {
                opacity: 1;
                transform: translateY(0);
            }
        }

        @keyframes shine-sweep {
            0%, 28% {
                transform: translateX(-130%) rotate(18deg);
            }

            72%, 100% {
                transform: translateX(130%) rotate(18deg);
            }
        }
    </style>
</head>
<body class="bg-main text-secondary">
    <main class="relative grid min-h-screen overflow-hidden px-5 py-8">
        <div class="absolute inset-0 bg-[radial-gradient(circle_at_18%_18%,rgba(143,111,107,.18),transparent_30%),radial-gradient(circle_at_82%_78%,rgba(74,44,42,.14),transparent_34%)]"></div>
        <div class="absolute inset-x-8 top-8 h-px bg-secondary/15"></div>
        <div class="absolute inset-x-8 bottom-8 h-px bg-secondary/15"></div>
        <div class="absolute inset-y-8 left-8 w-px bg-secondary/15"></div>
        <div class="absolute inset-y-8 right-8 w-px bg-secondary/15"></div>

        <section class="relative z-10 mx-auto grid w-full max-w-[1120px] items-center gap-10 md:grid-cols-[1.05fr_.95fr]">
            <div class="error-404__copy max-w-2xl pt-8 md:pt-0">
                <a href="{{ url('/') }}" class="inline-flex h-[2.4em] items-center">
                    <img src="{{ asset('assets/images/logo.png') }}" class="h-full object-contain" decoding="async" alt="Fuwans">
                </a>

                <p class="mt-12 font-link text-xs font-medium uppercase tracking-[.28em] text-desc">404 / Sayfa kayip</p>
                <h1 class="mt-5 font-title text-[3.7rem] font-normal leading-[.9] tracking-[.01em] text-title md:text-[6.8rem]">
                    Bu adres koleksiyonda yok.
                </h1>
                <p class="mt-6 max-w-xl font-desc text-base leading-7 text-desc md:text-lg">
                    Aradigin sayfa tasinmis ya da kaldirilmis olabilir. Ana sayfaya donup Fuwans deneyimine kaldigin yerden devam edebilirsin.
                </p>

                <div class="error-404__button mt-9 flex flex-wrap items-center gap-4">
                    <a href="{{ url('/') }}" class="animated inline-flex min-h-12 items-center justify-center bg-secondary px-7 py-3 font-link text-sm font-medium tracking-[.08em] text-main hover:bg-brass hover:text-white">
                        Ana Sayfaya Don
                    </a>
                    <a href="{{ url('/urunler') }}" class="under-anim font-link text-sm font-medium tracking-[.08em] text-secondary">
                        Urunleri Incele
                    </a>
                </div>
            </div>

            <div class="relative mx-auto grid aspect-square w-full max-w-[28rem] place-items-center md:max-w-[34rem]">
                <div class="error-404__ring absolute inset-[3%] rounded-xxl border border-secondary/15"></div>
                <div class="error-404__ring absolute inset-[13%] rounded-xxl border border-secondary/20"></div>
                <div class="absolute inset-[24%] overflow-hidden rounded-xxl bg-secondary shadow-[0_28px_90px_rgba(50,23,22,.22)]">
                    <div class="error-404__shine absolute inset-y-[-20%] left-0 w-1/3 bg-main/20 blur-sm"></div>
                </div>
                <div class="absolute inset-0 grid place-items-center">
                    <span class="error-404__number font-title text-[7rem] font-normal leading-none tracking-[.02em] text-main md:text-[10rem]">404</span>
                </div>
            </div>
        </section>
    </main>
</body>
</html>
