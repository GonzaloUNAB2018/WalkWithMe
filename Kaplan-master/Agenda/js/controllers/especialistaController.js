app.controller("especialistaController", ['$scope', '$http', 'especialistaService', 'tipoService', 'Notification','LoginService','$location',
function ($scope, $http, especialistaService, TipoService, Notification, LoginService, $location) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        var vm = this;
        vm.header = {
            url: 'header.html'
        };

        $scope.Especialista =
                 {
                     Id: -1,
                     Estado: -1,
                     Especialidad: { ID: null },
                     Persona: {
                         Id: -1,
                         Rut: null,
                         Dv: null,
                         Nombre: null,
                         Paterno: null,
                         Materno: null,
                         FechaNac: null,
                         Sexo: { ID: null },
                         Email: null,
                         Movil: null,
                         Telefono: null
                     }

                 };

        $scope.loading = true;
        $scope.loadingGrid = true;
        $scope.loadingTipoSexo = true;
        $scope.loadingTipoEspecialidad = true;

        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingGrid && !$scope.loadingTipoSexo && !$scope.loadingTipoEspecialidad);
        };

        //Listado de Especialistas
        especialistaService.getEspecialistas().then(function (result) {
            $scope.Especialistas = result.data;
            $scope.loadingGrid = false;
            $scope.StopLoading();
        }, function (reason) {
            Notification.error(reason.message);
        });

        $scope.Limpiar = function () {
            $scope.Especialista.Id = -1;
            $scope.Especialista.Estado = -1;
            $scope.Especialista.Persona.Id = -1;
            $scope.Especialista.Persona.Rut = null;
            $scope.Especialista.Persona.Dv = null;
            $scope.Especialista.Persona.Nombre = null;
            $scope.Especialista.Persona.Paterno = null;
            $scope.Especialista.Persona.Materno = null;
            $scope.Especialista.Persona.FechaNac = null;
            $scope.Especialista.Persona.Email = null;
            $scope.Especialista.Persona.Movil = null;
            $scope.Especialista.Persona.Telefono = null;
            $scope.Especialista.Persona.Sexo.ID = null;
            $scope.Especialista.Especialidad.ID = null;
            $scope.rutvalido = false;
            $('#collapseDataEspecialista').collapse('hide');
        };

        $scope.Nuevo = function () {
            $scope.rutvalido = false;
            $scope.Mod = false;
            $('#collapseDataEspecialista').collapse('show');
            document.getElementById("rut").focus();
            $scope.Especialista.Id = -1;
            $scope.Especialista.Estado = -1;
            $scope.Especialista.Persona.Id = -1;
            $scope.Especialista.Persona.Rut = null;
            $scope.Especialista.Persona.Dv = null;
            $scope.Especialista.Persona.Nombre = null;
            $scope.Especialista.Persona.Paterno = null;
            $scope.Especialista.Persona.Materno = null;
            $scope.Especialista.Persona.FechaNac = null;
            $scope.Especialista.Persona.Email = null;
            $scope.Especialista.Persona.Movil = null;
            $scope.Especialista.Persona.Telefono = null;
            $scope.Especialista.Persona.Sexo.ID = null;
            $scope.Especialista.Especialidad.ID = null;
        };

        $scope.getRut = function () {
            if ((typeof $scope.Especialista.Persona.Rut !== 'undefined' && $scope.Especialista.Persona.Rut !== null) && ($scope.Especialista.Persona.Dv !== "" && $scope.Especialista.Persona.Dv !== null && typeof $scope.Especialista.Persona.Dv !== 'undefined')) {
                var nuevo_numero = $scope.Especialista.Persona.Rut.toString().split("").reverse().join("");
                for (i = 0, j = 2, suma = 0; i < nuevo_numero.length; i++, ((j == 7) ? j = 2 : j++)) {
                    suma += (parseInt(nuevo_numero.charAt(i)) * j);
                }
                n_dv = 11 - (suma % 11);
                var dv = (n_dv == 11) ? 0 : ((n_dv == 10) ? "K" : n_dv);
                if ($scope.Especialista.Persona.Dv.toString().toUpperCase() !== dv.toString()) {
                    msg = { title: 'Advertencia', message: 'Rut no Valido' };
                    Notification.warning(msg);
                    setTimeout(function () { LimpiarDV() }, 100);
                    $scope.rutvalido = false;
                } else {
                    especialistaService.getEspecialista($scope.Especialista.Persona.Rut, null).then(function (result) {
                        $scope.Especialista = result.data;
                        $scope.Especialista.Persona.FechaNac = moment($scope.Especialista.Persona.FechaNac);
                        if ($scope.Especialista.Estado == 1) {
                            msg = { title: 'Especialista ya ingresado' };
                            Notification.success(msg);
                            $('#collapseDataEspecialista').collapse('hide');
                        } else {
                            msg = { title: 'Advertencia', message: 'Persona no registrada como especialista, complete los datos y guarde para registrar como especialista.' };
                            Notification.warning(msg);
                            $('#collapseDataEspecialista').collapse('show');
                        }
                        $scope.rutvalido = true;
                        $scope.Mod = false;
                    }, function (reason) {
                        if (reason.errorcode == 404) {
                            msg = { title: 'Advertencia', message: 'Especialista no registrado, debe ingresar los datos del nuevo especialista.' };
                            Notification.warning(msg);
                            $('#collapseDataEspecialista').collapse('show');
                            $scope.rutvalido = true;
                            $scope.Mod = false;
                            $scope.Especialista.Id = -1;
                            $scope.Especialista.Estado = -1;
                            $scope.Especialista.Persona.Id = -1;
                            $scope.Especialista.Persona.Nombre = null;
                            $scope.Especialista.Persona.Paterno = null;
                            $scope.Especialista.Persona.Materno = null;
                            $scope.Especialista.Persona.FechaNac = null;
                            $scope.Especialista.Persona.Email = null;
                            $scope.Especialista.Persona.Movil = null;
                            $scope.Especialista.Persona.Telefono = null;
                            $scope.Especialista.Persona.Sexo.ID = null;
                            $scope.Especialista.Especialidad.ID = null;
                        } else {
                            msg = { title: 'Error al intentar consultar rut' };
                            Notification.error(msg);
                            $scope.rutvalido = false;
                            $('#collapseDataEspecialista').collapse('hide');
                        }
                    });
                };
            };
            function LimpiarDV() {
                $scope.Especialista.Persona.Dv = "";
            }
        };


        $scope.Modificar = function (rut) {
            especialistaService.getEspecialista(rut, null).then(function (result) {
                $scope.Especialista = result.data;
                $scope.Especialista.Persona.FechaNac = moment($scope.Especialista.Persona.FechaNac);
                $scope.rutvalido = true;
                $scope.Mod = true;
                $('#collapseDataEspecialista').collapse('show');
            }, function (reason) {
                msg = { title: 'Error al intentar consultar rut' };
                Notification.error(msg);
                $scope.rutvalido = false;
                $scope.Mod = false;
                $('#collapseDataEspecialista').collapse('hide');
            });
        }

        $scope.registrarEspecialista = function () {
            especialistaService.registrarEspecialista($scope.Especialista).then(function (result) {
                msg = { title: 'Registro guardado con éxito', message: "" };
                Notification.success(msg);
                $scope.Limpiar();
                especialistaService.getEspecialistas().then(function (result) {
                    $scope.Especialistas = result.data;
                }, function (reason) {
                    Notification.error(reason.message);
                });
            }, function (reason) {
                msg = { title: 'Error guardando registro' };
                Notification.error(msg);
            });
        };

        TipoService.getTipoEspecialidad().then(function (result) {
            $scope.TipoEspecialidades = result.data;
            $scope.loadingTipoEspecialidad = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Especialidades' };
            Notification.error(msg);
        });

        TipoService.getTipoSexo().then(function (result) {
            $scope.TipoSexos = result.data;
            $scope.loadingTipoSexo = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Sexo' };
            Notification.error(msg);
        });
    }
}]);

