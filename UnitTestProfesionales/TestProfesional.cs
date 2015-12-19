﻿using System;
using Modelo_Entidades;
using Controladora;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProfesionales
{
    [TestClass]
    public class TestProfesional
    {
        [TestMethod]
        public void AñadirProfesional()
        {
            //Declaro variables que voy a utilizar
            cProfesional cProfesional = cProfesional.ObtenerInstancia();
            cLocalidad cLocalidad = cLocalidad.ObtenerInstancia();
            cEstado cEstado = cEstado.ObtenerInstancia();
            cTipo_Documento cTipo_Documento = cTipo_Documento.ObtenerInstancia();
            
            //Instancio el objeto
            Modelo_Entidades.Profesional toProfesional = new Profesional();
            Modelo_Entidades.Tipo_Documento toTipoDoc = new Tipo_Documento();

            //Seteo los datos de prueba 
            toProfesional.celular = 1234564;
            toProfesional.dni = 99773311;
            toProfesional.email1 = "emaildeprueba@probando.com";
            toProfesional.Estado = cEstado.ObtenerEstadoHabilitado();
            toProfesional.fecha_nacimiento = new DateTime(1979, 07, 09);
            toProfesional.nombre_apellido = "Clay Morrow";
            toProfesional.observaciones = "Sin observaciones";
            toProfesional.sexo = "Masculino";
            toProfesional.telefono = 664433;

            toTipoDoc.descripcion = "DNI";
            toProfesional.Tipo_Documento = toTipoDoc;

    #region Direccion del profesional            
            //Direccion - localidad provincia 
            Modelo_Entidades.Direccion direccion = new Direccion();
            Modelo_Entidades.Provincia provincia = new Provincia();
            Modelo_Entidades.Localidad localidad = new Localidad();

                //Seteo la direccion
            direccion.direccion = "domicilio 123 del profesional";

                //Seteo la localidad
            localidad = cLocalidad.BuscarLocalidadPorDesc("Rosario");

            //Guardo la direccion
           toProfesional.Direcciones.Add(direccion);
#endregion

    #region Direccion de trabajo

            //Direccion de trabajo
            Modelo_Entidades.Localidad localidadE = new Localidad();
            Modelo_Entidades.Direccion direccionE = new Direccion();
                
                //Seteo la direccion de trabajo
            direccionE.direccion ="direccion 123 de trabajo";

                //Seteo la localidad de trabajo
            localidadE = cLocalidad.BuscarLocalidadPorDesc("Rosario");
            
            //Guardo la direccion de trabajo
            toProfesional.Direcciones.Add(direccionE);

#endregion


            
            //Agrego a la BD
            cProfesional.Alta(toProfesional);

            //Recupero el profesional insertado y lo comparo con el que recupero de la bd
            Profesional bdprofesional = cProfesional.ObtenerProfesional(toProfesional.dni);

            Assert.AreSame(toProfesional, bdprofesional, "Hubo algun error");
            
                        

            
        }
    }
}
