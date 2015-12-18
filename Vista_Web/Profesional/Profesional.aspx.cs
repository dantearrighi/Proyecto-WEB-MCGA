using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using AjaxControlToolkit;

namespace Vista_Web
{
    public partial class Profesional : System.Web.UI.Page
    {
        #region Declaración de variables
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string modo_matricula;
        string usuario;
        string grupo;
        string direccion;
        string direccionE;
        string ctacte;
        string logcuota;
        string profesional;
        string tipomatricula;
        string colegio;
        string tipodocumento;
        string localidad;
        string provincia;
        string matricula;

        // Declaro las controladoras a utilizar en el formulario
        Controladora.cProfesional cProfesional;
        Controladora.cGrupo cGrupo;
        Controladora.cTipo_Documento cTipo_Documento;
        Controladora.cProvincia cProvincia;
        Controladora.cLocalidad cLocalidad;
        Controladora.cEstado cEstado;
        Controladora.cTipo_Matricula cTipo_Matricula;
        Controladora.cColegio cColegio;
        Controladora.cTitulo cTitulo;
        Controladora.cTipo_Certificado cTipo_Certificado;
        Controladora.cVerificacion cVerificacion;
        Controladora.cMatricula cMatricula;
        Controladora.cMovimiento cMovimiento;
        Controladora.cCtaCte cCtaCte;
        Controladora.cCuota cCuota;
        Controladora.cExpediente cExpediente;
        Controladora.cTipo_Movimiento cTipo_Movimiento;
        Controladora.cAuditoria cAuditoria;
        Controladora.cUsuario cUsuario;

        // Declaro las entidades
        Modelo_Entidades.Profesional oProfesional;
        Modelo_Entidades.Matricula oMatricula;
        Modelo_Entidades.Direccion oDireccion;
        Modelo_Entidades.Direccion oDireccionE;
        Modelo_Entidades.CtaCte oCtaCte;
        Modelo_Entidades.Usuario miUsuario;
        Modelo_Entidades.Auditoria_Cuota oLog_Cuota;
        Modelo_Entidades.Tipo_Matricula oTipoMatricula;
        Modelo_Entidades.Colegio oColegio;
        Modelo_Entidades.Tipo_Documento oTipoDocumento;
        Modelo_Entidades.Localidad oLocalidad;
        Modelo_Entidades.Provincia oProvincia;

        List<Modelo_Entidades.Movimiento> ListaMovimientos = new List<Modelo_Entidades.Movimiento>();
        List<Modelo_Entidades.Historial> lHistoriales;
        List<Modelo_Entidades.Matricula> lMatriculas;
        List<Modelo_Entidades.Cuota> lCuotasImpagas;
        List<Modelo_Entidades.Cuota> lCuotasPagas;
        List<Modelo_Entidades.Expediente> lExpedientes;
        List<Modelo_Entidades.Tipo_Documento> lTipoDocumentos;
        List<Modelo_Entidades.Provincia> lProvincias;
        List<Modelo_Entidades.Localidad> lLocalidades;
        List<Modelo_Entidades.Tipo_Matricula> lTipoMatriculas;
        List<Modelo_Entidades.Colegio> lColegios;
        List<Modelo_Entidades.Tipo_Certificado> lTipoCertificados;
        #endregion

        // Constructor
        public Profesional()
        {
            // Inicializo a las controladoras
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cTipo_Documento = Controladora.cTipo_Documento.ObtenerInstancia();
            cProvincia = Controladora.cProvincia.ObtenerInstancia();
            cLocalidad = Controladora.cLocalidad.ObtenerInstancia();
            cEstado = Controladora.cEstado.ObtenerInstancia();
            cTipo_Matricula = Controladora.cTipo_Matricula.ObtenerInstancia();
            cColegio = Controladora.cColegio.ObtenerInstancia();
            cTitulo = Controladora.cTitulo.ObtenerInstancia();
            cTipo_Certificado = Controladora.cTipo_Certificado.ObtenerInstancia();
            cMatricula = Controladora.cMatricula.ObtenerInstancia();
            cVerificacion = Controladora.cVerificacion.ObtenerInstancia();
            cMovimiento = Controladora.cMovimiento.ObtenerInstancia();
            cCtaCte = Controladora.cCtaCte.ObtenerInstancia();
            cCuota = Controladora.cCuota.ObtenerInstancia();
            cExpediente = Controladora.cExpediente.ObtenerInstancia();
            cTipo_Movimiento = Controladora.cTipo_Movimiento.ObtenerInstancia();
            cAuditoria = Controladora.cAuditoria.ObtenerInstancia();
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            profesional = Server.UrlDecode(Request.QueryString["profesional"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);
            usuario = Server.UrlDecode(Request.QueryString["usuario"]);

            //if ((profesional == null) || (modo == null) || (usuario == null))
            //{
            //    //crear una página que muestre mensajes de error
            //    Response.Redirect("~/Seguridad/Login.aspx");
            //}

            miUsuario = cUsuario.ObtenerUsuario(usuario);

            if (profesional == "nuevo")
            {
                oProfesional = new Modelo_Entidades.Profesional();
            }

            else
            {
                oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));
            }

            message.Visible = false;

            // Invalido controles que no se pueden editar
            txt_lugartrabajo.Enabled = false;
            cmb_colegios.Enabled = false;
            txt_año.Enabled = false;
            

            if (modo != "Alta")
            {
                // Inhabilito el DNI
                txt_numero.Enabled = false;

                ArmaFormulario(oProfesional);
                
                if (modo == "Consulta")
                {
                    txt_nombreapellido.Enabled = false;
                    cmb_tiposdoc.Enabled = false;
                    txt_numero.Enabled = false;
                    txt_fechanacimiento.Enabled = false;
                    sexo.Enabled = false;
                    txt_telfijo.Enabled = false;
                    txt_celular.Enabled = false;
                    txt_emailpricipal.Enabled = false;
                    txt_emailalternativo.Enabled = false;
                    chk_mismolugar.Enabled = false;
                    txt_direccion.Enabled = false;
                    txt_cp.Enabled = false;
                    cmb_localidades.Enabled = false;
                    cmb_provincias.Enabled = false;
                    txt_direccionE.Enabled = false;
                    txt_cpE.Enabled = false;
                    cmb_localidadesE.Enabled = false;
                    cmb_provinciasE.Enabled = false;
                    
                    cmb_tipomatricula.Enabled = false;
                    txt_observaciones_historial.Enabled = false;

                    btn_imprimirboletas.Enabled = false;

                    cmb_titulo_certhabilitacion.Enabled = false;
                    cmb_tipocertificado.Enabled = false;
                    btn_imprimircertificadoH.Enabled = false;
                    txt_observaciones.Enabled = false;
                    //cmb_tituloamostrar.Enabled = false;

                    btn_baja.Enabled = false;
                    btn_alta.Enabled = false;
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                    btn_agregar.Enabled = false;
                    btn_modificar.Enabled = false;
                    chk_mismolugar.Enabled = false;
                }
            }
                
            else
            {
                txt_numero.Enabled = true;
                lb_estado_def.Text = "Recién matriculado";
                txt_observaciones_historial.Enabled = false;

                btn_agregar.Enabled = false;
                btn_modificar.Enabled = false;
                btn_ver_detalle.Enabled = false;
                btn_imprimirtitulo.Enabled = false;
                btn_imprimircertificadoH.Enabled = false;
                btn_imprimirboletas.Enabled = false;
                btn_alta.Enabled = false;
                btn_baja.Enabled = false;

                mje_titulos.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargaDatos();
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Profesional/Gestion de Profesionales.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios() == true)
            {
                //try
                //{
                    #region Datos personales del profesional

                    tipodocumento = cmb_tiposdoc.SelectedValue.ToString();
                    oTipoDocumento = cTipo_Documento.BuscarTipoDcoumentoPorDesc(tipodocumento);
                    oProfesional.Tipo_Documento = oTipoDocumento;
                    oProfesional.dni = Convert.ToInt32(txt_numero.Text);
                    oProfesional.nombre_apellido = txt_nombreapellido.Text;
                    oProfesional.fecha_nacimiento = Convert.ToDateTime(txt_fechanacimiento.Text);

                    if (sexo.SelectedValue == "Masculino")
                    {
                        oProfesional.sexo = "Masculino";
                    }

                    else
                    {
                        oProfesional.sexo = "Femenino";
                    }

                    if (modo == "Alta")
                    {
                        oDireccion = new Modelo_Entidades.Direccion();
                        oDireccion.direccion = txt_direccion.Text;

                        localidad = cmb_localidades.SelectedValue.ToString();
                        oLocalidad = cLocalidad.BuscarLocalidadPorDesc(localidad);
                        oDireccion.Localidad = oLocalidad;
                        oProfesional.Direcciones.Add(oDireccion);

                        oDireccionE = new Modelo_Entidades.Direccion();
                        oDireccionE.direccion = txt_direccion.Text;
                        localidad = cmb_localidades.SelectedValue.ToString();
                        oLocalidad = cLocalidad.BuscarLocalidadPorDesc(localidad);
                        oDireccionE.Localidad = oLocalidad;
                        oProfesional.Direcciones.Add(oDireccionE);
                    }

                    else
                    {
                        oDireccion = oProfesional.Direcciones.ElementAt(0);
                        localidad = cmb_localidades.SelectedValue.ToString();
                        oLocalidad = cLocalidad.BuscarLocalidadPorDesc(localidad);
                        oDireccion.Localidad = oLocalidad;
                        oDireccion.direccion = txt_direccion.Text;
                        oProfesional.Direcciones.ElementAt(0).Equals(oDireccion);

                        oDireccionE = oProfesional.Direcciones.ElementAt(1);
                        localidad = cmb_localidadesE.SelectedValue.ToString();
                        oLocalidad = cLocalidad.BuscarLocalidadPorDesc(localidad);
                        oDireccionE.Localidad = oLocalidad;
                        oDireccionE.direccion = txt_direccionE.Text;
                        oProfesional.Direcciones.ElementAt(1).Equals(oDireccionE);
                    }

                    oProfesional.telefono = Convert.ToInt32(txt_telfijo.Text);
                    oProfesional.celular = Convert.ToInt32(txt_celular.Text);
                    oProfesional.email1 = txt_emailpricipal.Text;
                    oProfesional.email2 = txt_emailalternativo.Text;
                    #endregion

                    #region Matrícula del profesional

                tipomatricula = cmb_tipomatricula.SelectedValue.ToString();
                oTipoMatricula = cTipo_Matricula.BuscarTipoMatriculaPorDesc(tipomatricula);

                oProfesional.Tipo_Matricula = oTipoMatricula;

                if (oProfesional.Tipo_Matricula.descripcion == "Relación de Dependencia")
                {
                    oProfesional.lugar_trabajo = txt_lugartrabajo.Text;
                }

                if (oProfesional.Tipo_Matricula.descripcion == "Reciprocidad de Matrícula")
                {
                    colegio = cmb_colegios.SelectedValue.ToString();
                    oColegio = cColegio.BuscarColegioPorDesc(colegio);
                    oProfesional.Colegio = oColegio;
                    oProfesional.convenio_año = Convert.ToInt32(txt_año.Text);
                }

                if (modo == "Alta")
                {
                    // Cuando se matricula, le pongo el estado no habilitado. Se va a habilitar cuando pague.
                    oProfesional.Estado = cEstado.ObtenerEstadoNoHabilitado();
                    // Doy de alta el 1º historial
                    Modelo_Entidades.Historial oHistorial = new Modelo_Entidades.Historial();
                    oHistorial.estado = (cEstado.ObtenerEstadoHabilitado()).descripcion;
                    tipomatricula = cmb_tipomatricula.SelectedValue.ToString();
                    oTipoMatricula = cTipo_Matricula.BuscarTipoMatriculaPorDesc(tipomatricula);
                    oHistorial.tipo_matricula = oTipoMatricula.descripcion;
                    oHistorial.fecha = DateTime.Now;
                    oHistorial.observaciones = "Alta en el CIE del profesional";
                    oProfesional.Historiales.Add(oHistorial);
                }
                #endregion

                    #region Contabilidad del profesional

                if (modo == "Alta")
                {
                    // Doy de alta a la cta cte
                    Modelo_Entidades.CtaCte oCtaCte = new Modelo_Entidades.CtaCte();
                    oCtaCte.saldo = 0;
                    oCtaCte.Profesional = oProfesional;
                    oProfesional.CtaCte = oCtaCte;
                }

                #endregion

                    #region Observaciones del profesional
                oProfesional.observaciones = txt_observaciones.Text;
                //oProfesional.titulo_a_mostrar = cmb_tituloamostrar.SelectedValue.ToString();
                #endregion

                    #region Títulos del profesional

                #endregion

                    if (modo == "Alta")
                    {
                        cProfesional.Alta(oProfesional);                    

                        int mes = DateTime.Now.Month;
                        if (mes == 1 || mes == 2)
                        {
                            GeneraCuotaAnual(oProfesional);
                            GeneraCuotaBimensual(oProfesional, mes);
                        }

                        else
                        {
                            GeneraCuotaBimensual(oProfesional, mes);
                        }

                        cCtaCte.Modificacion(oCtaCte);
                        Page.Response.Redirect("~/Profesional/Gestion de Profesionales.aspx");
                    }

                    else
                    {
                        cProfesional.Modificacion(oProfesional);
                        Page.Response.Redirect("~/Profesional/Gestion de Profesionales.aspx");
                    }
                

                //catch (Exception Exc)
                //{
                //    message.Visible = true;
                //    lb_error.Text = Exc.Message.ToString();
                //}
            }
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            #region Datos personales
            if (cmb_tiposdoc.SelectedItem == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un tipo de documento para el Profesional";
                return false;
            }

            if (string.IsNullOrEmpty(txt_numero.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el número de DNI del Profesional";
                return false;
            }

            // Valido que no exista un profesional con un DNI igual
            if (cProfesional.ValidarProfesional(Convert.ToInt32(txt_numero.Text)) == false)
            {
                if (oProfesional.dni != Convert.ToInt32(txt_numero.Text))
                {
                    message.Visible = true;
                    lb_error.Text = "Ya existe un Profesional con el DNI introducido";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txt_nombreapellido.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el nombre y apellido del Profesional";
                return false;
            }

            //if (Regex.IsMatch(txt_nombreapellido.Text, @"^[a-zA-Z]+$"))
            //{
            //    message.Visible = true;
            //    lb_error.Text = "El nombre y el apellido solo pueden contener letras";
            //    return false;
            //}

            if (string.IsNullOrEmpty(txt_fechanacimiento.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar la fecha de nacimiento del Profesional";
                return false;
            }

            if (sexo.SelectedValue == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un tipo de género para del Profesional";
                return false;
            }

            if (cmb_provincias.SelectedValue == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar la provincia donde reside el Profesional";
                return false;
            }

            if (cmb_localidades.SelectedValue == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar la provincia donde reside el Profesional";
                return false;
            }

            if (string.IsNullOrEmpty(txt_direccion.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar la dirección del Profesional";
                return false;
            }

            if (cmb_provinciasE.SelectedValue == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar la provincia de envío de la boleta del Profesional";
                return false;
            }

            if (cmb_localidades.SelectedValue == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar la localidad de envío de la boleta del Profesional";
                return false;
            }

            if (string.IsNullOrEmpty(txt_direccionE.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar la dirección de envío de la matrícula del Profesional";
                return false;
            }

            if (string.IsNullOrEmpty(txt_telfijo.Text) || string.IsNullOrEmpty(txt_celular.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar al menos un número de contacto telefónico para comunicarse con el Profesional";
                return false;
            }

            if (string.IsNullOrEmpty(txt_emailpricipal.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un correo electrónico de contacto para comunicarse con el Profesional";
                return false;
            }

            string expresionregular = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            if (!(Regex.IsMatch(this.txt_emailpricipal.Text, expresionregular))) //si el mail no concuerda con la expresion regular
            {
                this.txt_emailpricipal.Focus();
                message.Visible = true;
                lb_error.Text = "El E-Mail ingresado tiene un formato incorrecto.";
                return false;
            }
            #endregion

            #region Datos referidos a la matrícula del profesional
            if (cmb_tipomatricula.SelectedValue == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un tipo de matrícula para el Profesional";
                return false;
            }

            if (cmb_tipomatricula.SelectedValue == "Relación de dependencia" && string.IsNullOrEmpty(txt_lugartrabajo.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe proporcionar el lugar de trabajo del profesional en relación de dependencia";
                return false;
            }

            if (cmb_tipomatricula.SelectedValue == "Convenio" && string.IsNullOrEmpty(txt_año.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe proporcionar el año de habilitación del profesional en el Colegio con el cual se estableció el convenio";
                return false;
            }
            #endregion

            #region datos del título

            //if (oProfesional.Matriculas.Count == 0)
            //{
            //    message.Visible = true;
            //    lb_error.Text = "Debe agregar al menos un título Profesional";
            //    return false;
            //}
            #endregion

            #region Datos referidos a la matrícula del profesional
            if (txt_observaciones_historial.Enabled == true)
            {
                if (string.IsNullOrEmpty(txt_observaciones_historial.Text))
                {
                    message.Visible = true;
                    lb_error.Text = "No ha ingresado ninguna observación por el cambio de estado o por el cambio de tipo de matrícula del profesional.";
                    return false;
                }

                if (oProfesional.Historiales.Count != 0)
                {
                    TimeSpan dif = oProfesional.Historiales.ToList().Last().fecha - DateTime.Now;
                    if (dif.Days > -365)
                    {
                        message.Visible = true;
                        lb_error.Text = "No puede cambiar el tipo de matrícula del profesional si no ha pasado al menos 1 año";
                        return false;
                    }

                    else
                    {
                        Modelo_Entidades.Historial oHistorial = new Modelo_Entidades.Historial();
                        oHistorial.estado = oProfesional.Estado.descripcion;
                        oHistorial.tipo_matricula = cmb_tipomatricula.SelectedValue.ToString();
                        oHistorial.fecha = DateTime.Now;
                        //Habilito las observaciones del historial
                        oHistorial.observaciones = txt_observaciones_historial.Text;
                        oProfesional.Historiales.Add(oHistorial);
                    }
                }
            }
            #endregion

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            lHistoriales = oProfesional.Historiales.ToList();
            dgv_historial.DataSource = lHistoriales;
            dgv_historial.DataBind();

            if (profesional != "nuevo")
            {
                lMatriculas = cMatricula.BuscarMatriculaPorProf(Convert.ToInt32(profesional));
                dgv_matriculas.DataSource = lMatriculas;
                dgv_matriculas.DataBind();

                lCuotasImpagas = cCuota.BuscarCuotasImpagasPorProfesional(oProfesional.dni);
                dgv_deudas.DataSource = lCuotasImpagas;
                dgv_deudas.DataBind();

                lCuotasPagas = cCuota.BuscarCuotasPagasPorProfesional(oProfesional.dni);
                dgv_creditos.DataSource = lCuotasPagas;
                dgv_creditos.DataBind();

                lExpedientes = oProfesional.Expedientes.ToList();
                dgv_expedeintes.DataSource = lExpedientes;
                dgv_expedeintes.DataBind();
            }
            

            lTipoDocumentos = cTipo_Documento.ObtenerTipos_Documentos();
            cmb_tiposdoc.DataSource = lTipoDocumentos;
            cmb_tiposdoc.DataBind();

            lProvincias = cProvincia.ObtenerProvincias();
            cmb_provincias.DataSource = lProvincias;
            cmb_provincias.DataBind();

            lLocalidades = cLocalidad.ObtenerLocalidades();
            cmb_localidades.DataSource = lLocalidades;
            cmb_localidades.DataBind();

            lProvincias = cProvincia.ObtenerProvincias();
            cmb_provinciasE.DataSource = lProvincias;
            cmb_provinciasE.DataBind();

            lLocalidades = cLocalidad.ObtenerLocalidades();
            cmb_localidadesE.DataSource = lLocalidades;
            cmb_localidadesE.DataBind();

            lTipoMatriculas = cTipo_Matricula.ObtenerTiposMatriculas();
            cmb_tipomatricula.DataSource = lTipoMatriculas;
            cmb_tipomatricula.DataBind();

            lColegios = cColegio.ObtenerColegios();
            cmb_colegios.DataSource = lColegios;
            cmb_colegios.DataBind();

            lMatriculas = oProfesional.Matriculas.ToList();
            cmb_titulo_certhabilitacion.DataSource = lMatriculas;
            cmb_titulo_certhabilitacion.DataBind();

            lTipoCertificados = cTipo_Certificado.ObtenerTiposCertificados();
            cmb_tipocertificado.DataSource = lTipoCertificados;
            cmb_tipocertificado.DataBind();

            //if (oProfesional.Matriculas.Count != 0)
            //{
            //    lMatriculas = oProfesional.Matriculas.ToList();
            //    cmb_tituloamostrar.DataSource = lMatriculas;
            //    //cmb_tituloamostrar.DataBind();
            //}
        }

        // Genero la cuota anual para un nuevo profesional
        private void GeneraCuotaAnual(Modelo_Entidades.Profesional oProfesional)
        {
            oCtaCte = oProfesional.CtaCte;
            Modelo_Entidades.Boleta oBoleta = new Modelo_Entidades.Boleta();
            Modelo_Entidades.Movimiento oMovimiento = new Modelo_Entidades.Movimiento();
            oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();

            oMovimiento.fecha = DateTime.Now;

            Modelo_Entidades.Anual oAnual = new Modelo_Entidades.Anual();
            if (oProfesional.Tipo_Matricula.descripcion == "Relación de Dependencia")
            {
                oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oAnual).Valor() * 0.7, 2); // EL PORCENTAJE ESTÁ HARKODEADO, DE TODAS FORMAS ESE ES EL VALOR QUE ANUALMENTE EL COLEGIO DISPONE
            }

            else
            {
                oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oAnual).Valor(), 2);
            }

            oMovimiento.descripcion = "Cuota anual año " + DateTime.Now.Year.ToString();
            oAnual.descripcion = "Cuota anual año " + DateTime.Now.Year.ToString();
            oAnual.estado = false;
            oAnual.Profesional = oProfesional;
            cCuota.AgregarCuota(oAnual);

            #region Audito la cuota
            oLog_Cuota.estado = false;
            oLog_Cuota.descripcion = "Cuota anual año " + DateTime.Now.Year.ToString();
            oLog_Cuota.Profesional_dni = oProfesional.dni;
            oLog_Cuota.usuario = miUsuario.nombre_apellido;
            oLog_Cuota.fecha = DateTime.Now;
            oLog_Cuota.accion = "Agregado de cuota anual al profesional " + oProfesional.nombre_apellido;
            cAuditoria.AuditarCuota(oLog_Cuota);
            #endregion

            oMovimiento.fecha = DateTime.Now;
            oMovimiento.CtaCte = oProfesional.CtaCte;
            oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
            oMovimiento.Comprobante = oBoleta;

            cMovimiento.Alta(oMovimiento);

            oProfesional.CtaCte.Movimientos.Add(oMovimiento);

            oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(oMovimiento.importe);

            cCtaCte.Modificacion(oCtaCte);
        }

        // Genero la cuota bimensual para un nuevo profesional
        private void GeneraCuotaBimensual(Modelo_Entidades.Profesional oProfesional, int mes)
        {
            int numero = mes;
            switch (numero)
            {
                case 1:
                    numero = 1;
                    break;
                case 2:
                    numero = 1;
                    break;
                case 3:
                    numero = 2;
                    break;
                case 4:
                    numero = 2;
                    break;
                case 5:
                    numero = 3;
                    break;
                case 6:
                    numero = 3;
                    break;
                case 7:
                    numero = 4;
                    break;
                case 8:
                    numero = 4;
                    break;
                case 9:
                    numero = 5;
                    break;
                case 10:
                    numero = 5;
                    break;
                case 11:
                    numero = 6;
                    break;
                case 12:
                    numero = 6;
                    break;
            }

            oCtaCte = oProfesional.CtaCte;
            Modelo_Entidades.Boleta oBoleta = new Modelo_Entidades.Boleta();
            Modelo_Entidades.Movimiento oMovimiento = new Modelo_Entidades.Movimiento();
            oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();

            oMovimiento.fecha = DateTime.Now;

            Modelo_Entidades.Bimensual oBimensual = new Modelo_Entidades.Bimensual();
            // Esto verifica si el profesional pagó la anual, no la genere las cuotas bimensuales y el que esté en relación de dependencia, la 5° y 6° cuota no las pague

            oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oBimensual).Valor(), 2);
            oMovimiento.descripcion = "Cuota " + numero.ToString() + "/" + DateTime.Now.Year.ToString();
            oBimensual.descripcion = "Cuota " + numero.ToString() + "/" + DateTime.Now.Year.ToString();
            oBimensual.estado = false;
            oBimensual.Profesional = oProfesional;
            cCuota.AgregarCuota(oBimensual);

            #region Audito la cuota
            oLog_Cuota.estado = false;
            oLog_Cuota.descripcion = "Cuota " + numero.ToString() + "/" + DateTime.Now.Year.ToString();
            oLog_Cuota.Profesional_dni = oProfesional.dni;
            oLog_Cuota.usuario = miUsuario.nombre_apellido;
            oLog_Cuota.fecha = DateTime.Now;
            oLog_Cuota.accion = "Agregado de cuota bimensual al profesional " + oProfesional.nombre_apellido;
            cAuditoria.AuditarCuota(oLog_Cuota);
            #endregion

            oMovimiento.fecha = DateTime.Now;
            oMovimiento.CtaCte = oProfesional.CtaCte;
            oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
            oMovimiento.Comprobante = oBoleta;

            cMovimiento.Alta(oMovimiento);

            oProfesional.CtaCte.Movimientos.Add(oMovimiento);

            oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(oMovimiento.importe);
        }

        protected void chk_mismolugar_CheckedChanged(object sender, EventArgs e)
        {
            
            if (cmb_localidades.SelectedValue == "")
            {
                return;
            }

            if (chk_mismolugar.Checked == true)
            {
                provincia = cmb_provincias.SelectedValue.ToString();
                oProvincia = cProvincia.BuscarProvinciaPorDesc(provincia);
                cmb_provinciasE.SelectedValue = oProvincia.nombre;

                localidad = cmb_localidades.SelectedValue.ToString();
                oLocalidad = cLocalidad.BuscarLocalidadPorDesc(localidad);
                cmb_localidadesE.SelectedValue = oLocalidad.nombre;

                txt_direccionE.Text = txt_direccion.Text;
                txt_cpE.Text = oLocalidad.cp.ToString();
            }

            if (chk_mismolugar.Checked == false)
            {
                lProvincias = cProvincia.ObtenerProvincias();
                cmb_provinciasE.DataSource = lProvincias;
                cmb_provinciasE.DataBind();
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            message.Visible = true;

            if (profesional == "nuevo")
            {
                lb_error.Text = "Antes de asignarle una matrícula al profesional, debe cargarlo";
            }

            else
            {

                matricula = "nuevo";
                modo_matricula = "Alta";

                Response.Redirect(String.Format("~/Profesional/Matriculas Profesional.aspx?matricula={0}&modo={1}&profesional={2}&modo_matricula={3}", Server.UrlEncode(matricula), Server.UrlEncode(modo), Server.UrlEncode(profesional), Server.UrlEncode(modo_matricula)));
            }
        }

        // Armo el formulario (si no es una alta)
        private void ArmaFormulario(Modelo_Entidades.Profesional oProfesional)
        {
            // Sección de datos del profesional
            lb_estado_def.Text = oProfesional.Estado.descripcion;

            txt_numero.Text = oProfesional.dni.ToString();
            txt_nombreapellido.Text = oProfesional.nombre_apellido;
            txt_fechanacimiento.Text = oProfesional.fecha_nacimiento.ToShortDateString();

            if (oProfesional.sexo == "Masculino")
            {
                sexo.SelectedValue = "Masculino";
            }

            else
            {
                sexo.SelectedValue = "Femenino";
            }

            txt_direccion.Text = oProfesional.Direcciones.ElementAt(0).direccion;
            txt_cp.Text = oProfesional.Direcciones.ElementAt(0).Localidad.cp.ToString();
            txt_direccionE.Text = oProfesional.Direcciones.ElementAt(1).direccion;
            txt_cpE.Text = oProfesional.Direcciones.ElementAt(1).Localidad.cp.ToString();

            cmb_tiposdoc.SelectedIndex = oProfesional.Tipo_Documento.id;

            cmb_provincias.SelectedValue = oProfesional.Direcciones.ElementAt(0).Localidad.Provincia.nombre;
            cmb_localidades.SelectedValue = oProfesional.Direcciones.ElementAt(0).Localidad.nombre;
            cmb_provinciasE.SelectedValue = oProfesional.Direcciones.ElementAt(1).Localidad.Provincia.nombre;
            cmb_localidadesE.SelectedValue = oProfesional.Direcciones.ElementAt(1).Localidad.nombre;

            if (oProfesional.Direcciones.ElementAt(0).Localidad.Provincia == oProfesional.Direcciones.ElementAt(1).Localidad.Provincia && oProfesional.Direcciones.ElementAt(0).Localidad == oProfesional.Direcciones.ElementAt(1).Localidad && oProfesional.Direcciones.ElementAt(0).direccion == oProfesional.Direcciones.ElementAt(1).direccion)
            {
                chk_mismolugar.Checked = true;
            }

            else
            {
                chk_mismolugar.Checked = false;
            }

            txt_telfijo.Text = oProfesional.telefono.ToString();
            txt_celular.Text = oProfesional.celular.ToString();
            txt_emailpricipal.Text = oProfesional.email1;
            txt_emailalternativo.Text = oProfesional.email2;

            // Sección de datos de la matrícula del profesional
            cmb_tipomatricula.SelectedValue = oProfesional.Tipo_Matricula.descripcion;

            switch (oProfesional.Tipo_Matricula.descripcion)
            {
                case ("Relación de Dependencia"):
                    {
                        txt_lugartrabajo.Text = oProfesional.lugar_trabajo;
                        break;
                    }

                case ("Convenio"):
                    {
                        cmb_colegios.SelectedValue = oProfesional.Colegio.descripcion;
                        txt_año.Text = oProfesional.convenio_año.ToString();
                        break;
                    }
            }

            txt_observaciones_historial.Enabled = false;

            // Sección de las observaciones del profesional
            //cmb_tituloamostrar.SelectedValue = oProfesional.titulo_a_mostrar;
            txt_observaciones.Text = oProfesional.observaciones;
        }

        protected void cmb_tipomatricula_TextChanged(object sender, EventArgs e)
        {
            tipomatricula = cmb_tipomatricula.SelectedValue.ToString();
            oTipoMatricula = cTipo_Matricula.BuscarTipoMatriculaPorDesc(tipomatricula);

            if (oTipoMatricula.descripcion == "")
            {
                return;
            }

            if (oTipoMatricula.descripcion == "Relación de Dependencia")
            {
                txt_lugartrabajo.Enabled = true;
            }

            else
            {
                txt_lugartrabajo.Enabled = false;
            }

            if (oTipoMatricula.descripcion == "Reciprocidad de Matrícula")
            {
                cmb_colegios.Enabled = true;
                txt_año.Enabled = true;
            }

            else
            {
                cmb_colegios.Enabled = false;
                txt_año.Enabled = false;
            }
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            message.Visible = true;

            if (dgv_matriculas.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una matricula";
            }

            else
            {
                matricula = dgv_matriculas.SelectedRow.Cells[1].Text;
                modo_matricula = "Modifica";

                Response.Redirect(String.Format("~/Profesional/Matriculas Profesional.aspx?matricula={0}&modo={1}&profesional={2}&modo_matricula={3}", Server.UrlEncode(matricula), Server.UrlEncode(modo), Server.UrlEncode(profesional), Server.UrlEncode(modo_matricula)));

            }
        }

        protected void btn_ver_detalle_Click(object sender, EventArgs e)
        {
            message.Visible = true;

            if (dgv_matriculas.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una matricula";
            }

            else
            {
                matricula = dgv_matriculas.SelectedRow.Cells[1].Text;
                modo_matricula = "Consulta";

                Response.Redirect(String.Format("~/Profesional/Matriculas Profesional.aspx?matricula={0}&modo={1}&profesional={2}&modo_matricula={3}", Server.UrlEncode(matricula), Server.UrlEncode(modo), Server.UrlEncode(profesional), Server.UrlEncode(modo_matricula)));

            }
        }

        protected void cmb_tipomatricula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tipomatricula.SelectedValue.ToString() == "Relación de Dependencia")
            {
                txt_lugartrabajo.Enabled = true;

                if (modo != "Alta")
                {
                    txt_observaciones_historial.Enabled = true;
                }
            }

            else if (cmb_tipomatricula.SelectedValue.ToString() == "Reciprocidad de Matrícula")
            {
                cmb_colegios.Enabled = true;
                txt_año.Enabled = true;

                if (modo != "Alta")
                {
                    txt_observaciones_historial.Enabled = true;
                }
            }

            else
            {
                txt_observaciones_historial.Enabled = false;
            }
        }

        protected void btn_baja_Click(object sender, EventArgs e)
        {
            if (oProfesional.Estado.descripcion == "Baja")
            {
                message.Visible = true;
                lb_error.Text = "El profesional ya se encuentra suspendido";
            }

            else
            {
                lb_mensaje_estado.Text = "¿Está seguro que desea suspender al profesional?";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
            }
        }

        protected void btn_imprimirtitulo_Click(object sender, EventArgs e)
        {
            if (dgv_matriculas.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un título para imprimir";
            }

            else
            {
                matricula = dgv_matriculas.SelectedRow.Cells[1].Text;
                oMatricula = cMatricula.BuscarMatriculaPorId(Convert.ToInt32(matricula));

                Response.Redirect(String.Format("~/Titulos/FrmImprimirTitulo.aspx?dni={0}&id_dir={1}&icie={2}", oProfesional.dni, oProfesional.Direcciones.First().id, oMatricula.icie));
            }
        }

        protected void btn_imprimirboletas_Click(object sender, EventArgs e)
        {
            foreach (Modelo_Entidades.Movimiento oMov in cMovimiento.ObtenerMovimientos())
            {
                foreach (Modelo_Entidades.Cuota oCuota in cCuota.BuscarCuotasImpagasPorProfesional(oProfesional.dni))
                {
                    if (oMov.CtaCte.id == oCuota.Profesional.CtaCte.id)
                    {
                        ListaMovimientos.Add(oMov);
                    }
                }
            }

            if (ListaMovimientos.Count == 0) // Si no hay movimientos no tengo que imprimirle
            {
                message.Visible = true;
                lb_error.Text = "El profesional no adeuda ninguna cuota";
            }

            else
            {
                Response.Redirect(String.Format("~/Cuotas/FrmImprimirBoleta_Prof.aspx?tipo_matricula={0}&menor={1}&mayor={2}&descripcion={3}&dni={4}", oProfesional.Tipo_Matricula.id, cCuota.ObtenerCuotas().First().id.ToString(), cCuota.ObtenerCuotas().Last().id.ToString(), "cuota", oProfesional.dni));

                //FrmImprimirBoleta_Prof FormImprimirBoletaProf = new FrmImprimirBoleta_Prof(cCuota.ObtenerCuotas().Last().id, cCuota.ObtenerCuotas().First().id, "cuota", oProfesional.dni, oProfesional.Tipo_Matricula.id);
                //DialogResult DrLogin = FormImprimirBoletaProf.ShowDialog();
            }
        }

        protected void btn_imprimircertificadoH_Click(object sender, EventArgs e)
        {
            if (cmb_tipocertificado.Text == "" || cmb_titulo_certhabilitacion.Text == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar una matrícula y un tipo de certificado para realizar la impresión";
            }

            else
            {
                if (oProfesional.Estado.descripcion == "No Habilitado" || oProfesional.Estado.descripcion == "Baja")
                {
                    message.Visible = true;
                    lb_error.Text = "El profesional no se encuentra habilitado para la emisión del certificado";
                }

                else
                {
                    if (cmb_tipocertificado.Text == "Habilitación")
                    {
                        Response.Redirect(String.Format("~/Profesional/FrmImprimirCertificado.aspx?icie={0}", cmb_titulo_certhabilitacion.Text));
                    }

                    else
                    {
                        Response.Redirect(String.Format("~/Profesional/FrmImprimirCertificado_I.aspx?icie={0}", cmb_titulo_certhabilitacion.Text));
                    }
                }
            }
        }

        protected void dgv_historial_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Text = "Estado";
            e.Row.Cells[2].Text = "Fecha del cambio";
            e.Row.Cells[3].Text = "Tipo de matrícula";
            e.Row.Cells[4].Text = "Observaciones";
        }

        protected void dgv_matriculas_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = "Matrícula";
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }

        protected void dgv_deudas_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = "Cuota";
        }

        protected void dgv_creditos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = "Cuota";
        }

        protected void dgv_expedeintes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Text = "Número";
            e.Row.Cells[1].Text = "Estado";
            e.Row.Cells[2].Text = "Devuelto";
            e.Row.Cells[3].Text = "Recibido";
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Text = "Aprobado";
            e.Row.Cells[6].Text = "Pagado";
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            TimeSpan dif = oProfesional.Historiales.ToList().Last().fecha - DateTime.Now;
            if (dif.Days > -365)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);

                message.Visible = true;
                lb_error.Text = "No se puede suspender a un profesional que haya modificado su matrícula hace menos de 1 año";
            }

            else
            {
                if (lb_mensaje_estado.Text == "¿Está seguro que desea suspender al profesional?") // Lo quiero suspender
                {
                    Modelo_Entidades.Historial oHistorial = new Modelo_Entidades.Historial();
                    oHistorial.estado = cEstado.ObtenerEstadoBaja().descripcion;
                    oProfesional.Estado = cEstado.ObtenerEstadoBaja();
                    oHistorial.fecha = DateTime.Now;
                    oHistorial.tipo_matricula = oProfesional.Tipo_Matricula.descripcion;
                    //Habilito las observaciones del historial
                    oHistorial.observaciones = "Baja voluntaria";
                    oProfesional.Historiales.Add(oHistorial);

                    lb_estado_def.Text = "Baja";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
                    message.Visible = true;
                    lb_error.Text = "El profesional fue suspendido correctamente";
                }

                if (lb_mensaje_estado.Text == "¿Está seguro que desea habilitar al profesional? - La habilitación se realiza por medio del pago de las cuotas. Tenga cuidado al proceder") // Lo quiero habilitar
                {
                    Modelo_Entidades.Historial oHistorial = new Modelo_Entidades.Historial();
                    oHistorial.estado = cEstado.ObtenerEstadoHabilitado().descripcion;
                    oProfesional.Estado = cEstado.ObtenerEstadoHabilitado();
                    oHistorial.fecha = DateTime.Now;
                    oHistorial.tipo_matricula = oProfesional.Tipo_Matricula.descripcion;
                    //Habilito las observaciones del historial
                    oHistorial.observaciones = "Alta";
                    oProfesional.Historiales.Add(oHistorial);

                    lb_estado_def.Text = "Habilitado";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
                    message.Visible = true;
                    lb_error.Text = "El profesional fue dado de alto correctamente";
                }
            }
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void btn_alta_Click(object sender, EventArgs e)
        {
            if (oProfesional.Estado.descripcion == "Alta")
            {
                message.Visible = true;
                lb_error.Text = "El profesional ya se encuentra habilitado";
            }

            else
            {
                lb_mensaje_estado.Text = "¿Está seguro que desea habilitar al profesional? - La habilitación se realiza por medio del pago de las cuotas. Tenga cuidado al proceder";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
            }
        }
    }
}