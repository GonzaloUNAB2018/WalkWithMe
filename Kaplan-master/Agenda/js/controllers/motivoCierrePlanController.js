app.controller("motivoCierrePlanController", ['$scope', 'Notification', 'motivoCierrePlanService', 'tipoService', 'LoginService', '$location',
function ($scope, Notification, motivoCierrePlanService, tipoService, LoginService, $location) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        var vm = this;
        vm.header = {
            url: 'header.html'
        };

        $scope.MotivoCierre =
        {
            Id: -1,
            Nombre: null,
            Estado: 1
        };

        motivoCierrePlanService.getMotivosCierrePlan().then(function (result) {
            $scope.MotivosCierrePlan = result.data;
        }, function (reason) {
            Notification.error(reason.message);
        });

        $scope.registrarMotivo = function () {
            $("#btnGuardar").button('loading');
            motivoCierrePlanService.registrarMotivo($scope.MotivoCierre).then(function (result) {
                msg = { title: 'Registro guardado con éxito', message: "" };
                Notification.success(msg);
                motivoCierrePlanService.getMotivosCierrePlan().then(function (result) {
                    $scope.MotivosCierrePlan = result.data;
                }, function (reason) {
                    Notification.error(reason.message);
                });
                $("#btnGuardar").button('reset');
                $scope.MotivoCierre =
                {
                    Id: -1,
                    Nombre: null,
                    Estado: 1
                };
            }, function (reason) {
                msg = { title: 'Error guardando registro' };
                Notification.error(msg);
                $("#btnGuardar").button('reset');
            });
        };

        $scope.eliminarMotivo = function (id) {
            motivoCierrePlanService.eliminarMotivo(id)
                .then(function (result) {
                    msg = { title: 'Registro Eliminado con éxito', message: "" };
                    Notification.success(msg);
                    motivoCierrePlanService.getMotivosCierrePlan().then(function (result) {
                        $scope.MotivosCierrePlan = result.data;
                    }, function (reason) {
                        Notification.error(reason.message);
                    });
                }, function (reason) {
                    msg = { title: 'Error Eliminando registro' };
                    Notification.error(msg);
                });
        };
    };
}]);