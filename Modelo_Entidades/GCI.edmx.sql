
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/29/2014 02:27:55
-- Generated from EDMX file: C:\Users\Pablo\Downloads\GCI\GCI\Modelo_Entidades\GCI.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GCI];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioGrupo_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuariosGrupos] DROP CONSTRAINT [FK_UsuarioGrupo_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioGrupo_Grupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuariosGrupos] DROP CONSTRAINT [FK_UsuarioGrupo_Grupo];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_PerfilGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilPermiso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_PerfilPermiso];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilFormulario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_PerfilFormulario];
GO
IF OBJECT_ID(N'[dbo].[FK_FormularioModulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Formularios] DROP CONSTRAINT [FK_FormularioModulo];
GO
IF OBJECT_ID(N'[dbo].[FK_CtaCteProfesional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CtasCtes] DROP CONSTRAINT [FK_CtaCteProfesional];
GO
IF OBJECT_ID(N'[dbo].[FK_MovimientoCtaCte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_MovimientoCtaCte];
GO
IF OBJECT_ID(N'[dbo].[FK_Tipo_MovimientoMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_Tipo_MovimientoMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_ComprobanteMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_ProvinciaLocalidades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Localidades] DROP CONSTRAINT [FK_ProvinciaLocalidades];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalHistoriales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Historiales] DROP CONSTRAINT [FK_ProfesionalHistoriales];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalDirecciones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direcciones] DROP CONSTRAINT [FK_ProfesionalDirecciones];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalMatricula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Matriculas] DROP CONSTRAINT [FK_ProfesionalMatricula];
GO
IF OBJECT_ID(N'[dbo].[FK_Tipo_DocumentoProfesional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profesionales] DROP CONSTRAINT [FK_Tipo_DocumentoProfesional];
GO
IF OBJECT_ID(N'[dbo].[FK_EstadoProfesional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profesionales] DROP CONSTRAINT [FK_EstadoProfesional];
GO
IF OBJECT_ID(N'[dbo].[FK_ColegioProfesional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profesionales] DROP CONSTRAINT [FK_ColegioProfesional];
GO
IF OBJECT_ID(N'[dbo].[FK_Tipo_MatriculaProfesional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profesionales] DROP CONSTRAINT [FK_Tipo_MatriculaProfesional];
GO
IF OBJECT_ID(N'[dbo].[FK_JurisdiccionTitulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Titulos] DROP CONSTRAINT [FK_JurisdiccionTitulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ModalidadTitulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Titulos] DROP CONSTRAINT [FK_ModalidadTitulo];
GO
IF OBJECT_ID(N'[dbo].[FK_NivelTitulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Titulos] DROP CONSTRAINT [FK_NivelTitulo];
GO
IF OBJECT_ID(N'[dbo].[FK_EspecialidadTitulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Titulos] DROP CONSTRAINT [FK_EspecialidadTitulo];
GO
IF OBJECT_ID(N'[dbo].[FK_UniversidadTitulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Titulos] DROP CONSTRAINT [FK_UniversidadTitulo];
GO
IF OBJECT_ID(N'[dbo].[FK_LocalidadDireccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direcciones] DROP CONSTRAINT [FK_LocalidadDireccion];
GO
IF OBJECT_ID(N'[dbo].[FK_MatriculaLegajo_Academico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Matriculas] DROP CONSTRAINT [FK_MatriculaLegajo_Academico];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanLegajo_Academico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Legajos_Academicos] DROP CONSTRAINT [FK_PlanLegajo_Academico];
GO
IF OBJECT_ID(N'[dbo].[FK_TituloLegajo_Academico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Legajos_Academicos] DROP CONSTRAINT [FK_TituloLegajo_Academico];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpedienteLiquidacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Liquidaciones] DROP CONSTRAINT [FK_ExpedienteLiquidacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalExpediente_Profesional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesionalExpediente] DROP CONSTRAINT [FK_ProfesionalExpediente_Profesional];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalExpediente_Expediente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesionalExpediente] DROP CONSTRAINT [FK_ProfesionalExpediente_Expediente];
GO
IF OBJECT_ID(N'[dbo].[FK_ComisionCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cursos] DROP CONSTRAINT [FK_ComisionCurso];
GO
IF OBJECT_ID(N'[dbo].[FK_DocenteCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cursos] DROP CONSTRAINT [FK_DocenteCurso];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoClase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clases] DROP CONSTRAINT [FK_CursoClase];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalAsistencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Asistencias] DROP CONSTRAINT [FK_ProfesionalAsistencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ClaseAsistencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Asistencias] DROP CONSTRAINT [FK_ClaseAsistencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalCuota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas] DROP CONSTRAINT [FK_ProfesionalCuota];
GO
IF OBJECT_ID(N'[dbo].[FK_ComitenteExpediente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expedientes] DROP CONSTRAINT [FK_ComitenteExpediente];
GO
IF OBJECT_ID(N'[dbo].[FK_TareaExpediente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expedientes] DROP CONSTRAINT [FK_TareaExpediente];
GO
IF OBJECT_ID(N'[dbo].[FK_Factura_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Factura] DROP CONSTRAINT [FK_Factura_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_Anual_inherits_Cuota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas_Anual] DROP CONSTRAINT [FK_Anual_inherits_Cuota];
GO
IF OBJECT_ID(N'[dbo].[FK_Bimensual_inherits_Cuota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas_Bimensual] DROP CONSTRAINT [FK_Bimensual_inherits_Cuota];
GO
IF OBJECT_ID(N'[dbo].[FK_Modificador_inherits_Cuota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas_Modificador] DROP CONSTRAINT [FK_Modificador_inherits_Cuota];
GO
IF OBJECT_ID(N'[dbo].[FK_Descuento_Anual_inherits_Modificador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas_Descuento_Anual] DROP CONSTRAINT [FK_Descuento_Anual_inherits_Modificador];
GO
IF OBJECT_ID(N'[dbo].[FK_Con_Recargo_inherits_Modificador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas_Con_Recargo] DROP CONSTRAINT [FK_Con_Recargo_inherits_Modificador];
GO
IF OBJECT_ID(N'[dbo].[FK_Boleta_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Boleta] DROP CONSTRAINT [FK_Boleta_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_OI_inherits_Expediente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expedientes_OI] DROP CONSTRAINT [FK_OI_inherits_Expediente];
GO
IF OBJECT_ID(N'[dbo].[FK_HM_inherits_Expediente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expedientes_HM] DROP CONSTRAINT [FK_HM_inherits_Expediente];
GO
IF OBJECT_ID(N'[dbo].[FK_FE_inherits_Expediente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expedientes_FE] DROP CONSTRAINT [FK_FE_inherits_Expediente];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Grupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grupos];
GO
IF OBJECT_ID(N'[dbo].[Perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfiles];
GO
IF OBJECT_ID(N'[dbo].[Permisos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permisos];
GO
IF OBJECT_ID(N'[dbo].[Formularios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Formularios];
GO
IF OBJECT_ID(N'[dbo].[Modulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modulos];
GO
IF OBJECT_ID(N'[dbo].[Profesionales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profesionales];
GO
IF OBJECT_ID(N'[dbo].[CtasCtes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CtasCtes];
GO
IF OBJECT_ID(N'[dbo].[Movimientos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movimientos];
GO
IF OBJECT_ID(N'[dbo].[Tipos_Movimientos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipos_Movimientos];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes];
GO
IF OBJECT_ID(N'[dbo].[Localidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Localidades];
GO
IF OBJECT_ID(N'[dbo].[Provincias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provincias];
GO
IF OBJECT_ID(N'[dbo].[Estados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estados];
GO
IF OBJECT_ID(N'[dbo].[Tipos_Matriculas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipos_Matriculas];
GO
IF OBJECT_ID(N'[dbo].[Colegios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colegios];
GO
IF OBJECT_ID(N'[dbo].[Historiales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Historiales];
GO
IF OBJECT_ID(N'[dbo].[Titulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Titulos];
GO
IF OBJECT_ID(N'[dbo].[Universidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Universidades];
GO
IF OBJECT_ID(N'[dbo].[Jurisdicciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jurisdicciones];
GO
IF OBJECT_ID(N'[dbo].[Modalidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modalidades];
GO
IF OBJECT_ID(N'[dbo].[Niveles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Niveles];
GO
IF OBJECT_ID(N'[dbo].[Especialidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Especialidades];
GO
IF OBJECT_ID(N'[dbo].[Planes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Planes];
GO
IF OBJECT_ID(N'[dbo].[Tipos_Certificados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipos_Certificados];
GO
IF OBJECT_ID(N'[dbo].[Direcciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Direcciones];
GO
IF OBJECT_ID(N'[dbo].[Tipos_Documentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipos_Documentos];
GO
IF OBJECT_ID(N'[dbo].[Matriculas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Matriculas];
GO
IF OBJECT_ID(N'[dbo].[Legajos_Academicos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Legajos_Academicos];
GO
IF OBJECT_ID(N'[dbo].[Alteradores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alteradores];
GO
IF OBJECT_ID(N'[dbo].[Comitentes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comitentes];
GO
IF OBJECT_ID(N'[dbo].[Tareas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tareas];
GO
IF OBJECT_ID(N'[dbo].[Liquidaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Liquidaciones];
GO
IF OBJECT_ID(N'[dbo].[Cursos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cursos];
GO
IF OBJECT_ID(N'[dbo].[Comisiones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comisiones];
GO
IF OBJECT_ID(N'[dbo].[Docentes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Docentes];
GO
IF OBJECT_ID(N'[dbo].[Clases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clases];
GO
IF OBJECT_ID(N'[dbo].[Asistencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Asistencias];
GO
IF OBJECT_ID(N'[dbo].[Expedientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expedientes];
GO
IF OBJECT_ID(N'[dbo].[Cuotas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuotas];
GO
IF OBJECT_ID(N'[dbo].[Videos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Videos];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_Factura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_Factura];
GO
IF OBJECT_ID(N'[dbo].[Cuotas_Anual]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuotas_Anual];
GO
IF OBJECT_ID(N'[dbo].[Cuotas_Bimensual]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuotas_Bimensual];
GO
IF OBJECT_ID(N'[dbo].[Cuotas_Modificador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuotas_Modificador];
GO
IF OBJECT_ID(N'[dbo].[Cuotas_Descuento_Anual]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuotas_Descuento_Anual];
GO
IF OBJECT_ID(N'[dbo].[Cuotas_Con_Recargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuotas_Con_Recargo];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_Boleta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_Boleta];
GO
IF OBJECT_ID(N'[dbo].[Expedientes_OI]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expedientes_OI];
GO
IF OBJECT_ID(N'[dbo].[Expedientes_HM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expedientes_HM];
GO
IF OBJECT_ID(N'[dbo].[Expedientes_FE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expedientes_FE];
GO
IF OBJECT_ID(N'[dbo].[UsuariosGrupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuariosGrupos];
GO
IF OBJECT_ID(N'[dbo].[ProfesionalExpediente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfesionalExpediente];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre_apellido] nvarchar(max)  NOT NULL,
    [clave] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [estado] bit  NOT NULL,
    [usuario] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Grupos'
CREATE TABLE [dbo].[Grupos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Perfiles'
CREATE TABLE [dbo].[Perfiles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Grupo_id] int  NOT NULL,
    [Permiso_id] int  NOT NULL,
    [Formulario_id] int  NOT NULL
);
GO

-- Creating table 'Permisos'
CREATE TABLE [dbo].[Permisos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Formularios'
CREATE TABLE [dbo].[Formularios] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [nombredemuestra] nvarchar(max)  NOT NULL,
    [Modulo_id] int  NOT NULL
);
GO

-- Creating table 'Modulos'
CREATE TABLE [dbo].[Modulos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Profesionales'
CREATE TABLE [dbo].[Profesionales] (
    [dni] int  NOT NULL,
    [nombre_apellido] nvarchar(max)  NOT NULL,
    [fecha_nacimiento] datetime  NOT NULL,
    [sexo] nvarchar(max)  NOT NULL,
    [telefono] int  NOT NULL,
    [celular] int  NOT NULL,
    [email1] nvarchar(max)  NOT NULL,
    [email2] nvarchar(max)  NOT NULL,
    [observaciones] nvarchar(max)  NOT NULL,
    [lugar_trabajo] nvarchar(max)  NULL,
    [convenio_año] int  NULL,
    [titulo_a_mostrar] nvarchar(max)  NOT NULL,
    [Tipo_Documento_id] int  NOT NULL,
    [Estado_id] int  NOT NULL,
    [Colegio_id] int  NULL,
    [Tipo_Matricula_id] int  NOT NULL
);
GO

-- Creating table 'CtasCtes'
CREATE TABLE [dbo].[CtasCtes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [saldo] decimal(18,0)  NOT NULL,
    [Profesional_dni] int  NOT NULL
);
GO

-- Creating table 'Movimientos'
CREATE TABLE [dbo].[Movimientos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [importe] float  NOT NULL,
    [fecha] datetime  NOT NULL,
    [CtaCte_id] int  NOT NULL,
    [Tipo_Movimiento_id] int  NOT NULL,
    [Comprobante_id] int  NOT NULL
);
GO

-- Creating table 'Tipos_Movimientos'
CREATE TABLE [dbo].[Tipos_Movimientos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Comprobantes'
CREATE TABLE [dbo].[Comprobantes] (
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Localidades'
CREATE TABLE [dbo].[Localidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [cp] int  NOT NULL,
    [Provincia_id] int  NOT NULL
);
GO

-- Creating table 'Provincias'
CREATE TABLE [dbo].[Provincias] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Estados'
CREATE TABLE [dbo].[Estados] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tipos_Matriculas'
CREATE TABLE [dbo].[Tipos_Matriculas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Colegios'
CREATE TABLE [dbo].[Colegios] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Historiales'
CREATE TABLE [dbo].[Historiales] (
    [id] int IDENTITY(1,1) NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [tipo_matricula] nvarchar(max)  NOT NULL,
    [observaciones] nvarchar(max)  NOT NULL,
    [Profesional_dni] int  NOT NULL
);
GO

-- Creating table 'Titulos'
CREATE TABLE [dbo].[Titulos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [ley_aprobacion] nvarchar(max)  NOT NULL,
    [res_coneau] nvarchar(max)  NOT NULL,
    [validez] nvarchar(max)  NOT NULL,
    [aprobacion_cie] nvarchar(max)  NOT NULL,
    [Jurisdiccion_id] int  NOT NULL,
    [Modalidad_id] int  NOT NULL,
    [Nivel_id] int  NOT NULL,
    [Especialidad_id] int  NOT NULL,
    [Universidad_id] int  NOT NULL
);
GO

-- Creating table 'Universidades'
CREATE TABLE [dbo].[Universidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Jurisdicciones'
CREATE TABLE [dbo].[Jurisdicciones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Modalidades'
CREATE TABLE [dbo].[Modalidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Niveles'
CREATE TABLE [dbo].[Niveles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Especialidades'
CREATE TABLE [dbo].[Especialidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Planes'
CREATE TABLE [dbo].[Planes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [año] nvarchar(max)  NOT NULL,
    [ordenanza] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [incumbencia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tipos_Certificados'
CREATE TABLE [dbo].[Tipos_Certificados] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [texto] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Direcciones'
CREATE TABLE [dbo].[Direcciones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [Profesional_dni] int  NOT NULL,
    [Localidad_id] int  NOT NULL
);
GO

-- Creating table 'Tipos_Documentos'
CREATE TABLE [dbo].[Tipos_Documentos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Matriculas'
CREATE TABLE [dbo].[Matriculas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [icie] nvarchar(max)  NULL,
    [certificado] bit  NOT NULL,
    [fecha_doc] datetime  NOT NULL,
    [incumbencia] bit  NOT NULL,
    [plan] bit  NOT NULL,
    [analitico] bit  NOT NULL,
    [Profesional_dni] int  NOT NULL,
    [Legajo_Academico_id] int  NOT NULL
);
GO

-- Creating table 'Legajos_Academicos'
CREATE TABLE [dbo].[Legajos_Academicos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Plan_id] int  NOT NULL,
    [Titulo_id] int  NOT NULL
);
GO

-- Creating table 'Alteradores'
CREATE TABLE [dbo].[Alteradores] (
    [porcentaje_recargo] float  NOT NULL,
    [dias_gracias] int  NOT NULL,
    [valor_cuota] float  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Comitentes'
CREATE TABLE [dbo].[Comitentes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [razon_social] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tareas'
CREATE TABLE [dbo].[Tareas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Liquidaciones'
CREATE TABLE [dbo].[Liquidaciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tarea] nvarchar(max)  NOT NULL,
    [cantidad] decimal(18,0)  NOT NULL,
    [importe] decimal(18,0)  NOT NULL,
    [Expediente_numero] int  NOT NULL
);
GO

-- Creating table 'Cursos'
CREATE TABLE [dbo].[Cursos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [asistentes] int  NOT NULL,
    [cupo] int  NOT NULL,
    [objetivo] int  NOT NULL,
    [arancelado] bit  NOT NULL,
    [costo] decimal(18,0)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [Comision_id] int  NOT NULL,
    [Docente_id] int  NOT NULL
);
GO

-- Creating table 'Comisiones'
CREATE TABLE [dbo].[Comisiones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [dinero_asignado] decimal(18,0)  NOT NULL,
    [dinero_gastado] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Docentes'
CREATE TABLE [dbo].[Docentes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre_apellido] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clases'
CREATE TABLE [dbo].[Clases] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [Curso_id] int  NOT NULL
);
GO

-- Creating table 'Asistencias'
CREATE TABLE [dbo].[Asistencias] (
    [id] int IDENTITY(1,1) NOT NULL,
    [presente] bit  NOT NULL,
    [Profesional_dni] int  NOT NULL,
    [Clase_id] int  NOT NULL
);
GO

-- Creating table 'Expedientes'
CREATE TABLE [dbo].[Expedientes] (
    [numero] int IDENTITY(1,1) NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [fecha_devolucion] datetime  NOT NULL,
    [fecha_recepcion] datetime  NOT NULL,
    [tipo_aporte] bit  NOT NULL,
    [fecha_aprobacion] datetime  NOT NULL,
    [fecha_pago] datetime  NOT NULL,
    [Comitente_Id] int  NOT NULL,
    [Tarea_Id] int  NOT NULL
);
GO

-- Creating table 'Cuotas'
CREATE TABLE [dbo].[Cuotas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [estado] bit  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [Profesional_dni] int  NOT NULL
);
GO

-- Creating table 'Videos'
CREATE TABLE [dbo].[Videos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Comprobantes_Factura'
CREATE TABLE [dbo].[Comprobantes_Factura] (
    [numero] int IDENTITY(1,1) NOT NULL,
    [cantidad] int  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [precio_unitario] decimal(18,0)  NOT NULL,
    [importe] decimal(18,0)  NOT NULL,
    [total] decimal(18,0)  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'Cuotas_Anual'
CREATE TABLE [dbo].[Cuotas_Anual] (
    [id] int  NOT NULL
);
GO

-- Creating table 'Cuotas_Bimensual'
CREATE TABLE [dbo].[Cuotas_Bimensual] (
    [id] int  NOT NULL
);
GO

-- Creating table 'Cuotas_Modificador'
CREATE TABLE [dbo].[Cuotas_Modificador] (
    [id] int  NOT NULL
);
GO

-- Creating table 'Cuotas_Descuento_Anual'
CREATE TABLE [dbo].[Cuotas_Descuento_Anual] (
    [id] int  NOT NULL
);
GO

-- Creating table 'Cuotas_Con_Recargo'
CREATE TABLE [dbo].[Cuotas_Con_Recargo] (
    [id] int  NOT NULL
);
GO

-- Creating table 'Comprobantes_Boleta'
CREATE TABLE [dbo].[Comprobantes_Boleta] (
    [numero] int IDENTITY(1,1) NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'Expedientes_OI'
CREATE TABLE [dbo].[Expedientes_OI] (
    [monto_obra] decimal(18,0)  NOT NULL,
    [numero] int  NOT NULL
);
GO

-- Creating table 'Expedientes_HM'
CREATE TABLE [dbo].[Expedientes_HM] (
    [dias_de_campo] decimal(18,0)  NOT NULL,
    [dias_de_gabinete] decimal(18,0)  NOT NULL,
    [numero] int  NOT NULL
);
GO

-- Creating table 'Expedientes_FE'
CREATE TABLE [dbo].[Expedientes_FE] (
    [dias_de_campo] decimal(18,0)  NOT NULL,
    [dias_de_gabinete] decimal(18,0)  NOT NULL,
    [hps] decimal(18,0)  NOT NULL,
    [bocas] decimal(18,0)  NOT NULL,
    [motores] decimal(18,0)  NOT NULL,
    [numero] int  NOT NULL
);
GO

-- Creating table 'UsuariosGrupos'
CREATE TABLE [dbo].[UsuariosGrupos] (
    [Usuarios_id] int  NOT NULL,
    [Grupos_id] int  NOT NULL
);
GO

-- Creating table 'ProfesionalExpediente'
CREATE TABLE [dbo].[ProfesionalExpediente] (
    [Profesionales_dni] int  NOT NULL,
    [Expedientes_numero] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Grupos'
ALTER TABLE [dbo].[Grupos]
ADD CONSTRAINT [PK_Grupos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [PK_Perfiles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Permisos'
ALTER TABLE [dbo].[Permisos]
ADD CONSTRAINT [PK_Permisos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Formularios'
ALTER TABLE [dbo].[Formularios]
ADD CONSTRAINT [PK_Formularios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Modulos'
ALTER TABLE [dbo].[Modulos]
ADD CONSTRAINT [PK_Modulos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [dni] in table 'Profesionales'
ALTER TABLE [dbo].[Profesionales]
ADD CONSTRAINT [PK_Profesionales]
    PRIMARY KEY CLUSTERED ([dni] ASC);
GO

-- Creating primary key on [id] in table 'CtasCtes'
ALTER TABLE [dbo].[CtasCtes]
ADD CONSTRAINT [PK_CtasCtes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [PK_Movimientos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tipos_Movimientos'
ALTER TABLE [dbo].[Tipos_Movimientos]
ADD CONSTRAINT [PK_Tipos_Movimientos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [PK_Comprobantes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [PK_Localidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Provincias'
ALTER TABLE [dbo].[Provincias]
ADD CONSTRAINT [PK_Provincias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [PK_Estados]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tipos_Matriculas'
ALTER TABLE [dbo].[Tipos_Matriculas]
ADD CONSTRAINT [PK_Tipos_Matriculas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Colegios'
ALTER TABLE [dbo].[Colegios]
ADD CONSTRAINT [PK_Colegios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Historiales'
ALTER TABLE [dbo].[Historiales]
ADD CONSTRAINT [PK_Historiales]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Titulos'
ALTER TABLE [dbo].[Titulos]
ADD CONSTRAINT [PK_Titulos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Universidades'
ALTER TABLE [dbo].[Universidades]
ADD CONSTRAINT [PK_Universidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Jurisdicciones'
ALTER TABLE [dbo].[Jurisdicciones]
ADD CONSTRAINT [PK_Jurisdicciones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Modalidades'
ALTER TABLE [dbo].[Modalidades]
ADD CONSTRAINT [PK_Modalidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Niveles'
ALTER TABLE [dbo].[Niveles]
ADD CONSTRAINT [PK_Niveles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Especialidades'
ALTER TABLE [dbo].[Especialidades]
ADD CONSTRAINT [PK_Especialidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Planes'
ALTER TABLE [dbo].[Planes]
ADD CONSTRAINT [PK_Planes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tipos_Certificados'
ALTER TABLE [dbo].[Tipos_Certificados]
ADD CONSTRAINT [PK_Tipos_Certificados]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [PK_Direcciones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tipos_Documentos'
ALTER TABLE [dbo].[Tipos_Documentos]
ADD CONSTRAINT [PK_Tipos_Documentos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [PK_Matriculas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Legajos_Academicos'
ALTER TABLE [dbo].[Legajos_Academicos]
ADD CONSTRAINT [PK_Legajos_Academicos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Alteradores'
ALTER TABLE [dbo].[Alteradores]
ADD CONSTRAINT [PK_Alteradores]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Comitentes'
ALTER TABLE [dbo].[Comitentes]
ADD CONSTRAINT [PK_Comitentes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [PK_Tareas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Liquidaciones'
ALTER TABLE [dbo].[Liquidaciones]
ADD CONSTRAINT [PK_Liquidaciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [PK_Cursos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Comisiones'
ALTER TABLE [dbo].[Comisiones]
ADD CONSTRAINT [PK_Comisiones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Docentes'
ALTER TABLE [dbo].[Docentes]
ADD CONSTRAINT [PK_Docentes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Clases'
ALTER TABLE [dbo].[Clases]
ADD CONSTRAINT [PK_Clases]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Asistencias'
ALTER TABLE [dbo].[Asistencias]
ADD CONSTRAINT [PK_Asistencias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [numero] in table 'Expedientes'
ALTER TABLE [dbo].[Expedientes]
ADD CONSTRAINT [PK_Expedientes]
    PRIMARY KEY CLUSTERED ([numero] ASC);
GO

-- Creating primary key on [id] in table 'Cuotas'
ALTER TABLE [dbo].[Cuotas]
ADD CONSTRAINT [PK_Cuotas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [PK_Videos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Comprobantes_Factura'
ALTER TABLE [dbo].[Comprobantes_Factura]
ADD CONSTRAINT [PK_Comprobantes_Factura]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cuotas_Anual'
ALTER TABLE [dbo].[Cuotas_Anual]
ADD CONSTRAINT [PK_Cuotas_Anual]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cuotas_Bimensual'
ALTER TABLE [dbo].[Cuotas_Bimensual]
ADD CONSTRAINT [PK_Cuotas_Bimensual]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cuotas_Modificador'
ALTER TABLE [dbo].[Cuotas_Modificador]
ADD CONSTRAINT [PK_Cuotas_Modificador]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cuotas_Descuento_Anual'
ALTER TABLE [dbo].[Cuotas_Descuento_Anual]
ADD CONSTRAINT [PK_Cuotas_Descuento_Anual]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cuotas_Con_Recargo'
ALTER TABLE [dbo].[Cuotas_Con_Recargo]
ADD CONSTRAINT [PK_Cuotas_Con_Recargo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Comprobantes_Boleta'
ALTER TABLE [dbo].[Comprobantes_Boleta]
ADD CONSTRAINT [PK_Comprobantes_Boleta]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [numero] in table 'Expedientes_OI'
ALTER TABLE [dbo].[Expedientes_OI]
ADD CONSTRAINT [PK_Expedientes_OI]
    PRIMARY KEY CLUSTERED ([numero] ASC);
GO

-- Creating primary key on [numero] in table 'Expedientes_HM'
ALTER TABLE [dbo].[Expedientes_HM]
ADD CONSTRAINT [PK_Expedientes_HM]
    PRIMARY KEY CLUSTERED ([numero] ASC);
GO

-- Creating primary key on [numero] in table 'Expedientes_FE'
ALTER TABLE [dbo].[Expedientes_FE]
ADD CONSTRAINT [PK_Expedientes_FE]
    PRIMARY KEY CLUSTERED ([numero] ASC);
GO

-- Creating primary key on [Usuarios_id], [Grupos_id] in table 'UsuariosGrupos'
ALTER TABLE [dbo].[UsuariosGrupos]
ADD CONSTRAINT [PK_UsuariosGrupos]
    PRIMARY KEY NONCLUSTERED ([Usuarios_id], [Grupos_id] ASC);
GO

-- Creating primary key on [Profesionales_dni], [Expedientes_numero] in table 'ProfesionalExpediente'
ALTER TABLE [dbo].[ProfesionalExpediente]
ADD CONSTRAINT [PK_ProfesionalExpediente]
    PRIMARY KEY NONCLUSTERED ([Profesionales_dni], [Expedientes_numero] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Usuarios_id] in table 'UsuariosGrupos'
ALTER TABLE [dbo].[UsuariosGrupos]
ADD CONSTRAINT [FK_UsuarioGrupo_Usuario]
    FOREIGN KEY ([Usuarios_id])
    REFERENCES [dbo].[Usuarios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Grupos_id] in table 'UsuariosGrupos'
ALTER TABLE [dbo].[UsuariosGrupos]
ADD CONSTRAINT [FK_UsuarioGrupo_Grupo]
    FOREIGN KEY ([Grupos_id])
    REFERENCES [dbo].[Grupos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioGrupo_Grupo'
CREATE INDEX [IX_FK_UsuarioGrupo_Grupo]
ON [dbo].[UsuariosGrupos]
    ([Grupos_id]);
GO

-- Creating foreign key on [Grupo_id] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_PerfilGrupo]
    FOREIGN KEY ([Grupo_id])
    REFERENCES [dbo].[Grupos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilGrupo'
CREATE INDEX [IX_FK_PerfilGrupo]
ON [dbo].[Perfiles]
    ([Grupo_id]);
GO

-- Creating foreign key on [Permiso_id] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_PerfilPermiso]
    FOREIGN KEY ([Permiso_id])
    REFERENCES [dbo].[Permisos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilPermiso'
CREATE INDEX [IX_FK_PerfilPermiso]
ON [dbo].[Perfiles]
    ([Permiso_id]);
GO

-- Creating foreign key on [Formulario_id] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_PerfilFormulario]
    FOREIGN KEY ([Formulario_id])
    REFERENCES [dbo].[Formularios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilFormulario'
CREATE INDEX [IX_FK_PerfilFormulario]
ON [dbo].[Perfiles]
    ([Formulario_id]);
GO

-- Creating foreign key on [Modulo_id] in table 'Formularios'
ALTER TABLE [dbo].[Formularios]
ADD CONSTRAINT [FK_FormularioModulo]
    FOREIGN KEY ([Modulo_id])
    REFERENCES [dbo].[Modulos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormularioModulo'
CREATE INDEX [IX_FK_FormularioModulo]
ON [dbo].[Formularios]
    ([Modulo_id]);
GO

-- Creating foreign key on [Profesional_dni] in table 'CtasCtes'
ALTER TABLE [dbo].[CtasCtes]
ADD CONSTRAINT [FK_CtaCteProfesional]
    FOREIGN KEY ([Profesional_dni])
    REFERENCES [dbo].[Profesionales]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CtaCteProfesional'
CREATE INDEX [IX_FK_CtaCteProfesional]
ON [dbo].[CtasCtes]
    ([Profesional_dni]);
GO

-- Creating foreign key on [CtaCte_id] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_MovimientoCtaCte]
    FOREIGN KEY ([CtaCte_id])
    REFERENCES [dbo].[CtasCtes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MovimientoCtaCte'
CREATE INDEX [IX_FK_MovimientoCtaCte]
ON [dbo].[Movimientos]
    ([CtaCte_id]);
GO

-- Creating foreign key on [Tipo_Movimiento_id] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_Tipo_MovimientoMovimiento]
    FOREIGN KEY ([Tipo_Movimiento_id])
    REFERENCES [dbo].[Tipos_Movimientos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tipo_MovimientoMovimiento'
CREATE INDEX [IX_FK_Tipo_MovimientoMovimiento]
ON [dbo].[Movimientos]
    ([Tipo_Movimiento_id]);
GO

-- Creating foreign key on [Comprobante_id] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_ComprobanteMovimiento]
    FOREIGN KEY ([Comprobante_id])
    REFERENCES [dbo].[Comprobantes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteMovimiento'
CREATE INDEX [IX_FK_ComprobanteMovimiento]
ON [dbo].[Movimientos]
    ([Comprobante_id]);
GO

-- Creating foreign key on [Provincia_id] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [FK_ProvinciaLocalidades]
    FOREIGN KEY ([Provincia_id])
    REFERENCES [dbo].[Provincias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinciaLocalidades'
CREATE INDEX [IX_FK_ProvinciaLocalidades]
ON [dbo].[Localidades]
    ([Provincia_id]);
GO

-- Creating foreign key on [Profesional_dni] in table 'Historiales'
ALTER TABLE [dbo].[Historiales]
ADD CONSTRAINT [FK_ProfesionalHistoriales]
    FOREIGN KEY ([Profesional_dni])
    REFERENCES [dbo].[Profesionales]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalHistoriales'
CREATE INDEX [IX_FK_ProfesionalHistoriales]
ON [dbo].[Historiales]
    ([Profesional_dni]);
GO

-- Creating foreign key on [Profesional_dni] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [FK_ProfesionalDirecciones]
    FOREIGN KEY ([Profesional_dni])
    REFERENCES [dbo].[Profesionales]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalDirecciones'
CREATE INDEX [IX_FK_ProfesionalDirecciones]
ON [dbo].[Direcciones]
    ([Profesional_dni]);
GO

-- Creating foreign key on [Profesional_dni] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [FK_ProfesionalMatricula]
    FOREIGN KEY ([Profesional_dni])
    REFERENCES [dbo].[Profesionales]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalMatricula'
CREATE INDEX [IX_FK_ProfesionalMatricula]
ON [dbo].[Matriculas]
    ([Profesional_dni]);
GO

-- Creating foreign key on [Tipo_Documento_id] in table 'Profesionales'
ALTER TABLE [dbo].[Profesionales]
ADD CONSTRAINT [FK_Tipo_DocumentoProfesional]
    FOREIGN KEY ([Tipo_Documento_id])
    REFERENCES [dbo].[Tipos_Documentos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tipo_DocumentoProfesional'
CREATE INDEX [IX_FK_Tipo_DocumentoProfesional]
ON [dbo].[Profesionales]
    ([Tipo_Documento_id]);
GO

-- Creating foreign key on [Estado_id] in table 'Profesionales'
ALTER TABLE [dbo].[Profesionales]
ADD CONSTRAINT [FK_EstadoProfesional]
    FOREIGN KEY ([Estado_id])
    REFERENCES [dbo].[Estados]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoProfesional'
CREATE INDEX [IX_FK_EstadoProfesional]
ON [dbo].[Profesionales]
    ([Estado_id]);
GO

-- Creating foreign key on [Colegio_id] in table 'Profesionales'
ALTER TABLE [dbo].[Profesionales]
ADD CONSTRAINT [FK_ColegioProfesional]
    FOREIGN KEY ([Colegio_id])
    REFERENCES [dbo].[Colegios]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ColegioProfesional'
CREATE INDEX [IX_FK_ColegioProfesional]
ON [dbo].[Profesionales]
    ([Colegio_id]);
GO

-- Creating foreign key on [Tipo_Matricula_id] in table 'Profesionales'
ALTER TABLE [dbo].[Profesionales]
ADD CONSTRAINT [FK_Tipo_MatriculaProfesional]
    FOREIGN KEY ([Tipo_Matricula_id])
    REFERENCES [dbo].[Tipos_Matriculas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tipo_MatriculaProfesional'
CREATE INDEX [IX_FK_Tipo_MatriculaProfesional]
ON [dbo].[Profesionales]
    ([Tipo_Matricula_id]);
GO

-- Creating foreign key on [Jurisdiccion_id] in table 'Titulos'
ALTER TABLE [dbo].[Titulos]
ADD CONSTRAINT [FK_JurisdiccionTitulo]
    FOREIGN KEY ([Jurisdiccion_id])
    REFERENCES [dbo].[Jurisdicciones]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JurisdiccionTitulo'
CREATE INDEX [IX_FK_JurisdiccionTitulo]
ON [dbo].[Titulos]
    ([Jurisdiccion_id]);
GO

-- Creating foreign key on [Modalidad_id] in table 'Titulos'
ALTER TABLE [dbo].[Titulos]
ADD CONSTRAINT [FK_ModalidadTitulo]
    FOREIGN KEY ([Modalidad_id])
    REFERENCES [dbo].[Modalidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ModalidadTitulo'
CREATE INDEX [IX_FK_ModalidadTitulo]
ON [dbo].[Titulos]
    ([Modalidad_id]);
GO

-- Creating foreign key on [Nivel_id] in table 'Titulos'
ALTER TABLE [dbo].[Titulos]
ADD CONSTRAINT [FK_NivelTitulo]
    FOREIGN KEY ([Nivel_id])
    REFERENCES [dbo].[Niveles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NivelTitulo'
CREATE INDEX [IX_FK_NivelTitulo]
ON [dbo].[Titulos]
    ([Nivel_id]);
GO

-- Creating foreign key on [Especialidad_id] in table 'Titulos'
ALTER TABLE [dbo].[Titulos]
ADD CONSTRAINT [FK_EspecialidadTitulo]
    FOREIGN KEY ([Especialidad_id])
    REFERENCES [dbo].[Especialidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EspecialidadTitulo'
CREATE INDEX [IX_FK_EspecialidadTitulo]
ON [dbo].[Titulos]
    ([Especialidad_id]);
GO

-- Creating foreign key on [Universidad_id] in table 'Titulos'
ALTER TABLE [dbo].[Titulos]
ADD CONSTRAINT [FK_UniversidadTitulo]
    FOREIGN KEY ([Universidad_id])
    REFERENCES [dbo].[Universidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UniversidadTitulo'
CREATE INDEX [IX_FK_UniversidadTitulo]
ON [dbo].[Titulos]
    ([Universidad_id]);
GO

-- Creating foreign key on [Localidad_id] in table 'Direcciones'
ALTER TABLE [dbo].[Direcciones]
ADD CONSTRAINT [FK_LocalidadDireccion]
    FOREIGN KEY ([Localidad_id])
    REFERENCES [dbo].[Localidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalidadDireccion'
CREATE INDEX [IX_FK_LocalidadDireccion]
ON [dbo].[Direcciones]
    ([Localidad_id]);
GO

-- Creating foreign key on [Legajo_Academico_id] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [FK_MatriculaLegajo_Academico]
    FOREIGN KEY ([Legajo_Academico_id])
    REFERENCES [dbo].[Legajos_Academicos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MatriculaLegajo_Academico'
CREATE INDEX [IX_FK_MatriculaLegajo_Academico]
ON [dbo].[Matriculas]
    ([Legajo_Academico_id]);
GO

-- Creating foreign key on [Plan_id] in table 'Legajos_Academicos'
ALTER TABLE [dbo].[Legajos_Academicos]
ADD CONSTRAINT [FK_PlanLegajo_Academico]
    FOREIGN KEY ([Plan_id])
    REFERENCES [dbo].[Planes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanLegajo_Academico'
CREATE INDEX [IX_FK_PlanLegajo_Academico]
ON [dbo].[Legajos_Academicos]
    ([Plan_id]);
GO

-- Creating foreign key on [Titulo_id] in table 'Legajos_Academicos'
ALTER TABLE [dbo].[Legajos_Academicos]
ADD CONSTRAINT [FK_TituloLegajo_Academico]
    FOREIGN KEY ([Titulo_id])
    REFERENCES [dbo].[Titulos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TituloLegajo_Academico'
CREATE INDEX [IX_FK_TituloLegajo_Academico]
ON [dbo].[Legajos_Academicos]
    ([Titulo_id]);
GO

-- Creating foreign key on [Expediente_numero] in table 'Liquidaciones'
ALTER TABLE [dbo].[Liquidaciones]
ADD CONSTRAINT [FK_ExpedienteLiquidacion]
    FOREIGN KEY ([Expediente_numero])
    REFERENCES [dbo].[Expedientes]
        ([numero])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpedienteLiquidacion'
CREATE INDEX [IX_FK_ExpedienteLiquidacion]
ON [dbo].[Liquidaciones]
    ([Expediente_numero]);
GO

-- Creating foreign key on [Profesionales_dni] in table 'ProfesionalExpediente'
ALTER TABLE [dbo].[ProfesionalExpediente]
ADD CONSTRAINT [FK_ProfesionalExpediente_Profesional]
    FOREIGN KEY ([Profesionales_dni])
    REFERENCES [dbo].[Profesionales]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Expedientes_numero] in table 'ProfesionalExpediente'
ALTER TABLE [dbo].[ProfesionalExpediente]
ADD CONSTRAINT [FK_ProfesionalExpediente_Expediente]
    FOREIGN KEY ([Expedientes_numero])
    REFERENCES [dbo].[Expedientes]
        ([numero])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalExpediente_Expediente'
CREATE INDEX [IX_FK_ProfesionalExpediente_Expediente]
ON [dbo].[ProfesionalExpediente]
    ([Expedientes_numero]);
GO

-- Creating foreign key on [Comision_id] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_ComisionCurso]
    FOREIGN KEY ([Comision_id])
    REFERENCES [dbo].[Comisiones]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ComisionCurso'
CREATE INDEX [IX_FK_ComisionCurso]
ON [dbo].[Cursos]
    ([Comision_id]);
GO

-- Creating foreign key on [Docente_id] in table 'Cursos'
ALTER TABLE [dbo].[Cursos]
ADD CONSTRAINT [FK_DocenteCurso]
    FOREIGN KEY ([Docente_id])
    REFERENCES [dbo].[Docentes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocenteCurso'
CREATE INDEX [IX_FK_DocenteCurso]
ON [dbo].[Cursos]
    ([Docente_id]);
GO

-- Creating foreign key on [Curso_id] in table 'Clases'
ALTER TABLE [dbo].[Clases]
ADD CONSTRAINT [FK_CursoClase]
    FOREIGN KEY ([Curso_id])
    REFERENCES [dbo].[Cursos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoClase'
CREATE INDEX [IX_FK_CursoClase]
ON [dbo].[Clases]
    ([Curso_id]);
GO

-- Creating foreign key on [Profesional_dni] in table 'Asistencias'
ALTER TABLE [dbo].[Asistencias]
ADD CONSTRAINT [FK_ProfesionalAsistencia]
    FOREIGN KEY ([Profesional_dni])
    REFERENCES [dbo].[Profesionales]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalAsistencia'
CREATE INDEX [IX_FK_ProfesionalAsistencia]
ON [dbo].[Asistencias]
    ([Profesional_dni]);
GO

-- Creating foreign key on [Clase_id] in table 'Asistencias'
ALTER TABLE [dbo].[Asistencias]
ADD CONSTRAINT [FK_ClaseAsistencia]
    FOREIGN KEY ([Clase_id])
    REFERENCES [dbo].[Clases]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClaseAsistencia'
CREATE INDEX [IX_FK_ClaseAsistencia]
ON [dbo].[Asistencias]
    ([Clase_id]);
GO

-- Creating foreign key on [Profesional_dni] in table 'Cuotas'
ALTER TABLE [dbo].[Cuotas]
ADD CONSTRAINT [FK_ProfesionalCuota]
    FOREIGN KEY ([Profesional_dni])
    REFERENCES [dbo].[Profesionales]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalCuota'
CREATE INDEX [IX_FK_ProfesionalCuota]
ON [dbo].[Cuotas]
    ([Profesional_dni]);
GO

-- Creating foreign key on [Comitente_Id] in table 'Expedientes'
ALTER TABLE [dbo].[Expedientes]
ADD CONSTRAINT [FK_ComitenteExpediente]
    FOREIGN KEY ([Comitente_Id])
    REFERENCES [dbo].[Comitentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ComitenteExpediente'
CREATE INDEX [IX_FK_ComitenteExpediente]
ON [dbo].[Expedientes]
    ([Comitente_Id]);
GO

-- Creating foreign key on [Tarea_Id] in table 'Expedientes'
ALTER TABLE [dbo].[Expedientes]
ADD CONSTRAINT [FK_TareaExpediente]
    FOREIGN KEY ([Tarea_Id])
    REFERENCES [dbo].[Tareas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TareaExpediente'
CREATE INDEX [IX_FK_TareaExpediente]
ON [dbo].[Expedientes]
    ([Tarea_Id]);
GO

-- Creating foreign key on [id] in table 'Comprobantes_Factura'
ALTER TABLE [dbo].[Comprobantes_Factura]
ADD CONSTRAINT [FK_Factura_inherits_Comprobante]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Comprobantes]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Cuotas_Anual'
ALTER TABLE [dbo].[Cuotas_Anual]
ADD CONSTRAINT [FK_Anual_inherits_Cuota]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Cuotas]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Cuotas_Bimensual'
ALTER TABLE [dbo].[Cuotas_Bimensual]
ADD CONSTRAINT [FK_Bimensual_inherits_Cuota]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Cuotas]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Cuotas_Modificador'
ALTER TABLE [dbo].[Cuotas_Modificador]
ADD CONSTRAINT [FK_Modificador_inherits_Cuota]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Cuotas]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Cuotas_Descuento_Anual'
ALTER TABLE [dbo].[Cuotas_Descuento_Anual]
ADD CONSTRAINT [FK_Descuento_Anual_inherits_Modificador]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Cuotas_Modificador]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Cuotas_Con_Recargo'
ALTER TABLE [dbo].[Cuotas_Con_Recargo]
ADD CONSTRAINT [FK_Con_Recargo_inherits_Modificador]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Cuotas_Modificador]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Comprobantes_Boleta'
ALTER TABLE [dbo].[Comprobantes_Boleta]
ADD CONSTRAINT [FK_Boleta_inherits_Comprobante]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Comprobantes]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [numero] in table 'Expedientes_OI'
ALTER TABLE [dbo].[Expedientes_OI]
ADD CONSTRAINT [FK_OI_inherits_Expediente]
    FOREIGN KEY ([numero])
    REFERENCES [dbo].[Expedientes]
        ([numero])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [numero] in table 'Expedientes_HM'
ALTER TABLE [dbo].[Expedientes_HM]
ADD CONSTRAINT [FK_HM_inherits_Expediente]
    FOREIGN KEY ([numero])
    REFERENCES [dbo].[Expedientes]
        ([numero])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [numero] in table 'Expedientes_FE'
ALTER TABLE [dbo].[Expedientes_FE]
ADD CONSTRAINT [FK_FE_inherits_Expediente]
    FOREIGN KEY ([numero])
    REFERENCES [dbo].[Expedientes]
        ([numero])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------