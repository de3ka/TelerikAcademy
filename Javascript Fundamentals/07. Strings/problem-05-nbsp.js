function solve(args) {
    var input=String(args[0]);
    var replace='&nbsp;';
    var output=input.split(' ').join(replace);

    console.log(output);

}
