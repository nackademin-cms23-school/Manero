document.addEventListener("DOMContentLoaded", function () {
    //forgotPasswordVerification()
    //accountVerification()
    onboardingFunction()
})

//function forgotPasswordVerification() {
//    const form = document.querySelector(".forgotpassword-verification-form")
//    const inputs = form.querySelectorAll("input")

//    inputs.forEach(input => {
//        input.addEventListener("keyup", (e) => {
//            if (e.target.value.length > 1) {
//                let value = e.target.value
//                let result = value.slice(1)

//                e.target.value = result
//                console.log(value)
//            }
//        })
//    })
//}

//function accountVerification(){
//    const form = document.querySelector(".verification-form")
//    const inputs = form.querySelectorAll("input")

//    inputs.forEach(input => {
//        input.addEventListener("keyup", (e) => {
//            if(e.target.value.length > 1) {
//                let value = e.target.value
//                let result = value.slice(1)

//                e.target.value = result
//            }
//        })
//    })
//}

function onboardingFunction() {
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