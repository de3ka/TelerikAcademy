function solve(args) {
    var params = args[0].split('\n');
    var n = +params[0];
    var arr = [];
    var maxSeq = 0;
    var seqNow = 0;
    var i;
    arr[n-1] = undefined;

    for (i = 1; i < params.length; i++) {
         arr[i-1] = +params[i];
    }
    for (i = 1; i < arr.length; i++) {
         if (arr[i] === arr[i-1]) {
             seqNow++;
             if (seqNow > maxSeq) {
                 maxSeq = seqNow;
             }
         } else {
             seqNow = 0;
         }
    }
    console.log(maxSeq+1);
}
