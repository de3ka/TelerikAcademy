function solve(args) {
  var numberA = +args[0];
  var numberB = +args[1];

  if (numberA > numberB) {
    var temp = numberA;
    numberA = numberB;
    numberB = temp;
  }

  console.log(numberA + " " + numberB);
}
