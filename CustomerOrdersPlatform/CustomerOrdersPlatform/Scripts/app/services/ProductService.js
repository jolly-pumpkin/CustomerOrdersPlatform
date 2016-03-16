angular.module('MyApp')
    .factory('ProductService', [
    '$http',
    function ($http) {
        return {
            GetProducts: function () {
                return $http.get('/Product/GetProducts');
            }
        };
    }]);