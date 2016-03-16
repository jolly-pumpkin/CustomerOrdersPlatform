angular.module('MyApp')
    .factory('OrdersService', [
    '$http',
    function ($http) {
        return {
            GetOrders: function () {
                return $http.get('/Orders/GetOrders');
            },
            CreateOrder: function (customerOrder) {
                return $http({
                    url: '/Orders/CreateOrder',
                    method: 'POST',
                    data: JSON.stringify(customerOrder),
                    headers: { 'content-type': 'application/json' }
                });
            },
            RemoveOrder: function (order) {
                return $http({
                    url: '/Orders/RemoveOrder',
                    method: 'POST',
                    data: JSON.stringify(order),
                    headers: { 'content-type': 'application/json' }
                });
            },
            GetOrderDetails: function(order) {
                return $http({
                    url: '/Orders/GetOrderDetails',
                    method: 'Get',
                    data: JSON.stringify(order),
                    headers: { 'content-type': 'application/json' }
                });
            },
            GetOrdersForCustomer: function (customer) {
                return $http({
                    url: '/Orders/GetCustomerOrders',
                    method: 'POST',
                    data: JSON.stringify(customer),
                    headers: { 'content-type': 'application/json' }
                });
            }
        };
    }]);