angular.module('MyApp') 
.controller('CustomerController', function ($scope, CustomerService) { 
    $scope.Contact = null;
    CustomerService.GetLastContact().then(function (d) {
        $scope.Customer = d.data; // Success
    }, function () {
        alert('Failed'); // Failed
    });
})
.factory('CustomerService', function ($http) {
    var fac = {};
    fac.GetLastContact = function () {
        return $http.get('/Customers/GetLastCustomer');
    }
    return fac;
});
 
 