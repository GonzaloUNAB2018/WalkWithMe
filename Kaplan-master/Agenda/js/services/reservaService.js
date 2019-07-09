app.factory('reservaService', ['$http', '$q', function ($http, $q) {
    var ReservaServ = [];

    ReservaServ.getReservasHoraDia = function (inFecha, inDia, inHora) {
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

    ReservaServ.getReserva = function (inId) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getReserva?inId=' + inId
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

    ReservaServ.getObservacion = function (inId) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getObservacion?inId=' + inId
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

    ReservaServ.getEstadisticaxReserva = function (inPaciente, inEspecialista) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getEstadisticaxReserva?inPaciente=' + inPaciente + '&inEspecialista=' + inEspecialista
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

    ReservaServ.getEspecialistasEsp = function (inEspecialidad) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getEspecialistasEsp?inEspecialidad=' + inEspecialidad
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

    ReservaServ.registrarReserva = function (inReserva) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Reserva", angular.toJson(inReserva))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarReserva',
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

    ReservaServ.anularReserva = function (inReserva) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Reserva", angular.toJson(inReserva))

        $http({
            method: 'POST',
            url: 'doPost.asmx/anularReserva',
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

    ReservaServ.registrarObservacion = function (inReserva) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Reserva", angular.toJson(inReserva))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarObservacion',
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

    return ReservaServ;
}]);