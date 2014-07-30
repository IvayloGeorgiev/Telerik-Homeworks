/// <reference path="../libs/jquery-2.1.1.min.js" />
/// <reference path="../libs/require.js" />
/// <reference path="httpRequests.js" />

define(['jquery', 'httpRequests'], function ($, httpRequests) {
    var $errorMessage, $successMessage, addStudent, reloadStudents, resourceUrl;        

    function error(err){
        $errorMessage
            .html('Error happened: ' + err)
            .show()
            .fadeOut(2000);
    }

    resourceUrl = 'http://localhost:3000/students';    

    $successMessage = $('.messages .success');

    $errorMessage = $('.messages .error');    

    addStudent = function (data) {
        function success(data){            
            $successMessage
                .html(data.name.toString() + ' successfully added')
                .show()
                .fadeOut(2000);
            reloadStudents();            
        }      

        return httpRequests.postJSON(resourceUrl, data, success, error);        
    };

    removeStudent = function (id) {
        return httpRequests.postJSON(resourceUrl + '/' + id, { _method: 'delete' }, reloadStudents, error);
    };

    reloadStudents = function () {
        function success (data) {
            var student, $studentsList, i, len;
            $studentsList = $('<ul/>').addClass('students-list');
            for (i = 0, len = data.students.length; i < len; i++) {
                student = data.students[i];                
                $('<li />')
                .addClass('student-item')
                .append($('<strong /> ')
                  .html(student.name))
                .append($('<span />')
                  .addClass('grade')
                  .html(student.grade))
                .append($('<span />')
                  .addClass('id')
                  .html(student.id))
                .appendTo($studentsList);
            }
            $('#students-container').html($studentsList);
        }

        httpRequests.getJSON(resourceUrl, success, error);        
    };

    function start() {
        reloadStudents();
        $('#btn-add-student').on('click', function () {
            var student;
            student = {
                name: $('#tb-name').val(),
                grade: $('#tb-grade').val()
            };
            addStudent(student);
        });
        $('#btn-remove-student').on('click', function () {
            var id;
            id = $('#tb-id').val();
            removeStudent(id);
        });
    }

    return {
        start: start
    };
});