using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cPerfil
    {
        // Declaración de variables a usar en la clase
        private static cPerfil instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        //Aplico el patron de diseño Singleton para la clase cPerfil (cuando la solicitan desde otra)
        public static cPerfil ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cPerfil();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cPerfil()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtengo los módulos según el grupo del usuario
        public List<Modelo_Entidades.Modulo> ObtenerModulosPorGrupo(int grupo)
        {
            var Consulta = from oPerfil in oModelo_Entidades.Perfiles.ToList()
                           where oPerfil.Grupo.id == grupo 
                           group oPerfil by oPerfil.Formulario.Modulo into Modulos
                           select Modulos.Key;
            return (List<Modelo_Entidades.Modulo>)Consulta.ToList();
        }

        // Obtengo los formulario según el grupo del usuario
        public List<Modelo_Entidades.Formulario> ObtenerFormulariosPorGrupo(int grupo)
        {
            var Consulta = from oPerfil in oModelo_Entidades.Perfiles.ToList()
                           where oPerfil.Grupo.id == grupo
                           group oPerfil by oPerfil.Formulario into Perfiles
                           select Perfiles.Key;
            return (List<Modelo_Entidades.Formulario>)Consulta.ToList();
        }

        // Obtengo los formularios según modulo al que pertenecen
        public List<Modelo_Entidades.Formulario> ObtenerFormulariosPorModulo(Modelo_Entidades.Modulo oModulo)
        {
            var Consulta = from oPerfil in oModelo_Entidades.Perfiles.ToList()
                           where oPerfil.Formulario.Modulo == oModulo
                           group oPerfil by oPerfil.Formulario into Formularios
                           select Formularios.Key;
            return (List<Modelo_Entidades.Formulario>)Consulta.ToList();
        }

        // Obtengo los permisos según el grupo del usuario y el formulario seleccionado
        public List<Modelo_Entidades.Permiso> ObtenerPermisos(int grupo, string formulario)
        {
            var Consulta = from oPerfil in oModelo_Entidades.Perfiles.ToList()
                           where oPerfil.Grupo.id == grupo && oPerfil.Formulario.descripcion == formulario
                           select oPerfil.Permiso;
            return (List<Modelo_Entidades.Permiso>)Consulta.ToList();
        }

        // Elimino un perfil
        public void BajaPerfil(Modelo_Entidades.Perfil oPerfil)
        {
            oPerfil.Baja(oPerfil);
        }

        //Agrego un perfil
        public void AltaPerfil(Modelo_Entidades.Perfil oPerfil)
        {
            oPerfil.Alta(oPerfil);
        }

        // Obtengo los perfiles
        public List<Modelo_Entidades.Perfil> ObtenerPerfiles()
        {
            return oModelo_Entidades.Perfiles.ToList();
        }

        public Modelo_Entidades.Perfil ObtenerPerfil(int perfil)
        {
            Modelo_Entidades.Perfil oPerfil = oModelo_Entidades.Perfiles.ToList().Find(delegate(Modelo_Entidades.Perfil fPerfil)
            {
                return fPerfil.id == perfil;
            });

            return oPerfil;
        }

        // Valido que no exista un perfil dado el grupo, formulario y permiso
        public Boolean ValidarPerfil(Modelo_Entidades.Grupo oGrupo, Modelo_Entidades.Formulario oFormulario, Modelo_Entidades.Permiso oPermiso)
        {
            Modelo_Entidades.Perfil oPerfil = oModelo_Entidades.Perfiles.ToList().Find(delegate(Modelo_Entidades.Perfil fPerfil)
            {
                return fPerfil.Grupo == oGrupo && fPerfil.Formulario == oFormulario && fPerfil.Permiso == oPermiso;
            });

            if (oPerfil == null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        // Metodo de validación general para todos los perfiles
        public List<Modelo_Entidades.Perfil> FiltrarPerfiles(string grupo, string formulario, string permiso)
        {
            var Consulta = from oPerfil in oModelo_Entidades.Perfiles.ToList()
                           select oPerfil;

            if (grupo != "0")
            {
                Consulta = Consulta.Where(oPerfil => oPerfil.Grupo.descripcion == grupo);
            }

            if (formulario != "0")
            {
                Consulta = Consulta.Where(oPerfil => oPerfil.Formulario.nombredemuestra == formulario);
            }

            if (permiso != "0")
            {
                Consulta = Consulta.Where(oPerfil => oPerfil.Permiso.descripcion == permiso);
            }

            return (List<Modelo_Entidades.Perfil>)Consulta.ToList();
        }
    }
}
