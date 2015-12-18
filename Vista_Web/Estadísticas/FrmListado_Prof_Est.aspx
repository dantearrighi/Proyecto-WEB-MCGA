<%@ Page Title="Profesionales por estado" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FrmListado_Prof_Est.aspx.cs" Inherits="Vista_Web.FrmListado_Prof_Est" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="473px" Width="971px">
                <LocalReport ReportEmbeddedResource="Vista_Web.Estadísticas.Profesionales_Por_Estado.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Vista_Web.App_Code.Listados_Prof_EstTableAdapters.EstadosTableAdapter">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="fecha_menor" QueryStringField="desde" Type="DateTime" />
                    <asp:QueryStringParameter DefaultValue="0" Name="fecha_mayor" QueryStringField="hasta" Type="DateTime" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <%--<div id="Div1" runat="server" class="row">
                <div id="Div2" runat="server" class="col-lg-offset-3 col-lg-6">
                    <div class="page-header">
                        <h1>Gestión de Auditoria<small> Módulo de Auditoria</small></h1>
                    </div>
                    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label for="txt_nombreapellido" class="col-sm-4 control-label">Usuario</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txt_nombreapellido" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_fecha" class="col-sm-4 control-label">Fecha</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txt_fecha" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txt_accion" class="col-sm-4 control-label">Acción</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txt_accion" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btn_cerrar" runat="server" OnClick="btn_cerrar_Click" CssClass="btn btn-default pull-right" Text="Cerrar" />
                    </div>
                </div>
            </div>--%>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
