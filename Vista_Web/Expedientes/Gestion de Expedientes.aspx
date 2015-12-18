<%@ Page Title="Gestión de Expedientes" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Gestion de Expedientes.aspx.cs" Inherits="Vista_Web.Expedientes" %>

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
                        <div class="page-header" title="Gestión de Expedientes">
                            <h1>Gestión de Expedientes <small>Módulo de Expedientes</small></h1>
                        </div>
                    </div>
                    <div id="Div4" runat="server" class="col-lg-4">
                        <div runat="server" class="form-group">
                            <label runat="server" for="txt_profesional">DNI del profesional</label>
                            <asp:TextBox ID="txt_profesional" runat="server" type="text" class="form-control" placeholder="DNI del profesional"></asp:TextBox>
                        </div>
                        <div id="Div5" runat="server" class="form-group">
                            <label id="Label1" runat="server" for="txt_nya_comitente">Razón social del comitente</label>
                            <asp:TextBox ID="txt_nya_comitente" runat="server" type="text" class="form-control" placeholder="Razón social"></asp:TextBox>
                        </div>
                        <div runat="server" class="form-group">
                            <label runat="server" for="cmb_obra">Obra</label>
                            <asp:DropDownList ID="cmb_obra" runat="server" class="form-control" OnSelectedIndexChanged="cmb_obra_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Obras de Ingenieria</asp:ListItem>
                                    <asp:ListItem>Fuerza Electromotriz</asp:ListItem>
                                    <asp:ListItem>Honorario Minimo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="Div6" runat="server" class="form-group">
                            <label id="Label2" runat="server" for="cmb_descripcion_tarea">Tarea</label>
                            <asp:DropDownList ID="cmb_descripcion_tarea" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                        <div id="Div1" runat="server" class="form-group">
                            <asp:Button ID="btn_filtrar" runat="server" OnClick="btn_filtrar_Click" Text="Filtrar" class="btn btn-info" />
                            &nbsp;&nbsp;
                        <asp:Button ID="btn_nuevaconsulta" runat="server" OnClick="btn_nuevaconsulta_Click" Text="Nueva Consulta" class="btn btn-default" />
                        </div>
                        <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                            <button runat="server" type="button" class="close" data-dismiss="alert"><span runat="server" aria-hidden="true">&times;</span><span runat="server" class="sr-only">Cerrar</span></button>
                            <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                        </div>
                    </div>
                    <div id="Div3" runat="server" class="col-lg-8">
                        <div style="height: 300px; overflow: auto;" class="form-group">
                            <asp:GridView ID="gvExpedientes" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="True" OnSelectedIndexChanged="gvExpedientes_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#E8E8E8" />
                            </asp:GridView>
                        </div>
                        <div id="Div2" runat="server" class="form-group">
                            <uc1:Botonera1 ID="botonera1" runat="server" OnClick_Alta="botonera1_Click_Alta" OnClick_Cerrar="botonera1_Click_Cerrar" OnClick_Consulta="botonera1_Click_Consulta" OnClick_Modificacion="botonera1_Click_Modificacion" />
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
                            <button id="btn_cerrar_modal" runat="server" type="button" class="close" data-dismiss="modal_detalle_titulo"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                            <h4 class="modal-title">Confirmar nuevo expediente</h4>
                        </div>
                        <div class="modal-body">
                            <p>Por favor confirme el tipo de expediente que desea dar de alta. Una vez que sea dado de alta no podrá eliminarlo.</p>
                            <div id="Div7" runat="server" class="form-group">
                                <label id="Label3" runat="server" for="cmb_obra">Tipo de expediente</label>
                                <asp:DropDownList ID="cmb_nuevo_expediente" runat="server" class="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Obras de Ingenieria</asp:ListItem>
                                    <asp:ListItem>Fuerza Electromotriz</asp:ListItem>
                                    <asp:ListItem>Honorario Mínimo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
<%--                            <asp:TextBox ID="txt_elegir_profesional" runat="server" CssClass="form-control" OnTextChanged="txt_elegir_profesional_TextChanged" Visible="false" AutoPostBack="true"></asp:TextBox>
                            <div id="grilla_profesionales" style="height: 300px; overflow: auto;" runat="server" class="form-group" Visible="false">
                                <asp:GridView ID="gv_modal_profesionales" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnRowCreated="gv_modal_profesionales_RowCreated">
                                    <SelectedRowStyle BackColor="#E8E8E8" />
                                </asp:GridView>
                            </div>--%>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btn_cancelar_modal" data-dismiss="modal_eliminar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btn_cancelar_modal_Click" />
                            <asp:Button ID="btn_eliminar_modal" runat="server" Text="Aceptar" class="btn btn-danger" OnClick="btn_eliminar_modal_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

