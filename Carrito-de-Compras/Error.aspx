<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Carrito_de_Compras.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
            <h1>Errores:</h1>
            <asp:TextBox ID="txaError" TextMode="MultiLine" CssClass="form-control" runat="server" />
        </div>
        <div>
            <a href="Default.aspx">Ir a Catalogo</a>
            <a href="Login.aspx">Volver</a>
        </div>
    </div>
</asp:Content>
