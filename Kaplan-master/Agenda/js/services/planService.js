app.factory('planService', ['$http', '$q', function ($http, $q) {
    var PlanServ = [];

    PlanServ.registrarPlan = function (Plan) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Plan", angular.toJson(Plan))

        $http({
            method: 'POST',
            url: 'doPost.asmx/registrarPlan',
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

    PlanServ.FinalizarPlan = function (Plan) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Plan", angular.toJson(Plan))

        $http({
            method: 'POST',
            url: 'doPost.asmx/finalizarPlan',
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

    return PlanServ;
}]);