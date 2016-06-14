(function () {
    'use strict';

    angular
        .module('app')
        .controller('dashboardController', dashboardController);

    dashboardController.$inject = ['$scope', 'Docentes']; 

    function dashboardController($scope, Docentes) {
        $scope.pagina.titulo = "Dashboard";
        $scope.selected = [];

        $scope.query = {
            order: 'nombre',
            limit: 10,
            page: 1
        };

        $scope.getDocentes = function () {
            $scope.promesa = Docentes.getAll()
                .then(function (data) {
                    $scope.docentes = data;
                });
        };
        $scope.getDocentes();
    }
})();
