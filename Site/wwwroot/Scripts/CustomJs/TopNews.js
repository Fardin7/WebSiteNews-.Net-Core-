function settbanner() {

    var id = $('input[name=topnews]:checked').val();
 
        $.ajax({
            type: "post",
            url: "/admin/Setting/SetTopNews",
            data: { newsid:id},
            success: function (data) {
                if (data) {
                    alert(data);
                   
                }
            },
            error: function (ex) {

            }
        });
}