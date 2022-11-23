// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
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
        $.ajax('/Comment/AddComment', {
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