/// <reference path="libs/jquery-2.1.1.min.js" />
/// <reference path="libs/sammy-latest.min.js" />
/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="logic.js" />

var main = Sammy('#sammy-main', function () {
    this.get('#/', function () {
        $('#sammy-main').empty();
        var context = $('<h1>').html('Welcome to the chatagedon!');
        context.appendTo('#sammy-main');
    });
    this.get('#/Chat', function () {
        function onPostClick() {
            var user = $('.post-user').val(),
                text = $('.post-text').val();
            logic.postToChat({ user: user, text: text });
            
        }
        $('<div>').addClass('chat-holder').appendTo('#sammy-main');
        var $postOn = $('<div>').addClass('post-holder');
        $('<label>').attr('for', 'post-user').text('User').appendTo($postOn);
        $('<input>').addClass('post-user').attr('name', 'post-user').appendTo($postOn);
        $('<br>').appendTo($postOn);
        $('<label>').attr('for', 'post-text').text('Text').appendTo($postOn);
        $('<textarea>').addClass('post-text').attr('name', 'post-text').appendTo($postOn);
        $('<button>').addClass('post-button').text('post').css('type', 'button').on('click', onPostClick).appendTo($postOn);        
        $postOn.appendTo('#sammy-main');

        logic.loadChat();        
    });
    this.get('#/About', function () {
        $('#sammy-main').empty();
        var context = $('<h1>').html('Some random stuff about the page should be here.');
        context.appendTo('#sammy-main');
    });
});

main.run('#/');