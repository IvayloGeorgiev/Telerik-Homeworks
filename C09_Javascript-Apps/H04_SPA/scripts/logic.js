/// <reference path="libs/jquery-2.1.1.min.js" />
/// <reference path="libs/sammy-latest.min.js" />
/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="HTTPRequests.js" />

var logic = (function () {
    var toServer = httpRequests,
        url = 'http://crowd-chat.herokuapp.com/posts';

    function loadChat() {
        function success(data) {            
            $.ajax({                
                url: 'scripts/templates/chat-template.html',
                cache: true,
                success: function (context) {
                    var template = Handlebars.compile(context);
                    var chat = template(data.reverse());
                    $('.chat-holder').html(chat);
                    setTimeout(loadChat, 2000);
                }
            });
        }

        toServer.getJSON(url, success);
    }

    function postToChat(message) {
        toServer.postJSON(url, message);
    }

    return {
        loadChat: loadChat,
        postToChat: postToChat
    };
}());