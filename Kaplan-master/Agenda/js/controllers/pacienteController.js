app.controller("pacienteController", ['$scope', '$http', 'ModalService', 'pacienteService', 'tipoService', 'Notification', 'LoginService', '$location',
function ($scope, $http, ModalService, pacienteService, TipoService, Notification, LoginService, $location) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingData);
        };

        var vm = this;
        vm.header = {
            url: 'header.html'
        };

        $scope.Paciente = {
            Id: -1,
            Estado: -1,
            Persona: {
                Id: -1,
                Rut: null,
                Dv: null,
                Nombre: null,
                Paterno: null,
                Materno: null,
                FechaNac: null,
                Sexo: { ID: null },
                Nacionalidad: { ID: null },
                Comuna: { ID: null },
                Region: { ID: null },
                Direccion: null,
                Email: null,
                Movil: null,
                Telefono: null,
                SituacionLaboral: null,
                EstadoCivil: { ID: null },
                Prevision: { ID: null }
            }
        };

        $scope.getRut = function () {
            $scope.loading = true;
            if ((typeof $scope.Paciente.Persona.Rut !== 'undefined' && $scope.Paciente.Persona.Rut !== null) && ($scope.Paciente.Persona.Dv !== "" && typeof $scope.Paciente.Persona.Dv !== 'undefined')) {
                var nuevo_numero = $scope.Paciente.Persona.Rut.toString().split("").reverse().join("");
                for (i = 0, j = 2, suma = 0; i < nuevo_numero.length; i++, ((j == 7) ? j = 2 : j++)) {
                    suma += (parseInt(nuevo_numero.charAt(i)) * j);
                }
                n_dv = 11 - (suma % 11);
                var dv = (n_dv == 11) ? 0 : ((n_dv == 10) ? "K" : n_dv);
                if ($scope.Paciente.Persona.Dv.toString().toUpperCase() !== dv.toString()) {
                    msg = { title: 'Advertencia', message: 'Rut no Valido' };
                    Notification.warning(msg);
                    setTimeout(function () { LimpiarDV() }, 100);
                    $scope.rutvalido = false;
                    $scope.loadingData = false;
                    $scope.StopLoading();
                    $('#collapseDataPaciente').collapse('hide');
                } else {
                    pacienteService.getPaciente($scope.Paciente.Persona.Rut, null).then(function (result) {
                        $scope.Paciente = result.data;
                        $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                        $scope.Titulo = $scope.Paciente.Persona.Nombre + " " + $scope.Paciente.Persona.Paterno + " " + $scope.Paciente.Persona.Materno;
                        $scope.RutPaciente = $scope.Paciente.Persona.Rut + "-" + $scope.Paciente.Persona.Dv;
                        $scope.loadingData = false;
                        $scope.StopLoading();
                        if ($scope.Paciente.Estado == 1) {
                            //msg = { title: 'Rut Valido' };
                            //Notification.success(msg);
                        } else {
                            msg = { title: 'Advertencia', message: 'Persona no registrada como paciente, complete los datos y guarde para registrar como paciente.' };
                            Notification.warning(msg);
                        }
                        $('#collapseDataPaciente').collapse('show');
                        $scope.rutvalido = true;
                        $scope.Mod = true;
                    }, function (reason) {
                        if (reason.errorcode == 404) {
                            msg = { title: 'Advertencia', message: 'Paciente no registrado, debe ingresar los datos del nuevo paciente.' };
                            Notification.warning(msg);
                            $('#collapseDataPaciente').collapse('show');
                            $scope.rutvalido = true;
                            $scope.Paciente.Id = -1;
                            $scope.Paciente.Estado = -1;
                            $scope.Paciente.Persona.Id = -1;
                            $scope.Paciente.Persona.Nombre = null;
                            $scope.Paciente.Persona.Paterno = null;
                            $scope.Paciente.Persona.Materno = null;
                            $scope.Paciente.Persona.FechaNac = null;
                            $scope.Paciente.Persona.Nacionalidad.ID = null;
                            $scope.Paciente.Persona.Comuna.ID = null;
                            $scope.Paciente.Persona.Direccion = null;
                            $scope.Paciente.Persona.Email = null;
                            $scope.Paciente.Persona.Movil = null;
                            $scope.Paciente.Persona.Telefono = null;
                            $scope.Paciente.Persona.SituacionLaboral = null;
                            $scope.Paciente.Persona.EstadoCivil.ID = null;
                            $scope.Paciente.Persona.Sexo.ID = null;
                            $scope.Paciente.Persona.Region.ID = null;
                            $scope.Paciente.Persona.Prevision.ID = null;
                            $scope.Mod = false;
                            $scope.loadingData = false;
                            $scope.StopLoading();
                        } else {
                            msg = { title: 'Error al intentar consultar rut' };
                            Notification.error(msg);
                            $scope.rutvalido = false;
                            $('#collapseDataPaciente').collapse('hide');
                            $scope.loadingData = false;
                            $scope.StopLoading();
                        }
                    });
                };
            };
            function LimpiarDV() {
                $scope.Paciente.Persona.Dv = "";
            }
        };

        $scope.registrarPaciente = function () {

            if ($scope.Paciente.Persona.Id == -1) {
                $("#btnGuardar").button('loading');
            } else {
                $("#btnModificar").button('loading');
            }
            $scope.Paciente.Licencias = null;            
            $scope.Paciente.Reservas = null;
            $scope.Paciente.Planes = null;
            pacienteService.registrarPaciente($scope.Paciente).then(function (result) {
                if ($scope.Paciente.Persona.Id == -1) {
                    $("#btnGuardar").button('reset');
                    msg = { title: 'Registro guardado con éxito' };
                    Notification.success(msg);
                } else {
                    $("#btnModificar").button('reset');
                    msg = { title: 'Registro modificado con éxito' };
                    Notification.success(msg);
                }
                TipoService.getPacientesFiltro().then(function (result) {
                    $scope.PacientesFiltro = result.data;
                }, function (reason) {
                    msg = { title: 'Error Lista de Pacientes Filtro' };
                    Notification.error(msg);
                });
                $scope.getRut();
                $scope.Limpiar();
            }, function (reason) {
                msg = { title: 'Error', message: 'Error guardando registro' };
                Notification.error(msg);
                if ($scope.Paciente.Persona.Id == -1) {
                    $("#btnGuardar").button('reset');
                } else {
                    $("#btnModificar").button('reset');
                }
            });
        };

        $scope.nuevaLicencia = function () {
            ModalService.showModal({
                templateUrl: "views/licencia.html",
                inputs: { rut: $scope.Paciente.Id, id: -1, inicio: null, termino: null, obs: null },
                controller: "licenciaController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        $scope.getRut();
                    }
                });
            });
        };

        $scope.editarLicencia = function (id, inicio, termino, obs) {
            ModalService.showModal({
                templateUrl: "views/licencia.html",
                inputs: { rut: $scope.Paciente.Id, id: id, inicio: inicio, termino: termino, obs: obs },
                controller: "licenciaController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        $scope.getRut();
                    }
                });
            });
        };

        $scope.nuevoPlan = function (idPlan, descripcion, nombre, cantidad) {
            ModalService.showModal({
                templateUrl: "views/Plan.html",
                inputs: { rut: $scope.Paciente.Id, id: idPlan, nombre: nombre, cantidad: cantidad, descripcion: descripcion },
                controller: "planController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        $scope.getRut();
                    }
                });
            });
        };

        $scope.anularReserva = function (id) {
            ModalService.showModal({
                templateUrl: "views/reservaAnular.html",
                inputs: { id: id },
                controller: "reservaAnularController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        $scope.getRut();
                    }
                });
            });
        };

        $scope.agregarObservacion = function (id) {
            ModalService.showModal({
                templateUrl: "views/reservaObservacion.html",
                inputs: { id: id },
                controller: "reservaObservacionController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        $scope.getRut();
                    }
                });
            });
        };

        $scope.tipo = LoginService.getTipo();

        $scope.finalizarPlan = function (id) {
            ModalService.showModal({
                templateUrl: "views/finalizarPlan.html",
                inputs: { id: id },
                controller: "finalizarPlanController"
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result) {
                        $scope.getRut();
                    }
                });
            });
        };

        $scope.Limpiar = function () {
            $scope.Paciente = {
                Id: -1,
                Estado: -1,
                Persona: {
                    Id: -1,
                    Rut: null,
                    Dv: null,
                    Nombre: null,
                    Paterno: null,
                    Materno: null,
                    FechaNac: null,
                    Sexo: { ID: null },
                    Nacionalidad: { ID: null },
                    Comuna: { ID: null },
                    Region: { ID: null },
                    Direccion: null,
                    Email: null,
                    Movil: null,
                    Telefono: null,
                    SituacionLaboral: null,
                    EstadoCivil: { ID: null },
                    Prevision: { ID: null }
                }
            };
            $scope.rutvalido = false;
            $('#collapseDataPaciente').collapse('hide');
        };

        $scope.Exportar = function () {
            var url = 'VerDocumentoCsv.aspx?tipo=ReporteMasivo&prmRut=' + $scope.Paciente.Persona.Rut
            window.open(url, '_blank')
        };

        $scope.FiltrarPaciente = function (rutFiltro) {
            if (rutFiltro !== null) {
                $scope.Paciente.Persona.Rut = parseInt(rutFiltro.toString().substring(0, rutFiltro.toString().length - 1));
                $scope.Paciente.Persona.Dv = rutFiltro.toString().charAt(rutFiltro.toString().length - 1);
                $scope.getRut();
            }
        };

        TipoService.getPacientesFiltro().then(function (result) {
            $scope.PacientesFiltro = result.data;
        }, function (reason) {
            msg = { title: 'Error Lista de Pacientes Filtro' };
            Notification.error(msg);
        });

        TipoService.getTipoEstadoCivil().then(function (result) {
            $scope.TipoEstadoCiviles = result.data;
        }, function (reason) {
            msg = { title: 'Error Lista de Tipo Estados Civiles' };
            Notification.error(msg);
        });

        TipoService.getTipoSexo().then(function (result) {
            $scope.TipoSexos = result.data;
        }, function (reason) {
            msg = { title: 'Error Lista de Tipo Sexo' };
            Notification.error(msg);
        });

        TipoService.getTipoRegion().then(function (result) {
            $scope.TipoRegiones = result.data;
        }, function (reason) {
            msg = { title: 'Error Lista de Regiones' };
            Notification.error(msg);
        });

        TipoService.getTipoComuna().then(function (result) {
            $scope.TipoComunas = result.data;
        }, function (reason) {
            msg = { title: 'Error Lista de Comunas' };
            Notification.error(msg);
        });

        TipoService.getTipoPais().then(function (result) {
            $scope.TipoNacionalidades = result.data;
        }, function (reason) {
            msg = { title: 'Error Lista de Paises' };
            Notification.error(msg);
        });

        TipoService.getTipoPrevision().then(function (result) {
            $scope.TipoPrevisiones = result.data;
        }, function (reason) {
            msg = { title: 'Error Lista de Previsiones de Salud' };
            Notification.error(msg);
        });

        TipoService.getTipoEspecialidad().then(function (result) {
            $scope.Especialidades = result.data;
        }, function (reason) {
            msg = { title: 'Error Lista de Tipo Especialidades' };
            Notification.error(msg);
        });
    }
}]);
app.filter('CantidadEstados', function () {
    return function (data, key, filter) {
        if (!key && !filter) {
            return data.length;
        }
        var arr = [];
        angular.forEach(data, function (v) {
            if (filter) {
                if (v.Estado.ID === key && v.Especialista.Especialidad.ID == filter) {
                    arr.push(v);
                }
            } else {
                if (v.Estado.ID === key) {
                    arr.push(v);
                }
            }
        })
        return arr.length;
    }
})
app.filter('filterEstados', function () {
    return function (data, filter) {
        if (!filter) {
            return data;
        }
        var arr = [];
        angular.forEach(data, function (v) {
            if (v.Especialista.Especialidad.ID === filter) {
                arr.push(v);
            }
        })

        return arr;
    }
})

