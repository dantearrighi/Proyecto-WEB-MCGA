<%@ Page Title="Gestión de Profesional" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Profesional.aspx.cs" Inherits="Vista_Web.Profesional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div runat="server" class="alert alert-warning error-message" role="alert" visible="false" id="message">
                <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                <asp:Label ID="lb_error" runat="server" Text="Mensaje" Visible="True"></asp:Label>
            </div>
            <div class="container">
                <div id="Div1" runat="server" class="row">
                    <div id="Div2" runat="server" class="col-lg-12">
                        <div class="page-header">
                            <h1>Gestión de Profesional <small>Módulo de Profesionales</small></h1>
                        </div>
                    </div>
                    <div id="Div3" runat="server" class="col-lg-12">
                        <ul id="myTab" class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#datos" role="tab" data-toggle="tab">Datos personales</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content small-panel">

                            <div class="tab-pane fade active in" id="datos">
                                <div class="form form-horizontal" role="form">
                                    <%--Datos principales--%>
                                    <div class="form-group">
                                        <label for="txt_nombreapellido" class="col-lg-2 control-label">Nombre y apellido</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_nombreapellido" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="cmb_tiposdoc" class="col-lg-2 control-label">Tipo documento</label>
                                        <div class="col-lg-2">
                                            <asp:DropDownList AutoPostBack="true" ID="cmb_tiposdoc" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <label for="txt_numero" class="col-lg-1 control-label">DNI</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="txt_numero" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div runat="server" class="form-group">
                                        <label class="col-lg-2 control-label" runat="server" for="txt_fechanacimiento">Fecha de nacimiento</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_fechanacimiento" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <label id="Label1" class="col-lg-2 control-label" runat="server" for="txt_fechanacimiento">Sexo</label>
                                        <div class="radio col-lg-3">
                                            <asp:DropDownList ID="sexo" runat="server" CssClass="form-control">
                                                <asp:ListItem>Masculino</asp:ListItem>
                                                <asp:ListItem>Femenino</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_telfijo" class="col-lg-2 control-label">Teléfono Fijo</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_telfijo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="txt_celular" class="col-lg-2 control-label">Celular</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_celular" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txt_emailpricipal" class="col-lg-2 control-label">Email principal</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_emailpricipal" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label for="txt_emailalternativo" class="col-lg-2 control-label">Email alternativo</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="txt_emailalternativo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                    </div>
                                    <%--Direcciones--%>
                                    <div class="panel-group" id="accordionDirecciones">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordionDirecciones" href="#collapseOne">Lugar de residencia
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseOne" class="panel-collapse collapse in">
                                                <div class="panel-body">
                                                    <div class="form" role="form">
                                                        <div class="form-group">
                                                            <label for="txt_direccion" class="col-lg-2 control-label">Dirección</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txt_direccion" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                            <label for="txt_cp" class="col-lg-2 control-label">Código postal</label>
                                                            <div class="col-lg-2">
                                                                <asp:TextBox ID="txt_cp" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cmb_localidades" class="col-lg-2 control-label">Localidad</label>
                                                            <div class="col-lg-4">
                                                                <asp:DropDownList AutoPostBack="False" ID="cmb_localidades" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <label for="cmb_provincias" class="col-lg-2 control-label">Provincia</label>
                                                            <div class="col-lg-4">
                                                                <asp:DropDownList AutoPostBack="False" ID="cmb_provincias" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a data-toggle="collapse" data-parent="#accordionDirecciones" href="#collapseTwo">Lugar de Trabajo
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseTwo" class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        <div class="form" role="form">
                                                            <div class="form-group">
                                                                <label for="txt_direccionE" class="col-lg-2 control-label">Dirección</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txt_direccionE" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label for="txt_cpE" class="col-lg-2 control-label">Código postal</label>
                                                                <div class="col-lg-2">
                                                                    <asp:TextBox ID="txt_cpE" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label for="cmb_localidadesE" class="col-lg-2 control-label">Localidad</label>
                                                                <div class="col-lg-4">
                                                                    <asp:DropDownList AutoPostBack="False" ID="cmb_localidadesE" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <label for="cmb_provinciasE" class="col-lg-2 control-label">Provincia</label>
                                                                <div class="col-lg-4">
                                                                    <asp:DropDownList AutoPostBack="False" ID="cmb_provinciasE" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                       
                           

                            
                            
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" CssClass="btn btn-success pull-right margin-left-5" Text="Guardar" />
                                <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right" Text="Cancelar" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--Modal--%>
               
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>