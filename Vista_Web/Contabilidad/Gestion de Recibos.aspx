<%@ Page Title="Gestión de Recibos" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Gestion de Recibos.aspx.cs" Inherits="Vista_Web.Recibos" %>

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
                            <h1>Gestión de Recibos <small title="Gestión de Recibos">Módulo de Contabilidad</small></h1>
                        </div>
                    </div>
                </div>
                <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                    <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                    <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                </div>
                <div id="Div1" runat="server" class="row">
                    <div class="form-horizontal">
                        <div id="Div2" runat="server" class="form-group">
                            <div class="col-sm-2">
                                <asp:Button ID="btn_seleccionar_prof" runat="server" CssClass="btn btn-primary margin-left-5" Text="Seleccionar profesional" OnClick="btn_seleccionar_prof_Click" Enabled="true" />
                            </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txt_profesional" runat="server" type="text" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="btn_cobrar_cuotas" runat="server" CssClass="btn btn-primary margin-left-5" Text="Cobrar cuotas" OnClick="btn_cobrar_cuotas_Click" />
                                <asp:Button ID="btn_cobrar_expediente" runat="server" CssClass="btn bg-success" Text="Cobrar expedientes" OnClick="btn_cobrar_expediente_Click" />
                            </div>
                        </div>
                    </div>
                    <div style="height: 300px; overflow: auto;" class="form-group">
                        <asp:GridView ID="gvRecibos" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvRecibos_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvRecibos_SelectedIndexChanged">
                            <SelectedRowStyle BackColor="#E8E8E8" />
                        </asp:GridView>
                    </div>

                    <div id="Div3" runat="server" class="form-group">
                        <div class="col-sm-9">
                            <asp:Button ID="btn_cancelar" runat="server" CssClass="btn btn-default margin-left-5" Text="Cancelar" OnClick="btn_cancelar_Click" />
                            <asp:Button ID="btn_imprimir" runat="server" CssClass="btn btn-warning" Text="Cobrar e Imprimir" OnClick="btn_imprimir_Click" />
                        </div>
                        <div class="col-sm-1">
                            <asp:Label ID="Label1" runat="server" Text="Total" CssClass="control-label"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox ID="txt_total" runat="server" type="text" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenido_Especial" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--Modal--%>
            <div class="modal fade" id="modal_eliminar" tabindex="-1" role="dialog" aria-labelledby="Inhabilitar Usuario" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button id="btn_cerrar_modal" runat="server" type="button" class="close" data-dismiss="modal_eliminar"><span id="Span3" runat="server" aria-hidden="true">&times;</span><span id="Span4" runat="server" class="sr-only">Cerrar</span></button>
                            <h4 class="modal-title">Seleccionar cuotas</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <div style="height: 300px; overflow: auto;" class="form-group">
                                    <asp:CheckBoxList ID="chk_cuotas" runat="server" AutoPostBack="False" ClientIDMode="AutoID" Height="20px" Width="200px">
                                    </asp:CheckBoxList>
                                </div>
                                <%--<div class="col-sm-2">
                                    <asp:Label ID="Label2" runat="server" Text="Total"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txt_total_cuotas" runat="server" type="number" class="form-control"></asp:TextBox>
                                </div>--%>
                                <%--<div class="col-sm-4">
                                    <asp:Button ID="btn_calcular" runat="server" Text="Calcular" class="btn btn-primary" OnClick="btn_calcular_Click"/>
                                </div>--%>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:CheckBox ID="chk_intereses" runat="server" Text="Incluir intereses" />
                            <asp:Button ID="btn_cancelar_modal" data-dismiss="modal_eliminar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btn_cancelar_modal_Click" />
                            <asp:Button ID="btn_aceptar_modal" runat="server" Text="Aceptar" class="btn btn-success" OnClick="btn_aceptar_modal_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
