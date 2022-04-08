$(function () {

    $('.CheckboxCreatorAccount').click(function () {

        var checkbox_obj = document.getElementById($(this).attr('id'));
        var email = document.getElementById($(this).attr('id').replace("checkbox", "userName")).innerText;
        var role = ($(this).is(":checked")) ? "CREATOR" : null;

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
                    PresentAutoCloseBootstrapAlert("#alert_placeholder_result", "success", "", "Role change was successful !");
                }
                else {
                    PresentAutoCloseBootstrapAlert("#alert_placeholder_result", "danger", "Error!", "Role change was unsuccessful !");
                    checkbox_obj.checked = !checkbox_obj.checked
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
                checkbox_obj.checked = !checkbox_obj.checked
            }

        });

    });

});