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
    public partial class Perfil : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Controladora.cPermiso cPermiso;
        Controladora.cFormulario cFormulario;
        Controladora.cPerfil cPerfil;

        //Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Grupo oGrupo;
        Modelo_Entidades.Permiso oPermiso;
        Modelo_Entidades.Formulario oFormulario;
        Modelo_Entidades.Perfil oPerfil;

        List<Modelo_Entidades.Grupo> lGrupos;
        List<Modelo_Entidades.Permiso> lPermisos;
        List<Modelo_Entidades.Formulario> lFormularios;

        string grupo;
        string permiso;
        string formulario;
        string perfil;

        // Constructor
        public Perfil()
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
            perfil = Server.UrlDecode(Request.QueryString["perfil"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);

            if (perfil == "nuevo")
            {
                oPerfil = new Modelo_Entidades.Perfil();
            }
            else
            {
                oPerfil = cPerfil.ObtenerPerfil(Convert.ToInt32(perfil));
            }

            message.Visible = false;

            cmb_grupos.Enabled = true;
            cmb_permisos.Enabled = true;
            cmb_formularios.Enabled = true;

            if (modo != "Alta")
            {
                cmb_grupos.SelectedValue = oPerfil.Grupo.ToString();
                cmb_permisos.SelectedValue = oPerfil.Permiso.ToString();
                cmb_formularios.SelectedValue = oPerfil.Formulario.ToString();

                if (modo == "Consulta")
                {
                    cmb_grupos.Enabled = false;
                    cmb_permisos.Enabled = false;
                    cmb_formularios.Enabled = false;
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
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
            Page.Response.Redirect("~/Seguridad/Gestion de Perfiles.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios() == true)
            {
                oPerfil.Grupo = oGrupo;
                oPerfil.Formulario = oFormulario;
                oPerfil.Permiso = oPermiso;

                cPerfil.AltaPerfil(oPerfil);
                Page.Response.Redirect("~/Seguridad/Gestion de Perfiles.aspx");
            }
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (cmb_grupos.SelectedValue == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un grupo";
                return false;
            }

            if (cmb_formularios.SelectedValue == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un formulario";
                return false;
            }

            if (cmb_permisos.SelectedValue == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un permiso";
                return false;
            }

            grupo = cmb_grupos.SelectedValue.ToString();
            oGrupo = cGrupo.BuscarGrupoPorDesc(grupo);

            permiso = cmb_permisos.SelectedValue.ToString();
            oPermiso = cPermiso.BuscarPermisoPorDesc(permiso);

            formulario = cmb_formularios.SelectedValue.ToString();
            oFormulario = cFormulario.BuscarFromularioPorDesc(formulario);

            if (cPerfil.ValidarPerfil(oGrupo, oFormulario, oPermiso) == false)
            {
                message.Visible = true;
                lb_error.Text = "El perfil ya existe, ingrese otros parámetros";
                return false;
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            lGrupos = cGrupo.ObtenerGrupos();
            cmb_grupos.DataSource = lGrupos;
            cmb_grupos.DataBind();

            lPermisos = cPermiso.ObtenerPermisos();
            cmb_permisos.DataSource = lPermisos;
            cmb_permisos.DataBind();

            lFormularios = cFormulario.ObtenerFormularios();
            cmb_formularios.DataSource = lFormularios;
            cmb_formularios.DataBind();
        }
    }
}