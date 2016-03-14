angular.module('MyApp')
    .controller('CustomerController', [
        '$scope',
        'CustomerService',
        function($scope, CustomerService) {
            CustomerService.GetCustomers().then(function (callback) {
                console.log('getting customers');
                console.log(callback);
                $scope.Customers = callback.data;
            });
        }
    ]);