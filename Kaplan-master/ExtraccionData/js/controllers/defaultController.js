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
        .when('/menu', {
            templateUrl: 'views/menuConsulta.html',
            inputs: { id: -1 },
            controller: 'menuConsultaController',
            controllerAs: 'menu'
        })
         .when('/menuErgo', {
             templateUrl: 'views/menuErgo.html',
             inputs: { id: -1 },
             controller: 'menuErgoController',
             controllerAs: 'menuErgo'
         })
         .when('/menuMaquina', {
             templateUrl: 'views/menuMaquinasKine.html',
             inputs: { id: -1 },
             controller: 'menuMaquinasKineController',
             controllerAs: 'menuMaquina'
         })
        .when('/menuMaquinaImpu', {
            templateUrl: 'views/menuMaquinasKineImpu.html',
            inputs: { id: -1 },
            controller: 'menuMaquinasKineImpuController',
            controllerAs: 'menuMaquinaImpu'
        })
        .when('/menuMaquinaCons', {
            templateUrl: 'views/menuMaquinasKineCons.html',
            inputs: { id: -1 },
            controller: 'menuMaquinasKineConsController',
            controllerAs: 'menuMaquinaCons'
        })
        .when('/menuMaquinaTread', {
            templateUrl: 'views/menuMaquinasKineTread.html',
            inputs: { id: -1 },
            controller: 'menuMaquinasKineTreadController',
            controllerAs: 'menuMaquinaTread'
        })
        .otherwise({
            redirectTo: '/'
        });
});