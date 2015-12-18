using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Vista_Web
{
    public partial class Login : System.Web.UI.Page
    {
        // Declaro las variables a utilizar en el formualario
        Controladora.cUsuario cUsuario;
        Modelo_Entidades.Usuario oUsuario;
        Controladora.cGrupo cGrupo;



        public Modelo_Entidades.Usuario UsuarioLogin
        {
            get { return oUsuario; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //nulificar la sesión de usuario
            Session["sUsuario"] = null;
            // Creo una controladora de usuario para trabajarla durante el formulario
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();

            message.Visible = false;
        }

        // Valido los datos obligatorios
        private bool ValidarObligatorios()
        {
            if (txt_nombreUsuario.Text == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un usuario";
                return false;
            }

            else if (txt_contraseña.Text == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una contraseña";
                return false;
            }

            else
            {
                return true;
            }
        }

        protected void btn_ingresa_Click(object sender, EventArgs e)
        {
            // Ingreso al sistema - Controladora.cEncriptacion.Encriptar(
            ValidarObligatorios();

            try
            {

                oUsuario = cUsuario.Login(txt_nombreUsuario.Text, txt_contraseña.Text);

                Session["sUsuario"] = oUsuario;
                Page.Response.Redirect("~/Principal.aspx");
            }

            catch (Exception Exc)
            {
                message.Visible = true;
                lb_error.Text = Exc.Message;
            }

        }
    }
}