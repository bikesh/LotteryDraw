(function () {
    "use strict";

    var appLottery = angular.module("lotteryManagement",
                        ["common.services", "ngRoute"]);

    appLottery
        .config(function ($routeProvider) {
            $routeProvider
                .when("/search", { templateUrl: "app/lottery/lotterysearch.html" })
                .when("/edit", { templateUrl: "app/lottery/lotteryedit.html"})
                .when("/create", { templateUrl: "app/lottery/lottery.html" });
    });

}());