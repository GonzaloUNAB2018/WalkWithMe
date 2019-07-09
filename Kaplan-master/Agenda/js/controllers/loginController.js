app.controller("loginController", ['$scope', 'Notification', '$location', 'LoginService',
function ($scope, Notification, $location, LoginService) {

    $scope.formSubmit = function () {  
        $("#btnGuardar").button('loading');
        $scope.Usuario.Pass = md5($scope.Usuario.Pass);
        LoginService.getIngresar($scope.Usuario)
            .then(function (result) {
                LoginService.getLoginServer($scope.Usuario.User).then(function (result) {
                    $scope.Usuario = result.data;
                    LoginService.getLoginLocal($scope.Usuario)
                    $location.path('calendario');
                }, function (reason) {
                    msg = { title: 'Error recuperando datos de usuarios' };
                    Notification.error(msg);
                    $("#btnGuardar").button('reset');
                });

            }, function (reason) {
                Notification.error(reason.message);
                $("#btnGuardar").button('reset');
            });
    };
}]);

