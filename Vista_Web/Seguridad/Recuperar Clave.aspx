<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recuperar Clave.aspx.cs" Inherits="Vista_Web.Recuperar_Clave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cambio de clave</title>
    <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="form-group">
        <div id="Div1" runat="server" class="row">
            <div id="Div2" runat="server" class="col-lg-offset-4 col-lg-3">
                <div class="page-header">
                    <h1>Recuperar clave <small>Módulo de Seguridad</small></h1>
                </div>
                <div class="form-group">
                    <label for="txt_nombreusuario" class="control-label">Usuario</label>
                    <div>
                        <asp:TextBox ID="txt_nombreusuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txt_email" class="control-label">Email</label>
                    <div>
                        <asp:TextBox ID="txt_email" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                    <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                    <asp:Label ID="lb_error" runat="server" Text="Mensaje" Visible="True"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Button ID="btn_recuperarclave" runat="server" OnClick="btn_recuperarclave_Click" CssClass="btn btn-danger pull-right margin-left-5" Text="Recuperar contraseña" />
                    <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right" Text="Cancelar" />
                </div>
            </div>
        </div>
    </form>
    <script src="../JS/jquery-1.11.1.min.js"></script>
    <script src="../JS/bootstrap.min.js"></script>
    <script src="../JS/custom.js"></script>
</body>
</html>
