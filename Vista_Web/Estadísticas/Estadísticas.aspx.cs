using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using AjaxControlToolkit;

namespace Vista_Web
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string listado;
        string fecha_desde;
        string fecha_hasta;
        DateTime fechaDesde;
        DateTime fechaHasta;
        // Constructor
        public Estadisticas()
        {
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                desde.SelectedDate = Convert.ToDateTime("01/01/2012");
                hasta.SelectedDate = DateTime.Now;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Principal.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            listado = cmb_listado.SelectedItem.Text;

            fecha_desde = desde.SelectedDate.ToShortDateString();
            fecha_hasta = hasta.SelectedDate.ToShortDateString();

            switch (listado)
            {
                case ("Profesionales por estado"):
                    Response.Redirect(String.Format("~/Estadísticas/FrmListado_Prof_Est.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Matrículas por especialidad"):
                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Mat_Esp.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Profesionales por tipo de matrícula"):
                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Prof_TM.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Títulos por universidad"):
                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Tit_Uni.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Títulos por especialidad"):
                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Tit_Esp.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Cuotas por especialidad"):
                fechaDesde = Convert.ToDateTime(desde.SelectedDate);
                fecha_desde = fechaDesde.ToString("yyyy-MM-dd hh:mm:ss");

                fechaHasta = Convert.ToDateTime(hasta.SelectedDate);
                fecha_hasta = fechaHasta.ToString("yyyy-MM-dd hh:mm:ss");

                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Cuotas_Esp.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Cuotas por descripción"):
                fechaDesde = Convert.ToDateTime(desde.SelectedDate);
                fecha_desde = fechaDesde.ToString("yyyy-MM-dd hh:mm:ss");

                fechaHasta = Convert.ToDateTime(hasta.SelectedDate);
                fecha_hasta = fechaHasta.ToString("yyyy-MM-dd hh:mm:ss");

                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Cuotas_Desc.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Expedientes por especialidad"):
                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Expte_Esp.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Montos de expdientes por especialidad"):
                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Expte_Monto_Esp.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;

                case ("Expedientes por tarea"):
                Response.Redirect(String.Format("~/Estadísticas/FrmListado_Expte_Obra.aspx?desde={0}&hasta={1}", fecha_desde, fecha_hasta));
                break;
            }
        }
    }
}