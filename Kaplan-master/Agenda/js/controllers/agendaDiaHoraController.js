app.controller("agendaDiaHoraController", ['$scope', 'ModalService', 'agendaDiaHoraService', 'Notification', 'fecha', 'dia', 'hora', "$element", 'close',
function ($scope, ModalService, agendaDiaHoraService, Notification, fecha, dia, hora, $element, close) {

    $scope.loading = true;
    $scope.loadingData = true;
    $scope.StopLoading = function () {
        $scope.loading = !(!$scope.loadingData);
    };

    agendaDiaHoraService.getReservasHoraDia(fecha, dia, hora)
      .then(function (result) {
          $scope.Reservas = result.data;
          var date = moment(fecha).locale('es').format('dddd') + ' ' + moment(fecha).locale('es').format('L') + ' - ' + hora + ' Horas';
          //var date = fecha;
          $scope.fecha = date;
          $scope.loadingData = false;
          $scope.StopLoading();
      }, function (reason) {
          msg = { title: 'Error obtención reservas' };
          Notification.error(msg);
          $element.modal('hide');
      });

    $scope.nuevaReserva = function () {
        ModalService.showModal({
            templateUrl: "views/reserva.html",
            inputs: { fecha: fecha, dia: dia, hora: hora },
            controller: "reservaController"
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (result) {
                    agendaDiaHoraService.getReservasHoraDia(fecha, dia, hora).then(function (result) {
                        $scope.Reservas = result.data;
                        var date = moment(fecha).locale('es').format('dddd') + ' ' + moment(fecha).locale('es').format('L') + ' - ' + hora + ' Horas';
                        //var date = fecha;
                        $scope.fecha = date;
                        $element.modal('hide');
                        close(true, 500);
                    }, function (reason) {
                        msg = { title: 'Error obtención reservas' };
                        Notification.error(msg);
                        $element.modal('hide');
                        close(true, 500);
                    });
                }
            });
        });
    };

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };
}]);
