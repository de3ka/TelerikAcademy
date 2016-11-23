function solve(args) {
    var xCoord = +args[0],
        yCoord = +args[1],
        xCircleCoord = 1,
        yCircleCoord = 1,
        radius = 1.5,
        doubleRadius = radius * radius,
        insideCircleFormula,
        isInsideCircle,
        isInsideRectangle,
        rectangleMsg,
        circleMsg;

    insideCircleFormula = ((xCoord - xCircleCoord) * (xCoord -xCircleCoord)) + ((yCoord - yCircleCoord) * (yCoord - yCircleCoord));

        if (doubleRadius >= insideCircleFormula) {
            isInsideCircle = true;
        }

        if (-1 <= xCoord && xCoord <=5 && -1 <= yCoord && yCoord <= 1) {
            isInsideRectangle = true;
        }

        if (isInsideRectangle) {
            rectangleMsg = "inside rectangle";
        }
        else {
            rectangleMsg = "outside rectangle";
        }

        if (isInsideCircle) {
            circleMsg = "inside circle";
        }
        else {
            circleMsg = "outside circle";
        }

        console.log(circleMsg + " " + rectangleMsg);
}
