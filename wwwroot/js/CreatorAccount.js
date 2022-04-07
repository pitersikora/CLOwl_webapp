$(function () {

    $('.CheckboxCreatorAccount').click(function () {

        var email = document.getElementById($(this).attr('id').replace("checkbox", "userName")).innerText;
        var role = ($(this).is(":checked")) ? "CREATOR" : null
        console.log(email);
        console.log(role)

        var userInput = {
            UserName: email,
            Role: role
        };

        var url = "CreatorAccounts/ChangeRole";

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {

                if (data) {
                    PresentBootstrapAlert("#alert_placeholder_result", "success", "", "Role change was successful !");
                }
                else {
                    PresentBootstrapAlert("#alert_placeholder_result", "danger", "Error!", "Role change was unsuccessful !");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }

        });

    });

});