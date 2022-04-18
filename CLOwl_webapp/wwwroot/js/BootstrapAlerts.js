/* exported PresentClosableBootstrapAlert, PresentAutoCloseBootstrapAlert, CloseAlert */
function PresentClosableBootstrapAlert (placeHolderElemId, alertType, alertHeading, alertMessage) {
  if (alertType === '') {
    alertType = 'info'
  }
  var alertHtml = '<div class="alert alert-' + alertType + ' alert-dismissible fade show" role="alert">' +
    '<strong>' + alertHeading + '</strong><br>' + alertMessage +
    '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
    '<span aria-hidden="true">&times;</span>' +
    '</button>' +
    '</div>'

  $(placeHolderElemId).html(alertHtml);
}

function PresentAutoCloseBootstrapAlert (placeHolderElemId, alertType, alertHeading, alertMessage) {
  if (alertType == '') {
    alertType = 'info'
  }
  var alertHtml = '<div class="alert alert-' + alertType + ' fade show" role="alert">' +
    '<strong>' + alertHeading + '</strong><br>' + alertMessage + '</div>'

  $(placeHolderElemId).html(alertHtml);

  window.setTimeout(function () {
    $('.alert').fadeTo(500, 0).slideUp(500, function () {
      $(this).remove();
    });
  }, 2000);
}

function CloseAlert (placeHolderElemId) {
  $(placeHolderElemId).html('');
}
