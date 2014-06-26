function specialConsole() {
    function writeLine() {
        if (arguments.length > 1) {
            writeWithFormat(arguments);
        } else {
            writeWithoutFormat(arguments[0]);
        }
    }

    function writeError() {
        if (arguments.length > 1) {
            writeWithFormat(arguments);
        } else {
            writeWithoutFormat(arguments[0]);
        }
    }

    function writeWarning() {
        if (arguments.length > 1) {
            writeWithFormat(arguments);
        } else {
            writeWithoutFormat(arguments[0]);
        }
    }

    function writeWithFormat(stringFormat) {
        var text = stringFormat[0],
            pattern = /{(\d+)}/g;
        
        var formatedText = text.replace(pattern, function (match, number) {
            num = parseInt(number, 10);            
            return (typeof (stringFormat[num + 1]) != 'undefined') ? stringFormat[num + 1] : match;
        })
        console.log(formatedText);
    }

    function writeWithoutFormat(message) {
        console.log(message);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
}