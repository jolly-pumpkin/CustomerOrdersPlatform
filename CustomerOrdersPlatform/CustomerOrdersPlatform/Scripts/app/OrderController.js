angular.module('MyApp')
.controller('OrdersController', function ($scope, OrdersService) {
        OrdersService.GetOrders().then(function(d) {
            $scope.Orders = d.data; 
            console.log(d.data);
        });
        OrdersService.GetOrders().then(function (d) {
            $scope.Orders = d.data; 
            console.log(d.data);
        });
    })
.factory('OrdersService', function ($http) {
    var fac = {};
    fac.GetOrders = function () {
        return $http.get('/Orders/GetOrders');
    }
    fac.GetProducts = function () {
        return $http.get('/Products/GetProducts');
    }
    return fac;
});

