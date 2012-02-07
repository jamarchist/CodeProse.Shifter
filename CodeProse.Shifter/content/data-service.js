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
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: function (msg) {
            console.log(msg);
        }
    });    
}