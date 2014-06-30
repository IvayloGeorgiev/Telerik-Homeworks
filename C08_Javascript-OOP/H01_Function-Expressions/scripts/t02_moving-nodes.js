function movingShapes() {
    var shapes = [],
        lastTime,
        now,
        delta,
        ELLIPSE_X_RADIUS = 160,
        ELLIPSE_Y_RADIUS = 40,
        RECTANGLE_X_LENGTH = 140,
        RECTANGLE_Y_LENGTH = 120,
        ELEMENT_HEIGHT = 20,
        ELEMENT_WIDTH = 80;

    function add(type) {
        var element = generateDivElement(),
            top,
            left;
        
        if (type.toLowerCase() === 'rect') {
            top = getRandomNumber(0, window.innerHeight - (RECTANGLE_Y_LENGTH + ELEMENT_HEIGHT + 7)); //the extra 7 is for the border width too lazy to add it as constant.
            left = getRandomNumber(0, window.innerWidth - (RECTANGLE_X_LENGTH + ELEMENT_WIDTH + 7));
            element.style.top = top + 'px';
            element.style.left = left + 'px';

            shapes.push({
                element: element,
                type: type.toLowerCase(),
                change: [RECTANGLE_X_LENGTH, 0],
                originalX: left,
                originalY: top,
                currentX: left,
                currentY: top
            });
        } else if (type.toLowerCase() === 'ellipse') {
            top = getRandomNumber(ELLIPSE_Y_RADIUS, window.innerHeight - (ELLIPSE_Y_RADIUS + ELEMENT_HEIGHT + 7));
            left = getRandomNumber(ELLIPSE_X_RADIUS, window.innerWidth - (ELLIPSE_X_RADIUS + ELEMENT_WIDTH + 7));
            element.style.top = top + 'px';
            element.style.left = left + 'px';
			element.style.borderRadius = '30px';

            shapes.push({
                element: element,
                type: type.toLowerCase(),                
                originalX: left,
                originalY: top,
                theta: Math.PI
            });
        } else {
            console.log('Invalid element movement type.');
            return;
        }
        
        document.body.appendChild(element);
    }

    function update() {
        now = Date.now();
        delta = (now - lastTime) / 1000;
        for (var i = 0, length = shapes.length; i < length; i++) {
            if (shapes[i].type === 'rect') {
                moveRect(shapes[i]);
            } else if (shapes[i].type === 'ellipse') {
                moveEllipse(shapes[i]);
            }
        }
        lastTime = now;        
        requestAnimationFrame(update);
    }

    function moveEllipse(shape) {
        var element = shape.element,
            theta = shape.theta,
            centerX = shape.originalX,
            centerY = shape.originalY,
            x,
            y;

        theta += (Math.PI) * delta;        
        x = Math.floor(centerX - ELLIPSE_X_RADIUS * Math.sin(theta));
        y = Math.floor(centerY + ELLIPSE_Y_RADIUS * Math.cos(theta));
        element.style.top = y + 'px';
        element.style.left = x + 'px';
        shape.theta = theta;
    }

    function moveRect(shape) {
        var element = shape.element,            
            x = shape.currentX,
            y = shape.currentY;
        
        x += shape.change[0] * delta;
        y += shape.change[1] * delta;
        if (x >= shape.originalX + RECTANGLE_X_LENGTH && shape.change[0] > 0) { //Stop right movement, go down
            x = shape.originalX + RECTANGLE_X_LENGTH;
            shape.change[0] = 0;
            shape.change[1] = RECTANGLE_Y_LENGTH;
        } else if (y >= shape.originalY + RECTANGLE_Y_LENGTH && shape.change[1] > 0) { //Stop down movement, go left
            y = shape.originalY + RECTANGLE_Y_LENGTH;
            shape.change[0] = -RECTANGLE_X_LENGTH;
            shape.change[1] = 0;
        } else if (x <= shape.originalX && shape.change[0] < 0) { //Stop left movement, go up
            x = shape.originalX;
            shape.change[0] = 0;
            shape.change[1] = -RECTANGLE_Y_LENGTH;
        } else if (y <= shape.originalY && shape.change[1] < 0) { //Stop up movement, go right
            y = shape.originalY;
            shape.change[0] = RECTANGLE_X_LENGTH;
            shape.change[1] = 0;
        }

        element.style.top = y + 'px';
        element.style.left = x + 'px';
        shape.currentX = x;
        shape.currentY = y;
    }

    function generateDivElement(){
        var element = document.createElement('div');
        element.style.border = '4px solid black';        
        element.style.color = getRandomColor();
        element.style.background = getRandomColor();        
        element.style.borderColor = getRandomColor();        
        element.style.width = ELEMENT_WIDTH + 'px';
        element.style.height = ELEMENT_HEIGHT + 'px';
        element.style.display = 'inline-block';
        element.style.position = 'absolute';
        element.innerHTML = 'div';        
        return element;
    }

    function getRandomNumber(low, high) {
        var random = Math.floor((Math.random() * (high - low + 1)) + low);
        return random;
    }

    function getRandomColor() {
        var red = getRandomNumber(0, 255),
            green = getRandomNumber(0, 255),
            blue = getRandomNumber(0, 255),
            color = 'rgb(' + red + ', ' + green + ', ' + blue + ')';
        return color;
    }

    lastTime = Date.now();
    requestAnimationFrame(update);

    return {
        add: add
    }
}