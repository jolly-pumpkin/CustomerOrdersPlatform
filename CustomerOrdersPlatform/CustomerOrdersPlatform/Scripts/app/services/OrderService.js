angular.module('MyApp')
    .factory('OrdersService', [
    '$http',
    function($http) {
        return {
            GetOrders: function (){
                return $http.get('/Orders/GetOrders');
            },
            CreateOrder: function (customerOrder){
                return $http({
                    url: '/Orders/CreateOrder',
                    method: 'POST',
                    data:JSON.stringify(customerOrder),
                    headers: { 'content-type': 'application/json' }
                });
            },
            RemoveOrder: function (order) {
                console.log("call to remove order");
                return $http({
                    url: '/Orders/RemoveOrder',
                    method: 'POST',
                    data: JSON.stringify(order),
                    headers: { 'content-type': 'application/json' }
                });
            }
        };
    }]);