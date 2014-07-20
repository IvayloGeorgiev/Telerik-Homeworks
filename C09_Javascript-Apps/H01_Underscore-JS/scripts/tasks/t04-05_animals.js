/// <reference path='../libs/underscore-min.js" />

(function () {
    var Animal = (function () {
        function Animal(name, species, legs) {
            this.name = name;
            this.species = species;
            this.legs = legs;
        }

        return Animal;
    })();

    var animals = [
        new Animal("Koko", "Mammal", 2),
        new Animal("Simba", "Mammal", 4),
        new Animal("Burn it with fire", "Insect", 100),
        new Animal("Mosquito Killer", "Insect", 8),
        new Animal("Tim", "Arthopode", 6),
        new Animal("Kim", "Arthopode", 4),
        new Animal("Bate Boiko", "Mammal", 2),
        new Animal("Tigre", "Mammal", 4),
        new Animal("Mecho Puh", "Mammal", 4),
        new Animal("Mufasa", "Mammal", 4),
        new Animal("Many legs", "Arthopode", 8)
    ];

    function groupBySpeciesSortByLegs(array) {
        var grouped = _.groupBy(_.sortBy(array, 'legs'), "species");        
        return grouped;
    }

    function totalLegCount(array) {
        var legCount = 0;
        _.each(array, function (animal) {
            legCount += animal.legs;
        })
        return legCount;
    }

    console.log("\n\n--------Original animals-------------")
    console.dir(animals);
    console.log("--------Task 4 - Group by species, sort by leg count.-----------");
    console.dir(groupBySpeciesSortByLegs(animals));
    console.log("--------Task 5 - Total leg count.-----------");
    console.log(totalLegCount(animals));
})();