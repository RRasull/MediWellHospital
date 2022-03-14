   (function() {
    "use strict";

     /**
   * Easy selector helper function
   */
  const select = (el, all = false) => {
    el = el.trim()
    if (all) {
      return [...document.querySelectorAll(el)]
    } else {
      return document.querySelector(el)
    }
  }

  /**
   * Easy event listener function
   */
  const on = (type, el, listener, all = false) => {
    let selectEl = select(el, all)
    if (selectEl) {
      if (all) {
        selectEl.forEach(e => e.addEventListener(type, listener))
      } else {
        selectEl.addEventListener(type, listener)
      }
    }
  }

  /**
   * Easy on scroll event listener 
   */
  const onscroll = (el, listener) => {
    el.addEventListener('scroll', listener)
  }
  
    const nav = document.querySelector('#header');
    let navTop = nav.offsetTop;
    
    function fixedNav() {
      if (window.scrollY >= navTop) {    
        nav.classList.add('fixed');
      } else {
        nav.classList.remove('fixed');    
      }
    }
    
    window.addEventListener('scroll', fixedNav);
    
      /**
       * Back to top button
       */
       let backtotop = select('.back-to-top')
       if (backtotop) {
         const toggleBacktotop = () => {
           if (window.scrollY > 100) {
             backtotop.classList.add('active')
           } else {
             backtotop.classList.remove('active')
           }
         }
         window.addEventListener('load', toggleBacktotop)
         onscroll(document, toggleBacktotop)
       }

        /**
   * Animation on scroll
   */
  window.addEventListener('load', () => {
    AOS.init({
      duration: 1000,
      easing: 'ease-in-out',
      once: true,
      mirror: false
    })
  });

  /**
   * Preloader
   */
   let preloader = select('#preloader');
   if (preloader) {
     window.addEventListener('load', () => {
       preloader.remove()
     });
   }

   /**
   * Mobile nav toggle
   */
  on('click', '.mobile-nav-toggle', function(e) {
    select('#navbar').classList.toggle('navbar-mobile')
    this.classList.toggle('bi-list')
    this.classList.toggle('bi-x')
  })

  /**
   * Mobile nav dropdowns activate
   */
  on('click', '.navbar .dropdown > a', function(e) {
    if (select('#navbar').classList.contains('navbar-mobile')) {
      e.preventDefault()
      this.nextElementSibling.classList.toggle('dropdown-active')
    }
  }, true)


  })()


 