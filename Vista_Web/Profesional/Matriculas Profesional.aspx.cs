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
    public partial class Matriculas_Profesional : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string modo_matricula;
        string matricula;
        string profesional;
        string titulo;
        string universidad;
        string plan;
        string usuario;

        Controladora.cUniversidad cUniversidad;
        Controladora.cTitulo cTitulo;
        Controladora.cPlan cPlan;
        Controladora.cVerificacion cVerificacion;
        Controladora.cMatricula cMatricula;
        Controladora.cLegajo_Academico cLegajo_Academico;
        Controladora.cProfesional cProfesional;

        Modelo_Entidades.Universidad oUniversidad;
        Modelo_Entidades.Titulo oTitulo;
        Modelo_Entidades.Plan oPlan;
        Modelo_Entidades.Matricula oMatricula;
        Modelo_Entidades.Legajo_Academico oLegajo_Academico;
        Modelo_Entidades.Profesional oProfesional;
        Modelo_Entidades.Usuario oUsuario;

        List<Modelo_Entidades.Universidad> lUniversidades;
        List<Modelo_Entidades.Titulo> lTitulos;
        List<Modelo_Entidades.Plan> lPlanes;

        // Constructor
        public Matriculas_Profesional()
        {
            cUniversidad = Controladora.cUniversidad.ObtenerInstancia();
            cTitulo = Controladora.cTitulo.ObtenerInstancia();
            cPlan = Controladora.cPlan.ObtenerInstancia();
            cVerificacion = Controladora.cVerificacion.ObtenerInstancia();
            cMatricula = Controladora.cMatricula.ObtenerInstancia();
            cLegajo_Academico = Controladora.cLegajo_Academico.ObtenerInstancia();
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            matricula = Server.UrlDecode(Request.QueryString["matricula"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);
            profesional = Server.UrlDecode(Request.QueryString["profesional"]);
            modo_matricula = Server.UrlDecode(Request.QueryString["modo_matricula"]);

            oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
            usuario = oUsuario.usuario;

            if (matricula == "nuevo")
            {
                oMatricula = new Modelo_Entidades.Matricula();
                oLegajo_Academico = new Modelo_Entidades.Legajo_Academico();
            }
            else
            {
                oMatricula = cMatricula.BuscarMatriculaPorId(Convert.ToInt32(matricula));
                oLegajo_Academico = oMatricula.Legajo_Academico;
                oTitulo = oLegajo_Academico.Titulo;
            }

            oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));

            message.Visible = false;

            if (modo != "Alta")
            {
                if (oMatricula.certificado == true)
                {
                    diploma.SelectedValue = "Diploma";
                }

                else
                {
                    diploma.SelectedValue = "Certificado";
                }

                txt_fechadoc.Text = oMatricula.fecha_doc.ToString();

                if (oMatricula.incumbencia == true)
                {
                    chk_incumbencias.Checked = true;
                }

                else
                {
                    chk_incumbencias.Checked = false;
                }

                if (oMatricula.plan == true)
                {
                    chk_plan.Checked = true;
                }

                else
                {
                    chk_plan.Checked = false;
                }

                if (oMatricula.analitico == true)
                {
                    chk_analitico.Checked = true;
                }

                else
                {
                    chk_analitico.Checked = false;
                }

                if (modo == "Consulta")
                {
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargaDatos();
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Profesional/Profesional.aspx?profesional={0}&modo={1}&usuario={2}", Server.UrlEncode(profesional), Server.UrlEncode(modo), Server.UrlEncode(usuario)));
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios())
            {
                titulo = cmb_titulos.SelectedValue.ToString();
                oTitulo = cTitulo.ObtenerTituloPorDesc(titulo);
                oLegajo_Academico.Titulo = oTitulo;

                plan = cmb_planes.SelectedValue.ToString();
                oPlan = cPlan.ObtenerPlanPorDesc(plan);
                oLegajo_Academico.Plan = oPlan;

                oMatricula.Legajo_Academico = oLegajo_Academico;

                if (diploma.SelectedValue == "Certificado")
                {
                    oMatricula.certificado = true;
                }

                else
                {
                    oMatricula.certificado = false;
                }

                oMatricula.fecha_doc = Convert.ToDateTime(txt_fechadoc.Text);

                if (chk_incumbencias.Checked == true)
                {
                    oMatricula.incumbencia = true;
                }

                else
                {
                    oMatricula.incumbencia = false;
                }

                if (chk_plan.Checked == true)
                {
                    oMatricula.plan = true;
                }

                else
                {
                    oMatricula.plan = false;
                }

                if (chk_analitico.Checked == true)
                {
                    oMatricula.analitico = true;
                }

                else
                {
                    oMatricula.analitico = false;
                }

                // Finalmente, agrego al profesional
                oMatricula.Profesional = oProfesional;

                int id = (cMatricula.ObtenerUltimoId()).id + 1;
                string digito = cVerificacion.AddCheckDigit(id.ToString());

                if (modo_matricula == "Alta")
                {
                    if (oProfesional.CtaCte == null)
                    {
                        switch (oProfesional.Matriculas.Count)
                        {
                            case 1:
                                break;
                            case 2: id = id + 1;
                                break;
                            case 3: id = id + 2;
                                break;
                            case 4: id = id + 3;
                                break;
                        }

                        switch (id.ToString().Length)
                        {
                            case 1: oMatricula.icie = "2-" + "000" + id.ToString() + "-" + digito;
                                break;
                            case 2: oMatricula.icie = "2-" + "00" + id.ToString() + "-" + digito;
                                break;
                            case 3: oMatricula.icie = "2-" + "0" + id.ToString() + "-" + digito;
                                break;
                            case 4: oMatricula.icie = "2-" + id.ToString() + "-" + digito;
                                break;
                        }
                    }

                    else
                    {
                        switch (id.ToString().Length)
                        {
                            case 1: oMatricula.icie = "2-" + "000" + id.ToString() + "-" + digito;
                                break;
                            case 2: oMatricula.icie = "2-" + "00" + id.ToString() + "-" + digito;
                                break;
                            case 3: oMatricula.icie = "2-" + "0" + id.ToString() + "-" + digito;
                                break;
                            case 4: oMatricula.icie = "2-" + id.ToString() + "-" + digito;
                                break;
                        }

                        cMatricula.Alta(oMatricula);
                        Response.Redirect(String.Format("~/Profesional/Profesional.aspx?profesional={0}&modo={1}&usuario={2}", Server.UrlEncode(profesional), Server.UrlEncode(modo), Server.UrlEncode(usuario)));
                    }
                }

                else
                {
                    cMatricula.Modificacion(oMatricula);
                    Response.Redirect(String.Format("~/Profesional/Profesional.aspx?profesional={0}&modo={1}&usuario={2}", Server.UrlEncode(profesional), Server.UrlEncode(modo), Server.UrlEncode(usuario)));
                }
            }
            
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (cmb_universidad.SelectedItem == null)
            {
                lb_error.Text = "Debe ingresar una universidad";
                return false;
            }

            if (cmb_titulos.SelectedItem == null)
            {
                lb_error.Text = "Debe ingresar un título";
                return false;
            }

            if (cmb_planes.SelectedItem == null)
            {
                lb_error.Text = "Debe ingresar un plan";
                return false;
            }

            if (string.IsNullOrEmpty(txt_fechadoc.Text))
            {
                lb_error.Text = "Debe ingresar la fecha del documento presentado por el profesional";
                return false;
            }

            if (chk_incumbencias.Checked == false || chk_plan.Checked == false || chk_analitico.Checked == false)
            {
                lb_error.Text = "El profesional no cumple con todos los requisitos de matriculación.";
                return false;
            }

            titulo = cmb_titulos.SelectedValue.ToString();
            oTitulo = cTitulo.ObtenerTituloPorDesc(titulo);
            
            universidad = cmb_universidad.SelectedValue.ToString();
            oUniversidad = cUniversidad.ObtenerUnivPorDesc(universidad);

            if (modo == "Alta")
            {
                if (cLegajo_Academico.ObtenerSiElProfTieneTit(oProfesional, oTitulo.id, oUniversidad.id) == false)
                {
                    lb_error.Text = "El profesional ya posee ese título.";
                    return false;
                }
            }
                

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            lUniversidades = cUniversidad.ObtenerUniversidades();
            cmb_universidad.DataSource = lUniversidades;
            cmb_universidad.DataBind();
            cmb_universidad.Items.Insert(0, new ListItem(String.Empty, String.Empty));

            lTitulos = cTitulo.ObtenerTitulos();
            cmb_titulos.DataSource = lTitulos;
            cmb_titulos.DataBind();
            cmb_titulos.Items.Insert(0, new ListItem(String.Empty, String.Empty));

            lPlanes = cLegajo_Academico.BuscarPlanesPorTit(oTitulo);
            cmb_planes.DataSource = lPlanes;
            cmb_planes.DataBind();
            cmb_planes.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            

            if (modo_matricula == "Alta")
            {
                cmb_universidad.SelectedIndex = 0;
                cmb_titulos.SelectedIndex = 0;
                cmb_planes.SelectedIndex = 0;
            }

            else
            {
                cmb_universidad.SelectedValue = oLegajo_Academico.Titulo.Universidad.descripcion;
                cmb_titulos.SelectedValue = oLegajo_Academico.Titulo.descripcion;
                cmb_planes.SelectedValue = oLegajo_Academico.Plan.año;
            }
        }

        protected void cmb_universidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            universidad = cmb_universidad.SelectedValue.ToString();
            oUniversidad = cUniversidad.ObtenerUnivPorDesc(universidad);
            
            if (oUniversidad != null)
            {
                lTitulos = cTitulo.BuscarTitulosPorUni(oUniversidad);
                cmb_titulos.DataSource = lTitulos;
                cmb_titulos.DataBind();
                cmb_titulos.Items.Add("");
                cmb_titulos.SelectedValue = "";
            }
        }

        protected void cmb_titulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            titulo = cmb_titulos.SelectedValue.ToString();
            oTitulo = cTitulo.ObtenerTituloPorDesc(titulo);
            
            if (oTitulo != null)
            {
                lPlanes = cLegajo_Academico.BuscarPlanesPorTit(oTitulo);
                cmb_planes.DataSource = lPlanes;
                cmb_planes.DataBind();
                cmb_planes.Items.Add("");
                cmb_planes.SelectedValue = "";
            }
        }

        protected void cmb_planes_SelectedIndexChanged(object sender, EventArgs e)
        {
            plan = cmb_planes.SelectedValue.ToString();
            oPlan = cPlan.ObtenerPlanPorDesc(plan);
        }
    }
}