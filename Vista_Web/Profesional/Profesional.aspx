<%@ Page Title="Gestión de Profesional" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Profesional.aspx.cs" Inherits="Vista_Web.Profesional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div runat="server" class="alert alert-warning error-message" role="alert" visible="false" id="message">
                <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                <asp:Label ID="lb_error" runat="server" Text="Mensaje" Visible="True"></asp:Label>
            </div>
            <div class="container">
                <div id="Div1" runat="server" class="row">
                    <div id="Div2" runat="server" class="col-lg-12">
                        <div class="page-header">
                            <h1>Gestión de Profesional <small>Módulo de Profesionales</small></h1>
                        </div>
                    </div>
                    <div id="Div3" runat="server" class="col-lg-12">
                        <ul id="myTab" class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#datos" role="tab" data-toggle="tab">Datos personales</a></li>
                            <li class=""><a href="#matriculas" role="tab" data-toggle="tab">Matrículas</a></li>
                            <li class=""><a href="#titulos" role="tab" data-toggle="tab">Títulos</a></li>
                            <li class=""><a href="#contabilidad" role="tab" data-toggle="tab">Contabilidad</a></li>
                            <li class=""><a href="#expedientes" role="tab" data-toggle="tab">Expedientes</a></li>
                            <li class=""><a href="#otros" role="tab" data-toggle="tab">Otros</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content small-panel">

                            <div class="tab-pane fade active in" id="datos">
                                <div class="form form-horizontal" role="form">
                                    <%--Datos principales--%>
                                    <div class="form-group">
                                        <label for="txt_nombreapellido" class="col-lg-2 control-label">Nombre y apellido</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_nombreapellido" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="cmb_tiposdoc" class="col-lg-2 control-label">Tipo documento</label>
                                        <div class="col-lg-2">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_tiposdoc" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <label for="txt_numero" class="col-lg-1 control-label">DNI</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="txt_numero" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div runat="server" class="form-group">
                                        <label class="col-lg-2 control-label" runat="server" for="txt_fechanacimiento">Fecha de nacimiento</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_fechanacimiento" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <label id="Label1" class="col-lg-2 control-label" runat="server" for="txt_fechanacimiento">Sexo</label>
                                        <div class="radio col-lg-3">
                                            <asp:DropDownList ID="sexo" runat="server" CssClass="form-control">
                                                <asp:ListItem>Masculino</asp:ListItem>
                                                <asp:ListItem>Femenino</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_telfijo" class="col-lg-2 control-label">Teléfono Fijo</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_telfijo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="txt_celular" class="col-lg-2 control-label">Celular</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_celular" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_emailpricipal" class="col-lg-2 control-label">Email principal</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_emailpricipal" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="txt_emailalternativo" class="col-lg-2 control-label">Email alternativo</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_emailalternativo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:CheckBox ID="chk_mismolugar" runat="server" OnCheckedChanged="chk_mismolugar_CheckedChanged" Text=" El lugar de envío es el mismo que el de residencia" />
                                    </div>
                                    <%--Direcciones--%>
                                    <div class="panel-group" id="accordionDirecciones">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordionDirecciones" href="#collapseOne">Lugar de residencia
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseOne" class="panel-collapse collapse in">
                                                <div class="panel-body">
                                                    <div class="form" role="form">
                                                        <div class="form-group">
                                                            <label for="txt_direccion" class="col-lg-2 control-label">Dirección</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txt_direccion" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <label for="txt_cp" class="col-lg-2 control-label">Código postal</label>
                                                            <div class="col-lg-2">
                                                                <asp:TextBox ID="txt_cp" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cmb_localidades" class="col-lg-2 control-label">Localidad</label>
                                                            <div class="col-lg-4">
                                                                <asp:DropDownList AutoPostBack="False" ID="cmb_localidades" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <label for="cmb_provincias" class="col-lg-2 control-label">Provincia</label>
                                                            <div class="col-lg-4">
                                                                <asp:DropDownList AutoPostBack="False" ID="cmb_provincias" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a data-toggle="collapse" data-parent="#accordionDirecciones" href="#collapseTwo">Lugar de Envío
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseTwo" class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        <div class="form" role="form">
                                                            <div class="form-group">
                                                                <label for="txt_direccionE" class="col-lg-2 control-label">Dirección</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txt_direccionE" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label for="txt_cpE" class="col-lg-2 control-label">Código postal</label>
                                                                <div class="col-lg-2">
                                                                    <asp:TextBox ID="txt_cpE" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="cmb_localidadesE" class="col-lg-2 control-label">Localidad</label>
                                                                <div class="col-lg-4">
                                                                    <asp:DropDownList AutoPostBack="False" ID="cmb_localidadesE" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <label for="cmb_provinciasE" class="col-lg-2 control-label">Provincia</label>
                                                                <div class="col-lg-4">
                                                                    <asp:DropDownList AutoPostBack="False" ID="cmb_provinciasE" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane fade" id="matriculas">
                                <div class="form form-horizontal" role="form">
                                    <div class="well well-lg col-lg-4 warning text-center">
                                        <asp:Label ID="lb_estado_def" runat="server" Text="Label" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <label for="cmb_tipomatricula" class="col-lg-2 control-label">Tipo de matrícula</label>
                                        <div class="col-lg-3">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_tipomatricula" runat="server" CssClass="form-control" OnTextChanged="cmb_tipomatricula_TextChanged" OnSelectedIndexChanged="cmb_tipomatricula_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <asp:Button ID="btn_baja" runat="server" CssClass="btn btn-danger col-lg-1 pull-right margin-left-5" Text="Suspender" OnClick="btn_baja_Click" />
                                        <asp:Button ID="btn_alta" runat="server" CssClass="btn btn-success col-lg-1 pull-right" Text="Habilitar" OnClick="btn_alta_Click" />
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_lugartrabajo" class="col-lg-2 control-label">Lugar de trabajo</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txt_lugartrabajo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="cmb_colegios" class="col-lg-2 control-label">Colegio</label>
                                        <div class="col-lg-5">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_colegios" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <label for="txt_año" class="col-lg-2 control-label">Año de habilitación</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_año" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="Div5" runat="server" class="col-lg-12">
                                        <label class="control-label">Historial (para ver los cambios luego de realiarlos, debe voler a ingresar a la ficha)</label>
                                        <div style="height: auto; overflow: auto;" class="form-group">
                                            <%--OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" - OnRowCreated="gvUsuarios_RowCreated"--%>
                                            <asp:GridView ID="dgv_historial" runat="server" AutoGenerateSelectButton="False" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnRowCreated="dgv_historial_RowCreated">
                                                <SelectedRowStyle BackColor="#E8E8E8" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_observaciones_historial" class="col-lg-2 control-label">Observaciones</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txt_observaciones_historial" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane fade" id="titulos">
                                <div class="form form-horizontal" role="form">
                                    <div id="Div6" runat="server" class="col-lg-12">
                                        <label class="control-label">Matrículas del profesional</label>
                                        <div style="height: auto; overflow: auto;" class="form-group">
                                            <%--OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" - OnRowCreated="gvUsuarios_RowCreated"--%>
                                            <asp:GridView ID="dgv_matriculas" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnRowCreated="dgv_matriculas_RowCreated">
                                                <SelectedRowStyle BackColor="#E8E8E8" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="form-group col-lg-12 text-center">
                                        <asp:Button ID="btn_agregar" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btn_agregar_Click" />
                                        <asp:Button ID="btn_modificar" runat="server" CssClass="btn btn-primary" Text="Modificar" OnClick="btn_modificar_Click" />
                                        <asp:Button ID="btn_ver_detalle" runat="server" CssClass="btn btn-info" Text="Ver detalle" OnClick="btn_ver_detalle_Click" />
                                        <asp:Button ID="btn_imprimirtitulo" runat="server" CssClass="btn btn-default" Text="Imprimir" OnClick="btn_imprimirtitulo_Click" />
                                    </div>
                                    <div class="form-group col-lg-12 text-center">
                                        <asp:Label ID="mje_titulos" runat="server" Text="Antes de cargar un título, debe guardar al profesional" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane fade" id="contabilidad">
                                <div class="form form-horizontal" role="form">
                                    <div id="Div8" runat="server" class="col-lg-6">
                                        <label class="control-label">Cuotas impagas</label>
                                        <div style="height: auto; overflow: auto;" class="form-group">
                                            <%--OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" - OnRowCreated="gvUsuarios_RowCreated"--%>
                                            <asp:GridView ID="dgv_deudas" runat="server" AutoGenerateSelectButton="False" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="True" OnRowCreated="dgv_deudas_RowCreated">
                                                <SelectedRowStyle BackColor="#E8E8E8" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div id="Div7" runat="server" class="col-lg-6">
                                        <label class="control-label">Cuotas pagas</label>
                                        <div style="height: auto; overflow: auto;" class="form-group">
                                            <%--OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" - OnRowCreated="gvUsuarios_RowCreated"--%>
                                            <asp:GridView ID="dgv_creditos" runat="server" AutoGenerateSelectButton="False" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="True" OnRowCreated="dgv_creditos_RowCreated">
                                                <SelectedRowStyle BackColor="#E8E8E8" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btn_imprimirboletas" runat="server" CssClass="btn btn-primary col-lg-2 pull-left" Text="Reimprimir boletas" OnClick="btn_imprimirboletas_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="expedientes">
                                <div class="form form-horizontal" role="form">
                                    <div id="Div10" runat="server" class="col-lg-10">
                                        <label class="control-label">Historial de expedientes</label>
                                        <div style="height: auto; overflow: auto;" class="form-group">
                                            <%--OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" - OnRowCreated="gvUsuarios_RowCreated"--%>
                                            <asp:GridView ID="dgv_expedeintes" runat="server" AutoGenerateSelectButton="False" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="True" OnRowCreated="dgv_expedeintes_RowCreated">
                                                <SelectedRowStyle BackColor="#E8E8E8" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="otros">
                                <div class="form form-horizontal" role="form">
                                    <div class="form-group">
                                        <label for="cmb_titulo_certhabilitacion" class="col-lg-1 control-label">Título</label>
                                        <div class="col-lg-2">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_titulo_certhabilitacion" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <label for="cmb_tipocertificado" class="col-lg-2 control-label">Tipo de certificado</label>
                                        <div class="col-lg-4">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_tipocertificado" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <asp:Button ID="btn_imprimircertificadoH" runat="server" CssClass="btn btn-default col-lg-3 pull-right" Text="Imprimir certificado" OnClick="btn_imprimircertificadoH_Click" />
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_observaciones" class="col-lg-2 control-label">Orbservaciones</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txt_observaciones" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <%--<div class="form-group">
                                        <label for="cmb_tituloamostrar" class="col-lg-2 control-label">Título a mostrar</label>
                                        <div class="col-lg-2">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_tituloamostrar" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" CssClass="btn btn-success pull-right margin-left-5" Text="Guardar" />
                                <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right" Text="Cancelar" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--Modal--%>
                <div class="modal fade" id="modal_eliminar" tabindex="-1" role="dialog" aria-labelledby="Inhabilitar Usuario" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button id="btn_cerrar_modal" runat="server" type="button" class="close" data-dismiss="modal_eliminar"><span id="Span3" runat="server" aria-hidden="true">&times;</span><span id="Span4" runat="server" class="sr-only">Cerrar</span></button>
                                <h4 class="modal-title">Modificación del estado del profesional</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lb_mensaje_estado" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btn_cancelar_modal" data-dismiss="modal_eliminar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btn_cancelar_modal_Click" />
                                <asp:Button ID="btn_eliminar_modal" runat="server" Text="Aceptar" class="btn btn-danger" OnClick="btn_eliminar_modal_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>