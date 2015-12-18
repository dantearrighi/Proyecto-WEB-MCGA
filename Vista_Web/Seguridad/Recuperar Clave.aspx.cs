using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web
{
    public partial class Recuperar_Clave : System.Web.UI.Page
    {
        Modelo_Entidades.Usuario oUsuario;
        Controladora.cUsuario cUsuario;

        string usuario;

         // Constructor
        public Recuperar_Clave()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            usuario = Server.UrlDecode(Request.QueryString["usuario"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Valido los datos
        public bool ValidarDatos()
        {
            oUsuario = cUsuario.ObtenerUsuario(this.txt_nombreusuario.Text);

            if (string.IsNullOrEmpty(this.txt_email.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el email del usuario";
                return false;
            }

            if (this.txt_email.Text != oUsuario.email)
            {
                message.Visible = true;
                lb_error.Text = "El e-mail no pertenece al usuario introducido";
                return false;
            }

            string expresionregular = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            if (!(Regex.IsMatch(this.txt_email.Text, expresionregular))) //si el mail no concuerda con la expresion regular
            {
                message.Visible = true;
                lb_error.Text = "El E-Mail ingresado tiene un formato incorrecto.";
                return false;
            }
            return true;
        }

        protected void btn_recuperarclave_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                oUsuario = cUsuario.ObtenerUsuario(this.txt_nombreusuario.Text);
                if (oUsuario != null)
                {
                    if (oUsuario.estado != false)
                    {
                        try
                        {
                            cUsuario.ResetearClave(oUsuario, txt_email.Text);
                            message.Visible = true;
                            lb_error.Text = "Contraseña reseteada con éxito. Revise su correo para volver a ingresar";
                        }

                        catch (System.Data.EntitySqlException ex)
                        {
                            message.Visible = true;
                            lb_error.Text = "No se ha podido resetear la contraseña: " + ex.InnerException.Message + ".";
                        }
                    }
                    else
                    {
                        message.Visible = true;
                        lb_error.Text = "Datos Inválidos - Usuario Inactivo";
                    }
                }
                else
                {
                    message.Visible = true;
                    lb_error.Text = "Datos Inválidos - Usuario Inexistente";
                }
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("../Seguridad/Login.aspx");
        }
    }
}