(function () {
    String.prototype.padLeft = function (padString, length) {
        var str = this;
        while (str.length < length)
            str = padString + str;
        return str;
    };

    String.prototype.unPadLeft = function (padChar, minLength) {
        var str = this;
        while (str.charAt(0) === padChar && str.length > minLength) {
            str = str.substr(1, str.length);
        }
        return str;
    };
})();