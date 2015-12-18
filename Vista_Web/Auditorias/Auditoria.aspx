<%@ Page Title="Gestión de Auditoria" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Auditoria.aspx.cs" Inherits="Vista_Web.Auditoria" %>

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
                        <h1>Gestión de Auditoria<small> Módulo de Auditoria</small></h1>
                    </div>
                    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label for="txt_nombreapellido" class="col-sm-4 control-label">Usuario</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txt_nombreapellido" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_fecha" class="col-sm-4 control-label">Fecha</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txt_fecha" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_accion" class="col-sm-4 control-label">Acción</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txt_accion" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btn_cerrar" runat="server" OnClick="btn_cerrar_Click" CssClass="btn btn-default pull-right" Text="Cerrar" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
