<%@ Page Title="Planes Titulo" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Planes Titulo.aspx.cs" Inherits="Vista_Web.Planes_Titulo" %>

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
                        <h1>Planes del título <small>Módulo de Titulos</small></h1>
                    </div>
                    <div>
                        <ul id="myTab" class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#datos" role="tab" data-toggle="tab" title="Gestión de Grupo">Datos</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content small-panel">
                            <div class="tab-pane fade active in" id="datos">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label for="txt_año" class="col-lg-2 control-label">Plan</label>
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="txt_año" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="txt_ordenanzaconsejo" class="col-lg-2 control-label">Ordenanza</label>
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="txt_ordenanzaconsejo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_plan_descripcion" class="col-lg-2 control-label">Descripción del plan</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txt_plan_descripcion" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_incumbencia" class="col-lg-2 control-label">Incumbencia</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txt_incumbencia" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
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
