<%@ Page Title="Gestión de Estadísticas" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Estadísticas.aspx.cs" Inherits="Vista_Web.Estadisticas" %>

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
                        <h1>Gestión de Estadisticas <small>Módulo de Estadisticas</small></h1>
                    </div>
                    <div>
                        <div class="form-horizontal" role="form">
                            <div class="form-group margin-buttom-10">
                                <label for="cmb_listado" class="col-sm-4 control-label">Listado:</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="cmb_listado" runat="server" class="form-control">
                                        <asp:ListItem>Profesionales por estado</asp:ListItem>
                                        <asp:ListItem>Matrículas por especialidad</asp:ListItem>
                                        <asp:ListItem>Profesionales por tipo de matrícula</asp:ListItem>
                                        <asp:ListItem>Títulos por universidad</asp:ListItem>
                                        <asp:ListItem>Títulos por especialidad</asp:ListItem>
                                        <asp:ListItem>Cuotas por especialidad</asp:ListItem>
                                        <asp:ListItem>Cuotas por descripción</asp:ListItem>
                                        <asp:ListItem>Expedientes por especialidad</asp:ListItem>
                                        <asp:ListItem>Montos de expdientes por especialidad</asp:ListItem>
                                        <asp:ListItem>Expedientes por tarea</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="Div3" runat="server" class="form-group">
                                <div class="col-sm-6">
                                    <label id="Label1" runat="server" for="desde">Desde:</label>
                                    <asp:Calendar ID="desde" runat="server"></asp:Calendar>
                                </div>

                                <div class="col-sm-6">
                                    <label id="Label2" runat="server" for="desde">Hasta:</label>
                                    <asp:Calendar ID="hasta" runat="server"></asp:Calendar>
                                </div>
                                <%--<asp:TextBox ID="txt_fecha_desde" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre del usuario"></asp:TextBox>--%>
                            </div>
                            
                        </div>
                    </div>
                    <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                        <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                        <asp:Label ID="lb_error" runat="server" Text="Mensaje" Visible="True"></asp:Label>
                    </div>
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" CssClass="btn btn-success pull-right margin-left-5" Text="Emitir" />
                        <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right" Text="Cancelar" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
