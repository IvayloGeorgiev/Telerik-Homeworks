var GameLogic = (function () {
    var Logic = function Logic() {
        this.number = [];
    };

    function GetRandomNumber(low, high) {
        var number = Math.floor((Math.random() * high) + low);        
        return number;
    }

    function checkRams(actual, guess) {
        var rams = 0;
        for (var i = 0, length = actual.length; i < length; i++) {
            if (actual[i] === guess[i]) {
                rams += 1;
            }
        }
        return rams;
    }

    function checkSheep(actual, guess) {
        var sheep = 0;
        for (var i = 0, length = actual.length; i < length; i++) {
            for (var j = 0; j < length; j++) {
                if (i !== j && actual[i] === guess[j]) {
                    sheep++;
                }
            }
        }
        return sheep;
    }

    Logic.prototype = {
        generateNumber: function () {
            var array = [],
                numIndex,
                availableNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            while (array.length < 4) {
                numIndex = GetRandomNumber(0, availableNumbers.length);
                array.push(availableNumbers[numIndex]);
                availableNumbers.splice(numIndex, 1);
            }
            this.number = array;
        },

        checkGuess: function (guess) {
            var rams = checkRams(this.number, guess);
            var sheep = checkSheep (this.number, guess);
            return {
                sheep: sheep,
                rams: rams
            };
        }       
    };

    return Logic;
})();