﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleDeArticulos.aspx.cs" Inherits="Carrito_de_Compras.DetalleDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <!-- INICIO -->
    <div class="container text-center">
        <h1>Detalles De Lista Articulos</h1>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label>Filtro por Nombre de Articulo: </label>
                    <asp:TextBox ID="tbxFiltroRapido" CssClass="form-control" AutoPostback="true" OnTextChanged="tbxFiltroRapido_TextChanged" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:CheckBox ID="chxFiltroAvanzado" CssClass="form-check" Text="Filtro Avanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chxFiltroAvanzado_CheckedChanged" />
                </div>
            </div>
        </div>
        <!-- Filtro Avanzado -->
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%if (chekedFiltro)
                    {%>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <label>Marca</label>
                            <asp:DropDownList ID="ddlMarcaFiltro" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <label>Tipo</label>
                            <asp:DropDownList ID="ddlTpoFiltro" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <label>Precio</label>
                            <asp:TextBox ID="txbPrecioFiltro" Text="" CssClass="form-control" runat="server" OnTextChanged="txbPrecioFiltro_TextChanged" AutoPostBack="true" />
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <label>Criterio Precio</label>
                            <asp:DropDownList ID="ddlCriterioFiltro" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <label>Estado</label>
                            <asp:DropDownList ID="ddlEstadosFiltro" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Todos" />
                                <asp:ListItem Text="Activos" />
                                <asp:ListItem Text="Inactivos" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row-cols-lg-3" style="margin-bottom: 10px">
                        <asp:Button ID="btnBuscarFiltroAvanzado" CssClass="btn btn-primary" Text="Buscar" runat="server" OnClick="btnBuscarFiltroAvanzado_Click" />
                    </div>
                </div>
                <%} %>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- Fin Filtro Avanzado -->
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <!-- Data Grid -->
                <asp:GridView
                    ID="dgwListaDetallada"
                    CssClass="table table-dark table-striped-columns"
                    AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgwListaDetallada_SelectedIndexChanged"
                    OnPageIndexChanging="dgwListaDetallada_PageIndexChanging"
                    AutoPostBack="true"
                    AllowPaging="true" PageSize="5"
                    runat="server" DataKeyNames="_Id">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="_codArticulo" />
                        <asp:BoundField HeaderText="Nombre" DataField="_nombre" />
                        <asp:BoundField HeaderText="Marca" DataField="_marca._Descripcion" />
                        <asp:BoundField HeaderText="Tipo" DataField="_categoria._Descripcion" />
                        <asp:BoundField HeaderText="Descripcion" DataField="_descripcion" />
                        <asp:BoundField HeaderText="Url de Img" DataField="_urlImagen" />
                        <asp:BoundField HeaderText="Precio" DataField="_precio" />
                        <asp:BoundField HeaderText="Activo" DataField="_activo" />
                        <asp:CommandField HeaderText="Ver" ShowSelectButton="true" SelectText="+" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- Botones -->
        <div class="row">
            <div class="col">
                <a href="DetalleDeArticulos.aspx" class="btn btn-secondary">Borrar todos los Filtros</a>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col">
                <a href="Formulario.aspx">Volver A Formulario</a>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <a href="Default.aspx">Cancelar</a>
            </div>
        </div>
    </div>
    <!-- FIN -->
</asp:Content>
