<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito_de_Compras.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- INICIO -->
    <asp:ScriptManager runat="server" />
    <div class="container text-center mt-5">
        <div style="margin-bottom: 10px">
            <h4>Cantidad de Articulos en Carrito: <span class="badge bg-secondary"><%:Session["cantidad"] %></span></h4>
            <div class="d-grid gap-2 col-6 mx-auto mb-5">
                <asp:LinkButton ID="lbtLinkCarrito" Text="Ir a Carrito" CssClass="btn btn-primary" OnClick="lbtLinkCarrito_Click" runat="server" />
            </div>
        </div>
        <!-- Filtros Busqueda -->
        <div class="p-5" style="background-color: #0b0034; border-radius: 2em;">

            <div class="row">
                <div class="col-1 ms-5">
                    <h4>Marca:</h4>
                </div>
                <div class="col-2 me-2">
                    <asp:DropDownList ID="dwlMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-1 ms-2">
                    <h4>Tipo:</h4>
                </div>
                <div class="col-2">
                    <asp:DropDownList ID="dwlTipo" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-1 ms-2">
                    <h4>Precio:</h4>
                </div>
                <div class="col-2">
                    <asp:TextBox Text="0" CssClass="form-control" ID="txbPrecio" runat="server" />
                </div>
                <div class="col-2">
                    <asp:DropDownList ID="dwlSelector" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row mt-5 justify-content-center">
                <div class="col-4">
                    <asp:Button ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" runat="server" CssClass="btn btn-primary col-4" />
                </div>
                <div class="col-4">
                    <asp:Button ID="btnResetFiltro" Text="Borrar filtro" OnClick="btnResetFiltro_Click" runat="server" CssClass="btn btn-primary col-4" />
                </div>
            </div>
        </div>
        <hr />
        <!-- FIN Filtros Busqueda -->
        <h2>ARTICULOS</h2>
        <%if (flagFiltro)
            {%>
        <h5>Cantidad de articulos encontrados: <span class="badge bg-secondary"><%: count %></span></h5>
        <%} %>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <!-- Repiter -->
                    <asp:Repeater ID="rep_ListaDefautl" runat="server">
                        <ItemTemplate>
                            <div class="col" style="padding-bottom: 10px; display: grid; justify-items: center;">
                                <div class="card" style="width: 18rem;">
                                    <asp:Image runat="server" CssClass="img-thumbnail" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "_urlImagen")%>' onerror="this.src='https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/495px-No-Image-Placeholder.svg.png?20200912122019'" Style="width: 100%; height: 40vh; object-fit: contain;" />
                                    <div class="card-body">
                                        <h5 class="card-title"><%#DataBinder.Eval(Container.DataItem, "_nombre")%></h5>
                                        <p class="card-text"><%#DataBinder.Eval(Container.DataItem, "_descripcion")%></p>
                                    </div>
                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item">Codigo: <%#DataBinder.Eval(Container.DataItem, "_codArticulo")%></li>
                                        <li class="list-group-item">Precio: <%#DataBinder.Eval(Container.DataItem, "_precio")%> $</li>
                                        <li class="list-group-item">Marca: <%#DataBinder.Eval(Container.DataItem, "_marca._Descripcion")%></li>
                                    </ul>
                                    <div class="card-body">
                                        <asp:Button ID="btn_AgregarArt" Text="Agregar a Carrito" CssClass="btn btn-primary" runat="server" CommandArgument='<%#Eval("_id") %>' CommandName="ArtId" OnClick="btn_AgregarArt_Click" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- Fin Repiter -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
<!-- FIN -->
</asp:Content>
