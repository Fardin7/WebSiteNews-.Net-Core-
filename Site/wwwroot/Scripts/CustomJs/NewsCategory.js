$("#NewsCategorysubmitbtn").click(function () {

    $(this).toggle()

    var token = $('input[name=__RequestVerificationToken]').val();

    var formModel = {}

    formModel.Id = $("#Id").val();

    formModel.Title = $("#Title").val();

    formModel.IsActive = $("#IsActive").val();

    $.ajax({
        type: "POST",
        url: "/admin/NewsCategories/Create",
        async: true,
        data: {
            __RequestVerificationToken: token,
            newsCategory: formModel
        },
        success: function (data) {

            $("#NewsCategorysubmitbtn").toggle()

            $("#NewsCategorytable").empty();

            var lankanListArray = JSON.parse(data);

            $.each(lankanListArray, function () {

                $("#NewsCategorytable").append("<tr id='" + this.Id + "' ><td>" + this.Title + "</td>" +
                    "<td><a href='/admin/NewsCategories/Edit/" + this.Id + "'>ویرایش</a></td> <td><button    onclick=deleteNewsCategory('" + this.Id + "') >حذف</button></td></tr>").val(this.Id);
            });

        },
        error: function (ex) {
            $("#NewsCategorysubmitbtn").toggle()
            alert(ex);
        }
    });


})
function deleteNewsCategory(id) {

    $.ajax({
        type: "post",
        url: "/Admin/NewsCategories/Delete/" + id,
        success: function (data) {

            if (data == "ok") {
                $("#NewsCategorytable #" + id).remove();
            }
            else {
                alert(data)
            }
        },
        error: function (ex) {
            alert(ex);
        }
    });
}


