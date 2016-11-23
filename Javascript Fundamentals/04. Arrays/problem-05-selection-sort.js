function solve(args){
    var input=args[0].split('\n');
    var n=+input[0];
    var arr=[];
    arr[n-1]=undefined;
    var temp;
    var reversed = [];
    var len;

    for(var i=1; i<input.length;i+=1){
        arr[i-1]=+input[i];
    }

    for(var i=0;i<arr.length;i+=1){
        for(var j=0; j<arr.length; j+=1){
            if(arr[j]<arr[i]){
                temp=arr[i];
                arr[i]=arr[j];
                arr[j]=temp;
            }
        }
    }

    for (i = 0, len = arr.length; i < len; i += 1) {
        j = len - i - 1;
        reversed.push(arr[j]);
    }

    console.log(reversed.join('\n'))
}
