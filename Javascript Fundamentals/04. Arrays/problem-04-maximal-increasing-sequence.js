function solve(args){
    var input= args[0].split('\n');
    var n= +input[0];
    var arr=[];
    arr[n-1]=undefined;
    var maxSequence=1;
    var currentSequence=1;

    for(var i=1; i<input.length;i+=1){
        arr[i-1]=+input[i];
    }
    for(var i=1;i<arr.length;i+=1){
        if(arr[i]>arr[i-1]){
            currentSequence++;
            if(currentSequence>maxSequence){
                maxSequence=currentSequence;
            }
        }else{
            currentSequence=1;
        }
    }
console.log(maxSequence);

}
