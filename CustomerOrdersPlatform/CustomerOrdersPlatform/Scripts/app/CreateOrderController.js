angular.module('MyApp')
    .controller('CreateOrderController', [
        '$scope',
        'OrdersService',
        'ProductService',
        'CustomerService',
        function($scope, OrdersService, ProductService, CustomerService) {
            $scope.Details = [];
            ProductService.GetProducts().then(function (callback) {
                $scope.Products = callback.data;
            });
            CustomerService.GetCustomers().then(function(callback) {
                $scope.Customers = callback.data;
            });

            $scope.setSelected = function(index) {
                Detail = $scope.Products[index];
                $scope.Details.push(Detail);
            };

            $scope.ClearOrder = function() {
                $scope.Details = [];
            };

            $scope.CreateOrder = function() {
                var orderDetails = new Array();
                for (var i = 0; i < $scope.Details.length; i++) {
                    var detail = $scope.Details[i];
                    var record = {
                        Order_ID: null,
                        Detail_ID: null,
                        Product_SKU: detail.SKU
                    };
                    orderDetails.push(record);
                };

                var date = new Date();

                var customerOrder = {
                    Order_ID: null,
                    Customer_ID: $scope.selectedUser,
                    Date: date.getDate(),
                    Order_Details: orderDetails
                };
                
                $scope.Details = [];
                OrdersService.CreateOrder(customerOrder);
            };
            $scope.removeDetailLine = function(index) {
                $scope.Details.splice(index, 1);
            };

        }
]);