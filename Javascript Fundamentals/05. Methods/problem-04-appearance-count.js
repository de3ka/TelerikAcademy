function appearanceCount(args) {

        var arrayLength = args[0],
        array = args[1].split(' ').map(Number),
        x = args[2];

    return countAppearance(array, arrayLength, x);

    function countAppearance(array, arrLength, x) {
        var counter = 0,
            i;

        for (i = 0; i < arrLength; i += 1) {
            if (+array[i] === +x) {
                counter += 1;
            }
        }

        return counter;
    }
}
