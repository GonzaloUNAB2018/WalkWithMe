app.factory('LoginService', ['$http', '$q', 'WindowsService', '$location', function ($http, $q, WindowsService, $location) {
    var LoginServ = [];
    var v_tipo;
    var v_id;
    var v_user;
    var isAuthenticated = false;

    LoginServ.getIngresar = function (Usuario) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Usuario", angular.toJson(Usuario))

        $http({
            method: 'POST',
            url: 'doPost.asmx/getIngresar',
            data: myFormData,
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result)
            { deferred.resolve(response.data); }
            else
            { deferred.reject(response.data) }
        }
        function onFailure(response) {
            deferred.reject(response);;
        };

        return deferred.promise;
    };

    LoginServ.getLoginServer = function (Login) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getLogin?strUser=' + Login
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result)
            { deferred.resolve(response.data); }
            else
            { deferred.reject(response.data) }
        }
        function onFailure(response) {
            deferred.reject(response);
        };
        return deferred.promise;

    };

    LoginServ.getLoginLocal = function (Usuario) {
        WindowsService.setVariable('isAuthenticated', true);
        WindowsService.setVariable('v_tipo', Usuario.Tipo);
        WindowsService.setVariable('v_id', Usuario.Id);
        WindowsService.setVariable('v_user', Usuario.User);
        WindowsService.setVariable('v_username', Usuario.Nombres);
        WindowsService.setVariable('v_idespecialista', Usuario.IdEspecialista);
        return true;
    };

    LoginServ.getisAuthenticated = function () {
        return WindowsService.getVariable('isAuthenticated');
    };

    LoginServ.getId = function () {
        return WindowsService.getVariable('v_id');
    };

    LoginServ.getTipo = function () {
        return WindowsService.getVariable('v_tipo');
    };

    LoginServ.getUser = function () {
        return WindowsService.getVariable('v_user');
    };

    LoginServ.getUserName = function () {
        return WindowsService.getVariable('v_username');
    };

    LoginServ.getIdEspecialista = function () {
        return WindowsService.getVariable('v_idespecialista');
    };

    LoginServ.getCerrarSesion = function () {
        window.localStorage.clear()
        return true;
    };

    return LoginServ;
}]);