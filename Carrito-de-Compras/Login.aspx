<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Carrito_de_Compras.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <!-- Formulario -->
    <div class="container-fluid">
        <div class="row">
            <!-- Imputs: usuario, pass -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label class="form-label">Usuario</label>
                    <asp:TextBox Text="" ID="txtUsuario" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox Text="" ID="txtPass" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnIngresar" Text="Ingresar"  CssClass="btn btn-primary" OnClick="btnIngresar_Click" runat="server" />
                    <asp:Button ID="btnCerrarSesion" Text="Cerrar Sesion"  CssClass="btn btn-primary" OnClick="btnCerrarSesion_Click" runat="server" />
                </div>
                <!-- Fin Formulario -->
            </div>
        </div>
    </div>
</asp:Content>
