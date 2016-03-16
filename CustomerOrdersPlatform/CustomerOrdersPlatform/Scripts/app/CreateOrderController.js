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
                console.log(Detail);
                $scope.Details.push(Detail);
            };

            $scope.ClearOrder = function() {
                $scope.Details = [];
            };

            $scope.CreateOrder = function() {
                console.log("Creating order");
                console.log($scope.selectedUser);
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
                
                console.log(customerOrder);
                $scope.Details = [];
                OrdersService.CreateOrder(customerOrder);
            };
            $scope.removeDetailLine = function(index) {
                console.log("delete row");
                console.log(index);
                $scope.Details.splice(index, 1);
            };

        }
]);