document.addEventListener("DOMContentLoaded", function () {
    forgotPasswordVerification()
    accountVerification()
})

function forgotPasswordVerification() {
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

function accountVerification(){
    const form = document.querySelector(".verification-form")
    const inputs = form.querySelectorAll("input")

    inputs.forEach(input => {
        input.addEventListener("keyup", (e) => {
            if(e.target.value.length > 1) {
                let value = e.target.value
                let result = value.slice(1)

                e.target.value = result
            }
        })
    })
}