(function () {
    var app = angular.module('MyApp', [
       'ngRoute',
       'ngMaterial']);
    app.controller('HomeController', function ($scope) {  
        $scope.Message = "Angular works!";
    });
})();
