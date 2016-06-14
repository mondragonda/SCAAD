(function () {
    'use strict';

    angular
        .module('app', [
            'ngMaterial',
            'ui.router',
            'satellizer',
            'angular-loading-bar',
            'ngAnimate',
            'restangular',
            'md.data.table'
        ])

        .config(appConfig);

    appConfig.$inject = ['$stateProvider', '$urlRouterProvider', '$authProvider', 'RestangularProvider', 'EnvProvider', '$mdThemingProvider'];

    function appConfig($stateProvider, $urlRouterProvider, $authProvider, RestangularProvider, EnvProvider, $mdThemingProvider) {
        $mdThemingProvider
            .theme('default')
            .primaryPalette('teal')
            .accentPalette('pink')
            .warnPalette('red')
            .backgroundPalette('grey');
        // // Restangular

        RestangularProvider.setBaseUrl(EnvProvider.apiUrl);
        //RestangularProvider.addResponseInterceptor(function (data) {
        //    return data.data;
        //});

        // // Satellizer

        $authProvider.withCredentials = false;
        $authProvider.storageType = 'localStorage';
        $authProvider.tokenName = 'access_token';
        $authProvider.baseUrl = EnvProvider.apiUrl;
        //$authProvider.signupUrl = '/';
        $authProvider.loginUrl = '/oauth/token';

        $urlRouterProvider.otherwise("/dashboard");
        $stateProvider
                    ////////////////////////
                    // Sesion
                    ////////////////////////
                    .state('login', {
                        url: '/',
                        templateUrl: 'views/login.html',
                        controller: 'loginController'
                    })
                    ////////////////////////
                    // App
                    ////////////////////////
                    .state('app', {
                        url: '/app',
                        abstract: true,
                        templateUrl: 'views/app.html',
                        resolve: {
                            //usuario: function ($q, $timeout, $auth, $state) {
                            //    var deferred = $q.defer();
                            //    $timeout(function () {
                            //        console.log($auth.getPayload());
                            //        if ($auth.isAuthenticated())
                            //            deferred.resolve($auth.getPayload());
                            //        else {
                            //            $state.go('login');
                            //            deferred.reject();
                            //        }
                            //    });
                            //    return deferred.promise;
                            //}
                        }
                    })
                        .state('app.dashboard', {
                            url: '^/dashboard',
                            templateUrl: 'views/dashboard.html',
                            controller: 'dashboardController'
                        })
        ;
    }
})();