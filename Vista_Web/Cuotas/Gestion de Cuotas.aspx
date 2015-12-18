<%@ Page Title="Gestión de Cuotas" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Gestion de Cuotas.aspx.cs" Inherits="Vista_Web.Cuotas" %>

<%@ Register Src="../Botoneras/Botonera1.ascx" TagName="Botonera1" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="container">
                <div runat="server" class="row">
                    <div runat="server" class="col-lg-12">
                        <div class="page-header">
                            <h1>Gestión de Cuotas <small title="Gestión de Cuotas">Módulo de Cuotas</small></h1>
                        </div>
                    </div>
                </div>
                <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                    <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                    <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                </div>
                <div id="Div1" runat="server" class="row">
                    <div class="form-horizontal">
                        <div class="well">
                            <div class="form-group">
                                <label class="col-sm-4 control-label" runat="server" for="txt_porcentaje">Porcentaje de recargo (sobre los días de mora)</label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="txt_porcentaje" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                                <label id="Label6" class="col-sm-4 control-label" runat="server" for="txt_dias_gracias">Días de gracia (antes del cobro de los intereses)</label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="txt_dias_gracias" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div id="Div2" runat="server" class="form-group">
                                <label class="col-sm-4 control-label" id="Label4" runat="server" for="txt_valor_bimensual">Valor de la cuota bimensual</label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="txt_valor_bimensual" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                                <asp:Button ID="btn_guardar" runat="server" CssClass="btn btn-primary pull-right margin-left-5" Text="Guardar" OnClick="btn_guardar_Click" />
                                <asp:Button ID="btn_cancelar" runat="server" CssClass="btn btn-default pull-right" Text="Cancelar" OnClick="btn_cancelar_Click" />
                                <asp:Button ID="btn_editar" runat="server" CssClass="btn btn-warning" Text="Editar Valores" OnClick="btn_editar_Click"/>                                
                            </div>
                        </div>
                        <div class="well">
                            <div class="form-group">
                                <label id="Label1" class="control-label col-sm-1" runat="server" for="nud_año">Año</label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="nud_año" runat="server" type="number" class="form-control" min="2013" max="2020"></asp:TextBox>
                                </div>
                                <label id="Label2" runat="server" for="cmb_cuota" class="col-sm-2 control-label">Tipo de cuota</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList AutoPostBack="true" ID="cmb_cuota" runat="server" class="form-control">
                                        <asp:ListItem>Bimensual</asp:ListItem>
                                        <asp:ListItem>Anual</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label id="Label3" class="control-label col-sm-2" runat="server" for="nud_año">Número de cuota</label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="nud_cuontas_numeros" runat="server" type="number" class="form-control" min="1" max="6"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label id="Label7" runat="server" for="cmb_tipo_matricula" class="col-sm-3 control-label">Tipo de matrícula</label>
                                <div class="col-sm-5">
                                    <asp:DropDownList AutoPostBack="true" ID="cmb_tipo_matricula" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>
                                <asp:Button ID="btn_generar" runat="server" CssClass="btn btn-danger col-sm-4" Text="Generar cuota seleccionada" OnClick="btn_generar_Click" />
                            </div>
                        </div>
                        <div class="well">
                            <div id="Div4" runat="server" class="form-group">
                                <label id="Label5" runat="server" for="nud_año_corrimiento" class="col-sm-1 control-label">Año</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="nud_año_corrimiento" runat="server" type="number" class="form-control" min="2013" max="2020"></asp:TextBox>
                                </div>
                                <div class="col-sm-8">
                                    <asp:Button ID="btn_corrimiento" runat="server" CssClass="btn btn-success" Text="Generar corrimiento para el año seleccionada" OnClick="btn_corrimiento_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

