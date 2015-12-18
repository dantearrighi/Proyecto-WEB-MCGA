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
    public partial class Tarea : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string tarea;
        Controladora.cTarea cTarea;
        Controladora.cGrupo cGrupo;
        Modelo_Entidades.Tarea oTarea;
        Modelo_Entidades.Grupo oGrupo;
        string grupo;

        // Constructor
        public Tarea()
        {
            cTarea = Controladora.cTarea.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();

        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            tarea = Server.UrlDecode(Request.QueryString["Tarea"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);


            if (tarea == "nuevo")
            {
                oTarea = new Modelo_Entidades.Tarea();
            }

            else
            {
                oTarea = cTarea.ObtenerTarea(Convert.ToInt32(tarea));
            }

            message.Visible = false;

            if (modo != "Alta")
            {
                txt_nombreapellido.Text = oTarea.descripcion;

                if (modo == "Consulta")
                {
                    txt_nombreapellido.Enabled = false;

                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Expedientes/Gestion de Tareas.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            if (ValidarObligatorios() == true)
            {
                oTarea.descripcion = txt_nombreapellido.Text;

                if (modo == "Alta")
                {
                    cTarea.AgregarTarea(oTarea);

                    Page.Response.Redirect("~/Expedientes/Gestion de Tareas.aspx");
                }

                else
                {
                    cTarea.ModificarTarea(oTarea);
                    
                    Page.Response.Redirect("~/Expedientes/Gestion de Tareas.aspx");
                }                
            }
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (cTarea.ValidarTarea(txt_nombreapellido.Text) == false)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una descripción para la Tarea, dado que existe una Tarea con el msimo nombre";
                return false;
            }

            if (string.IsNullOrEmpty(txt_nombreapellido.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una descipción para la Tarea";
                return false;
            }

            return true;
        }
    }
}