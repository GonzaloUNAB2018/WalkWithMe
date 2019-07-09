app.controller("fichaKinesiologiaController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {

        /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
        $scope.loading = true;
        //$scope.loadingData = true;
        $scope.loadingTipoRegion = true;
        $scope.loadingTipoDiagnosticoKine = true;
        $scope.loadingTipoObjetivoKine = true;
        $scope.loadingTipoComuna = true;
        $scope.loadingPlanes = true;    
        $scope.mostrarReporte = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTipoRegion && !$scope.loadingTipoDiagnosticoKine && !$scope.loadingTipoObjetivoKine && !$scope.loadingTipoComuna && !$scope.loadingPlanes);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        /*Validacion de perfil para editar la ficha*/
        if (parseInt(LoginService.getTipo()) == 5) {
            $scope.FormEditabe = false;
        } else {
            $scope.FormEditabe = true;
        };
        /*Fin*/

       /*Creacion de input variables*/
        $scope.columnsO = [{ colId: 'col1', Tipo: { ID: '' } , Id: -1}];

        $scope.addNewColumnO = function () {
            var newItemNo = $scope.columnsO.length + 1;
            $scope.columnsO.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnO = function (index) {
            $scope.columnsO.splice(index, 1);
        };

        $scope.columnsD = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];

        $scope.addNewColumnD = function () {
            var newItemNo = $scope.columnsD.length + 1;
            $scope.columnsD.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnD = function (index) {
            $scope.columnsD.splice(index, 1);
        };
        /*Fin*/

        /*Accion de para avanzar o retroceder en un tabpanel*/
        $scope.next = function () {
            $('.nav-tabs > .active').next('li').find('a').each(function () {
                $(this).attr("data-toggle", "tab");
            });
            $('.nav-tabs > .active').next('li').find('a').trigger('click');
        };

        $scope.previous = function () {
            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
        };
        /*Fin*/

        /*Tipo Services*/
        tipoService.getTipoObjetivoKine().then(function (result) {
            $scope.TiposObjetivo = result.data;
            $scope.loadingTipoObjetivoKine = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Objetivo Kine' };
            Notification.error(msg);
        });

        tipoService.getTipoDiagnosticoKine().then(function (result) {
            $scope.TiposDiagnostico = result.data;
            $scope.loadingTipoDiagnosticoKine = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Diagnostico Kine' };
            Notification.error(msg);
        });

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
        /*Fin*/

        /*Carga de Planes*/
        fichaService.getPlanesxRut(parseInt(fichaService.getRutPaciente())).then(function (result) {
            $scope.Planes = result.data;
            $scope.loadingPlanes = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Planes' };
            Notification.error(msg);
        });
        /*Fin*/




        /*Funciones*/
        //$scope.CambioPlan = function (plan) {
        //    if (typeof plan !== 'undefined') {
        //        fichaService.getSesionesxPlan(plan, 5).then(function (result) {
        //            $scope.Sesiones = result.data;
        //        }, function (reason) {
        //            msg = { title: 'Error Listar Planes' };
        //            Notification.error(msg);
        //        });
        //    };            
        //};

        $scope.CambioPlan = function (sesion) {
            if (typeof sesion !== 'undefined') {
                waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
                fichaService.getFichaKinesiologiasxReserva(sesion).then(function (result) {
                    if (result.data.length !== 0) {
                        $scope.mostrarReporte = false;
                        $scope.Ficha = result.data;
                        $scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso = moment($scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso);
                        $scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso = moment($scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso);
                        $scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaIngreso = moment($scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaIngreso);
                        $scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaEgreso = moment($scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaEgreso);
                        $scope.Ficha.FichaKinesiologia.EvolucionIngresoKine.Fecha = moment($scope.Ficha.FichaKinesiologia.EvolucionIngresoKine.Fecha);
                        $scope.Ficha.FichaKinesiologia.EvolucionEgresoKine.Fecha = moment($scope.Ficha.FichaKinesiologia.EvolucionEgresoKine.Fecha);
                        $scope.columnsO = $scope.Ficha.FichaKinesiologia.PlanKinesico.Objetivo;
                        $scope.columnsD = $scope.Ficha.FichaKinesiologia.PlanKinesico.Diagnostico;
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
                        if (parseInt(LoginService.getTipo()) == 5) {
                            msg = { title: 'Sesion Sin Ficha, Complete la ficha para esta sesion' };
                            Notification.warning(msg);
                            fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                                $scope.Paciente = result.data;
                                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                                $scope.columnsO = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];
                                $scope.columnsD = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];
                                $scope.Ficha = {FichaKinesiologia: { Id: -1, IdReserva: sesion }};
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

        $scope.SaveFicha = function () {
            if ($scope.ValidarForm()) {
                $scope.Ficha.Id = fichaService.getidFicha();
                $scope.Ficha.Fecha = moment($scope.Ficha.Fecha);
                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                $scope.Ficha.FichaKinesiologia.PlanKinesico.Diagnostico = $scope.columnsD;
                $scope.Ficha.FichaKinesiologia.PlanKinesico.Objetivo = $scope.columnsO;
                $scope.Ficha.FichaKinesiologia.IdEspecialista = parseInt(LoginService.getIdEspecialista())
                waitingDialog.show('Guardando Ficha...', { dialogSize: 'sm' });
                fichaService.SaveFichaKinesiologia($scope.Ficha, $scope.Paciente)
                   .then(function (result) {
                       fichaService.getFichaKinesiologiasxReserva($scope.Ficha.FichaKinesiologia.IdReserva).then(function (result) {
                               $scope.Ficha = result.data;
                               $scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso = moment($scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso);
                               $scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso = moment($scope.Ficha.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso);
                               $scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaIngreso = moment($scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaIngreso);
                               $scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaEgreso = moment($scope.Ficha.FichaKinesiologia.SHUTTLE.EFechaEgreso);
                               $scope.Ficha.FichaKinesiologia.EvolucionIngresoKine.Fecha = moment($scope.Ficha.FichaKinesiologia.EvolucionIngresoKine.Fecha);
                               $scope.Ficha.FichaKinesiologia.EvolucionEgresoKine.Fecha = moment($scope.Ficha.FichaKinesiologia.EvolucionEgresoKine.Fecha);
                               $scope.columnsO = $scope.Ficha.FichaKinesiologia.PlanKinesico.Objetivo;
                               $scope.columnsD = $scope.Ficha.FichaKinesiologia.PlanKinesico.Diagnostico;
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

        $scope.ValidarForm = function () {
            var error = 0;
            var msg = 'Los siguientes campos son requeridos :<br>';
            $(':input[required]', '#frmKinesiologia').each(function () {
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

        $scope.reporte = function (sesion) {
            url = "reports/reporte.aspx?tipo=FK&id=" + sesion
            window.open(url, '_blank');
        }
        /*Fin*/        
    };
}]);