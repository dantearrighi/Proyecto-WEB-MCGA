using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cGrupo
    {
        // Declaración de variables a usar en la clase
        private static cGrupo instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        //Aplico el patron de diseño Singleton para la clase cGrupo (cuando la solicitan desde otra)
        public static cGrupo ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cGrupo();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cGrupo()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtengo los grupos
        public List<Modelo_Entidades.Grupo> ObtenerGrupos()
        {
            return oModelo_Entidades.Grupos.ToList();
        }

        // Elimino a un grupo
        public void EliminarGrupo(Modelo_Entidades.Grupo oGrupo)
        {
            oGrupo.Baja(oGrupo);
        }

        // Agrego un grupo
        public void AgregarGrupo(Modelo_Entidades.Grupo oGrupo)
        {
            oGrupo.Alta(oGrupo);
        }

        // Busco a un título por su ID y lo devuelvo
        public Modelo_Entidades.Grupo BuscarGrupoPorId(int id)
        {
            // Busca el grupo por la descripcion y lo devuelve.
            Modelo_Entidades.Grupo oGrupo = oModelo_Entidades.Grupos.ToList().Find(delegate(Modelo_Entidades.Grupo fGrupo)
            {
                return fGrupo.id == id;
            });

            return oGrupo;
        }

        // Busco a un título por su decripcion
        public Modelo_Entidades.Grupo BuscarGrupoPorDesc(string grupo)
        {
            // Busca el grupo por la descripcion y lo devuelve.
            Modelo_Entidades.Grupo oGrupo = oModelo_Entidades.Grupos.ToList().Find(delegate(Modelo_Entidades.Grupo fGrupo)
            {
                return fGrupo.descripcion.Contains(grupo);
            });

            return oGrupo;
        }

        // Modifico un grupo
        public void ModificarGrupo(Modelo_Entidades.Grupo oGrupo)
        {
            oGrupo.Modificacion(oGrupo);
        }

        // Busco los grupos por una descripción parcial
        public List<Modelo_Entidades.Grupo> FiltrarGrupos(string texto)
        {
            var Consulta = from oGrupo in oModelo_Entidades.Grupos.ToList()
            where oGrupo.descripcion.Contains(texto)
            select oGrupo;
            return (List<Modelo_Entidades.Grupo>)Consulta.ToList();
        }

        // Busco los grupos dado un usuario
        public List<Modelo_Entidades.Grupo> BuscarGruposdelUsuario(Modelo_Entidades.Usuario miUsuario)
        {
            var Consulta = from oGrupo in oModelo_Entidades.Grupos.ToList()
                           where oGrupo.Usuarios.Contains(miUsuario)
                           select oGrupo;
            return (List<Modelo_Entidades.Grupo>)Consulta.ToList();
        }

        // Valido que no exista un grupo dado el nombre del grupo
        public Boolean ValidarGrupo(string grupo)
        {
            Modelo_Entidades.Grupo oGrupo = oModelo_Entidades.Grupos.ToList().Find(delegate(Modelo_Entidades.Grupo fGrupo)
            {
                return fGrupo.descripcion == grupo;
            });

            if (oGrupo == null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        // Valido que no un grupo no tengo miembros asociados
        public Boolean ValidarMiembrosGrupo(Modelo_Entidades.Grupo oGrup)
        {
            Modelo_Entidades.Grupo oGrupo = oModelo_Entidades.Grupos.ToList().Find(delegate(Modelo_Entidades.Grupo fGrupo)
            {
                return fGrupo == oGrup;
            });

            if (oGrupo.Usuarios.Count == 0 && oGrupo.Perfiles.Count == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}

