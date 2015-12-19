using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace Vista_Web
{
    public partial class SeleccionarProfesional : System.Web.UI.Page
    {
       // Declaro las controladoras a usar
        string profesional;
        string modo;
       
        string tipo;
        

        Modelo_Entidades.Usuario oUsuario;
        List<Modelo_Entidades.Profesional> lProfesionales;

        Controladora.cProfesional cProfesional;
       

        // Constructor
        public SeleccionarProfesional()
        {
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
         
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            profesional = Server.UrlDecode(Request.QueryString["profesional"]);

          
            modo = Server.UrlDecode(Request.QueryString["modo"]);
           

            oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                Arma_Lista();
            }
        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            lProfesionales = cProfesional.ObtenerProfesionales();
            gvProfesionales.DataSource = lProfesionales;
            gvProfesionales.DataBind();

            message.Visible = false;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (gvProfesionales.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un profesional";
            }

           
            
        }

        protected void gvProfesionales_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
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

        protected void gvProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void txt_profesional_TextChanged(object sender, EventArgs e)
        {
            lProfesionales = cProfesional.FiltrarPorNyA(txt_profesional.Text);
            gvProfesionales.DataSource = lProfesionales;
            gvProfesionales.DataBind();
        }
    }
}