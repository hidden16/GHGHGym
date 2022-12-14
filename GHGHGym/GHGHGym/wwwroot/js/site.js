const triggerTabList = document.querySelectorAll('#myTab button')
triggerTabList.forEach(triggerEl => {
    const tabTrigger = new bootstrap.Tab(triggerEl)

    triggerEl.addEventListener('click', event => {
        event.preventDefault()
        tabTrigger.show()
    })
})

$(document).ready(function () {
    $("#SubmitComment").click(function () {

        var productId = $("input#ProductId").val();
        var commentText = $("textarea#CommentText").val();
        $.ajax('/Comment/AddProductComment', {
            type: 'POST', // http method
            data: { productId: productId, commentText: commentText },  // data to submit
            //headers: { 'X-CSRF-TOKEN': token },
            complete: function (html) {
                $("#CommentContainer").html(html.responseText);
                $("textarea#CommentText").val("");
            }
        });
    });
});

$(document).ready(function () {
    $("#SubmitCommentTrainer").click(function () {

        var trainerId = $("input#TrainerId").val();
        var commentText = $("textarea#CommentText").val();
        $.ajax('/Comment/AddTrainerComment', {
            type: 'POST', // http method
            data: { trainerId: trainerId, commentText: commentText },  // data to submit
            //headers: { 'X-CSRF-TOKEN': token },
            complete: function (html) {
                $("#CommentContainer").html(html.responseText);
                $("textarea#CommentText").val("");
            }
        });
    });
});

