function solve(args) {
  var xCoordinate=+args[0];
  var yCoordinate=+args[1];
  var radius=2;
  var distance;
  var diameter;
  var radiusSquare;
  distance = Math.pow(xCoordinate, 2) + Math.pow(yCoordinate, 2);
  radiusSquare=Math.pow(radius,2);
  distanceFromCenter = Math.sqrt(distance);
  if (radiusSquare >= distance) {
    console.log("yes "+distanceFromCenter.toFixed(2));
  }else {
    console.log("no "+distanceFromCenter.toFixed(2));
  }
}
