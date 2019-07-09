app.controller("fichaRegistroMedicoController", ['$scope', 'ModalService', 'Notification', 'LoginService', '$location', 'registromedicoService', 'fichaService',
function ($scope, ModalService, Notification, LoginService, $location, registromedicoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {

        /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Registros Médicos...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.loadingData = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingData);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        $scope.TipoEspecialidad = LoginService.getTipo();

        registromedicoService.getRegistrosMedicos(fichaService.getRutPaciente()).then(function (result) {
            $scope.RegistrosMedicos = result.data;
            $scope.loadingData = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Registros Médicos' };
            Notification.error(msg);
        });


        $scope.NuevoRegistro = function () {
            ModalService.showModal({
                templateUrl: "views/modalRegistroMedico.html",
                inputs: { id: -1 },
                controller: "modalRegistroMedicoController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        registromedicoService.getRegistrosMedicos(fichaService.getRutPaciente()).then(function (result) {
                            $scope.RegistrosMedicos = result.data;
                        }, function (reason) {
                            msg = { title: 'Error Listar Registros Médicos' };
                            Notification.error(msg);
                        });
                    };
                });
            });
        };

        $scope.Eliminar = function (id) {
            waitingDialog.show('Eliminando Registro Médico...', { dialogSize: 'sm' });
            registromedicoService.EliminarRegistro(id).then(function (result) {
                registromedicoService.getRegistrosMedicos(fichaService.getRutPaciente()).then(function (result) {
                    $scope.RegistrosMedicos = result.data;
                    msg = { title: 'Eliminado Exitosamente' };
                    Notification.success(msg);
                    waitingDialog.hide();
                }, function (reason) {
                    msg = { title: 'Error Registros Médicos' };
                    Notification.error(msg);
                    waitingDialog.hide();
                });
            }, function (reason) {
                msg = { title: 'Error Eliminar Registro Médico' };
                Notification.error(msg);
                waitingDialog.hide();
            });
        };

        $scope.LeerRegistro = function (id) {
            waitingDialog.show('Cambiando Estado a Registro Médico...', { dialogSize: 'sm' });
            registromedicoService.MarcarLeidoRegistro(id, LoginService.getIdEspecialista()).then(function (result) {
                registromedicoService.getRegistrosMedicos(fichaService.getRutPaciente()).then(function (result) {
                    $scope.RegistrosMedicos = result.data;
                    msg = { title: 'Cambio de Estado Exito' };
                    Notification.success(msg);
                    waitingDialog.hide();
                }, function (reason) {
                    msg = { title: 'Error Listar Registros Médicos' };
                    Notification.error(msg);
                    waitingDialog.hide();
                });
            }, function (reason) {
                msg = { title: 'Error Cambiando Estado a Registro Médico' };
                Notification.error(msg);
                waitingDialog.hide();
            });
        };

    };
}]);