app.controller("fichaPsicologiaController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        $scope.mostrarReporte = true;
        waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.TiposSintomatologia = true;

        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTiposSintomatologia);
            if (!$scope.loading) { waitingDialog.hide(); }
        };

        if (parseInt(LoginService.getTipo()) == 4) {
            $scope.FormEditabe = false;
        } else {
            $scope.FormEditabe = true;
        };
        
        fichaService.getPlanesxRut(parseInt(fichaService.getRutPaciente())).then(function (result) {
            $scope.Planes = result.data;
            $scope.loadingPlanes = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Planes' };
            Notification.error(msg);
        });
        $scope.CambioPlan = function (plan) {
            if (typeof plan !== 'undefined') {
                fichaService.getSesionesxPlan(plan, 4).then(function (result) {
                    $scope.Sesiones = result.data;
                }, function (reason) {
                    msg = { title: 'Error Listar Planes' };
                    Notification.error(msg);
                });
            };
        };
        $scope.CambiarSesion = function (sesion) {
            if (typeof sesion !== 'undefined') {
                waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
                fichaService.getFichaPsicologiaxReserva(sesion).then(function (result) {
                    if (result.data.length !== 0) {
                        $scope.mostrarReporte = false;
                        $scope.Ficha = result.data;
                        $scope.Ficha.FichaPsicologia.Sf36.FechaAIng = moment($scope.Ficha.FichaPsicologia.Sf36.FechaAIng);
                        $scope.Ficha.FichaPsicologia.Sf36.FechaAEgr = moment($scope.Ficha.FichaPsicologia.Sf36.FechaAEgr);
                        $scope.Ficha.FichaPsicologia.Sf36.FechaBIng = moment($scope.Ficha.FichaPsicologia.Sf36.FechaBIng);
                        $scope.Ficha.FichaPsicologia.Sf36.FechaBEgr = moment($scope.Ficha.FichaPsicologia.Sf36.FechaBEgr);
                        $scope.Ficha.FichaPsicologia.Had.FechaAIng = moment($scope.Ficha.FichaPsicologia.Had.FechaAIng);
                        $scope.Ficha.FichaPsicologia.Had.FechaAEgr = moment($scope.Ficha.FichaPsicologia.Had.FechaAEgr);
                        $scope.Ficha.FichaPsicologia.Had.FechaBIng = moment($scope.Ficha.FichaPsicologia.Had.FechaBIng);
                        $scope.Ficha.FichaPsicologia.Had.FechaBEgr = moment($scope.Ficha.FichaPsicologia.Had.FechaBEgr);
                        fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                            $scope.Paciente = result.data;
                            $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                            $('#collapseDataPaciente').collapse('show');
                            waitingDialog.hide();
                        }, function (reason) {
                            msg = { title: 'Error Al cargar datos del paciente' };
                            Notification.error(msg);
                            $('#collapseDataPaciente').collapse('hide');
                            waitingDialog.hide();
                        });
                    } else {
                        $('#collapseDataPaciente').collapse('hide');
                        waitingDialog.hide();
                    };
                }, function (reason) {
                    if (reason.errorcode == 404) {
                        if (parseInt(LoginService.getTipo()) == 4) {
                            msg = { title: 'Sesion Sin Ficha, Complete la ficha para esta sesion' };
                            Notification.warning(msg);
                            fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                                $scope.Paciente = result.data;
                                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                                $scope.Ficha = { FichaKinesiologia: { Id: -1, IdReserva: sesion } };
                                $('#collapseDataPaciente').collapse('show');
                                waitingDialog.hide();
                            }, function (reason) {
                                msg = { title: 'Error Al cargar datos del paciente' };
                                Notification.error(msg);
                                $('#collapseDataPaciente').collapse('hide');
                                waitingDialog.hide();
                            });
                        } else {
                            msg = { title: 'Sesion Sin Ficha' };
                            Notification.warning(msg);
                            $('#collapseDataPaciente').collapse('hide');
                            waitingDialog.hide();
                        };
                    } else {
                        msg = { title: 'Error al Buscar Ficha' };
                        Notification.error(msg);
                        $('#collapseDataPaciente').collapse('hide');
                        waitingDialog.hide();
                    }
                });
            } else {
                $('#collapseDataPaciente').collapse('hide');
                waitingDialog.hide();
            };
        };
        $scope.ValidarForm = function () {
            var error = 0;
            var msg = 'Los siguientes campos son requeridos :<br>';
            $(':input[required]', '#frmPsicologia').each(function () {
                $(this).css('border', '1px solid #32b8da');
                if ($(this).val() == '') {
                    msg += '<br><b>' + $(this).attr('placeholder') + '</b>';
                    $(this).css('border', '2px solid #F57E7D');
                    /*if (error == 0) {
                        $(this).focus();
                        var tab = $(this).closest('.tab-pane').attr('id');
                        $('#myTab a[href="#' + tab + '"]').tab('show');
                    }*/
                    error = 1;
                }
            });
            if (error == 1) {
                msg = { title: 'Ups, faltan campos por completar', message: msg, delay: 5000 };
                Notification.warning(msg);
                return false;
            } else {
                return true;
            }
        }
        $scope.SaveFicha = function () {
            if ($scope.ValidarForm()) {
                $scope.Ficha.Id = fichaService.getidFicha();
                $scope.Ficha.Fecha = moment($scope.Ficha.Fecha);
                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                $scope.Ficha.FichaPsicologia.IdEspecialista = parseInt(LoginService.getIdEspecialista())
                waitingDialog.show('Guardando Ficha...', { dialogSize: 'sm' });
                fichaService.SaveFichaPsicologia($scope.Ficha, $scope.Paciente)
                   .then(function (result) {
                       fichaService.getFichaPsicologiaxReserva($scope.Ficha.FichaPsicologia.IdReserva).then(function (result) {
                               $scope.mostrarReporte = false;
                               $scope.Ficha = result.data;
                               $scope.Ficha.FichaPsicologia.Sf36.FechaAIng = moment($scope.Ficha.FichaPsicologia.Sf36.FechaAIng);
                               $scope.Ficha.FichaPsicologia.Sf36.FechaAEgr = moment($scope.Ficha.FichaPsicologia.Sf36.FechaAEgr);
                               $scope.Ficha.FichaPsicologia.Sf36.FechaBIng = moment($scope.Ficha.FichaPsicologia.Sf36.FechaBIng);
                               $scope.Ficha.FichaPsicologia.Sf36.FechaBEgr = moment($scope.Ficha.FichaPsicologia.Sf36.FechaBEgr);
                               $scope.Ficha.FichaPsicologia.Had.FechaAIng = moment($scope.Ficha.FichaPsicologia.Had.FechaAIng);
                               $scope.Ficha.FichaPsicologia.Had.FechaAEgr = moment($scope.Ficha.FichaPsicologia.Had.FechaAEgr);
                               $scope.Ficha.FichaPsicologia.Had.FechaBIng = moment($scope.Ficha.FichaPsicologia.Had.FechaBIng);
                               $scope.Ficha.FichaPsicologia.Had.FechaBEgr = moment($scope.Ficha.FichaPsicologia.Had.FechaBEgr);
                               fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                                   $scope.Paciente = result.data;
                                   $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                                   msg = { title: 'Ficha guardada con éxito', message: "" };
                                   Notification.success(msg);
                                   waitingDialog.hide();
                                   window.scrollTo(0, 0);
                                   $scope.mostrarReporte = false;
                               });
                       }, function (reason) {
                           msg = { title: 'Error al Intentar Recargar los datos de la Ficha guardada' };
                           Notification.error(msg);
                           $('#collapseDataPaciente').collapse('hide');
                           waitingDialog.hide();
                       });
                   }, function (reason) {
                       msg = { title: 'Error guardando Ficha' };
                       Notification.error(msg);
                       $scope.saving = false;
                       waitingDialog.hide();
                   });
            };
        }
        $scope.next = function () {
            $('.nav-tabs > .active').next('li').find('a').each(function () {
                $(this).attr("data-toggle", "tab");
            });
            $('.nav-tabs > .active').next('li').find('a').trigger('click');
        };
        $scope.previous = function () {
            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
        };

        /*  Tipos   */
        tipoService.getTipoRegion().then(function (result) {
            $scope.TipoRegiones = result.data;
            $scope.loadingTipoRegion = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Region' };
            Notification.error(msg);
        });
        tipoService.getTipoComuna().then(function (result) {
            $scope.TipoComunas = result.data;
            $scope.loadingTipoComuna = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Comuna' };
            Notification.error(msg);
        });
        tipoService.getTipoSintomatologia().then(function (result) {
            $scope.TiposSintomatologia = result.data;
            $scope.loadingTiposSintomatologia = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Sintomatología Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoDerivacionAPS().then(function (result) {
            $scope.TiposDerivacionAPS = result.data;
            $scope.loadingTiposDerivacionAPS = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo DerivacionAPS Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoApoyoSocial().then(function (result) {
            $scope.TiposApoyoSocial = result.data;
            $scope.loadingTiposApoyoSocial = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo ApoyoSocial Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoProblemaPsicosocial().then(function (result) {
            $scope.TiposProblemaPsicosocial = result.data;
            $scope.loadingTiposProblemaPsicosocial = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo ProblemaPsicosocial Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoRasgoPersonalidad().then(function (result) {
            $scope.TiposRasgoPersonalidad = result.data;
            $scope.loadingTiposRasgoPersonalidad = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Rasgo Personalidad Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoTrastornoMental().then(function (result) {
            $scope.TiposTrastornoMental = result.data;
            $scope.loadingTiposTrastornoMental = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Trastorno Mental Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoTraumaPostOp().then(function (result) {
            $scope.TiposTraumaPostOp = result.data;
            $scope.loadingTiposTraumaPostOp = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Trauma Post Op. Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoConcienciaFactor().then(function (result) {
            $scope.TiposConcienciaFactor = result.data;
            $scope.loadingTiposConcienciaFactor = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Conciencia Factor Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoDificultadResp().then(function (result) {
            $scope.TiposDificultadResp = result.data;
            $scope.loadingTiposDificultadResp = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Dificultad Respuesta Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoIngresoTaller().then(function (result) {
            $scope.TiposIngresoTaller = result.data;
            $scope.loadingTiposIngresoTaller = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Ingreso Taller Kine' };
            Notification.error(msg);
        });
        tipoService.getTipoTratamiento().then(function (result) {
            $scope.TiposTratamiento = result.data;
            $scope.loadingTiposTratamiento = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Tratamiento Kine' };
            Notification.error(msg);
        });
        /*  Fin Tipos   */

        $scope.reporte = function (sesion) {
            url = "reports/reporte.aspx?tipo=FP&id=" + sesion
            window.open(url, '_blank');
        }
    };
}]);