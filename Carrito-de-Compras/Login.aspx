<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Carrito_de_Compras.Login" %>

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
                    <label class="form-label">Email</label>
                    <asp:TextBox Text="" ID="txtMail" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox Text="" TextMode="Password" ID="txtPass" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Fecha Nacimiento</label>
                    <asp:TextBox Text="" TextMode="date" ID="txtFechaNacimiento" CssClass="form-control" runat="server" />
                </div>
                <!-- Botones: Ingresar, Cerrar, Regsitrarse -->
                <div class="mb-3">
                    <asp:Button ID="btnIngresar" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" runat="server" />
                    <asp:Button ID="btnCerrarSesion" Text="Cerrar Sesion Actual" CssClass="btn btn-primary" OnClick="btnCerrarSesion_Click" runat="server" />
                    <asp:Button ID="btnRegistrarse" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" runat="server" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label class="form-label">Imagen de Perfil</label>
                    <label class="form-label">Url Imagen</label>
                    <asp:UpdatePanel ID="UpdatePanelFormulario" runat="server">
                        <ContentTemplate>
                            <div>
                                <asp:TextBox ID="txtUrlImg" Text="" CssClass="form-control" runat="server" />
                            </div>
                            <div>
                                <label for="formFile" class="form-label">Default file input example</label>
                                <input class="form-control" type="file" id="formFile">
                            </div>
                            <div style="margin-top: 5px">
                                <asp:Image ID="imgPerfilUsuario" ImageUrl="image-missing.png" Width="60%" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!-- Fin Formulario -->
</asp:Content>
