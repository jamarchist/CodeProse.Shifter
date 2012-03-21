var CodeProse = CodeProse || {};
CodeProse.Shifter = CodeProse.Shifter || {};
CodeProse.Shifter.Data = CodeProse.Shifter.Data || {};

CodeProse.Shifter.Data.addMember = function(newMember, onSuccess) {
    $.ajax({
        type: "POST",
        url: "/shifter/members/",
        data: JSON.stringify(newMember),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: function (msg) {
            console.log(msg);
        }
    });
};

CodeProse.Shifter.Data.getMembers = function(onSuccess) {
    $.ajax({
        type: "GET",
        url: "/shifter/members/",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: function(msg) {
            console.log(msg);
        }
    });
};

CodeProse.Shifter.Data.deleteMember = function(identifier, onSuccess) {
    $.ajax({
        type: "DELETE",
        url: "/shifter/members/" + identifier,
        data: "",
        contentType: "application/json; charset=utf-8",
        success: onSuccess,
        error: function(msg) {
            console.log(msg);
        }
    });
};

CodeProse.Shifter.Data.get = function (resourceUrl, onSuccess) {
    $.ajax({
        type: "GET",
        url: '/shifter' + resourceUrl,
        data: "",
        contentType: "application/json; charset=utf-8",
        success: onSuccess,
        error: function (msg) {
            console.log(msg);
        },
        async: false
    });
}