(function () {
    'use strict';

    angular
        .module('app')
        .provider('Env', envProvider);

    function envProvider() {

        this.apiUrl = 'http://scaadapi.azurewebsites.net/';

        var Env = this;

        this.$get = function () {
            return Env;
        };
    }

})();