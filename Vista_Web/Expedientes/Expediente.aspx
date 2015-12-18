<%@ Page Title="Gestión de Expediente" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Expediente.aspx.cs" Inherits="Vista_Web.Expediente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Div1" runat="server" class="row">
                <div id="Div2" runat="server" class="col-lg-offset-1 col-lg-10" title="Gestión de Expediente">
                    <div class="page-header">
                        <h1>Gestión de Expediente <small>Módulo de Expedientes</small></h1>
                    </div>
                    
                    <div class="well">
                    <h3>
                        <asp:Label ID="lb_tipo_expediente" runat="server" Text="Label" CssClass="label label-default"></asp:Label>
                        <asp:Label ID="lb_estado_expediente" runat="server" Text="Label" CssClass="label label-primary pull-right margin-left-5"></asp:Label>
                        <asp:Label ID="lb_numero_expediente" runat="server" Text="Label" CssClass="label label-info pull-right"></asp:Label>
                    </h3>
                    </div>
                    <div>
                        <ul id="myTab" class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#datos" role="tab" data-toggle="tab">Datos</a></li>
                            <li class=""><a href="#expediente" role="tab" data-toggle="tab">Expediente</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content small-panel">
                            <div class="tab-pane fade active in" id="datos">
                                <div class="form-horizontal" role="form">

                                    <div class="form-group">
                                        <div class="col-sm-10">
                                            <asp:GridView ID="gv_profesionales" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnRowCreated="gv_profesionales_RowCreated">
                                                <SelectedRowStyle BackColor="#E8E8E8" />
                                            </asp:GridView>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btn_agregar" runat="server" OnClick="btn_agregar_Click" CssClass="btn btn-success margin-buttom-10" Text="Agregar" />
                                            <asp:Button ID="btn_quitar" runat="server" OnClick="btn_quitar_Click" CssClass="btn btn-danger" Text="Eliminar" />
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-group">
                                        <label for="txt_comitente" class="col-sm-2 control-label">Comitente</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="cmb_comitentes" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                       
                                    </div>
                                    <hr />
                                    <div class="form-group">
                                        <label id="Label4" class="col-lg-2 control-label" runat="server" for="dtp_fecha_recepcion">Fecha de recepción</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="dtp_fecha_recepcion" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        
                                        <label id="Label3" class="col-lg-2 control-label" runat="server" for="dtp_fecha_aprobacion">Fecha de aprobación</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="dtp_fecha_aprobacion" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <asp:CheckBox ID="chk_aprobar" runat="server" CssClass="col-lg-2" Text="Aprobar" OnCheckedChanged="chk_aprobar_CheckedChanged" AutoPostBack="true"/>
                                    </div>
                                    <div class="form-group">
                                        <label id="Label7" class="col-lg-2 control-label" runat="server" for="dtp_fecha_pago">Fecha de pago</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="dtp_fecha_pago" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        
                                        <label id="Label8" class="col-lg-2 control-label" runat="server" for="dtp_fecha_devolución">Fecha de devolución</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="dtp_fecha_devolución" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <asp:CheckBox ID="chk_devuelto" runat="server" CssClass="col-lg-2" Text="Devuelto" OnCheckedChanged="chk_devuelto_CheckedChanged" AutoPostBack="true"/>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="expediente">
                                
                                <div runat="server" id="OI">
                                    
                                    <div class="col-lg-6 form-group">
                                        <asp:GridView ID="dgv_liquidaciones_OI" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnRowCreated="dgv_liquidaciones_OI_RowCreated">
                                            <SelectedRowStyle BackColor="#E8E8E8" />
                                        </asp:GridView>
                                    </div>

                                    <div class="col-lg-6 form-group">
                                        <label id="Label1" class="col-lg-2 control-label" runat="server" for="cmb_tareas_OI">Tarea</label>
                                        <asp:DropDownList ID="cmb_tareas_OI" runat="server" class="form-control col-lg-2 margin-buttom-10">
                                        </asp:DropDownList>

                                        <label id="Label19" class="col-lg-2 control-label" runat="server" for="nud_monto_obra_OI">Monto de obra</label>
                                        <div class="col-lg-3">
                                            <asp:TextBox ID="nud_monto_obra_OI" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_aportes" runat="server" Text="Aportes definitivos"/>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 form-group well">
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_anteproyecto" runat="server" Text="Anteproyecto"></asp:CheckBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_proyecto_sin_anteproyecto" runat="server" Text="Proyecto sin anteproyecto"></asp:CheckBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_proyecto" runat="server" Text="Proyecto de la obra"></asp:CheckBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_conduccion_tecnica" runat="server" Text="Conducción técnica"></asp:CheckBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 form-group well">
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_administracion" runat="server" Text="Administración"></asp:CheckBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_trámites" runat="server" Text="Trámites"></asp:CheckBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_representacion_tecnica" runat="server" Text="Representación técnica"></asp:CheckBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:CheckBox ID="chk_direccion_de_la_obra" runat="server" Text="Dirección de la obra"></asp:CheckBox>
                                        </div>
                                    </div>

                                </div>

                                <div runat="server" id="FE">
                                    <div class="col-lg-6 form-group">
                                        <asp:GridView ID="dgv_liquidaciones_FE" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnRowCreated="dgv_liquidaciones_FE_RowCreated">
                                            <SelectedRowStyle BackColor="#E8E8E8" />
                                        </asp:GridView>
                                    </div>

                                    <div class="col-lg-6 form-group">
                                        <label id="Label2" class="col-lg-2 control-label" runat="server" for="cmb_tareas_fe">Tarea</label>
                                        <asp:DropDownList ID="cmb_tareas_fe" runat="server" class="form-control col-lg-2 margin-buttom-10">
                                        </asp:DropDownList>

                                        <label id="Label14" class="col-lg-2 control-label" runat="server" for="nud_dias_campo_FE">Días de campo</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="nud_dias_campo_FE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    
                                        <label id="Label15" class="col-lg-2 control-label" runat="server" for="nud_dias_gabinete_FE">Días de gabinete</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="nud_dias_gabinete_FE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 form-group">
                                        <label id="Label17" class="col-lg-2 control-label" runat="server" for="nud_num_hp_FE">HP instalados</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="nud_num_hp_FE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    
                                        <label id="Label18" class="col-lg-2 control-label" runat="server" for="nud_num_bocas_FE">Bocas</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="nud_num_bocas_FE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                        <label id="Label16" class="col-lg-2 control-label" runat="server" for="nud_num_motores_FE">Motores</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="nud_num_motores_FE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                                <div runat="server" id="HM">
                                    <div class="col-lg-6 form-group">
                                        <asp:GridView ID="dgv_liquidaciones_HM" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" AllowCustomPaging="False" OnRowCreated="dgv_liquidaciones_HM_RowCreated">
                                            <SelectedRowStyle BackColor="#E8E8E8" />
                                        </asp:GridView>
                                    </div>

                                    <div class="col-lg-6 form-group">
                                        <label id="Label13" class="col-lg-2 control-label" runat="server" for="cmb_tareas_hm">Tarea</label>
                                        <asp:DropDownList ID="cmb_tareas_hm" runat="server" class="form-control col-lg-2 margin-buttom-10" >
                                        </asp:DropDownList>

                                        <label id="Label11" class="col-lg-2 control-label" runat="server" for="nud_dias_campo_HM">Días de campo</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="nud_dias_campo_HM" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    
                                        <label id="Label12" class="col-lg-2 control-label" runat="server" for="nud_dias_gabinete_HM">Días de gabinete</label>
                                        <div class="col-lg-2">
                                            <asp:TextBox ID="nud_dias_gabinete_HM" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        
                        <hr />
                        
                    </div>
                    </div>
                    <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                        <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                        <asp:Label ID="lb_error" runat="server" Text="Mensaje" Visible="True"></asp:Label>
                    </div>
                    <div class="form-group">
                            <label id="Label5" class="col-lg-1 control-label" runat="server" for="txt_total_a_liquidar">Total a liquidar</label>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txt_total_a_liquidar" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <label id="Label6" class="col-lg-1 control-label" runat="server" for="txt_aportes_al_cie">Aportes al CIE</label>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txt_aportes_al_cie" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <label id="Label9" class="col-lg-1 control-label" runat="server" for="txt_aportes_a_caja">Aportes al Caja</label>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txt_aportes_a_caja" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <label id="Label10" class="col-lg-1 control-label" runat="server" for="txt_total_aportes">Total aportes</label>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txt_total_aportes" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    <div class="col-sm-offset-6 col-sm-6 margin-top-10">
                            <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" CssClass="btn btn-success pull-right margin-left-5 col-sm-2" Text="Guardar" />
                            <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right margin-left-5 col-sm-2" Text="Cancelar" />
                            <asp:Button ID="btn_liquidar" runat="server" OnClick="btn_liquidar_Click" CssClass="btn btn-success pull-right col-sm-2" Text="Liquidar" />
                    </div>
                    
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenido_Especial" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <%--Modal--%>
            <div class="modal fade" id="modal_eliminar" tabindex="-1" role="dialog" aria-labelledby="Inhabilitar Usuario" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button id="btn_cerrar_modal" runat="server" type="button" class="close" data-dismiss="modal_detalle_titulo"><span id="Span3" runat="server" aria-hidden="true">&times;</span><span id="Span4" runat="server" class="sr-only">Cerrar</span></button>
                            <h4 class="modal-title">Confirmar acción</h4>
                        </div>
                        <div class="modal-body">
                            <div id="Div7" runat="server" class="form-group">
                                <asp:Label ID="lb_mje_modal" runat="server" Text=""></asp:Label>
                            </div>                            
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