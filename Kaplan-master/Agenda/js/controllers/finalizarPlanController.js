app.controller("finalizarPlanController", ['$scope', 'ModalService', 'planService', 'Notification', 'tipoService', "$element", 'id', 'close', 'LoginService',
function ($scope, ModalService, planService, Notification, TipoService, $element, id, close, LoginService) {

    $scope.loading = true;
    $scope.loadingData = true;
    $scope.StopLoading = function () {
        $scope.loading = !(!$scope.loadingData);
    };

    $scope.Plan = {
        Id: id,
        Motivo: { ID: null },
        Usuario: { Id: LoginService.getId() }
    };

    $scope.finalizarPlan = function () {
        planService.FinalizarPlan($scope.Plan).then(function (result) {
            msg = { title: 'Planificacion Finalizada con éxito', message: "" };
            Notification.success(msg);
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: 'Error guardando Finalizacion de Planificacion' };
            Notification.error(msg);
        });
    };

    TipoService.getTipoMotivoPlan().then(function (result) {
        $scope.TipoMotivos = result.data;
        $scope.loadingData = false;
        $scope.StopLoading();
    }, function (reason) {
        msg = { title: 'Error Lista de Tipo Motivos' };
        Notification.error(msg);
    });

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };
}]);
