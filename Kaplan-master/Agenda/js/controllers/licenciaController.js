app.controller("licenciaController", ['$scope', 'ModalService', 'licenciaService', 'Notification', "$element", 'rut', 'id', 'inicio', 'termino', 'obs', 'close',
function ($scope, ModalService, licenciaService, Notification, $element, rut, id, inicio, termino, obs, close) {
    $scope.saving = false;
    $scope.loading = true;

    if (id == -1) {
        $scope.Licencia = {
            Id: -1,
            IdPaciente: rut,
            Inicio: null,
            Termino: null,
            Observacion: null
        };
    }
    else {
        $scope.Licencia = {
            Id: id,
            IdPaciente: rut,
            Inicio: moment(inicio),
            Termino: moment(termino),
            Observacion: obs
        };
    }
    $scope.registrarLicencia = function () {
        $scope.saving = true;
        licenciaService.registrarLicencia($scope.Licencia).then(function (result) {
            msg = { title: 'Licencia registrada con éxito', message: "" };
            Notification.success(msg);
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: 'Error guardando Licencia' };
            Notification.error(msg);
        });
    };
   

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };
}]);
