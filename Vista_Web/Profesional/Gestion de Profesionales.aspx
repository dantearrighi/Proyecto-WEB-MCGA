<%@ Page Title="Gestión de Profesionales" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Gestion de Profesionales.aspx.cs" Inherits="Vista_Web.Profesionales" %>

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
                        <div class="page-header" title="Gestión de Usuarios">
                            <h1>Gestión de Profesionales <small>Módulo de Profesionales</small></h1>
                        </div>
                    </div>
                    <div id="Div4" runat="server" class="col-lg-4">
                        <div runat="server" class="form-group">
                            <label runat="server" for="txt_nya_profesional">Nombre y apellido del profesional</label>
                            <asp:TextBox ID="txt_nya_profesional" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre del profesional" OnTextChanged="txt_nya_profesional_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div id="Div5" runat="server" class="form-group">
                            <label id="Label1" runat="server" for="txt_dni">DNI del profesional</label>
                            <asp:TextBox ID="txt_dni" runat="server" type="text" class="form-control" placeholder="Ingrese el DNI del profesional" OnTextChanged="txt_dni_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div id="Div6" runat="server" class="form-group">
                            <label id="Label2" runat="server" for="txt_num_matricula">Matrícula del profesional</label>
                            <asp:TextBox ID="txt_num_matricula" runat="server" type="text" class="form-control" placeholder="Ingrese la matrícula del profesional" OnTextChanged="txt_num_matricula_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                            <button runat="server" type="button" class="close" data-dismiss="alert"><span runat="server" aria-hidden="true">&times;</span><span runat="server" class="sr-only">Cerrar</span></button>
                            <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                        </div>
                    </div>
                    <div id="Div3" runat="server" class="col-lg-8">
                        <div style="height: 300px; overflow: auto;" class="form-group">
                            <asp:GridView ID="gvProfesionales" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvProfesionales_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvProfesionales_SelectedIndexChanged">
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
