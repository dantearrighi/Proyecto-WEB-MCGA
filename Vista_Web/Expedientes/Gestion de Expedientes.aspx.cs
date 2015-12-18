using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Vista_Web
{
    public partial class Expedientes : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cTipo_Movimiento cTipo_Movimiento;
        Controladora.cMovimiento cMovimiento;
        Controladora.cTarea cTarea;
        Controladora.cProfesional cProfesional;
        Controladora.cExpediente cExpediente;
        Controladora.cComitente cComitente;

        Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.OI oOI;
        Modelo_Entidades.FE oFE;
        Modelo_Entidades.HM oHM;
        Modelo_Entidades.Expediente oExpediente;
        Modelo_Entidades.Comitente oComitente;
        Modelo_Entidades.Tarea oTarea;

        List<Modelo_Entidades.Expediente> lExpedientes;

        string usuario;
        string expediente;
        string modo;
        string tipo;
        string comitente;
        string tarea;

        // Constructor
        public Expedientes()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cMovimiento = Controladora.cMovimiento.ObtenerInstancia();
            cTipo_Movimiento = Controladora.cTipo_Movimiento.ObtenerInstancia();
            cTarea = Controladora.cTarea.ObtenerInstancia();
            cProfesional = Controladora.cProfesional.ObtenerInstancia();
            cExpediente = Controladora.cExpediente.ObtenerInstancia();
            cComitente = Controladora.cComitente.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "FrmExpedientes");
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
            message.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvExpedientes.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un expediente";
            }

            else
            {
                expediente = gvExpedientes.SelectedRow.Cells[1].Text;
                modo = "Consulta";
                tipo = gvExpedientes.SelectedRow.Cells[5].Text;

                Response.Redirect(String.Format("~/Expedientes/Expediente.aspx?expediente={0}&modo={1}&tipo_expediente={2}", Server.UrlEncode(expediente), Server.UrlEncode(modo), Server.UrlEncode(tipo)));
            }
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvExpedientes.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un expediente";
            }

            else
            {
                expediente = gvExpedientes.SelectedRow.Cells[1].Text;
                modo = "Modifica";

                tipo = gvExpedientes.SelectedRow.Cells[5].Text;

                Response.Redirect(String.Format("~/Expedientes/Expediente.aspx?expediente={0}&modo={1}&tipo_expediente={2}", Server.UrlEncode(expediente), Server.UrlEncode(modo), Server.UrlEncode(tipo)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }

        private DataTable ToDataTable(List<Modelo_Entidades.Expediente> Expedientes)
        {
            DataTable returnTable = new DataTable("Expedientes");
            returnTable.Columns.Add(new DataColumn("Número"));
            returnTable.Columns.Add(new DataColumn("Estado"));
            returnTable.Columns.Add(new DataColumn("Profesional"));
            returnTable.Columns.Add(new DataColumn("Comitente"));
            returnTable.Columns.Add(new DataColumn("Obra"));
            returnTable.Columns.Add(new DataColumn("Tarea"));
            //returnTable.Columns.Add(new DataColumn("Fecha de devolución"));
            //returnTable.Columns.Add(new DataColumn("Fecha de recepción"));
            //returnTable.Columns.Add(new DataColumn("Fecha de aprobación"));
            //returnTable.Columns.Add(new DataColumn("Fecha de pago"));
            

            foreach (Modelo_Entidades.Expediente unExpediente in Expedientes)
            {
                returnTable.AcceptChanges();
                DataRow row = returnTable.NewRow();
                row[0] = unExpediente.numero;
                row[1] = unExpediente.estado;
                row[2] = unExpediente.Profesionales.First().nombre_apellido;
                row[3] = unExpediente.Comitente.razon_social;

                switch (unExpediente.GetType().ToString())
                {
                    case ("Modelo_Entidades.HM"):
                        row[4] = "HM";
                        break;
                    case ("Modelo_Entidades.FE"):
                        row[4] = "FE";
                        break;
                    case ("Modelo_Entidades.OI"):
                        row[4] = "OI";
                        break;
                }
                
                row[5] = unExpediente.Tarea.descripcion;

                returnTable.Rows.Add(row);
            }

            return returnTable;
        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            lExpedientes = cExpediente.ObtenerExpedientes().OrderBy(x => x.numero).ToList();
            gvExpedientes.DataSource = this.ToDataTable(lExpedientes);
            gvExpedientes.DataBind();

            // Finalmente limpio los txts
            txt_nya_comitente.Text = "";
            txt_profesional.Text = "";

            cmb_obra.SelectedIndex = 0;

            cmb_descripcion_tarea.Items.Clear();
            cmb_descripcion_tarea.DataBind();
            cmb_descripcion_tarea.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_descripcion_tarea.SelectedIndex = 0;

            message.Visible = false;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            string VarCombo_Obras;
            string VarCombo_Tareas;
            string nya_profesional;
            string nya_comitente;

            if (cmb_obra.SelectedItem == null)
            {
                VarCombo_Obras = "0";
            }

            else
            {
                VarCombo_Obras = cmb_obra.SelectedItem.Text;
            }

            if (cmb_descripcion_tarea.SelectedItem == null)
            {
                VarCombo_Tareas = "0";
            }

            else
            {
                VarCombo_Tareas = cmb_descripcion_tarea.SelectedItem.Text;
            }

            if (txt_profesional.Text == "")
            {
                nya_profesional = "0";
            }

            else
            {
                Modelo_Entidades.Profesional oProf = cProfesional.ObtenerProfesional(Convert.ToInt32(txt_profesional.Text));

                if (oProf != null)
                {
                    nya_profesional = txt_profesional.Text;
                }

                else
                {
                    nya_profesional = "0";

                    //message.Visible = true;
                    //lb_error.Text = "El profesional no registra ningún expediente";
                }
            }

            if (txt_nya_comitente.Text == "")
            {
                nya_comitente = "0";
            }

            else
            {
                nya_comitente = txt_nya_comitente.Text;
            }

            lExpedientes = cExpediente.FiltrarExpedientes(nya_profesional, nya_comitente, VarCombo_Obras, VarCombo_Tareas);
            gvExpedientes.DataSource = this.ToDataTable(lExpedientes);
            gvExpedientes.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            //expediente = "nuevo";
            modo = "Alta";
            tipo = cmb_nuevo_expediente.Text;

            switch (tipo)
            {
                case ("Honorario Mínimo"):
                    tipo = "HM";
                    oHM = new Modelo_Entidades.HM();
                    oExpediente = oHM;
                    
                    oComitente = cComitente.ObtenerComitente(6);
                    oExpediente.Comitente = oComitente;
                    comitente = oComitente.razon_social;
                    oTarea = cTarea.ObtenerTarea(6);
                    oExpediente.Tarea = oTarea;
                    tarea = oTarea.descripcion;
                    oExpediente.estado = "Recibido";

                    cExpediente.AgregarExpediente(oExpediente);
                    expediente = oExpediente.numero.ToString();
                    break;
                case ("Fuerza Electromotriz"):
                    tipo = "FE";
                    oFE = new Modelo_Entidades.FE();
                    oExpediente = oFE;
                    
                    oComitente = cComitente.ObtenerComitente(6);
                    oExpediente.Comitente = oComitente;
                    comitente = oComitente.razon_social;
                    oTarea = cTarea.ObtenerTarea(6);
                    oExpediente.Tarea = oTarea;
                    tarea = oTarea.descripcion;
                    oExpediente.estado = "Recibido";

                    cExpediente.AgregarExpediente(oExpediente);
                    expediente = oExpediente.numero.ToString();
                    break;
                case ("Obras de Ingenieria"):
                    tipo = "OI";
                    oOI = new Modelo_Entidades.OI();
                    oExpediente = oOI;
                    
                    oComitente = cComitente.ObtenerComitente(6);
                    oExpediente.Comitente = oComitente;
                    comitente = oComitente.razon_social;
                    oTarea = cTarea.ObtenerTarea(6);
                    oExpediente.Tarea = oTarea;
                    tarea = oTarea.descripcion;
                    oExpediente.estado = "Recibido";

                    cExpediente.AgregarExpediente(oExpediente);
                    expediente = oExpediente.numero.ToString();
                    break;
            }

            Response.Redirect(String.Format("~/Expedientes/Expediente.aspx?expediente={0}&modo={1}&tipo_expediente={2}&comitente={3}&tarea={4}", Server.UrlEncode(expediente), Server.UrlEncode(modo), Server.UrlEncode(tipo), Server.UrlEncode(comitente), Server.UrlEncode(tarea)));
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void gvExpedientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void cmb_obra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_obra.SelectedItem != null)
            {
                cmb_descripcion_tarea.Items.Clear();
                cmb_descripcion_tarea.DataSource = cTarea.BuscarTareasPorObra(cmb_obra.SelectedItem.ToString());
                cmb_descripcion_tarea.DataBind();
            }

            else
            {
                cmb_descripcion_tarea.Items.Clear();
                cmb_descripcion_tarea.DataBind();
                cmb_descripcion_tarea.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                cmb_descripcion_tarea.SelectedIndex = 0;
            }
        }
    }
}