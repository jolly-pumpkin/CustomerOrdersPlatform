angular.module('MyApp')
    .controller('CustomerController', [
        '$scope',
        '$mdDialog',
        'CustomerService',
        'OrdersService',
        function ($scope, $mdDialog, CustomerService, OrdersService) {
            $scope.Customers = [];
            $scope.Orders = [];

            CustomerService.GetCustomers().then(function (callback) {
                console.log('getting customers');
                $scope.Customers = callback.data;
            });
            $scope.showOrders = function (index, ev) {
                var customer = $scope.Customers[index];
                OrdersService.GetOrdersForCustomer(customer).then(function (callback) {
                    console.log('getting orders');
                    $scope.Orders = [];
                    $scope.Orders = callback.data;
                });
            };
            $scope.removeOrder = function (index) {
                var order = $scope.Orders[index];
                OrdersService.RemoveOrder(order);
                $scope.Orders.splice(index, 1);
            };
        }
    ]);