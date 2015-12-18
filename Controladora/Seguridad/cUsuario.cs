using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Controladora
{
    public class cUsuario
    {
        // Declaro las variables a utilizar en la clase
        private static cUsuario instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;
        Controladora.cEncriptacion cEncriptacion = new cEncriptacion();

        // Aplico el patrón de diseño Singleton a la clase
        public static cUsuario ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cUsuario();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cUsuario()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Busco al usuario 
        public Modelo_Entidades.Usuario ObtenerUsuario(string usuario)
        {
            Modelo_Entidades.Usuario oUsuario = oModelo_Entidades.Usuarios.ToList().Find(delegate(Modelo_Entidades.Usuario fUsuario)
            {
                return fUsuario.usuario == usuario;
            });

            return oUsuario;
        }

        // Busco al usuario 
        public Modelo_Entidades.Usuario ObtenerUsuarioPorNyA(string usuario)
        {
            Modelo_Entidades.Usuario oUsuario = oModelo_Entidades.Usuarios.ToList().Find(delegate(Modelo_Entidades.Usuario fUsuario)
            {
                return fUsuario.nombre_apellido == usuario;
            });

            return oUsuario;
        }
        
        // Método para la generación de la contraseña al azar
        private string GenerarClaveAleatoria(int caracteres, bool minusculas)
        {
            StringBuilder constructor = new StringBuilder();
            Random numeroalazar = new Random(DateTime.Now.Millisecond); // generar con el milisegundo actual como semilla
            char caracter;
            for (int i = 0; i < caracteres; i++)
            {
                caracter = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * numeroalazar.NextDouble() + 65)));
                constructor.Append(caracter);
            }
            if (minusculas)
            {
                return constructor.ToString().ToLower();
            }
            else
            {
                return constructor.ToString();
            }
        }

        // Generar una clave al azar para la creación del usuario
        public void ResetearClave(Modelo_Entidades.Usuario oUsuario, string email) 
        {
            //generar una clave aleatoria
            oUsuario.clave = GenerarClaveAleatoria(8, false);
            //enviar la clave sin encriptar por mail

            string De = "gestioncolegioingenieros@gmail.com";
            string Password = "aguirregil";
            string Para = email;
            string Mensaje = "Bienvenido al sistema. Su nombre de usuario es " + oUsuario.usuario + " y su clave temporal es " + oUsuario.clave + ". Por favor cambie su clave la primera vez que entre al sistema.";
            string Asunto = "Usuario y Contraseña para el sistema";
            System.Net.Mail.MailMessage Email;

            Email = new System.Net.Mail.MailMessage(De, Para, Asunto, Mensaje);
            /*
            System.Net.Mail.SmtpClient smtpMail = new System.Net.Mail.SmtpClient("smtp.gmail.com"); 
            Email.IsBodyHtml = false; 
            smtpMail.EnableSsl = true; 
            smtpMail.UseDefaultCredentials = false;
            smtpMail.Host = "smtp.gmail.com";
            smtpMail.Port = ; 
            smtpMail.Credentials = new System.Net.NetworkCredential(De, Password); 
            smtpMail.ClientCertificates. 
            SmtpClient clienteSmtp = new SmtpClient("WIN02");
             * */
            /*
             * Cliente SMTP
             * Gmail:  smtp.gmail.com  puerto:587
             * Hotmail: smtp.liva.com  puerto:25
             */
            SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
            /*
            * Autenticacion en el Servidor
            * Utilizaremos nuestra cuenta de correo
            *
            * Direccion de Correo (Gmail o Hotmail)
            * y Contrasena correspondiente
            */
            server.Credentials = new System.Net.NetworkCredential(De, Password);
            server.EnableSsl = true;

            server.Send(Email);

            //obtener el hash md5 de la clave generada
            string clave_temporal = oUsuario.clave;
            oUsuario.clave = cEncriptacion.Encriptar(clave_temporal);
            //guardar el cambio 
            Modificacion(oUsuario);
        }

        // Busco al usuario en las entidades, haciendo las validaciones necesarias
        public Modelo_Entidades.Usuario Login(string usuario, string clave)
        {
            // Aca instancio un objeto "Usuario" y tomo el objeto "Entidades" que instancie en un principio.
            // Luego, a esas "Entidades", les pido que me traigan a todos los "Usuarios" en forma de Lista.
            // A esa Lista de "Usuarios" le pido que me encuentre y que me devuelva el id del usuario "usuario" que pasé por parámetros. 
            Modelo_Entidades.Usuario oUsuario = oModelo_Entidades.Usuarios.ToList().Find(delegate(Modelo_Entidades.Usuario fUsuario)
            {
                return fUsuario.usuario == usuario;
            });

            ValidarUsuario(oUsuario, clave);

            // En caso de que pase todas la validaciones, devuelvo al Usuario
            return oUsuario;
        }

        // Obtengo los grupos de un usuario
        public List<Modelo_Entidades.Grupo> ObtenerGruposUsuario(int id)
        {
            // Aca instancio un objeto "Usuario" y tomo el objeto "Entidades" que instancie en un principio.
            // Luego, a esas "Entidades", les pido que me traigan a todos los "Usuarios" en forma de Lista.
            // A esa Lista de "Usuarios" le pido que me encuentre y que me devuelva los grupos del usuario "usuario" que pasé por parámetros. 
            Modelo_Entidades.Usuario oUsuario = oModelo_Entidades.Usuarios.ToList().Find(delegate(Modelo_Entidades.Usuario fUsuario)
            {
                    return fUsuario.id == id;
            });
                return oUsuario.Grupos.ToList();
        }

        // Dar de alta a un nuevo usuario
        public void Alta(Modelo_Entidades.Usuario oUsuario)
        {
            oUsuario.Alta(oUsuario);
        }

        // Modificar a un usuario
        public void Modificacion(Modelo_Entidades.Usuario oUsuario)
        {
            oUsuario.Modificacion(oUsuario);
        }

        // Obtener los usuarios
        public List<Modelo_Entidades.Usuario> ObtenerUsuarios()
        {
            return oModelo_Entidades.Usuarios.ToList();
        }

        // Busco los usuarios por una descripción parcial
        public List<Modelo_Entidades.Usuario> BuscarUsuarios(string texto)
        {
            var Consulta = from oUsuario in oModelo_Entidades.Usuarios.ToList()
                           where oUsuario.nombre_apellido.Contains(texto)
                           select oUsuario;
            return (List<Modelo_Entidades.Usuario>)Consulta.ToList();
        }

        // Valido que no exista un usuario dado el nombre del usuario
        public Boolean ValidarUsuario(string usuario)
        {
            Modelo_Entidades.Usuario oUsuario = oModelo_Entidades.Usuarios.ToList().Find(delegate(Modelo_Entidades.Usuario fUsuario)
            {
                return fUsuario.usuario == usuario;
            });

            if (oUsuario == null)
            {
                return true;
            }

            else 
            {
                return false;
            }
        }

        // Metodo de validación general para todos los usuarios
        public List<Modelo_Entidades.Usuario> FiltrarUsuarios(string nya, string grupo, string estado)
        {
            var Consulta = from oUsuario in oModelo_Entidades.Usuarios.ToList()
                           select oUsuario;

            if (nya != "0")
            {
                Consulta = Consulta.Where(oUsuario => oUsuario.nombre_apellido.Contains(nya));
            }

            if (grupo != "0")
            {
                Consulta = Consulta.Where(oUsuario => oUsuario.Grupos.Contains(this.BuscoGrupo(grupo)));
            }

            if (estado == "0")
            {
                Consulta = Consulta.Where(oUsuario => oUsuario.estado == false);
            }

            if (estado == "1")
            {
                Consulta = Consulta.Where(oUsuario => oUsuario.estado == true);
            }

            return (List<Modelo_Entidades.Usuario>)Consulta.ToList();
        }

        // Método interno para buscar un grupo
        private Modelo_Entidades.Grupo BuscoGrupo(string grupo)
        {
            Modelo_Entidades.Grupo oGrupo = oModelo_Entidades.Grupos.ToList().Find(delegate(Modelo_Entidades.Grupo fGrupo)
            {
                return fGrupo.descripcion == grupo;
            });

            return oGrupo;
        }

        // Valido el usuario
        private void ValidarUsuario(Modelo_Entidades.Usuario oUsuario, string clave)
        {
            // Pregunto si el usuario es nulo, y devuelvo un mensaje, en caso de que sea así.
            if (oUsuario == null)
            {
                throw new Exception("El usuario ingresado no se encuentra registrado en el sistema");
            }

            // Pregunto por la clave del usuario, y devuelvo un mensaje, en caso de que sea incorrecta.
            if (oUsuario.clave != clave)
            {
                throw new Exception("La contraseña ingresada es incorrecta");
            }

            // Pregunto por el estado del usuario, y devuelvo un mensaje, en caso de que sea inactivo.
            if (oUsuario.estado == false)
            {
                throw new Exception("El usuario ingresado se encuentra inactivo");
            }
        }
    }
}
