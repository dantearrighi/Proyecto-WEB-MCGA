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

        string usuario;
        string grupo;
        string direccion;

        string profesional;

        string tipodocumento;
        string localidad;
        string provincia;


        // Declaro las controladoras a utilizar en el formulario
        Controladora.cProfesional cProfesional;
        Controladora.cGrupo cGrupo;
        Controladora.cTipo_Documento cTipo_Documento;
        Controladora.cProvincia cProvincia;
        Controladora.cLocalidad cLocalidad;
        Controladora.cEstado cEstado;

        Controladora.cVerificacion cVerificacion;
        Controladora.cAuditoria cAuditoria;
        Controladora.cUsuario cUsuario;

        // Declaro las entidades
        Modelo_Entidades.Profesional oProfesional;

        Modelo_Entidades.Direccion oDireccion;

        Modelo_Entidades.Usuario miUsuario;

        Modelo_Entidades.Tipo_Documento oTipoDocumento;
        Modelo_Entidades.Localidad oLocalidad;
        Modelo_Entidades.Provincia oProvincia;

      

        List<Modelo_Entidades.Tipo_Documento> lTipoDocumentos;
        List<Modelo_Entidades.Provincia> lProvincias;
        List<Modelo_Entidades.Localidad> lLocalidades;

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
            cVerificacion = Controladora.cVerificacion.ObtenerInstancia();
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

                    txt_direccion.Enabled = false;
                    txt_cp.Enabled = false;
                    cmb_localidades.Enabled = false;
                    cmb_provincias.Enabled = false;

                    txt_direccionE.Enabled = false;
                    txt_cpE.Enabled = false;
                    cmb_localidadesE.Enabled = false;
                    cmb_provinciasE.Enabled = false;






                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                   

                }
            }

            else
            {
                txt_numero.Enabled = true;


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


                }

                else
                {
                    oDireccion = oProfesional.Direcciones.ElementAt(0);
                    localidad = cmb_localidades.SelectedValue.ToString();
                    oLocalidad = cLocalidad.BuscarLocalidadPorDesc(localidad);
                    oDireccion.Localidad = oLocalidad;
                    oDireccion.direccion = txt_direccion.Text;
                    oProfesional.Direcciones.ElementAt(0).Equals(oDireccion);


                }

                oProfesional.telefono = Convert.ToInt32(txt_telfijo.Text);
                oProfesional.celular = Convert.ToInt32(txt_celular.Text);
                oProfesional.email1 = txt_emailpricipal.Text;
                oProfesional.email2 = txt_emailalternativo.Text;
                #endregion

                #region Matrícula del profesional

                /* tipomatricula = cmb_tipomatricula.SelectedValue.ToString();
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
                * 
                * */
                #endregion

                #region Contabilidad del profesional

                /* if (modo == "Alta")
                {
                    // Doy de alta a la cta cte
                    Modelo_Entidades.CtaCte oCtaCte = new Modelo_Entidades.CtaCte();
                    oCtaCte.saldo = 0;
                    oCtaCte.Profesional = oProfesional;
                    oProfesional.CtaCte = oCtaCte;
                }*/

                #endregion

               

                #region Títulos del profesional

                #endregion

                  if (modo == "Alta")
                    {
                        cProfesional.Alta(oProfesional);                    
                                            
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


            #region datos del título

            //if (oProfesional.Matriculas.Count == 0)
            //{
            //    message.Visible = true;
            //    lb_error.Text = "Debe agregar al menos un título Profesional";
            //    return false;
            //}
            #endregion




            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {


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


        }



        // Armo el formulario (si no es una alta)
        private void ArmaFormulario(Modelo_Entidades.Profesional oProfesional)
        {
            // Sección de datos del profesional


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



            txt_telfijo.Text = oProfesional.telefono.ToString();
            txt_celular.Text = oProfesional.celular.ToString();
            txt_emailpricipal.Text = oProfesional.email1;
            txt_emailalternativo.Text = oProfesional.email2;





            // Sección de las observaciones del profesional
            //cmb_tituloamostrar.SelectedValue = oProfesional.titulo_a_mostrar;
       
        }



        protected void btn_baja_Click(object sender, EventArgs e)
        {
            /* if (oProfesional.Estado.descripcion == "Baja")
             {
                 message.Visible = true;
                 lb_error.Text = "El profesional ya se encuentra suspendido";
             }

             else
             {
                 lb_mensaje_estado.Text = "¿Está seguro que desea suspender al profesional?";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
             }*/
        }


        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            /*
                        if (lb_mensaje_estado.Text == "¿Está seguro que desea suspender al profesional?") // Lo quiero suspender
                        {
                            Modelo_Entidades.Historial oHistorial = new Modelo_Entidades.Historial();
                            oHistorial.estado = cEstado.ObtenerEstadoBaja().descripcion;
                            oProfesional.Estado = cEstado.ObtenerEstadoBaja();
                            oHistorial.fecha = DateTime.Now;
                            //Habilito las observaciones del historial
                            oHistorial.observaciones = "Baja voluntaria";
                            oProfesional.Historiales.Add(oHistorial);

              

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
                            message.Visible = true;
                            lb_error.Text = "El profesional fue suspendido correctamente";
                        }

                        if (lb_mensaje_estado.Text == "¿Está seguro que desea habilitar al profesional? ") // Lo quiero habilitar
                        {
                            Modelo_Entidades.Historial oHistorial = new Modelo_Entidades.Historial();
                            oHistorial.estado = cEstado.ObtenerEstadoHabilitado().descripcion;
                            oProfesional.Estado = cEstado.ObtenerEstadoHabilitado();
                            oHistorial.fecha = DateTime.Now;
                            //Habilito las observaciones del historial
                            oHistorial.observaciones = "Alta";
                            oProfesional.Historiales.Add(oHistorial);

               

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
                            message.Visible = true;
                            lb_error.Text = "El profesional fue dado de alto correctamente";
                        }*/
        }

        /*
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
                    lb_mensaje_estado.Text = "¿Está seguro que desea habilitar al profesional?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                }
            }*/
    }
}