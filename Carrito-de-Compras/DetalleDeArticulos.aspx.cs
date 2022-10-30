using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_de_Compras
{
    public partial class DetalleDeArticulos : System.Web.UI.Page
    {
        private List<Articulo> listaFiltroRapido;
        private List<Articulo> listaLogica;
        private char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        public bool chekedFiltro { get; set; } = false;

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            chekedFiltro = chxFiltroAvanzado.Checked;
            if(!IsPostBack)
            {
                NegocioArticulo negocio = new NegocioArticulo();
                listaLogica = negocio.listarArticulos(0);

                NegocioDetalle detalle = new NegocioDetalle();
                detalle.listarDosCategorias();
                Detalle aux = new Detalle() { _Id = -1, _Descripcion = "" };
                List<Detalle> ls = new List<Detalle>();
                
                ls.Add(aux);
                ls.AddRange(detalle.listaCategorias);
                ddlTpoFiltro.DataSource = ls;
                ddlTpoFiltro.DataBind();

                ls.Clear();

                ls.Add(aux);
                ls.AddRange(detalle.listaMarcas);
                ddlMarcaFiltro.DataSource = ls;
                ddlMarcaFiltro.DataBind();

                ddlCriterioFiltro.Enabled = false;
            }

            if (Session["listaArticulosPrincipal"] == null)
                Session.Add("listaArticulosPrincipal", listaLogica);

            if (Request.QueryString["activo"] != null)
                listaLogica.RemoveAll(itm => itm._activo == false);

            dgwListaDetallada.DataSource = Session["listaArticulosPrincipal"];
            dgwListaDetallada.DataBind();
        }
        //METODOS:
        // Metodo Cambio de indice en Grid
        protected void dgwListaDetallada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["listaArticulosFiltrada"] != null)
            {
                dgwListaDetallada.DataSource = Session["listaArticulosFiltrada"];
                dgwListaDetallada.DataBind();
            }
            string id = dgwListaDetallada.SelectedDataKey.Value.ToString();
            Session.Remove("listaArticulosFiltrada");
            Response.Redirect("Formulario.aspx?id=" + id, false);
        }
        // Metodo Cambio de indice en Grid
        protected void dgwListaDetallada_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgwListaDetallada.PageIndex = e.NewPageIndex;
            dgwListaDetallada.DataBind();
        }
        // Boton Mostrar Activos
        protected void btnMostrarLogicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleDeArticulos.aspx?activo=1", false);   
        }
        // Boton Mostrar Inactivos
        protected void btnMostrarSilogicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleDeArticulos.aspx", false);
        }
        // Evento Cambio de Texto en Filtro Rapido
        protected void tbxFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            listaFiltroRapido = ((List<Articulo>)Session["listaArticulosPrincipal"]).
                FindAll( itm => itm._nombre.ToUpper().Contains(tbxFiltroRapido.Text.ToUpper()) );

            if (Session["listaArticulosFiltrada"] == null)
                Session.Add("listaArticulosFiltrada", listaFiltroRapido);

            dgwListaDetallada.DataSource = listaFiltroRapido;
            dgwListaDetallada.DataBind();
        }
        // Evento ChekedBox Filtro Avanzado
        protected void chxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            chekedFiltro = chxFiltroAvanzado.Checked;
            tbxFiltroRapido.Enabled = !chekedFiltro;
        }

        protected void txbPrecioFiltro_TextChanged(object sender, EventArgs e)
        {
            ddlCriterioFiltro.Items.Clear();
            ddlCriterioFiltro.Enabled = true;
            ddlCriterioFiltro.Items.Add("Igual a");
            ddlCriterioFiltro.Items.Add("Mayor a");
            ddlCriterioFiltro.Items.Add("Menor a");
        }

        protected void btnBuscarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                string marca = ddlMarcaFiltro.SelectedValue;
                string tipo = ddlTpoFiltro.SelectedValue;
                string precio = txbPrecioFiltro.Text;
                string criterio = "";
                if (ddlCriterioFiltro.SelectedValue != null)
                {
                    criterio = ddlCriterioFiltro.SelectedValue;
                }
                decimal filPrecio = 0.00M;

                if (!string.IsNullOrWhiteSpace(precio))
                {
                    decimal.TryParse(precio, out  filPrecio);
                }

                NegocioArticulo negocio = new NegocioArticulo();
                List<Articulo> listaFiltrada = negocio.busquedaFiltrada(marca, tipo, filPrecio, criterio);

                if (ddlEstadosFiltro.SelectedValue == "Activos")
                {
                    listaFiltrada.RemoveAll(itm => itm._activo == false);
                    dgwListaDetallada.DataSource = listaFiltrada;
                }
                else if (ddlEstadosFiltro.SelectedValue == "Inactivos")
                {
                    listaFiltrada.RemoveAll(itm => itm._activo == true);
                    dgwListaDetallada.DataSource = listaFiltrada;
                }
                else
                {
                    dgwListaDetallada.DataSource = listaFiltrada;
                }
                dgwListaDetallada.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}