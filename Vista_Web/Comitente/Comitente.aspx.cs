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
    public partial class Comitente : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string comitente;
        Controladora.cComitente cComitente;
        Controladora.cGrupo cGrupo;
        Modelo_Entidades.Comitente oComitente;
        Modelo_Entidades.Grupo oGrupo;
        string grupo;

        // Constructor
        public Comitente()
        {
            cComitente = Controladora.cComitente.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();

        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            comitente = Server.UrlDecode(Request.QueryString["comitente"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);


            if (comitente == "nuevo")
            {
                oComitente = new Modelo_Entidades.Comitente();
            }

            else
            {
                oComitente = cComitente.ObtenerComitente(Convert.ToInt32(comitente));
            }

            message.Visible = false;

            if (modo != "Alta")
            {
                txt_nombreapellido.Text = oComitente.razon_social;

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
            Page.Response.Redirect("~/Expedientes/Gestion de Comitentes.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            if (ValidarObligatorios() == true)
            {
                oComitente.razon_social = txt_nombreapellido.Text;

                if (modo == "Alta")
                {
                    cComitente.AgregarComitente(oComitente);

                    Page.Response.Redirect("~/Expedientes/Gestion de Comitentes.aspx");
                }

                else
                {
                    cComitente.ModificarComitente(oComitente);
                    
                    Page.Response.Redirect("~/Expedientes/Gestion de Comitentes.aspx");
                }                
            }
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (cComitente.ValidarComitente(txt_nombreapellido.Text) == false)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una razón social para el comitente, dado que existe un comitente con el msimo nombre";
                return false;
            }

            if (string.IsNullOrEmpty(txt_nombreapellido.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una descipción para el comitente";
                return false;
            }

            return true;
        }
    }
}