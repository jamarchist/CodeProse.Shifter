var CodeProse = CodeProse || {};
CodeProse.Shifter = CodeProse.Shifter || {};

CodeProse.Shifter.ShifterDate = function(year, month, day, hour, minute) {
    var jsDate = new Date(year, month - 1, hour, minute, 0);
};