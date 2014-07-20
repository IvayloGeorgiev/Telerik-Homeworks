/// <reference path='../libs/underscore-min.js" />

(function () {
    var Student = (function () {
        function Student(firstName, lastName, grade, age, marks) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
            this.age = age;
            this.marks = marks;
        }

        return Student;
    })();

    var students = [
        new Student("Pencho", "Petkov", 6, 12, [4, 4, 4, 4]),
        new Student("Gencho", "Atkov", 5, 11, [4, 2, 3, 3]),
        new Student("Angel", "Zlatkov", 7, 13, [6, 6, 5, 6]),
        new Student("Zlatok", "Angelov", 3, 9, [3, 5, 4, 3]),
        new Student("Trencho", "Raikov", 8, 14, [6, 6, 6, 6]),
        new Student("Batko", "Goikov", 11, 17, [2, 2, 2, 2]),
        new Student("Hlencho", "Ialkov", 12, 18, [3, 3, 4, 4]),
        new Student("Radko", "Piratkov", 10, 16, [5, 5, 4, 6]),
        new Student("Kinko", "Dakov", 7, 13, [4, 6, 4, 6]),
        new Student("Bogomil", "Naumov", 12, 21, [5, 2, 5, 6]),
        new Student("Laika", "Zdravkova", 4, 10, [4, 6, 3, 4]),
        new Student("Raicho", "Radkov", 5, 11, [5, 4, 6, 4]),
        new Student("Svilen", "Cakov", 12, 20, [3, 2, 3, 4]),
    ];

    function lastNameBeforeFirst(array) {
        var lastNameOrder = _.filter(array, function (student) {
            return student.firstName < student.lastName;
        });        

        lastNameOrder = _.sortBy(lastNameOrder, function (student) {
            return student.firstName + ' ' + student.lastName;
        }).reverse();
        return lastNameOrder;
    }
    
    function studentsBetween18And24(array) {
        var ageLimited = _.filter(array, function (student) {
            return ((18 <= student.age) && (student.age <= 24));
        });

        var onlyNames = _.map(ageLimited, function (student) {
            return {
                firstName: student.firstName,
                lastName: student.lastName
            };
        });
        return onlyNames;
    }

    function highestMarks(array) {
        var highestMarks = _.sortBy(array, function (student) {
            var totalMark = 0;
            _.each(student.marks, function (mark) {
                totalMark += mark;
            })
            return (totalMark / student.marks.length);
        });
        return _.last(highestMarks);
    }

    console.log("--------Original Array------------");
    console.dir(students);
    console.log("--------Task 1 - Last name is before first, order by full name.-----------");
    console.dir(lastNameBeforeFirst(students));
    console.log("--------Task 2 - First and Last name of students between 18 and 24.-----------")
    console.dir(studentsBetween18And24(students));
    console.log("--------Task 3 - Student with the highest marks.-----------");
    console.dir(highestMarks(students));
})();