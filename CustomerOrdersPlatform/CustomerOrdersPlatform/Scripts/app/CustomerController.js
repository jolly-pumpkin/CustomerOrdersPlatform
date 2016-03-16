angular.module('MyApp')
    .controller('CustomerController', [
        '$scope',
        '$mdDialog',
        'CustomerService',
        'OrdersService',
        'UtilsService',
        function ($scope, $mdDialog, CustomerService, OrdersService, UtilsService) {
            $scope.Customers = [];
            $scope.Orders = [];

            CustomerService.GetCustomers().then(function (callback) {
                console.log('getting customers');
                console.log(callback);
                $scope.Customers = callback.data;
            });
            $scope.showOrders = function (index, ev) {
                var customer = $scope.Customers[index];
                OrdersService.GetOrdersForCustomer(customer).then(function (callback) {
                    console.log('getting orders');
                    console.log(callback);
                    $scope.Orders = [];
                    $scope.Orders = callback.data;
                });
            };
            $scope.getTimestamp = function (date) {
                console.log(date);
                return UtilsService.getTimestamp(date);
            };
            $scope.removeOrder = function (index) {
                console.log("start");
                var order = $scope.Orders[index];
                OrdersService.RemoveOrder(order);
                $scope.Orders.splice(index, 1);
            };
        }
    ]);