app.controller("reservaController", ['$scope', 'ModalService', 'reservaService', 'Notification', 'pacienteService', 'tipoService', 'fecha', 'dia', 'hora', "$element", 'close',
function ($scope, ModalService, reservaService, Notification, pacienteService, TipoService, fecha, dia, hora, $element, close) {

    $scope.loading = true;
    $scope.loadingEspecialistas = true;
    $scope.loadingEspecialidad = true;
    $scope.loadingReserva = true;
    $scope.StopLoading = function () {
        $scope.loading = !(!$scope.loadingEspecialistas && !$scope.loadingEspecialidad && !$scope.loadingReserva);
    };

    $scope.Reserva = {
        Id: -1,
        Estado: -1,
        Paciente: {
            Id: -1,
        },
        Especialista: {
            Id: -1,
        },
        Plan: {
            Id: -1,
        },
        Fecha: moment(fecha).locale('es').format('dddd') + ' ' + moment(fecha).locale('es').format('L'),
        Hora: hora,
        Tipo: { ID: -1 },
        Estado: { ID: -1 }
    };

    $scope.registrarReserva = function () {
        $scope.Reserva.Fecha = fecha;
        reservaService.registrarReserva($scope.Reserva).then(function (result) {
            msg = { title: 'Reserva registrada con éxito', message: "" };
            Notification.success(msg);
            $element.modal('hide');
            close(true, 500);
        }, function (result) {
            msg = { title: result.message };
            Notification.error(msg);
        });
    };

    $scope.getRut = function () {
        if ((typeof $scope.Rut !== 'undefined' && $scope.Rut !== null) && ($scope.Dv !== "" && typeof $scope.Dv !== 'undefined')) {
            var nuevo_numero = $scope.Rut.toString().split("").reverse().join("");
            for (i = 0, j = 2, suma = 0; i < nuevo_numero.length; i++, ((j == 7) ? j = 2 : j++)) {
                suma += (parseInt(nuevo_numero.charAt(i)) * j);
            }
            n_dv = 11 - (suma % 11);
            var dv = (n_dv == 11) ? 0 : ((n_dv == 10) ? "K" : n_dv);
            if ($scope.Dv.toString().toUpperCase() !== dv.toString()) {
                msg = { title: 'Advertencia', message: 'Rut no Valido' };
                Notification.warning(msg);
                setTimeout(function () { LimpiarDV() }, 100);
                $scope.rutvalido = false;
            } else {
                pacienteService.getPaciente($scope.Rut, null).then(function (result) {
                    $scope.Paciente = result.data;
                    $scope.Reserva.Paciente.Id = $scope.Paciente.Id;
                    if ($scope.Paciente.Estado == 1) {
                        //msg = { title: 'Rut Valido' };
                        //Notification.success(msg);
                        $scope.rutvalido = true;
                    } else {
                        msg = { title: 'Advertencia', message: 'Persona no registrada como paciente, complete los datos y guarde para registrar como paciente.' };
                        Notification.warning(msg);
                        $scope.Reserva.Rut = null;
                        $scope.Reserva.Dv = null;
                        $scope.Reserva.Nombre = null;
                        $scope.Reserva.Paterno = null;
                        $scope.Reserva.Materno = null;
                    }
                    $scope.Mod = true;
                }, function (reason) {
                    if (reason.errorcode == 404) {
                        msg = { title: 'Advertencia', message: 'Paciente no registrado, debe ingresar los datos del nuevo paciente.' };
                        Notification.warning(msg);
                        $scope.Reserva.Rut = null;
                        $scope.Reserva.Dv = null;
                        $scope.Reserva.Nombre = null;
                        $scope.Reserva.Paterno = null;
                        $scope.Reserva.Materno = null;
                    } else {
                        msg = { title: 'Error al intentar consultar rut' };
                        Notification.error(msg);
                        $scope.rutvalido = false;
                    }
                });
            };
        };
        function LimpiarDV() {
            $scope.Reserva.Dv = "";
        }
    };

    $scope.FiltrarPaciente = function (rutFiltro) {
        if (rutFiltro !== null) {
            $scope.Rut = parseInt(rutFiltro.toString().substring(0, rutFiltro.toString().length - 1));
            $scope.Dv = rutFiltro.toString().charAt(rutFiltro.toString().length - 1);
            $scope.getRut();
        }
    };

    TipoService.getPacientesFiltro().then(function (result) {
        $scope.PacientesFiltro = result.data;
    }, function (reason) {
        msg = { title: 'Error Lista de Pacientes Filtro' };
        Notification.error(msg);
    });

    $scope.cargarEspecialistas = function (inEspecialidad) {
        if (inEspecialidad !== undefined) {
            reservaService.getEspecialistasEsp(inEspecialidad).then(function (result) {
                $scope.Especialistas = result.data;
                $scope.loadingEspecialistas = false;
                $scope.StopLoading();
            }, function (reason) {
                msg = { title: 'Error recuperando listado especialistas' };
                Notification.error(msg);
                $element.modal('hide');
            });
        }
    };

    $scope.EstadisticaxReserva = function (inPaciente , inEspecialidad) {
        if (inEspecialidad !== undefined && inPaciente !== undefined) {
            reservaService.getEstadisticaxReserva(inPaciente, inEspecialidad).then(function (result) {
                $scope.anuladas = result.data.reservasanuladas;
                $scope.total = result.data.totalreservas;
            }, function (reason) {
                msg = { title: 'Error recuperando listado estadisticas' };
                Notification.error(msg);
            });
        }
    };

    TipoService.getTipoEspecialidad().then(function (result) {
        $scope.Especialidades = result.data;
        $scope.loadingEspecialidad = false;
        $scope.StopLoading();
    }, function (reason) {
        msg = { title: 'Error Lista de Tipo Especialidades' };
        Notification.error(msg);
    });

    TipoService.getTipoReserva().then(function (result) {
        $scope.TipoReserva = result.data;
        $scope.loadingReserva = false;
        $scope.StopLoading();
    }, function (reason) {
        msg = { title: 'Error Lista de Tipo Reserva' };
        Notification.error(msg);
    });

    $scope.filterPlanActivo = function () {

        return function (item) {

            if (item.Estado.ID == 1) {

                return true;

            }

            return false;

        };

    };

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };

}]);
