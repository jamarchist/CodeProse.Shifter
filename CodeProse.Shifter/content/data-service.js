var CodeProse = CodeProse || {};
CodeProse.Shifter = CodeProse.Shifter || {};
CodeProse.Shifter.Resources = CodeProse.Shifter.Resources || {};

CodeProse.Shifter.Resources.add = function(resourceUrl, newResource, onSuccess) {
    $.ajax({
        type: "POST",
        url: "/shifter" + resourceUrl,
        data: JSON.stringify(newResource),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: function (msg) {
            console.log(msg);
        }
    });
};

CodeProse.Shifter.Resources.del = function(resourceUrl, onSuccess) {
    $.ajax({
        type: "DELETE",
        url: "/shifter" + resourceUrl,
        data: "",
        contentType: "application/json; charset=utf-8",
        success: onSuccess,
        error: function(msg) {
            console.log(msg);
        }
    });
};

CodeProse.Shifter.Resources.get = function (resourceUrl, onSuccess) {
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