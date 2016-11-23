function solve(args){
    var input=args;
    var people=[];
    var step=3;

    for(var i=0; i<input.length;i+=step){
        people.push({
                firstName: input[i] + '',
                lastName: input[i + 1] + '',
                age: +input[i + 2]
            }
        );
    }

    var youngest=people.reduce(function (a,b) {
        return a.age<=b.age ? a:b;
    })
console.log(youngest.firstName+' '+youngest.lastName);
}
