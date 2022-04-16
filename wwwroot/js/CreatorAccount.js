$(function () {

  $('.CheckboxCreatorAccount').click(function () {
    var checkboxObj = document.getElementById($(this).attr('id'));
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
          checkboxObj.checked = !checkboxObj.checked
        }
      },
      error: function (xhr, ajaxOptions, thrownError) {
        var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
        PresentAutoCloseBootstrapAlert("#alert_placeholder_result", "danger", "Error!", errorText);
        checkboxObj.checked = !checkboxObj.checked
        console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
      }
    });
  });
});