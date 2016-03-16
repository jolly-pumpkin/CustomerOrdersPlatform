angular.module('MyApp')
.controller('OrdersController', [
        '$scope',
        'OrdersService',
        function($scope, OrdersService) {
            OrdersService.GetOrders().then(function(callback) {
                $scope.Orders = callback.data;
            });
            $scope.removeOrder = function(index) {
                var order = $scope.Orders[index];
                OrdersService.RemoveOrder(order);
                $scope.Orders.splice(index, 1);
                $scope.Order_Details = [];
            };
            $scope.getDetails = function (index) {
                var order = $scope.Orders[index];
                OrdersService.GetOrderDetails(order).then(function (callback) {
                    $scope.Order_Details = callback.data;
                });
            }
        }
]);