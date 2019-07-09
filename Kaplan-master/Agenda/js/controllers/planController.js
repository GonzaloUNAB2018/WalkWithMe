app.controller("planController", ['$scope', 'ModalService', 'planService', 'Notification', "$element", 'rut', 'close','id', 'nombre', 'descripcion', 'cantidad',
function ($scope, ModalService, planService, Notification, $element, rut, close, id, nombre, descripcion, cantidad) {
    $scope.saving = false;
    $scope.loading = true;

    $scope.Plan = {
        Id: id,
        IdPaciente: rut,
        Nombre: nombre,
        Descripcion: descripcion,
        Cantidad: cantidad
    };

    $scope.registrarPlan = function () {
        $scope.saving = true;
        planService.registrarPlan($scope.Plan).then(function (result) {
            msg = { title: 'Plan registrado con éxito', message: "" };
            Notification.success(msg);
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: 'Error guardando Plan' };
            Notification.error(msg);
        });
    };

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };

}]);