<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Carrito_de_Compras.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- INICIO -->
    <asp:ScriptManager runat="server" />
    <hr>
    <div class="container text-center">
        <!-- Formulario -->
        <div class="row">
            <!-- Imputs: Id, Codigo, Categoria, Nombre, Marca, Precio -->
            <div class="col-6">
                <div class="mb-3">
                    <label class="form-label">Id</label>
                    <asp:TextBox Text="" ID="tbxId" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Codigo</label>
                    <asp:TextBox Text="" ID="tbxCodigo" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Categoria</label>
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox Text="" ID="tbxNombre" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Marca</label>
                    <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Precio</label>
                    <asp:TextBox Text="" ID="tbxPrecio" CssClass="form-control" runat="server" />
                </div>
            </div>
            <!-- Imputs: Descripcion e Imagen -->
            <div class="col-6">
                <div class="mb-3">
                    <label class="form-label">Descripcion</label>
                    <asp:TextBox ID="txaDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Url Imagen</label>
                    <asp:UpdatePanel ID="UpdatePanelFormulario" runat="server">
                        <ContentTemplate>
                            <div>
                                <asp:TextBox ID="txbUrlImg" Text="" CssClass="form-control" OnTextChanged="txbUrlImg_TextChanged" AutoPostBack="true" runat="server" />
                            </div>
                            <div style="margin-top: 5px">
                                <asp:Image ID="imgFormulario" ImageUrl="image-missing.png" Width="60%" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <!-- Fin Formulario -->
        </div>
        <!-- Botones Agregar, Modificar, Borrar, Cancelar -->
        <div class="row">
            <div class="mb-3">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" />
                            <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
                            <asp:Button ID="btnEliminarLogica" Text="Dar de Baja" CssClass="btn btn-warning" OnClick="btnEliminarLogica_Click" runat="server" />
                            <asp:Button ID="btnAltaLogica" Text="Dar de Alta" CssClass="btn btn-warning" OnClick="btnAltaLogica_Click" runat="server" />
                            <% if (ConfirmarElminar)
                                {%>
                            <div class="mb-3" style="margin-top: 5px">
                                <asp:CheckBox ID="chkConfirmarEliminar" Text="Confirmar Eliminacion" runat="server" />
                                <asp:Button ID="btnConfirmarEliminar" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminar_Click" runat="server" />
                            </div>
                            <%} %>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="mb-3">
                    <a href="DetalleDeArticulos.aspx" class="btn btn-link">Volver Lista Detalles</a>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <a href="Default.aspx" class="btn-link">Cancelar</a>
            </div>
        </div>
    </div>
    <!-- FIN -->
</asp:Content>
