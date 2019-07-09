app.controller("calendarioController", ['$scope', 'ModalService', 'ResumenCalendarioService', 'Notification', 'LoginService', '$location',
function ($scope, ModalService, ResumenCalendarioService, Notification, LoginService, $location) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        var date = moment();
        date.locale("es");
        $scope.FechaSemana = date;
        var vm = this;
        vm.header = {
            url: 'header.html'
        };
        $scope.loading = true;
        $scope.loadingData = true;
        if ($scope.Especialidad == 1) {
            $scope.IdEspecialista = -1
        }
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingData);
        };

        $scope.IdEspecialista = LoginService.getIdEspecialista();
        $scope.Especialidad = LoginService.getTipo();

        $scope.cargarSemana = function (inFecha) {
            if ($scope.Especialidad == 1) {
                $scope.IdEspecialista = -1
            }
            ResumenCalendarioService.getResumenCalendario(inFecha.toISOString(), $scope.IdEspecialista).then(function (result) {
                $scope.Dias = result.data;
                $scope.loadingData = false;
                $scope.StopLoading();
            }, function (reason) {
                msg = { title: 'Error obteniendo Resumen Calendario' };
                Notification.error(msg);
            });
        };   
        $scope.cargarSemana(moment())

        $scope.VerDetalleHora = function (inFecha, inDia, inHora, inReservas) {
            var date = new Date();
            date = moment(inFecha).startOf('isoWeek').add(inDia - 1, 'days');
            if (inReservas > 0) {                
                ModalService.showModal({
                    templateUrl: "views/agendaDiaHora.html",
                    inputs: { fecha: date.format("YYYY-MM-DD"), dia: inDia, hora: inHora },
                    controller: "agendaDiaHoraController"
                }).then(function (modal) {
                    modal.element.modal();
                    modal.close.then(function (result) {
                        if (result) {
                            $scope.cargarSemana(inFecha);
                        };
                    });
                });
            }
            else {
                ModalService.showModal({
                    templateUrl: "views/reserva.html",
                    inputs: { fecha: date.format("YYYY-MM-DD"), dia: inDia, hora: inHora },
                    controller: "reservaController"
                }).then(function (modal) {
                    modal.element.modal();
                    modal.close.then(function (result) {
                        if (result) {
                            $scope.cargarSemana(inFecha);
                        }
                    });
                });
            }
        };
    };
}]);

