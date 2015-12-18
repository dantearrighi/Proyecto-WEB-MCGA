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
    public partial class Recibos : System.Web.UI.Page
    {
       // Declaro las controladoras a usar
        string profesional;
        string cuota;
        string expediente;
        Modelo_Entidades.Profesional oProfesional;
        Modelo_Entidades.Movimiento oMovimiento;
        Modelo_Entidades.Factura oFactura;
        Modelo_Entidades.Expediente oExpediente;
        Modelo_Entidades.CtaCte oCtaCte;
        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Cuota oCuota;
        string concepto;

        List<Modelo_Entidades.Movimiento> ListaMovimientos = new List<Modelo_Entidades.Movimiento>();
        List<Modelo_Entidades.Cuota> ListaCuotas = new List<Modelo_Entidades.Cuota>();

        // Declaro las controladoras a usar
        Controladora.cTipo_Movimiento cTipo_Movimiento;
        Controladora.cMovimiento cMovimiento;
        Controladora.cProfesional cProfesional;
        Controladora.cEstado cEstado;
        Controladora.cCuota cCuota;
        Controladora.cComprobante cComprobante;
        Controladora.cCtaCte cCtaCte;
        Controladora.cAuditoria cAuditoria;
        Controladora.cExpediente cExpediente;

        // Constructor
        public Recibos()
        {
            cTipo_Movimiento = Controladora.cTipo_Movimiento.ObtenerInstancia();
            cMovimiento = Controladora.cMovimiento.ObtenerInstancia();
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
            cEstado = Controladora.cEstado.ObtenerInstancia();
            cCuota = Controladora.cCuota.ObtenerInstancia();
            cComprobante = Controladora.cComprobante.ObtenerInstancia();
            cCtaCte = Controladora.cCtaCte.ObtenerInstancia();
            cAuditoria = Controladora.cAuditoria.ObtenerInstancia();
            cExpediente = Controladora.cExpediente.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            profesional = Server.UrlDecode(Request.QueryString["profesional"]);
            expediente = Server.UrlDecode(Request.QueryString["expediente"]);
            
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
            //btn_cobrar_cuotas.Enabled = false;
            //btn_cobrar_expediente.Enabled = false;
            btn_imprimir.Enabled = false;

            if (profesional != null)
            {
                oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));
                txt_profesional.Text = oProfesional.nombre_apellido;

                chk_cuotas.DataSource = null;
                chk_cuotas.DataSource = cCuota.BuscarCuotasImpagasPorProfesional(Convert.ToInt32(profesional));
                chk_cuotas.DataBind();
            }

            if (expediente != null)
            {
                oExpediente = cExpediente.BuscarExpedientePorNumero(Convert.ToInt32(expediente));

                ArmaFacturaExpte();
                concepto = "Expediente";
                btn_imprimir.Enabled = true;

                txt_total.Text = oMovimiento.importe.ToString();
            }
        }

        protected void btn_cobrar_cuotas_Click(object sender, EventArgs e)
        {
            if (profesional != null)
            {
                message.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
            }

            else
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un profesional o elegir un nombre para la factura";
            }
        }

        protected void btn_seleccionar_prof_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Profesional/Seleccionar profesional.aspx?"));
        }

        protected void gvRecibos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvRecibos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = "Concepto";
            e.Row.Cells[3].Text = "Importe";
            e.Row.Cells[4].Visible = false;
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (profesional != null)
            {
                oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));
            }

            if (expediente != null)
            {
                oExpediente = cExpediente.BuscarExpedientePorNumero(Convert.ToInt32(expediente));
                concepto = "Expediente";

                oMovimiento = cMovimiento.BuscarMovimientoPorDescExpte(oExpediente.numero);
            }

            else
            {
                ArmaFactura();
                concepto = "Cuota";
            }

            if (gvRecibos.Rows.Count == 0)
            {
                message.Visible = true;
                lb_error.Text = "Debe existir alg{un concepto para imprimir";
            }

            else
            {
                switch (concepto)
                {
                    case "Cuota":
                        #region Cobro de cuota
                        oCtaCte = oProfesional.CtaCte;
                        Modelo_Entidades.Auditoria_Cuota oLog_Cuota;

                        if (ListaCuotas.Count == 0)
                        {
                            message.Visible = true;
                            lb_error.Text = "Debe seleccionar al menos 1 cuota para cobrar";
                        }

                        else
                        {
                            foreach (Modelo_Entidades.Cuota oCuo in ListaCuotas)
                            {
                                #region Audito la cuota
                                oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();
                                oLog_Cuota.estado = false;
                                oLog_Cuota.descripcion = oCuo.descripcion;
                                oLog_Cuota.Profesional_dni = oCuo.Profesional.dni;
                                oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                oLog_Cuota.fecha = DateTime.Now;
                                oLog_Cuota.accion = "Modificación de cuota al profesional " + oCuo.Profesional.nombre_apellido;
                                cAuditoria.AuditarCuota(oLog_Cuota);
                                #endregion

                                oCuo.estado = true;
                            }

                            // 1º Creo un una nueva factura                
                            oFactura = new Modelo_Entidades.Factura();

                            int i = 0;
                            double suma = 0;

                            // 2º Cargo los datos de la factura
                            oFactura.cantidad = 1;
                            oFactura.descripcion = "Pago de cuotas";
                            oFactura.precio_unitario = 1;

                            foreach (Modelo_Entidades.Movimiento oMov in ListaMovimientos) // Acá saldo a cada movimiento que genero la cuota, con otro movimiento igual, pero con distinto tipo y le coloco la misma factura
                            {
                                oMovimiento = new Modelo_Entidades.Movimiento();
                                oMovimiento.fecha = DateTime.Now;
                                oMovimiento.importe = oMov.importe;
                                oMovimiento.descripcion = oMov.descripcion;
                                oMovimiento.CtaCte = oProfesional.CtaCte;
                                oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Acreedor();

                                while (i < gvRecibos.Rows.Count)
                                {
                                    if (gvRecibos.Rows[i] != null)
                                    {
                                        suma = Convert.ToDouble(gvRecibos.Rows[i].Cells[3].Text) + suma;
                                    }

                                    i++;
                                }

                                oFactura.importe = Convert.ToDecimal(suma);
                                oFactura.total = Convert.ToDecimal(suma);

                                oMovimiento.Comprobante = oFactura;
                                cMovimiento.Alta(oMovimiento);

                                oFactura.Movimientos.Add(oMovimiento);
                                oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                                oCtaCte.saldo = oCtaCte.saldo + Convert.ToDecimal(oMov.importe);
                                //oProfesional.CtaCte.saldo = oProfesional.CtaCte.saldo + Convert.ToDecimal(oMov.importe); // Sumo al saldo, cuando el profesional termina de pagar

                                // Elimino todos los movimientos bimensuales del año que le cobré
                                string año = oMov.descripcion.Substring(oMov.descripcion.Length - Math.Min(4, oMov.descripcion.Length));
                                if (oMov.descripcion.Contains("anual") == true) // Quiere decir que pagó la cuota anual
                                {
                                    foreach (Modelo_Entidades.Movimiento oMovi in cMovimiento.ObtenerMovimientos())
                                    {
                                        if (oMovi.descripcion.Contains("/") && oMovi.descripcion.Contains(año) && oMovi.CtaCte.id == oProfesional.CtaCte.id) // Pregunto por las cuotas de ese año que pagó
                                        {
                                            //oProfesional.CtaCte.saldo = oProfesional.CtaCte.saldo + Convert.ToDecimal(oMovi.importe); 
                                            Modelo_Entidades.Cuota CuotaAEliminar = cCuota.ObtenerCuota(oMovi.descripcion, oProfesional.dni);

                                            if (CuotaAEliminar != null) // Solo resto cuando elimino la cuota
                                            {
                                                #region Audito la cuota
                                                oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();
                                                oLog_Cuota.estado = false;
                                                oLog_Cuota.descripcion = CuotaAEliminar.descripcion;
                                                oLog_Cuota.Profesional_dni = CuotaAEliminar.Profesional.dni;
                                                oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                                oLog_Cuota.fecha = DateTime.Now;
                                                oLog_Cuota.accion = "Eliminacíón de cuota bimensual al profesional " + CuotaAEliminar.Profesional.nombre_apellido;
                                                cAuditoria.AuditarCuota(oLog_Cuota);
                                                #endregion

                                                oCtaCte.saldo = oCtaCte.saldo + Convert.ToDecimal(oMovi.importe); // Sumo al saldo, ya que le estoy anulando la cuota
                                                cCuota.EliminarCuota(CuotaAEliminar); // Entonces debo eliminar las cuotas de ese año
                                            }

                                            cCtaCte.Modificacion(oCtaCte);
                                        }
                                    }
                                }

                                else
                                {
                                    Modelo_Entidades.Cuota CuotaAEliminar = cCuota.ObtenerCuota(("Cuota anual año " + año), oProfesional.dni);

                                    if (CuotaAEliminar != null) // Solo resto cuando elimino la cuota
                                    {
                                        double valor = (cMovimiento.BuscarMovimientoPorCuotaYProf("Cuota anual año " + año, oProfesional.CtaCte.id).importe);

                                        #region Audito la cuota
                                        oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();
                                        oLog_Cuota.estado = false;
                                        oLog_Cuota.descripcion = CuotaAEliminar.descripcion;
                                        oLog_Cuota.Profesional_dni = CuotaAEliminar.Profesional.dni;
                                        oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                        oLog_Cuota.fecha = DateTime.Now;
                                        oLog_Cuota.accion = "Eliminacíón de cuota anual al profesional " + CuotaAEliminar.Profesional.nombre_apellido;
                                        cAuditoria.AuditarCuota(oLog_Cuota);
                                        #endregion

                                        oCtaCte.saldo = oCtaCte.saldo + Convert.ToDecimal(valor); // Sumo al saldo, ya que le estoy anulando la cuota
                                        cCuota.EliminarCuota(CuotaAEliminar); // Entonces debo eliminar las cuotas de ese año
                                    }

                                    cCtaCte.Modificacion(oCtaCte);
                                }
                            }

                            // Después de cobrarle hago la verificación de si 1º no tiene deudas de otros años y 2º si tiene paga la 1º o la cuota anual del año en curso

                            // El mayor es por los intereses. Además se podría colocar que  el saldo debe ser mayor o igual a 0, pero el colegio no lo toma como requisito (&& oProfesional.CtaCte.saldo >= 0)
                            if (((cCuota.ObtenerSiElProfPago(oProfesional, ("Cuota " + "1" + "/" + DateTime.Now.Year.ToString()), DateTime.Now.Year.ToString())) == true))
                            {
                                oProfesional.Estado = cEstado.ObtenerEstadoHabilitado();
                                cProfesional.Modificacion(oProfesional);
                            }

                            txt_total.Text = suma.ToString();

                            Response.Redirect(String.Format("~/Contabilidad/FrmImprimirRecibo.aspx?comp_id={0}", Server.UrlEncode(oFactura.id.ToString())));

                        }
                        #endregion
                        break;
                    case "Expediente":
                        #region Cobro de expediente

                        // Cambio el estado del expediente a pagado
                        oExpediente.estado = "Pagado";
                        oExpediente.fecha_pago = DateTime.Now;
                        oCtaCte = oProfesional.CtaCte;

                        // 1º Creo un una nueva factura                
                        oFactura = new Modelo_Entidades.Factura();

                        int i_1 = 0;
                        double suma_1 = 0;

                        // 2º Cargo los datos de la factura
                        oFactura.cantidad = 1;
                        oFactura.descripcion = "Pago de expediente";
                        oFactura.precio_unitario = 1;

                        Modelo_Entidades.Movimiento oMovi_expte = new Modelo_Entidades.Movimiento();
                        oMovi_expte.fecha = DateTime.Now;
                        oMovi_expte.importe = oMovimiento.importe;
                        oMovi_expte.descripcion = "Pago expediente número " + oExpediente.numero;
                        oMovi_expte.CtaCte = oProfesional.CtaCte;
                        oMovi_expte.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Acreedor();

                        while (i_1 < gvRecibos.Rows.Count)
                        {
                            if (gvRecibos.Rows[i_1] != null)
                            {
                                suma_1 = Convert.ToDouble(gvRecibos.Rows[i_1].Cells[3].Text + suma_1);
                            }

                            i_1++;
                        }

                        oFactura.importe = Convert.ToDecimal(suma_1);
                        oFactura.total = Convert.ToDecimal(suma_1);

                        oMovi_expte.Comprobante = oFactura;
                        cMovimiento.Alta(oMovi_expte);

                        oFactura.Movimientos.Add(oMovi_expte);
                        oProfesional.CtaCte.Movimientos.Add(oMovi_expte);

                        oCtaCte.saldo = oCtaCte.saldo + Convert.ToDecimal(oMovi_expte.importe);

                        Response.Redirect(String.Format("~/Contabilidad/FrmImprimirRecibo.aspx?comp_id={0}", Server.UrlEncode(oFactura.id.ToString())));

                        #endregion
                        break;
                }
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }

        protected void btn_cobrar_expediente_Click(object sender, EventArgs e)
        {
            if (profesional != null)
            {
                Response.Redirect(String.Format("~/Expedientes/Seleccionar Expediente.aspx?profesional={0}", Server.UrlEncode(profesional)));

            }

            else
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un profesional para la factura";
            }
        }

        protected void btn_aceptar_modal_Click(object sender, EventArgs e)
        {
            ArmaFactura();
            concepto = "Cuota";
            btn_imprimir.Enabled = true;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        private void ArmaFactura()
        {
            oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));

            //Antes de hacer el calculo, necesito ver cual de las cuotas estan checkeadas
            ListaCuotas.Clear();
            for (int i = 0; i < chk_cuotas.Items.Count; i++)
            {
                cuota = chk_cuotas.Items[i].Text;
                oCuota = cCuota.ObtenerCuota(cuota, oProfesional.dni);

                if (chk_cuotas.Items[i].Selected == true)
                {
                    ListaCuotas.Add(oCuota);
                }
            }

            double suma = 0;

            if (chk_intereses.Checked == true)
            {
                foreach (Modelo_Entidades.Cuota oCuota in ListaCuotas)
                {
                    oMovimiento = cMovimiento.BuscarMovimientoPorCuotaYProf(oCuota.descripcion, oProfesional.CtaCte.id);
                    TimeSpan dif = DateTime.Now - oMovimiento.fecha;
                    oMovimiento.importe = cCuota.ObtenerValor_Couta_Interes(cCuota.ObtenerValor_Tipo_Couta((oCuota)), dif.Days);
                    suma = oMovimiento.importe + suma;
                    ListaMovimientos.Add(oMovimiento);
                }
            }

            else
            {
                foreach (Modelo_Entidades.Cuota oCuota in ListaCuotas)
                {
                    oMovimiento = cMovimiento.BuscarMovimientoPorCuotaYProf(oCuota.descripcion, oProfesional.CtaCte.id);
                    //oMovimiento.importe = cCuota.ObtenerValor_Tipo_Couta(oCuota).Valor();
                    suma = oMovimiento.importe + suma;
                    ListaMovimientos.Add(oMovimiento);
                }
            }

            txt_total.Text = suma.ToString();

            gvRecibos.DataSource = null;
            gvRecibos.DataSource = ListaMovimientos;
            gvRecibos.DataBind();
        }

        private void ArmaFacturaExpte()
        {
            gvRecibos.DataSource = null;
            ListaMovimientos = cMovimiento.BuscarMovimientosPorDescExpte(oExpediente.numero);
            gvRecibos.DataSource = ListaMovimientos;
            gvRecibos.DataBind();

            oMovimiento = cMovimiento.BuscarMovimientoPorDescExpte(oExpediente.numero);
            oMovimiento.descripcion = "Pago expediente número " + oExpediente.numero;
        }
    }
}