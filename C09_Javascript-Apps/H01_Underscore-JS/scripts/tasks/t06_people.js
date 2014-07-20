/// <reference path='../libs/underscore-min.js" />

(function () {
    var Person = (function () {
        function Person(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        return Person;
    })();

    var people = [
        new Person("Georgi", "Bakalov"),
        new Person("Dancho", "Traikov"),
        new Person("Mincho", "Traikov"),
        new Person("Georgi", "Georgiev"),
        new Person("Radko", "Manolov"),
        new Person("Nikolay", "Georgiev"),
        new Person("Georgi", "Slavkov"),
        new Person("Mincho", "Georgiev"),
        new Person("Georgi", "Manolov")
    ];

    function mostCommon(array, type) {
        var result = _.chain(array)
            .groupBy(type)
            .sortBy('length')
            .last()
            .value();        
        return result[0][type];
    }

    console.log("\n\n-------------People:-------------");
    console.dir(people);
    console.log("---------Task 6 - Most common name---------");
    console.log("First name: " + mostCommon(people, "firstName"));
    console.log("Last name: " + mostCommon(people, "lastName"));
})();