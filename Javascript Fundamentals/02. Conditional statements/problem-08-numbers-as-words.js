function solve(args) {
    var number = +args[0];
    var alphabet = ['Zero', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'];
    var result = '';
    if (number >= 0 && number <= 999) {
        switch (number.toString().length) {
            case 1:
                result = alphabet[number];
                break;
            case 3:
                result += alphabet[Math.floor(number / 100)] + ' hundred';
                number = number % 100;
                if (number > 0 && number < 10) {
                    result += ' and ' + alphabet[number].toLowerCase();
                    break;
                }
            case 2:
                if (number === 10) {
                    result += (result === '') ? 'Ten' : ' and ten';
                }
                if (number === 11) {
                    result += (result === '') ? 'Eleven' : ' and eleven';
                }
                if (number === 12) {
                    result += (result === '') ? 'Twelve' : ' and twelve';
                }
                if (number > 12 && number < 20) {
                    result += (result === '') ? alphabet[number % 10] : ' and ' + alphabet[number % 10].toLowerCase();
                    result += 'teen';
                }
                if (number >= 20 && number < 30) {
                    result += (result === '') ? 'Twenty' : ' and twenty';
                    if (number % 10 !== 0) {
                        result += ' ' + alphabet[number % 10].toLowerCase();
                    }
                }
                if (number >= 30 && number < 40) {
                    result += (result === '') ? 'Thirty' : ' and thirty';
                    if (number % 10 !== 0) {
                        result += ' ' + alphabet[number % 10].toLowerCase();
                    }
                }
                if (number >= 40 && number < 50) {
                    result += (result === '') ? 'Forty' : ' and forty';
                    if (number % 10 !== 0) {
                        result += ' ' + alphabet[number % 10].toLowerCase();
                    }
                }
                if (number >= 50 && number < 60) {
                    result += (result === '') ? 'Fifty' : ' and fifty';
                    if (number % 10 !== 0) {
                        result += ' ' + alphabet[number % 10].toLowerCase();
                    }
                }
                if (number >= 80 && number < 90) {
                    result += (result === '') ? 'Eighty' : ' and eighty';
                    if (number % 10 !== 0) {
                        result += ' ' + alphabet[number % 10].toLowerCase();
                    }
                }
                if ((number >= 60 && number < 80) || (number >= 90 && number < 100)) {
                    result += (result === '') ? alphabet[Math.floor(number / 10)] : ' and ' + alphabet[Math.floor(number / 10)].toLowerCase();
                    result += 'ty';
                    if (number % 10 !== 0) {
                        result += ' ' + alphabet[number % 10].toLowerCase();
                    }
                }
                break;
        }
    }
    console.log(result);
}
