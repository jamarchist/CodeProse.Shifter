(function ($) {
    $(document).ready(function () {
        $('.number-picker').each(function () {
            var picker = $(this);
            var max = picker.data('maximum');
            var min = picker.data('minimum');

            var number = picker.children(':input').first();
            var incrementor = number.next();
            var decrementor = incrementor.next();

            if (number.val() === '') {
                number.val(min);
            }

            incrementor.click(function () {
                var current = parseInt(number.val());

                if (current === max) {
                    current = min;
                } else {
                    current++;
                }

                number.val(current);
            });

            decrementor.click(function () {
                var current = parseInt(number.val());

                if (current === min) {
                    current = max;
                } else {
                    current--;
                }

                number.val(current);
            });
        });
    });

    $.fn.number = function () {
        return this.children(':input').first().val();
    };

})(jQuery);