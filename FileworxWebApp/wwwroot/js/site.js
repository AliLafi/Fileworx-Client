// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    (function () {
        'use strict'

  // Fetch all the forms we want to apply custom Bootstrap validation styles to
  var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
    .forEach(function (form) {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            form.classList.add('was-validated')
        }, false)
    })
})()


function checkBtn() {
    var checkBoxRead = document.getElementById("IsRead");
    var checkBoxWrite = document.getElementById("IsWrite");
    var submitBtn = document.getElementById("ContactBtn")
    if (checkBoxRead.checked == true || checkBoxWrite.checked == true) {
        submitBtn.removeAttribute("disabled");
    }
    else {
        submitBtn.setAttribute("disabled", "disabled");
    }
}



function checkReceive() {
    checkBtn();
    var checkBox = document.getElementById("IsRead");
    var recieve = document.getElementById("ReceivePath");
    if (checkBox.checked == true) {
        recieve.type = "text";
        checkBox.value = true;
        recieve.setAttribute("required","required");
    }
    else
    {
        recieve.type = "hidden";
        checkBox.value = false;
        recieve.setAttribute("required", "");
    }
}

function checkSend() {
    checkBtn();

    var checkBox = document.getElementById("IsWrite");
    var send = document.getElementById("SendPath");
    if (checkBox.checked == true) {
        send.type = "text";
        checkBox.value = true;
        send.setAttribute("required", "required");
    }
    else
    {
        send.type = "hidden";
        checkBox.value = false;
        send.setAttribute("required", "");
    }
}

