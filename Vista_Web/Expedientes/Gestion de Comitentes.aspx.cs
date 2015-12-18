using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vista_Web
{
    public partial class Comitentes : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Controladora.cComitente cComitente;

        Modelo_Entidades.Usuario oUsuario;
        List<Modelo_Entidades.Usuario> lUsuarios;
        Modelo_Entidades.Comitente oComitente;
        List<Modelo_Entidades.Comitente> lComitentes;
        string comitente;
        string modo;

        // Constructor
        public Comitentes()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cComitente = Controladora.cComitente.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "FrmComitentes");
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
            comitente = "nuevo";
            modo = "Alta";
            Response.Redirect(String.Format("~/Comitente/Comitente.aspx?comitente={0}&modo={1}", Server.UrlEncode(comitente), Server.UrlEncode(modo)));
        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvUsuarios.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un comitente";
            }

            else
            {
                comitente = gvUsuarios.SelectedRow.Cells[1].Text;
                modo = "Consulta";
                Response.Redirect(String.Format("~/Comitente/Comitente.aspx?comitente={0}&modo={1}", Server.UrlEncode(comitente), Server.UrlEncode(modo)));
            }
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvUsuarios.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un comitente";
            }

            else
            {
                comitente = gvUsuarios.SelectedRow.Cells[1].Text;
                modo = "Modifica";
                Response.Redirect(String.Format("~/Comitente/Comitente.aspx?comitente={0}&modo={1}", Server.UrlEncode(comitente), Server.UrlEncode(modo)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }


        // Al hacer click en "Modificar"
        protected void botonera1_Click_Baja(object sender, EventArgs e)
        {
            comitente = gvUsuarios.SelectedRow.Cells[1].Text;
            oComitente = cComitente.ObtenerComitente(Convert.ToInt32(comitente));
            if (gvUsuarios.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un comitente";
            }

            else
            {
                if (oComitente.Expedientes.Count != 0)
                {
                    message.Visible = true;
                    lb_error.Text = "No se puede eliminar el comitente debido a que existen expedientes vinculados a él";
                    return;
                }
                else
                {
                    comitente = gvUsuarios.SelectedRow.Cells[1].Text;
                    oComitente = cComitente.ObtenerComitente(Convert.ToInt32(comitente));

                    message.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                }
            }

        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            lComitentes = cComitente.ObtenerComitentes();
            gvUsuarios.DataSource = lComitentes;
            gvUsuarios.DataBind();

            message.Visible = false;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            gvUsuarios.DataSource = cComitente.FiltrarPorNyA(txt_nombreapellido.Text);
            gvUsuarios.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            comitente = gvUsuarios.SelectedRow.Cells[1].Text;
            oComitente = cComitente.ObtenerComitente(Convert.ToInt32(comitente));

            cComitente.EliminarComitente(oComitente);
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
            message.Visible = true;
            lb_error.Text = "El comitente fue eliminado";
            Arma_Lista();
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void gvUsuarios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Text = "ID";
            e.Row.Cells[2].Text = "Razón social";
        }
    }
}