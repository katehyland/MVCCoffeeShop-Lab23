function ValidateForm() {

   return ConfirmPassAndEmail();
}

function ConfirmPassAndEmail() {
    //make objects, use colon sign to assign value to a property
    var Password = {
        pass: document.querySelector("#Password"),
        confirmPass: document.querySelector("#confirmPassword")
    };

    var Email = {
        email: document.querySelector("#Email"),
        confirmEmail: document.querySelector("#confirmEmail")
    };

    //first check if there has been any value entered
    if (Password.pass.value !== "" && Password.confirmPass.value !== "") {
        if (Email.email.value !== "" && Email.confirmEmail.value !== "") {

            //then check if it is the same confirmed values
            if (Password.pass.value === Password.confirmPass.value) {

                var email = Email.email.value.search(/(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/g);
                console.log(email);
                if (email == 0) {
                    console.log(email);
                    if (Email.email.value === Email.confirmEmail.value) {
                        console.log(email);
                        return true;
                    } else {
                        console.log(email + "false");
                        return false;
                    }
                }
            }

        } else {
            return false;
        }
    }
}