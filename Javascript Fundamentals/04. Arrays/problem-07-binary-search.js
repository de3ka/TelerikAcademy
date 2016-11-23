function solve(args){
    var input=args[0].split('\n');
    var n = +input[0];
    var elemToSearch=+input[input.length-1];
    var numbers = input.slice(1);
    var index;
    var found=false;

    for(var i=0;i<numbers.length-1;i+=1){
        if(+numbers[i]===elemToSearch) {
            index = +i;
            found=true;
        }
    }
    if(found){
        console.log(index);
    }else {
        console.log('-1');
    }
}
