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
    public partial class Cuotas : System.Web.UI.Page
    {
       // Declaro las controladoras a usar
        Controladora.cProfesional cProfesional;
        Controladora.cAlterador cAlterador;
        Controladora.cCuota cCuota;
        Controladora.cTipo_Movimiento cTipo_Movimiento;
        Controladora.cMovimiento cMovimiento;
        Controladora.cEstado cEstado;
        Controladora.cCtaCte cCtaCte;
        Controladora.cTipo_Matricula cTipo_Matricula;
        Controladora.cAuditoria cAuditoria;

        Modelo_Entidades.Alterador oAlterador;
        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.Titulo oTitulo;
        
        string titulo;
        string modo;
        string desc;
        string tipo_matricula;

        // Constructor
        public Cuotas()
        {
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
            cAlterador = Controladora.cAlterador.ObtenerInstancia();
            cCuota = Controladora.cCuota.ObtenerInstancia();
            cTipo_Movimiento = Controladora.cTipo_Movimiento.ObtenerInstancia();
            cMovimiento = Controladora.cMovimiento.ObtenerInstancia();
            cEstado = Controladora.cEstado.ObtenerInstancia();
            cCtaCte = Controladora.cCtaCte.ObtenerInstancia();
            cTipo_Matricula = Controladora.cTipo_Matricula.ObtenerInstancia();
            cAuditoria = Controladora.cAuditoria.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
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
            oAlterador = cAlterador.ObtenerAlterador();
            txt_porcentaje.Text = oAlterador.porcentaje_recargo.ToString();
            txt_dias_gracias.Text = oAlterador.dias_gracias.ToString();
            txt_valor_bimensual.Text = oAlterador.valor_cuota.ToString();
            btn_guardar.Enabled = false;
            btn_cancelar.Enabled = false;
            
            txt_porcentaje.Enabled = false;
            txt_dias_gracias.Enabled = false;
            txt_valor_bimensual.Enabled = false;
            nud_cuontas_numeros.Enabled = true;

            cmb_tipo_matricula.DataSource = cTipo_Matricula.ObtenerTiposMatriculas();
            cmb_tipo_matricula.DataBind();
            cmb_tipo_matricula.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_tipo_matricula.SelectedIndex = 0;
        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {
            btn_guardar.Enabled = true;
            btn_cancelar.Enabled = true;
            txt_porcentaje.Enabled = true;
            txt_dias_gracias.Enabled = true;
            txt_valor_bimensual.Enabled = true;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios())
            {
                oAlterador = cAlterador.ObtenerAlterador();
                oAlterador.porcentaje_recargo = Convert.ToDouble(txt_porcentaje.Text);
                oAlterador.dias_gracias = Convert.ToInt32(txt_dias_gracias.Text);
                oAlterador.valor_cuota = Convert.ToDouble(txt_valor_bimensual.Text);
                cAlterador.Modificacion(oAlterador);
                message.Visible = true;
                lb_error.Text = "El valor se ha actualizado correctamente";

                btn_guardar.Enabled = false;
                btn_cancelar.Enabled = false;
                txt_porcentaje.Enabled = false;
                txt_dias_gracias.Enabled = false;
                txt_valor_bimensual.Enabled = false;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            btn_guardar.Enabled = false;
            btn_cancelar.Enabled = false;
            txt_porcentaje.Enabled = false;
            txt_dias_gracias.Enabled = false;
            txt_valor_bimensual.Enabled = false;
        }

        protected void btn_generar_Click(object sender, EventArgs e)
        {
            //FrmImprimirBoleta FormularioImpresionBoleta;
            Modelo_Entidades.CtaCte oCtaCte;
            Modelo_Entidades.Boleta oBoleta;
            Modelo_Entidades.Movimiento oMovimiento;
            Modelo_Entidades.Anual oAnual;
            Modelo_Entidades.Bimensual oBimensual;

            Modelo_Entidades.Auditoria_Cuota oLog_Cuota;

            if (ValidarDatos())
            {
                string tipo_de_cuota = cmb_tipo_matricula.SelectedItem.ToString();

                #region Generación de cuota anual
                if (cmb_cuota.SelectedValue == "Anual") // genero la anual y la 1º
                {
                    tipo_matricula = cmb_tipo_matricula.SelectedItem.ToString();

                    switch (tipo_matricula)
                    {
                        case ("Normal"):

                            foreach (Modelo_Entidades.Profesional oProfesional in cProfesional.ObtenerProfesionalesNormales())
                            {
                                oCtaCte = oProfesional.CtaCte;
                                oBoleta = new Modelo_Entidades.Boleta();
                                oMovimiento = new Modelo_Entidades.Movimiento();
                                oAnual = new Modelo_Entidades.Anual();
                                oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();

                                oMovimiento.fecha = DateTime.Now;
                                oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oAnual).Valor(), 2);
                                oMovimiento.descripcion = "Cuota anual año " + nud_año.Text;
                                oAnual.descripcion = "Cuota anual año " + nud_año.Text;
                                oAnual.estado = false;
                                oAnual.Profesional = oProfesional;
                                cCuota.AgregarCuota(oAnual);

                                #region Audito la cuota
                                oLog_Cuota.estado = false;
                                oLog_Cuota.descripcion = "Cuota anual año " + nud_año.Text;
                                oLog_Cuota.Profesional_dni = oProfesional.dni;
                                oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                oLog_Cuota.fecha = DateTime.Now;
                                oLog_Cuota.accion = "Agregado de cuota anual al profesional " + oProfesional.nombre_apellido;
                                cAuditoria.AuditarCuota(oLog_Cuota);
                                #endregion

                                oMovimiento.CtaCte = oProfesional.CtaCte;
                                oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                                oMovimiento.Comprobante = oBoleta;

                                cMovimiento.Alta(oMovimiento);

                                oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(oMovimiento.importe);
                                cCtaCte.Modificacion(oCtaCte);
                            }

                            Response.Redirect(String.Format("~/Cuotas/FrmImprimirBoleta.aspx?tipo_matricula={0}&menor={1}&mayor={2}&descripcion={3}","1", cCuota.ObtenerCuotas().First().id.ToString(), cCuota.ObtenerCuotas().Last().id.ToString(), "anual"));

                            break;

                        case ("Relación de Dependencia"):

                            foreach (Modelo_Entidades.Profesional oProfesional in cProfesional.ObtenerProfesionalesEnRelacionDeDependencia())
                            {
                                oCtaCte = oProfesional.CtaCte;
                                oBoleta = new Modelo_Entidades.Boleta();
                                oMovimiento = new Modelo_Entidades.Movimiento();
                                oAnual = new Modelo_Entidades.Anual();
                                oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();

                                oMovimiento.fecha = DateTime.Now;
                                oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oAnual).Valor() * 0.7, 2); // EL PORCENTAJE ESTÁ HARKODEADO, DE TODAS FORMAS ESE ES EL VALOR QUE ANUALMENTE EL COLEGIO DISPONE
                                oMovimiento.descripcion = "Cuota anual año " + nud_año.Text;
                                oAnual.descripcion = "Cuota anual año " + nud_año.Text;
                                oAnual.estado = false;
                                oAnual.Profesional = oProfesional;
                                cCuota.AgregarCuota(oAnual);

                                #region Audito la cuota
                                oLog_Cuota.estado = false;
                                oLog_Cuota.descripcion = "Cuota anual año " + nud_año.Text;
                                oLog_Cuota.Profesional_dni = oProfesional.dni;
                                oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                oLog_Cuota.fecha = DateTime.Now;
                                oLog_Cuota.accion = "Agregado de cuota anual al profesional " + oProfesional.nombre_apellido;
                                cAuditoria.AuditarCuota(oLog_Cuota);
                                #endregion

                                oMovimiento.CtaCte = oProfesional.CtaCte;
                                oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                                oMovimiento.Comprobante = oBoleta;

                                cMovimiento.Alta(oMovimiento);

                                oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(oMovimiento.importe);
                                cCtaCte.Modificacion(oCtaCte);
                            }

                            Response.Redirect(String.Format("~/Cuotas/FrmImprimirBoleta.aspx?tipo_matricula={0}&menor={1}&mayor={2}&descripcion={3}", "2", cCuota.ObtenerCuotas().First().id.ToString(),cCuota.ObtenerCuotas().Last().id.ToString(), "anual"));

                            break;

                        case ("Reciprocidad de Matrícula"):

                            foreach (Modelo_Entidades.Profesional oProfesional in cProfesional.ObtenerProfesionalesEnReciprocidadDeMatricula())
                            {
                                oCtaCte = oProfesional.CtaCte;
                                oBoleta = new Modelo_Entidades.Boleta();
                                oMovimiento = new Modelo_Entidades.Movimiento();
                                oAnual = new Modelo_Entidades.Anual();
                                oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();

                                oMovimiento.fecha = DateTime.Now;
                                oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oAnual).Valor(), 2);
                                oMovimiento.descripcion = "Cuota anual año " + nud_año.Text;
                                oAnual.descripcion = "Cuota anual año " + nud_año.Text;
                                oAnual.estado = false;
                                oAnual.Profesional = oProfesional;
                                cCuota.AgregarCuota(oAnual);

                                #region Audito la cuota
                                oLog_Cuota.estado = false;
                                oLog_Cuota.descripcion = "Cuota anual año " + nud_año.Text;
                                oLog_Cuota.Profesional_dni = oProfesional.dni;
                                oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                oLog_Cuota.fecha = DateTime.Now;
                                oLog_Cuota.accion = "Agregado de cuota anual al profesional " + oProfesional.nombre_apellido;
                                cAuditoria.AuditarCuota(oLog_Cuota);
                                #endregion

                                oMovimiento.CtaCte = oProfesional.CtaCte;
                                oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                                oMovimiento.Comprobante = oBoleta;

                                cMovimiento.Alta(oMovimiento);

                                oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                                oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(oMovimiento.importe);
                                cCtaCte.Modificacion(oCtaCte);
                            }

                            Response.Redirect(String.Format("~/Cuotas/FrmImprimirBoleta.aspx?tipo_matricula={0}&menor={1}&mayor={2}&descripcion={3}", "3", cCuota.ObtenerCuotas().First().id.ToString(), cCuota.ObtenerCuotas().Last().id.ToString(), "anual"));

                            break;
                    }
                }
                #endregion

                #region Generación de cuota bimensual
                if (cmb_cuota.SelectedValue == "Bimensual")
                {
                    tipo_matricula = cmb_tipo_matricula.SelectedItem.ToString();

                    switch (tipo_matricula)
                    {
                        case ("Normal"):

                            foreach (Modelo_Entidades.Profesional oProfesional in cProfesional.ObtenerProfesionalesNormales())
                            {
                                oCtaCte = oProfesional.CtaCte;
                                oBoleta = new Modelo_Entidades.Boleta();
                                oMovimiento = new Modelo_Entidades.Movimiento();
                                oBimensual = new Modelo_Entidades.Bimensual();
                                oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();

                                if (cCuota.ObtenerSiElProfPago(oProfesional, "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text, nud_año.Text) == false)
                                {
                                    oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oBimensual).Valor(), 2);
                                    oMovimiento.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                    oBimensual.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                    oBimensual.estado = false;
                                    oBimensual.Profesional = oProfesional;
                                    cCuota.AgregarCuota(oBimensual);

                                    #region Audito la cuota
                                    oLog_Cuota.estado = false;
                                    oLog_Cuota.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                    oLog_Cuota.Profesional_dni = oProfesional.dni;
                                    oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                    oLog_Cuota.fecha = DateTime.Now;
                                    oLog_Cuota.accion = "Agregado de cuota bimensual al profesional " + oProfesional.nombre_apellido;
                                    cAuditoria.AuditarCuota(oLog_Cuota);
                                    #endregion

                                    oMovimiento.fecha = DateTime.Now;
                                    oMovimiento.CtaCte = oProfesional.CtaCte;
                                    oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                                    oMovimiento.Comprobante = oBoleta;

                                    cMovimiento.Alta(oMovimiento);

                                    oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                                    oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(oMovimiento.importe);
                                    cCtaCte.Modificacion(oCtaCte);
                                }
                            }

                            Response.Redirect(String.Format("~/Cuotas/FrmImprimirBoleta.aspx?tipo_matricula={0}&menor={1}&mayor={2}&descripcion={3}", "1", cCuota.ObtenerCuotas().First().id.ToString(), cCuota.ObtenerCuotas().Last().id.ToString(), "/"));


                            break;

                        case ("Relación de Dependencia"):

                            foreach (Modelo_Entidades.Profesional oProfesional in cProfesional.ObtenerProfesionalesEnRelacionDeDependencia())
                            {
                                // Esto verifica si el profesional pagó la anual, no la genere las cuotas bimensuales y el que esté en relación de dependencia, la 5° y 6° cuota no las pague
                                if (cCuota.ObtenerSiElProfPago(oProfesional, "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text, nud_año.Text) == false)
                                {
                                    oCtaCte = oProfesional.CtaCte;
                                    oBoleta = new Modelo_Entidades.Boleta();
                                    oMovimiento = new Modelo_Entidades.Movimiento();
                                    oBimensual = new Modelo_Entidades.Bimensual();
                                    oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();

                                    if (nud_cuontas_numeros.Text != "5" || nud_cuontas_numeros.Text != "6")
                                    {
                                        oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oBimensual).Valor(), 2);
                                        oMovimiento.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                        oBimensual.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                        oBimensual.estado = false;
                                        oBimensual.Profesional = oProfesional;
                                        cCuota.AgregarCuota(oBimensual);

                                        #region Audito la cuota
                                        oLog_Cuota.estado = false;
                                        oLog_Cuota.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                        oLog_Cuota.Profesional_dni = oProfesional.dni;
                                        oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                        oLog_Cuota.fecha = DateTime.Now;
                                        oLog_Cuota.accion = "Agregado de cuota bimensual al profesional " + oProfesional.nombre_apellido;
                                        cAuditoria.AuditarCuota(oLog_Cuota);
                                        #endregion

                                        oMovimiento.fecha = DateTime.Now;
                                        oMovimiento.CtaCte = oProfesional.CtaCte;
                                        oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                                        oMovimiento.Comprobante = oBoleta;

                                        cMovimiento.Alta(oMovimiento);

                                        oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                                        oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(oMovimiento.importe);
                                        cCtaCte.Modificacion(oCtaCte);
                                    }
                                }
                            }

                            Response.Redirect(String.Format("~/Cuotas/FrmImprimirBoleta.aspx?tipo_matricula={0}&menor={1}&mayor={2}&descripcion={3}","2", cCuota.ObtenerCuotas().First().id.ToString(), cCuota.ObtenerCuotas().Last().id.ToString(), "/"));

                            break;

                        case ("Reciprocidad de Matrícula"):

                            foreach (Modelo_Entidades.Profesional oProfesional in cProfesional.ObtenerProfesionalesEnReciprocidadDeMatricula())
                            {
                                // Esto verifica si el profesional pagó la anual, no la genere las cuotas bimensuales y el que esté en relación de dependencia, la 5° y 6° cuota no las pague
                                if (cCuota.ObtenerSiElProfPago(oProfesional, "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text, nud_año.Text) == false)
                                {
                                    oCtaCte = oProfesional.CtaCte;
                                    oBoleta = new Modelo_Entidades.Boleta();
                                    oMovimiento = new Modelo_Entidades.Movimiento();
                                    oBimensual = new Modelo_Entidades.Bimensual();
                                    oLog_Cuota = new Modelo_Entidades.Auditoria_Cuota();

                                    if (nud_cuontas_numeros.Text != "5" || nud_cuontas_numeros.Text != "6")
                                    {
                                        oMovimiento.importe = Math.Round(cCuota.ObtenerValor_Tipo_Couta(oBimensual).Valor(), 2);
                                        oMovimiento.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                        oBimensual.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                        oBimensual.estado = false;
                                        oBimensual.Profesional = oProfesional;
                                        cCuota.AgregarCuota(oBimensual);

                                        #region Audito la cuota
                                        oLog_Cuota.estado = false;
                                        oLog_Cuota.descripcion = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
                                        oLog_Cuota.Profesional_dni = oProfesional.dni;
                                        oLog_Cuota.usuario = oUsuario.nombre_apellido;
                                        oLog_Cuota.fecha = DateTime.Now;
                                        oLog_Cuota.accion = "Agregado de cuota bimensual al profesional " + oProfesional.nombre_apellido;
                                        cAuditoria.AuditarCuota(oLog_Cuota);
                                        #endregion

                                        oMovimiento.fecha = DateTime.Now;
                                        oMovimiento.CtaCte = oProfesional.CtaCte;
                                        oMovimiento.Tipo_Movimiento = cTipo_Movimiento.ObtenerMov_Deudor();
                                        oMovimiento.Comprobante = oBoleta;

                                        cMovimiento.Alta(oMovimiento);

                                        oProfesional.CtaCte.Movimientos.Add(oMovimiento);

                                        oCtaCte.saldo = oCtaCte.saldo - Convert.ToDecimal(oMovimiento.importe);
                                        cCtaCte.Modificacion(oCtaCte);
                                    }
                                }
                            }

                            Response.Redirect(String.Format("~/Cuotas/FrmImprimirBoleta.aspx?tipo_matricula={0}&menor={1}&mayor={2}&descripcion={3}", "3", cCuota.ObtenerCuotas().First().id.ToString(), cCuota.ObtenerCuotas().Last().id.ToString(), "/"));

                            break;
                    }
                }
                # endregion

            }
        }

        protected void btn_corrimiento_Click(object sender, EventArgs e)
        {
            foreach (Modelo_Entidades.Profesional oProfesional in cProfesional.ObtenerProfesionales())
            {
                // Si no pagó la 1º o la anual (= false), lo inhabilito 
                if (cCuota.ObtenerSiElProfPago(oProfesional, ("Cuota " + "1" + "/" + nud_año_corrimiento.Text), nud_año.Text) == false)
                {
                    oProfesional.Estado = cEstado.ObtenerEstadoNoHabilitado();
                    cProfesional.Modificacion(oProfesional);
                }
            }

            message.Visible = true;
            lb_error.Text = "El corrimiento se ha efectuado correctamente";
        }

        // Valido los datos
        private bool ValidarDatos()
        {
            // Obtención del nombre de la cuota
            if (cmb_cuota.SelectedValue == "Anual")
            {
                desc = "Cuota anual año " + nud_año.Text;
            }

            if (cmb_cuota.SelectedValue == "Bimensual")
            {
                desc = "Cuota " + nud_cuontas_numeros.Text + "/" + nud_año.Text;
            }

            // Validaciones
            if (nud_año.Text == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el año para la cuota";
                return false;
            }

            if (cmb_cuota.SelectedValue == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar al menos un tipo de cuota";
                return false;
            }

            if (cmb_cuota.SelectedValue == "Bimensual" && nud_cuontas_numeros.Text == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el número de la cuota";
                return false;
            }

            string tipo_de_cuota = cmb_tipo_matricula.SelectedItem.ToString();
            switch (tipo_de_cuota)
            {
                case ("Normal"):
                    if (cMovimiento.BuscarCuotaNormalGenerada(desc) == true)
                    {
                        message.Visible = true;
                        lb_error.Text = "La cuota ya fue generada, por favor seleccione otra cuota";
                        return false;
                    }

                    break;

                case ("Relación de Dependencia"):
                    if (cMovimiento.BuscarCuotaEnRelGenerada(desc) == true)
                    {
                        message.Visible = true;
                        lb_error.Text = "La cuota ya fue generada, por favor seleccione otra cuota";
                        return false;
                    }

                    break;

                case ("Reciprocidad de Matrícula"):
                    if (cMovimiento.BuscarCuotaEnReciprocidadGenerada(desc) == true)
                    {
                        message.Visible = true;
                        lb_error.Text = "La cuota ya fue generada, por favor seleccione otra cuota";
                        return false;
                    }

                    break;
            }

            return true;
        }

        // valido datos
        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(txt_porcentaje.Text))
            {
                message.Visible = false;
                lb_error.Text = "Debe ingresar el porcentaje";
                return false;
            }

            if (string.IsNullOrEmpty(txt_dias_gracias.Text))
            {
                message.Visible = false;
                lb_error.Text = "Debe ingresar los días de gracia";
                return false;
            }

            if (string.IsNullOrEmpty(txt_valor_bimensual.Text))
            {
                message.Visible = false;
                lb_error.Text = "Debe ingresar el valor de la cuota";
                return false;
            }
            return true;
        }
    }
}