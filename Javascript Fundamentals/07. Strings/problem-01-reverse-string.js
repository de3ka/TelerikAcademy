function solve(args){
    var input=String(args);
    var output='';
    var stringLength=+input.length;

    for(var i=stringLength-1;i>=0;i-=1){
      output+=input[i];
    }
    console.log(output);
}
