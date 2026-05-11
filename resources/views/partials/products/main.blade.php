<section class="w-full md:pb-20 pb-12 px-4 flex flex-col items-center xxl:gap-16 laptopMd:gap-12 gap-10 justify-center relative z-[15]">
    <div class="w-full max-w-xl flex flex-col xxl:gap-16 laptopMd:gap-12 gap-10 border-b border-[#E5E2E1] xxl:pb-10 md:pb-6 pb-4 relative z-20">
        <div class="w-full grid grid-cols-1 xxl:px-16 laptopMd:px-11 md:px-6 px-4">
            <form action="">
                <div class="flex justify-between md:flex-row flex-col xxl:gap-10 laptopMd:gap-8 gap-6 w-full">
                    <div class="flex flex-wrap xxl:gap-8 md:gap-6 gap-4 md:max-w-[70%] max-xs:flex-col max-xs:justify-center">
                        <div class="filter-dropdown relative max-xs:flex max-xs:justify-center">
                            <button type="button" class="filter-dropdown-button flex items-center md:gap-2.5 gap-2" aria-expanded="false">
                                <p class="text-secondary small-text uppercase tracking-wider font-semibold animated">
                                    CATEGORY
                                </p>
                                <svg xmlns="http://www.w3.org/2000/svg" class="filter-dropdown-icon w-2 animated" viewBox="0 0 8 5" fill="none">
                                    <path class="fill-secondary" d="M3.98077 4.51154L0 0.530772L0.530772 0L3.98077 3.45L7.43077 0L7.96154 0.530772L3.98077 4.51154V4.51154" fill="#1B1B1C"/>
                                </svg>
                            </button>
                            <div class="filter-dropdown-panel absolute left-1/2 top-[calc(100%+16px)] z-40 hidden w-[min(82vw,260px)] -translate-x-1/2" aria-hidden="true">
                                <div class="filter-dropdown-arrow absolute -top-2 left-1/2 size-4 -translate-x-1/2 rotate-45 border-l border-t border-secondary/10 bg-main"></div>
                                <div class="filter-dropdown-content relative max-h-[clamp(150px,35svh,300px)] overflow-y-auto rounded-[6px] border border-secondary/10 bg-main px-2.5 py-3 shadow-[0_18px_45px_rgba(27,27,28,0.14)]">
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">All Products</span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="category[]" value="all" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">New Arrivals</span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="category[]" value="new-arrivals" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Best Sellers</span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="category[]" value="best-sellers" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Limited Edition</span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="category[]" value="limited-edition" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="filter-dropdown relative max-xs:flex max-xs:justify-center">
                            <button type="button" class="filter-dropdown-button flex items-center md:gap-2.5 gap-2" aria-expanded="false">
                                <p class="text-secondary small-text uppercase tracking-wider font-semibold animated">
                                    PRICE RANGE
                                </p>
                                <svg xmlns="http://www.w3.org/2000/svg" class="filter-dropdown-icon w-2 animated" viewBox="0 0 8 5" fill="none">
                                    <path class="fill-secondary" d="M3.98077 4.51154L0 0.530772L0.530772 0L3.98077 3.45L7.43077 0L7.96154 0.530772L3.98077 4.51154V4.51154" fill="#1B1B1C"/>
                                </svg>
                            </button>
                            <div class="filter-dropdown-panel absolute left-1/2 top-[calc(100%+16px)] z-40 hidden w-[min(82vw,280px)] -translate-x-1/2" aria-hidden="true">
                                <div class="filter-dropdown-arrow absolute -top-2 left-1/2 size-4 -translate-x-1/2 rotate-45 border-l border-t border-secondary/10 bg-main"></div>
                                <div class="filter-dropdown-content relative max-h-[clamp(150px,35svh,300px)] overflow-y-auto rounded-[6px] border border-secondary/10 bg-main px-2.5 py-3 shadow-[0_18px_45px_rgba(27,27,28,0.14)]">
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">$0 - $50</span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="price_range[]" value="0-50" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">$50 - $100</span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="price_range[]" value="50-100" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">$100 - $200</span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="price_range[]" value="100-200" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">$200+</span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="price_range[]" value="200-plus" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="filter-dropdown relative max-xs:flex max-xs:justify-center">
                            <button type="button" class="filter-dropdown-button flex items-center md:gap-2.5 gap-2" aria-expanded="false">
                                <p class="text-secondary small-text uppercase tracking-wider font-semibold animated">
                                    COLOR PALETTE
                                </p>
                                <svg xmlns="http://www.w3.org/2000/svg" class="filter-dropdown-icon w-2 animated" viewBox="0 0 8 5" fill="none">
                                    <path class="fill-secondary" d="M3.98077 4.51154L0 0.530772L0.530772 0L3.98077 3.45L7.43077 0L7.96154 0.530772L3.98077 4.51154V4.51154" fill="#1B1B1C"/>
                                </svg>
                            </button>
                            <div class="filter-dropdown-panel absolute left-1/2 top-[calc(100%+16px)] z-40 hidden w-[min(82vw,280px)] -translate-x-1/2" aria-hidden="true">
                                <div class="filter-dropdown-arrow absolute -top-2 left-1/2 size-4 -translate-x-1/2 rotate-45 border-l border-t border-secondary/10 bg-main"></div>
                                <div class="filter-dropdown-content relative max-h-[clamp(150px,35svh,300px)] overflow-y-auto rounded-[6px] border border-secondary/10 bg-main px-2.5 py-3 shadow-[0_18px_45px_rgba(27,27,28,0.14)]">
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="flex items-center gap-3">
                                            <span class="size-4 rounded-full border border-secondary/10 bg-[#F5F5F0] shadow-[inset_0_0_0_1px_rgba(255,255,255,0.75)]"></span>
                                            <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Cream</span>
                                        </span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="color[]" value="cream" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="flex items-center gap-3">
                                            <span class="size-4 rounded-full border border-secondary/10 bg-[#4A2C2A] shadow-[inset_0_1px_0_rgba(255,255,255,0.18)]"></span>
                                            <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Brown</span>
                                        </span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="color[]" value="brown" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="flex items-center gap-3">
                                            <span class="size-4 rounded-full border border-secondary/10 bg-[#B38A58] shadow-[inset_0_1px_0_rgba(255,255,255,0.24)]"></span>
                                            <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Brass</span>
                                        </span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="color[]" value="brass" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                    <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                        <span class="flex items-center gap-3">
                                            <span class="size-4 rounded-full border border-secondary/10 bg-[#1B1B1C] shadow-[inset_0_1px_0_rgba(255,255,255,0.2)]"></span>
                                            <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Black</span>
                                        </span>
                                        <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                            <input type="checkbox" name="color[]" value="black" class="peer absolute inset-0 cursor-pointer opacity-0">
                                            <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                            <svg xmlns="http://www.w3.org/2000/svg" class="relative z-10 w-[9px] scale-75 opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100" viewBox="0 0 10 8" fill="none">
                                                <path d="M1 4L3.35 6.25L9 1" stroke="#F5F5F0" stroke-width="1.55" stroke-linecap="round" stroke-linejoin="round"/>
                                            </svg>
                                        </span>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="flex items-center xxl:gap-6 gap-4">
                        <div class="flex items-center gap-2.5">
                            <p class="text-secondary/75 small-text uppercase tracking-wider font-semibold">
                                SORT:
                            </p>
                            <div class="filter-dropdown relative">
                                <button type="button" class="filter-dropdown-button flex min-w-[150px] items-center justify-between gap-5" aria-expanded="false">
                                    <span class="text-secondary small-text uppercase tracking-wider font-semibold">
                                        NEWEST
                                    </span>
                                    <svg xmlns="http://www.w3.org/2000/svg" class="filter-dropdown-icon w-2 animated" viewBox="0 0 8 5" fill="none">
                                        <path class="fill-secondary" d="M3.98077 4.51154L0 0.530772L0.530772 0L3.98077 3.45L7.43077 0L7.96154 0.530772L3.98077 4.51154V4.51154" fill="#1B1B1C"/>
                                    </svg>
                                </button>
                                <div class="filter-dropdown-panel absolute left-1/2 top-[calc(100%+16px)] z-40 hidden w-[min(82vw,240px)] -translate-x-1/2" aria-hidden="true">
                                    <div class="filter-dropdown-arrow absolute -top-2 left-1/2 size-4 -translate-x-1/2 rotate-45 border-l border-t border-secondary/10 bg-main"></div>
                                    <div class="filter-dropdown-content relative max-h-[clamp(150px,35svh,300px)] overflow-y-auto rounded-[6px] border border-secondary/10 bg-main px-2.5 py-3 shadow-[0_18px_45px_rgba(27,27,28,0.14)]">
                                        <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                            <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Newest</span>
                                            <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                                <input type="radio" name="sort" value="newest" checked class="peer absolute inset-0 cursor-pointer opacity-0">
                                                <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                                <span class="relative z-10 size-1.5 scale-75 rounded-full bg-main opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100"></span>
                                            </span>
                                        </label>
                                        <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                            <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Price Low</span>
                                            <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                                <input type="radio" name="sort" value="price-low" class="peer absolute inset-0 cursor-pointer opacity-0">
                                                <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                                <span class="relative z-10 size-1.5 scale-75 rounded-full bg-main opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100"></span>
                                            </span>
                                        </label>
                                        <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                            <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Price High</span>
                                            <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                                <input type="radio" name="sort" value="price-high" class="peer absolute inset-0 cursor-pointer opacity-0">
                                                <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                                <span class="relative z-10 size-1.5 scale-75 rounded-full bg-main opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100"></span>
                                            </span>
                                        </label>
                                        <label class="group flex cursor-pointer items-center justify-between gap-4 rounded-[4px] px-3 py-2.5 animated hover:bg-secondary/5">
                                            <span class="small-text font-medium uppercase tracking-wider text-secondary/80 animated group-hover:text-secondary">Best Sellers</span>
                                            <span class="relative grid size-[18px] shrink-0 place-items-center rounded-full border border-secondary/20 bg-white shadow-[0_3px_10px_rgba(27,27,28,0.08),inset_0_1px_0_rgba(255,255,255,0.9)] animated group-hover:border-brass/70 group-hover:shadow-[0_5px_16px_rgba(179,138,88,0.14),inset_0_1px_0_rgba(255,255,255,0.9)]">
                                                <input type="radio" name="sort" value="best-sellers" class="peer absolute inset-0 cursor-pointer opacity-0">
                                                <span class="absolute inset-0 rounded-full bg-secondary opacity-0 shadow-[0_4px_12px_rgba(74,44,42,0.22),inset_0_1px_0_rgba(255,255,255,0.16)] animated peer-checked:opacity-100"></span>
                                                <span class="relative z-10 size-1.5 scale-75 rounded-full bg-main opacity-0 animated peer-checked:scale-100 peer-checked:opacity-100"></span>
                                            </span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="md:flex hidden items-center xxl:gap-3 gap-2.5">
                            <button class="group active-grid grid-btn" data-grid="4" type="button">
                                <svg class="w-4 animated" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="none">
                                    <path class="animated fill-secondary/40 group-hover:fill-secondary" d="M0 7.00001V0H7.00001V7.00001H0V7.00001M0 16V9.00001H7.00001V16H0V16M9.00001 7.00001V0H16V7.00001H9.00001V7.00001M9.00001 16V9.00001H16V16H9.00001V16M1.00001 6H6V1.00001H1.00001V6V6M10 6H15V1.00001H10V6V6M10 15H15V10H10V15V15M1.00001 15H6V10H1.00001V15V15M10 6V6V6V6V6V6M10 10V10V10V10V10V10M6 10V10V10V10V10V10M6 6V6V6V6V6V6" fill="#321716"/>
                                </svg>
                            </button>
                            <button class="group grid-btn" data-grid="6" type="button">
                                <svg class="w-4 animated" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 12" fill="none">
                                    <path class="animated fill-secondary/40 group-hover:fill-secondary" d="M10.9635 5.5H14.9423V5.5V5.5V1.61539C14.9423 1.4359 14.8846 1.28847 14.7692 1.17308C14.6539 1.0577 14.5064 1.00001 14.3269 1.00001H10.9635V1.00001V1.00001V5.5V5.5V5.5V5.5M5.97885 5.5H9.9577V5.5V5.5V1.00001V1.00001V1.00001H5.97885V1.00001V1.00001V5.5V5.5V5.5V5.5M1.00001 5.5H4.97885V5.5V5.5V1.00001V1.00001V1.00001H1.61539C1.4359 1.00001 1.28847 1.0577 1.17308 1.17308C1.0577 1.28847 1.00001 1.4359 1.00001 1.61539V5.5V5.5V5.5V5.5M1.61539 11H4.97885V11V11V6.50001V6.50001V6.50001H1.00001V6.50001V6.50001V10.3846C1.00001 10.5641 1.0577 10.7115 1.17308 10.8269C1.28847 10.9423 1.4359 11 1.61539 11V11M5.97885 11H9.9577V11V11V6.50001V6.50001V6.50001H5.97885V6.50001V6.50001V11V11V11V11M10.9635 11H14.3269C14.5064 11 14.6539 10.9423 14.7692 10.8269C14.8846 10.7115 14.9423 10.5641 14.9423 10.3846V6.50001V6.50001V6.50001H10.9635V6.50001V6.50001V11V11V11V11M0 10.3846V1.61539C0 1.17116 0.158173 0.790867 0.47452 0.474521C0.790867 0.158174 1.17116 0 1.61539 0H14.3269C14.7712 0 15.1515 0.158174 15.4678 0.474521C15.7841 0.790867 15.9423 1.17116 15.9423 1.61539V10.3846C15.9423 10.8289 15.7841 11.2091 15.4678 11.5255C15.1515 11.8418 14.7712 12 14.3269 12H1.61539C1.17116 12 0.790867 11.8418 0.47452 11.5255C0.158173 11.2091 0 10.8289 0 10.3846V10.3846" fill="#685D4C"/>
                                </svg>
                            </button>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <div class="max-w-xl w-full relative z-10">
        <div class="w-full grid laptopMd:grid-cols-4 xs:grid-cols-2 xxl:gap-10 md:gap-8 gap-6 grid-area" data-grid="4">
            <article>
                <a href="/urun-detay" class="w-full flex flex-col group product-item relative">               
                    <div class="w-full bg-secondary/5 aspect-[304/405] z-10 relative overflow-hidden md:p-2 p-1.5">
                        <div class="relative z-10 group-hover:bg-secondary bg-transparent animated py-1 md:px-2.5 px-2 w-max max-w-full">
                            <p class="small-text uppercase -tracking-tight group-hover:text-white animated text-secondary font-medium">NEW ARRIVAL</p>
                        </div>
                        <div class="absolute inset-0 w-full h-full overflow-hidden">
                            <!-- Sayfa yüklendiğinde default ilk rengin görseli buraya yüklenicek -->
                            <img src="{{ asset('assets/images/Linen Shirt.png') }}" class="product-item-image w-full h-full absolute inset-0 object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                    </div>
                    <div class="flex flex-col gap-2">
                        <p class="big-text text-secondary font-medium">Signature Bone Linen Overshirt</p>
                        <h5 class="h5-title text-[#685D4C] font-desc">$340</h5>
                        <div class="flex flex-wrap gap-1.5 items-center">
                            <!-- İlk color'da sayfa yüklendiğinde aktif classı olucak (active-color) -->
                            <button type="button" data-img="{{ asset('assets/images/Linen Shirt.png') }}" class="group product-item-color-btn active-color">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: green;"></div>
                            </button>
                             <button type="button" data-img="{{ asset('assets/images/Margin.png') }}" class="group product-item-color-btn">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: red;"></div>
                            </button>
                        </div>
                    </div>
                </a>
            </article>
            <article>
                <a href="/urun-detay" class="w-full flex flex-col group product-item relative">               
                    <div class="w-full bg-secondary/5 aspect-[304/405] z-10 relative overflow-hidden md:p-2 p-1.5">
                        <div class="relative z-10 group-hover:bg-secondary bg-transparent animated py-1 md:px-2.5 px-2 w-max max-w-full">
                            <p class="small-text uppercase -tracking-tight group-hover:text-white animated text-secondary font-medium">NEW ARRIVAL</p>
                        </div>
                        <div class="absolute inset-0 w-full h-full overflow-hidden">
                            <!-- Sayfa yüklendiğinde default ilk rengin görseli buraya yüklenicek -->
                            <img src="{{ asset('assets/images/Linen Shirt.png') }}" class="product-item-image w-full h-full absolute inset-0 object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                    </div>
                    <div class="flex flex-col gap-2">
                        <p class="big-text text-secondary font-medium">Signature Bone Linen Overshirt</p>
                        <h5 class="h5-title text-[#685D4C] font-desc">$340</h5>
                        <div class="flex flex-wrap gap-1.5 items-center">
                            <!-- İlk color'da sayfa yüklendiğinde aktif classı olucak (active-color) -->
                            <button type="button" data-img="{{ asset('assets/images/Linen Shirt.png') }}" class="group product-item-color-btn active-color">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: green;"></div>
                            </button>
                             <button type="button" data-img="{{ asset('assets/images/Margin.png') }}" class="group product-item-color-btn">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: red;"></div>
                            </button>
                        </div>
                    </div>
                </a>
            </article>
            <!-- Büyük gösterilmek istenen ürünler alttaki article gibi olucaktır -->
            <article class="xs:col-span-2 product-grid-featured">
                <a href="/urun-detay" class="w-full flex flex-col group product-item relative">               
                    <div class="w-full bg-secondary/5 xs:aspect-[700/439.63] aspect-[304/405] z-10 relative overflow-hidden md:p-2 p-1.5">
                        <div class="relative z-10 group-hover:bg-secondary bg-transparent animated py-1 md:px-2.5 px-2 w-max max-w-full">
                            <p class="small-text uppercase -tracking-tight group-hover:text-white animated text-secondary font-medium">NEW ARRIVAL</p>
                        </div>
                        <div class="absolute inset-0 w-full h-full overflow-hidden">
                            <!-- Sayfa yüklendiğinde default ilk rengin görseli buraya yüklenicek -->
                            <img src="{{ asset('assets/images/Linen Shirt.png') }}" class="product-item-image w-full h-full absolute inset-0 object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                    </div>
                    <div class="flex flex-col gap-2">
                        <p class="big-text text-secondary font-medium">Signature Bone Linen Overshirt</p>
                        <h5 class="h5-title text-[#685D4C] font-desc">$340</h5>
                        <div class="flex flex-wrap gap-1.5 items-center">
                            <!-- İlk color'da sayfa yüklendiğinde aktif classı olucak (active-color) -->
                            <button type="button" data-img="{{ asset('assets/images/Linen Shirt.png') }}" class="group product-item-color-btn active-color">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: green;"></div>
                            </button>
                             <button type="button" data-img="{{ asset('assets/images/Margin.png') }}" class="group product-item-color-btn">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: red;"></div>
                            </button>
                        </div>
                    </div>
                </a>
            </article>
            <article class="xs:col-span-2 product-grid-featured">
                <a href="/urun-detay" class="w-full flex flex-col group product-item relative">               
                    <div class="w-full bg-secondary/5 xs:aspect-[700/439.63] aspect-[304/405] z-10 relative overflow-hidden md:p-2 p-1.5">
                        <div class="relative z-10 group-hover:bg-secondary bg-transparent animated py-1 md:px-2.5 px-2 w-max max-w-full">
                            <p class="small-text uppercase -tracking-tight group-hover:text-white animated text-secondary font-medium">NEW ARRIVAL</p>
                        </div>
                        <div class="absolute inset-0 w-full h-full overflow-hidden">
                            <!-- Sayfa yüklendiğinde default ilk rengin görseli buraya yüklenicek -->
                            <img src="{{ asset('assets/images/Linen Shirt.png') }}" class="product-item-image w-full h-full absolute inset-0 object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                    </div>
                    <div class="flex flex-col gap-2">
                        <p class="big-text text-secondary font-medium">Signature Bone Linen Overshirt</p>
                        <h5 class="h5-title text-[#685D4C] font-desc">$340</h5>
                        <div class="flex flex-wrap gap-1.5 items-center">
                            <!-- İlk color'da sayfa yüklendiğinde aktif classı olucak (active-color) -->
                            <button type="button" data-img="{{ asset('assets/images/Linen Shirt.png') }}" class="group product-item-color-btn active-color">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: green;"></div>
                            </button>
                             <button type="button" data-img="{{ asset('assets/images/Margin.png') }}" class="group product-item-color-btn">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: red;"></div>
                            </button>
                        </div>
                    </div>
                </a>
            </article>
            <article>
                <a href="/urun-detay" class="w-full flex flex-col group product-item relative">               
                    <div class="w-full bg-secondary/5 aspect-[304/405] z-10 relative overflow-hidden md:p-2 p-1.5">
                        <div class="relative z-10 group-hover:bg-secondary bg-transparent animated py-1 md:px-2.5 px-2 w-max max-w-full">
                            <p class="small-text uppercase -tracking-tight group-hover:text-white animated text-secondary font-medium">NEW ARRIVAL</p>
                        </div>
                        <div class="absolute inset-0 w-full h-full overflow-hidden">
                            <!-- Sayfa yüklendiğinde default ilk rengin görseli buraya yüklenicek -->
                            <img src="{{ asset('assets/images/Linen Shirt.png') }}" class="product-item-image w-full h-full absolute inset-0 object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                    </div>
                    <div class="flex flex-col gap-2">
                        <p class="big-text text-secondary font-medium">Signature Bone Linen Overshirt</p>
                        <h5 class="h5-title text-[#685D4C] font-desc">$340</h5>
                        <div class="flex flex-wrap gap-1.5 items-center">
                            <!-- İlk color'da sayfa yüklendiğinde aktif classı olucak (active-color) -->
                            <button type="button" data-img="{{ asset('assets/images/Linen Shirt.png') }}" class="group product-item-color-btn active-color">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: green;"></div>
                            </button>
                             <button type="button" data-img="{{ asset('assets/images/Margin.png') }}" class="group product-item-color-btn">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: red;"></div>
                            </button>
                        </div>
                    </div>
                </a>
            </article>
            <article>
                <a href="/urun-detay" class="w-full flex flex-col group product-item relative">               
                    <div class="w-full bg-secondary/5 aspect-[304/405] z-10 relative overflow-hidden md:p-2 p-1.5">
                        <div class="relative z-10 group-hover:bg-secondary bg-transparent animated py-1 md:px-2.5 px-2 w-max max-w-full">
                            <p class="small-text uppercase -tracking-tight group-hover:text-white animated text-secondary font-medium">NEW ARRIVAL</p>
                        </div>
                        <div class="absolute inset-0 w-full h-full overflow-hidden">
                            <!-- Sayfa yüklendiğinde default ilk rengin görseli buraya yüklenicek -->
                            <img src="{{ asset('assets/images/Linen Shirt.png') }}" class="product-item-image w-full h-full absolute inset-0 object-cover animated group-hover:scale-105" loading="lazy" decoding="async" alt="">
                        </div>
                    </div>
                    <div class="flex flex-col gap-2">
                        <p class="big-text text-secondary font-medium">Signature Bone Linen Overshirt</p>
                        <h5 class="h5-title text-[#685D4C] font-desc">$340</h5>
                        <div class="flex flex-wrap gap-1.5 items-center">
                            <!-- İlk color'da sayfa yüklendiğinde aktif classı olucak (active-color) -->
                            <button type="button" data-img="{{ asset('assets/images/Linen Shirt.png') }}" class="group product-item-color-btn active-color">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: green;"></div>
                            </button>
                             <button type="button" data-img="{{ asset('assets/images/Margin.png') }}" class="group product-item-color-btn">
                                <div class="md:w-4 w-3 aspect-square rounded-xxl border border-[#D4C3C1] animated" style="background-color: red;"></div>
                            </button>
                        </div>
                    </div>
                </a>
            </article>
        </div>
    </div>
</section>
