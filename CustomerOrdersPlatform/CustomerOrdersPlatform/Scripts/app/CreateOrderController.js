angular.module('MyApp')
    .controller('CreateOrderController', [
        '$scope',
        'OrdersService',
        'ProductService',
        'CustomerService',
        function($scope, OrdersService, ProductService, CustomerService) {
            ProductService.GetProducts().then(function(callback) {
                $scope.Products = callback.data;
            });
            CustomerService.GetCustomers().then(function(callback) {
                $scope.Customers = callback.data;
            });
        }
]);