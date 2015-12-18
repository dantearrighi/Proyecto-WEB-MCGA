<%@ Page Title="Gestión de Usuario" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Vista_Web.Usuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Div1" runat="server" class="row">
                <div id="Div2" runat="server" class="col-lg-offset-3 col-lg-6" title="Gestión de Usuario">
                    <div class="page-header">
                        <h1>Gestión de Usuario <small>Módulo de Seguridad</small></h1>
                    </div>
                    <div>
                        <ul id="myTab" class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#datos" role="tab" data-toggle="tab">Datos</a></li>
                            <li class=""><a href="#grupos" role="tab" data-toggle="tab">Grupos</a></li>
                            <li class=""><a href="#contraseña" role="tab" data-toggle="tab">Contraseña</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content small-panel">
                            <div class="tab-pane fade active in" id="datos">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label for="txt_nombreapellido" class="col-sm-4 control-label">Nombre y apellido</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_nombreapellido" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_email" class="col-sm-4 control-label">Email</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_email" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_nombreusuario" class="col-sm-4 control-label">Usuario</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_nombreusuario" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            <div class="checkbox">
                                                <label>
                                                    <asp:CheckBox ID="chk_estado" runat="server" />
                                                    Activo
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="grupos">
                                <div style="height: 300px; overflow: auto;" class="form-group">
                                    <asp:CheckBoxList ID="chklstbox_grupos" runat="server" AutoPostBack="False" ClientIDMode="AutoID" Height="16px" Width="383px" RepeatColumns="1">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="contraseña">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label for="txt_nuevacontraseña" class="col-sm-4 control-label">Contraseña actual</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_contraseña_actual" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_nuevacontraseña" class="col-sm-4 control-label">Nueva contraseña</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_nuevacontraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_repetircontraseña" class="col-sm-4 control-label">Repetir Contraseña</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_repetircontraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:Button ID="btn_cambiarpass" runat="server" OnClick="btn_cambiarpass_Click" CssClass="btn btn-danger" Text="Cambiar contraseña" />
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
