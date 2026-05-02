<section class="relative md:min-h-[calc(100svh-4.5em)] md:mt-[4.5em] mt-[63px] min-h-[calc(100svh-63px)] xxl:text-base desktopLg:text-sm laptopMd:text-xs md:text-[10px] text-sm flex items-stretch">
    <div class="w-full relative overflow-hidden flex items-center justify-center md:py-20 py-12 px-4">
        <div class="max-w-xl w-full relative z-20 flex justify-center">
            <div data-index="1" class="max-w-full hero-middle-content">
                <div class="flex flex-col items-center xl:gap-7 laptopMd:gap-5 gap-4">
                    <p class="big-text text-white/75 text-center">HERITAGE & CRAFT</p>
                    <h1 class="h1-title text-white text-center !leading-none">Crafted for Timeless Elegance</h1>
                    <div class="flex items-stretch max-w-full flex-wrap justify-center xl:gap-7 laptopMd:gap-5 gap-4">
                        <a href="/urunler" class="hero-premium-button big-text">SHOP NOW</a>
                        <a href="/urunler" class="hero-premium-button hero-premium-button--ghost big-text">SHOP NOW</a>
                    </div>
                </div>
            </div>
            <div data-index="2" class="max-w-full hero-middle-content hidden">
                <div class="flex flex-col items-center xl:gap-7 laptopMd:gap-5 gap-4">
                    <p class="big-text text-white/75 text-center">BULLET</p>
                    <h1 class="h1-title text-white text-center !leading-none">FUWANS the man</h1>
                    <div class="flex items-stretch max-w-full flex-wrap justify-center xl:gap-7 laptopMd:gap-5 gap-4">
                        <a href="/urunler" class="hero-premium-button big-text">SHOP NOW</a>
                        <a href="/urunler" class="hero-premium-button hero-premium-button--ghost big-text">DISCOVER COLLECTION</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="absolute inset-0 w-full h-full z-10 bg-gradient-to-b from-black/35 via-transparent to-black/35"></div>
        <div class="absolute inset-x-0 bottom-8 z-30 flex justify-center px-4">
            <div class="flex items-center gap-3">
                <button type="button" class="hero-slider-button hero-slider-prev" aria-label="Onceki hero gorseli">
                    <span></span>
                </button>
                <button type="button" class="hero-slider-button hero-slider-next" aria-label="Sonraki hero gorseli">
                    <span></span>
                </button>
            </div>
        </div>
        <div class="absolute inset-0 w-full h-full overflow-hidden z-0 hero-img-content">
            <!-- Burdaki data-index'i yüksek olan yukarda olmalı yani sıralama tam tersi olmalı -->
            <img src="{{ asset('assets/images/hero-img1.png') }}" data-index="1" class="absolute inset-0 w-full h-full object-cover hero-img-item" loading="eager" decoding="async" fetchpriority="high" alt="">
            <img src="{{ asset('assets/images/hero-img2.jpg') }}" data-index="2" class="absolute inset-0 w-full h-full object-cover hero-img-item" loading="lazy" decoding="async" alt="">
        </div>
    </div>
</section>
