/// <reference path="../libs/jquery-2.1.1.min.js" />
/// <reference path="../libs/require.js" />

define(['jquery'], function ($) {
    function getJSON(url, success, error, headers) {
        $.ajax({
            url: url,
            type: 'GET',
            contentType: 'application/json',
            success: success,
            error: error,
            headers: headers
        });
    }

    function postJSON(url, data, success, error, headers) {
        $.ajax({
            url: url,
            type: 'POST',
            data: data,
            success: success,
            error: error,
            headers: headers
        });
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON
    };
});