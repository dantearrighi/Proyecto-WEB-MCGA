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
    public partial class Planes_Titulo : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string modo_plan;
        string titulo;
        string usuario;
        string plan;

        Controladora.cPlan cPlan;
        Controladora.cLegajo_Academico cLegajo_Academico;
        Controladora.cTitulo cTitulo;

        Modelo_Entidades.Plan oPlan;
        Modelo_Entidades.Legajo_Academico oLegajo_Academico;
        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Titulo oTitulo;

        List<Modelo_Entidades.Plan> lPlanes;

        // Constructor
        public Planes_Titulo()
        {
            cPlan = Controladora.cPlan.ObtenerInstancia();
            cLegajo_Academico = Controladora.cLegajo_Academico.ObtenerInstancia();
            cTitulo = Controladora.cTitulo.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            plan = Server.UrlDecode(Request.QueryString["plan"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);
            titulo = Server.UrlDecode(Request.QueryString["titulo"]);
            modo_plan = Server.UrlDecode(Request.QueryString["modo_plan"]);

            oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
            usuario = oUsuario.usuario;

            if (plan == "nuevo")
            {
                oPlan = new Modelo_Entidades.Plan();
            }
            else
            {
                oPlan = cPlan.ObtenerPlanPorDesc(plan);
            }

            oTitulo = cTitulo.ObtenerTituloPorID(Convert.ToInt32(titulo));

            message.Visible = false;

            if (modo_plan != "Alta")
            {
                if (modo_plan == "Consulta")
                {
                    txt_año.Enabled = false;
                    txt_ordenanzaconsejo.Enabled = false;
                    txt_plan_descripcion.Enabled = false;
                    txt_incumbencia.Enabled = false;
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
            Response.Redirect(String.Format("~/Titulos/Titulo.aspx?plan={0}&modo={1}&titulo={2}", Server.UrlEncode(plan), Server.UrlEncode(modo), Server.UrlEncode(titulo)));
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios())
            {
                try
                {
                    oPlan.año = txt_año.Text;
                    oPlan.ordenanza = txt_ordenanzaconsejo.Text;
                    oPlan.descripcion = txt_plan_descripcion.Text;
                    oPlan.incumbencia = txt_incumbencia.Text;

                    if (modo_plan == "Alta")
                    {
                        cPlan.AgregarPlan(oPlan);

                        // Creo el legajo 
                        oLegajo_Academico = new Modelo_Entidades.Legajo_Academico();
                        oLegajo_Academico.Plan = oPlan;
                        oLegajo_Academico.Titulo = oTitulo;

                        cLegajo_Academico.AgregarLegajo(oLegajo_Academico);

                        oTitulo.Legajos_Academicos.Add(oLegajo_Academico);
                    }

                    else
                    {
                        cPlan.ModificarPlan(oPlan);

                        // Agrego el legajo academico
                        oTitulo.Legajos_Academicos.Equals(oLegajo_Academico);
                        oPlan.Legajos_Academicos.Equals(oLegajo_Academico);

                        oLegajo_Academico = cLegajo_Academico.BuscarLegajoPorTityPlan(oTitulo, oPlan);
                        // Le asigno al legajo el titulo y el plan
                        oLegajo_Academico.Titulo = oTitulo;
                        oLegajo_Academico.Plan = oPlan;

                        cLegajo_Academico.Modificacion(oLegajo_Academico);
                    }
                    
                    Response.Redirect(String.Format("~/Titulos/Titulo.aspx?plan={0}&modo={1}&titulo={2}", Server.UrlEncode(plan), Server.UrlEncode(modo), Server.UrlEncode(titulo)));
                }

                catch (Exception Exc)
                {
                    message.Visible = true;
                    lb_error.Text = Exc.Message.ToString();
                }
            }
            
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (txt_año.Text == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un año para el plan";
                return false;
            }

            if (txt_ordenanzaconsejo.Text == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una ordenanza para el título";
                return false;
            }

            if (txt_plan_descripcion.Text == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una descripción para el plan";
                return false;
            }

            if (txt_incumbencia.Text == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una incumbencia para el plan del título";
                return false;
            }

            if (cLegajo_Academico.ValidarPlandelTitulo(txt_año.Text) == false)
            {
                if (oPlan.año != txt_año.Text)
                {
                    message.Visible = true;
                    lb_error.Text = "Ya existe un plan como el ingresado";
                    return false;
                }
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            txt_año.Text = oPlan.año;
            txt_ordenanzaconsejo.Text = oPlan.ordenanza;
            txt_plan_descripcion.Text = oPlan.descripcion;
            txt_incumbencia.Text = oPlan.incumbencia;
        }

    }
}