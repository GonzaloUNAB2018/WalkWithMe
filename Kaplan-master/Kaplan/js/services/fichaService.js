app.factory('fichaService', ['$http', '$q', 'WindowsService', function ($http, $q, WindowsService) {
    var FichaServ = [];

    /*  Generales   */
    FichaServ.getPaciente = function (rut, pasaporte) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getPaciente?intRut=' + rut + '&strPasaporte=' + pasaporte
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

    FichaServ.getPacienteLocal = function (rut, ficha) {
        WindowsService.setVariable('isValid', true);
        WindowsService.setVariable('v_rutpaciente', rut);
        WindowsService.setVariable('v_ficha', ficha)
        return true;
    };

    FichaServ.getPacienteIDLocal = function (rut) {
        WindowsService.setVariable('v_idrutpaciente', rut);
        return true;
    };

    FichaServ.getLimpiarPacienteLocal = function (rut, ficha) {
        window.localStorage.removeItem("v_rutpaciente");
        window.localStorage.removeItem("v_idrutpaciente");
        window.localStorage.removeItem("v_ficha");
        WindowsService.setVariable('isValid', false);
        return true;
    };

    FichaServ.getisRutvalido = function () {
        return WindowsService.getVariable('isValid');
    };

    FichaServ.getIDPaciente = function () {
        return WindowsService.getVariable('v_idrutpaciente');
    };

    FichaServ.getidFicha = function () {
        return WindowsService.getVariable('v_ficha');
    };

    FichaServ.getRutPaciente = function () {
        return WindowsService.getVariable('v_rutpaciente');
    };

    FichaServ.getPlanesxRut = function (rut) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getPlanesxRut?intRut=' + rut
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

    FichaServ.getSesionesxPlan = function (plan, especialidad) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getSesionesxPlan?intPlan=' + plan + '&intEspecialidad=' + especialidad
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

    /*  Kinesiología    */
    FichaServ.getFichaKinesiologiasxReserva = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichaKinesiologiasxReserva?intReserva=' + id
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
    FichaServ.SaveFichaKinesiologia = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaKinesiologia',
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
    /*  Psicología    */
    FichaServ.getFichaPsicologiaxReserva = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichaPsicologiasReserva?intReserva=' + id
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
    FichaServ.SaveFichaPsicologia = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaPsicologia',
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
    /*  Enfermeria    */
    FichaServ.getFichaEnfermeriaxReserva = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichaEnfermeriaxReserva?intReserva=' + id
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
    FichaServ.SaveFichaEnfermeria = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaEnfermeria',
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
    /*  Nutrición    */
    FichaServ.getFichaNutricionxReserva = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichaNutricionReserva?intReserva=' + id
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
    FichaServ.SaveFichaNutricion = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaNutricion',
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
    /*  Medico  */
    FichaServ.getFichaMedicoxReserva = function (id) {
        var deferred = $q.defer();
        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getFichaMedicoxReserva?intReserva=' + id
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
    FichaServ.SaveFichaMedico = function (ficha, paciente) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("Ficha", angular.toJson(ficha))
        myFormData.append("paciente", angular.toJson(paciente))

        $http({
            method: 'POST',
            url: 'doPost.asmx/SaveFichaMedico',
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
    return FichaServ;
}]);