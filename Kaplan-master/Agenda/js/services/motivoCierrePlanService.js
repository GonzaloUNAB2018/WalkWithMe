app.factory('motivoCierrePlanService', ['$http', '$q', function ($http, $q) {
    var motivoCierrePlanServ = [];

    motivoCierrePlanServ.getMotivosCierrePlan = function () {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getMotivosCierrePlan'
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

    motivoCierrePlanServ.registrarMotivo = function (inMotivoCierre) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("MotivoCierre", angular.toJson(inMotivoCierre))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarMotivoCierrePlan',
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

    motivoCierrePlanServ.eliminarMotivo = function (inId) {
        var deferred = $q.defer();

        var myFormData = new FormData();
        var vMotivo = { 'Id': inId };
        myFormData.append("MotivoCierre", angular.toJson(vMotivo))

        $http({
            method: 'POST',
            url: 'doPost.asmx/EliminarMotivoCierrePlan',
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

    return motivoCierrePlanServ;
}]);