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
    public partial class FrmListado_Prof_TM : System.Web.UI.Page
    {
        string desde;
        string hasta; 

        // Constructor
        public FrmListado_Prof_TM()
        {
            
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {

            desde = Request.QueryString["desde"];
            hasta = Request.QueryString["hasta"];

            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            // the ReportPath is relative to the page displaying the ReportViewer
            ReportViewer1.LocalReport.ReportPath = "Estadísticas/Profesionales_Por_TM.rdlc";

            //object YourDataHereForTheReport;
            ReportDataSource rds = new ReportDataSource("Tipos_Matricula", ObjectDataSource1);

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