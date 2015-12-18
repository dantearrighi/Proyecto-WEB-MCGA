using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vista_Web
{
    public partial class AuditoriasCuotas : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Controladora.cAuditoria cAuditoria;

        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Auditoria_Log oAuditoria;
        List<Modelo_Entidades.Auditoria_Cuota> lAuditorias;
        string auditoria;
        string modo;

        // Constructor
        public AuditoriasCuotas()
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
            lAuditorias = cAuditoria.ObtenerAuditoriasCuotas();
            gvAuditorias.DataSource = lAuditorias;
            gvAuditorias.DataBind();
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            string nya;
            string dni;
            string cuota;

            if (txt_usuario.Text == "")
            {
                nya = "0";
            }

            else
            {
                nya = txt_usuario.Text;
            }

            if (txt_dni_profesional.Text == "")
            {
                dni = "0";
            }

            else
            {
                dni = txt_dni_profesional.Text;
            }

            if (txt_cuota.Text == "")
            {
                cuota = "0";
            }

            else
            {
                cuota = txt_cuota.Text;
            }

            lAuditorias = cAuditoria.FiltrarAuditoriasCuotas(nya, dni, cuota);
            gvAuditorias.DataSource = lAuditorias;
            gvAuditorias.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void gvAuditorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void gvAuditorias_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Text = "Descripción";
            e.Row.Cells[4].Text = "DNI del profesional";
            e.Row.Cells[5].Text = "Usuario";
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Text = "Acción";
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }
    }
}