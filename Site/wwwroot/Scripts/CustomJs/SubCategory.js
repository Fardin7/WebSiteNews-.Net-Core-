$("#subcategorysubmitbtn").click(function () {

    $(this).toggle()

    var token = $('input[name=__RequestVerificationToken]').val();

    var formModel = {}

    formModel.Id = $("#Id").val();

    formModel.Title = $("#Title").val();

    formModel.IsActive = $("#IsActive").val();

    formModel.ImageAddress = $("#ImageAddress").val();

    formModel.CategoryId = $("#CategoryId").val();

    formModel.SubcategoryId = $("#SubcategoryId").val();

    $.ajax({
        type: "POST",
        url: "/admin/Subcategories/Create",
        data: {
            __RequestVerificationToken: token,
            subcategory: formModel
        },
        success: function (data) {

            $("#subcategorysubmitbtn").toggle()

            $("#Subcategoriestable").empty();

            var lankanListArray = JSON.parse(data);

            $.each(lankanListArray, function () {
                
                $("#Subcategoriestable").append("<tr id='" + this.Id+"' ><td>" + this.Title + "</td>" + "<td>" + "<img  style='width:210px;height:160px;' src='" + this.ImageAddress + "'>" + "</td>" +
                    "<td><a href='/admin/Subcategories/Edit/" + this.Id + "'>ویرایش</a></td> <td><button    onclick=deleteSubcategories('" + this.Id +"') >حذف</button></td></tr>").val(this.Id);
            });
          
        },
        error: function (ex) {

            $("#subcategorysubmitbtn").toggle()

            alert(ex);
        }
    });


})

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

function deleteSubcategories(id) {

    $.ajax({
        type: "post",
        url: "/admin/Subcategories/Delete/"+id,
        success: function (data) {
            if (data == "ok") {
                $("#Subcategoriestable #" + id).remove();
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

function uploadfile(uploadedfile, gifid, url) {
    $("#" + gifid).css("visibility", "visible");
    if (window.FormData !== undefined) {

        var fileUpload = uploadedfile;
        //$("#selectfile").get(0);
        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }


        $.ajax({
            url: url,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {

                $("#" + gifid).css("visibility", "hidden")
            },
            error: function (err) {
                alert(err.statusText);
            }
        });
    } else {
        alert("FormData is not supported.");
    }
}

