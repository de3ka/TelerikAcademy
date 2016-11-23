function largerThanNeighbours(args) {
    var arrayLength = args[0],
        array = args[1].split(' ').map(Number);

    return neighboursChecker(array, arrayLength);

    function neighboursChecker(sequence, arrLength) {
        var counter = 0,
            i;
        for (i = 1; i < arrLength - 1; i++) {
            if (sequence[i - 1] < sequence[i] && sequence[i + 1] < sequence[i]) {
                counter += 1;
            }
        }

        return counter;
    }
}
