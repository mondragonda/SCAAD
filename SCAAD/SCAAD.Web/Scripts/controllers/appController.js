(function () {
    'use strict';

    angular
        .module('app')
        .controller('appController', appController);

    appController.$inject = ['$scope', '$mdSidenav', '$state']; 

    function appController($scope, $mdSidenav, $state) {
        $scope.$state = $state;
        $scope.pagina = {
            titulo: ""
        };
        $scope.$mdSidenav = $mdSidenav;
    }
})();
