function selectsub(ddcontext, tagid, btnid, dataname) {
    var id = ddcontext.value;
    var text = ddcontext.text;
    if (id != "") {
        $("#" + tagid).removeAttr("hidden")
        $("#" + btnid).removeAttr("hidden")
        $("#" + btnid).attr("data-id", id);
        $("#" + btnid).attr("data-name", dataname);
        $.ajax({
            type: "GET",
            url: "/admin/News/FillNewsCategory/",
            contentType: "application/json; charset=utf-8",
            data: { "id": id, "categorytype": tagid },
            datatype: "json",
            success: function (data) {
                $("#" + tagid).empty();

                var lankanListArray = JSON.parse(data);
                $.each(lankanListArray, function () {
                    $("#" + tagid).append($("<option></option>").val(this.Id).html(this.Title));
                });

            },
            error: function (ex) {
                alert(ex);
            }
        });
    }

}

$(function () {
    $(".btn-flat").click(function () {
        var dropdownid = $(this).attr('dropdown-id');
        var controllername = $(this).attr('controller-name');
        var dataid = $(this).attr("data-id");
        var dataname = $(this).attr("data-name");
        var TeamDetailPostBackURL = '/' + controllername + '/CreatePartial';
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: "/admin" + TeamDetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            datatype: "json",

            success: function (data) {

                var url = $(data).attr("action");
                var formid = $(data).attr("id");
                $('.modal-body').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');
                $("#submitbtn").unbind();
                if (dataid != undefined && dataname != undefined) {
                    $("#" + formid).append("<input name=" + dataname + "  value=" + dataid + "  id=" + dataname + " style='visibility:hidden'/>");

                }

                $("#submitbtn").click(function () {

                    $.ajax({
                        type: "POST",
                        url:  url,
                        data: $("#" + formid).serialize(),
                        success: function (data) {
                            $("#" + dropdownid).empty();
                            var lankanListArray = JSON.parse(data);
                            $.each(lankanListArray, function () {
                                $("#" + dropdownid).append($("<option></option>").val(this.Id).html(this.Title));
                            });
                            $('#myModal').modal('hide');

                        },
                        error: function (ex) {
                            alert(ex);
                        }
                    });


                })
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
});

function AJAXSubmit(oFormElement, gifid, url,addressholder,currentfile) {

    var oReq = new XMLHttpRequest();
    var fileUpload = oFormElement;

    var file = fileUpload.files[0];

    var fileData = new FormData();

    fileData.append("fileData", file);
    oReq.onload = function (e) {
        $("#" + gifid).css("visibility", "visible");
        if (oReq.status == 200) {
            $("#" + gifid).css("visibility", "hidden");
            $("#" + addressholder).val(oReq.response);
            if (currentfile =='newsimage') {
                $("#" + currentfile).attr('src', oReq.response)
            }           
        }
    };
    url += "?savedImage=" + $("#ImageAddress").val();
    oReq.open("POST", url);
    oReq.send(fileData);

}

function DeleteNewsFile(addressimage, id) {
    $.ajax({
        type: "POST",
        url: "/admin/DeleteNewsFile/DeleteNewsFile?addressimage=" + addressimage + "&& id=" + id,
        datatype: "json",
        success: function (data) {

            if (data) {
                alert("فایل حذف شد!")
                $("#uploadfileholder").empty();

            }
            else {
                alert("! در حذف فایل مشکلی به وجود امده")
            }

        },
        error: function (ex) {
            alert(ex);
        }
    });

}

function DeleteImage() {

    var addressimage = document.getElementById('newsimage').value;
    $.ajax({
        type: "GET",
        url: "/admin/News/DeleteImage?addressimage=" + addressimage,
        data: addressimage,
        success: function (data) {
            if (data) {
                $("#newsimage").remove();
                $("#deleteimage").remove();
            }
        },
        error: function (ex) {

        }
    });

}

$("#submitnewsform").click(function (e) {

    if ($("#newsform").validate()) {

        var formdata = {};

        var token = $('input[name=__RequestVerificationToken]').val();

        var newsFileAddress = $("#NewsFileAddress").val();
        formdata.Id = $("#Id").val();
        formdata.Title = $("#Title").val();
        formdata.ImageAddress = $("#ImageAddress").val();
        formdata.Description = $("#Description").val();
        formdata.Body = $('.textarea').val();
        formdata.KeyWord = $("#tags").val();
        formdata.PublishDate = $('#filter-date').val();
        formdata.IsActive = $("#IsActive").is(':checked');
        formdata.SubcategoryId = $("#SubcategoryId").val();
        formdata.NewsType = $('input[name=NewsType]:checked', '#editform').val();
        formdata.NewsSubcategoryId = $("#NewsSubcategoryId").val();

        $.ajax({
            type: "POST",
            url: "/admin/News/Create",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: {
                __RequestVerificationToken: token,
                News: formdata,
                NewsFileAddress: newsFileAddress

            },

            success: function (data) {
                if (data.data == "1") {
                    alert("تغییرات با موفقیت انجام شد")
                }
                else {
                    alert("امکان ثبت خبر نیست !!")
                }

            },
            error: function (ex) {
                alert(ex);
            }


        });

    }
  
    //if ($("#newsform").validate()) {

    //    var subcategory = $("#SubcategoryId").val();
    //    var newssubcategory = $("#NewsSubcategoryId").val();
    //    if (subcategory == null || newssubcategory == null) {
    //        $("#Subcategoryvld").html(" please select subcategory!");
    //        $("#NewsSubcategoryvld").html("please select newssubcategory!");

    //        e.preventDefault();
    //    }
    //}
})
$("#CategoryId ").change(function () {
    $("#Subcategoryvld").empty();


})
$("#NewsCategoryId").change(function () {

    $("#NewsSubcategoryvld").empty();

})
$("#submiteditform").click(function () {
    var formdata = {};

    var token = $('input[name=__RequestVerificationToken]').val();

    var newsFileAddress = $("#NewsFileAddress").val();

    formdata.Id = $("#Id").val();
    formdata.Title = $("#Title").val();
    formdata.ImageAddress = $("#ImageAddress").val();
    formdata.Description = $("#Description").val();
    formdata.Body = $('.textarea').val();
    formdata.KeyWord = $("#tags").val();
    formdata.PublishDate = $('#filter-date').val();
    formdata.IsActive = $("#IsActive").is(':checked');
    formdata.SubcategoryId = $("#SubcategoryId").val();
    formdata.NewsType = $('input[name=NewsType]:checked', '#editform').val();
    formdata.NewsSubcategoryId = $("#NewsSubcategoryId").val();

    $.ajax({
        type: "POST",
        url: "/admin/News/Edit",
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: {
            __RequestVerificationToken: token,
            News: formdata,
            NewsFileAddress: newsFileAddress
        },

        success: function (data) {     
            if (data.data == "1") {
                
                if (data.existfile) {
                    $("#uploadfileholder").empty();
                    $("#uploadfileholder").append("<a href=/admin/News/GenerateFile/?filename=" + data.existfilename + " id='filedownloadlink'>" + data.existfilename + "</a>"
                        +

                        "<img src='/PanelFile/Icons/deletefileicon.png' style='width:25px;'  DeleteNewsFile('" + data.existfilename + "','" + data.fileId+"')  id='deletefile' />")                   
                }
                else {
                    $("#uploadfileholder").empty();
                }
                alert("تغییرات با موفقیت انجام شد")
            }
            else {
                alert("fail1")
            }

        },
        error: function (ex) {
            alert(ex);
        }
    });


})


// Delete news
var DeleteNews = function (newsid) {

    var deleteconfirm = confirm("از حذف خبر مطمئن هستید؟");
    if (deleteconfirm) {
        $.ajax(
            {
                type: "GET",
                url: "/admin/News/Delete",
                data: { id: newsid },
                success: function (data) {
                    if (data) {
                        alert("حذف شد!");
                        window.location.href = "/admin/News/Index";

                    }
                }
                ,
                error: function (ex) {
                    alert(ex);
                }

            }

        )
    }
}



$("#submitcommentform").click(function () {
    if ($("#commentForm").valid()) {
        $.ajax({
            type: "POST",
            url: "/Comment/Insert",
            data: {
                Description: $("#Description").val(),
                Name: $("#Name").val(),
                Email: $("#Email").val(),
                NewsId: $("#NewsId").val()

            },
            datatype: "json",
            success: function (data) {


                var result = JSON.parse(data);
                $("#resultofsendcomment").text(result.message)
            },
            error: function (ex) {
                alert(ex);
            }
        });
    }



})

$("#registernewsletter").click(function () {
    if ($("#newsletterForm").valid()) {
        $.ajax({
            type: "POST",
            url: "/NewsLetter/Create",
            data: {
                Email: $("#newsletterForm #Email").val(),


            },
            datatype: "json",
            success: function (data) {


                var result = JSON.parse(data);
                $("#newsletterregisterresult").text(result.message)
            },
            error: function (ex) {
                alert(ex);
            }
        });
    }



})
$("#newsletter-submit").click(function () {
    if ($("#footernewsletterForm").valid()) {
        $.ajax({
            type: "POST",
            url: "/NewsLetter/Create",
            data: {
                Email: $("#footernewsletterForm #Email").val(),


            },
            datatype: "json",
            success: function (data) {


                var result = JSON.parse(data);
                $("#resultoffooternewsletter").text(result.message)
            },
            error: function (ex) {
                alert(ex);
            }
        });
    }



})

$("#submitcontactus").click(function () {
    if ($("#contactForm").valid()) {
        $.ajax({
            type: "POST",
            url: "/Contact/Create",
            data: {
                Description: $("#Description").val(),
                Name: $("#Name").val(),
                Email: $("#Email").val()


            },
            datatype: "json",
            success: function (data) {


                var result = JSON.parse(data);
                $("#resultofconactus").text(result.message)
            },
            error: function (ex) {
                alert(ex);
            }
        });
    }



})


