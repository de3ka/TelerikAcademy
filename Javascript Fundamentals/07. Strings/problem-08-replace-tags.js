function solve8_2(args) {
    var text = args[0],
        result = "", i, tag, endTag, endUrl, tagDesc;

    while (text.length > 0) {
        i = text.indexOf('<a href="');
        if (i > -1) {
            result += text.substring(0, i);
            endTag = text.indexOf('">', i);
            tag = text.substring(i + 9, endTag);
            endUrl = text.indexOf('</a>', endTag + 1);
            tagDesc = text.substring(endTag + 2, endUrl);

            result += '[' + tagDesc + '](' + tag + ')';

            text = text.substring(endUrl + 4);
        }
        else {
            result += text;
            text = "";
        }
    }
	console.log(result);
}
