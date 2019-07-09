app.controller("modalExamenController", ['$scope', 'ModalService', 'Notification', 'examenService', 'id', "$element", 'close', 'fichaService', 'LoginService',
function ($scope, ModalService, Notification, examenService, id, $element, close, fichaService, LoginService) {

    $scope.Examen = {
        Id: -1,
    };

    $scope.registrarExamen = function () {
        $scope.saving = true;
        waitingDialog.show('Guardando Examen...', { dialogSize: 'sm' });
        $scope.Examen.Paciente = fichaService.getRutPaciente();
        $scope.Examen.Especialista = LoginService.getIdEspecialista();
        examenService.registrarExamen($scope.Examen, $scope.examenFile).then(function (result) {
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
