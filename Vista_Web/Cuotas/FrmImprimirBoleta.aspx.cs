﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using AjaxControlToolkit;
using System.Data;
using System.Drawing;
using Vista_Web.App_Code.BoletasTableAdapters;
using Vista_Web.App_Code;
using Microsoft.Reporting.WebForms;

namespace Vista_Web
{
    public partial class FrmImprimirBoleta : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        int menor_1;
        int mayor_1;
        string desc_1;
        int tipo_matricula_1;

        string menor;
        string mayor; 
        string desc;
        string tipo_matricula;

        // Constructor
        public FrmImprimirBoleta()
        {
            
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {

            tipo_matricula = Request.QueryString["tipo_matricula"];
            menor = Request.QueryString["menor"];
            mayor = Request.QueryString["mayor"];
            desc = Request.QueryString["descripcion"];

            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            // the ReportPath is relative to the page displaying the ReportViewer
            ReportViewer1.LocalReport.ReportPath = "Cuotas/Boletas.rdlc";

            //object YourDataHereForTheReport;
            ReportDataSource rds = new ReportDataSource("Boletas", ObjectDataSource1);

            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.Refresh();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // TODO: esta línea de código carga datos en la tabla 'Boletas.Cuotas' Puede moverla o quitarla según sea necesario.

                //Vista_Web.App_Code.BoletasTableAdapters.CuotasTableAdapter ta = new App_Code.BoletasTableAdapters.CuotasTableAdapter();
                //Vista_Web.App_Code.Boletas.CuotasDataTable tabla = new Boletas.CuotasDataTable();

                //ta.FillBoletas(tabla, tipo_matricula_1, menor_1, mayor_1, desc_1);

                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportDataSource datasource = new ReportDataSource("Boletas", (DataTable)tabla);
                //ReportViewer1.LocalReport.DataSources.Add(datasource);
                //ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}