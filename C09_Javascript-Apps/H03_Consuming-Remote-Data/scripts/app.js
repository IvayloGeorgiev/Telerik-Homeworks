/// <reference path="libs/require.js" />

(function () {
    require.config({
        paths: {
            jquery: 'scripts/libs/jquery-2.1.1.min',
            httpRequests: 'scripts/src/httpRequests',
            client: 'scripts/src/client'
        }
    });

    require(['client'], function (client) {
        client.start();
    });
}());