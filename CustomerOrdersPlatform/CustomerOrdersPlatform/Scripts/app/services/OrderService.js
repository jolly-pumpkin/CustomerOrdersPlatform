angular.module('MyApp')
    .factory('OrdersService', [
    '$http',
    function($http) {
        return {
            GetOrders: function (){
                return $http.get('/Orders/GetOrders');
            },
            CreateOrder: function (order){
                return $http({
                    url: '/Orders/CreateOrder',
                    method: 'POST',
                    data: JSON.stringify(order),
                    headers: { 'content-type': 'application/json' }
                });
            }
        };
    }]);