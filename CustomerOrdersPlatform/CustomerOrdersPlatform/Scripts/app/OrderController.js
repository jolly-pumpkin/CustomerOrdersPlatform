﻿angular.module('MyApp')
.controller('OrdersController', [
        '$scope',
        'OrdersService',
        function($scope, OrdersService) {
            OrdersService.GetOrders().then(function(callback) {
                $scope.Orders = callback.data;
                console.log($scope.Orders);
            });
            $scope.removeOrder = function (index) {
                console.log("start");
                var order = $scope.Orders[index];
                OrdersService.RemoveOrder(order);
            }

        }
]);