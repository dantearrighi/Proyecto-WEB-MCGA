drop database GCI

create database GCI

use GCI

insert into Usuarios values
('Pablo Gil', 'p', 'gil.a.pablo@gmail.com', 1, 'p'),
('Jorge Lopez', 'x','jogelopez@gmail.com',2,'x'),
('Federico Aguirre', 'f','aguirre.federico.alejandro@gmail.com',1,'f')

insert into Grupos values
('Administrador'),
('Usuario')

insert into UsuariosGrupos values
(1,1),
(2,1),
(2,2)

insert into Modulos values
('Seguridad'),
('Auditorias'),
('Profesional'),
('Titulos'),
('Cuotas'),
('Contabilidad'),
('Expedientes'),
('Estadísticas'),
('Ayuda')

insert into Permisos values
('Alta'),
('Baja'),
('Modifica'),
('Consulta')

insert into Formularios values
('FrmPerfiles','Gestion de Perfiles',1),
('FrmGrupos', 'Gestion de Grupos',1),
('FrmUsuarios','Gestion de Usuarios',1),
('FrmAuditorias','Gestion de Auditorías',2),
('FrmProfesionales','Gestion de Profesionales',3),
('FrmTitulos','Gestion de Titulos',4),
('FrmCuotas', 'Gestion de Cuotas',5),
('FrmRecibos', 'Gestion de Recibos',6),
('FrmExpedientes', 'Gestion de Expedientes',7),
('FrmAuditoriaCuotas','Gestion de Auditorías de Cuotas',2),
('FrmManual','Manual de usuario',9),
('FrmEstadisticas','Estadísticas',8),
('FrmComitentes', 'Gestion de Comitentes',7),
('FrmTareas', 'Gestion de Tareas',7)

insert into Perfiles values
(1,1,1)
--(1,2,1),
--(1,3,1),
--(1,4,1),
--(1,1,2),
--(1,2,2),
--(1,3,2),
--(1,4,2),
--(1,1,3),
--(1,1,4),
--(1,1,5),
--(1,1,6),
--(1,2,5),
--(1,2,6),
--(1,3,6),
--(1,3,5),
--(1,1,7),
--(1,1,8),
--(1,1,9),
--(1,3,9),
--(1,1,10),
--(1,1,11),
--(1,1,12),
--(1,1,13),
--(1,1,14)

insert into Provincias values
('Santa Fe'),
('Buenos Aires'),
('Cordoba'),
('Corrientes'),
('Entre Rios'),
('Santa Fe'),
('Catamarca'),
('Chaco'),
('Chubut'),
('Formosa'),
('Jujuy'),
('La Pampa'),
('La Rioja'),
('Mendoza'),
('Misiones'),
('Neuquen'),
('Rio Negro'),
('Salta'),
('San Juan'),
('San Luis'),
('Santa Cruz'),
('Santiago del Estero'),
('Tucuman'),
('Tierra del Fuego')

insert into Localidades values
('Rosario',2000,1),
('Aaron Castellanos',6106,1),
('Acebal',2109,1),
('Albarellos',2101,1),
('Alvear',2126,1),
('Arteaga',2187,1),
('Andino',2214,1),
('Casilda',2170,1),
('Abasto',1903,2),
('Abel',6450,2),
('Acevedo',2717,2),
('Acassuso',1640,2),
('Barrio el Once',1884,2),
('Berutti',6424,2),
('Bolivar',6550,2),
('Boulogne',1609,2),
('Burzaco',1852,2),
('Adrogue',1846,2)

insert into Tipos_Documentos values
('DNI'),
('LC')

insert into Estados values
('Habilitado'),
('No Habilitado'),
('Baja')

insert into Tipos_Matriculas values
('Normal'),
('Relación de Dependencia'),
('Reciprocidad de Matrícula')

insert into Colegios values
('Colegio de Ingenieros de Córdoba')

insert into Universidades values
('Universidad Abierta Interamericana'),
('Universidad Tecnologica Nacional'),
('Universidad Catolica Argentina'),
('Universidad de Buenos Aires'),
('Universidad de la Plata'),
('Universidad Nacional de Rosario'),
('Universidad de Palermo')

insert into Niveles values
('PreGrado'),
('Grado'),
('PosGrado')

insert into Modalidades values
('Prescencial'),
('Distancia'),
('Semi-Presencial')

insert into Jurisdicciones values
('Nacional'),
('Provincial')

insert into Especialidades values
('Sistemas'),
('Mecanica'),
('Bioingenieria'),
('Industrial'),
('Quimica'),
('Electrica'),
('Ambiente')

--insert into Planes values
--('T104','15412/10','Ingeniería en Sistemas Informaticos', 'Incumbencias del plan'),
--('T108','15412/11','Ingeniería en Sistemas Informaticos', 'Incumbencias del plan'),
--('T109','15412/12','Ingeniería en Sistemas Informaticos', 'Incumbencias del plan'),
--('A116','10254/03','Analista en Sistemas Informaticos', 'Incumbencias del plan'),
--('M005','10253/05','Ingenieria Mecanica', 'Incumbencias del plan'),
--('E101','14254/04','Ingenieria Electrica', 'Incumbencias del plan'),
--('Q110','16785/03','Ingenieria Quimica', 'Incumbencias del plan')

--insert into Titulos values
--('Ingeniería en Sistemas Informaticos','24578','255/10','2015','RDP Nº 23',1,1,1,1,1),
--('Analista en Sistemas Informaticos','15246','152/11','2014','RDP Nº 12',1,1,2,1,1),
--('Ingenieria Mecanica','1001','234/01','2020','RDP Nº 03',1,1,1,2,2),
--('Ingenieria Electrica','1002','235/01','2020','RDP Nº 04',1,1,1,6,6),
--('Ingenieria Quimica','1003','236/01','2020','RDP Nº 05',1,1,1,5,5)

--insert into Legajos_Academicos values
--(1,1),
--(2,2),
--(3,3),
--(4,4),
--(5,5)

insert into Tipos_Certificados values
('Habilitación','Descripción del certificado'),
('Incumbencia','Descripción del certificado')

--insert into Profesionales values
--(01868923,'Pablo Gil','01/09/1988','Masculino',4321636,153192897,'gil.a.pablo@gmail.com','pablogil_39@hotmail.com','Obs',NULL,NULL,'2-0001-8',1,1,NULL,1),
--(02254345,'David Lopez','10/03/1988','Masculino',4456536,154209876,'david.lopez@gmail.com','david.lopez@hotmail.com','Obs',NULL,NULL,'2-0002-8',1,1,NULL,1),
--(03354657,'Sergio Cabral','23/11/1958','Masculino',4675467,154309876,'sergio.cabral@gmail.com','sergio.cabral@hotmail.com','Obs',NULL,NULL,'2-0003-8',1,2,NULL,1),
--(04354657,'Estefania Franco','23/12/1981','Femenino',4561098,152348976,'estefania.franco@gmail.com','estefania.franco@hotmail.com','Obs',NULL,NULL,'2-0004-8',1,1,NULL,1),
--(05897675,'Marcelo Ferrari','15/11/1950','Masculino',4672307,153786512,'marcelo.ferrari@gmail.com','marcelo.ferrari@hotmail.com','Obs',NULL,NULL,'2-0005-8',1,1,NULL,1),
--(06832890,'Fernando Rodriguez','21/02/1965','Masculino',4657346,156398752,'fernando.rodriguez@gmail.com','fernando.rodriguez@hotmail.com','Obs',NULL,NULL,'2-0006-8',1,2,NULL,1),
--(07821356,'Federico Aguirre','07/06/1980','Masculino',4676007,154572590,'aguirre.federico.aguirre@gmail.com','rosariofd@hotmail.com','Obs',NULL,NULL,'2-0007-8',1,1,NULL,1),
--(08821311,'Gustavo Fernandez','17/06/1984','Masculino',4346007,152573490,'gustavo.fernandez@gmail.com','gustavo.fernandez@hotmail.com','Obs',NULL,NULL,'2-0008-8',1,1,NULL,1),
--(09822312,'Agustina Torres','27/06/1990','Femenino',3676007,15234512,'agustina.torres@gmail.com','agustina.torres@hotmail.com','Obs',NULL,NULL,'2-0009-8',1,1,NULL,1),
--(10321313,'Florencia Marco','07/06/1980','Femenino',4676007,154272590,'florencia.marco@gmail.com','florencia.marco@hotmail.com','Obs',NULL,NULL,'2-0010-8',1,1,NULL,1),
--(11821314,'Pedro Blanco','07/12/1955','Masculino',4532543,113572590,'pedro.blanco@gmail.com','pedro.blanco@hotmail.com','Obs',NULL,NULL,'2-0011-8',1,1,NULL,1),
--(12821315,'Nicolas Crochet','07/06/1980','Masculino',46762337,154544590,'nicolas.crochet@gmail.com','nicolas.crochet@hotmail.com','Obs',NULL,NULL,'2-0012-8',1,1,NULL,1),
--(13821316,'Augusto Perez','07/06/1980','Masculino',4676567,151272590,'agusto.perez@gmail.com','agusto.perez@hotmail.com','Obs',NULL,NULL,'2-0013-8',1,1,NULL,1),
--(14821317,'Paula Bracco','07/06/1980','Femenino',4676767,154572590,'paula.bracco@gmail.com','paula.bracco@hotmail.com','Obs',NULL,NULL,'2-0014-8',1,1,NULL,1),
--(15821318,'Federico Aguirre','07/06/1980','Masculino',4676997,154112590,'aguirre.federico.aguirre@gmail.com','rosariofd@hotmail.com','Obs',NULL,NULL,'2-0015-8',1,1,NULL,1)

--insert into Direcciones values
--('Saavedra 2456',01868923,1),
--('Saavedra 2456',01868923,1),
--('Mitre 456',02254345,1),
--('Mitre 456',02254345,1),
--('Santiago 830',03354657,1),
--('Santiago 830',03354657,1),
--('Pte Roca 931',04354657,1),
--('Pte Roca 931',04354657,1),
--('Buenos Aires 1025',05897675,1),
--('Buenos Aires 1025',05897675,1),
--('Ov Lagos 2565',06832890,1),
--('Ov Lagos 2565',06832890,1),
--('Arrieta 6547',07821356,1),
--('Arrieta 6547',07821356,1),
--('Bermudez 3454',08821311,1),
--('Bermudez 3454',08821311,1),
--('Ayacucho 5656',09822312,1),
--('Ayacucho 5656',09822312,1),
--('Callao 879',10321313,1),
--('Callao 879',10321313,1),
--('Marco Polo 4090',11821314,1),
--('Marco Polo 4090',11821314,1),
--('San Lorenzo 902',12821315,1),
--('San Lorenzo 902',12821315,1),
--('Cordoba 2546',13821316,1),
--('Cordoba 2546',13821316,1),
--('Av Uriburu 2015',14821317,1),
--('Av Uriburu 2015',14821317,1),
--('Alvear 930',15821318,1),
--('Alvear 930',15821318,1)

--insert into Matriculas values
--('2-0001-0',0,'01/10/2012',1,1,1,01868923,1),
--('2-00016-0',0,'01/10/2012',1,1,1,01868923,2),
--('2-0002-1',1,'01/03/2012',1,1,1,02254345,2),
--('2-0003-2',1,'01/04/2012',1,1,1,03354657,3),
--('2-0004-6',1,'01/05/2012',1,1,1,04354657,4),
--('2-0005-8',1,'01/06/2012',1,1,1,05897675,5),
--('2-0006-5',1,'01/07/2012',1,1,1,06832890,1),
--('2-0007-9',1,'01/08/2012',1,1,1,07821356,2),
--('2-0008-2',1,'08/09/2012',1,1,1,08821311,3),
--('2-0009-1',1,'07/10/2012',1,1,1,09822312,4),
--('2-0010-3',1,'06/11/2012',1,1,1,10321313,5),
--('2-0011-0',1,'05/12/2012',1,1,1,11821314,1),
--('2-0012-1',1,'04/11/2012',1,1,1,12821315,2),
--('2-0013-4',1,'03/10/2012',1,1,1,13821316,3),
--('2-0014-7',1,'02/09/2012',1,1,1,14821317,4),
--('2-0015-9',1,'01/08/2012',1,1,1,15821318,5)

--insert into Historiales values
--('Habilitado','01/10/2012','Normal','1º Habilitación',01868923),
--('Habilitado','12/11/2012','Normal','1º Habilitación',02254345),
--('Habilitado','23/12/2012','Normal','1º Habilitación',03354657),
--('Habilitado','15/03/2012','Normal','1º Habilitación',04354657),
--('Habilitado','16/05/2012','Normal','1º Habilitación',05897675),
--('Habilitado','09/02/2012','Normal','1º Habilitación',06832890),
--('Habilitado','04/07/2012','Normal','1º Habilitación',07821356),
--('Habilitado','03/10/2012','Normal','1º Habilitación',08821311),
--('Habilitado','18/03/2012','Normal','1º Habilitación',09822312),
--('Habilitado','28/01/2012','Normal','1º Habilitación',10321313),
--('Habilitado','25/10/2012','Normal','1º Habilitación',11821314),
--('Habilitado','19/03/2012','Normal','1º Habilitación',12821315),
--('Habilitado','09/12/2012','Normal','1º Habilitación',13821316),
--('Habilitado','11/06/2012','Normal','1º Habilitación',14821317),
--('Habilitado','22/04/2012','Normal','1º Habilitación',15821318)

insert into Alteradores values
(0.005,10,120)

insert into Tipos_Movimientos values
('Deudor'),
('Acreedor')

--insert into CtasCtes values
--(0,01868923),
--(0,02254345),
--(0,03354657),
--(0,04354657),
--(0,05897675),
--(0,06832890),
--(0,07821356),
--(0,08821311),
--(0,09822312),
--(0,10321313),
--(0,11821314),
--(0,12821315),
--(0,13821316),
--(0,14821317),
--(0,15821318)

--insert into Comisiones values
--('Mecanica',2500,500),
--('Eléctrica',2500,700),
--('Química',2500,200),
--('Higiene y Seguridad en el Trabajo',2500,1000),
--('Sistemas',2500,1500),
--('Peritos de la Justicia',2500,2400),
--('Ambiente',2500,2200),
--('Bioingeniería',2500,2500),
--('Alimentos',2500,1000),
--('Industrial',2500,1500),
--('Educacion ',2500,2450)

--insert into Docentes values
--('Jorge Perez'),
--('Marisa Fernandez'),
--('Ezequiel Gaboto'),
--('Mauricio García'),
--('Leandro Rodriguez'),
--('German Alvarez'),
--('Mariela Sanchez'),
--('Sergio Ramirez'),
--('Diego Franco')

--insert into Cursos values
--(5,5,5,0,1000,'Ascensores',1,1),
--(8,10,10,0,2500,'Cableados',2,2),
--(12,20,15,0,2000,'Estructuras',10,3),
--(4,20,8,0,900,'Escaleras',1,4),
--(7,10,8,0,750,'ISO 9001',4,5),
--(4,20,10,0,1200,'ISO 9014',4,6),
--(2,15,10,0,3500,'BioSeguridad',4,7),
--(6,10,8,0,500,'Herramientas para Ingenieria',10,8),
--(3,5,5,0,4000,'Ingenieria y Negocios',10,9),
--(7,15,12,0,1400,'Controles de Maniobra Electronica',2,1),
--(8,25,15,0,1500,'Configuracion de Redes de Computadoras',5,2),
--(10,20,15,0,1600,'Gestión de Riesgos para Productos Médicos',4,3),
--(5,15,10,0,2600,'Ingeniería de TV DIGITAL',5,4),
--(4,10,6,0,900,'Motores Mecanicos',1,5),
--(2,10,6,0,900,'Motores Electricos',2,6),
--(8,10,10,0,2500,'Compuestos Quimicos',3,7),
--(7,15,12,0,1400,'Reacciones Quimicas',3,1),
--(2,10,6,0,900,'Hidrocarburos',3,2),
--(5,6,5,0,1500,'Configuracion Vlans',5,2),
--(8,10,10,0,2500,'Ley 2908',6,7),
--(7,15,12,0,1400,'Ley 6754',6,1),
--(2,10,6,0,900,'Informacion Justicia',6,2),
--(8,10,10,0,2500,'Ley Ambiental',7,7),
--(7,15,12,0,1400,'Cuidemos el Medio Ambiente',7,1),
--(2,10,6,0,900,'Reciclado de Papel',7,2),
--(8,10,10,0,2500,'Bioingeniería 1',8,7),
--(7,15,12,0,1400,'Bioingeniería 2',8,1),
--(2,10,6,0,900,'Bioingeniería 3',8,2),
--(8,10,10,0,2500,'Alimentos 1',9,7),
--(7,15,12,0,1400,'Alimentos 2',9,1),
--(2,10,6,0,900,'Alimentos 3',9,2),
--(8,10,10,0,2500,'Industrial 1',10,7),
--(7,15,12,0,1400,'Industrial 2',10,1),
--(2,10,6,0,900,'Industrial 3',10,2),
--(8,10,10,0,2500,'Educacion 1',11,7),
--(7,15,12,0,1400,'Educacion 2',11,1),
--(2,10,6,0,900,'Educacion 3',11,2)


--insert into Clases values
--('02/01/2012',1),
--('03/01/2012',1),
--('04/01/2012',1),
--('01/02/2012',2),
--('02/02/2012',2),
--('01/03/2012',3),
--('02/03/2012',3),
--('03/03/2012',3),
--('04/03/2012',3),
--('05/03/2012',3),
--('01/04/2012',4),
--('02/04/2012',4),
--('03/04/2012',4),
--('01/05/2012',5),
--('02/05/2012',5),
--('01/06/2012',6),
--('02/06/2012',6),
--('03/06/2012',6),
--('04/06/2012',6),
--('01/07/2012',7),
--('02/07/2012',7),
--('01/08/2012',8),
--('02/08/2012',8),
--('03/08/2012',8),
--('01/09/2012',9),
--('01/10/2012',10),
--('02/10/2012',10),
--('01/11/2012',11),
--('02/11/2012',11),
--('01/11/2012',12),
--('02/11/2012',12),
--('01/11/2012',12),
--('02/11/2012',13),
--('02/11/2012',13),
--('04/11/2012',14),
--('04/11/2012',14),
--('06/11/2012',15),
--('06/11/2012',15),
--('07/11/2012',16),
--('08/11/2012',17),
--('09/11/2012',18),
--('10/11/2012',19),
--('11/11/2012',19),
--('07/11/2012',20),
--('08/11/2012',21),
--('09/11/2012',22),
--('10/11/2012',23),
--('11/11/2012',24),
--('12/11/2012',25),
--('13/11/2012',26),
--('14/11/2012',27),
--('15/11/2012',28),
--('11/02/2012',29),
--('12/02/2012',30),
--('13/02/2012',31),
--('14/02/2012',32),
--('15/02/2012',33),
--('16/03/2012',34),
--('17/04/2012',35),
--('18/05/2012',36),
--('19/05/2012',37)


--insert into Asistencias values
---- asistencia de 5 Profesionales al curso Ascensores id_curso 1
--(0,01868923,1),
--(0,02254345,1),
--(0,03354657,1),
--(0,04354657,1),
--(0,05897675,1),
--(0,01868923,2),
--(0,02254345,2),
--(0,03354657,2),
--(0,04354657,2),
--(1,05897675,2),
--(1,01868923,3),
--(1,02254345,3),
--(1,03354657,3),
--(1,04354657,3),
--(1,05897675,3),
---- asistencia de 8 Profesionales al curso Cableados id_curso 2
--(1,01868923,4),
--(1,02254345,4),
--(1,03354657,4),
--(1,04354657,4),
--(1,05897675,4),
--(0,06832890,4),
--(0,07821356,4),
--(0,08821311,4),
--(0,01868923,5),
--(0,02254345,5),
--(1,03354657,5),
--(1,04354657,5),
--(0,05897675,5),
--(0,06832890,5),
--(0,07821356,5),
--(0,08821311,5),
---- asistencia de 12 Profesionales al curso Estructuras id_curso 3
--(1,01868923,6),
--(1,02254345,6),
--(1,03354657,6),
--(0,04354657,6),
--(0,05897675,6),
--(0,06832890,6),
--(0,07821356,6),
--(0,08821311,6),
--(0,09822312,6),
--(1,10321313,6),
--(0,11821314,6),
--(0,12821315,6),
--(0,01868923,7),
--(0,02254345,7),
--(0,03354657,7),
--(1,04354657,7),
--(0,05897675,7),
--(1,06832890,7),
--(0,07821356,7),
--(1,08821311,7),
--(1,09822312,7),
--(0,10321313,7),
--(1,11821314,7),
--(1,12821315,7),
--(0,01868923,8),
--(1,02254345,8),
--(1,03354657,8),
--(0,04354657,8),
--(1,05897675,8),
--(1,06832890,8),
--(0,07821356,8),
--(1,08821311,8),
--(1,09822312,8),
--(0,10321313,8),
--(1,11821314,8),
--(0,12821315,8),
--(0,01868923,9),
--(0,02254345,9),
--(1,03354657,9),
--(1,04354657,9),
--(0,05897675,9),
--(1,06832890,9),
--(0,07821356,9),
--(1,08821311,9),
--(1,09822312,9),
--(1,10321313,9),
--(1,11821314,9),
--(1,12821315,9),
--(0,01868923,10),
--(1,02254345,10),
--(1,03354657,10),
--(0,04354657,10),
--(1,05897675,10),
--(1,06832890,10),
--(1,07821356,10),
--(1,08821311,10),
--(0,09822312,10),
--(1,10321313,10),
--(1,11821314,10),
--(1,12821315,10),
---- asistencia de 4 Profesionales al curso Escaleras id_curso 4
--(1,01868923,11),
--(1,02254345,11),
--(0,03354657,11),
--(1,04354657,11),
--(0,01868923,12),
--(1,02254345,12),
--(0,03354657,12),
--(1,04354657,12),
--(1,01868923,13),
--(0,02254345,13),
--(1,03354657,13),
--(0,04354657,13),
---- asistencia de 7 Profesionales al curso ISO 9001 id_curso 5
--(1,01868923,14),
--(1,02254345,14),
--(1,03354657,14),
--(1,04354657,14),
--(1,05897675,14),
--(1,06832890,14),
--(1,07821356,14),
--(1,01868923,15),
--(0,02254345,15),
--(0,03354657,15),
--(1,04354657,15),
--(1,05897675,15),
--(0,06832890,15),
--(1,07821356,15),
---- asistencia de 4 Profesionales al curso ISO 9014 id_curso 6
--(1,01868923,16),
--(1,02254345,16),
--(1,03354657,16),
--(0,04354657,16),
--(1,01868923,17),
--(1,02254345,17),
--(0,03354657,17),
--(1,04354657,17),
--(1,01868923,18),
--(0,02254345,18),
--(1,03354657,18),
--(1,04354657,18),
--(0,01868923,19),
--(1,02254345,19),
--(1,03354657,19),
--(0,04354657,19),
---- asistencia de 2 Profesionales al curso BioSeguridad id_curso 7 
--(1,01868923,20),
--(1,02254345,20),
--(0,01868923,21),
--(1,02254345,21),

---- asistencia de 2 Profesionales al curso Herramientas para Ingenieria id_curso 8          
--(0,01868923,22),
--(0,02254345,22),
--(0,03354657,22),
--(1,04354657,22),
--(0,05897675,22),
--(0,06832890,22),
--(1,01868923,23),
--(0,02254345,23),
--(0,03354657,23),
--(1,04354657,23),
--(0,05897675,23),
--(0,06832890,23),
--(0,01868923,24),
--(0,02254345,24),
--(1,03354657,24),
--(0,04354657,24),
--(0,05897675,24),
--(1,06832890,24),
---- asistencia de 3 Profesionales al curso Ingenieria y Negocios id_curso 9 
--(1,01868923,25),
--(0,02254345,25),
--(1,03354657,25),
---- asistencia de 7 Profesionales al curso Controles de Maniobra Electronica id_curso 10
--(1,01868923,26),
--(1,02254345,26),
--(0,03354657,26),
--(1,04354657,26),
--(0,05897675,26),
--(1,06832890,26),
--(1,07821356,26),
--(0,01868923,27),
--(1,02254345,27),
--(1,03354657,27),
--(1,04354657,27),
--(1,05897675,27),
--(0,06832890,27),
--(0,07821356,27),
---- asistencia de 8 Profesionales al curso Controles de Maniobra Electronica id_curso 11
--(1,08821311,28),
--(0,09822312,28),
--(1,10321313,28),
--(0,11821314,28),
--(1,12821315,28),
--(0,13821316,28),
--(0,14821317,28),
--(0,15821318,28),
--(1,08821311,29),
--(0,09822312,29),
--(0,10321313,29),
--(0,11821314,29),
--(0,12821315,29),
--(1,13821316,29),
--(0,14821317,29),
--(1,15821318,29),
---- asistencia de 10 Profesionales al curso Curso de Gestión de Riesgos para Productos Médicos id_curso 12
--(1,01868923,30),
--(1,02254345,30),
--(0,03354657,30),
--(1,04354657,30),
--(0,05897675,30),
--(1,06832890,30),
--(0,07821356,30),
--(1,08821311,30),
--(0,09822312,30),
--(0,10321313,30),
--(1,01868923,31),
--(1,02254345,31),
--(0,03354657,31),
--(1,04354657,31),
--(0,05897675,31),
--(1,06832890,31),
--(0,07821356,31),
--(1,08821311,31),
--(0,09822312,31),
--(0,10321313,31),
--(1,01868923,32),
--(1,02254345,32),
--(0,03354657,32),
--(1,04354657,32),
--(0,05897675,32),
--(1,06832890,32),
--(0,07821356,32),
--(1,08821311,32),
--(0,09822312,32),
--(0,10321313,32),
---- asistencia de 5 Profesionales al curso  id_curso 13
--(1,11821314,33),
--(0,12821315,33),
--(1,13821316,33),
--(0,14821317,33),
--(1,15821318,33),
--(1,11821314,34),
--(0,12821315,34),
--(1,13821316,34),
--(0,14821317,34),
--(1,15821318,34),
---- asistencia de 4 Profesionales al curso Motores Mecanicos id_curso 14
--(0,01868923,35),
--(0,02254345,35),
--(1,03354657,35),
--(1,04354657,35),
--(0,01868923,36),
--(1,02254345,36),
--(0,03354657,36),
--(1,04354657,36),
---- asistencia de 4 Profesionales al curso Motores Electricos id_curso 15
--(1,01868923,37),
--(0,02254345,37),
--(0,01868923,38),
--(1,02254345,38),
---- asistencia de 8 Profesionales al curso Compuestos Quimicos id_curso 16
--(1,01868923,39),
--(1,02254345,39),
--(1,03354657,39),
--(1,04354657,39),
--(1,05897675,39),
--(0,06832890,39),
--(0,07821356,39),
--(0,08821311,39),
---- asistencia de 7 Profesionales al curso Reacciones Quimicos id_curso 17
--(1,09822312,40),
--(0,10321313,40),
--(1,11821314,40),
--(1,12821315,40),
--(0,13821316,40),
--(1,14821317,40),
--(0,15821318,40),
---- asistencia de 2 Profesionales al curso Hidrocarburos id_curso 18
--(1,01868923,41),
--(0,02254345,41),
---- asistencia de 5 Profesionales al curso Configuracion Vlans id_curso 19
--(0,01868923,42),
--(0,02254345,42),
--(0,03354657,42),
--(0,04354657,42),
--(0,05897675,42),
--(0,01868923,43),
--(0,02254345,43),
--(0,03354657,43),
--(0,04354657,43),
--(0,05897675,43),
---- asistencia de 8 Profesionales al curso Ley id_curso 20
--(1,01868923,44),
--(1,02254345,44),
--(1,03354657,44),
--(1,04354657,44),
--(1,05897675,44),
--(0,06832890,44),
--(0,07821356,44),
--(0,08821311,44),
---- asistencia de 7 Profesionales al curso Ley id_curso 21
--(1,09822312,45),
--(0,10321313,45),
--(1,11821314,45),
--(1,12821315,45),
--(0,13821316,45),
--(1,14821317,45),
--(0,15821318,45),
---- asistencia de 2 Profesionales al curso Charla Justicia id_curso 22
--(1,01868923,46),
--(0,02254345,46),
---- asistencia de 8 Profesionales al curso ambiente id_curso 23
--(1,01868923,47),
--(1,02254345,47),
--(1,03354657,47),
--(1,04354657,47),
--(1,05897675,47),
--(0,06832890,47),
--(0,07821356,47),
--(0,08821311,47),
---- asistencia de 7 Profesionales al curso ambiente id_curso 24
--(1,09822312,48),
--(0,10321313,48),
--(1,11821314,48),
--(1,12821315,48),
--(0,13821316,48),
--(1,14821317,48),
--(0,15821318,48),
---- asistencia de 2 Profesionales al curso ambiente id_curso 25
--(1,01868923,49),
--(0,02254345,49),
---- asistencia de 8 Profesionales al curso bioingenieria1 id_curso 26
--(1,01868923,50),
--(1,02254345,50),
--(1,03354657,50),
--(1,04354657,50),
--(1,05897675,50),
--(0,06832890,50),
--(0,07821356,50),
--(0,08821311,50),
---- asistencia de 7 Profesionales al curso bioingenieria2 id_curso 27
--(1,09822312,51),
--(0,10321313,51),
--(1,11821314,51),
--(1,12821315,51),
--(0,13821316,51),
--(1,14821317,51),
--(0,15821318,51),
---- asistencia de 2 Profesionales al curso bioingenieria3 id_curso 28
--(1,01868923,52),
--(0,02254345,52),
---- asistencia de 8 Profesionales al curso alimenticia1 id_curso 29
--(1,01868923,53),
--(1,02254345,53),
--(1,03354657,53),
--(1,04354657,53),
--(1,05897675,53),
--(0,06832890,53),
--(0,07821356,53),
--(0,08821311,53),
---- asistencia de 7 Profesionales al curso alimenticia2 id_curso 30
--(1,09822312,54),
--(0,10321313,54),
--(1,11821314,54),
--(1,12821315,54),
--(0,13821316,54),
--(1,14821317,54),
--(0,15821318,54),
---- asistencia de 2 Profesionales al curso alimenticia3 id_curso 31
--(1,01868923,55),
--(0,02254345,55),
---- asistencia de 8 Profesionales al curso industrial1 id_curso 32
--(1,01868923,56),
--(1,02254345,56),
--(1,03354657,56),
--(1,04354657,56),
--(1,05897675,56),
--(0,06832890,56),
--(0,07821356,56),
--(0,08821311,56),
---- asistencia de 7 Profesionales al curso indstrial2 id_curso 33
--(1,09822312,57),
--(0,10321313,57),
--(1,11821314,57),
--(1,12821315,57),
--(0,13821316,57),
--(1,14821317,57),
--(0,15821318,57),
---- asistencia de 2 Profesionales al curso industrial3 id_curso 34
--(1,01868923,58),
--(0,02254345,58),
---- asistencia de 8 Profesionales al curso educacion1 id_curso 35
--(1,01868923,59),
--(1,02254345,59),
--(1,03354657,59),
--(1,04354657,59),
--(1,05897675,59),
--(0,06832890,59),
--(0,07821356,59),
--(0,08821311,59),
---- asistencia de 7 Profesionales al curso educacion2 id_curso 36
--(1,09822312,60),
--(0,10321313,60),
--(1,11821314,60),
--(1,12821315,60),
--(0,13821316,60),
--(1,14821317,60),
--(0,15821318,60),
---- asistencia de 2 Profesionales al curso educacion3 id_curso 37
--(1,01868923,61),
--(0,02254345,61)

--insert into Tareas values
--('Informe Técnico'),
--('Fuerza Electromotriz'),
--('Obras de Ingenieria')

--insert into Comitentes values
--('Google Inc.'),
--('Microsoft')

--insert into Expedientes values
--('Devuelto','04/11/2012','01/11/2012',0,'03/11/2012','03/11/2012',1,1),
--('Devuelto','04/11/2012','01/11/2012',0,'03/11/2012','03/11/2012',1,2),
--('Devuelto','04/11/2012','01/11/2012',0,'03/11/2012','03/11/2012',1,3)

--insert into ProfesionalExpediente values
--(01868923,1),
--(01868923,2),
--(01868923,3)

--insert into Expedientes_HM values
--(1,1,1)

--insert into Expedientes_FE values
--(1,1,20,22,25,2)

--insert into Expedientes_OI values
--(50000,3)

insert into Videos values
('Patron Estrategia', 'http://youtu.be/94t2ayF1l3o');

--insert into Liquidaciones values
--('Dias de campo',1,0.7,1),
--('Dias de gabinete',1,0.3,1)

--delete from Liquidaciones where Liquidaciones.cantidad = 1

--insert into Asistencias values
--('01/11/2012',33868923,1)

--insert into Conceptos DEFAULT VALUES
--insert into Conceptos DEFAULT VALUES

--insert into Conceptos_Anual DEFAULT VALUES

--insert into Conceptos_Bimensual DEFAULT VALUES
--insert into Conceptos_Bimensual DEFAULT VALUES
--insert into Conceptos_Bimensual DEFAULT VALUES

--insert into Movimientos values
--('Cuota 1/2012',120,'01/12/2011',0,1,1,1),
--('Cuota 2/2012',120,'01/12/2011',0,1,2,1),
--('Cuota 1/2012',120,'01/12/2011',1,1,3,2)

--insert into Conceptos_Anual values
--('Anual 2012',1)

--insert into Conceptos_Bimensual values
--('Bimensual 01/2012',1)

ALTER TABLE Profesionales ALTER COLUMN fecha_nacimiento DATETIME2  
ALTER TABLE Matriculas ALTER COLUMN fecha_doc DATETIME2
ALTER TABLE Movimientos ALTER COLUMN fecha DATETIME2
ALTER TABLE Clases ALTER COLUMN fecha DATETIME2
ALTER TABLE Expedientes ALTER COLUMN fecha_devolucion DATETIME2
ALTER TABLE Expedientes ALTER COLUMN fecha_recepcion DATETIME2
ALTER TABLE Expedientes ALTER COLUMN fecha_aprobacion DATETIME2
ALTER TABLE Expedientes ALTER COLUMN fecha_pago DATETIME2
ALTER TABLE Liquidaciones ALTER COLUMN importe DECIMAL(18,2)

--DELETE FROM Comprobantes_Boleta
--DELETE FROM Comprobantes_Factura
--DELETE FROM Cuotas_Anual
--DELETE FROM Cuotas_Bimensual
--DELETE FROM Cuotas
--DELETE FROM Movimientos
--DELETE FROM Comprobantes

--DELETE FROM Liquidaciones

--DELETE FROM Auditorias_Cuotas
