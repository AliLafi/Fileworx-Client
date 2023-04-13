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
    var checkBoxRead = document.getElementById("IsReadFile");
    var checkBoxWrite = document.getElementById("IsWriteFile");
    var checkBoxReadFtp = document.getElementById("IsReadFtp");
    var checkBoxWriteFtp = document.getElementById("IsWriteFtp");
    var checkBoxWriteTelegram = document.getElementById("IsWriteTelegram");
    var submitBtn = document.getElementById("ContactBtn")
    if (checkBoxRead.checked == true || checkBoxWrite.checked == true || checkBoxReadFtp.checked == true || checkBoxWriteFtp.checked == true || checkBoxWriteTelegram.checked == true) {
        submitBtn.removeAttribute("disabled");
    }
    else {
        submitBtn.setAttribute("disabled", "disabled");
    }
}

function checkFtp() {
    var checkRead = document.getElementById("IsReadFtp");
    var checkWrite = document.getElementById("IsWriteFtp");
    var Host = document.getElementById("Host");
    var User = document.getElementById("Username");
    var Pass = document.getElementById("Password");
    if (checkRead.checked || checkWrite.checked) {
        Host.type = "text";
        Pass.type = "text";
        User.type = "text";
        Host.removeAttribute("disabled");
        Pass.removeAttribute("disabled");
        User.removeAttribute("disabled");
    }
    else {
        Host.type = "hidden";
        Pass.type = "hidden";
        User.type = "hidden";
        Host.setAttribute("disabled", "disabled");
        User.setAttribute("disabled", "disabled");
        Pass.setAttribute("disabled", "disabled");
    }
}


function checkFileReceive() {
    checkBtn();
    var checkBox = document.getElementById("IsReadFile");
    var recieve = document.getElementById("ReceiveFilePath");
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

function checkFileSend() {
    checkBtn();

    var checkBox = document.getElementById("IsWriteFile");
    var send = document.getElementById("SendFilePath");
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

function checkTelegramSend() {
    checkBtn();
    var checkBox = document.getElementById("IsWriteTelegram");
    var userBox = document.getElementById("TelegramUsername");
    if (checkBox.checked == true) {
        userBox.type = "text";
        checkBox.value = true;
        userBox.setAttribute("required", "required");
    }
    else {
        userBox.type = "hidden";
        checkBox.value = false;
        userBox.setAttribute("required", "");
    }
}

function checkFtpReceive() {
    checkBtn();
    var checkBox = document.getElementById("IsReadFtp");
    var recieve = document.getElementById("ReceiveFtpPath");
    if (checkBox.checked == true) {
        recieve.type = "text";
        checkBox.value = true;
        recieve.setAttribute("required", "required");
        checkFtp();
    }
    else {
        recieve.type = "hidden";
        checkBox.value = false;
        recieve.setAttribute("required", "");
    }
    checkFtp();
}

function checkFtpSend() {
    checkBtn();

    var checkBox = document.getElementById("IsWriteFtp");
    var send = document.getElementById("SendFtpPath");
    if (checkBox.checked == true) {
        send.type = "text";
        checkBox.value = true;
        send.setAttribute("required", "required");
    }
    else {
        send.type = "hidden";
        checkBox.value = false;
        send.setAttribute("required", "");
    }
    checkFtp();
}
