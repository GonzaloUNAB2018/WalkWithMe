app.controller("fichaCargaArchivoController", ['$scope', 'ModalService', 'Notification', 'LoginService', '$location', 'archivoService', 'fichaService',
function ($scope, ModalService, Notification, LoginService, $location, archivoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {

        /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Archivos...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.loadingData = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingData);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        archivoService.getArchivos(fichaService.getRutPaciente()).then(function (result) {
            $scope.Archivos = result.data;
            $scope.loadingData = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Exámenes' };
            Notification.error(msg);
        });        

        $scope.NuevoArchivo = function () {
            ModalService.showModal({
                templateUrl: "views/modalArchivo.html",
                inputs: { id: -1 },
                controller: "modalArchivoController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        archivoService.getArchivos(fichaService.getRutPaciente()).then(function (result) {
                            $scope.Archivos = result.data;
                        }, function (reason) {
                            msg = { title: 'Error Listar Exámenes' };
                            Notification.error(msg);
                        });
                    };
                });
            });
        };

        $scope.Descargar = function (id, formato) {
            if (formato == "Excel") {
                format = 1
            }
            if (formato == "Texto") {
                format = 2
            }
            var url;
            url = "reports/verDocumento.aspx?inId=" + id + '&inTipo=Archivo&inFormato=' + format;
            window.open(url, '_blank');
        };

        //$scope.Eliminar = function (id) {
        //    waitingDialog.show('Eliminando Exámen...', { dialogSize: 'sm' });
        //    examenService.EliminarExamen(id).then(function (result) {
        //        examenService.getExamenes(fichaService.getRutPaciente()).then(function (result) {
        //            $scope.Examenes = result.data;
        //            msg = { title: 'Eliminado Exitosamente' };
        //            Notification.success(msg);
        //            waitingDialog.hide();
        //        }, function (reason) {
        //            msg = { title: 'Error Listar Exámenes' };
        //            Notification.error(msg);
        //            waitingDialog.hide();
        //        });
        //    }, function (reason) {
        //        msg = { title: 'Error Eliminar Exámen' };
        //        Notification.error(msg);
        //        waitingDialog.hide();
        //    });
        //};

        //$scope.Descargar = function (id) {
        //    var url;
        //    url = "reports/verDocumento.aspx?inId=" + id + '&inTipo=Examen';
        //    window.open(url, '_blank');
        //};

    };
}]);