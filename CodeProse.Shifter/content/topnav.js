var user; // global

$(function () {
    user = { name: "Raul Aso" }; // get from cookie

    $('<div id="topnav" class="ui-widget-header">' +
            '<a href="default">Home</a> ' +
            '<a href="view-calendar">Calendar</a> ' +
            '<a href="manage-shifts">Shifts</a> ' +
            '<a href="manage-members">Members</a> ' +
            '<a href="assign-shifts">Schedule</a>' +
            '</div>')
        .append($('<div id="user" />').text(user.name))
        .prependTo("body");
});