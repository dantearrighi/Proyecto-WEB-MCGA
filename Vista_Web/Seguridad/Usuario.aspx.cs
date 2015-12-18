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
    public partial class Usuario : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string usuario;
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Grupo oGrupo;
        string grupo;

        // Constructor
        public Usuario()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();

        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            usuario = Server.UrlDecode(Request.QueryString["usuario"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);


            if (usuario == "nuevo")
            {
                oUsuario = new Modelo_Entidades.Usuario();
            }

            else
            {
                oUsuario = cUsuario.ObtenerUsuario(usuario);
            }

            message.Visible = false;

            txt_nuevacontraseña.Enabled = false;
            txt_repetircontraseña.Enabled = false;
            txt_contraseña_actual.Enabled = false;
            btn_cambiarpass.Enabled = false;

            if (modo != "Alta")
            {
                txt_nombreapellido.Text = oUsuario.nombre_apellido;
                txt_email.Text = oUsuario.email;
                txt_nombreusuario.Text = oUsuario.usuario;
                chk_estado.Checked = oUsuario.estado;

                if (modo == "Consulta")
                {
                    txt_nombreapellido.Enabled = false;
                    txt_nombreusuario.Enabled = false;
                    txt_email.Enabled = false;
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                    chk_estado.Enabled = false;
                    chklstbox_grupos.Enabled = false;
                    btn_cambiarpass.Enabled = false;
                }

                else
                {
                    chk_estado.Enabled = true;
                    btn_cambiarpass.Enabled = true;
                }
            }

            else
            {
                txt_nuevacontraseña.Enabled = true;
                txt_repetircontraseña.Enabled = true;
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
            Page.Response.Redirect("~/Seguridad/Gestion de Usuarios.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            if (ValidarObligatorios() == true)
            {
                oUsuario.nombre_apellido = txt_nombreapellido.Text;
                oUsuario.email = txt_email.Text;
                oUsuario.usuario = txt_nombreusuario.Text;
                oUsuario.estado = chk_estado.Checked;
                oUsuario.clave = Controladora.cEncriptacion.Encriptar(txt_nuevacontraseña.Text);

                oUsuario.Grupos.Clear();

                for (int i = 0; i < chklstbox_grupos.Items.Count; i++)
                {
                    grupo = chklstbox_grupos.Items[i].Text;
                    oGrupo = cGrupo.BuscarGrupoPorDesc(grupo);

                    if (chklstbox_grupos.Items[i].Selected == true)
                    {
                        oUsuario.Grupos.Add(oGrupo);
                    }
                }                

                if (modo == "Alta")
                {
                    cUsuario.Alta(oUsuario);
                    Page.Response.Redirect("~/Seguridad/Gestion de Usuarios.aspx");
                }

                else
                {
                    oUsuario.clave = Controladora.cEncriptacion.Encriptar(txt_nuevacontraseña.Text);
                    cUsuario.Modificacion(oUsuario);
                    Page.Response.Redirect("~/Seguridad/Gestion de Usuarios.aspx");
                }                
            }
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(txt_nombreapellido.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el nombre y apellido del usuario";
                return false;
            }

            if (string.IsNullOrEmpty(txt_email.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el e-mail del usuario";
                return false;
            }

            string expresionregular = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            if (!(Regex.IsMatch(this.txt_email.Text, expresionregular))) //si el mail no concuerda con la expresion regular
            {
                message.Visible = true;
                this.txt_email.Focus();
                lb_error.Text = "El E-Mail ingresado tiene un formato incorrecto.";
                return false;
            }

            if (string.IsNullOrEmpty(txt_nombreusuario.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el nombre de usuario";
                return false;
            }

            if (cUsuario.ValidarUsuario(txt_nombreusuario.Text) == false)
            {
                if (oUsuario.usuario != txt_nombreusuario.Text)
                {
                    message.Visible = true;
                    lb_error.Text = "Debe ingresar otro usuario ya que el nombre no se encuentra disponible";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txt_nuevacontraseña.Text) || string.IsNullOrEmpty(txt_repetircontraseña.Text) || string.IsNullOrEmpty(txt_nuevacontraseña.Text))
            {
                if (modo != "Alta" && txt_contraseña_actual.Enabled == true)
                {
                    if (string.IsNullOrEmpty(txt_nuevacontraseña.Text) && string.IsNullOrEmpty(txt_repetircontraseña.Text) && string.IsNullOrEmpty(txt_nuevacontraseña.Text))
                    {
                        message.Visible = true;
                        lb_error.Text = "Debe ingresar una contraseña, ya que o no las ha ingresado, o no coinciden";
                        return false;
                    }

                    else if (Controladora.cEncriptacion.Encriptar(txt_contraseña_actual.Text) != oUsuario.clave || string.IsNullOrEmpty(txt_contraseña_actual.Text))
                    {
                        message.Visible = true;
                        lb_error.Text = "La contraseña actual es incorrecta, por favor introduscula nuevamente";
                        return false;
                    }
                }
            }

            if (modo != "Alta" && txt_contraseña_actual.Enabled == true)
            {
                if (Controladora.cEncriptacion.Encriptar(txt_contraseña_actual.Text) != oUsuario.clave || string.IsNullOrEmpty(txt_contraseña_actual.Text) || txt_nuevacontraseña.Text != txt_repetircontraseña.Text)
                {
                    message.Visible = true;
                    lb_error.Text = "La contraseña actual es incorrecta o las claves no coinciden, por favor introdusca los datos nuevamente";
                    return false;
                }
            }

            if (modo == "Alta")
            {
                if (string.IsNullOrEmpty(txt_nuevacontraseña.Text) || string.IsNullOrEmpty(txt_repetircontraseña.Text) || txt_nuevacontraseña.Text != txt_repetircontraseña.Text)
                {
                    message.Visible = true;
                    lb_error.Text = "No ha introducido una contraseña o las claves no coinciden, por favor introdusca los datos nuevamente";
                    return false;
                }
            }

            if (chklstbox_grupos.SelectedIndex == -1)
            {
                message.Visible = true;
                lb_error.Text = "Debe elegir al menos un grupo para el usuario";
                return false;
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            chklstbox_grupos.DataSource = null;
            chklstbox_grupos.DataSource = cGrupo.ObtenerGrupos();
            chklstbox_grupos.DataBind();

            if (modo != "Alta")
            {
                for (int i = 0; i < chklstbox_grupos.Items.Count; i++)
                {
                    grupo = chklstbox_grupos.Items[i].Text;
                    oGrupo = cGrupo.BuscarGrupoPorDesc(grupo);
                    foreach (Modelo_Entidades.Grupo miGrupo in oUsuario.Grupos.ToList())
                    {
                        if (oGrupo.id == miGrupo.id)
                        {
                            chklstbox_grupos.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        protected void btn_cambiarpass_Click(object sender, EventArgs e)
        {
            txt_nuevacontraseña.Enabled = true;
            txt_repetircontraseña.Enabled = true;
            txt_contraseña_actual.Enabled = true;
            btn_cambiarpass.Enabled = false;
        }
    }
}