﻿<%@ Page Title="Gestión de Perfiles" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Gestion de Perfiles.aspx.cs" Inherits="Vista_Web.Perfiles" %>

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
                            <h1>Gestión de Perfiles <small title="Gestión de Perfiles">Módulo de Seguridad</small></h1>
                        </div>
                    </div>
                    <div id="Div4" runat="server" class="col-lg-4">
                        <div id="Div2" runat="server" class="form-group">
                            <label id="Label1" runat="server" for="cmb_grupos">Grupo</label>
                            <asp:DropDownList ID="cmb_grupos" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                        <div runat="server" class="form-group">
                            <label runat="server" for="cmb_formularios">Formularios</label>
                            <asp:DropDownList ID="cmb_formularios" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                        <div id="Div3" runat="server" class="form-group">
                            <label id="Label2" runat="server" for="cmb_permisos">Permisos</label>
                            <asp:DropDownList ID="cmb_permisos" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                        <div id="Div1" runat="server" class="form-group">
                            <asp:Button ID="btn_filtrar" runat="server" OnClick="btn_filtrar_Click" Text="Filtrar" class="btn btn-info" />
                            &nbsp;&nbsp;
                        <asp:Button ID="btn_nuevaconsulta" runat="server" OnClick="btn_nuevaconsulta_Click" Text="Nueva Consulta" class="btn btn-default" />
                        </div>
                        <br />
                        <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                            <button runat="server" type="button" class="close" data-dismiss="alert"><span runat="server" aria-hidden="true">&times;</span><span runat="server" class="sr-only">Cerrar</span></button>
                            <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                        </div>
                    </div>
                    <div id="Div5" runat="server" class="col-lg-8">
                        <div style="height: 300px; overflow: auto;" class="form-group">
                            <asp:GridView ID="gvPerfiles" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnSelectedIndexChanged="gvPerfiles_SelectedIndexChanged" AutoGenerateColumns="True">
                                <SelectedRowStyle BackColor="#E8E8E8" />
                            </asp:GridView>
                        </div>
                        <div id="Div6" runat="server" class="form-group">
                            <uc1:Botonera1 ID="botonera1" runat="server" OnClick_Alta="botonera1_Click_Alta" OnClick_Baja="botonera1_Click_Baja" OnClick_Cerrar="botonera1_Click_Cerrar" OnClick_Consulta="botonera1_Click_Consulta"/>
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
                            <button id="btn_cerrar_modal" runat="server" type="button" class="close" data-dismiss="modal_eliminar"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                            <h4 class="modal-title">Eliminar perfil</h4>
                        </div>
                        <div class="modal-body">
                            <p>¿Está seguro que desea eliminar al perfil seleccionado?</p>
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

