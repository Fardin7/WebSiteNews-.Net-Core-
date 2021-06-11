function setttrend(id) {
  
 
        $.ajax({
            type: "post",
            url: "/admin/Setting/SetTrendingNews",
            data: { newsid:id},
            success: function (data) {
                if (data) {
                    alert(data);
                    if ($("#" + id).hasClass("btn-danger")) {
                        $("#" + id).removeClass("btn-danger");
                        $("#" + id).addClass("btn-success");
                        $("#" + id).val("trending")
                    }
                    else {
                        $("#" + id).addClass("btn-danger");
                        $("#" + id).removeClass("btn-success");
                        $("#" + id).val("trended")
                    }
                }
            },
            error: function (ex) {

            }
        });
}