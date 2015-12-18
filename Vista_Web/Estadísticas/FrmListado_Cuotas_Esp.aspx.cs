using System;
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
    public partial class FrmListado_Cuotas_Esp : System.Web.UI.Page
    {
        string desde;
        string hasta; 

        // Constructor
        public FrmListado_Cuotas_Esp()
        {
            
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {

            desde = Request.QueryString["desde"];
            hasta = Request.QueryString["hasta"];

            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            // the ReportPath is relative to the page displaying the ReportViewer
            ReportViewer1.LocalReport.ReportPath = "Estadísticas/Cuotas_Por_Esp.rdlc";

            //object YourDataHereForTheReport;
            ReportDataSource rds = new ReportDataSource("Cuotas", ObjectDataSource1);

            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.Refresh();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
    }
}