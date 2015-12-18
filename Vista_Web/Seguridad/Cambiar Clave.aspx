<%@ Page Title="Gestión de Usuario" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Cambiar Clave.aspx.cs" Inherits="Vista_Web.Cambiar_Clave" %>

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
                        <h1>Cambio de clave <small>Módulo de Seguridad</small></h1>
                    </div>
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
                    </div>
                    <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                        <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                        <asp:Label ID="lb_error" runat="server" Text="Mensaje" Visible="True"></asp:Label>
                    </div>
                    <div class="pull-right">
                        <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default" Text="Cancelar" />
                        <asp:Button ID="btn_cambiarpass" runat="server" OnClick="btn_cambiarpass_Click" CssClass="btn btn-danger" Text="Cambiar contraseña" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
