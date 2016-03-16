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

                    $mdDialog.show({
                        controller: "CustomerOrdersController",
                        templateUrl: './Views/Angular/CustomerOrders.html',
                        parent: angular.element(document.body),
                        targetEvent: ev
                    });
                });
            };
        }
    ]);