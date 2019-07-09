app.factory('especialistaService', ['$http', '$q', function ($http, $q) {
    var EspecialistaServ = [];

    EspecialistaServ.getEspecialistas = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getEspecialistas'
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

    EspecialistaServ.getEspecialista = function (rut, pasaporte) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getEspecialista?intRut=' + rut + '&strPasaporte=' + pasaporte
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

    EspecialistaServ.registrarEspecialista = function (especialista) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Especialista", angular.toJson(especialista))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarEspecialista',
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

    EspecialistaServ.getEspecialistaAusencias = function (idEspecialista) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getEspecialistaAusencias?prmIdEspecialista=' + idEspecialista
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

    EspecialistaServ.registrarAusencia = function (ausencia) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ausencia", angular.toJson(ausencia))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarAusencia',
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

    EspecialistaServ.EliminarAusencia = function (num) {
        var deferred = $q.defer();

        var myFormData = new FormData();
        var vAusencia = { 'Id': num };
        myFormData.append("Ausencia", angular.toJson(vAusencia))

        $http({
            method: 'POST',
            url: 'doPost.asmx/EliminarAusencia',
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

    EspecialistaServ.getEspecialistaAtencionHoras = function (idEspecialista) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getEspecialistaAtencionHoras?prmIdEspecialista=' + idEspecialista
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

    EspecialistaServ.registrarAtencionHora = function (atencion) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("AtencionHora", angular.toJson(atencion))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarAtencionHora',
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

    EspecialistaServ.EliminarAtencionHora = function (num) {
        var deferred = $q.defer();

        var myFormData = new FormData();
        var vAtencion = { 'Id': num };
        myFormData.append("AtencionHora", angular.toJson(vAtencion))

        $http({
            method: 'POST',
            url: 'doPost.asmx/EliminarAtencionHora',
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

    return EspecialistaServ;
}]);