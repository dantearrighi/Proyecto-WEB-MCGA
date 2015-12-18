<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Botonera1.ascx.cs" Inherits="Vista_Web.Botoneras.Botonera1" %>
<link href="../CSS/bootstrap.min.css" rel="stylesheet" />
<asp:Button ID="btn_agregar" runat="server" Text="Agregar" OnClick="btn_agregar_Click" class="btn btn-success"/> 
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" OnClick="btn_eliminar_Click" class="btn btn-danger"/>
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btn_modificar" runat="server" Text="Modificar" OnClick="btn_modificar_Click" class="btn btn-primary"/>
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btn_verdetalle" runat="server" Text="Ver detalle" OnClick="btn_verdetalle_Click" class="btn btn-info"/>
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btn_cerrar" runat="server" Text="Cerrar" OnClick="btn_cerrar_Click" class="btn btn-default" />

