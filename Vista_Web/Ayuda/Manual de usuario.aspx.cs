using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;

namespace Vista_Web
{
    public partial class ManualUsuario : System.Web.UI.Page
    {
        Controladora.cUsuario cUsuario;
        Controladora.cVideo cVideo;

        Modelo_Entidades.Usuario oUsuario;
        List<Modelo_Entidades.Usuario> lUsuarios;
        Modelo_Entidades.Comitente oComitente;
        List<Modelo_Entidades.Video> lVideos;
        string video;
        string modo;

        // Constructor
        public ManualUsuario()
        {
            cUsuario = Controladora.cUsuario.ObtenerInstancia();
            cVideo = Controladora.cVideo.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.Usuario)HttpContext.Current.Session["sUsuario"];
            }
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
            lVideos = cVideo.ObtenerVideoes();
            gvUsuarios.DataSource = lVideos;
            gvUsuarios.DataBind();
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            gvUsuarios.DataSource = cVideo.FiltrarPorDesc(txt_nombre.Text);
            gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[1].Text = "ID";
            //e.Row.Cells[2].Text = "Razón social";
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            video = gvUsuarios.SelectedRow.Cells[3].Text;
            Process.Start(video);
        }
    }
}