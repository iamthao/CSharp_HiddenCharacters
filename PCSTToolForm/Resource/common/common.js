'use strict';
var common = {
    decodeObject :function decodeObject(obj) {
                        for (var key in obj) {
                            if (obj[key] != null && typeof obj[key] == "string") {
                                obj[key] = decodeHTMLEntities(obj[key].toString());
                            }
                        }
                    return obj;
    },
    checkAndSetWidthPopup: function checkAndSetWidthPopup(popup) {
        popup.setOptions({
            width: popup.options.width > $(window).width() - 30 ? $(window).width() - 30 : popup.options.width
        });
    }

};

function decodeHTMLEntities(text) {
    var entities = [
        ['amp', '&'],
        ['apos', '\''],
        ['#x27', '\''],
        ['#x2F', '/'],
        ['#39', '\''],
        ['#47', '/'],
        ['lt', '<'],
        ['gt', '>'],
        ['nbsp', ' '],
        ['quot', '"']
    ];

    for (var i = 0, max = entities.length; i < max; ++i)
        text = text.replace(new RegExp('&' + entities[i][0] + ';', 'g'), entities[i][1]);

    return text;
}

