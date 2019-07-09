app.controller("modalArchivoController", ['$scope', 'ModalService', 'Notification', 'archivoService', 'id', "$element", 'close', 'fichaService', 'LoginService',
function ($scope, ModalService, Notification, archivoService, id, $element, close, fichaService, LoginService) {

    $scope.Carga = {
        Id: -1,
    };
    $scope.loadingPlanes = true;
    $scope.StopLoading = function () {
        $scope.loading = !(!$scope.loadingPlanes);
        if (!$scope.loading) { waitingDialog.hide(); }
    };

    /*Carga de Planes*/
    fichaService.getPlanesxRut(parseInt(fichaService.getRutPaciente())).then(function (result) {
        $scope.Planes = result.data;
        $scope.loadingPlanes = false;
        $scope.StopLoading();
    }, function (reason) {
        msg = { title: 'Error Listar Planes' };
        Notification.error(msg);
    });
    /*Fin*/

    /*Funciones*/
    $scope.CambioPlan = function (plan) {
        if (typeof plan !== 'undefined') {
            fichaService.getSesionesxPlan(plan, 5).then(function (result) {
                $scope.Sesiones = result.data;
            }, function (reason) {
                msg = { title: 'Error Listar Planes' };
                Notification.error(msg);
            });
        };
    };

    $scope.CambiarSesion = function (sesion) {
        if (typeof sesion !== 'undefined') {
            waitingDialog.show('Obteniendo Datos...', { dialogSize: 'sm' });
            fichaService.getFichaKinesiologiasxReserva(sesion).then(function (result) {
                if (result.data.length !== 0) {
                    $('#collapseDataPaciente').collapse('show');
                    waitingDialog.hide();
                } else {
                    $('#collapseDataPaciente').collapse('hide');
                    waitingDialog.hide();
                };
            }, function (reason) {
                if (reason.errorcode == 404) {
                    if (parseInt(LoginService.getTipo()) == 5) {
                        msg = { title: 'Sesion Sin Ficha, Complete la ficha para esta sesion' };
                        Notification.warning(msg);
                        $('#collapseDataPaciente').collapse('hide');
                        waitingDialog.hide();
                        $element.modal('hide');                        
                    } else {
                        msg = { title: 'Sesion Sin Ficha' };
                        Notification.warning(msg);
                        $('#collapseDataPaciente').collapse('hide');
                        waitingDialog.hide();
                        $element.modal('hide');
                    };
                } else  {
                    msg = { title: 'Error al Buscar Ficha' };
                    Notification.error(msg);
                    $('#collapseDataPaciente').collapse('hide');
                    waitingDialog.hide();
                }
            });
        } else {
            $('#collapseDataPaciente').collapse('hide');
            waitingDialog.hide();
        };
    };

    $scope.registrarArchivo = function () {
        $scope.saving = true;
        waitingDialog.show('Cargando Archivo...', { dialogSize: 'sm' });
        $scope.Carga.Id = $scope.Sesion.Id
        archivoService.registrarArchivo($scope.Carga, $scope.ergoFile).then(function (result) {
            msg = { title: 'Archivo Cargado Exitosamente' };
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
