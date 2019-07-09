app.controller("reservaObservacionController", ['$scope', 'ModalService', 'reservaService', 'Notification', 'tipoService', "$element", 'id', 'close',
function ($scope, ModalService, reservaService, Notification, TipoService, $element, id, close) {

    $scope.loading = true;
    $scope.loadingData = true;
    $scope.StopLoading = function () {
        $scope.loading = !(!$scope.loadingData);
    };

    reservaService.getObservacion(id).then(function (result) {
        $scope.Reserva = result.data;        
        $scope.StopLoading();
    })

    $scope.registrarObservacion = function () {
        $scope.Reserva.Id = id;
        $scope.Reserva.Fecha = moment($scope.Reserva.Fecha);
        reservaService.registrarObservacion($scope.Reserva).then(function (result) {
            msg = { title: 'Observación registrada con éxito', message: "" };
            Notification.success(msg);
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: 'Error guardando observación' };
            Notification.error(msg);
        });
    };
    
    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };
}]);

