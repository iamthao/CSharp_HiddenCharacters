var app = angular.module('plunker', ['ngTagsInput']);

app.controller('MainCtrl', function ($scope, $http) {
    $scope.tags = [
      //{ name: "Brazil", flag: "Brazil.png" },
      //{ name: "Italy", flag: "Italy.png" },
      //{ name: "Spain", flag: "Spain.png" },
      //{ name: "Germany", flag: "Germany.png" },
    ];

    var data = [
        { "name": "Algeria", "flag": "Algeria.png", "confederation": "CAF", "id": 21 },
        { "name": "Argentina", "flag": "Argentina.png", "confederation": "CONMEBOL", "id": 5 },
        { "name": "Australia", "flag": "Australia.png", "confederation": "AFC", "id": 32 },
        { "name": "Belgium", "flag": "Belgium.png", "confederation": "UEFA", "id": 11 },
        { "name": "Bosnia and Herzegovina", "flag": "Bosnia-and-Herzegovina.png", "confederation": "UEFA", "id": 20 },
        { "name": "Brazil", "flag": "Brazil.png", "confederation": "CONMEBOL", "id": 3 },
        { "name": "Cameroon", "flag": "Cameroon.png", "confederation": "CAF", "id": 30 },
        { "name": "Chile", "flag": "Chile.png", "confederation": "CONMEBOL", "id": 14 },
        { "name": "Colombia", "flag": "Colombia.png", "confederation": "CONMEBOL", "id": 8 },
        { "name": "Costa Rica", "flag": "Costa-Rica.png", "confederation": "CONCACAF", "id": 24 },
        { "name": "Croatia", "flag": "Croatia.png", "confederation": "UEFA", "id": 17 },
        { "name": "Ecuador", "flag": "Ecuador.png", "confederation": "CONMEBOL", "id": 23 },
        { "name": "England", "flag": "England.png", "confederation": "UEFA", "id": 10 },
        { "name": "France", "flag": "France.png", "confederation": "UEFA", "id": 16 },
        { "name": "Germany", "flag": "Germany.png", "confederation": "UEFA", "id": 2 },
        { "name": "Ghana", "flag": "Ghana.png", "confederation": "CAF", "id": 26 },
        { "name": "Greece", "flag": "Greece.png", "confederation": "UEFA", "id": 12 },
        { "name": "Honduras", "flag": "Honduras.png", "confederation": "CONCACAF", "id": 25 },
        { "name": "Iran", "flag": "Iran.png", "confederation": "AFC", "id": 27 },
        { "name": "Italy", "flag": "Italy.png", "confederation": "UEFA", "id": 9 },
        { "name": "Ivory Coast", "flag": "Cote-dIvoire.png", "confederation": "CAF", "id": 22 },
        { "name": "Japan", "flag": "Japan.png", "confederation": "AFC", "id": 29 },
        { "name": "Mexico", "flag": "Mexico.png", "confederation": "CONCACAF", "id": 19 },
        { "name": "Netherlands", "flag": "Netherlands.png", "confederation": "UEFA", "id": 15 },
        { "name": "Nigeria", "flag": "Nigeria.png", "confederation": "CAF", "id": 28 },
        { "name": "Portugal", "flag": "Portugal.png", "confederation": "UEFA", "id": 4 },
        { "name": "Russia", "flag": "Russia.png", "confederation": "UEFA", "id": 18 },
        { "name": "South Korea", "flag": "South-Korea.png", "confederation": "AFC", "id": 31 },
        { "name": "Spain", "flag": "Spain.png", "confederation": "UEFA", "id": 1 },
        { "name": "Switzerland", "flag": "Switzerland.png", "confederation": "UEFA", "id": 6 },
        { "name": "United States", "flag": "United-States.png", "confederation": "CONCACAF", "id": 13 },
        { "name": "Uruguay", "flag": "Uruguay.png", "confederation": "CONMEBOL", "id": 7 }
    ];
    $scope.loadCountries = function ($query) {
       // return $http.get('test.txt', { cache: true }).then(function (response) {
            var countries = data;
            //console.log(countries);
            return countries.filter(function (country) {
                //console.log(country);
                return country.name.toLowerCase().indexOf($query.toLowerCase()) != -1;
            });
        //});
        //return data;
    };
    $scope.showData = function() {
        console.log($scope.tags);
    }
});