(function ($) {
    $(document).ready(function () {

    });

    $.fn.time = function () {
        var numbers = this.children('.number-picker');

        var hour = numbers.first().number();
        var minute = numbers.first().next().number();
        var ampm = this.children('select').children('option:selected').val();

        var formatted = function () {
            var minutePart = '';
            if (minute > 0) {
                minutePart = ':' + minute.toString().padLeft('0', 2);
            };

            return hour.toString() + minutePart + ' ' + ampm;
        };

        return {
            hour: hour,
            minute: minute,
            ampm: ampm,
            formatted: formatted
        };
    };
})(jQuery);