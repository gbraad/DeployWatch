var sites = ["google.com", "baidu.com"];

$.map(sites, function(value) {
    $.get("/site/" + value, function (data) {
        $("#siteTemplate").tmpl(data).appendTo("#sites");
    });
});
