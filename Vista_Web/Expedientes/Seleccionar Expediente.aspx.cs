﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace Vista_Web
{
    public partial class SeleccionarExpediente : System.Web.UI.Page
    {
       // Declaro las controladoras a usar
        string profesional;
        string expediente;
        Modelo_Entidades.Usuario oUsuario;
        List<Modelo_Entidades.Expediente> lExpedientes;
        Modelo_Entidades.Profesional oProfesional;

        Controladora.cProfesional cProfesional;
        Controladora.cExpediente cExpediente;

        // Constructor
        public SeleccionarExpediente()
        {
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
            cExpediente = Controladora.cExpediente.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            profesional = Server.UrlDecode(Request.QueryString["profesional"]);
            oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));
            
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
            lExpedientes = cExpediente.BuscarExpedientesAprobados(oProfesional);
            gvExpedientes.DataSource = lExpedientes;
            gvExpedientes.DataBind();

            message.Visible = false;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Contabilidad/Gestion de Recibos.aspx?"));
        }

        protected void btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (gvExpedientes.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un expediente";
            }

            else
            {
                expediente = gvExpedientes.SelectedRow.Cells[1].Text;

                Response.Redirect(String.Format("~/Contabilidad/Gestion de Recibos.aspx?profesional={0}&expediente={1}", Server.UrlEncode(profesional), Server.UrlEncode(expediente)));
            }
        }

        protected void gvProfesionales_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Text = "Número";
            e.Row.Cells[2].Text = "Estado";
            e.Row.Cells[3].Text = "Fecha de devolución";
            e.Row.Cells[4].Text = "Fecha de recepción";
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Text = "Fecha de aprobación";
            e.Row.Cells[7].Text = "Fecha de pago";
        }

        protected void gvProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void txt_numero_TextChanged(object sender, EventArgs e)
        {
            lExpedientes = cExpediente.BuscarExpedientesAprobadosPorNumero(Convert.ToInt32(txt_numero.Text));
            gvExpedientes.DataSource = lExpedientes;
            gvExpedientes.DataBind();
        }
    }
}