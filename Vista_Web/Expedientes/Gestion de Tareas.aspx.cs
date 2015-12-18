using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vista_Web
{
    public partial class Tareas : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Controladora.cTarea cTarea;

        Modelo_Entidades.Usuario oUsuario;
        List<Modelo_Entidades.Usuario> lUsuarios;
        Modelo_Entidades.Tarea oTarea;
        List<Modelo_Entidades.Tarea> lTareas;
        string Tarea;
        string modo;

        // Constructor
        public Tareas()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cTarea = Controladora.cTarea.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "FrmTareas");
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
            Tarea = "nuevo";
            modo = "Alta";
            Response.Redirect(String.Format("~/Tareas/Tarea.aspx?Tarea={0}&modo={1}", Server.UrlEncode(Tarea), Server.UrlEncode(modo)));
        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvUsuarios.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una Tarea";
            }

            else
            {
                Tarea = gvUsuarios.SelectedRow.Cells[1].Text;
                modo = "Consulta";
                Response.Redirect(String.Format("~/Tareas/Tarea.aspx?Tarea={0}&modo={1}", Server.UrlEncode(Tarea), Server.UrlEncode(modo)));
            }
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvUsuarios.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un Tarea";
            }

            else
            {
                Tarea = gvUsuarios.SelectedRow.Cells[1].Text;
                modo = "Modifica";
                Response.Redirect(String.Format("~/Tareas/Tarea.aspx?Tarea={0}&modo={1}", Server.UrlEncode(Tarea), Server.UrlEncode(modo)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }


        // Al hacer click en "Modificar"
        protected void botonera1_Click_Baja(object sender, EventArgs e)
        {
            Tarea = gvUsuarios.SelectedRow.Cells[1].Text;
            oTarea = cTarea.ObtenerTarea(Convert.ToInt32(Tarea));
            if (gvUsuarios.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar una Tarea";
            }

            else
            {
                if (oTarea.Expedientes.Count != 0)
                {
                    message.Visible = true;
                    lb_error.Text = "No se puede eliminar el Tarea debido a que existen expedientes vinculados a la misma";
                    return;
                }
                else
                {
                    Tarea = gvUsuarios.SelectedRow.Cells[1].Text;
                    oTarea = cTarea.ObtenerTarea(Convert.ToInt32(Tarea));

                    message.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                }
            }

        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            lTareas = cTarea.ObtenerTareas();
            gvUsuarios.DataSource = lTareas;
            gvUsuarios.DataBind();

            message.Visible = false;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            gvUsuarios.DataSource = cTarea.FiltrarPorDesc(txt_nombreapellido.Text);
            gvUsuarios.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            Tarea = gvUsuarios.SelectedRow.Cells[1].Text;
            oTarea = cTarea.ObtenerTarea(Convert.ToInt32(Tarea));

            cTarea.EliminarTarea(oTarea);
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
            message.Visible = true;
            lb_error.Text = "La Tarea fue eliminada";
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
            e.Row.Cells[2].Text = "Descripción";
        }
    }
}