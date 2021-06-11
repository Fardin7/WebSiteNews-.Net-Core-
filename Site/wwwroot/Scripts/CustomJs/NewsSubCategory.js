$("#newssubcategorysubmitbtn").click(function () {

    $(this).toggle()

    var token = $('input[name=__RequestVerificationToken]').val();

    var formModel = {}

    formModel.Id = $("#Id").val();

    formModel.Title = $("#Title").val();

    formModel.IsActive = $("#IsActive").val();

    formModel.NewsCategoryId = $("#NewsCategoryId").val();

    formModel.NewsSubCategoryId = $("#NewsSubCategoryId").val();
    $.ajax({
        type: "POST",
        url: "/admin/NewsSubCategories/Create",
        data: {
            __RequestVerificationToken: token,
            newsSubCategory: formModel
        },
        success: function (data) {
            $("#newssubcategorysubmitbtn").toggle()

            $("#NewsSubCategorytable").empty();

            var lankanListArray = JSON.parse(data);

            $.each(lankanListArray, function () {

                $("#NewsSubCategorytable").append("<tr id='" + this.Id + "' ><td>" + this.Title + "</td>" + "<td>" +
                    "<td><a href='/admin/NewsSubCategories/Edit/" + this.Id + "'>ویرایش</a></td> <td><button    onclick=deletenewsSubcategories('" + this.Id + "') >حذف</button></td></tr>").val(this.Id);
            });

        },
        error: function (ex) {
            $("#newssubcategorysubmitbtn").toggle()
            alert(ex);
        }
    });


})
function deletenewsSubcategories(id) {

    $.ajax({
        type: "post",
        url: "/admin/NewsSubCategories/Delete/" + id,
        success: function (data) {
            if (data == "ok") {
                $("#NewsSubCategorytable #" + id).remove();
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


