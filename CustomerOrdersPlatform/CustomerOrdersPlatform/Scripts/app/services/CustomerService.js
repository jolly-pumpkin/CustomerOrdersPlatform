angular.module('MyApp')
    .factory('CustomerService', [
    '$http',
    function($http) {
        return {
            GetCustomers: function () {
                return $http.get('/Customers/GetCustomers');
            }
        };
    }]);