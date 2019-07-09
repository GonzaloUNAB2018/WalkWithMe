app.factory('registromedicoService', ['$http', '$q', function ($http, $q) {
    var RegistroServ = [];

    RegistroServ.getRegistrosMedicos = function (rut) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getRegistrosMedicos?inRut=' + rut
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

    RegistroServ.registrarRegistroMedico = function (Registro) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Registro", angular.toJson(Registro));
        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarRegistroMedico',
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

    RegistroServ.EliminarRegistro = function (id) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("ID", angular.toJson(id));
        $http({
            method: 'POST',
            url: 'doPost.asmx/EliminarRegistroMedico',
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

    RegistroServ.MarcarLeidoRegistro = function (id, idEspecialista) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("ID", angular.toJson(id));
        myFormData.append("IdEspecialista", angular.toJson(idEspecialista));
        $http({
            method: 'POST',
            url: 'doPost.asmx/MarcarLeidoRegistroMedico',
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

    return RegistroServ;
}]);