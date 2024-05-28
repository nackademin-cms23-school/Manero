document.addEventListener("DOMContentLoaded", function () {
    swiperFunction();
    forgotPasswordVerification()
    accountVerification()
    onboardingFunction()
    profileImgUpload()
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

        const btns = document.querySelectorAll("#onboard-btn")
        btns.forEach(btn => {
            btn.addEventListener("click", function () {
                plusSlides(1)
            })
        })

        const dots1 = document.querySelectorAll(".dots-one")
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

function profileImgUpload() {
    try {
        const fileUploader = document.querySelector("#file")
        

        if (fileUploader != undefined) {
            fileUploader.addEventListener("change", function (e) {
                if (this.files.length > 0) {
                    handleSubmit(e)
                    
                }
            })
        }
    }
    catch { }
}


const handleSubmit = async (e) => {

    e.preventDefault()
    
    const file = e.target.files[0]
    console.log(file)
    const formData = new FormData()
    formData.append('file', file);
    
    const res = await fetch('https://fileproviderasp2.azurewebsites.net/api/FileUploader?code=ioIp0g8nzbFkUfS2MtyVryqJnLN4lj0mD4Y1Yk5NxHm5AzFujw3E5g%3D%3D', {
        method: 'post',
        body: formData
    })

    if (res.status === 200) {
        let data = await res.text()
        data = data.replace(/^"|"$/g, '');

        console.log(data)

        const element = document.querySelector("#photoImage")
        console.log(element)
        element.src = data
    }
}