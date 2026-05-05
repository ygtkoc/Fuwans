import $ from "jquery";
import Swiper from "swiper";
import { Navigation, Pagination, Autoplay } from "swiper/modules";
import { Fancybox } from "@fancyapps/ui";
import gsap from "gsap";
import Lenis from "lenis";

window.$ = window.jQuery = $;

Swiper.use([Navigation, Pagination, Autoplay]);

const lenis = new Lenis({
    duration: 1.05,
    smoothWheel: true,
});

let pageScrollLockCount = 0;
let pageScrollPosition = 0;
const fancyboxScrollLockKey = Symbol("fancyboxScrollLock");

function lockPageScroll() {
    pageScrollLockCount += 1;

    if (pageScrollLockCount > 1) {
        return;
    }

    pageScrollPosition =
        window.scrollY || document.documentElement.scrollTop || 0;
    lenis.stop();

    document.documentElement.classList.add("overflow-hidden");
    document.body.classList.add("overflow-hidden");
    document.body.style.position = "fixed";
    document.body.style.top = `-${pageScrollPosition}px`;
    document.body.style.left = "0";
    document.body.style.width = "100%";
}

function unlockPageScroll() {
    if (pageScrollLockCount <= 0) {
        return;
    }

    pageScrollLockCount -= 1;

    if (pageScrollLockCount > 0) {
        return;
    }

    document.documentElement.classList.remove("overflow-hidden");
    document.body.classList.remove("overflow-hidden");
    document.body.style.position = "";
    document.body.style.top = "";
    document.body.style.left = "";
    document.body.style.width = "";
    window.scrollTo(0, pageScrollPosition);
    lenis.start();
}

window.lockPageScroll = lockPageScroll;
window.unlockPageScroll = unlockPageScroll;

Fancybox.bind("[data-fancybox]", {
    dragToClose: true,
    animated: true,
    on: {
        init: (fancybox) => {
            if (fancybox[fancyboxScrollLockKey]) {
                return;
            }

            fancybox[fancyboxScrollLockKey] = true;
            lockPageScroll();
        },
        close: (fancybox) => {
            if (!fancybox[fancyboxScrollLockKey]) {
                return;
            }

            fancybox[fancyboxScrollLockKey] = false;
            unlockPageScroll();
        },
        destroy: (fancybox) => {
            if (!fancybox[fancyboxScrollLockKey]) {
                return;
            }

            fancybox[fancyboxScrollLockKey] = false;
            unlockPageScroll();
        },
    },
});

function raf(time) {
    lenis.raf(time);
    requestAnimationFrame(raf);
}

requestAnimationFrame(raf);

function initScrollControl() {
    const control = document.querySelector(".site-scroll-control");
    if (!control) {
        return;
    }

    let lastScrollY = window.scrollY;
    let direction = "down";
    let hideTimer = null;

    function getScrollLimit() {
        return Math.max(
            document.documentElement.scrollHeight - window.innerHeight,
            0,
        );
    }

    function setDirection(nextDirection) {
        direction = nextDirection;
        control.classList.toggle("is-up", direction === "up");
        control.setAttribute(
            "aria-label",
            direction === "up" ? "Sayfanin basina git" : "Sayfanin sonuna git",
        );
    }

    function scheduleHide() {
        clearTimeout(hideTimer);
        hideTimer = setTimeout(() => {
            control.classList.remove("is-visible");
        }, 950);
    }

    function updateControl() {
        const scrollY = window.scrollY;
        const limit = getScrollLimit();
        const progress = limit ? Math.min(Math.max(scrollY / limit, 0), 1) : 0;

        control.style.setProperty("--scroll-progress", progress.toFixed(4));

        if (limit <= 0) {
            control.classList.remove("is-visible");
            return;
        }

        if (progress <= 0.001) {
            setDirection("down");
        } else if (progress >= 0.999) {
            setDirection("up");
        } else if (scrollY > lastScrollY) {
            setDirection("down");
        } else if (scrollY < lastScrollY) {
            setDirection("up");
        }

        lastScrollY = scrollY;
        control.classList.add("is-visible");
        scheduleHide();
    }

    control.addEventListener("click", () => {
        const target = direction === "up" ? 0 : getScrollLimit();
        control.classList.add("is-visible");
        lenis.scrollTo(target, { duration: 1.15 });
        scheduleHide();
    });

    lenis.on("scroll", updateControl);
    window.addEventListener("resize", updateControl);
    window.addEventListener("load", updateControl);
    updateControl();
    control.classList.remove("is-visible");
}

function initUnderlineAnimations() {
    const links = document.querySelectorAll(".under-anim");
    if (!links.length) {
        return;
    }

    links.forEach((link) => {
        let line = link.querySelector(".under-anim__line");

        if (!line) {
            line = document.createElement("span");
            line.className = "under-anim__line";
            line.setAttribute("aria-hidden", "true");
            link.appendChild(line);
        }

        gsap.set(line, { left: "0%", right: "100%" });

        const showLine = () => {
            gsap.killTweensOf(line);
            gsap.to(line, {
                left: "0%",
                right: "0%",
                duration: 0.42,
                ease: "power2.inOut",
            });
        };

        const hideLine = () => {
            gsap.killTweensOf(line);
            gsap.to(line, {
                left: "100%",
                right: "0%",
                duration: 0.36,
                ease: "power2.inOut",
                onComplete: () => {
                    gsap.set(line, { left: "0%", right: "100%" });
                },
            });
        };

        link.addEventListener("mouseenter", showLine);
        link.addEventListener("mouseleave", hideLine);
        link.addEventListener("focusin", showLine);
        link.addEventListener("focusout", hideLine);
    });
}

function initMobileMenu() {
    const button = document.querySelector(".open-mobile-menu");
    const panel = document.querySelector(".mobile-menu-panel");

    if (!button || !panel) {
        return;
    }

    const lines = button.querySelectorAll(".mobile-menu-line");
    const menuLinks = panel.querySelectorAll(".mobile-menu-link");
    const menuMeta = panel.querySelector(".mobile-menu-meta");
    let isOpen = false;
    let menuTimeline = null;

    gsap.set(panel, { autoAlpha: 0, yPercent: -6 });
    gsap.set(menuLinks, { autoAlpha: 0, y: 24 });
    gsap.set(menuMeta, { autoAlpha: 0, y: 14 });

    const setExpanded = (nextState) => {
        button.setAttribute("aria-expanded", String(nextState));
        button.setAttribute(
            "aria-label",
            nextState ? "Mobil menuyu kapat" : "Mobil menuyu ac",
        );
        panel.setAttribute("aria-hidden", String(!nextState));
    };

    const animateButton = (nextState) => {
        gsap.killTweensOf(lines);

        if (nextState) {
            gsap.to(lines[0], {
                top: "50%",
                yPercent: -50,
                rotation: 45,
                duration: 0.34,
                ease: "power2.inOut",
            });
            gsap.to(lines[1], {
                autoAlpha: 0,
                x: -8,
                duration: 0.22,
                ease: "power2.out",
            });
            gsap.to(lines[2], {
                bottom: "50%",
                yPercent: 50,
                width: "100%",
                rotation: -45,
                duration: 0.34,
                ease: "power2.inOut",
            });
            return;
        }

        gsap.to(lines[0], {
            top: "0%",
            yPercent: 0,
            rotation: 0,
            duration: 0.3,
            ease: "power2.inOut",
        });
        gsap.to(lines[1], {
            autoAlpha: 1,
            x: 0,
            duration: 0.24,
            delay: 0.08,
            ease: "power2.out",
        });
        gsap.to(lines[2], {
            bottom: "0%",
            yPercent: 0,
            width: "50%",
            rotation: 0,
            duration: 0.3,
            ease: "power2.inOut",
        });
    };

    const openMenu = () => {
        if (isOpen) {
            return;
        }

        isOpen = true;
        menuTimeline?.kill();
        gsap.killTweensOf([panel, menuMeta, ...menuLinks]);
        setExpanded(true);
        lockPageScroll();
        animateButton(true);

        menuTimeline = gsap
            .timeline({
                defaults: { ease: "power3.out" },
                onStart: () => {
                    panel.style.pointerEvents = "auto";
                },
            })
            .to(panel, { autoAlpha: 1, yPercent: 0, duration: 0.42 })
            .to(
                menuLinks,
                { autoAlpha: 1, y: 0, duration: 0.48, stagger: 0.07 },
                "-=0.2",
            )
            .to(menuMeta, { autoAlpha: 1, y: 0, duration: 0.36 }, "-=0.28");
    };

    const closeMenu = () => {
        if (!isOpen) {
            return;
        }

        isOpen = false;
        menuTimeline?.kill();
        gsap.killTweensOf([panel, menuMeta, ...menuLinks]);
        setExpanded(false);
        unlockPageScroll();
        animateButton(false);

        menuTimeline = gsap
            .timeline({
                defaults: { ease: "power2.inOut" },
                onComplete: () => {
                    panel.style.pointerEvents = "none";
                    gsap.set(panel, { autoAlpha: 0, yPercent: -6 });
                    gsap.set(menuLinks, { autoAlpha: 0, y: 24 });
                    gsap.set(menuMeta, { autoAlpha: 0, y: 14 });
                },
            })
            .to([menuMeta, ...menuLinks].reverse(), {
                autoAlpha: 0,
                y: -12,
                duration: 0.18,
                stagger: 0.025,
            })
            .to(panel, { autoAlpha: 0, yPercent: -4, duration: 0.3 }, "-=0.04");
    };

    button.addEventListener("click", () => {
        if (isOpen) {
            closeMenu();
            return;
        }

        openMenu();
    });

    panel.querySelectorAll("a").forEach((link) => {
        link.addEventListener("click", closeMenu);
    });

    window.addEventListener("keydown", (event) => {
        if (event.key === "Escape") {
            closeMenu();
        }
    });

    window.addEventListener("resize", () => {
        if (window.matchMedia("(min-width: 769px)").matches && isOpen) {
            closeMenu();
        }
    });
}

function initHeroClipSlider() {
    const hero = document.querySelector(".hero-img-content");
    if (!hero) {
        return;
    }

    const items = Array.from(hero.querySelectorAll(".hero-img-item")).sort(
        (a, b) => Number(a.dataset.index) - Number(b.dataset.index),
    );
    const contents = Array.from(
        document.querySelectorAll(".hero-middle-content"),
    ).sort((a, b) => Number(a.dataset.index) - Number(b.dataset.index));
    const prevButton = document.querySelector(".hero-slider-prev");
    const nextButton = document.querySelector(".hero-slider-next");

    if (items.length < 2) {
        return;
    }

    const fullClip = "inset(0% 0% 0% 0%)";
    const revealFromLeft = "inset(0% 100% 0% 0%)";
    const revealFromRight = "inset(0% 0% 0% 100%)";
    const autoplayDelay = 5000;
    let activeIndex = 0;
    let isAnimating = false;
    let autoplay = null;

    const syncContent = (nextIndex) => {
        contents.forEach((content, index) => {
            const isActive = index === nextIndex;
            content.classList.toggle("hidden", !isActive);

            if (isActive) {
                gsap.fromTo(
                    content,
                    { autoAlpha: 0, y: 18 },
                    { autoAlpha: 1, y: 0, duration: 0.55, ease: "power3.out" },
                );
            }
        });
    };

    const resetAutoplay = () => {
        clearInterval(autoplay);
        autoplay = setInterval(() => {
            goNext();
        }, autoplayDelay);
    };

    const setStack = () => {
        items.forEach((item, index) => {
            gsap.set(item, {
                zIndex: index === activeIndex ? 2 : 1,
                clipPath: index === activeIndex ? fullClip : revealFromLeft,
            });
        });
    };

    const goTo = (nextIndex, direction = "next") => {
        if (isAnimating || nextIndex === activeIndex) {
            return;
        }

        isAnimating = true;
        const current = items[activeIndex];
        const next = items[nextIndex];
        gsap.killTweensOf(items);
        gsap.set(items, { zIndex: 0 });
        gsap.set(current, { zIndex: 1, clipPath: fullClip });
        gsap.set(next, {
            zIndex: 2,
            clipPath: direction === "next" ? revealFromLeft : revealFromRight,
        });
        syncContent(nextIndex);

        gsap.to(next, {
            clipPath: fullClip,
            duration: 1.15,
            ease: "power3.inOut",
            onComplete: () => {
                activeIndex = nextIndex;
                items.forEach((item, index) => {
                    gsap.set(item, {
                        zIndex: index === activeIndex ? 2 : 1,
                        clipPath:
                            index === activeIndex ? fullClip : revealFromLeft,
                    });
                });
                isAnimating = false;
            },
        });
    };

    const completeStackToStart = () => {
        if (isAnimating) {
            return;
        }

        isAnimating = true;
        gsap.killTweensOf(items);
        syncContent(0);

        items.forEach((item, index) => {
            gsap.set(item, {
                zIndex: index === items.length - 1 ? 1 : index + 2,
                clipPath:
                    index === items.length - 1 ? fullClip : revealFromLeft,
            });
        });

        gsap.timeline({
            defaults: { duration: 0.72, ease: "power3.inOut" },
            onComplete: () => {
                activeIndex = 0;
                items.forEach((item, index) => {
                    gsap.set(item, {
                        zIndex: index === activeIndex ? 2 : 1,
                        clipPath:
                            index === activeIndex ? fullClip : revealFromLeft,
                    });
                });
                isAnimating = false;
            },
        }).to(items.slice(0, -1), {
            clipPath: fullClip,
            stagger: 0.16,
        });
    };

    function goNext() {
        if (activeIndex === items.length - 1) {
            completeStackToStart();
            return;
        }

        goTo(activeIndex + 1, "next");
    }

    function goPrev() {
        if (activeIndex === 0) {
            goTo(items.length - 1, "prev");
            return;
        }

        goTo(activeIndex - 1, "prev");
    }

    setStack();
    syncContent(0);
    resetAutoplay();

    nextButton?.addEventListener("click", () => {
        goNext();
        resetAutoplay();
    });

    prevButton?.addEventListener("click", () => {
        goPrev();
        resetAutoplay();
    });
}

function initCategoryFloatAnimations(container) {
    const cards = Array.from(
        container.querySelectorAll(".categories-floating-card"),
    );

    if (
        !cards.length ||
        window.matchMedia("(prefers-reduced-motion: reduce)").matches
    ) {
        return;
    }

    const duration = 5.8;
    const timelines = [];

    const createAnimations = () => {
        timelines.forEach((timeline) => timeline.kill());
        timelines.length = 0;

        cards.forEach((card, index) => {
            const slide = card.closest(".swiper-slide");
            const limit = slide
                ? Math.max((slide.clientHeight - card.clientHeight) / 2, 0)
                : 0;
            const slideIndex = Number(
                slide?.dataset.swiperSlideIndex ?? index,
            );
            const startsDown = slideIndex % 2 === 0;
            const fromY = startsDown ? -limit : limit;
            const toY = startsDown ? limit : -limit;

            gsap.killTweensOf(card);
            gsap.set(card, {
                y: fromY,
                force3D: true,
            });

            timelines.push(
                gsap.to(card, {
                    y: toY,
                    duration,
                    ease: "sine.inOut",
                    repeat: -1,
                    yoyo: true,
                }),
            );
        });
    };

    let resizeTimer = null;

    createAnimations();
    window.addEventListener("resize", () => {
        clearTimeout(resizeTimer);
        resizeTimer = setTimeout(createAnimations, 160);
    });
}

function copyTextFallback(text) {
    const textarea = document.createElement("textarea");

    textarea.value = text;
    textarea.setAttribute("readonly", "");
    textarea.style.position = "fixed";
    textarea.style.top = "-9999px";
    textarea.style.left = "-9999px";
    document.body.appendChild(textarea);
    textarea.select();
    document.execCommand("copy");
    textarea.remove();
}

function initSiteShare() {
    const shareButtons = document.querySelectorAll(".share-site");

    if (!shareButtons.length) {
        return;
    }

    shareButtons.forEach((button) => {
        const defaultLabel = button.getAttribute("aria-label") || "Share site";

        button.addEventListener("click", async () => {
            const url = window.location.href;
            const shareData = {
                title: document.title,
                text: "Fuwans",
                url,
            };

            try {
                if (navigator.share) {
                    await navigator.share(shareData);
                    return;
                }

                if (navigator.clipboard?.writeText) {
                    await navigator.clipboard.writeText(url);
                } else {
                    copyTextFallback(url);
                }

                button.setAttribute("aria-label", "Site link copied");
                clearTimeout(button.shareResetTimer);
                button.shareResetTimer = setTimeout(() => {
                    button.setAttribute("aria-label", defaultLabel);
                }, 1400);
            } catch (error) {
                if (error?.name === "AbortError") {
                    return;
                }

                copyTextFallback(url);
            }
        });
    });
}

$(function () {
    initScrollControl();
    initUnderlineAnimations();
    initMobileMenu();
    initHeroClipSlider();
    initSiteShare();

    const homeProperties = document.querySelector(".home-properties-swiper");
    if (homeProperties) {
        new Swiper(homeProperties, {
            slidesPerView: 1.3,
            spaceBetween: 16,
            loop: true,
            speed: 5000,
            allowTouchMove: false,
            autoplay: {
                delay: 0,
                disableOnInteraction: false,
            },
            breakpoints: {
                451: {
                    slidesPerView: 2,
                    spaceBetween: 16,
                },
                800: {
                    slidesPerView: 3,
                    spaceBetween: 16,
                },
                1441: {
                    slidesPerView: 6,
                    spaceBetween: 16,
                },
            },
        });
    }

    const homeCategories = document.querySelector(".categories-swiper");
    if (homeCategories) {
        new Swiper(homeCategories, {
            slidesPerView: 1.3,
            spaceBetween: 16,
            loop: true,
            speed: 800,
            preventInteractionOnTransition: true,
            autoplay: {
                delay: 5000,
                disableOnInteraction: false,
            },
            breakpoints: {
                500: {
                    slidesPerView: 2,
                    spaceBetween: 16,
                },
                800: {
                    slidesPerView: 3,
                    spaceBetween: 16,
                },
                1441: {
                    slidesPerView: 3,
                    spaceBetween: 16,
                },
            },
        });
        initCategoryFloatAnimations(homeCategories);
    }
});
