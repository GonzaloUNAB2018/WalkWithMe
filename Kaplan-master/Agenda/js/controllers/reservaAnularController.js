app.controller("reservaAnularController", ['$scope', 'ModalService', 'reservaService', 'Notification', 'tipoService', "$element", 'id', 'close',
function ($scope, ModalService, reservaService, Notification, TipoService, $element, id, close) {

    $scope.loading = true;
    $scope.loadingData = true;
    $scope.StopLoading = function () {
        $scope.loading = !(!$scope.loadingData);
    };   

    reservaService.getReserva(id).then(function (result) {
        $scope.Reserva = result.data;
        $scope.cargarMotivos($scope.Reserva.Estado.ID)
        $scope.loadingData = false;
        $scope.StopLoading();
    })

    $scope.anularReserva = function () {
        $scope.Reserva.Fecha = moment($scope.Reserva.Fecha);
        $scope.Reserva.Paciente.Persona.FechaNac = moment($scope.Reserva.Paciente.Persona.FechaNac);
        $scope.Reserva.Especialista.Persona.FechaNac = moment($scope.Reserva.Especialista.Persona.FechaNac);
        $scope.Reserva.Paciente.Reservas = null;
        $scope.Reserva.Paciente.Planes = null;
        $scope.Reserva.Paciente.Licencias= null;
        reservaService.anularReserva($scope.Reserva).then(function (result) {
            msg = { title: 'Reserva anulada con éxito', message: "" };
            Notification.success(msg);
            $element.modal('hide');
            close(true, 500);
        }, function (reason) {
            msg = { title: 'Error guardando reserva' };
            Notification.error(msg);
        });
    };

    $scope.cargarMotivos = function (estado) {
        if (estado == 4) {
            TipoService.getTipoAnulada().then(function (result) {
                $scope.TipoMotivos = result.data;
            }, function (reason) {
                msg = { title: 'Error Lista de Tipo Estados Anulación' };
                Notification.error(msg);
            });
        }
        else if (estado == 5) {
            TipoService.getTipoNoRealizada().then(function (result) {
                $scope.TipoMotivos = result.data;
            }, function (reason) {
                msg = { title: 'Error Lista de Tipo Estados No Realizada' };
                Notification.error(msg);
            });
        };
    };

    TipoService.getTipoEstadoReserva().then(function (result) {
        $scope.TipoEstadoReservas = result.data;
    }, function (reason) {
        msg = { title: 'Error Lista de Tipo Estados Reserva' };
        Notification.error(msg);
    });

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };
}]);

