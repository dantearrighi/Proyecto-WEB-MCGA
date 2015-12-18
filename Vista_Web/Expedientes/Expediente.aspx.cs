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
    public partial class Expediente : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string expediente;
        string tipo;
        string profesional;
        string expediente_elegido;
        decimal monto_obra;
        string comitente;
        string tarea;

        Controladora.cExpediente cExpediente;
        Controladora.cLiquidacion cLiquidacion;
        Controladora.cProfesional cProfesional;
        Controladora.cTarea cTarea;
        Controladora.cMovimiento cMovimiento;
        Controladora.cTipo_Movimiento cTipo_Movimiento;
        Controladora.cCtaCte cCtaCte;
        Controladora.cComitente cComitente;

        Modelo_Entidades.OI oOI;
        Modelo_Entidades.FE oFE;
        Modelo_Entidades.HM oHM;
        Modelo_Entidades.Expediente oExpediente;
        Modelo_Entidades.Comitente oComitente;
        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Profesional oProfesional;
        Modelo_Entidades.Movimiento oMovimiento;
        Modelo_Entidades.Boleta oBoleta;
        Modelo_Entidades.CtaCte oCtaCte;
        Modelo_Entidades.Tarea oTarea;
        List<Modelo_Entidades.Profesional> lProfesionales;
        List<Modelo_Entidades.Comitente> lComitentes;

        // Constructor
        public Expediente()
        {
            cExpediente = Controladora.cExpediente.ObtenerInstancia();
            cLiquidacion = Controladora.cLiquidacion.ObtenerInstancia();
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
            cTarea = Controladora.cTarea.ObtenerInstancia();
            cMovimiento = Controladora.cMovimiento.ObtenerInstancia();
            cTipo_Movimiento = Controladora.cTipo_Movimiento.ObtenerInstancia();
            cCtaCte = Controladora.cCtaCte.ObtenerInstancia();
            cComitente = Controladora.cComitente.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            expediente = Server.UrlDecode(Request.QueryString["expediente"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);
            tipo = Server.UrlDecode(Request.QueryString["tipo_expediente"]);
            comitente = Server.UrlDecode(Request.QueryString["comitente"]);
            profesional = Server.UrlDecode(Request.QueryString["profesional"]);

            if (modo == "Alta")
            {
                btn_cancelar.Enabled = false;
            }
            //if (expediente == "nuevo")
            //{
            //    switch (tipo)
            //    {
            //        case ("Honorario Mínimo"):
            //            oHM = new Modelo_Entidades.HM();
            //            expediente_elegido = "HM";
            //            oExpediente = oHM;
            //            GuardarExpte(oExpediente);
            //            break;
            //        case ("Fuerza Electromotriz"):
            //            oFE = new Modelo_Entidades.FE();
            //            expediente_elegido = "FE";
            //            oExpediente = oFE;
            //            GuardarExpte(oExpediente);
            //            break;
            //        case ("Obras de Ingenieria"):
            //            oOI = new Modelo_Entidades.OI();
            //            expediente_elegido = "OI";
            //            oExpediente = oOI;
            //            GuardarExpte(oExpediente);
            //            break;
            //    }
            //}

            //else
            //{
            oExpediente = cExpediente.BuscarExpedientePorNumero(Convert.ToInt32(expediente));
            tipo = oExpediente.GetType().ToString();
            switch (tipo)
            {
                case ("Modelo_Entidades.HM"):
                    oHM = (Modelo_Entidades.HM)oExpediente;
                    expediente_elegido = "HM";
                    break;
                case ("Modelo_Entidades.FE"):
                    oFE = (Modelo_Entidades.FE)oExpediente;
                    expediente_elegido = "FE";
                    break;
                case ("Modelo_Entidades.OI"):
                    oOI = (Modelo_Entidades.OI)oExpediente;
                    expediente_elegido = "OI";
                    break;
            }
            //}

            message.Visible = false;

            dtp_fecha_devolución.Enabled = false;
            dtp_fecha_aprobacion.Enabled = false;

            if (comitente != "S/N" && comitente != null)
            {
                oComitente = cComitente.ObtenerComitente(Convert.ToInt32(comitente));
                switch (tipo)
                {
                    case ("Modelo_Entidades.OI"):
                        oOI.Comitente = oComitente;
                        break;
                    case ("Modelo_Entidades.FE"):
                        oFE.Comitente = oComitente;
                        break;
                    case ("Modelo_Entidades.HM"):
                        oHM.Comitente = oComitente;
                        break;
                }
                // Lo muestro en el textbox
                cmb_comitentes.SelectedItem.Text = oComitente.razon_social;

                oExpediente = cExpediente.BuscarExpedientePorNumero(Convert.ToInt32(expediente));
                this.GuardarExpte(oExpediente);
            }

            if (profesional != "")
            {
                if (profesional != null && oExpediente.Profesionales.Contains(cProfesional.ObtenerProfesional(Convert.ToInt32(profesional))) == false)
                {
                    string eleccion = lb_tipo_expediente.Text;

                    oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));

                    oExpediente = cExpediente.BuscarExpedientePorNumero(Convert.ToInt32(expediente));

                    if (oProfesional.Estado.descripcion == "No Habilitado" || oProfesional.Estado.descripcion == "Baja")
                    {
                        message.Visible = true;
                        lb_error.Text = "El profesional no se encuentra habilitado para realizar el expediente";
                    }

                    else
                    {
                        tipo = oExpediente.GetType().ToString();

                        switch (tipo)
                        {
                            case ("Modelo_Entidades.OI"):
                                oOI.Profesionales.Add(oProfesional);
                                // Limpio la grilla
                                gv_profesionales.DataSource = null;
                                // Asigno el binding a la grilla
                                gv_profesionales.DataSource = oOI.Profesionales;
                                gv_profesionales.DataBind();
                                break;
                            case ("Modelo_Entidades.FE"):
                                oFE.Profesionales.Add(oProfesional);
                                // Limpio la grilla
                                gv_profesionales.DataSource = null;
                                // Asigno el binding a la grilla
                                gv_profesionales.DataSource = oFE.Profesionales;
                                gv_profesionales.DataBind();
                                break;
                            case ("Modelo_Entidades.HM"):
                                oHM.Profesionales.Add(oProfesional);
                                // Limpio la grilla
                                gv_profesionales.DataSource = null;
                                // Asigno el binding a la grilla
                                gv_profesionales.DataSource = oHM.Profesionales;
                                gv_profesionales.DataBind();
                                break;
                        }

                        this.GuardarExpte(oExpediente);
                    }
                }
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
            Page.Response.Redirect("~/Expedientes/Gestion de Expedientes.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Modelo_Entidades.Expediente oExpediente;

            if (ValidarObligatorios() == true)
            {
                try
                {
                    string eleccion = lb_tipo_expediente.Text;
                    switch (tipo)
                    {
                        case ("Modelo_Entidades.OI"):
                            oExpediente = oOI;
                            if (cmb_tareas_OI.SelectedItem != null)
                            {
                                tarea = cmb_tareas_OI.SelectedItem.Text;
                                oTarea = cTarea.ObtenerTareaPorDesc(tarea);
                                oExpediente.Tarea = oTarea;
                            }
                            GuardarExpte(oExpediente);
                            break;
                        case ("Modelo_Entidades.FE"):
                            oExpediente = oFE;
                            if (cmb_tareas_fe.SelectedItem != null)
                            {
                                tarea = cmb_tareas_fe.SelectedItem.Text;
                                oTarea = cTarea.ObtenerTareaPorDesc(tarea);
                                oExpediente.Tarea = oTarea;
                            }
                            GuardarExpte(oExpediente);
                            break;
                        case ("Modelo_Entidades.HM"):
                            oExpediente = oHM;
                            if (cmb_tareas_hm.SelectedItem != null)
                            {
                                tarea = cmb_tareas_hm.SelectedItem.Text;
                                oTarea = cTarea.ObtenerTareaPorDesc(tarea);
                                oExpediente.Tarea = oTarea;
                            }
                            GuardarExpte(oExpediente);
                            break;
                    }
                }

                catch (Exception Exc)
                {
                    message.Visible = true;
                    lb_error.Text = Exc.Message.ToString();
                }

                Page.Response.Redirect("~/Expedientes/Gestion de Expedientes.aspx");
            }
        }

        // Valido los datos del expediente
        private bool ValidarObligatorios()
        {
            if (gv_profesionales.Rows.Count == 0)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar al menos un profesional para el expediente";
                return false;
            }

            if (dtp_fecha_recepcion.Text == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar al menos una fecha de recepción para el expediente";
                return false;
            }

            if (string.IsNullOrEmpty(cmb_comitentes.SelectedItem.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una comitente para el expediente";
                return false;
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            if (modo == "Alta")
            {
                lb_numero_expediente.Text = "S/N";
                lb_estado_expediente.Text = "Recibido";

                dtp_fecha_aprobacion.Text = "";
                dtp_fecha_pago.Text = "";
                dtp_fecha_devolución.Text = "";

                // Si el expte es nuevo, lo cargo con la fecha actual
                dtp_fecha_recepcion.Text = DateTime.Now.ToShortDateString();
            }

            cmb_comitentes.Items.Clear();
            lComitentes = cComitente.ObtenerComitentes();
            cmb_comitentes.DataSource = lComitentes;
            cmb_comitentes.DataBind();

            tipo = oExpediente.GetType().ToString();
            switch (tipo)
            {
                #region Honorario mínimo
                case ("Modelo_Entidades.HM"):

                    lb_tipo_expediente.Text = "Honorario Mínimo";

                    HM.Visible = true;
                    FE.Visible = false;
                    OI.Visible = false;

                    cmb_tareas_hm.Items.Clear();
                    cmb_tareas_hm.DataSource = cTarea.BuscarTareasPorObra("Honorario Minimo");
                    cmb_tareas_hm.DataBind();

                    if (modo != "Alta")
                    {
                        if (modo == "Consulta")
                        {
                            InhabilitarControles();

                            dgv_liquidaciones_HM.Enabled = false;

                            cmb_tareas_hm.Enabled = false;
                            nud_dias_campo_HM.Enabled = false;
                            nud_dias_gabinete_HM.Enabled = false;

                        }

                        #region Datos del expediente

                        lb_numero_expediente.Text = oHM.numero.ToString();
                        lb_estado_expediente.Text = oHM.estado;

                        dtp_fecha_recepcion.Text = oHM.fecha_recepcion.ToShortDateString();

                        switch (oHM.estado)
                        {
                            case ("Recibido"):
                                {
                                    dtp_fecha_aprobacion.Text = "";
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_pago.Text = "";
                                    dtp_fecha_recepcion.Text = oHM.fecha_recepcion.ToShortDateString();
                                    break;
                                }

                            case ("Aprobado"):
                                {
                                    dtp_fecha_pago.Text = "";
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_recepcion.Text = oHM.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oHM.fecha_aprobacion.ToShortDateString();
                                    break;
                                }

                            case ("Pagado"):
                                {
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_recepcion.Text = oHM.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oHM.fecha_aprobacion.ToShortDateString();
                                    dtp_fecha_pago.Text = oHM.fecha_pago.ToShortDateString();
                                    break;
                                }


                            case ("Devuelto"):
                                {
                                    dtp_fecha_recepcion.Text = oHM.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oHM.fecha_aprobacion.ToShortDateString();
                                    dtp_fecha_pago.Text = oHM.fecha_pago.ToShortDateString();
                                    dtp_fecha_devolución.Text = oHM.fecha_devolucion.ToShortDateString();
                                    break;
                                }
                        }

                        cmb_comitentes.SelectedItem.Text = oHM.Comitente.razon_social;
                        // Limpio la grilla
                        gv_profesionales.DataSource = null;
                        // Asigno el binding a la grilla
                        gv_profesionales.DataSource = oHM.Profesionales;
                        gv_profesionales.DataBind();
                        #endregion

                        #region Datos propios del HM
                        nud_dias_campo_HM.Text = oHM.dias_de_campo.ToString();
                        nud_dias_gabinete_HM.Text = oHM.dias_de_gabinete.ToString();

                        // Limpio la grilla
                        dgv_liquidaciones_HM.DataSource = null;
                        // LLeno el binding con los datos que traigo de las entidades
                        dgv_liquidaciones_HM.DataSource = oHM.Liquidaciones;
                        dgv_liquidaciones_HM.DataBind();

                        // Seccion de datos del groupbox "Totales"
                        int i_1 = 0;
                        double suma_2 = 0;
                        while (i_1 < dgv_liquidaciones_HM.Rows.Count)
                        {
                            if (dgv_liquidaciones_HM.Rows[i_1] != null)
                            {
                                suma_2 = Convert.ToDouble(dgv_liquidaciones_HM.Rows[i_1].Cells[4].Text) + suma_2;
                            }

                            i_1++;
                        }

                        txt_total_a_liquidar.Text = suma_2.ToString();
                        txt_aportes_al_cie.Text = ((suma_2) * 0.05).ToString();
                        txt_aportes_a_caja.Text = ((suma_2) * 0.23).ToString();
                        txt_total_aportes.Text = (((suma_2) * 0.05) + ((suma_2) * 0.23)).ToString();
                        InhabilitarTxts();
                        #endregion
                    }

                    else
                    {
                        oHM.estado = "Recibido";
                    }
                    break;
                #endregion

                #region Fuerza electromotriz
                case ("Modelo_Entidades.FE"):

                    lb_tipo_expediente.Text = "Fuerza electromotriz";

                    HM.Visible = false;
                    FE.Visible = true;
                    OI.Visible = false;

                    cmb_tareas_fe.Items.Clear();
                    cmb_tareas_fe.DataSource = cTarea.BuscarTareasPorObra("Fuerza Electromotriz");
                    cmb_tareas_fe.DataBind();

                    if (modo != "Alta")
                    {
                        if (modo == "Consulta")
                        {
                            InhabilitarControles();

                            dgv_liquidaciones_FE.Enabled = false;

                            cmb_tareas_fe.Enabled = false;
                            nud_dias_campo_FE.Enabled = false;
                            nud_dias_gabinete_FE.Enabled = false;
                            nud_num_hp_FE.Enabled = false;
                            nud_num_bocas_FE.Enabled = false;
                            nud_num_motores_FE.Enabled = false;
                        }

                        #region Datos del expediente

                        lb_numero_expediente.Text = oFE.numero.ToString();
                        lb_estado_expediente.Text = oFE.estado;

                        cmb_tareas_fe.Text = oFE.Tarea.ToString();
                        dtp_fecha_recepcion.Text = oFE.fecha_recepcion.ToShortDateString();

                        switch (oFE.estado)
                        {
                            case ("Recibido"):
                                {
                                    dtp_fecha_aprobacion.Text = "";
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_pago.Text = "";
                                    dtp_fecha_recepcion.Text = oFE.fecha_recepcion.ToShortDateString();
                                    break;
                                }

                            case ("Aprobado"):
                                {
                                    dtp_fecha_pago.Text = "";
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_recepcion.Text = oFE.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oFE.fecha_aprobacion.ToShortDateString();
                                    break;
                                }

                            case ("Pagado"):
                                {
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_recepcion.Text = oFE.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oFE.fecha_aprobacion.ToShortDateString();
                                    dtp_fecha_pago.Text = oFE.fecha_pago.ToShortDateString();
                                    break;
                                }


                            case ("Devuelto"):
                                {
                                    dtp_fecha_recepcion.Text = oFE.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oFE.fecha_aprobacion.ToShortDateString();
                                    dtp_fecha_pago.Text = oFE.fecha_pago.ToShortDateString();
                                    dtp_fecha_devolución.Text = oFE.fecha_devolucion.ToShortDateString();
                                    break;
                                }
                        }

                        cmb_comitentes.SelectedValue = oFE.Comitente.razon_social;
                        // Limpio la grilla
                        gv_profesionales.DataSource = null;
                        // Asigno el binding a la grilla
                        gv_profesionales.DataSource = oFE.Profesionales;
                        gv_profesionales.DataBind();
                        #endregion

                        #region Datos propios del FE
                        nud_dias_campo_FE.Text = oFE.dias_de_campo.ToString();
                        nud_dias_gabinete_FE.Text = oFE.dias_de_gabinete.ToString();
                        nud_num_hp_FE.Text = oFE.hps.ToString();
                        nud_num_bocas_FE.Text = oFE.bocas.ToString();
                        nud_num_motores_FE.Text = oFE.motores.ToString();

                        // Limpio la grilla
                        dgv_liquidaciones_FE.DataSource = null;
                        // LLeno el binding con los datos que traigo de las entidades
                        dgv_liquidaciones_FE.DataSource = oFE.Liquidaciones;
                        dgv_liquidaciones_FE.DataBind();
                        // Seccion de datos del groupbox "Totales"
                        int i = 0;
                        double suma_2 = 0;
                        while (i < dgv_liquidaciones_FE.Rows.Count)
                        {
                            if (dgv_liquidaciones_FE.Rows[i] != null)
                            {
                                suma_2 = Convert.ToDouble(dgv_liquidaciones_FE.Rows[i].Cells[4].Text) + suma_2;
                            }

                            i++;
                        }

                        txt_total_a_liquidar.Text = suma_2.ToString();
                        txt_aportes_al_cie.Text = ((suma_2) * 0.05).ToString();
                        txt_aportes_a_caja.Text = ((suma_2) * 0.23).ToString();
                        txt_total_aportes.Text = (((suma_2) * 0.05) + ((suma_2) * 0.23)).ToString();
                        InhabilitarTxts();

                        #endregion
                    }

                    else
                    {
                        oFE.estado = "Recibido";
                    }

                    break;

                #endregion

                #region Obras de ingeniería
                case ("Modelo_Entidades.OI"):
                    lb_tipo_expediente.Text = "Obra de ingeniería";

                    HM.Visible = false;
                    FE.Visible = false;
                    OI.Visible = true;

                    cmb_tareas_OI.Items.Clear();
                    cmb_tareas_OI.DataSource = cTarea.BuscarTareasPorObra("Obras de Ingenieria");
                    
                    cmb_tareas_OI.DataBind();

                    

                    if (modo != "Alta")
                    {
                        if (modo == "Consulta")
                        {
                            InhabilitarControles();

                            dgv_liquidaciones_OI.Enabled = false;

                            cmb_tareas_OI.Enabled = false;
                            nud_monto_obra_OI.Enabled = false;
                            chk_aportes.Enabled = false;

                            chk_anteproyecto.Enabled = false;
                            chk_proyecto_sin_anteproyecto.Enabled = false;
                            chk_proyecto.Enabled = false;
                            chk_conduccion_tecnica.Enabled = false;
                            chk_administracion.Enabled = false;
                            chk_trámites.Enabled = false;
                            chk_representacion_tecnica.Enabled = false;
                            chk_direccion_de_la_obra.Enabled = false;

                        }

                        lb_numero_expediente.Text = oOI.numero.ToString();
                        lb_estado_expediente.Text = oOI.estado;

                        #region Datos del expediente

                        lb_numero_expediente.Text = oOI.numero.ToString();
                        lb_estado_expediente.Text = oOI.estado;

                        dtp_fecha_recepcion.Text = oOI.fecha_recepcion.ToShortDateString();

                        switch (oOI.estado)
                        {
                            case ("Recibido"):
                                {
                                    dtp_fecha_aprobacion.Text = "";
                                    dtp_fecha_pago.Text = "";
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_recepcion.Text = oOI.fecha_recepcion.ToShortDateString();
                                    break;
                                }

                            case ("Aprobado"):
                                {
                                    dtp_fecha_aprobacion.Text = "";
                                    dtp_fecha_pago.Text = "";
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_recepcion.Text = oOI.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oOI.fecha_aprobacion.ToShortDateString();
                                    break;
                                }

                            case ("Pagado"):
                                {
                                    dtp_fecha_aprobacion.Text = "";
                                    dtp_fecha_pago.Text = "";
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_recepcion.Text = oOI.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oOI.fecha_aprobacion.ToShortDateString();
                                    dtp_fecha_pago.Text = oOI.fecha_pago.ToShortDateString();
                                    break;
                                }

                            case ("Devuelto"):
                                {
                                    dtp_fecha_devolución.Text = "";
                                    dtp_fecha_recepcion.Text = oOI.fecha_recepcion.ToShortDateString();
                                    dtp_fecha_aprobacion.Text = oOI.fecha_aprobacion.ToShortDateString();
                                    dtp_fecha_pago.Text = oOI.fecha_pago.ToShortDateString();
                                    dtp_fecha_devolución.Text = oOI.fecha_devolucion.ToShortDateString();
                                    break;
                                }
                        }

                        cmb_comitentes.SelectedItem.Text = oOI.Comitente.razon_social;
                        // Limpio la grilla
                        gv_profesionales.DataSource = null;
                        // Asigno el binding a la grilla
                        gv_profesionales.DataSource = oOI.Profesionales;
                        gv_profesionales.DataBind();
                        #endregion

                        #region Datos propios de la OI
                        nud_monto_obra_OI.Text = oOI.monto_obra.ToString();
                        cmb_tareas_OI.SelectedValue = oOI.Tarea.descripcion;

                        // Limpio la grilla
                        dgv_liquidaciones_OI.DataSource = null;
                        // LLeno el binding con los datos que traigo de las entidades
                        dgv_liquidaciones_OI.DataSource = oOI.Liquidaciones;
                        dgv_liquidaciones_OI.DataBind();

                        if (oOI.Liquidaciones.Count != 0)
                        {
                            if (oOI.Liquidaciones.ElementAt(0).importe == 0)
                            {
                                chk_anteproyecto.Checked = false;
                            }

                            else
                            {
                                chk_anteproyecto.Checked = true;
                            }

                            if (oOI.Liquidaciones.ElementAt(1).importe == 0)
                            {
                                chk_proyecto_sin_anteproyecto.Checked = false;
                            }

                            else
                            {
                                chk_proyecto_sin_anteproyecto.Checked = true;
                            }

                            if (oOI.Liquidaciones.ElementAt(2).importe == 0)
                            {
                                chk_proyecto.Checked = false;
                            }

                            else
                            {
                                chk_proyecto.Checked = true;
                            }

                            if (oOI.Liquidaciones.ElementAt(3).importe == 0)
                            {
                                chk_conduccion_tecnica.Checked = false;
                            }

                            else
                            {
                                chk_conduccion_tecnica.Checked = true;
                            }

                            if (oOI.Liquidaciones.ElementAt(4).importe == 0)
                            {
                                chk_administracion.Checked = false;
                            }

                            else
                            {
                                chk_administracion.Checked = true;
                            }

                            if (oOI.Liquidaciones.ElementAt(5).importe == 0)
                            {
                                chk_trámites.Checked = false;
                            }

                            else
                            {
                                chk_trámites.Checked = true;
                            }

                            if (oOI.Liquidaciones.ElementAt(6).importe == 0)
                            {
                                chk_representacion_tecnica.Checked = false;
                            }

                            else
                            {
                                chk_representacion_tecnica.Checked = true;
                            }

                            if (oOI.Liquidaciones.ElementAt(7).importe == 0)
                            {
                                chk_direccion_de_la_obra.Checked = false;
                            }

                            else
                            {
                                chk_direccion_de_la_obra.Checked = true;
                            }

                            // Seccion de datos del groupbox "Totales"
                            int i_2 = 0;
                            double suma_2 = 0;
                            while (i_2 < dgv_liquidaciones_OI.Rows.Count)
                            {
                                if (dgv_liquidaciones_OI.Rows[i_2] != null)
                                {
                                    suma_2 = Convert.ToDouble(dgv_liquidaciones_OI.Rows[i_2].Cells[4].Text) + suma_2;
                                }

                                i_2++;
                            }

                            txt_total_a_liquidar.Text = suma_2.ToString();
                            txt_aportes_al_cie.Text = ((suma_2) * 0.05).ToString();
                            txt_aportes_a_caja.Text = ((suma_2) * 0.23).ToString();
                            txt_total_aportes.Text = (((suma_2) * 0.05) + ((suma_2) * 0.23)).ToString();
                            InhabilitarTxts();
                        }

                        //dtp_fecha_recepcion.Checked.Equals(true);


                        #endregion
                    }

                    else
                    {
                        oOI.estado = "Recibido";
                    }

                    break;
                #endregion
            }
        }

        protected void btn_cambiarpass_Click(object sender, EventArgs e)
        {

        }

        protected void gv_profesionales_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Text = "DNI";
            e.Row.Cells[2].Text = "Nombre y Apellido";
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
        }

        private void InhabilitarControles()
        {
            btn_guardar.Enabled = false;
            btn_liquidar.Enabled = false;
            btn_cancelar.Text = "Cerrar";
            btn_agregar.Enabled = false;
            btn_quitar.Enabled = false;

            txt_total_a_liquidar.Enabled = false;
            txt_aportes_al_cie.Enabled = false;
            txt_aportes_a_caja.Enabled = false;
            txt_total_aportes.Enabled = false;
            
            gv_profesionales.Enabled = false;

            dtp_fecha_aprobacion.Enabled = false;
            dtp_fecha_pago.Enabled = false;
            dtp_fecha_devolución.Enabled = false;
            dtp_fecha_recepcion.Enabled = false;

            cmb_comitentes.Enabled = false;
        }

        protected void btn_liquidar_Click(object sender, EventArgs e)
        {
            string eleccion = lb_tipo_expediente.Text;

            switch (eleccion)
            {
                #region Liquidación OI
                case ("Obra de ingeniería"):
                    if (oOI.Comitente == null || oOI.Profesionales == null)
                    {
                        message.Visible = true;
                        lb_error.Text = "Antes de liquidar el expediente, debe ingresar un comitente y al menos un profesional";
                        return;
                    }

                    else
                    {
                        if (dgv_liquidaciones_OI.Rows.Count != 0)
                        {
                            lb_mje_modal.Text = "Ya ha realizado la liquidación del expediente. ¿Desea realizarla de nuevo?";
                            
                            message.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                        }
                        else
                        {
                            Liquidar_OI();
                        }
                    }
                    break;

                #endregion

                #region Liquidación FE
                case ("Fuerza electromotriz"):
                    if (oFE.Comitente == null || oFE.Profesionales == null)
                    {
                        message.Visible = true;
                        lb_error.Text = "Antes de liquidar el expediente, debe ingresar un comitente y al menos un profesional";
                        return;
                    }

                    else
                    {
                        if (dgv_liquidaciones_FE.Rows.Count != 0)
                        {
                            lb_mje_modal.Text = "Ya ha realizado la liquidación del expediente. ¿Desea realizarla de nuevo?";

                            message.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                        }
                        else
                        {
                            Liquidar_FE();
                        }
                    }
                    break;
                #endregion

                #region Liquidación HM
                case ("Honorario Mínimo"):
                    if (oHM.Comitente == null || oHM.Profesionales == null)
                    {
                        message.Visible = true;
                        lb_error.Text = "Antes de liquidar el expediente, debe ingresar un comitente y al menos un profesional";
                        return;
                    }

                    else
                    {
                        if (dgv_liquidaciones_HM.Rows.Count != 0)
                        {
                            lb_mje_modal.Text = "Ya ha realizado la liquidación del expediente. ¿Desea realizarla de nuevo?";

                            message.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                        }
                        else
                        {
                            Liquidar_HM();
                        }
                    }
                    break;

                #endregion
            }
        }

        protected void dgv_liquidaciones_HM_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        private void InhabilitarTxts()
        {
            txt_total_a_liquidar.Enabled = false;
            txt_aportes_al_cie.Enabled = false;
            txt_aportes_a_caja.Enabled = false;
            txt_total_aportes.Enabled = false;
        }

        protected void dgv_liquidaciones_FE_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void chk_aprobar_CheckedChanged(object sender, EventArgs e)
        {
            dtp_fecha_aprobacion.Enabled = true;

            string eleccion = lb_tipo_expediente.Text;

            if (chk_aprobar.Checked == true)
            {
                switch (eleccion)
                {
                    case ("Obra de ingeniería"):
                        oOI.estado = "Aprobado";
                        break;

                    case ("Fuerza electromotriz"):
                        oFE.estado = "Aprobado";
                        break;

                    case ("Honorario Mínimo"):
                        oHM.estado = "Aprobado";
                        break;
                }
            }

            else
            {
                dtp_fecha_aprobacion.Enabled = false;

                switch (eleccion)
                {
                    case ("Obras de Ingenieria"):
                        oOI.estado = "Recibido";
                        break;

                    case ("Fuerza Electromotriz"):
                        oFE.estado = "Recibido";
                        break;

                    case ("Honorario Mínimo"):
                        oHM.estado = "Recibido";
                        break;
                }
            }
        }

        protected void chk_devuelto_CheckedChanged(object sender, EventArgs e)
        {
            dtp_fecha_devolución.Enabled = true;

            string eleccion = lb_tipo_expediente.Text;

            if (chk_aprobar.Checked == true)
            {
                if (chk_devuelto.Checked == true)
                {
                    switch (eleccion)
                    {
                        case ("Obras de Ingenieria"):
                            oOI.estado = "Devuelto";
                            break;

                        case ("Fuerza Electromotriz"):
                            oFE.estado = "Devuelto";
                            break;

                        case ("Honorario Mínimo"):
                            oHM.estado = "Devuelto";
                            break;
                    }
                }

                else
                {
                    dtp_fecha_devolución.Enabled = false;

                    switch (eleccion)
                    {
                        case ("Obras de Ingenieria"):
                            oOI.estado = "Aprobado";
                            break;

                        case ("Fuerza Electromotriz"):
                            oFE.estado = "Aprobado";
                            break;

                        case ("Honorario Mínimo"):
                            oHM.estado = "Aprobado";
                            break;
                    }
                }
            }

            else
            {
                message.Visible = true;
                lb_error.Text = "Antes de ingresar la devolución, debe ingresar la fecha de recepción";
            }
        }

        protected void dgv_liquidaciones_OI_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            string eleccion = lb_tipo_expediente.Text;

            switch (eleccion)
            {
                case ("Obras de Ingenieria"):
                    Liquidar_OI();
                    break;
                case ("Fuerza Electromotriz"):
                    Liquidar_FE();
                    break;
                case ("Honorario Mínimo"):
                    Liquidar_HM();
                    break;
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        // Liquido las OI
        private void Liquidar_OI()
        {
            // Lo 1º que hago es eliminar la liquidación anterior
            foreach (Modelo_Entidades.Liquidacion oLiq in cLiquidacion.ObtenerLiquidaciones())
            {
                if (oOI.numero == oLiq.Expediente.numero)
                {
                    cLiquidacion.EliminarLiquidacion(oLiq);
                }
            }

            #region Liquidación del OI
            // Faltaria validar los datos del OI (con un metodo)
            decimal monto_obra_definitivo = cExpediente.CalcularTotalaLiquidar_OI(Convert.ToDecimal(nud_monto_obra_OI.Text));
            monto_obra = monto_obra_definitivo;

            if (chk_anteproyecto.Checked == true) // Verifica si esta tildado
            {
                // Liquido el anteproyecto (10%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_a = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_a.tarea = "Anteproyecto";
                NuevaLiquidacion_a.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de anteproyecto
                NuevaLiquidacion_a.importe = monto_obra;
                NuevaLiquidacion_a.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_a);
                oOI.Liquidaciones.Add(NuevaLiquidacion_a);
            }

            else
            {
                // Liquido el anteproyecto (10%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_a = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_a.tarea = "Anteproyecto";
                NuevaLiquidacion_a.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de anteproyecto
                NuevaLiquidacion_a.importe = 0;
                NuevaLiquidacion_a.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_a);
                oOI.Liquidaciones.Add(NuevaLiquidacion_a);
            }

            if (chk_proyecto_sin_anteproyecto.Checked == true) // Verifica si esta tildado
            {
                // Liquido el proyecto sin el anteproyecto (45%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_b = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_b.tarea = "Proyecto sin anteproyecto";
                NuevaLiquidacion_b.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de anteproyecto
                NuevaLiquidacion_b.importe = monto_obra;
                NuevaLiquidacion_b.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_b);
                oOI.Liquidaciones.Add(NuevaLiquidacion_b);
            }

            else
            {
                // Liquido el proyecto sin el anteproyecto (45%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_b = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_b.tarea = "Proyecto sin anteproyecto";
                NuevaLiquidacion_b.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de anteproyecto
                NuevaLiquidacion_b.importe = 0;
                NuevaLiquidacion_b.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_b);
                oOI.Liquidaciones.Add(NuevaLiquidacion_b);
            }

            if (chk_proyecto.Checked == true) // Verifica si esta tildado
            {
                // Liquido el proyecto (55%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_c = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_c.tarea = "Proyecto de la obra";
                NuevaLiquidacion_c.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Proyecto de la obra
                NuevaLiquidacion_c.importe = monto_obra;
                NuevaLiquidacion_c.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_c);
                oOI.Liquidaciones.Add(NuevaLiquidacion_c);
            }

            else
            {
                // Liquido el proyecto (55%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_c = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_c.tarea = "Proyecto de la obra";
                NuevaLiquidacion_c.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Proyecto de la obra
                NuevaLiquidacion_c.importe = 0;
                NuevaLiquidacion_c.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_c);
                oOI.Liquidaciones.Add(NuevaLiquidacion_c);
            }

            if (chk_conduccion_tecnica.Checked == true) // Verifica si esta tildado
            {
                // Liquido la conducción técnica (45%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_d = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_d.tarea = "Conducción técnica de la obra";
                NuevaLiquidacion_d.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Conducción técnica de la obra
                NuevaLiquidacion_d.importe = monto_obra;
                NuevaLiquidacion_d.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_d);
                oOI.Liquidaciones.Add(NuevaLiquidacion_d);
            }

            else
            {
                // Liquido la conducción técnica (45%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_d = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_d.tarea = "Conducción técnica de la obra";
                NuevaLiquidacion_d.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Conducción técnica de la obra
                NuevaLiquidacion_d.importe = 0;
                NuevaLiquidacion_d.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_d);
                oOI.Liquidaciones.Add(NuevaLiquidacion_d);
            }

            if (chk_administracion.Checked == true) // Verifica si esta tildado
            {
                // Liquido la Administración a cargo del comitente (13.5%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_e = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_e.tarea = "Administración a cargo del comitente";
                NuevaLiquidacion_e.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Administración a cargo del comitente
                NuevaLiquidacion_e.importe = monto_obra;
                NuevaLiquidacion_e.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_e);
                oOI.Liquidaciones.Add(NuevaLiquidacion_e);
            }

            else
            {
                // Liquido la Administración a cargo del comitente (13.5%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_e = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_e.tarea = "Administración a cargo del comitente";
                NuevaLiquidacion_e.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Administración a cargo del comitente
                NuevaLiquidacion_e.importe = 0;
                NuevaLiquidacion_e.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_e);
                oOI.Liquidaciones.Add(NuevaLiquidacion_e);
            }

            if (chk_trámites.Checked == true) // Verifica si esta tildado
            {
                // Liquido los trámites (0.2%) (es sobre el monto de obra)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_f = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_f.tarea = "Trámites";
                NuevaLiquidacion_f.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Trámites
                NuevaLiquidacion_f.importe = Convert.ToDecimal(nud_monto_obra_OI.Text);
                NuevaLiquidacion_f.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_f);
                oOI.Liquidaciones.Add(NuevaLiquidacion_f);
            }

            else
            {
                // Liquido los trámites (0.2%) (es sobre el monto de obra)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_f = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_f.tarea = "Trámites";
                NuevaLiquidacion_f.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Trámites
                NuevaLiquidacion_f.importe = 0;
                NuevaLiquidacion_f.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_f);
                oOI.Liquidaciones.Add(NuevaLiquidacion_f);
            }

            if (chk_representacion_tecnica.Checked == true) // Verifica si esta tildado
            {
                // Liquido la representación técnica de la obra (13.5% + 45%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_g = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_g.tarea = "Representación técnica de la obra";
                NuevaLiquidacion_g.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Representación técnica de la obra
                NuevaLiquidacion_g.importe = monto_obra;
                NuevaLiquidacion_g.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_g);
                oOI.Liquidaciones.Add(NuevaLiquidacion_g);
            }

            else
            {
                // Liquido la representación técnica de la obra (13.5% + 45%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_g = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_g.tarea = "Representación técnica de la obra";
                NuevaLiquidacion_g.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Representación técnica de la obra
                NuevaLiquidacion_g.importe = 0;
                NuevaLiquidacion_g.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_g);
                oOI.Liquidaciones.Add(NuevaLiquidacion_g);
            }

            if (chk_direccion_de_la_obra.Checked == true) // Verifica si esta tildado
            {
                // Liquido la dirección de la obra (45%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_h = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_h.tarea = "Dirección de la obra";
                NuevaLiquidacion_h.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Dirección de la obra
                NuevaLiquidacion_h.importe = monto_obra;
                NuevaLiquidacion_h.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_h);
                oOI.Liquidaciones.Add(NuevaLiquidacion_h);
            }

            else
            {
                // Liquido la dirección de la obra (45%)
                Modelo_Entidades.Liquidacion NuevaLiquidacion_h = new Modelo_Entidades.Liquidacion();
                NuevaLiquidacion_h.tarea = "Dirección de la obra";
                NuevaLiquidacion_h.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion de Dirección de la obra
                NuevaLiquidacion_h.importe = 0;
                NuevaLiquidacion_h.Expediente = oOI;
                cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_h);
                oOI.Liquidaciones.Add(NuevaLiquidacion_h);
            }
            #endregion

            // Limpio la grilla
            dgv_liquidaciones_OI.DataSource = null;
            // LLeno el binding con los datos que traigo de las entidades
            dgv_liquidaciones_OI.DataSource = cExpediente.LiquidarExpediente(oOI);
            dgv_liquidaciones_OI.DataBind();

            int i_2 = 0;
            double suma_2 = 0;
            while (i_2 < dgv_liquidaciones_OI.Rows.Count)
            {
                if (dgv_liquidaciones_OI.Rows[i_2] != null)
                {
                    suma_2 = Convert.ToDouble(dgv_liquidaciones_OI.Rows[i_2].Cells[4].Text) + suma_2;
                }

                i_2++;
            }

            txt_total_a_liquidar.Text = suma_2.ToString();
            txt_aportes_al_cie.Text = ((suma_2) * 0.05).ToString();
            txt_aportes_a_caja.Text = ((suma_2) * 0.23).ToString();
            txt_total_aportes.Text = (((suma_2) * 0.05) + ((suma_2) * 0.23)).ToString();
            InhabilitarTxts();

            #region Agregado del saldo a la cta cte del profesional
            profesional = gv_profesionales.Rows[0].Cells[1].Text;
            oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));

            if (cMovimiento.BuscarMovimientoPorDescExpte(oOI.numero) != null) // quiere decir que está, por lo que se tiene que modificar
            {
                oMovimiento = cMovimiento.BuscarMovimientoPorDescExpte(oOI.numero);

                // Lo 1º es sumar el saldo anterior, para que no se siga restando
                oCtaCte = oProfesional.CtaCte;
                oCtaCte.saldo = oCtaCte.saldo + Convert.ToDecimal(oMovimiento.importe);

                // Luego, hago los 2 cambios que afectan al movimiento
                oMovimiento.fecha = DateTime.Now;
                oMovimiento.importe = ((suma_2) * 0.05);
                //oMovimiento.descripcion = "Débito del expediente número " + oOI.numero.ToString();
                //oMovimiento.CtaCte = oProfesional.CtaCte;
                //oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                //oMovimiento.Comprobante = oBoleta;

                cMovimiento.ModificarMovimiento(oMovimiento);
                //oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(((suma_2) * 0.05));
                cCtaCte.Modificacion(oCtaCte);
            }

            else
            {
                oMovimiento = new Modelo_Entidades.Movimiento();
                oBoleta = new Modelo_Entidades.Boleta();

                oMovimiento.fecha = DateTime.Now;
                oMovimiento.importe = ((suma_2) * 0.05);
                oMovimiento.descripcion = "Débito del expediente número " + oOI.numero.ToString();
                oMovimiento.CtaCte = oProfesional.CtaCte;
                oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                oMovimiento.Comprobante = oBoleta;

                cMovimiento.Alta(oMovimiento);
                oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                oCtaCte = oProfesional.CtaCte;
                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(((suma_2) * 0.05));
                cCtaCte.Modificacion(oCtaCte);
            }
            #endregion

        }

        // Liquido las FE
        private void Liquidar_FE()
        {
            decimal coeficiente_k;

            // Lo 1º que hago es eliminar la liquidación anterior
            foreach (Modelo_Entidades.Liquidacion oLiq in cLiquidacion.ObtenerLiquidaciones())
            {
                if (oFE.numero == oLiq.Expediente.numero)
                {
                    cLiquidacion.EliminarLiquidacion(oLiq);
                }
            }

            oFE.dias_de_campo = Convert.ToDecimal(nud_dias_campo_FE.Text);
            oFE.dias_de_gabinete = Convert.ToDecimal(nud_dias_campo_FE.Text);
            oFE.hps = Convert.ToDecimal(nud_num_hp_FE.Text);
            oFE.bocas = Convert.ToDecimal(nud_num_bocas_FE.Text);
            oFE.motores = Convert.ToDecimal(nud_num_motores_FE.Text);

            // Hago los calculos necesarios para obtener el monto de obra
            coeficiente_k = cExpediente.CalcularCoeficienteK(oFE.hps, oFE.bocas, oFE.motores);

            #region Liquidación del FE
            // Agrego las liquidaciones para que luego pueda modificar sus valores y luegos ponerlas en el datagridview según sea la solapa

            // Liquidacion con respecto a los dias de campo
            Modelo_Entidades.Liquidacion NuevaLiquidacion_1 = new Modelo_Entidades.Liquidacion();
            NuevaLiquidacion_1.tarea = "Dias de campo liquidados";
            NuevaLiquidacion_1.cantidad = Convert.ToDecimal(nud_dias_campo_FE.Text);
            NuevaLiquidacion_1.importe = 0.4m; // Esta hardcodeado, pero hay que ponerlo para que lo puedan editar en un cuadro grande con los valores de cada una de las posibles liquidaciones de todas las tareas
            NuevaLiquidacion_1.Expediente = oFE;
            cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_1);
            oFE.Liquidaciones.Add(NuevaLiquidacion_1);

            // Liquidacion con respecto a los dias de gabinete
            Modelo_Entidades.Liquidacion NuevaLiquidacion_2 = new Modelo_Entidades.Liquidacion();
            NuevaLiquidacion_2.tarea = "Dias de campo liquidados";
            NuevaLiquidacion_2.cantidad = Convert.ToDecimal(nud_dias_gabinete_FE.Text);
            NuevaLiquidacion_2.importe = 0.3m; // Esta hardcodeado, pero hay que ponerlo para que lo puedan editar en un cuadro grande con los valores de cada una de las posibles liquidaciones de todas las tareas
            NuevaLiquidacion_2.Expediente = oFE;
            cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_2);
            oFE.Liquidaciones.Add(NuevaLiquidacion_2);

            // Liquidación con respecto al trabajo en si
            Modelo_Entidades.Liquidacion NuevaLiquidacion_3 = new Modelo_Entidades.Liquidacion();
            NuevaLiquidacion_3.tarea = "Liquidación básica";
            NuevaLiquidacion_3.cantidad = 1; // Es siempre 1, ya que existe solo 1 liqudiacion
            NuevaLiquidacion_3.importe = (oFE.hps * coeficiente_k * 1290) + (oFE.bocas * 290); // Estan hardcodeados, pero hay que ponerlo para que lo puedan editar en un cuadro grande con los valores de cada una de las posibles liquidaciones de todas las tareas
            NuevaLiquidacion_3.Expediente = oFE;
            cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_3);
            oFE.Liquidaciones.Add(NuevaLiquidacion_3);

            // Calculo la estrategia, y la derivo a la liquidación
            dgv_liquidaciones_FE.DataSource = cExpediente.LiquidarExpediente(oFE);

            // Limpio la grilla
            dgv_liquidaciones_FE.DataSource = null;
            // LLeno el binding con los datos que traigo de las entidades
            dgv_liquidaciones_FE.DataSource = oFE.Liquidaciones;
            dgv_liquidaciones_FE.DataBind();
            #endregion

            int i = 0;
            double suma = 0;
            while (i < dgv_liquidaciones_FE.Rows.Count)
            {
                if (dgv_liquidaciones_FE.Rows[i] != null)
                {
                    suma = Convert.ToDouble(dgv_liquidaciones_FE.Rows[i].Cells[4].Text) + suma;
                }

                i++;
            }

            txt_total_a_liquidar.Text = suma.ToString();
            txt_aportes_al_cie.Text = ((suma) * 0.05).ToString();
            txt_aportes_a_caja.Text = ((suma) * 0.23).ToString();
            txt_total_aportes.Text = (((suma) * 0.05) + ((suma) * 0.23)).ToString();
            InhabilitarTxts();

            #region Agregado del saldo a la cta cte del profesional
            profesional = gv_profesionales.Rows[0].Cells[1].Text;
            oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));

            if (cMovimiento.BuscarMovimientoPorDescExpte(oFE.numero) != null) // quiere decir que está, por lo que se tiene que modificar
            {
                oMovimiento = cMovimiento.BuscarMovimientoPorDescExpte(oFE.numero);

                // Lo 1º es sumar el saldo anterior, para que no se siga restando         
                oCtaCte = oProfesional.CtaCte;
                oCtaCte.saldo = oCtaCte.saldo + Convert.ToDecimal(oMovimiento.importe);

                // Luego, hago los 2 cambios que afectan al movimiento
                oMovimiento.fecha = DateTime.Now;
                oMovimiento.importe = ((suma) * 0.05);
                //oMovimiento.descripcion = "Débito del expediente número " + oFE.numero.ToString();
                //oMovimiento.CtaCte = oProfesional.CtaCte;
                //oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                //oMovimiento.Comprobante = oBoleta;

                cMovimiento.ModificarMovimiento(oMovimiento);
                //oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(((suma) * 0.05));
                cCtaCte.Modificacion(oCtaCte);
            }

            else
            {
                oMovimiento = new Modelo_Entidades.Movimiento();
                oBoleta = new Modelo_Entidades.Boleta();

                oMovimiento.fecha = DateTime.Now;
                oMovimiento.importe = ((suma) * 0.05);
                oMovimiento.descripcion = "Débito del expediente número " + oFE.numero.ToString();
                oMovimiento.CtaCte = oProfesional.CtaCte;
                oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                oMovimiento.Comprobante = oBoleta;

                cMovimiento.Alta(oMovimiento);
                oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                oCtaCte = oProfesional.CtaCte;
                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(((suma) * 0.05));
                cCtaCte.Modificacion(oCtaCte);
            }
            #endregion
        }

        // Liquido los HM
        private void Liquidar_HM()
        {
            // Defino las variables propias del HM
            oHM.dias_de_campo = Convert.ToDecimal(nud_dias_campo_HM.Text);
            oHM.dias_de_gabinete = Convert.ToDecimal(nud_dias_gabinete_HM.Text);

            // Lo 1º que hago es eliminar la liquidación anterior
            foreach (Modelo_Entidades.Liquidacion oLiq in cLiquidacion.ObtenerLiquidaciones())
            {
                if (oHM.numero == oLiq.Expediente.numero)
                {
                    cLiquidacion.EliminarLiquidacion(oLiq);
                }
            }

            #region Liquidación del HM
            // Agrego las liquidaciones para que luego pueda modificar sus valores y luegos ponerlas en el datagridview según sea la solapa

            Modelo_Entidades.Liquidacion NuevaLiquidacion_4 = new Modelo_Entidades.Liquidacion();
            NuevaLiquidacion_4.tarea = "Dias de campo liquidados";
            NuevaLiquidacion_4.cantidad = Convert.ToDecimal(nud_dias_campo_HM.Text);
            NuevaLiquidacion_4.importe = 0.7m; // Esta hardcodeado, pero hay que ponerlo para que lo puedan editar en un cuadro grande con los valores de cada una de las posibles liquidaciones de todas las tareas
            NuevaLiquidacion_4.Expediente = oHM;
            cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_4);
            oHM.Liquidaciones.Add(NuevaLiquidacion_4);

            Modelo_Entidades.Liquidacion NuevaLiquidacion_5 = new Modelo_Entidades.Liquidacion();
            NuevaLiquidacion_5.tarea = "Dias de campo liquidados";
            NuevaLiquidacion_5.cantidad = Convert.ToDecimal(nud_dias_gabinete_HM.Text);
            NuevaLiquidacion_5.importe = 0.3m; // Esta hardcodeado, pero hay que ponerlo para que lo puedan editar en un cuadro grande con los valores de cada una de las posibles liquidaciones de todas las tareas
            NuevaLiquidacion_5.Expediente = oHM;
            cLiquidacion.AgregarLiquidacion(NuevaLiquidacion_5);
            oHM.Liquidaciones.Add(NuevaLiquidacion_5);

            // Calculo la estrategia
            dgv_liquidaciones_HM.DataSource = cExpediente.LiquidarExpediente(oHM);

            // Finalmente muestro la grilla con los datos

            // Limpio la grilla
            dgv_liquidaciones_HM.DataSource = null;
            // LLeno el binding con los datos que traigo de las entidades
            dgv_liquidaciones_HM.DataSource = oHM.Liquidaciones;
            dgv_liquidaciones_HM.DataBind();
            #endregion

            int i_1 = 0;
            double suma_1 = 0;
            while (i_1 < dgv_liquidaciones_HM.Rows.Count)
            {
                if (dgv_liquidaciones_HM.Rows[i_1] != null)
                {
                    suma_1 = Convert.ToDouble(dgv_liquidaciones_HM.Rows[i_1].Cells[4].Text) + suma_1;
                }

                i_1++;
            }

            txt_total_a_liquidar.Text = suma_1.ToString();
            txt_aportes_al_cie.Text = ((suma_1) * 0.05).ToString();
            txt_aportes_a_caja.Text = ((suma_1) * 0.23).ToString();
            txt_total_aportes.Text = (((suma_1) * 0.05) + ((suma_1) * 0.23)).ToString();
            InhabilitarTxts();

            #region Agregado del saldo a la cta cte del profesional
            profesional = gv_profesionales.Rows[0].Cells[1].Text;
            oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));

            if (cMovimiento.BuscarMovimientoPorDescExpte(oHM.numero) != null) // quiere decir que está, por lo que se tiene que modificar
            {
                oMovimiento = cMovimiento.BuscarMovimientoPorDescExpte(oHM.numero);

                // Lo 1º es sumar el saldo anterior, para que no se siga restando   
                oCtaCte = oProfesional.CtaCte;
                oCtaCte.saldo = oCtaCte.saldo + Convert.ToDecimal(oMovimiento.importe);

                // Luego, hago los 2 cambios que afectan al movimiento
                oMovimiento.fecha = DateTime.Now;
                oMovimiento.importe = ((suma_1) * 0.05);
                //oMovimiento.descripcion = "Débito del expediente número " + oHM.numero.ToString();
                //oMovimiento.CtaCte = oProfesional.CtaCte;
                //oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                //oMovimiento.Comprobante = oBoleta;

                cMovimiento.ModificarMovimiento(oMovimiento);
                //oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(((suma_1) * 0.05));
                cCtaCte.Modificacion(oCtaCte);
            }

            else
            {
                oMovimiento = new Modelo_Entidades.Movimiento();
                oBoleta = new Modelo_Entidades.Boleta();

                oMovimiento.fecha = DateTime.Now;
                oMovimiento.importe = ((suma_1) * 0.05);
                oMovimiento.descripcion = "Débito del expediente número " + oHM.numero.ToString();
                oMovimiento.CtaCte = oProfesional.CtaCte;
                oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                oMovimiento.Comprobante = oBoleta;

                cMovimiento.Alta(oMovimiento);
                oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                oCtaCte = oProfesional.CtaCte;
                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(((suma_1) * 0.05));
                cCtaCte.Modificacion(oCtaCte);
            }
            #endregion
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Profesional/Seleccionar profesional.aspx?expediente={0}&modo={1}&tipo_expediente={2}", Server.UrlEncode(expediente), Server.UrlEncode(modo), Server.UrlEncode(tipo)));
        }

        protected void btn_quitar_Click(object sender, EventArgs e)
        {
            string eleccion = lb_tipo_expediente.Text;

            // Finalmente, agrego el comitente al expediente 
            profesional = gv_profesionales.SelectedRow.Cells[1].Text;
            oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));

            switch (eleccion)
            {
                case ("Obra de ingeniería"):
                    oOI.Profesionales.Remove(oProfesional);
                    // Limpio la grilla
                    gv_profesionales.DataSource = null;
                    // Asigno el binding a la grilla
                    gv_profesionales.DataSource = oOI.Profesionales;
                    gv_profesionales.DataBind();
                    break;
                case ("Fuerza electromotriz"):
                    oFE.Profesionales.Remove(oProfesional);
                    // Limpio la grilla
                    gv_profesionales.DataSource = null;
                    // Asigno el binding a la grilla
                    gv_profesionales.DataSource = oFE.Profesionales;
                    gv_profesionales.DataBind();
                    break;
                case ("Honorario Mínimo"):
                    oHM.Profesionales.Remove(oProfesional);
                    // Limpio la grilla
                    gv_profesionales.DataSource = null;
                    // Asigno el binding a la grilla
                    gv_profesionales.DataSource = oHM.Profesionales;
                    gv_profesionales.DataBind();
                    break;
            } 
        }

        // Para guardar el expediente, genero un métedo
        private void GuardarExpte(Modelo_Entidades.Expediente oExpediente)
        {
            // A los profesionales los guardo cuando armo la lista
            if (dtp_fecha_recepcion.Text != "")
            {
                oExpediente.fecha_recepcion = Convert.ToDateTime(dtp_fecha_recepcion.Text);
            }

            if (dtp_fecha_aprobacion.Text != "")
            {
                oExpediente.fecha_aprobacion = Convert.ToDateTime(dtp_fecha_aprobacion.Text);
            }

            if (dtp_fecha_devolución.Text != "")
            {
                oExpediente.fecha_devolucion = Convert.ToDateTime(dtp_fecha_devolución.Text);
            }

            if (chk_aportes.Checked == false)
            {
                oExpediente.tipo_aporte = false;
            }

            else
            {
                oExpediente.tipo_aporte = true;
            }

            if (cmb_comitentes.SelectedItem != null)
            {
                oComitente = cComitente.ObtenerComitentePorDesc(cmb_comitentes.SelectedItem.Text);
                oExpediente.Comitente = oComitente;
            }
            // Al comitente lo guardo cuando lo termino de elegir
            // A las liquidaciones ya las guardo cuando liquido el expediente

            //if (modo == "Alta" && oExpediente.Liquidaciones.Count == 0)
            //{
            //    cExpediente.AgregarExpediente(oExpediente);
            //}

            //else
            //{
                cExpediente.ModificarExpediente(oExpediente);
            //}
        }
    }
}