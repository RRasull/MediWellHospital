$('.owl-carousel').owlCarousel({
    loop:true,
    dots:false,
    nav:false,
    margin:10,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:5
        }
    }
})



$(document).ready(function() {
    $("#testimonial-slider").owlCarousel({
      items: 2,
      itemsDesktop: [1000, 2],
      itemsDesktopSmall: [990, 2],
      itemsTablet: [768, 1],
      pagination: true,
      navigation: false,
      navigationText: ["", ""],
      slideSpeed: 1000,
      autoPlay: true
    });
  });


  
jQuery(function ($) {
    "use strict";
    var $window = $(window);
    var windowsize = $(window).width();
    var $root = $("html, body");
    var $this = $(this);
 
 
    /*Testimonials 3columns*/
    $("#testimonial-slider").owlCarousel({
       items: 3,
       autoplay: 2500,
       autoplayHoverPause: true,
       loop: true,
       margin: 30,
       dots: true,
       nav: false,
       responsive: {
          1280: {
             items: 3,
          },
          600: {
             items: 2,
          },
          320: {
             items: 1,
          },
       }
    });
 
 
 });
 
 

 jQuery(function ($) {
    "use strict";
    var $window = $(window);
    var windowsize = $(window).width();
    var $root = $("html, body");
    var $this = $(this);
  
  
    /*Testimonials 3columns*/
    $("#testimonial-slider").owlCarousel({
       items: 3,
       autoplay: 2500,
       autoplayHoverPause: true,
       loop: true,
       margin: 30,
       dots: true,
       nav: false,
       responsive: {
          1280: {
             items: 3,
          },
          600: {
             items: 2,
          },
          320: {
             items: 1,
          },
       }
    });
  
  
 });