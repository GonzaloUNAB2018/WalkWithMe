app.factory('archivoService', ['$http', '$q', function ($http, $q) {
    var ArchivoServ = [];

    ArchivoServ.getArchivos = function (rut) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getArchivos?inRut=' + rut
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

    ArchivoServ.registrarArchivo = function (carga, archivo) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("archivo", archivo)
        myFormData.append("carga", angular.toJson(carga));
        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarArchivo',
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

    ArchivoServ.EliminarExamen = function (id) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("ID", angular.toJson(id));
        $http({
            method: 'POST',
            url: 'doPost.asmx/EliminarExamen',
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

    return ArchivoServ;
}]);