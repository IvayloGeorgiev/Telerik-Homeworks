function domModule() {
    var buffer = {};

    function appendChild(element, selector) {        
        var parent = document.querySelector(selector);
        parent.appendChild(element);
    }

    function removeChild(parentSelector, childSelector) {        
        var parent = document.querySelector(parentSelector),
            child = parent.querySelector(childSelector);

        parent.removeChild(child);
    }

    function addHandler(selector, action, logic) {        
        var element = document.querySelector(selector);

        element.addEventListener(action, logic);
    }

    function appendToBuffer(parentSelector, element) {        
        if (buffer.parentSelector) {
            buffer.parentSelector.appendChild(element);
            if (buffer.parentSelector.childNodes.length >= 100) {
                var parent = document.querySelector(parentSelector);                
                parent.appendChild(buffer.parentSelector);
                buffer.parentSelector = document.createDocumentFragment();
            }
        } else {            
            buffer.parentSelector = document.createDocumentFragment();
            buffer.parentSelector.appendChild(element);            
        }        
    }

    function cssSelector(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        cssSelector: cssSelector
    }
}