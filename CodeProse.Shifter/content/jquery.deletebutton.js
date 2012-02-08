(function ($) {

    $.fn.deletebutton = function (options) {

        var settings = $.extend({
            icon: "ui-icon-closethick",
            confirm: "Are you sure you want to delete this item?",
            label: "Delete",
            width: "22px",
            height: "22px",
            click: function () { }
        }, options);

        return this.each(function () {

            var $this = $(this);

            $this.append($("<button></button>")
                    .text(settings.label)
                    .button({
                        icons: { primary: settings.icon },
                        text: false
                    }).css({
                        "float": "right",
                        "width": settings.width,
                        "height": settings.height
                    }).click(function () {
                        if (confirm(settings.confirm)) {
                            settings.click();

                            $(this).parent().remove();
                        }
                    }).hide())
                .hover(function () {
                    $(this).children("button").show();
                },
                function () {
                    $(this).children("button").hide();
                });
        });
    };
})(jQuery);