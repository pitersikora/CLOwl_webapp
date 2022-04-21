$(function () {
    $('.video-link').blur(function () {
        var linkObject = document.getElementById($(this).attr('id'));

        function getYouTubeVideoIdByUrl(url) {
            const reg = /^(https?:)?(\/\/)?((www\.|m\.)?youtube(-nocookie)?\.com\/((watch)?\?(feature=\w*&)?vi?=|embed\/|vi?\/|e\/)|youtu.be\/)([\w\-]{10,20})/i
            const match = url.match(reg);
            if (match) {
                return match[9];
            } else {
                return null;
            }
        }

        var ytID = getYouTubeVideoIdByUrl(linkObject.value)
        var ytAPIURL = 'https://youtube.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&id=' + ytID + '&key=AIzaSyC_qavYm7VKLQhK1u39vfGHuUlnrTIbF4s'

        $.ajax({
            type: "GET",
            url: ytAPIURL,
            success: function (data) {
                linkObject.value = 'https://www.youtube.com/embed/' + ytID
                PresentAutoCloseBootstrapAlert("#alert_placeholder_result", "success", "Succesfully added video link",
                    data.items[0].snippet.title);
            },
            fail: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText + '\r\n' + 'Trying to embed link manually';
                PresentAutoCloseBootstrapAlert("#alert_placeholder_result", "danger", "Error!", errorText);
                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
                linkObject.value = 'https://www.youtube.com/embed/' + ytID
            }
        });
  });
});