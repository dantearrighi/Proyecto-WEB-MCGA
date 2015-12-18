<%@ Page Title="Gestión de Titulo" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Titulo.aspx.cs" Inherits="Vista_Web.Titulo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Div1" runat="server" class="row">
                <div id="Div2" runat="server" class="col-lg-offset-3 col-lg-6">
                    <div class="page-header">
                        <h1>Gestión de Titulo <small>Módulo de Titulos</small></h1>
                    </div>
                    <div>
                        <ul id="myTab" class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#datos" role="tab" data-toggle="tab" title="Gestión de Titulo">Datos</a></li>
                            <li class=""><a href="#planes" role="tab" data-toggle="tab">Planes</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content small-panel">
                            <div class="tab-pane fade active in" id="datos">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label id="Label1" runat="server" for="cmb_universidad" class="col-sm-2 control-label">Universidad</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_universidad" runat="server" class="form-control" OnSelectedIndexChanged="cmb_universidad_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_titulo" class="col-sm-2 control-label">Desripción</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txt_titulo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_leyaprobacion" class="col-sm-2 control-label">Ley de aprobación</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txt_leyaprobacion" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="txt_coneau" class="col-sm-4 control-label">Resolución de CONEAU</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txt_coneau" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label id="Label3" runat="server" for="cmb_jurisdiccion" class="col-sm-2 control-label">Jurisdicción</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_jurisdiccion" runat="server" class="form-control" OnSelectedIndexChanged="cmb_jurisdiccion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <label id="Label4" runat="server" for="cmb_modalidad" class="col-sm-2 control-label">Modalidad</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_modalidad" runat="server" class="form-control" OnSelectedIndexChanged="cmb_modalidad_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label id="Label5" runat="server" for="cmb_nivel" class="col-sm-2 control-label">Nivel</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_nivel" runat="server" class="form-control" OnSelectedIndexChanged="cmb_nivel_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <label for="txt_terminovalidez" class="col-sm-4 control-label">Término de la validez</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txt_terminovalidez" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        
                                    </div>
                                    <div class="form-group">
                                    <label for="txt_aprobacioncie" class="col-sm-4 control-label">Aprobación en CIE</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_aprobacioncie" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label id="Label6" runat="server" for="cmb_especialidades" class="col-sm-2 control-label">Especialidad</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_especialidades" runat="server" class="form-control" OnSelectedIndexChanged="cmb_especialidades_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="planes">
                                <div class="form form-horizontal" role="form">
                                    <div id="Div6" runat="server" class="col-lg-12">
                                        <label class="control-label">Planes del título</label>
                                        <div style="height: auto; overflow: auto;" class="form-group">
                                            <%--OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" - OnRowCreated="gvUsuarios_RowCreated"--%>
                                            <asp:GridView ID="dgv_planes" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnRowCreated="dgv_planes_RowCreated">
                                                <SelectedRowStyle BackColor="#E8E8E8" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="form-group col-lg-12 text-center">
                                        <asp:Button ID="btn_agregar" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btn_agregar_Click" />
                                        <asp:Button ID="btn_modificar" runat="server" CssClass="btn btn-primary" Text="Modificar" OnClick="btn_modificar_Click" />
                                        <asp:Button ID="btn_ver_detalle" runat="server" CssClass="btn btn-info" Text="Ver detalle" OnClick="btn_ver_detalle_Click" />
                                        <asp:Button ID="btn_eliminar" runat="server" CssClass="btn btn-default" Text="Eliminar" OnClick="btn_eliminar_Click" />
                                    </div>
                                    <div class="form-group col-lg-12 text-center">
                                        <asp:Label ID="mje_plan" runat="server" Text="Para poder cargar un mensaje debe primero cargar el plan" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                        <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                        <asp:Label ID="lb_error" runat="server" Text="Mensaje" Visible="True"></asp:Label>
                    </div>
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" CssClass="btn btn-success pull-right margin-left-5" Text="Guardar" />
                        <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right" Text="Cancelar" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido_Especial" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <%--Modal--%>
            <div class="modal fade" id="modal_eliminar" tabindex="-1" role="dialog" aria-labelledby="Inhabilitar Usuario" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button id="btn_cerrar_modal" runat="server" type="button" class="close" data-dismiss="modal_eliminar"><span id="Span3" runat="server" aria-hidden="true">&times;</span><span id="Span4" runat="server" class="sr-only">Cerrar</span></button>
                            <h4 class="modal-title">Eliminar plan</h4>
                        </div>
                        <div class="modal-body">
                            <p>¿Está seguro que desea eliminar al plan seleccionado?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btn_cancelar_modal" data-dismiss="modal_eliminar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btn_cancelar_modal_Click" />
                            <asp:Button ID="btn_eliminar_modal" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btn_eliminar_modal_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>