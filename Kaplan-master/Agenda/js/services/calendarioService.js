app.factory('ResumenCalendarioService', ['$http', '$q', function ($http, $q) {
    var ResumenCalendarioServ = [];

    ResumenCalendarioServ.getResumenCalendario = function (inFecha, inEspecialista) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getResumenCalendario?inFecha=' + inFecha + '&inEspecialista=' + inEspecialista
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

    return ResumenCalendarioServ;
}]);