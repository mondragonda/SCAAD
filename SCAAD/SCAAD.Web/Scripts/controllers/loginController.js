(function () {
    'use strict';

    angular
        .module('app')
        .controller('loginController', loginController);

    loginController.$inject = ['$scope', '$auth', '$state', 'Restangular']; 

    function loginController($scope, $auth, $state, Restangular) {
        $scope.pagina.titulo = "Inicio de sesion";
        $scope.login = function (usuario) {
            usuario.grant_type = "password";
            //Restangular.all('oauth/token').post(usuario).then(function (m) { console.log(m); }, function (e) { console.log(e); });
            $state.go('app.dashboard');
            /*$auth.login(usuario)
                .then(function (respuesta) {
                    $state.go('app.dashboard');
                }, function (error) {
                    console.log(error);
                    $scope.error = true;
                });*/
        };
    }
})();
