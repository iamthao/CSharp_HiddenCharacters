var app = angular.module('app', []);

app.controller('PcstController', ['$scope', '$http', function ($scope, $http) {
    function bindEventSignature() {
        $('#full-content input.signature').unbind('focus');

        $('#full-content input.signature').bind('focus', function (e) {
            $('#gridSystemModal').modal('show');
        });
    }

    function testCallHttp() {
        $http.get('http://localhost:9000/api/Values').then(function (result) {
            console.log(result);
        });
    }

    testCallHttp();
    $('#gridSystemModal').on('hidden.bs.modal', function (e) {
        $scope.mySign.clear();
    });
    bindEventSignature();
    $scope.save = function () {
        $('#saveModal').modal('show');
        var data = winformObj.save('data');
        console.log(data);
    };
}]);