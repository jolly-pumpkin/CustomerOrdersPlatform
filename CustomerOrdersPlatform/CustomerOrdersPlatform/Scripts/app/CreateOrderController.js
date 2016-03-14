angular.module('MyApp')
    .controller('CreateOrderController', [
        '$scope',
        'OrdersService',
        'ProductService',
        'CustomerService',
        function($scope, OrdersService, ProductService, CustomerService) {
            $scope.Order = {
                Customer_ID: '',
                Products: {}
            };

            ProductService.GetProducts().then(function (callback) {
                $scope.Products = callback.data;
            });
            CustomerService.GetCustomers().then(function(callback) {
                $scope.Customers = callback.data;
            });
            $scope.SelectedProduct = {};
            $scope.setSelected = function (selectedID) {
                console.log("picked row");
            };
            $scope.CreateOrder = function() {
                console.log("Creating order");
                console.log(this.selectedUser);
                //OrdersService.CreateOrder();
            };
        }
]);