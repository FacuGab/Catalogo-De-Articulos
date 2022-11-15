<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Carrito_de_Compras.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- -->
    <div class="container-fluid">
        <div class="row">
            <!-- Imputs: usuario, pass -->
            <div class="col-md-6">
                <h3>Registro de Usuarios</h3>
                <asp:Label ID="lblAux" Text="" runat="server" />
                <div class="mb-3">
                    <label class="form-label">Nombre de Usuario</label>
                    <asp:TextBox Text="" ID="txtUsuario" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Mail</label>
                    <asp:TextBox Text="" ID="txtMail" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox Text="" ID="txtPass" TextMode="Password" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Repetir Contraseña</label>
                    <asp:TextBox Text="" ID="txtRepPass" TextMode="Password" CssClass="form-control" runat="server" />
                </div>
                <!-- Botones: Ingresar, Cerrar, Regsitrarse -->
                <div class="mb-3">
                    <asp:Button ID="btnRegistrar" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" runat="server" />
                    <a href="Default.aspx">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
    <!-- -->
</asp:Content>
