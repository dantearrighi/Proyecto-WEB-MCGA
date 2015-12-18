using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vista_Web
{
    public partial class Auditorias : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Controladora.cAuditoria cAuditoria;

        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Auditoria_Log oAuditoria;
        List<Modelo_Entidades.Auditoria_Log> lAuditorias;
        string auditoria;
        string modo;

        // Constructor
        public Auditorias()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cAuditoria = Controladora.cAuditoria.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "FrmAuditorias");
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

            message.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal1();", true);

        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvAuditorias.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un registro";
            }

            else
            {
                auditoria = gvAuditorias.SelectedRow.Cells[1].Text;
                modo = "Consulta";
                Response.Redirect(String.Format("~/Auditorias/Auditoria.aspx?auditoria={0}&modo={1}", Server.UrlEncode(auditoria), Server.UrlEncode(modo)));
            }
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvAuditorias.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un registro";
            }

            else
            {
                auditoria = gvAuditorias.SelectedRow.Cells[1].Text;
                modo = "Modifica";
                Response.Redirect(String.Format("~/Auditoria/Auditoria.aspx?auditoria={0}&modo={1}", Server.UrlEncode(auditoria), Server.UrlEncode(modo)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Baja(object sender, EventArgs e)
        {
            if (gvAuditorias.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un registro";
            }

            else
            {
                auditoria = gvAuditorias.SelectedRow.Cells[1].Text;
                oUsuario = cUsuario.ObtenerUsuario(auditoria);

                {
                    message.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                }
            }

        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            lAuditorias = cAuditoria.ObtenerAuditorias();
            gvAuditorias.DataSource = lAuditorias;
            gvAuditorias.DataBind();

            cmb_acciones.DataSource = cAuditoria.ObtenerAcciones();
            cmb_acciones.DataBind();
            cmb_acciones.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_acciones.SelectedIndex = 0;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            string nya;
            string VarCombo_accion;
            string fecha_desde;
            string fecha_hasta;

            if (txt_nombreapellido.Text == "")
            {
                nya = "0";
            }

            else
            {
                nya = txt_nombreapellido.Text;
            }

            if (cmb_acciones.SelectedValue == "")
            {
                VarCombo_accion = "0";
            }

            else
            {
                VarCombo_accion = cmb_acciones.SelectedValue.ToString();
            }

            if (c_fechadesde.Value == "")
            {
                fecha_desde = "0";
            }

            else
            {
                fecha_desde = c_fechadesde.Value.ToString();
            }

            if (c_fechahasta.Value == "")
            {
                fecha_hasta = "0";
            }

            else
            {
                fecha_hasta = c_fechahasta.Value.ToString();
            }

            lAuditorias = cAuditoria.FiltrarAuditorias(nya, VarCombo_accion, fecha_desde, fecha_hasta);
            gvAuditorias.DataSource = lAuditorias;
            gvAuditorias.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            auditoria = gvAuditorias.SelectedRow.Cells[1].Text;
            oAuditoria = cAuditoria.ObtenerAuditoria(Convert.ToInt32(auditoria));

            cAuditoria.BajaAuditoria(oAuditoria);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);

            message.Visible = true;
            lb_error.Text = "El registro fue eliminado";
            Arma_Lista();
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void btn_cancelar_modal_1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal1();", true);
        }

        protected void btn_formatear_modal_Click(object sender, EventArgs e)
        {
            cAuditoria.FormatearAuditorias();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal1();", true);

            message.Visible = true;
            lb_error.Text = "Se ha formateado la tabla de auditorias correctamente";
            Arma_Lista();
        }

        protected void gvAuditorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void gvAuditorias_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = "Nombre y Apellido del Usuario";
            e.Row.Cells[3].Text = "Fecha";
            e.Row.Cells[4].Text = "Acción";
        }
    }
}