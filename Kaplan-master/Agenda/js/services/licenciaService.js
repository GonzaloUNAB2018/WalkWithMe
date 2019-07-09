app.factory('licenciaService', ['$http', '$q', function ($http, $q) {
    var LicenciaServ = [];

    LicenciaServ.registrarLicencia = function (inLicencia) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Licencia", angular.toJson(inLicencia))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarLicencia',
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

    return LicenciaServ;
}]);