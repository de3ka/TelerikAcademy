function solve(args) {
    var number = +args[0],
        index = 2,
        isPrime = true;

    if (number <= 1) {
        console.log("false");
    } else if (number <= 3) {
        console.log("true");
    } else if (number % 2 === 0 || number % 3 === 0) {
        console.log("false");
    } else {
        while (index * index <= number) {
            if (number % index === 0) {
                isPrime = false;
            }

            index++;
        }
        if (isPrime) {
            console.log("true");
        } else {
            console.log("false");
        }
    }
}
