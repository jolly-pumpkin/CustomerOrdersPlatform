angular.module('MyApp')
    .factory('OrdersService', [
    '$http',
    function($http) {
        return {
            GetOrders: function (){
                return $http.get('/Orders/GetOrders');
            }
        };
    }]);