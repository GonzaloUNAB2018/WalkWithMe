app.controller("especialistaMisHorasController", ['$scope', 'Notification', 'especialistaService', 'tipoService', 'LoginService', '$location',
function ($scope, Notification, especialistaService, tipoService, LoginService, $location) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        var vm = this;
        vm.header = {
            url: 'header.html'
        };

        $scope.AtencionHora =
                 {
                     Id: -1,
                     Dia: { ID: null },
                     Hora: { ID: null },
                     IdEspecialista: LoginService.getIdEspecialista()
                 };

        //Listado de Ausencia
        especialistaService.getEspecialistaAtencionHoras($scope.AtencionHora.IdEspecialista).then(function (result) {
            $scope.AtencionHoras = result.data;
            /*$scope.loadingGrid = false;
            $scope.StopLoading();*/
        }, function (reason) {
            Notification.error(reason.message);
        });

        $scope.registrarAtencion = function () {
            $("#btnGuardar").button('loading');
            especialistaService.registrarAtencionHora($scope.AtencionHora).then(function (result) {
                msg = { title: 'Registro guardado con éxito', message: "" };
                Notification.success(msg);
                especialistaService.getEspecialistaAtencionHoras($scope.AtencionHora.IdEspecialista).then(function (result) {
                    $scope.AtencionHoras = result.data;
                }, function (reason) {
                    Notification.error(reason.message);
                });
                $("#btnGuardar").button('reset');
            }, function (reason) {
                msg = { title: 'Error guardando registro' };
                Notification.error(msg);
                $("#btnGuardar").button('reset');
            });
        };

        $scope.eliminarAtencion = function (num) {
            especialistaService.EliminarAtencionHora(num)
                .then(function (result) {
                    msg = { title: 'Registro Eliminado con éxito', message: "" };
                    Notification.success(msg);
                    especialistaService.getEspecialistaAtencionHoras($scope.AtencionHora.IdEspecialista).then(function (result) {
                        $scope.AtencionHoras = result.data;
                    }, function (reason) {
                        Notification.error(reason.message);
                    });
                }, function (reason) {
                    msg = { title: 'Error Elimando registro' };
                    Notification.error(msg);
                });
        };

        tipoService.getTipoHoras().then(function (result) {
            $scope.TipoHoras = result.data;
            /*$scope.loadingTipoSexo = false;
            $scope.StopLoading();*/
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Hora' };
            Notification.error(msg);
        });

        tipoService.getTipoDias().then(function (result) {
            $scope.TipoDias = result.data;
            /*$scope.loadingTipoSexo = false;
            $scope.StopLoading();*/
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Dia' };
            Notification.error(msg);
        });
    };
}]);