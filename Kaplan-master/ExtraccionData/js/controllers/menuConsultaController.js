app.controller("menuConsultaController", ['$scope', 'Notification', 'LoginService', '$location', 'consultaService',
function ($scope, Notification, LoginService, $location, consultaService) {

    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        var vm = this;
        vm.header = {
            url: 'header.html'
        };
        $scope.tipo = LoginService.getTipo();
        $scope.Nombres = LoginService.getUserName();

        if ($scope.tipo == '1') {
            $scope.NombreEspecialidad = 'Secretaria'
        }
        else {
            $scope.NombreEspecialidad = 'Especialista'
        }

        /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Registros...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.loadingData = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingData);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        consultaService.getConsulta().then(function (result) {
            $scope.Registros = result.data;
            $scope.loadingData = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Cargando Datos' };
            Notification.error(msg);
            $scope.loadingData = false;
            $scope.StopLoading();
        });
    };

    $scope.CerrarSesion = function () {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    };

    $scope.Export = function () {
        $("#paraReporte").table2excel({
            filename: "Data.xls"
        });
    }


}]);