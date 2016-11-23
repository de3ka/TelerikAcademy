function solve(args) {
    var number = +args[0];
    var position = 3;
    var mask;
    var bit;

    mask = 1 << position;
    number = number & mask;
    bit = number >> position;
    console.log(bit);
}
