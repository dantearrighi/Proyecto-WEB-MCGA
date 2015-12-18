<%@ Page Title="Matrículas del profesional" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Matriculas Profesional.aspx.cs" Inherits="Vista_Web.Matriculas_Profesional" %>

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
                        <h1>Matrículas del profesional <small>Módulo de Profesional</small></h1>
                    </div>
                    <div>
                        <ul id="myTab" class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#datos" role="tab" data-toggle="tab" title="Gestión de Grupo">Datos</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content small-panel">
                            <div class="tab-pane fade active in" id="datos">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label for="cmb_universidad" class="col-lg-2 control-label">Universidad</label>
                                        <div class="col-lg-10">
                                            <asp:DropDownList AutoPostBack="True" ID="cmb_universidad" runat="server" CssClass="form-control" OnSelectedIndexChanged="cmb_universidad_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="cmb_titulos" class="col-lg-2 control-label">Título</label>
                                        <div class="col-lg-10">
                                            <asp:DropDownList AutoPostBack="True" ID="cmb_titulos" runat="server" CssClass="form-control" OnSelectedIndexChanged="cmb_titulos_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="cmb_planes" class="col-lg-2 control-label">Plan</label>
                                        <div class="col-lg-3">
                                            <asp:DropDownList AutoPostBack="True" ID="cmb_planes" runat="server" CssClass="form-control" OnSelectedIndexChanged="cmb_planes_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <label id="Label1" class="col-lg-2 control-label" runat="server" for="diploma">Documento</label>
                                        <div class="col-lg-5">
                                            <asp:DropDownList ID="diploma" runat="server" CssClass="form-control">
                                                <asp:ListItem>Diploma</asp:ListItem>
                                                <asp:ListItem>Certificado</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_fechadoc" class="col-lg-1 control-label">Fecha</label>
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="txt_fechadoc" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <asp:CheckBox ID="chk_incumbencias" runat="server" CssClass="col-lg-3 control-label" Text="Incumbencias"/>
                                        <asp:CheckBox ID="chk_plan" runat="server" CssClass="col-lg-2 control-label" Text="Plan"/>
                                        <asp:CheckBox ID="chk_analitico" runat="server" CssClass="col-lg-2 control-label" Text="Analítico"/>
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
