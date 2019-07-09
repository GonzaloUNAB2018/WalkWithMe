app.factory('agendaDiaHoraService', ['$http', '$q', function ($http, $q) {
    var AgendaDiaHoraServ = [];

    AgendaDiaHoraServ.getReservasHoraDia = function (inFecha, inDia, inHora) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getReservasDiaHora?inFecha=' + inFecha + '&inDia=' + inDia + '&inHora=' + inHora
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

    return AgendaDiaHoraServ;
}]);