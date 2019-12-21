/******************************************
    Version: 1.0
/****************************************** */

(function ($) {
    "use strict";

    /* ==============================================
	LOADER -->
    =============================================== */

    $(window).on('load', function () {
        $('.preloader').fadeOut();
        $('#preloader').delay(550).fadeOut('slow');
        $('body').delay(450).css({ 'overflow': 'visible' });
    })


	/* ==============================================
    Navbar Bar
    =============================================== */

    $('.navbar-nav .nav-link').on('click', function () {
        var toggle = $('.navbar-toggler').is(':visible');
        if (toggle) {
            $('.navbar-collapse').collapse('hide');
        }
    });

    /* ==============================================
    Dropdown show(滑鼠移過自動展開)
    =============================================== */

    $(document).ready(function () {
        $('.adminddl').hover(function () {
            $(this).find('.dropdown-menu').fadeToggle();
        });
    })



	/* ==============================================
    Fixed menu
    =============================================== */

    $(window).on('scroll', function () {
        if ($(window).scrollTop() > 50) {
            $('.header_style_01').addClass('fixed-menu');
        } else {
            $('.header_style_01').removeClass('fixed-menu');
        }
    });

    /* ==============================================
    BACK TOP
    =============================================== */
    $(window).scroll(function () {
        if (jQuery(this).scrollTop() > 1) {
            jQuery('.dmtop').css({
                bottom: "10px"
            });
        } else {
            jQuery('.dmtop').css({
                bottom: "-100px"
            });
        }
    });

	/* ==============================================
    Smooth Scroll
    =============================================== */

    $('a[href*="#"]')
        // Remove links that don't actually link to anything
        .not('[href="#"]')
        .not('[href="#0"]')
        .click(function (event) {
            // On-page links
            if (
                location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
                &&
                location.hostname == this.hostname
            ) {
                // Figure out element to scroll to
                var target = $(this.hash);
                target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                // Does a scroll target exist?
                if (target.length) {
                    // Only prevent default if animation is actually gonna happen
                    event.preventDefault();
                    $('html, body').animate({
                        scrollTop: target.offset().top
                    }, 1000, function () {
                        // Callback after animation
                        // Must change focus!
                        var $target = $(target);
                        $target.focus();
                        if ($target.is(":focus")) { // Checking if the target was focused
                            return false;
                        } else {
                            $target.attr('tabindex', '-1'); // Adding tabindex for elements not focusable
                            $target.focus(); // Set focus again
                        };
                    });
                }
            }
        });



	/* ==============================================
     FUN FACTS -->
     =============================================== */

    $('.selectpicker').selectpicker();

    /* ==============================================
     FUN FACTS -->
     =============================================== */

    function count($this) {
        var current = parseInt($this.html(), 10);
        current = current + 50; /* Where 50 is increment */
        $this.html(++current);
        if (current > $this.data('count')) {
            $this.html($this.data('count'));
        } else {
            setTimeout(function () {
                count($this)
            }, 30);
        }
    }
    $(".stat_count, .stat_count_download").each(function () {
        $(this).data('count', parseInt($(this).html(), 10));
        $(this).html('0');
        count($(this));
    });

    /* ==============================================
     TOOLTIP -->
     =============================================== */
    $('[data-toggle="tooltip"]').tooltip()
    $('[data-toggle="popover"]').popover()

    /* ==============================================
    DATE PICKER -->
    =============================================== */
    $(function () {
        $(".datetimepicker").datepicker({
            format: "yyyy/mm/dd",
            autoclose: true,
            clearBtn: true,
            calenderWeeks: true,
            todayHightlight: true,
            language: "zh-TW",
        });
    });

})(jQuery);