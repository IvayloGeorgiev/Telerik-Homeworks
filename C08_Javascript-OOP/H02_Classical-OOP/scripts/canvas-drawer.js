function CanvasDrawer(container, width, height) {
    var canvasContainer = document.querySelector(container),
        canvas = document.createElement('canvas');
    canvas.width = width || 600;
    canvas.height = height || 400;
    canvasContainer.appendChild(canvas);
        
    this._ctx = canvas.getContext('2d');
    this._ctx.fillStyle = 'lightgreen';
    this._ctx.strokeStyle = 'black';
    this._ctx.lineWidth = '3';
}

CanvasDrawer.prototype = {
    rect: function (x, y, width, height) {
        this._ctx.beginPath();
        this._ctx.fillRect(x, y, width, height);
        this._ctx.strokeRect(x, y, width, height);
    },

    circle: function (x, y, radius) {
        this._ctx.beginPath();
        this._ctx.arc(x, y, radius, 0, 2 * Math.PI);
        this._ctx.fill();
        this._ctx.stroke();
    },

    line: function (x1, y1, x2, y2) {
        this._ctx.beginPath();
        this._ctx.moveTo(x1, y1);
        this._ctx.lineTo(x2, y2);
        this._ctx.fill();
        this._ctx.stroke();
    }
};
