<%@ Page Title="Manual de usuario" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Manual de usuario.aspx.cs" Inherits="Vista_Web.ManualUsuario" %>

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
                        <div class="page-header" title="Gestión de Usuarios">
                            <h1>Gestión de ayuda <small>Módulo de Ayuda</small></h1>
                        </div>
                    </div>
                    <div id="Div4" runat="server" class="col-lg-4">
                        <div runat="server" class="form-group">
                            <label runat="server" for="txt_nombre">Video:</label>
                            <asp:TextBox ID="txt_nombre" runat="server" type="text" class="form-control" placeholder="Ingrese el tema a buscar"></asp:TextBox>
                        </div>
                    </div>
                    <div id="Div3" runat="server" class="col-lg-8">
                        <div style="height: 300px; overflow: auto;" class="form-group">
                            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvUsuarios_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#E8E8E8" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


