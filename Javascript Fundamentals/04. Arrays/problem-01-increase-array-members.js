function solve(args) {
    var num=+args[0];
    var arr=[];
    arr[num-1]=undefined;

    for (var i=0; i<arr.length; i+=1){
        arr[i]=i*5;
        console.log(arr[i]);
    }
}
