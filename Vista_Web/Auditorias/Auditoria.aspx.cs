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
    public partial class Auditoria : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        Controladora.cUsuario cUsuario;
        Controladora.cAuditoria cAuditoria;

        Modelo_Entidades.Auditoria_Log oAuditoria;

        string modo;
        string auditoria;

        // Constructor
        public Auditoria()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cAuditoria = Controladora.cAuditoria.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            auditoria = Server.UrlDecode(Request.QueryString["auditoria"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);

            oAuditoria = cAuditoria.ObtenerAuditoria(Convert.ToInt32(auditoria));

            txt_nombreapellido.Enabled = false;
            txt_fecha.Enabled = false;
            txt_accion.Enabled = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargaDatos();
            }
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Auditorias/Gestion de Auditorías.aspx");
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            txt_nombreapellido.Text = oAuditoria.usuario;
            txt_accion.Text = oAuditoria.accion;
            txt_fecha.Text = oAuditoria.fecha.ToString();
        }
    }
}