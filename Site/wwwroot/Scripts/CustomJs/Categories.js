$("#categorysubmitbtn").click(function () {

    $(this).toggle()

    var token = $('input[name=__RequestVerificationToken]').val();

    var formModel = {}

    formModel.Id = $("#Id").val();

    formModel.Title = $("#Title").val();

    formModel.IsActive = $("#IsActive").val();

    formModel.ImageAddress = $("#ImageAddress").val();



    $.ajax({
        type: "POST",
        url: "/admin/Categories/Create",
        data: {
            __RequestVerificationToken: token,
            category: formModel
        },
        success: function (data) {
            $("#categorysubmitbtn").toggle()

            $("#categorytable").empty();

            var lankanListArray = JSON.parse(data);

            $.each(lankanListArray, function () {

                $("#categorytable").append("<tr><td>" + this.Title + "</td>" + "<td>" + "<img  style='width:210px;height:160px;' src='" + this.ImageAddress + "'>" + "</td>" +
                    "<td><a href='/admin/Categories/Edit/" + this.Id + "'>ویرایش</a></td> <td><button    onclick=deletecategory('" + this.Id + "') >حذف</button></td></tr>").val(this.Id);
            });

        },
        error: function (ex) {
            $("#categorysubmitbtn").toggle()
            alert(ex);
        }
    });


})

function deletecategory(id) {

    $.ajax({
        type: "post",
        url: "/admin/Categories/Delete/" + id,
        success: function (data) {
            $("#categorytable").empty();
            var lankanListArray = JSON.parse(data);
            $.each(lankanListArray, function () {
                $("#categorytable").append("<tr><td>" + this.Title + "</td>" + "<td>" + "<img  style='width:210px;height:160px;' src='" + this.ImageAddress + "'>" + "</td>" +
                    "<td><a href='/admin/Categories/Edit/" + this.Id + "'>ویرایش</a></td> <td><button   onclick=deletecategory('" + this.Id + "') >حذف</button></td></tr>").val(this.Id);
            });

        },
        error: function (ex) {
            alert(ex);
        }
    });
}

function AJAXSubmit(oFormElement, gifid, url) {

    var oReq = new XMLHttpRequest();
    var fileUpload = oFormElement;

    var file = fileUpload.files[0];

    var fileData = new FormData();

    fileData.append("fileData", file);
    oReq.onload = function (e) {
        $("#" + gifid).css("visibility", "visible");
        if (oReq.status == 200) {
            $("#" + gifid).css("visibility", "hidden");
            $("#ImageAddress").val(oReq.response);

        }
    };
    url += "?savedImage=" + $("#ImageAddress").val();
    oReq.open("POST", url);
    oReq.send(fileData);

}



