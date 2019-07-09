app.factory('WindowsService', ['$http', '$q', '$window', function ($http, $q, $window) {
    var WindowsServ = [];

    WindowsServ.getVariable = function (variable) {
        return ($window.localStorage && $window.localStorage.getItem(variable));
    }

    WindowsServ.setVariable = function (variable, valor) {
        $window.localStorage && $window.localStorage.setItem(variable, valor);
    }

    return WindowsServ;
}]);