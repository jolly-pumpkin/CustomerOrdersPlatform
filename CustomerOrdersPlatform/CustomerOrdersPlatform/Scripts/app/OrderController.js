angular.module('MyApp')
.controller('OrdersController', [
        '$scope',
        'OrdersService',
        function($scope, OrdersService) {
            OrdersService.GetOrders().then(function(callback) {
                $scope.Orders = callback.data; 
            });
        }
]);