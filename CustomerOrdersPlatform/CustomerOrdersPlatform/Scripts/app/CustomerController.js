angular.module('MyApp')
    .controller('CustomerController', [
        '$scope',
        'CustomerService',
        'OrdersService',
        function ($scope, CustomerService, OrdersService) {
            $scope.Customers = [];
            $scope.Orders = [];

            CustomerService.GetCustomers().then(function (callback) {
                console.log('getting customers');
                console.log(callback);
                $scope.Customers = callback.data;
            });
            $scope.showOrders = function (index) {
                var customer = $scope.Customers[index];
                OrdersService.GetOrdersForCustomer(customer).then(function (callback) {
                    console.log('getting orders');
                    console.log(callback);
                    $scope.Orders = [];
                    $scope.Orders = callback.data;
                });
            };
        }
    ]);