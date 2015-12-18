<%@ Page Title="Selección de expediente" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Seleccionar Expediente.aspx.cs" Inherits="Vista_Web.SeleccionarExpediente" %>

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
                            <h1>Seleccionar expediente <small title="Selección de expediente">Módulo de Contabilidad</small></h1>
                        </div>
                    </div>
                </div>
                <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                    <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                    <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                </div>
                <asp:TextBox ID="txt_numero" runat="server" type="text" class="form-control" OnTextChanged="txt_numero_TextChanged" AutoPostBack="true" Placeholder="Buscar expediente por número"></asp:TextBox>
                <div style="height: 300px; overflow: auto; margin-top:5px" class="form-group">
                    <asp:GridView ID="gvExpedientes" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvProfesionales_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvProfesionales_SelectedIndexChanged">
                        <SelectedRowStyle BackColor="#E8E8E8" />
                    </asp:GridView>
                </div>
                <div class="col-sm-12">
                    <asp:Button ID="btn_seleccionar" runat="server" CssClass="btn btn-warning margin-left-5 pull-right" Text="Seleccionar" OnClick="btn_seleccionar_Click"/>
                    <asp:Button ID="btn_cancelar" runat="server" CssClass="btn btn-primary pull-right" Text="Cancelar" OnClick="btn_cancelar_Click"/>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

