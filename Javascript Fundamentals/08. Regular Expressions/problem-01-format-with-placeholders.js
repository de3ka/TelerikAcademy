function solve (text) {
    var obj = JSON.parse(text[0]);
    var str = String(text[1]);
    String.prototype.format = function (obj) {
        var placeholder,
            _this = this;

        for (var prop in obj) {
            placeholder = new RegExp('#{' + prop + '}', 'g');
            _this = _this.replace(placeholder, obj[prop]);
        }

        return _this;
    };

console.log(str.format(obj));
}
