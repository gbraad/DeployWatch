var sites = ["google.com", "baidu.com"];

$.each(sites, function(index, value) {
    $.get("/site/" + value, function (data) {
        $("#siteTemplate").tmpl(data).appendTo("#sites");
    });
});
