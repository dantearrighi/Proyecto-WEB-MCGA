using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vista_Web
{
    public partial class Titulos : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cUniversidad cUniversidad;
        Controladora.cEspecialidad cEspecialidad;
        Controladora.cTitulo cTitulo;
        Controladora.cLegajo_Academico cLegajo_Academico;

        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Titulo oTitulo;
        
        string titulo;
        string modo;

        // Constructor
        public Titulos()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cUniversidad = Controladora.cUniversidad.ObtenerInstancia();
            cEspecialidad = Controladora.cEspecialidad.ObtenerInstancia();
            cTitulo = Controladora.cTitulo.ObtenerInstancia();
            cLegajo_Academico = Controladora.cLegajo_Academico.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "FrmTitulos");
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
            titulo = "nuevo";
            modo = "Alta";
            Response.Redirect(String.Format("~/Titulos/Titulo.aspx?titulo={0}&modo={1}", Server.UrlEncode(titulo), Server.UrlEncode(modo)));
        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvTitulos.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un título";
            }

            else
            {
                titulo = gvTitulos.SelectedRow.Cells[1].Text;
                modo = "Consulta";
                Response.Redirect(String.Format("~/Titulos/Titulo.aspx?titulo={0}&modo={1}", Server.UrlEncode(titulo), Server.UrlEncode(modo)));
            }
        }

        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvTitulos.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un título";
            }

            else
            {
                titulo = gvTitulos.SelectedRow.Cells[1].Text;
                modo = "Modifica";
                Response.Redirect(String.Format("~/Titulos/Titulo.aspx?titulo={0}&modo={1}", Server.UrlEncode(titulo), Server.UrlEncode(modo)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Baja(object sender, EventArgs e)
        {
            if (gvTitulos.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un título";
            }

            else
            {
                message.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
            }
        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            gvTitulos.DataSource = cTitulo.ObtenerTitulos();
            gvTitulos.DataBind();

            cmb_especialidades.DataSource = cEspecialidad.ObtenerEspecialidades();
            cmb_especialidades.DataBind();
            cmb_especialidades.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_especialidades.SelectedIndex = 0;

            cmb_universidad.DataSource = cUniversidad.ObtenerUniversidades();
            cmb_universidad.DataBind();
            cmb_universidad.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_universidad.SelectedIndex = 0;

            message.Visible = false;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            string VarCombo_Universidad;
            string VarCombo_Especialidad;

            if (cmb_universidad.SelectedValue == null)
            {
                VarCombo_Universidad = "0";
            }

            else
            {
                VarCombo_Universidad = cmb_universidad.SelectedValue.ToString();
            }

            if (cmb_especialidades.SelectedValue == null)
            {
                VarCombo_Especialidad = "0";
            }

            else
            {
                VarCombo_Especialidad = cmb_especialidades.SelectedValue.ToString();
            }

            gvTitulos.DataSource = cTitulo.FiltrarTitulos(VarCombo_Universidad, VarCombo_Especialidad);
            gvTitulos.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            titulo = gvTitulos.SelectedRow.Cells[1].Text;
            oTitulo = cTitulo.ObtenerTituloPorID(Convert.ToInt32(titulo));

            if (cLegajo_Academico.ValidarPlanesdelTitulo(oTitulo) == true)
            {
                message.Visible = true;
                lb_error.Text = "Debe desvincular al título de sus planes antes de eliminarlo.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
            }

            else
            {
                cTitulo.EliminarTitulo(oTitulo);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
                Arma_Lista();
                message.Visible = true;
                lb_error.Text = "El título fue eliminado";
            }
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void gvTitulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void gvTitulos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = "Descripción";
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
        }
    }
}