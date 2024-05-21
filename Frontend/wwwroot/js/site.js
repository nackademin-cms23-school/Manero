document.addEventListener("DOMContentLoaded", function () {
    swiperFunction();
})

function swiperFunction() {
    var swiper = new Swiper(".mySwiper", {
        direction: 'horizontal',
        slidesPerView: 4,
        spaceBetween: 10,
        loop: false,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
    });
}