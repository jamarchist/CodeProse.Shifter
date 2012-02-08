var user; // global

$(function () {
    user = { name: "Raul Aso" }; // get from cookie

    $('<div id="topnav" class="ui-widget-header"><a href="default">Home</a> <a href="view-calendar">View</a> <a href="assign-shifts">Manage</a></div>')
        .append($('<div id="user" />').text(user.name))
        .prependTo("body");
});