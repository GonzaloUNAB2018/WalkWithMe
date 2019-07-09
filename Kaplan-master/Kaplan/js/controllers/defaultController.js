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
        .when('/ficha', {
            templateUrl: 'views/ficha.html',
            inputs: { id: -1 },
            controller: 'fichaController',
            controllerAs: 'ficha'
        })
        .when('/inicio', {
            templateUrl: 'views/inicio.html',
            inputs: { id: -1 },
            controller: 'inicioController',
            controllerAs: 'inicio'
        })
        .otherwise({
            redirectTo: '/'
        });
});