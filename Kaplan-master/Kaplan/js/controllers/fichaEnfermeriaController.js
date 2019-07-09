app.controller("fichaEnfermeriaController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.mostrarReporte = true;
        $scope.loadingTiposAVD = true;
        $scope.loadingTipoRegion = true;
        $scope.loadingTiposAbdomena = true;
        $scope.loadingTiposAbdomenb = true;
        $scope.loadingTipoComuna = true;
        $scope.loadingPlanes = true;
        $scope.loadingTiposAdeherenciaFarma = true;
        $scope.loadingTiposActividadesRecreativas = true;
        $scope.loadingTiposAF = true;
        $scope.loadingTiposAgua = true;
        $scope.loadingTiposBebidaNec = true;
        $scope.loadingTiposCabeza = true;
        $scope.loadingTiposCuello = true;
        $scope.loadingTiposDeposicion = true;
        $scope.loadingTiposDiuresis = true;
        $scope.loadingTiposDLP = true;
        $scope.loadingTiposDM = true;
        $scope.loadingTiposEEII = true;
        $scope.loadingTiposEESS = true;
        $scope.loadingTiposEA = true;
        $scope.loadingTiposEstres = true;
        $scope.loadingTiposFrutayVerdura = true;
        $scope.loadingTiposGrasas = true;
        $scope.loadingTiposHTA = true;
        $scope.loadingTiposllencap = true;
        $scope.loadingTiposMotivacion = true;
        $scope.loadingTiposOH = true;
        $scope.loadingTiposPatronRespiratorio = true;
        $scope.loadingTiposRegimenHiposodico = true;
        $scope.loadingTiposSED = true;
        $scope.loadingTiposSPOB = true;
        $scope.loadingTiposSuenoNocturnoa = true;
        $scope.loadingTiposSuenoNocturnob = true;
        $scope.loadingTiposSuenoNocturnoc = true;
        $scope.loadingTiposTB = true;
        $scope.loadingTiposTBa = true;
        $scope.loadingTiposTBb = true;
        $scope.loadingTiposToraxa = true;
        $scope.loadingTiposToraxb = true;
        $scope.loadingTiposToraxc = true;
        $scope.loadingTiposToraxd = true;
        $scope.loadingTiposValoracion = true;
        $scope.loadingTiposDiagnostico = true;
        $scope.loadingTiposIndicador = true;
        $scope.loadingTiposIntervencion = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTipoRegion && !$scope.loadingTipoComuna && !$scope.loadingPlanes && !$scope.loadingTiposAbdomena && !$scope.loadingTiposAbdomenb && !$scope.loadingTiposAVD && !$scope.loadingTiposActividadesRecreativas && !$scope.loadingTiposAdeherenciaFarma && !$scope.loadingTiposAF && !$scope.loadingTiposAgua && !$scope.loadingTiposBebidaNec && !$scope.loadingTiposCabeza && !$scope.loadingTiposCuello && !$scope.loadingTiposDeposicion && !$scope.loadingTiposDiuresis && !$scope.loadingTiposDLP && !$scope.loadingTiposDM && !$scope.loadingTiposEEII && !$scope.loadingTiposEESS && !$scope.loadingTiposEA && !$scope.loadingTiposEstres && !$scope.loadingTiposFrutayVerdura && !$scope.loadingTiposGrasas && !$scope.loadingTiposHTA && !$scope.loadingTiposllencap && !$scope.loadingTiposMotivacion && !$scope.loadingTiposOH && !$scope.loadingTiposPatronRespiratorio && !$scope.loadingTiposRegimenHiposodico && !$scope.loadingTiposSED && !$scope.loadingTiposSPOB && !$scope.loadingTiposSuenoNocturnoa && !$scope.loadingTiposSuenoNocturnob && !$scope.loadingTiposSuenoNocturnoc && !$scope.loadingTiposTB && !$scope.loadingTiposTBa && !$scope.loadingTiposTBb && !$scope.loadingTiposToraxa && !$scope.loadingTiposToraxb && !$scope.loadingTiposToraxc && !$scope.loadingTiposToraxd && !$scope.loadingTiposValoracion && !$scope.loadingTiposDiagnostico && !$scope.loadingTiposIndicador && !$scope.loadingTiposIntervencion);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        /*Validacion de perfil para editar la ficha*/
        if (parseInt(LoginService.getTipo()) == 3) {
            $scope.FormEditabe = false;
        } else {
            $scope.FormEditabe = true;
        };
        /*Fin*/

        /*Creacion de input variables*/
        $scope.columnsEvolucion = [{ colId: 'col1', Fecha: '', Evolucion: '', Id: -1 }];

        $scope.addNewColumnEvolucion = function () {
            var newItemNo = $scope.columnsEvolucion.length + 1;
            $scope.columnsEvolucion.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnEvolucion = function (index) {
            $scope.columnsEvolucion.splice(index, 1);
        };
        //-----------------------------------------------------------//
        $scope.columnsMedicamentos = [{ colId: 'col1', Nombre: '', Observacion: '', Dosis: '', Horario: '', Id: -1 }];

        $scope.addNewColumnMedicamentos = function () {
            var newItemNo = $scope.columnsMedicamentos.length + 1;
            $scope.columnsMedicamentos.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnMedicamentos = function (index) {
            $scope.columnsMedicamentos.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsDiagnostico = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];

        $scope.addNewColumnDiagnostico = function () {
            var newItemNo = $scope.columnsDiagnostico.length + 1;
            $scope.columnsDiagnostico.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnDiagnostico = function (index) {
            $scope.columnsDiagnostico.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsIntervenciones = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];

        $scope.addNewColumnIntervenciones = function () {
            var newItemNo = $scope.columnsIntervenciones.length + 1;
            $scope.columnsIntervenciones.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnIntervenciones = function (index) {
            $scope.columnsIntervenciones.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsIndicadores = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1, Inicio: '', Final: '' }];

        $scope.addNewColumnIndicadores = function () {
            var newItemNo = $scope.columnsIndicadores.length + 1;
            $scope.columnsIndicadores.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnIndicadores = function (index) {
            $scope.columnsIndicadores.splice(index, 1);
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

        tipoService.getTipoAbdomenA().then(function (result) {
            $scope.TiposAbdomena = result.data;
            $scope.loadingTiposAbdomena = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Abdomen' };
            Notification.error(msg);
        });

        tipoService.getTipoAbdomenB().then(function (result) {
            $scope.TiposAbdomenb = result.data;
            $scope.loadingTiposAbdomenb = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Abdomen' };
            Notification.error(msg);
        });

        tipoService.getTipoActividadLaboral().then(function (result) {
            $scope.TiposAVD = result.data;
            $scope.loadingTiposAVD = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo AVD' };
            Notification.error(msg);
        });

        tipoService.getTipoActividadRecreativa().then(function (result) {
            $scope.TiposActividadesRecreativas = result.data;
            $scope.loadingTiposActividadesRecreativas = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo ACtividades Recreativas' };
            Notification.error(msg);
        });

        tipoService.getTipoAdherenciaFarma().then(function (result) {
            $scope.TiposAdeherenciaFarma = result.data;
            $scope.loadingTiposAdeherenciaFarma = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Adeherencia Farma' };
            Notification.error(msg);
        });

        tipoService.getTipoAF().then(function (result) {
            $scope.TiposAF = result.data;
            $scope.loadingTiposAF = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo AF' };
            Notification.error(msg);
        });

        tipoService.getTipoAgua().then(function (result) {
            $scope.TiposAgua = result.data;
            $scope.loadingTiposAgua = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Agua' };
            Notification.error(msg);
        });

        tipoService.getTipoBebNec().then(function (result) {
            $scope.TiposBebidaNec = result.data;
            $scope.loadingTiposBebidaNec = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Bebidas y/o Nec.' };
            Notification.error(msg);
        });

        tipoService.getTipoCabeza().then(function (result) {
            $scope.TiposCabeza = result.data;
            $scope.loadingTiposCabeza = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Cabeza' };
            Notification.error(msg);
        });

        tipoService.getTipoCuello().then(function (result) {
            $scope.TiposCuello = result.data;
            $scope.loadingTiposCuello = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Cuello' };
            Notification.error(msg);
        });

        tipoService.getTipoDeposicion().then(function (result) {
            $scope.TiposDeposicion = result.data;
            $scope.loadingTiposDeposicion = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Deposicion' };
            Notification.error(msg);
        });

        tipoService.getTipoDiuresis().then(function (result) {
            $scope.TiposDiuresis = result.data;
            $scope.loadingTiposDiuresis = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Diuresis' };
            Notification.error(msg);
        });

        tipoService.getTipoDLP().then(function (result) {
            $scope.TiposDLP = result.data;
            $scope.loadingTiposDLP = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo DLP' };
            Notification.error(msg);
        });

        tipoService.getTipoDM().then(function (result) {
            $scope.TiposDM = result.data;
            $scope.loadingTiposDM = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo DM' };
            Notification.error(msg);
        });

        tipoService.getTipoEEII().then(function (result) {
            $scope.TiposEEII = result.data;
            $scope.loadingTiposEEII = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo EEII' };
            Notification.error(msg);
        });

        tipoService.getTipoEESS().then(function (result) {
            $scope.TiposEESS = result.data;
            $scope.loadingTiposEESS = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo EESS' };
            Notification.error(msg);
        });

        tipoService.getTipoEstadoAnimo().then(function (result) {
            $scope.TiposEA = result.data;
            $scope.loadingTiposEA = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Estado Animo' };
            Notification.error(msg);
        });

        tipoService.getTipoEstres().then(function (result) {
            $scope.TiposEstres = result.data;
            $scope.loadingTiposEstres = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Estres' };
            Notification.error(msg);
        });

        tipoService.getTipoFrutaVerdura().then(function (result) {
            $scope.TiposFrutayVerdura = result.data;
            $scope.loadingTiposFrutayVerdura = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Fruta y Verduras' };
            Notification.error(msg);
        });

        tipoService.getTipoGrasas().then(function (result) {
            $scope.TiposGrasas = result.data;
            $scope.loadingTiposGrasas = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Grasas' };
            Notification.error(msg);
        });

        tipoService.getTipoHTA().then(function (result) {
            $scope.TiposHTA = result.data;
            $scope.loadingTiposHTA = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo HTA' };
            Notification.error(msg);
        });

        tipoService.getTipoLlenCap().then(function (result) {
            $scope.Tiposllencap = result.data;
            $scope.loadingTiposllencap = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Llen Cap' };
            Notification.error(msg);
        });

        tipoService.getTipoMotivacion().then(function (result) {
            $scope.TiposMotivacion = result.data;
            $scope.loadingTiposMotivacion = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Motivacion' };
            Notification.error(msg);
        });

        tipoService.getTipoOH().then(function (result) {
            $scope.TiposOH = result.data;
            $scope.loadingTiposOH = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo OH' };
            Notification.error(msg);
        });

        tipoService.getTipoPatronRespiratorio().then(function (result) {
            $scope.TiposPatronRespiratorio = result.data;
            $scope.loadingTiposPatronRespiratorio = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Patron Respiratorio' };
            Notification.error(msg);
        });

        tipoService.getTipoRegimenHiposodico().then(function (result) {
            $scope.TiposRegimenHiposodico = result.data;
            $scope.loadingTiposRegimenHiposodico = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Regimen Hiposodico' };
            Notification.error(msg);
        });

        tipoService.getTipoSED().then(function (result) {
            $scope.TiposSED = result.data;
            $scope.loadingTiposSED = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo SED' };
            Notification.error(msg);
        });

        tipoService.getTipoSPOB().then(function (result) {
            $scope.TiposSPOB = result.data;
            $scope.loadingTiposSPOB = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo SO/OB' };
            Notification.error(msg);
        });

        tipoService.getTipoSuenoNocturnoA().then(function (result) {
            $scope.TiposSuenoNocturnoa = result.data;
            $scope.loadingTiposSuenoNocturnoa = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Sueño Nocturno' };
            Notification.error(msg);
        });

        tipoService.getTipoSuenoNocturnoB().then(function (result) {
            $scope.TiposSuenoNocturnob = result.data;
            $scope.loadingTiposSuenoNocturnob = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Sueño Nocturno' };
            Notification.error(msg);
        });

        tipoService.getTipoSuenoNocturnoC().then(function (result) {
            $scope.TiposSuenoNocturnoc = result.data;
            $scope.loadingTiposSuenoNocturnoc = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Sueño Nocturno' };
            Notification.error(msg);
        });

        tipoService.getTipoTB().then(function (result) {
            $scope.TiposTB = result.data;
            $scope.loadingTiposTB = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo TB' };
            Notification.error(msg);
        });

        tipoService.getTipoTBA().then(function (result) {
            $scope.TiposTBa = result.data;
            $scope.loadingTiposTBa = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo TB' };
            Notification.error(msg);
        });

        tipoService.getTipoTBB().then(function (result) {
            $scope.TiposTBb = result.data;
            $scope.loadingTiposTBb = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo TB' };
            Notification.error(msg);
        });

        tipoService.getTipoToraxA().then(function (result) {
            $scope.TiposToraxa = result.data;
            $scope.loadingTiposToraxa = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Torax' };
            Notification.error(msg);
        });

        tipoService.getTipoToraxB().then(function (result) {
            $scope.TiposToraxb = result.data;
            $scope.loadingTiposToraxb = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Torax' };
            Notification.error(msg);
        });

        tipoService.getTipoToraxC().then(function (result) {
            $scope.TiposToraxc = result.data;
            $scope.loadingTiposToraxc = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Torax' };
            Notification.error(msg);
        });

        tipoService.getTipoToraxD().then(function (result) {
            $scope.TiposToraxd = result.data;
            $scope.loadingTiposToraxd = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Torax' };
            Notification.error(msg);
        });

        tipoService.getTipoValoracion().then(function (result) {
            $scope.TiposRespiracion = result.data;
            $scope.TiposAlimentacion = result.data;
            $scope.TiposEliminacion = result.data;
            $scope.TiposDescanso = result.data;
            $scope.TiposHigienePiel = result.data;
            $scope.TiposActividades = result.data;
            $scope.TiposVestirse = result.data;
            $scope.TiposComunicarse = result.data;
            $scope.TiposAutoRealizacion = result.data;
            $scope.loadingTiposValoracion = false;

            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Valoraciones' };
            Notification.error(msg);
        });

        tipoService.getTipoDiagnosticoEnfermeria().then(function (result) {
            $scope.TiposDiagnostico = result.data;
            $scope.loadingTiposDiagnostico = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Diagnostico' };
            Notification.error(msg);
        });

        tipoService.getTipoIntervencion().then(function (result) {
            $scope.TiposIntervencion = result.data;
            $scope.loadingTiposIntervencion = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Intervencion' };
            Notification.error(msg);
        });

        tipoService.getTipoIndicador().then(function (result) {
            $scope.TiposIndicador = result.data;
            $scope.loadingTiposIndicador = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Indicador' };
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
        $scope.CambioPlan = function (plan) {
            if (typeof plan !== 'undefined') {
                fichaService.getSesionesxPlan(plan, 3).then(function (result) {
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
                fichaService.getFichaEnfermeriaxReserva(sesion).then(function (result) {
                    if (result.data.length !== 0) {
                        $scope.mostrarReporte = false;
                        $scope.Ficha = result.data;
                        $scope.columnsMedicamentos = $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria;
                        $scope.columnsEvolucion = $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria;
                        for (i = 0; i < $scope.columnsEvolucion.length; i++) {
                            $scope.columnsEvolucion[i].Fecha = moment($scope.columnsEvolucion[i].Fecha);
                        }
                        $scope.columnsDiagnostico = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico;
                        $scope.columnsIntervenciones = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion;
                        $scope.columnsIndicadores = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores;
                        $scope.Ficha.FichaEnfermeria.FechaDiagnostico = moment($scope.Ficha.FichaEnfermeria.FechaDiagnostico);
                        $scope.Ficha.FichaEnfermeria.FechaCxProced = moment($scope.Ficha.FichaEnfermeria.FechaCxProced);
                        $scope.Ficha.FichaEnfermeria.FechaAlta = moment($scope.Ficha.FichaEnfermeria.FechaAlta);                
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
                        if (parseInt(LoginService.getTipo()) == 3) {
                            msg = { title: 'Sesion Sin Ficha, Complete la ficha para esta sesion' };
                            Notification.warning(msg);
                            fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                                $scope.Paciente = result.data;
                                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                                $scope.columnsEvolucion = [{ colId: 'col1', Fecha: '', Evolucion: '', Id: -1 }];
                                $scope.columnsMedicamentos = [{ colId: 'col1', Nombre: '', Observacion: '', Dosis: '', Horario: '', Id: -1 }];
                                $scope.columnsDiagnostico = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];
                                $scope.columnsIntervenciones = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];
                                $scope.columnsIndicadores = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1, Inicio: '', Final: '' }];
                                $scope.Ficha = { FichaEnfermeria: { Id: -1, IdReserva: sesion } };
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
                $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria = $scope.columnsMedicamentos;
                $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria = $scope.columnsEvolucion;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico = $scope.columnsDiagnostico;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion = $scope.columnsIntervenciones;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores = $scope.columnsIndicadores;
                $scope.Ficha.FichaEnfermeria.IdEspecialista = parseInt(LoginService.getIdEspecialista())
                waitingDialog.show('Guardando Ficha...', { dialogSize: 'sm' });
                fichaService.SaveFichaEnfermeria($scope.Ficha, $scope.Paciente)
                   .then(function (result) {
                       fichaService.getFichaEnfermeriaxReserva($scope.Ficha.FichaEnfermeria.IdReserva).then(function (result) {
                               $scope.Ficha = result.data;
                               $scope.columnsMedicamentos = $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria;
                               $scope.columnsEvolucion = $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria;
                               for (i = 0; i < $scope.columnsEvolucion.length; i++) {
                                   $scope.columnsEvolucion[i].Fecha = moment($scope.columnsEvolucion[i].Fecha);
                               }
                               $scope.columnsDiagnostico = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico;
                               $scope.columnsIntervenciones = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion;
                               $scope.columnsIndicadores = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores;
                               $scope.Ficha.FichaEnfermeria.FechaDiagnostico = moment($scope.Ficha.FichaEnfermeria.FechaDiagnostico);
                               $scope.Ficha.FichaEnfermeria.FechaCxProced = moment($scope.Ficha.FichaEnfermeria.FechaCxProced);
                               $scope.Ficha.FichaEnfermeria.FechaAlta = moment($scope.Ficha.FichaEnfermeria.FechaAlta);
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
            $(':input[required]', '#frmEnfermeria').each(function () {
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
        /*Fin*/

        $scope.reporte = function (sesion) {
            url = "reports/reporte.aspx?tipo=FE&id=" + sesion
            window.open(url, '_blank');
        }
    };
}]);