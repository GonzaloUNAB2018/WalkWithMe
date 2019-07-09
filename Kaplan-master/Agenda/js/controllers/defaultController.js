app.controller("defaultController", ['$scope', '$http', 'ModalService',
    function ($scope, $http, ModalService) { }]);

app.config(function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'login.html',
            inputs: { id: -1 },
            controller: 'loginController',
            controllerAs: 'login'
        })
        .when('/recuperar', {
            templateUrl: 'views/recuperar.html',
            inputs: { id: -1 },
            controller: 'recuperarController',
            controllerAs: 'recuperar'
        })
        .when('/paciente', {
            templateUrl: 'views/paciente.html',
            inputs: { id: -1 },
            controller: 'pacienteController',
            controllerAs: 'paciente'
        })
        .when('/calendario', {
            templateUrl: 'views/calendario.html',
            inputs: { id: -1 },
            controller: 'calendarioController',
            controllerAs: 'calendario'
        })
        .when('/especialista', {
            templateUrl: 'views/especialista.html',
            inputs: { id: -1 },
            controller: 'especialistaController',
            controllerAs: 'especialista'
        })
        .when('/especialistaMisHoras', {
            templateUrl: 'views/especialistaMisHoras.html',
            inputs: { id: -1 },
            controller: 'especialistaMisHorasController',
            controllerAs: 'especialistaMisHoras'
        })
        .when('/especialistaAusencias', {
            templateUrl: 'views/especialistaAusencias.html',
            inputs: { id: -1 },
            controller: 'especialistaAusenciasController',
            controllerAs: 'especialistaAusencias'
        })
        .when('/motivoCierrePlan', {
            templateUrl: 'views/motivoCierrePlan.html',
            inputs: { id: -1 },
            controller: 'motivoCierrePlanController',
            controllerAs: 'motivoCierrePlan'
        })
        .otherwise({
            redirectTo: '/'
        });
});