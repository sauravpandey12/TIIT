$(window).on("load", function() {
    "use strict";

    /*=================== Dropdown Class ===================*/
    $("nav li ul").parent().addClass("has-children");

    /*=================== Responsive Menu ===================*/
    $(".menu-button").on("click",function(){
        $(".responsive-menu").addClass("slidein");
        return false;
    });  
    $(".close-menu").on("click",function(){
        $(".responsive-menu").removeClass("slidein");
        return false;
    });  


    /*================== Responsive Menu Dropdown =====================*/
    $(".responsive-menu ul ul").parent().addClass("menu-item-has-children");
    $(".responsive-menu ul li.menu-item-has-children > a").on("click", function() {
        $(this).parent().toggleClass("active").siblings().removeClass("active");
        $(this).next("ul").slideToggle();
        $(this).parent().siblings().find("ul").slideUp();
        return false;
    });


    /*================== Search =====================*/
    $(".search-btn").on("click", function() {
        $(this).parent().toggleClass("active");
        return false;
    });


    /*=================== Accordion ===================*/
    $(".toggle").each(function(){
        $(this).find('.content').hide();
        $(this).find('h2:first').addClass('active').next().slideDown(500).parent().addClass("activate");
        $('h2', this).click(function() {
            if ($(this).next().is(':hidden')) {
                $(this).parent().parent().find("h2").removeClass('active').next().slideUp(500).parent().removeClass("activate");
                $(this).toggleClass('active').next().slideDown(500).parent().toggleClass("activate");
            }
        });
    });


    $(".tabs-selectors a").on("click",function(){
        $(this).addClass("active").siblings().removeClass("active");
    });  


});