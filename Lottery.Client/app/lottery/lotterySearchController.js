(function () {
    "use strict";
    angular
        .module("lotteryManagement")
        .controller("lotterySearchController", ["$scope", "$http", "productResource", function ($scope, $http, productResource) {
            var vm = this;
            var serverUrl = "http://localhost:63232/api/lottery";
            vm.lotteries = [];

            $http({ method: 'get', url: serverUrl }).
                then(function (response) {
                    vm.lotteries = response.data;
                }, function (response) {
                    vm.message = response.data || 'Request failed';
                })
        }]);
}());