angular.module('MyApp')
    .controller('CustomerController', [
        '$scope',
        'CustomerService',
        function($scope, CustomerService) {
            CustomerService.GetCustomers().then(function(callback) {
                $scope.Customers = callback.data;
            });
        }
    ]);