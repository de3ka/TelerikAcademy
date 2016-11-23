function CountBrackets(str) {
    var input = String(str);
    var openBracket = 0;
    var closeBracket = 0;

    // Count open brackets.
    var index = input.indexOf('(');
    while (index >= 0) {
        openBracket += 1;
        index = input.indexOf('(', index + 1);
    }

    // Count close brackets.
    index = input.indexOf(')');
    while (index >= 0) {
        closeBracket += 1;
        index = input.indexOf(')', index + 1);
    }
var output;
    // Output
    if (openBracket === closeBracket) {
       output= 'Correct';
    } else {
        output= 'Incorrect';
    }
    console.log(output);
}
