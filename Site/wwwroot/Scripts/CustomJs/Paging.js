function paging(newscount, pagenumber, newstype) {

    $.ajax({
        type: "POST",
        url: "/News/NewsPaging?newscount=" + newscount + "&pagenumber=" + pagenumber + "&newstype=" + newstype,
        datatype: "json",
        success: function (data) {
            var model = JSON.parse(data);

            $("#lastnewscontainer").empty();
            var result = '<div class="col-12">'
                +
                '<div class="recent-active dot-style d-flex dot-style" >';
            for (var i = 0; i < model.length; i++) {

                result = ' <div class="single-recent mb-100"> <div class="what-img"><img src="' + model[i].ImageAddress + '" />'

                    +
                    ' </div>'
                    +
                    '<div class="what-cap">'
                    +
                    '<span class="color1">' + model[i].Title + ' </span><h4>'
                    +
                    '<a href=' + model[i].Url + '>' + '</a>'
                    +
                    '  </h4>'
                    +
                    ' </div>'
                    +
                    ' </div>'




            }
            result += ' </div>'
                +
                ' </div>';
            $("#lastnewscontainer").appendTo(result);




        },
        error: function (ex) {

        }
    });

}
function arrowpaging(currentpage, pages, newstype, newscategory) {
    pagingnews(4, currentpage, newstype, newscategory);
    renderpaging(currentpage, pages, newstype, newscategory);
}
function viewpaging(newstype, newscategory) {

    $.ajax({
        type: "POST",
        url: "/NewsCategory/ViewPaging?newstype=" + newstype + "&newscategory=" + newscategory,
        datatype: "json",
        success: function (data) {
            var currentpage = data.pages > 3 ? 3 : data.pages;
            renderpaging(currentpage, data.pages, data.newstype, data.newscategory)
        },
        error: function (ex) {

        }
    });


}
function renderpaging(currentpages, pages, newstype, newscategory) {

    var leftarrow = "";
    var rightarrow = "";

    var rightcounter = currentpages + 1;
    var leftcounter = currentpages - 1;
    if (pages > 3 && currentpages - 2 > 1) {

        leftarrow = '<li  onclick="arrowpaging(' + leftcounter + ',' + pages + ',' + newstype + ',' + newscategory + ')"  class="page-item"><a class="page-link" ><span class="flaticon-arrow roted"></span></a></li>';
    }

    if (pages > 3 && currentpages < pages) {
        rightarrow = '<li  onclick="arrowpaging(' + rightcounter + ',' + pages + ',' + newstype + ',' + newscategory + ')" class="page-item"><a class="page-link" ><span class="flaticon-arrow right-arrow"></span></a></li>';
    }

    $("#pagingcontainer").empty();
    var result =
        '<div class="col-xl-12">'
        +
        '<div class="single-wrap d-flex justify-content-center"  >'
        +

        '<nav aria-label="Page navigation example"   >'
        +
        '<ul class="pagination justify-content-start">'
        +
        leftarrow
    for (var i = (currentpages) < 3 ? 1 : currentpages - 2; i <= currentpages; i++) {

        result += "<li class='page-item' id='" + i + "'><a class='page-link'   onclick='pagingnews(4" + "," + i + "," + newstype + "," + newscategory + ")'>" + i + "</a></li>";

    }

    result += rightarrow
        +
        '</ul>'
        +
        '</nav>'
        +
        '</div>'
        +
        '</div >';

    $("#pagingcontainer").append(result);
    $("#" + currentpages).css("color", "red");

}
function pagingnews(newscount, pagenumber, newstype, newscategory) {
    var previuseitemid = pagenumber - 1;
    var nextitemid = pagenumber + 1;
    $("#" + previuseitemid).removeAttr("style");
    $("#" + nextitemid).removeAttr("style");
    $("#" + pagenumber).css("color", "red");
    $.ajax({
        type: "POST",
        url: "/NewsCategory/PagingNewsOfNewsCategory?newscount=" + newscount + "&pagenumber=" + pagenumber + "&type=" + newstype + "&newscategory=" + newscategory,
        datatype: "json",
        success: function (data) {
            var model = JSON.parse(data);

            $("#" + newscategory).empty();

            var result = '<div class="whats-news-caption"><div class="row" >';

            for (var i = 0; i < model.length; i++) {

                result +=
                    '<div class="col-lg-6 col-md-6">'
                    +
                    ' <div class="single-what-news mb-100">'
                    +
                    '<div class="what-img">'
                    +
                    '<img style="height:370px;width:344.5px; "' + 'src="' + model[i].ImageAddress + '"' + 'alt="' + model[i].Title + '">'
                    +
                    '</div>'
                    +
                    '<div class="what-cap">'
                    +
                    '<span class="color1">'
                    + model[i].Title +
                    '</span>'
                    +
                    '<h4>'
                    +
                    '<a  href="' + model[i].Url + '">'
                    +
                    model[i].Description
                    +
                    '</a>'
                    +
                    '</h4>'
                    +
                    '</div>'
                    +
                    '</div>'
                    +
                    '</div>'
                    ;

            }
            result += '</div></div>';
            $("#" + newscategory).append(result);

        },
        error: function (ex) {

        }
    });

}

function pagingrelatednews(type, categoryname, newscategoryname, count, pagenumber, pagecount) {

    var rightcounter = pagenumber + 1;
    var leftcounter = rightcounter - 2;

    $.ajax({
        type: "POST",
        url: "/News/NewsOfNewsCategoryAndCategoryPaging?type=" + type + "&categoryname=" + categoryname + "&newscategoryname=" + newscategoryname + "&count=" + count + "&pagenumber=" + pagenumber,
        datatype: "json",
        success: function (data) {
            var model = JSON.parse(data);
            if (model.length > 0) {
                $("#relatednews").empty();
                var leftarrow = "";
                var rightarrow = "";
                if (leftcounter >= 1 && leftcounter < pagecount) {
                    leftarrow = '<div  style="cursor:pointer;"     onclick="pagingrelatednews(' + type + ',' + categoryname + ',' + newscategoryname + ',' + count + ',' + leftcounter + ',' + pagecount + ')"' + '  class="col-lg-6 col-md-6 col-12 nav-left flex-row d-flex justify-content-start align-items-center" >'



                }
                else {
                    leftarrow = '<div class="col-lg-6 col-md-6 col-12 nav-left flex-row d-flex justify-content-start align-items-center">'


                }
                if (rightcounter <= pagecount && rightcounter > 1) {
                    rightarrow = '<div style="cursor:pointer;" class="thumb" onclick="pagingrelatednews(' + type + ',' + categoryname + ',' + newscategoryname + ',' + count + ',' + rightcounter + ',' + pagecount + ')"  >'

                }
                else {
                    rightarrow = '<div class="thumb">'
                }
                var result = "";

                result += '<div class="row">'
                    +

                    leftarrow
                    +
                    '<div class="thumb" >'
                    +
                    '<a>'
                    +

                    '<img class="img-fluid" style="width:60px;height:60px;" src="' + model[0].ImageAddress + '" alt="">'
                    +

                    '</a>'
                    +
                    '</div>'
                    +
                    '<div class="arrow">'
                    +
                    '<a>'
                    +
                    '<span class="lnr text-white ti-arrow-left"></span>'
                    +
                    '</a>'
                    +
                    '</div>'
                    +
                    '<div class="detials" >'
                    +
                    '<p>قبل</p>'
                    +
                    '<a href="' + model[0].Url + '">'
                    +
                    '<h4>' + model[0].Title + '</h4>'
                    +
                    '</a>'
                    +
                    '</div>'
                    +
                    '</div >'
                    +
                    '<div class="col-lg-6 col-md-6 col-12 nav-right flex-row d-flex justify-content-end align-items-center">'
                    +
                    '<div class="detials">'
                    +
                    '<p>بعد</p>'
                    +
                    '<a href="' + model[1].Url + '">'
                    +
                    '<h4 >' + model[1].Title + '</h4>'
                    +
                    '</a>'
                    +
                    '</div>'
                    +

                    '<div class="arrow">'
                    +
                    '<a >'
                    +
                    '<span class="lnr text-white ti-arrow-right"></span>'
                    +
                    '</a>'
                    +
                    '</div>'

                    +
                    rightarrow
                    +
                    '<a>'
                    +
                    '<img class="img-fluid" style="width:60px;height:60px;"  src="' + model[1].ImageAddress + '"  alt="">'
                    +
                    '</a>'
                    +
                    '</div >'
                    +
                    '</div >'
                    +
                    '</div >'
                    ;

                $("#relatednews").append(result);

            }

        },
        error: function (ex) {

        }
    });


}
function newsofnewsandnewscategorypaging(type, categoryname, newscategoryname, count, currentpages, pagecount) {


    newsofcategorandnewscategory(count, currentpages, type, newscategoryname, categoryname);
    var rightcounter = currentpages + 1;
    var leftcounter = currentpages - 1;


    $("#newspagingcontiner").empty();
    var leftarrow = "";
    var rightarrow = "";
    if (leftcounter >= 1 && leftcounter < pagecount) {
        leftarrow = '<li   style="cursor:pointer;" class="page-item"  onclick="newsofnewsandnewscategorypaging(' + type + ',' + categoryname + ',' + newscategoryname + ',' + count + ',' + leftcounter + ',' + pagecount + ')">'
            +
            '<a  class="page-link" aria-label="Previous">'
            +
            '<i class="ti-angle-left"></i>'

        '</a>'
            +
            '</li>'
            ;


    }
    else {


        leftarrow = '';
    }
    if (rightcounter <= pagecount && rightcounter > 1) {

        rightarrow = '<li   style="cursor:pointer;" class="page-item"  onclick="newsofnewsandnewscategorypaging(' + type + ',' + categoryname + ',' + newscategoryname + ',' + count + ',' + rightcounter + ',' + pagecount + ')">'
            +
            '<a  class="page-link" aria-label="Next">'
            +
            '<i class="ti-angle-right"></i>'

        '</a>'
            +
            '</li>'
            ;

    }
    else {
        rightarrow = '';
    }
    var result = '<ul class="pagination">';
    result += leftarrow;
    for (var i = (currentpages) < 3 ? 1 : currentpages - 1; i <= currentpages; i++) {

        result += '<li  id="' + i + '" class="page-item" onclick="newsofcategorandnewscategory(' + count + ', ' + i + ', ' + type + ',' + newscategoryname + ', ' + categoryname + ')">'
            +
            '<a  class="page-link">' + i + '</a>'
            +
            '</li>';

    }
    result += rightarrow;
    result += '</ul >';

    $("#newspagingcontiner").append(result);

    $("#newspagingcontiner" + "  #" + currentpages).css("color", "red")


}
function newsofcategorandnewscategory(newscount, pagenumber, newstype, newscategory, category) {
    var previuseitemid = pagenumber - 1;
    var nextitemid = pagenumber + 1;
    $("#" + previuseitemid).removeAttr("style");
    $("#" + nextitemid).removeAttr("style");
    $("#newspagingcontiner" + "  #" + pagenumber).css("color", "red")
    $.ajax({
        type: "POST",
        url: "/News/NewsOfNewsCategoryAndCategoryPaging?count=" + newscount + "&pagenumber=" + pagenumber + "&type=" + newstype + "&categoryname=" + category + "&newscategoryname=" + newscategory,
        datatype: "json",
        success: function (data) {
            var model = JSON.parse(data);

            $("#newsofnewscategoryandcateory").empty();

            var result = '';

            for (var i = 0; i < model.length; i++) {

                result +=
                    '<article class="blog_item">'
                    +
                    '<div class="blog_item_img">'
                    +
                    '<img style="width:770px;height:385px;" class="card-img rounded-0" src="' + model[i].ImageAddress + '" alt="">'

                    +

                    '<a href="' + model[i].Url + '" class="blog_item_date">'

                    +
                    '<h3>تاریخ به فارسی</h3>'
                    +
                    '<p> تاریخ به فارسی</p>'
                    +
                    '</a>'
                    +
                    ' </div>'
                    +

                    '<div class="blog_details">'
                    +
                    '<a class="d-inline-block" href="' + model[i].Url + '">'
                    +
                    '<h2>' + model[i].Title + '</h2 >'
                    +
                    '</a>'
                    +
                    '<p>'
                    +
                    model[i].Description
                    +
                    '</p>'
                    +
                    '<ul class="blog-info-link">'
                    +
                    '<li><a ><i class="fa fa-user"></i>' + model[i].SubCategoryTitle + ',' + model[i].NewsCategoryTitle + '</a ></li >'
                    +
                    '<li><a ><i class="fa fa-comments"></i> 03  بازدید</a></li>'
                    +
                    '</ul>'
                    +
                    '</div>'
                    +
                    '</article>'
                    ;

            }

            $("#newsofnewscategoryandcateory").append(result);

        },
        error: function (ex) {

        }
    });

}