/// <reference path='../libs/underscore-min.js" />

(function () {
    var Book = (function () {
        function Book(title, author) {
            this.title = title;
            this.author = author;
        }

        return Book;
    })();

    var books = [
        new Book("Cold Days", "Jim Butcher"),
        new Book("Ten Little Niggers", "Agatha Christie"),
        new Book("The Lord of the Rings", "J. R. R. Tolkin"),
        new Book("Words of Radiance", "Brandon Sanderson"),
        new Book("Turn Coat", "Jim Butcher"),
        new Book("East of Eden", "John Steinbeck"),
        new Book("Of Mice and Men", "John Steinbeck"),
        new Book("The Pale Horse", "Agatha Christie"),
        new Book("Changes", "Jim Butcher")
    ];

    function mostProlificAuthor(array) {
        var result = _.chain(array)
            .groupBy('author')
            .sortBy('length')
            .last()
            .value();
        return result[0].author;
    }

    console.log("\n\n-------------Books:-------------");
    console.dir(books);
    console.log("---------Task 5 - Most prolific author---------");
    console.log(mostProlificAuthor(books));
})();