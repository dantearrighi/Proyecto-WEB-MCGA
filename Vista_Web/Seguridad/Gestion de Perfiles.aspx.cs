using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vista_Web
{
    public partial class Perfiles : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Controladora.cPerfil cPerfil;
        Controladora.cFormulario cFormulario;
        Controladora.cPermiso cPermiso;

        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Perfil oPerfil;
        List<Modelo_Entidades.Perfil> lPerfiles;
        string perfil;
        string modo;

        // Constructor
        public Perfiles()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cPerfil = Controladora.cPerfil.ObtenerInstancia();
            cFormulario = Controladora.cFormulario.ObtenerInstancia();
            cPermiso = Controladora.cPermiso.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "FrmPerfiles");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Arma_Lista();
            }

        }

        // Al hacer click en "Agregar"
        protected void botonera1_Click_Alta(object sender, EventArgs e)
        {
            perfil = "nuevo";
            modo = "Alta";
            Response.Redirect(String.Format("~/Seguridad/Perfil.aspx?perfil={0}&modo={1}", Server.UrlEncode(perfil), Server.UrlEncode(modo)));
        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvPerfiles.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un perfil";
            }

            else
            {
                perfil = gvPerfiles.SelectedRow.Cells[1].Text;
                modo = "Consulta";
                Response.Redirect(String.Format("~/Seguridad/Perfil.aspx?perfil={0}&modo={1}", Server.UrlEncode(perfil), Server.UrlEncode(modo)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }


        // Al hacer click en "Modificar"
        protected void botonera1_Click_Baja(object sender, EventArgs e)
        {
            if (gvPerfiles.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un perfil";
            }

            else
            {
                perfil = gvPerfiles.SelectedRow.Cells[1].Text;
                oPerfil = cPerfil.ObtenerPerfil(Convert.ToInt32(perfil));
                message.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
            }
        }

        private DataTable ToDataTable(List<Modelo_Entidades.Perfil> Perfiles)
        {
            DataTable returnTable = new DataTable("Perfiles");
            returnTable.Columns.Add(new DataColumn("ID"));
            returnTable.Columns.Add(new DataColumn("Grupo"));
            returnTable.Columns.Add(new DataColumn("Permiso"));
            returnTable.Columns.Add(new DataColumn("Formulario"));

            foreach (Modelo_Entidades.Perfil unPerfil in Perfiles)
            {
                returnTable.AcceptChanges();
                DataRow row = returnTable.NewRow();
                row[0] = unPerfil.id;
                row[1] = unPerfil.Grupo;
                row[2] = unPerfil.Permiso;
                row[3] = unPerfil.Formulario;

                returnTable.Rows.Add(row);
            }

            return returnTable;
        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            lPerfiles = cPerfil.ObtenerPerfiles();
            gvPerfiles.DataSource = this.ToDataTable(lPerfiles);
            gvPerfiles.DataBind();

            cmb_grupos.DataSource = cGrupo.ObtenerGrupos();
            cmb_grupos.DataBind();
            cmb_grupos.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_grupos.SelectedIndex = 0;

            cmb_formularios.DataSource = cFormulario.ObtenerFormularios();
            cmb_formularios.DataBind();
            cmb_formularios.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_formularios.SelectedIndex = 0;

            cmb_permisos.DataSource = cPermiso.ObtenerPermisos();
            cmb_permisos.DataBind();
            cmb_permisos.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_permisos.SelectedIndex = 0;

            message.Visible = false;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            string VarCombo_Grupo;
            string VarCombo_Formulario;
            string VarCombo_Permiso;

            if (cmb_grupos.SelectedValue == "")
            {
                VarCombo_Grupo = "0";
            }

            else
            {
                VarCombo_Grupo = cmb_grupos.SelectedValue.ToString();
            }

            if (cmb_formularios.SelectedValue == "")
            {
                VarCombo_Formulario = "0";
            }

            else
            {
                VarCombo_Formulario = cmb_formularios.SelectedValue.ToString();
            }

            if (cmb_permisos.SelectedValue == "")
            {
                VarCombo_Permiso = "0";
            }

            else
            {
                VarCombo_Permiso = cmb_permisos.SelectedValue.ToString();
            }

            gvPerfiles.DataSource = this.ToDataTable(cPerfil.FiltrarPerfiles(VarCombo_Grupo, VarCombo_Formulario, VarCombo_Permiso));
            gvPerfiles.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            perfil = gvPerfiles.SelectedRow.Cells[1].Text;
            oPerfil = cPerfil.ObtenerPerfil(Convert.ToInt32(perfil));

            cPerfil.BajaPerfil(oPerfil);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
            message.Visible = true;
            lb_error.Text = "El perfil fue eliminado";
            Arma_Lista();
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void gvPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }
    }
}