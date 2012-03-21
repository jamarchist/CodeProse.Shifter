(function ($) {
    $(document).ready(function () {
        $('.number-picker').each(function () {
            var picker = $(this);
            var max = picker.data('maximum');
            var min = picker.data('minimum');

            var number = picker.children(':input').first();
            var incrementor = number.next();
            var decrementor = incrementor.next();

            var setNumber = function (newVal) {
                var newDisplayValue = newVal.toString().padLeft('0', 2);
                number.val(newDisplayValue);
            };

            var getNumber = function () {
                return parseInt(number.val().unPadLeft('0', 1));
            };

            if (number.val() === '') {
                setNumber(min);
            }

            incrementor.click(function () {
                var current = getNumber();

                if (current === max) {
                    current = min;
                } else {
                    current++;
                }

                setNumber(current);
            });

            decrementor.click(function () {
                var current = getNumber();

                if (current === min) {
                    current = max;
                } else {
                    current--;
                }

                setNumber(current);
            });
        });
    });

    $.fn.number = function () {
        return this.children(':input').first().val();
    };

})(jQuery);