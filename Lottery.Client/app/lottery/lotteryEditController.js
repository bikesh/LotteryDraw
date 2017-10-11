(function () {
    "use strict";
    angular
        .module("lotteryManagement")
        .controller("lotteryEditController", ["$scope", "$http", "productResource", function ($scope, $http, productResource) {
            var vm = this;
            var serverUrl = "http://localhost:63232/api/lottery";
            vm.lotteryList = [];
            vm.selectedLottery = {};
            vm.selectedLottery.winningPrimaryNumbers = [];
            vm.selectedLottery.winningSecondaryNumbers = [];
            $http({ method: 'get', url: serverUrl }).
                then(function (response) {
                    vm.lotteryList = response.data;
                }, function (response) {
                    $scope.data = response.data || 'Request failed';
                    vm.message = response.status;
                })

            vm.dropdownChanged = function () {
                vm.selectedLottery.winningPrimaryNumbers = [];
                for (var i = 0; i < 5; i++) {
                    var newItemNo = vm.selectedLottery.winningPrimaryNumbers.length + 1;
                    vm.selectedLottery.winningPrimaryNumbers.push({ 'id': 'choice' + newItemNo });
                }

                vm.selectedLottery.winningSecondaryNumbers = [];
                for (var i = 0; i < 2; i++) {
                    var newItemNo = vm.selectedLottery.winningSecondaryNumbers.length + 1;
                    vm.selectedLottery.winningSecondaryNumbers.push({ 'id': 'choice' + newItemNo });
                }
            };

            vm.submit = function () {
                $http({ method: 'put', url: serverUrl + "?id=" + vm.selectedLottery.Name, data: JSON.stringify(vm.selectedLottery) }).
                  then(function (response) {
                      vm.message = response.status;
                      vm.selectedLottery = {};
                      if (response.status === 200)
                          alert('record updated');
                      else 
                          alert(response.data)
                  }, function (response) {
                      alert(response.data.Message);
                  });
            };

        }]);
}());