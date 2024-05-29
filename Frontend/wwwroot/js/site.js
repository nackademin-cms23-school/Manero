document.addEventListener("DOMContentLoaded", function () {
    swiperFunction();
    forgotPasswordVerification()
    accountVerification()
    onboardingFunction()
    handleOrderClick()
    handelbutton()
})

function swiperFunction() {
    try {
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
    catch { }
}

function forgotPasswordVerification() {
    try {
        const form = document.querySelector(".forgotpassword-verification-form")
        const inputs = form.querySelectorAll("input")

        inputs.forEach(input => {
            input.addEventListener("keyup", (e) => {
                if (e.target.value.length > 1) {
                    let value = e.target.value
                    let result = value.slice(1)

                    e.target.value = result
                    console.log(value)
                }
            })
        })
    }
    catch { }
}

function accountVerification(){
    try {
        const form = document.querySelector(".verification-form")
        const inputs = form.querySelectorAll("input")

        inputs.forEach(input => {
            input.addEventListener("keyup", (e) => {
                if (e.target.value.length > 1) {
                    let value = e.target.value
                    let result = value.slice(1)

                    e.target.value = result
                }
            })
        })
    }
    catch { }
}

function onboardingFunction() {
    try {
        console.log("Hej")

        const btns = document.querySelectorAll("#onboard-btn")
        btns.forEach(btn => {
            btn.addEventListener("click", function () {
                plusSlides(1)
            })
        })

        const dots1 = document.querySelectorAll(".dots-one")
        console.log(dots1)
        dots1.forEach(dot1 => {
            dot1.addEventListener("click", function () {
                currentSlide(1)
            })
        })

        const dots2 = document.querySelectorAll(".dots-2")
        dots2.forEach(dot2 => {
            dot2.addEventListener("click", function () {
                currentSlide(2)
            })
        })

        const dots3 = document.querySelectorAll(".dots-3")
        dots3.forEach(dot3 => {
            dot3.addEventListener("click", function () {
                currentSlide(3)
            })
        })

        let slideIndex = 1;
        showSlides(slideIndex);

        function plusSlides(n) {
            showSlides(slideIndex += n);
        }

        function currentSlide(n) {
            showSlides(slideIndex = n);
        }

        function showSlides(n) {
            let i;
            let slides = document.getElementsByClassName("content");
            let dots = document.getElementsByClassName("dot");
            if (n > slides.length) { slideIndex = 1 }
            console.log(n)
            if (n < 1) { slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "flex";
            dots[slideIndex - 1].className += " active";
        }
    }
    catch { }
}

const handleOrderClick = () => {
    try {
        orders = document.querySelectorAll('.order')
        if (orders.length > 0) {
            orders.forEach(order => {
                
                order.addEventListener('click', (e) => {
                    details = order.querySelector('.order-details')
                    console.log(details)
                    console.log(order)
                    if (!details.className.includes('visible')) {
                        details.className += ' visible'
                    }
                    else {
                        details.className = details.className.replace(' visible', '')
                    }
                })
            })
        }
    }
    catch {

    }


}
// payment and wishlist
function formatCardNumber() {
    const cardNumberInput = document.getElementById('cardNumber');
    let value = cardNumberInput.value.replace(/\D/g, '');
    value = value.slice(0, 16);
    cardNumberInput.value = value.match(/.{1,4}/g)?.join('-') || value;
}


function validateForm() {
    const cardNumber = document.getElementById('cardNumber').value.replace(/\D/g, '');
    const cvv = document.getElementById('cvv').value;
    const expiryDate = document.getElementById('expiryDate').value;

    if (cardNumber.length !== 16) {
        alert('Card number must be 16 digits.');
        return false;
    }

    if (!/^\d{3}$/.test(cvv)) {
        alert('CVV must be exactly 3 digits.');
        return false;
    }

    if (!/^\d{2}\/\d{2}$/.test(expiryDate)) {
        alert('Expiry date must be in the format MM/YY.');
        return false;
    }

    const [month, year] = expiryDate.split('/').map(Number);

    if (month < 1 || month > 12) {
        alert('Expiry month must be between 01 and 12.');
        return false;
    }

    const currentYear = new Date().getFullYear() % 100;
    if (year < currentYear || year > currentYear + 10) {
        alert('Expiry year must be within the next 10 years.');
        return false;
    }

    return true;
}

function handelbutton() {
    document.addEventListener('DOMContentLoaded', function () {

        const addCardIcon = document.getElementById('add-card-icon');
        const addPayoneerIcon = document.getElementById('add-payoneer-icon');


        function redirectToCardPage() {
            window.location.href = '/path/to/Index.html';
        }


        if (addCardIcon) {
            addCardIcon.addEventListener('click', redirectToCardPage);
        }
        if (addPayoneerIcon) {
            addPayoneerIcon.addEventListener('click', redirectToCardPage);
        }
    });

}


