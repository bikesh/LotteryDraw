(function () {
    "use strict";
    angular
        .module("lotteryManagement")
        .controller("lotteryController", ["$scope", "$http", "productResource", function ($scope, $http, productResource) {
            var vm = this;
            vm.lottery = {};
            vm.submit = function () {
                var serverUrl = "http://localhost:63232/api/lottery";
                vm.lottery.primaryNumbersRange = { from: vm.lottery.primaryNumbersRangeFrom, to: vm.lottery.primaryNumbersRangeTo };
                vm.lottery.secondaryNumbersRange = { from: vm.lottery.secondaryNumbersRangeFrom, to: vm.lottery.secondaryNumbersRangeTo };

                $http({ method: 'post', url: serverUrl, data: JSON.stringify(vm.lottery) }).
                  then(function (response) {
                      vm.lottery = {};
                      if (response.status === 200)
                          alert('record created');
                      else
                          alert(response.data)
                  }, function (response) {
                      alert(response.data.Message);
                  });
            };

        }]);
}());