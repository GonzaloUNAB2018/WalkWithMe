app.controller("fichaController", ['$scope', 'Notification', 'LoginService', '$location', 'ServiceObservadorUser', 'fichaService', 'ModalService',
function ($scope, Notification, LoginService, $location, ServiceObservadorUser, fichaService, ModalService) {

    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        $scope.tipo = LoginService.getTipo();
        $scope.Nombres = LoginService.getUserName();

        if ($scope.tipo == '1') {
            $scope.NombreEspecialidad = 'Secretaria'
        }
        else {
            $scope.NombreEspecialidad = 'Especialista'
        }

        var vm = this;
        vm.filePath = {
            name: "views/inicio.html",
            url: "views/inicio.html"
        };

        this.receive = function (message) {
            if (message.Estado == 1) {
                $scope.rutvalido = true;
                $scope.Titulo = message.Persona.Nombre + " " + message.Persona.Paterno + " " + message.Persona.Materno;
                $scope.RutPaciente = message.Persona.Rut + "-" + message.Persona.Dv;
            } else {
                $scope.Titulo = null;
                $scope.RutPaciente = null;
                $scope.rutvalido = false;
            };

        };
        ServiceObservadorUser.listenMessage(this);
        
    };

    $scope.CerrarSesion = function () {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    };

    $scope.ModalEvolucion = function () {
        ModalService.showModal({
            templateUrl: "views/modalEvolucion.html",
            inputs: { id: -1 },
            controller: "modalEvolucionController"
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (result) {
                    /*registromedicoService.getRegistrosMedicos(fichaService.getRutPaciente()).then(function (result) {
                        $scope.RegistrosMedicos = result.data;
                    }, function (reason) {
                        msg = { title: 'Error Listar Registros Médicos' };
                        Notification.error(msg);
                    });*/
                };
            });
        });
    };

    $scope.LimpiarRut = function () {
        $scope.Paciente = {
            Estado: 0,
            Persona: {
                Rut: null,
                Dv: null
            }
        };
        $scope.rutvalido = false;
        ServiceObservadorUser.sendMessage($scope.Paciente);
        fichaService.getLimpiarPacienteLocal();
        $location.path('/inicio');
    };

    $scope.nav = function (path) {
        if (LoginService.getisAuthenticated()) {
            vm.filePath = {
                name: path,
                url: path
            };
        }
    };

}]);

