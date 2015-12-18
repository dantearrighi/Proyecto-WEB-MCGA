<%@ Page Title="Gestion de Auditorías de Cuotas" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Gestion de Auditorías de Cuotas.aspx.cs" Inherits="Vista_Web.AuditoriasCuotas" %>

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
                            <h1>Gestión de Auditorías de Cuotas<small> Módulo de Auditoría</small></h1>
                        </div>
                    </div>
                    <div id="Div2" runat="server" class="col-lg-4">
                        <div runat="server" class="form-group">
                            <label runat="server" for="txt_usuario">Nombre y apellido del usuario</label>
                            <asp:TextBox ID="txt_usuario" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre del usuario"></asp:TextBox>
                        </div>
                        <div id="Div4" runat="server" class="form-group">
                            <label id="Label3" runat="server" for="txt_dni_profesional">DNI del profesional</label>
                            <asp:TextBox ID="txt_dni_profesional" runat="server" type="text" class="form-control" placeholder="Ingrese el DNI del profesional"></asp:TextBox>
                        </div>
                        <div id="Div5" runat="server" class="form-group">
                            <label id="Label4" runat="server" for="txt_cuota">Descipción de la cuota</label>
                            <asp:TextBox ID="txt_cuota" runat="server" type="text" class="form-control" placeholder="Ingrese la descripción de la cuota"></asp:TextBox>
                        </div>
                        <div id="Div1" runat="server" class="form-group">
                            <asp:Button ID="btn_filtrar" runat="server" OnClick="btn_filtrar_Click" Text="Filtrar" class="btn btn-info margin-left-5" />
                            <asp:Button ID="btn_nuevaconsulta" runat="server" OnClick="btn_nuevaconsulta_Click" Text="Nueva Consulta" class="btn btn-default" />
                        </div>
                        <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                            <button runat="server" type="button" class="close" data-dismiss="alert"><span runat="server" aria-hidden="true">&times;</span><span runat="server" class="sr-only">Cerrar</span></button>
                            <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                        </div>
                    </div>
                    <div id="Div3" runat="server" class="col-lg-8">
                        <div style="height: 300px; overflow: scroll;" class="form-group">
                            <asp:GridView ID="gvAuditorias" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvAuditorias_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvAuditorias_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#E8E8E8" />
                            </asp:GridView>
                        </div>
                        <asp:Button ID="btn_cerrar" runat="server" Text="Cerrar" OnClick="btn_cerrar_Click" CssClass="btn btn-default pull-right" />
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

