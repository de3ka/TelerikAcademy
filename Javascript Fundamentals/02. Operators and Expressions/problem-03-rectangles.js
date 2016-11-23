function solve(args) {
    var width = +args[0];
    var height = +args[1];
    var perimeter = 2 * (width + height);
    var area = width * height;
    console.log(area.toFixed(2) + " " + perimeter.toFixed(2));
}
