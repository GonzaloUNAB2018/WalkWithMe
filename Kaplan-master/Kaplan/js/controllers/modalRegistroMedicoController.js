app.controller("modalRegistroMedicoController", ['$scope', 'ModalService', 'Notification', 'registromedicoService', 'id', "$element", 'close', 'fichaService', 'LoginService', 'tipoService',
function ($scope, ModalService, Notification, registromedicoService, id, $element, close, fichaService, LoginService, tipoService) {

    $scope.RegistroMedico = {
        Id: -1,
    };

    tipoService.getTipoEspecialidad().then(function (result) {
        $scope.Especialidades = result.data;
    }, function (reason) {
        msg = { title: 'Error Lista de Tipo Especialidades' };
        Notification.error(msg);
    });

    $scope.registrarRegistro = function () {
        $scope.saving = true;
        waitingDialog.show('Guardando Registro Médico...', { dialogSize: 'sm' });
        $scope.RegistroMedico.Paciente = fichaService.getRutPaciente();
        $scope.RegistroMedico.idEspecialistaEmisor = LoginService.getIdEspecialista();
        registromedicoService.registrarRegistroMedico($scope.RegistroMedico).then(function (result) {
            msg = { title: 'Guardado Exitosamente' };
            Notification.success(msg);
            waitingDialog.hide();
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: reason.message };
            Notification.error(msg);
            $scope.saving = false;
            waitingDialog.hide();
        });
    };
    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };

}]);
