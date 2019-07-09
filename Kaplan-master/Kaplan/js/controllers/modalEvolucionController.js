app.controller("modalEvolucionController", ['$scope', 'ModalService', 'Notification', 'id', "$element", 'close', 'fichaService',
function ($scope, ModalService, Notification, id, $element, close, fichaService) {

    /*Validacion de Carga inicial*/
    waitingDialog.show('Cargando...', { dialogSize: 'sm' });
    $scope.loading = true;
    $scope.loadingData = true;
    $scope.StopLoading = function () {
        $scope.loading = !(!$scope.loadingData);
        if (!$scope.loading) { waitingDialog.hide(); }
    };
    /*Fin*/

    fichaService.getPlanesxRut(parseInt(fichaService.getRutPaciente())).then(function (result) {
        $scope.Planes = result.data;
        $scope.loadingData = false;
        $scope.StopLoading();
    }, function (reason) {
        msg = { title: 'Error Listar Planes' };
        Notification.error(msg);
    });

    $scope.CambioPlan = function (plan) {
        if (typeof plan !== 'undefined') {
            url = "reports/reporte.aspx?tipo=EVO&id=" + plan
            window.open(url, '_blank');
        };
    };

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };

}]);
