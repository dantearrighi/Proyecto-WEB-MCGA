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
    public partial class Titulo : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string modo_plan;
        Controladora.cUsuario cUsuario;
        Controladora.cTitulo cTitulo;
        Controladora.cUniversidad cUniversidad;
        Controladora.cJurisdiccion cJurisdiccion;
        Controladora.cModalidad cModalidad;
        Controladora.cNivel cNivel;
        Controladora.cEspecialidad cEspecialidad;
        Controladora.cPlan cPlan;
        Controladora.cMatricula cMatricula;
        Controladora.cLegajo_Academico cLegajo_Academico;

        Modelo_Entidades.Titulo oTitulo;
        Modelo_Entidades.Plan oPlan;
        Modelo_Entidades.Legajo_Academico oLegajo_Academico;
        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Universidad oUniversidad;
        Modelo_Entidades.Jurisdiccion oJurisdiccion;
        Modelo_Entidades.Modalidad oModalidad;
        Modelo_Entidades.Nivel oNivel;
        Modelo_Entidades.Especialidad oEspecialdad;
        
        List<Modelo_Entidades.Formulario> lFormularios;
        List<Modelo_Entidades.Permiso> lPermisos;
        List<Modelo_Entidades.Universidad> lUniversidades;
        List<Modelo_Entidades.Plan> lPlanes;
        List<Modelo_Entidades.Jurisdiccion> lJurisdicciones;
        List<Modelo_Entidades.Modalidad> lModalidades;
        List<Modelo_Entidades.Nivel> lNiveles;
        List<Modelo_Entidades.Especialidad> lEspecialidades;

        string titulo;
        string usuario;
        string plan;
        string universidad;
        string jurisdiccion;
        string modalidad;
        string nivel;
        string especialidad;

        // Constructor
        public Titulo()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cTitulo = Controladora.cTitulo.ObtenerInstancia();
            cUniversidad = Controladora.cUniversidad.ObtenerInstancia();
            cJurisdiccion = Controladora.cJurisdiccion.ObtenerInstancia();
            cModalidad = Controladora.cModalidad.ObtenerInstancia();
            cNivel = Controladora.cNivel.ObtenerInstancia();
            cEspecialidad = Controladora.cEspecialidad.ObtenerInstancia();
            cPlan = Controladora.cPlan.ObtenerInstancia();
            cMatricula = Controladora.cMatricula.ObtenerInstancia();
            cLegajo_Academico = Controladora.cLegajo_Academico.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            titulo = Server.UrlDecode(Request.QueryString["titulo"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);

            if (titulo == "nuevo")
            {
                oTitulo = new Modelo_Entidades.Titulo();
            }
            else
            {
                oTitulo = cTitulo.ObtenerTituloPorID(Convert.ToInt32(titulo));
                this.ArmaFormulario();
            }

            message.Visible = false;

            cmb_universidad.Enabled = true;
            txt_titulo.Enabled = true;
            txt_leyaprobacion.Enabled = true;
            txt_coneau.Enabled = true;
            cmb_jurisdiccion.Enabled = true;
            cmb_modalidad.Enabled = true;
            cmb_nivel.Enabled = true;
            txt_terminovalidez.Enabled = true;
            txt_aprobacioncie.Enabled = true;

            btn_agregar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_modificar.Enabled = true;
            btn_ver_detalle.Enabled = true;
            btn_guardar.Enabled = true;

            if (modo != "Alta")
            {
                txt_titulo.Text = oTitulo.descripcion;

                if (modo == "Consulta")
                {
                    cmb_universidad.Enabled = false;
                    txt_titulo.Enabled = false;
                    txt_leyaprobacion.Enabled = false;
                    txt_coneau.Enabled = false;
                    cmb_jurisdiccion.Enabled = false;
                    cmb_modalidad.Enabled = false;
                    cmb_nivel.Enabled = false;
                    txt_terminovalidez.Enabled = false;
                    txt_aprobacioncie.Enabled = false;

                    btn_agregar.Enabled = false;
                    btn_eliminar.Enabled = false;
                    btn_modificar.Enabled = false;
                    btn_ver_detalle.Enabled = false;
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                }
            }

            else
            {
                btn_agregar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_modificar.Enabled = false;
                btn_ver_detalle.Enabled = false;

                mje_plan.Visible = true;
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
            Page.Response.Redirect("~/Titulos/Gestion de Titulos.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios() == true)
            {
                try
                {
                    //Datos del titulo
                    universidad = cmb_universidad.SelectedValue.ToString();
                    oUniversidad = cUniversidad.ObtenerUnivPorDesc(universidad);
                    oTitulo.Universidad = oUniversidad;

                    oTitulo.descripcion = txt_titulo.Text;
                    oTitulo.ley_aprobacion = txt_leyaprobacion.Text;
                    oTitulo.res_coneau = txt_coneau.Text;

                    jurisdiccion = cmb_jurisdiccion.SelectedValue.ToString();
                    oJurisdiccion = cJurisdiccion.ObtenerJurisdiccionPorDesc(jurisdiccion);
                    oTitulo.Jurisdiccion = oJurisdiccion;

                    modalidad = cmb_modalidad.SelectedValue.ToString();
                    oModalidad = cModalidad.ObtenerModalidadPorDesc(modalidad);
                    oTitulo.Modalidad = oModalidad;

                    nivel = cmb_nivel.SelectedValue.ToString();
                    oNivel = cNivel.ObtenerNivelPorDesc(nivel);
                    oTitulo.Nivel = oNivel;

                    oTitulo.validez = txt_terminovalidez.Text;
                    oTitulo.aprobacion_cie = txt_aprobacioncie.Text;

                    especialidad = cmb_especialidades.SelectedValue.ToString();
                    oEspecialdad = cEspecialidad.ObtenerEspecialidadPorDesc(especialidad);
                    oTitulo.Especialidad = oEspecialdad;

                    if (modo == "Alta")
                    {
                        message.Visible = true;
                        cTitulo.AgregarTitulo(oTitulo);
                        lb_error.Text = "El título se ha agregado correctamente";
                    }

                    else
                    {
                        message.Visible = true;
                        cTitulo.ModificarTitulo(oTitulo);
                        lb_error.Text = "El título se ha modificado correctamente";
                    }
                    
                    Page.Response.Redirect("~/Titulos/Gestion de Titulos.aspx");
                }

                catch (Exception Exc)
                {
                    message.Visible = true;
                    lb_error.Text = Exc.ToString();
                }
            }

            
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (cmb_universidad.SelectedItem == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una universidad para el título";
                return false;
            }

            if (string.IsNullOrEmpty(txt_titulo.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una descipción para el título";
                return false;
            }

            if (string.IsNullOrEmpty(txt_leyaprobacion.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una ley de aprobación para el título";
                return false;
            }

            if (string.IsNullOrEmpty(txt_coneau.Text))
            {
                message.Visible = true;
                lb_error.Text = "El título se cargará sin una resolucuión por parte de la CONEAU";
            }

            if (cmb_jurisdiccion.SelectedItem == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una jurisdicción para el título";
                return false;
            }

            if (cmb_modalidad.SelectedItem == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una modalidad para el título";
                return false;
            }

            if (cmb_nivel.SelectedItem == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un nivel para el título";
                return false;
            }

            if (string.IsNullOrEmpty(txt_terminovalidez.Text))
            {
                message.Visible = true;
                lb_error.Text = "El título se cargará sin un término de validez";
            }

            if (string.IsNullOrEmpty(txt_aprobacioncie.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una instancia en la que el título se aprobó en el Colegio";
                return false;
            }

            if (cmb_especialidades.SelectedItem == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una especialidad para el título";
                return false;
            }

            if (cTitulo.ValidarTitulo(txt_titulo.Text) == false)
            {
                if (oTitulo.descripcion != txt_titulo.Text)
                {
                    message.Visible = true;
                    lb_error.Text = "Ya existe un título como el ingresado";
                    return false;
                }
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            lPlanes = cLegajo_Academico.BuscarPlanesPorTit(oTitulo);
            dgv_planes.DataSource = lPlanes;
            dgv_planes.DataBind();

            lUniversidades = cUniversidad.ObtenerUniversidades();
            cmb_universidad.DataSource = lUniversidades;
            cmb_universidad.DataBind();

            lJurisdicciones = cJurisdiccion.ObtenerJurisdicciones();
            cmb_jurisdiccion.DataSource = lJurisdicciones;
            cmb_jurisdiccion.DataBind();

            lModalidades = cModalidad.ObtenerModalidades();
            cmb_modalidad.DataSource = lModalidades;
            cmb_modalidad.DataBind();

            lNiveles = cNivel.ObtenerNiveles();
            cmb_nivel.DataSource = lNiveles;
            cmb_nivel.DataBind();

            lEspecialidades = cEspecialidad.ObtenerEspecialidades();
            cmb_especialidades.DataSource = lEspecialidades;
            cmb_especialidades.DataBind();
        }

        private void ArmaFormulario()
        {
            cmb_universidad.SelectedValue = oTitulo.Universidad.descripcion;
            txt_titulo.Text = oTitulo.descripcion;
            txt_leyaprobacion.Text = oTitulo.ley_aprobacion;
            txt_coneau.Text = oTitulo.res_coneau;
            cmb_jurisdiccion.SelectedValue = oTitulo.Jurisdiccion.descripcion;
            cmb_modalidad.SelectedValue = oTitulo.Modalidad.descripcion;
            cmb_nivel.SelectedValue = oTitulo.Nivel.descripcion;
            txt_terminovalidez.Text = oTitulo.validez;
            txt_aprobacioncie.Text = oTitulo.aprobacion_cie;

            cmb_especialidades.SelectedValue = oTitulo.Especialidad.descripcion;
        }

        protected void cmb_universidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmb_jurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmb_modalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmb_nivel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmb_especialidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgv_planes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = "Plan";
            e.Row.Cells[3].Text = "Ordenanza";
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            message.Visible = true;

            if (titulo == "nuevo")
            {
                lb_error.Text = "Antes de cargarle un plan al título, debe cargarlo";
            }

            else
            {
                plan = "nuevo";
                modo_plan = "Alta";

                Response.Redirect(String.Format("~/Titulos/Planes Titulo.aspx?plan={0}&modo={1}&titulo={2}&modo_plan={3}", Server.UrlEncode(plan), Server.UrlEncode(modo), Server.UrlEncode(titulo), Server.UrlEncode(modo_plan)));
            }
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            message.Visible = true;

            if (dgv_planes.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una plan";
            }

            else
            {
                plan = dgv_planes.SelectedRow.Cells[2].Text;
                modo_plan = "Modifica";

                Response.Redirect(String.Format("~/Titulos/Planes Titulo.aspx?plan={0}&modo={1}&titulo={2}&modo_plan={3}", Server.UrlEncode(plan), Server.UrlEncode(modo), Server.UrlEncode(oTitulo.id.ToString()), Server.UrlEncode(modo_plan)));

            }
        }

        protected void btn_ver_detalle_Click(object sender, EventArgs e)
        {
            message.Visible = true;

            if (dgv_planes.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una plan";
            }

            else
            {
                plan = dgv_planes.SelectedRow.Cells[2].Text;
                modo = "Consulta";

                Response.Redirect(String.Format("~/Titulos/Planes Titulo.aspx?plan={0}&modo={1}&titulo={2}&modo_plan={3}", Server.UrlEncode(plan), Server.UrlEncode(modo), Server.UrlEncode(titulo), Server.UrlEncode(modo_plan)));

            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            plan = dgv_planes.SelectedRow.Cells[2].Text;
            oPlan = cPlan.ObtenerPlanPorDesc(plan);
            oTitulo = cTitulo.ObtenerTituloPorDesc(txt_titulo.Text);
            oLegajo_Academico = cLegajo_Academico.BuscarLegajoPorTityPlan(oTitulo, oPlan);

            if (dgv_planes.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un plan";
            }

            else
            {
                if (oLegajo_Academico.Matriculas.Count != 0)
                {
                    message.Visible = true;
                    lb_error.Text =  "No puede eliminar al plan ya que existen profesionales asociados a el.";
                }

                else
                {
                    message.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                }

                //if (cPlan.ValidarPLanesTitulo(oPlan) == false)
                //{
                //    message.Visible = true;
                //    lb_error.Text = "Para eliminar el plan, primero debe desasociar a todos los títulos que lo involucran";
                //    return;
                //}

                
            }
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            plan = dgv_planes.SelectedRow.Cells[2].Text;
            oPlan = cPlan.ObtenerPlanPorDesc(plan);

            oTitulo = cTitulo.ObtenerTituloPorDesc(txt_titulo.Text);
            oLegajo_Academico = cLegajo_Academico.BuscarLegajoPorTityPlan(oTitulo, oPlan);
            cLegajo_Academico.BajaLegajo(oLegajo_Academico);

            cPlan.EliminarPlan(oPlan);
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
            message.Visible = true;

            lb_error.Text = "El plan y el título fueron eliminados de su respectivo legajo";
            ArmaFormulario();
        }
    }
}