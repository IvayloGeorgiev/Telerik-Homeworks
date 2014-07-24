/// <reference path="libs/jquery-2.1.1.min.js" />
/// <reference path="libs/underscore.js" />
/// <reference path="gameLogic.js" />

(function () {
    var RAM_AND_SHEEP_GAME = 'RamAndSheepGame';
    var highScores = loadHighScores();
    var logic = new GameLogic();
    var score = 100;        
    logic.generateNumber();
    console.log(logic.number);
    $('.get-user-input').on('click', onGuessButtonClick);
    $('.get-username').on('click', onSubmitUsernameClick);
    displayHighScores();

    function loadHighScores() {        
        var scores = JSON.parse(localStorage.getItem(RAM_AND_SHEEP_GAME)) || [];                        
        return scores;
    }

    function saveHighScores() {
        for (var i = 0, length = highScores.length; i < length; i++) {
            localStorage.setItem(RAM_AND_SHEEP_GAME, JSON.stringify(highScores));
        }
    }

    function addScore(nickname) {
        var result = {
            nickname: nickname,
            score: score
        };        
        highScores.push(result);        
        _.sortBy(highScores, 'score').reverse();
    }

    function onGuessButtonClick() {
        $this = $(this);        
        var guessAsString = $('.input-field').val();        
        if (validateInput(guessAsString)) {
            var guess = [];
            for (var i = 0, length = guessAsString.length; i < length; i++) {
                guess.push(parseInt(guessAsString[i]));
            }
            var guessResult = logic.checkGuess(guess);
            if (guessResult.rams === 4) {
                $('.username-div').css('display', 'block');
                $('.final-score').html('Final score: ' + score);
                $('.user-input').css('display', 'none');
            } else {                
                var listContainer = $('.guesses-list');
                listContainer.prepend(generateGuessContainer(guess, guessResult));
                score -= 1;
            }
        }
    }

    function onSubmitUsernameClick(){
        var nick = $('.username-field').val();        
        if (nick.length > 3) {            
            addScore(nick);
            saveHighScores();
            $('.username-div').css('display', 'none');
            $('.game-over').css('display', 'block');
        }        
    }

    function validateInput(string){
        if (string.length !== 4){
            return false;
        } else if (isNaN(string)){
            return false;
        } else if (string[0] === '0'){
            return false;
        } 
        for (var i = 0, length = string.length; i < length; i++) {           
            if (isNaN(string[i])){
                return false;
            }
        }
        return true;
    }

    function displayHighScores() {        
        $('.high-scores-list').empty();        
        highScores = _.sortBy(highScores, 'score').reverse();        
        
        for (var i = 0, length = highScores.length; i < length; i++){            
            $('.high-scores-list').append(generateHighScoreContainer(highScores[i]));
        }
    }

    function generateHighScoreContainer(item) {        
        return $('<li>').html(item.nickname + ' - ' + item.score).addClass('score-item');
    }

    function generateGuessContainer(guess, guessResult) {        
        var result = $('<li>').addClass('guess-item');
        $('<div>').html(guess.join(',')).appendTo(result);
        $('<div>').html('Rams - ' + guessResult.rams + '; Sheep - ' + guessResult.sheep).appendTo(result);
        return result;
    }
})();