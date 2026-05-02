<section class="w-full bg-[#FCF9F8] px-4 md:py-20 py-12 flex justify-center">
    <div class="max-w-xl w-full flex flex-col xl:gap-14 laptopMd:gap-10 gap-8">
        <div class="w-full md:flex-row flex-col flex justify-between md:items-end items-start gap-6">
            <div class="md:w-[30%] w-full flex flex-col items-start xl:gap-8 md:gap-6 gap-5">
                <h2 class="h2-title text-secondary">The Essentials</h2>
                <div class="w-full regular-text text-secondary">
                    <p>Our most coveted pieces, designed for the modern
                        connoisseur of fine leather goods.</p>
                </div>
            </div>
            <a href="/urunler" class="regular-text uppercase text-center md:self-auto text-secondary self-center under-anim md:tracking-wider tracking-wide">VIEW ALL</a>
        </div>
        <div class="w-full grid grid-cols-5 xl:gap-10 md:gap-8 gap-6">
            <!-- Öne çıkan büyük gösterilmek istenen ürün bu şekilde olucak -->
             <div class="col-span-3 flex flex-col xl:gap-10 md:gap-8 gap-6">
                <article class="w-full">
                    <a href="/urun-detay" class="w-full flex flex-col xl:gap-6 md:gap-5 gap-4 group">
                        <div class="w-full bg-white aspect-square relative overflow-hidden">
                            <img src="{{ asset('assets/images/hero-img2.jpg') }}" class="absolute inset-0 w-full h-full object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                        <div class="w-full flex flex-col xl:gap-4 md:gap-3.5 gap-2.5">
                            <div class="w-full flex items-center justify-between gap-4">
                                <h5 class="h5-title text-secondaryTitle">The Heritage Tote</h5>
                                <p class="big-text text-[#504443] font-title font-medium">$1,250</p>
                            </div>
                            <p class="text-[#504443] small-text !leading-none">FULL-GRAIN ITALIAN LEATHER</p>
                        </div>
                    </a>
                </article>
             </div>
             <!-- Küçük ürünler  -->
            <div class="xl:gap-10 md:gap-8 gap-6 flex flex-col col-span-2">
                <article class="w-full"> 
                    <a href="/urun-detay" class="w-full flex flex-col xl:gap-6 md:gap-5 gap-4 group">
                        <div class="w-full bg-white aspect-square relative overflow-hidden">
                            <img src="{{ asset('assets/images/hero-img2.jpg') }}" class="absolute inset-0 w-full h-full object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                        <div class="w-full flex flex-col xl:gap-4 md:gap-3.5 gap-2.5">
                            <div class="w-full flex items-center justify-between gap-4">
                                <h5 class="h5-title text-secondaryTitle">The Heritage Tote</h5>
                                <p class="big-text text-[#504443] font-title font-medium">$1,250</p>
                            </div>
                            <p class="text-[#504443] small-text !leading-none">FULL-GRAIN ITALIAN LEATHER</p>
                        </div>
                    </a>
                </article>
                <article class="w-full"> 
                    <a href="/urun-detay" class="w-full flex flex-col xl:gap-6 md:gap-5 gap-4 group">
                        <div class="w-full bg-white aspect-square relative overflow-hidden">
                            <img src="{{ asset('assets/images/hero-img2.jpg') }}" class="absolute inset-0 w-full h-full object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                        <div class="w-full flex flex-col xl:gap-4 md:gap-3.5 gap-2.5">
                            <div class="w-full flex items-center justify-between gap-4">
                                <h5 class="h5-title text-secondaryTitle">The Heritage Tote</h5>
                                <p class="big-text text-[#504443] font-title font-medium">$1,250</p>
                            </div>
                            <p class="text-[#504443] small-text !leading-none">FULL-GRAIN ITALIAN LEATHER</p>
                        </div>
                    </a>
                </article>
            </div>
            <!-- 4lü ürün listesi için( Öne çıkan büyük ürün )  -->
            <!-- <article class="w-full"> 
                    <a href="/urun-detay" class="w-full flex flex-col xl:gap-6 md:gap-5 gap-4 group">
                        <div class="w-full bg-white aspect-square relative overflow-hidden">
                            <img src="{{ asset('assets/images/hero-img2.jpg') }}" class="absolute inset-0 w-full h-full object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                        <div class="w-full flex flex-col xl:gap-4 md:gap-3.5 gap-2.5">
                            <div class="w-full flex items-center justify-between gap-4">
                                <h5 class="h5-title text-secondaryTitle">The Heritage Tote</h5>
                                <p class="big-text text-[#504443] font-title font-medium">$1,250</p>
                            </div>
                            <p class="text-[#504443] small-text !leading-none">FULL-GRAIN ITALIAN LEATHER</p>
                        </div>
                    </a>
            </article> -->
        </div>
    </div>
</section>