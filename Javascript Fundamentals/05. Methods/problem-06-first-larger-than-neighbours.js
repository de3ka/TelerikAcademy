function FirstLargerThanNeighbours(args) {
    var arrLength=+args[0],
    array=args[1].split(' ').map(Number),
    index=-1;

    for(var i=1; i<arrLength-1;i+=1){
        if(array[i]>array[i+1] && array[i]>array[i-1]) {
            index=i;
            return index;
        }
    }
}
