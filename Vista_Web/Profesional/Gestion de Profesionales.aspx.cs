using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vista_Web
{
    public partial class Profesionales : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cGrupo cGrupo;
        Controladora.cProfesional cProfesional;
        Modelo_Entidades.Usuario oUsuario;
        List<Modelo_Entidades.Profesional> lProfesionales;
        string profesional;
        string modo;
        string usuario;

        // Constructor
        public Profesionales()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];

            if (!Page.IsPostBack)
            {
                botonera1.ArmaPerfil(oUsuario, "FrmProfesionales");
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
            profesional = "nuevo";
            modo = "Alta";
            usuario = oUsuario.usuario;

            Response.Redirect(String.Format("~/Profesional/Profesional.aspx?profesional={0}&modo={1}&usuario={2}", Server.UrlEncode(profesional), Server.UrlEncode(modo), Server.UrlEncode(usuario)));
        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvProfesionales.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un profesional";
            }

            else
            {
                profesional = gvProfesionales.SelectedRow.Cells[1].Text;
                modo = "Consulta";
                usuario = oUsuario.usuario;

                Response.Redirect(String.Format("~/Profesional/Profesional.aspx?profesional={0}&modo={1}&usuario={2}", Server.UrlEncode(profesional), Server.UrlEncode(modo), Server.UrlEncode(usuario)));
            }
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvProfesionales.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un profesional";
            }

            else
            {
                profesional = gvProfesionales.SelectedRow.Cells[1].Text;
                modo = "Modifica";
                usuario = oUsuario.usuario;

                Response.Redirect(String.Format("~/Profesional/Profesional.aspx?profesional={0}&modo={1}", Server.UrlEncode(profesional), Server.UrlEncode(modo), Server.UrlEncode(usuario)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            lProfesionales = cProfesional.ObtenerProfesionales();
            gvProfesionales.DataSource = lProfesionales;
            gvProfesionales.DataBind();

            message.Visible = false;
        }

        protected void gvProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void gvProfesionales_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Text = "DNI";
            e.Row.Cells[2].Text = "Nombre y Apellido";
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
        }

        

        protected void txt_dni_TextChanged(object sender, EventArgs e)
        {
            lProfesionales = cProfesional.FiltrarPorDNI(txt_dni.Text);
            gvProfesionales.DataSource = lProfesionales;
            gvProfesionales.DataBind();
        }

        protected void txt_nya_profesional_TextChanged(object sender, EventArgs e)
        {
            lProfesionales = cProfesional.FiltrarPorNyA(txt_nya_profesional.Text);
            gvProfesionales.DataSource = lProfesionales;
            gvProfesionales.DataBind();
        }
    }
}