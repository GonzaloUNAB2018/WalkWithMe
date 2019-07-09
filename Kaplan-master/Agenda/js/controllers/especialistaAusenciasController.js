app.controller("especialistaAusenciasController", ['$scope', 'Notification', 'especialistaService', 'tipoService','LoginService','$location',
function ($scope, Notification, especialistaService, tipoService, LoginService, $location) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        var vm = this;
        vm.header = {
            url: 'header.html'
        };

        $scope.Ausencia =
                 {
                     Id: -1,
                     Estado: { ID: null },
                     Hora: { ID: null },
                     Dia: null,
                     Motivo: null,
                     IdEspecialista: LoginService.getIdEspecialista()
                 };

        //Listado de Ausencia
        especialistaService.getEspecialistaAusencias($scope.Ausencia.IdEspecialista).then(function (result) {
            $scope.Ausencias = result.data;
            $scope.Ausencias.Dia = moment($scope.Ausencias.Dia);
            /*$scope.loadingGrid = false;
            $scope.StopLoading();*/
        }, function (reason) {
            Notification.error(reason.message);
        });

        $scope.registrarAusencia = function () {
            $("#btnGuardar").button('loading');
            especialistaService.registrarAusencia($scope.Ausencia).then(function (result) {
                msg = { title: 'Registro guardado con éxito', message: "" };
                Notification.success(msg);
                especialistaService.getEspecialistaAusencias($scope.Ausencia.IdEspecialista).then(function (result) {
                    $scope.Ausencias = result.data;
                    $scope.Ausencias.Dia = moment($scope.Ausencias.Dia);
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

        $scope.eliminarAusencia = function (num) {
            especialistaService.EliminarAusencia(num)
                .then(function (result) {
                    msg = { title: 'Registro Eliminado con éxito', message: "" };
                    Notification.success(msg);
                    especialistaService.getEspecialistaAusencias($scope.Ausencia.IdEspecialista).then(function (result) {
                        $scope.Ausencias = result.data;
                        $scope.Ausencias.Dia = moment($scope.Ausencias.Dia);
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
    };
}]);