(function () {
    'use strict';

    angular
        .module('app')
        .factory('Docentes', Docentes);

    Docentes.$inject = ['$q', 'Restangular'];

    function Docentes($q, Restangular) {
        var service = {
            getAll: getAll
        };

        return service;

        function getAll() {
            var defered = $q.defer();
            Restangular.all('api/Docentes').getList()
                .then(function (data) {
                    defered.resolve(data);
                }).catch(function (error) {
                    defered.reject(error);
                });
            return defered.promise;
        }
    }
})();