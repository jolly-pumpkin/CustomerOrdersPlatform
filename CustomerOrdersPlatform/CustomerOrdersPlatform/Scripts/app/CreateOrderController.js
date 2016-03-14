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

            $scope.setSelected = function (index) {
                Detail = $scope.Products[index];
                console.log(Detail);
                $scope.Details.push(Detail);
            };
            $scope.CreateOrder = function() {
                console.log("Creating order");
                console.log($scope.selectedUser);
                var customerOrder = {
                    Order_ID: null,
                    Customer_ID: $scope.selectedUser,
                    Date: new Date()
                };
                console.log(customerOrder);
                OrdersService.CreateOrder(customerOrder);
            };
            $scope.removeDetailLine = function (index) {
                console.log("delete row");
                console.log(index);
                $scope.Details.splice(index, 1);
            }

        }
]);