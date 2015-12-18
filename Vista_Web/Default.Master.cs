using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Vista_Web
{
    public partial class Default : System.Web.UI.MasterPage
    {
        //Declaracion de varibles a utilizar en el formulario
        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Auditoria_Log oAuditoria;
        Controladora.cModulo cModulo;
        Controladora.cPerfil cPerfil;
        Controladora.cUsuario cUsuario;
        Controladora.cAuditoria cAuditoria;

        List<Modelo_Entidades.Modulo> lModulos;
        List<Modelo_Entidades.Formulario> lFormularios;

        protected void Page_Init(object sender, EventArgs e)
        {
            //Compruebo si el usuario se ha logueado viendo si existe una sesión
            if (Session["sUsuario"] == null)
            {
                Response.Redirect("~/Seguridad/Login.aspx");
            }

            
            //Instancio a las controladoras del modulo
            cModulo = Controladora.cModulo.ObtenerInstancia();
            cPerfil = Controladora.cPerfil.ObtenerInstancia();
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cAuditoria = Controladora.cAuditoria.ObtenerInstancia();

            oUsuario = (Modelo_Entidades.Usuario)Session["sUsuario"];
            oAuditoria = new Modelo_Entidades.Auditoria_Log();
            lModulos = new List<Modelo_Entidades.Modulo>();
            lFormularios = new List<Modelo_Entidades.Formulario>();
            oAuditoria.usuario = oUsuario.nombre_apellido;
            oAuditoria.fecha = DateTime.Now;
            oAuditoria.accion = "Ingreso al Sistema";
            cAuditoria.AuditarLogUsuario(oAuditoria);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user_menu.InnerText = oUsuario.nombre_apellido;

                HtmlGenericControl SpanFlechaUser = new HtmlGenericControl("span");

                SpanFlechaUser.Attributes.Add("class", "caret");
                user_menu.Controls.Add(SpanFlechaUser);

                //MenuItem Menu_Modulo;
                Control Menu_Formularios = FindControl("ulmenu");

                foreach (Modelo_Entidades.Grupo oGrupo in cUsuario.ObtenerGruposUsuario(oUsuario.id))
                {
                    foreach (Modelo_Entidades.Modulo oModulo in cPerfil.ObtenerModulosPorGrupo(oGrupo.id))
                    {
                        if (lModulos.Contains(oModulo) == false)
                        {
                            HtmlGenericControl Formulario = new HtmlGenericControl("li");
                            //Formulario.ID = oModulo.descripcion;
                            //Formulario.InnerHtml = oModulo.descripcion;
                            //Formulario.Attributes.Add("class", "dropdown");
                            Menu_Formularios.Controls.Add(Formulario);

                            HtmlGenericControl Link_Formularios = new HtmlGenericControl("a");
                            //Link_Formularios.ID = "Link_Formularios";
                            Link_Formularios.InnerHtml = oModulo.descripcion;
                            Link_Formularios.Attributes.Add("class", "dropdown-toggle");
                            Link_Formularios.Attributes.Add("href", "#");
                            Link_Formularios.Attributes.Add("data-toggle", "dropdown");
                            Formulario.Controls.Add(Link_Formularios);

                            HtmlGenericControl SpanFlecha = new HtmlGenericControl("span");

                            SpanFlecha.Attributes.Add("class", "caret");
                            Link_Formularios.Controls.Add(SpanFlecha);

                            HtmlGenericControl SubMenu_Formularios = new HtmlGenericControl("ul");
                            SubMenu_Formularios.ID = "SubMenu_Formularios";
                            //SubMenu_Formularios.InnerHtml = oFormulario.nombredemuestra;
                            SubMenu_Formularios.Attributes.Add("class", "dropdown-menu");
                            SubMenu_Formularios.Attributes.Add("role", "menu");
                            Formulario.Controls.Add(SubMenu_Formularios);


                            // Inserto el objeto creado a la barra de menúes del formulario
                            //msMenu.Items.Add(Menu_Modulo);

                            // Busco las funciones asociadas al formulario
                            lModulos.Add(oModulo);
                            ArmaFormularios(oGrupo.id, SubMenu_Formularios, oModulo);
                        }
                    }
                }
            }
        }

        // Armo los menues y submenues
        private void ArmaFormularios(int grupo, Control SubMenu_Formularios, Modelo_Entidades.Modulo oModulo)
        {
            // Le solicito a la controladora la lista de funciones de un módulo determinado.
            // Defino un objeto ToolStripMenuItem para asignar los permisos recuperados.
            //MenuItem SubMenu_Formularios;
            //HtmlGenericControl SubMenu_Formularios = new HtmlGenericControl("ul");

            // Recorro el listado de los permisos según el perfil

            foreach (Modelo_Entidades.Formulario oFormulario in cPerfil.ObtenerFormulariosPorModulo(oModulo))
            {
                if (lFormularios.Contains(oFormulario) == false)
                {
                    //SubMenu_Formularios.ID = "Link_Formulario";
                    //SubMenu_Formularios.InnerHtml = oModulo.descripcion;
                    ////Link_Formulario.Attributes.Add("href", oModulo.descripcion);
                    //SubMenu_Formularios.Attributes.Add("data-toggle", "dropdown");
                    //SubMenu_Formularios.Attributes.Add("role", "button");
                    //Formulario.Controls.Add(SubMenu_Formularios);

                    HtmlGenericControl SubFormulario = new HtmlGenericControl("li");

                    //SubFormulario.ID = "SubFormulario";
                    //SubFormulario.Attributes.Add("href", oModulo.descripcion + "/" + oFormulario.nombredemuestra + ".aspx");
                    //SubFormulario.Attributes.Add("role", "presentation");
                    SubMenu_Formularios.Controls.Add(SubFormulario);

                    HyperLink Link_SubFormulario = new HyperLink();

                    Link_SubFormulario.Text = oFormulario.nombredemuestra;
                    Link_SubFormulario.NavigateUrl = "~/" + oModulo.descripcion + "/" + oFormulario.nombredemuestra + ".aspx";
                    SubFormulario.Controls.Add(Link_SubFormulario);
                    lFormularios.Add(oFormulario);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            oAuditoria = new Modelo_Entidades.Auditoria_Log();
            oAuditoria.usuario = oUsuario.nombre_apellido;
            oAuditoria.fecha = DateTime.Now;
            oAuditoria.accion = "Egreso del Sistema";
            cAuditoria.AuditarLogUsuario(oAuditoria);

            Session.Abandon();
            Page.Response.Redirect("~/Seguridad/Login.aspx");
        }
    }
}