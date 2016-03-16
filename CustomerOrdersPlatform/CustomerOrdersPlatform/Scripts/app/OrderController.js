angular.module('MyApp')
.controller('OrdersController', [
        '$scope',
        'OrdersService',
        'UtilsService',
        function($scope, OrdersService, UtilsService) {
            OrdersService.GetOrders().then(function(callback) {
                $scope.Orders = callback.data;
                console.log($scope.Orders);
            });
            $scope.removeOrder = function(index) {
                console.log("start");
                var order = $scope.Orders[index];
                OrdersService.RemoveOrder(order);
                $scope.Orders.splice(index, 1);
            };
            $scope.getDetails = function (index) {
                console.log("getting details");
                var order = $scope.Orders[index];
                console.log(order);
                OrdersService.GetOrderDetails(order).then(function (callback) {
                    $scope.Order_Details = callback.data;
                    console.log($scope.Order_Details);
                });
            }
            $scope.getTimestamp = function(date){
                  return UtilsService.getTimestamp(date);
            };
        }
]);