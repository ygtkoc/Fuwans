import $ from 'jquery';
import Swiper from 'swiper';
import { Navigation, Pagination, Autoplay } from 'swiper/modules';
import { Fancybox } from '@fancyapps/ui';
import gsap from 'gsap';
import Lenis from 'lenis';

window.$ = window.jQuery = $;

Swiper.use([Navigation, Pagination, Autoplay]);

Fancybox.bind('[data-fancybox]', {
  dragToClose: true,
  animated: true,
});

const lenis = new Lenis({
  duration: 1.05,
  smoothWheel: true,
});

function raf(time) {
  lenis.raf(time);
  requestAnimationFrame(raf);
}

requestAnimationFrame(raf);

function initScrollControl() {
  const control = document.querySelector('.site-scroll-control');
  if (!control) {
    return;
  }

  let lastScrollY = window.scrollY;
  let direction = 'down';
  let hideTimer = null;

  function getScrollLimit() {
    return Math.max(document.documentElement.scrollHeight - window.innerHeight, 0);
  }

  function setDirection(nextDirection) {
    direction = nextDirection;
    control.classList.toggle('is-up', direction === 'up');
    control.setAttribute('aria-label', direction === 'up' ? 'Sayfanin basina git' : 'Sayfanin sonuna git');
  }

  function scheduleHide() {
    clearTimeout(hideTimer);
    hideTimer = setTimeout(() => {
      control.classList.remove('is-visible');
    }, 950);
  }

  function updateControl() {
    const scrollY = window.scrollY;
    const limit = getScrollLimit();
    const progress = limit ? Math.min(Math.max(scrollY / limit, 0), 1) : 0;

    control.style.setProperty('--scroll-progress', progress.toFixed(4));

    if (limit <= 0) {
      control.classList.remove('is-visible');
      return;
    }

    if (progress <= 0.001) {
      setDirection('down');
    } else if (progress >= 0.999) {
      setDirection('up');
    } else if (scrollY > lastScrollY) {
      setDirection('down');
    } else if (scrollY < lastScrollY) {
      setDirection('up');
    }

    lastScrollY = scrollY;
    control.classList.add('is-visible');
    scheduleHide();
  }

  control.addEventListener('click', () => {
    const target = direction === 'up' ? 0 : getScrollLimit();
    control.classList.add('is-visible');
    lenis.scrollTo(target, { duration: 1.15 });
    scheduleHide();
  });

  lenis.on('scroll', updateControl);
  window.addEventListener('resize', updateControl);
  window.addEventListener('load', updateControl);
  updateControl();
  control.classList.remove('is-visible');
}

function initUnderlineAnimations() {
  const links = document.querySelectorAll('.under-anim');
  if (!links.length) {
    return;
  }

  links.forEach((link) => {
    let line = link.querySelector('.under-anim__line');

    if (!line) {
      line = document.createElement('span');
      line.className = 'under-anim__line';
      line.setAttribute('aria-hidden', 'true');
      link.appendChild(line);
    }

    gsap.set(line, { left: '0%', right: '100%' });

    const showLine = () => {
      gsap.killTweensOf(line);
      gsap.to(line, {
        left: '0%',
        right: '0%',
        duration: 0.42,
        ease: 'power2.inOut',
      });
    };

    const hideLine = () => {
      gsap.killTweensOf(line);
      gsap.to(line, {
        left: '100%',
        right: '0%',
        duration: 0.36,
        ease: 'power2.inOut',
        onComplete: () => {
          gsap.set(line, { left: '0%', right: '100%' });
        },
      });
    };

    link.addEventListener('mouseenter', showLine);
    link.addEventListener('mouseleave', hideLine);
    link.addEventListener('focusin', showLine);
    link.addEventListener('focusout', hideLine);
  });
}

function initMobileMenu() {
  const button = document.querySelector('.open-mobile-menu');
  const panel = document.querySelector('.mobile-menu-panel');

  if (!button || !panel) {
    return;
  }

  const lines = button.querySelectorAll('.mobile-menu-line');
  const menuLinks = panel.querySelectorAll('.mobile-menu-link');
  const menuMeta = panel.querySelector('.mobile-menu-meta');
  let isOpen = false;
  let menuTimeline = null;

  gsap.set(panel, { autoAlpha: 0, yPercent: -6 });
  gsap.set(menuLinks, { autoAlpha: 0, y: 24 });
  gsap.set(menuMeta, { autoAlpha: 0, y: 14 });

  const setExpanded = (nextState) => {
    button.setAttribute('aria-expanded', String(nextState));
    button.setAttribute('aria-label', nextState ? 'Mobil menuyu kapat' : 'Mobil menuyu ac');
    panel.setAttribute('aria-hidden', String(!nextState));
    document.documentElement.classList.toggle('overflow-hidden', nextState);
    document.body.classList.toggle('overflow-hidden', nextState);
  };

  const animateButton = (nextState) => {
    gsap.killTweensOf(lines);

    if (nextState) {
      gsap.to(lines[0], {
        top: '50%',
        yPercent: -50,
        rotation: 45,
        duration: 0.34,
        ease: 'power2.inOut',
      });
      gsap.to(lines[1], {
        autoAlpha: 0,
        x: -8,
        duration: 0.22,
        ease: 'power2.out',
      });
      gsap.to(lines[2], {
        bottom: '50%',
        yPercent: 50,
        width: '100%',
        rotation: -45,
        duration: 0.34,
        ease: 'power2.inOut',
      });
      return;
    }

    gsap.to(lines[0], {
      top: '0%',
      yPercent: 0,
      rotation: 0,
      duration: 0.3,
      ease: 'power2.inOut',
    });
    gsap.to(lines[1], {
      autoAlpha: 1,
      x: 0,
      duration: 0.24,
      delay: 0.08,
      ease: 'power2.out',
    });
    gsap.to(lines[2], {
      bottom: '0%',
      yPercent: 0,
      width: '50%',
      rotation: 0,
      duration: 0.3,
      ease: 'power2.inOut',
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
    animateButton(true);

    menuTimeline = gsap.timeline({
      defaults: { ease: 'power3.out' },
      onStart: () => {
        panel.style.pointerEvents = 'auto';
      },
    })
      .to(panel, { autoAlpha: 1, yPercent: 0, duration: 0.42 })
      .to(menuLinks, { autoAlpha: 1, y: 0, duration: 0.48, stagger: 0.07 }, '-=0.2')
      .to(menuMeta, { autoAlpha: 1, y: 0, duration: 0.36 }, '-=0.28');
  };

  const closeMenu = () => {
    if (!isOpen) {
      return;
    }

    isOpen = false;
    menuTimeline?.kill();
    gsap.killTweensOf([panel, menuMeta, ...menuLinks]);
    setExpanded(false);
    animateButton(false);

    menuTimeline = gsap.timeline({
      defaults: { ease: 'power2.inOut' },
      onComplete: () => {
        panel.style.pointerEvents = 'none';
        gsap.set(panel, { autoAlpha: 0, yPercent: -6 });
        gsap.set(menuLinks, { autoAlpha: 0, y: 24 });
        gsap.set(menuMeta, { autoAlpha: 0, y: 14 });
      },
    })
      .to([menuMeta, ...menuLinks].reverse(), { autoAlpha: 0, y: -12, duration: 0.18, stagger: 0.025 })
      .to(panel, { autoAlpha: 0, yPercent: -4, duration: 0.3 }, '-=0.04');
  };

  button.addEventListener('click', () => {
    if (isOpen) {
      closeMenu();
      return;
    }

    openMenu();
  });

  panel.querySelectorAll('a').forEach((link) => {
    link.addEventListener('click', closeMenu);
  });

  window.addEventListener('keydown', (event) => {
    if (event.key === 'Escape') {
      closeMenu();
    }
  });

  window.addEventListener('resize', () => {
    if (window.matchMedia('(min-width: 769px)').matches && isOpen) {
      closeMenu();
    }
  });
}

$(function () {
  initScrollControl();
  initUnderlineAnimations();
  initMobileMenu();

  const heroSlider = document.querySelector('.js-hero-slider');
  if (heroSlider) {
    new Swiper(heroSlider, {
      loop: true,
      speed: 900,
      autoplay: {
        delay: 4200,
        disableOnInteraction: false,
      },
      pagination: {
        el: '.js-hero-pagination',
        clickable: true,
      },
      navigation: {
        nextEl: '.js-hero-next',
        prevEl: '.js-hero-prev',
      },
    });
  }

  const productSlider = document.querySelector('.js-product-slider');
  if (productSlider) {
    new Swiper(productSlider, {
      slidesPerView: 1.2,
      spaceBetween: 16,
      breakpoints: {
        640: { slidesPerView: 2.2 },
        1024: { slidesPerView: 4, spaceBetween: 24 },
      },
    });
  }

  $('.js-menu-toggle').on('click', function () {
    $('.js-mobile-menu').toggleClass('hidden');
    $(this).attr('aria-expanded', (_, value) => value !== 'true');
  });

  gsap.from('[data-animate="fade-up"]', {
    y: 28,
    opacity: 0,
    duration: 0.85,
    ease: 'power3.out',
    stagger: 0.08,
  });
});
