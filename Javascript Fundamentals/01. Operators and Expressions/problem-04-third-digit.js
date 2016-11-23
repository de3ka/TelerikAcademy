function solve(args) {
    var number = +args[0];
    var digit = number / 100;
    digit = digit % 10 - 0.5;
    digit = Math.round(digit);
    if (digit === 7) {
        console.log("true");
    } else {
        console.log("false " + digit);
    }
}
