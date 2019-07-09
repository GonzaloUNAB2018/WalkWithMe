app.factory('examenService', ['$http', '$q', function ($http, $q) {
    var ExamenServ = [];

    ExamenServ.getExamenes = function (rut) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getExamenes?inRut=' + rut
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

    ExamenServ.registrarExamen = function (examen, archivo) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("documento", archivo)
        myFormData.append("Examen", angular.toJson(examen));
        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarExamen',
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

    ExamenServ.EliminarExamen = function (id) {
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

    return ExamenServ;
}]);