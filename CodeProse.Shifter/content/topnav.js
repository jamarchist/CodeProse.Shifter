var user; // global

$(function () {
    user = { name: "Raul Aso" }; // get from cookie

    $('<div id="topnav"><a href="default.htm">Home</a> <a href="view-calendar.htm">View</a> <a href="manage.htm">Manage</a></div>')
        .append($('<div id="user" />').text(user.name))
        .prependTo("body");
});