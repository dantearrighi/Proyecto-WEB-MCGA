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
    public partial class Grupo : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Controladora.cPermiso cPermiso;
        Controladora.cFormulario cFormulario;
        Controladora.cPerfil cPerfil;

        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Grupo oGrupo;
        Modelo_Entidades.Permiso oPermiso;
        Modelo_Entidades.Formulario oFormulario;
        List<Modelo_Entidades.Formulario> lFormularios;
        List<Modelo_Entidades.Permiso> lPermisos;

        string grupo;
        string usuario;

        // Constructor
        public Grupo()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cPermiso = Controladora.cPermiso.ObtenerInstancia();
            cFormulario = Controladora.cFormulario.ObtenerInstancia();
            cPerfil = Controladora.cPerfil.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            grupo = Server.UrlDecode(Request.QueryString["grupo"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);

            if (grupo == "nuevo")
            {
                oGrupo = new Modelo_Entidades.Grupo();
            }
            else
            {
                oGrupo = cGrupo.BuscarGrupoPorDesc(grupo);
            }

            message.Visible = false;

            txt_descripcion.Enabled = true;
            chklstbox_persmisos.Enabled = false;
            chklstbox_usuarios.Enabled = true;

            if (modo != "Alta")
            {
                txt_descripcion.Text = oGrupo.descripcion;

                if (modo == "Consulta")
                {
                    txt_descripcion.Enabled = false;
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                    chklstbox_persmisos.Enabled = false;
                    chklstbox_usuarios.Enabled = false;
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
            Page.Response.Redirect("~/Seguridad/Gestion de Grupos.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios() == true)
            {
                oGrupo.descripcion = txt_descripcion.Text;

                oGrupo.Usuarios.Clear();
                for (int i = 0; i < chklstbox_usuarios.Items.Count; i++)
                {
                    usuario = chklstbox_usuarios.Items[i].Text;
                    oUsuario = cUsuario.ObtenerUsuarioPorNyA(usuario);

                    if (chklstbox_usuarios.Items[i].Selected == true)
                    {
                        oGrupo.Usuarios.Add(oUsuario);
                    }
                }

                if (modo == "Alta")
                {
                    cGrupo.AgregarGrupo(oGrupo);
                }

                else
                {
                    cGrupo.ModificarGrupo(oGrupo);
                }
            }

            Page.Response.Redirect("~/Seguridad/Gestion de Grupos.aspx");
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (cGrupo.ValidarGrupo(txt_descripcion.Text) == false)
            {
                if (oGrupo.descripcion != txt_descripcion.Text)
                {
                    lb_error.Text = "Debe ingresar una descipción para el grupo ya que existe otro grupo con el mismo nombre";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txt_descripcion.Text))
            {
                lb_error.Text = "Debe ingresar una descipción para el grupo ya sea o por que no la ha ingresado o por que ya existe otro grupo con el nombre ingresado";
                return false;
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            string usuario;

            chklstbox_usuarios.DataSource = null;
            chklstbox_usuarios.DataSource = cUsuario.ObtenerUsuarios();
            chklstbox_usuarios.DataBind();

            chklstbox_persmisos.DataSource = null;
            chklstbox_persmisos.DataSource = cPermiso.ObtenerPermisos();
            chklstbox_persmisos.DataBind();

            lFormularios = cFormulario.ObtenerFormularios();
            cmb_formularios.DataSource = lFormularios;
            cmb_formularios.DataBind();

            if (modo != "Alta")
            {
                for (int i = 0; i < chklstbox_usuarios.Items.Count; i++)
                {
                    usuario = chklstbox_usuarios.Items[i].Text;
                    oUsuario = cUsuario.ObtenerUsuarioPorNyA(usuario);

                    foreach (Modelo_Entidades.Usuario miUsuario in oGrupo.Usuarios.ToList())
                    {
                        if (oUsuario.id == miUsuario.id)
                        {
                            chklstbox_usuarios.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        protected void cmb_formularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string formulario;
            formulario = cmb_formularios.SelectedValue.ToString();
            oFormulario = cFormulario.BuscarFromularioPorDesc(formulario);

            string permiso;

            for (int i = 0; i < chklstbox_persmisos.Items.Count; i++)
            {
                permiso = chklstbox_persmisos.Items[i].Text;
                oPermiso = cPermiso.BuscarPermisoPorDesc(permiso);

                lPermisos = cPerfil.ObtenerPermisos(oGrupo.id, oFormulario.descripcion);

                foreach (Modelo_Entidades.Permiso miPermiso in lPermisos)
                {
                    if (miPermiso.id == oPermiso.id)
                    {
                        chklstbox_persmisos.Items[i].Selected = true;
                    }
                }
            }
        }
    }
}