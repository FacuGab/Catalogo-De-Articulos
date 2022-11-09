<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="Carrito_de_Compras.Mensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col">
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="txtMail" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Asunto</label>
                    <asp:TextBox ID="txtAsunto" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Mensaje</label>
                    <asp:TextBox TextMode="MultiLine" ID="txtCuerpo" CssClass="form-control" runat="server" />
                </div>
                <asp:Button ID="btnEnviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click" Text="Enviar" runat="server" />
            </div>
        </div>
    </div>


</asp:Content>
