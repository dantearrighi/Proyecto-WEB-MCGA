using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Botoneras
{
    public delegate void Eventos_Botonera(object sender, EventArgs e);

    public partial class Botonera1 : System.Web.UI.UserControl
    {
        public event Eventos_Botonera Click_Alta;
        public event Eventos_Botonera Click_Baja;
        public event Eventos_Botonera Click_Modificacion;
        public event Eventos_Botonera Click_Consulta;
        public event Eventos_Botonera Click_Cerrar;

        Controladora.cPerfil cPerfil;
        Controladora.cGrupo cGrupo;
        Controladora.cUsuario cUsuario;

        public Botonera1()
        {
            cPerfil = Controladora.cPerfil.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            Click_Alta(sender, e);
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            Click_Baja(sender, e);
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            Click_Modificacion(sender, e);
        }

        protected void btn_verdetalle_Click(object sender, EventArgs e)
        {
            Click_Consulta(sender, e);
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            Click_Cerrar(sender, e);
        }

        public void ArmaPerfil(Modelo_Entidades.Usuario oUsuario, string form)
        {
            cPerfil = Controladora.cPerfil.ObtenerInstancia();
            cGrupo = Controladora.cGrupo.ObtenerInstancia();
            cUsuario = Controladora.cUsuario.ObtenerInstancia();

            btn_agregar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
            btn_verdetalle.Enabled = false;

            try
            {
                foreach (Modelo_Entidades.Grupo oGrupo in cUsuario.ObtenerGruposUsuario(oUsuario.id))
                {
                    foreach (Modelo_Entidades.Permiso oPermiso in cPerfil.ObtenerPermisos(oGrupo.id, form))
                    {
                        switch (oPermiso.descripcion)
                        {
                            case "Alta":
                                if (form == "FrmAuditorias")
                                {
                                    btn_agregar.Visible = false;
                                }

                                btn_agregar.Enabled = true;
                                break;

                            case "Baja":
                                if (form == "FrmProfesionales" || form == "FrmExpedientes" || form == "FrmAuditorias")
                                {
                                    btn_eliminar.Visible = false;
                                }

                                btn_eliminar.Enabled = true;
                                break;

                            case "Modifica":
                                if (form == "FrmAuditorias" || form == "FrmPerfiles")
                                {
                                    btn_modificar.Visible = false;
                                }

                                btn_modificar.Enabled = true;

                                break;

                            case "Consulta":
                                btn_verdetalle.Enabled = true;
                                break;
                        }
                    }
                }
            }

            catch (Exception Exc)
            {
                throw new Exception(Exc.Message);
            }
        }
    }
}