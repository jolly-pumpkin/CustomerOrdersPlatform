angular.module('MyApp')
.controller('OrdersController', function ($scope, OrdersService) {
    $scope.Contact = null;
    OrdersService.GetOrders().then(function (d) {
        $scope.Orders = d.data; // Success
        console.log(d.data);
    }, function () {
        alert('Failed'); // Failed
    });
})
.factory('OrdersService', function ($http) {
    var fac = {};
    fac.GetOrders = function () {
        return $http.get('/Orders/GetOrders');
    }
    return fac;
});

