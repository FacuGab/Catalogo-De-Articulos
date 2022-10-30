using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_de_Compras
{
    public partial class Default : System.Web.UI.Page
    {//
        private List<Articulo> listaSeleccionados;
        Dictionary<string, int> keyValues;
        private int cantidad = 0;
        private int index;
        public int count { get; set; }

        //Load:
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Detalle aux = new Detalle() { _Id = -1, _Descripcion = "" };
                List<Detalle> ls = new List<Detalle>();
                NegocioArticulo negocio = new NegocioArticulo();
                NegocioDetalle detalles = new NegocioDetalle();
                detalles.listarDosCategorias();

                ls.Add(aux);
                ls.AddRange(detalles.listaCategorias);
                dwlTipo.DataSource = ls;
                dwlTipo.DataBind();

                ls.Clear();

                ls.Add(aux);
                ls.AddRange(detalles.listaMarcas);
                dwlMarca.DataSource = ls;
                dwlMarca.DataBind();

                dwlSelector.Items.Insert(0, "Mayor a");
                dwlSelector.Items.Insert(1, "Menor a");
                dwlSelector.Items.Insert(2, "Igual a");

                rep_ListaDefautl.DataSource = new List<Articulo>(negocio.listarArticulos(0));
                rep_ListaDefautl.DataBind();

                if (Session.Count == 0)
                {
                    Session.Add("ListaArticulos", new List<Articulo>(negocio.listarArticulos(0)));
                    Session.Add("cantidadFiltrados", negocio.CantArt);
                    Session.Add("listaSeleccionados", new List<Articulo>());
                    Session.Add("cantidad", 0);
                    Session.Add("uniXcodigo", new Dictionary<string, int>());
                    Session.Add("montoTotal", 0.00M);
                    Session.Add("montoParcial", 0.00M);
                    count = negocio.CantArt;
                }
                else
                {
                    Session.Add("cantidadFiltrados", negocio.CantArt);
                    count = negocio.CantArt;
                }
            }
        }
        //METODOS:
        //Boton Agregar
        protected void btn_AgregarArt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaSeleccionados"] == null || Session["ListaArticulos"] == null)
                    return;

                cantidad += (int)Session["cantidad"];
                int intSelect = int.Parse(((Button)sender).CommandArgument);

                List<Articulo> list = ((List<Articulo>)Session["ListaArticulos"]);
                listaSeleccionados = (List<Articulo>)Session["listaSeleccionados"];
                keyValues = (Dictionary<string, int>)Session["uniXcodigo"];

                index = list.FindIndex(itm => itm._Id == intSelect);
                listaSeleccionados.Add(list[index]);
                Session.Add("cantidad", ++cantidad);

                index = listaSeleccionados.FindIndex(itm => itm._Id == intSelect);
                string codSeleccionado = listaSeleccionados[index]._codArticulo;

                if (!keyValues.ContainsKey(codSeleccionado))
                {
                    keyValues.Add(codSeleccionado, 1);
                }
                else
                {
                    keyValues[codSeleccionado]++;
                }
            }
            catch
            {
                Response.Redirect("Default.aspx", false);
            }

        }
        //Boton Ir a Carrito
        protected void lbtLinkCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Lista.aspx", false);
            }
            catch
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        //Boton Filtrar
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    NegocioArticulo negocioFiltro = new NegocioArticulo();
                    List<Articulo> listaFiltrada = new List<Articulo>();
                    List<Articulo> listaArticulos = (List<Articulo>)Session["ListaArticulos"];
                    string marca = dwlMarca.SelectedValue;
                    string tipo = dwlTipo.SelectedValue;
                    string strPrecio = txbPrecio.Text;
                    string selector = dwlSelector.SelectedValue;
                    decimal precio = 0.00M;

                    if(!string.IsNullOrEmpty(strPrecio))
                    {
                        if (!decimal.TryParse(strPrecio, out precio))
                        {
                            PageUtils.Mensaje(this, "El precio ingresado no es valido");
                            return;
                        }
                        else if(precio < 0)
                        {
                            PageUtils.Mensaje(this, "El precio ingresado no es valido");
                            return;
                        }
                        else
                        {
                            precio = decimal.Parse(strPrecio);
                            precio = decimal.Round(precio);
                        }
                    }

                    listaFiltrada = negocioFiltro.busquedaFiltrada(marca, tipo, precio, selector);
                    if (listaFiltrada.Count > 0)
                        Session.Add("cantidadFiltrados", listaFiltrada.Count);
                    else
                        Session.Add("cantidadFiltrados", 0);

                    count = (int)Session["cantidadFiltrados"];
                    rep_ListaDefautl.DataSource = listaFiltrada;
                    rep_ListaDefautl.DataBind();
                }
            }
            catch
            {
                PageUtils.Mensaje(this, "Error en el ingreso de campos");
                Response.Redirect("Default.aspx", false);
            }
        }
        //Boton Resetear Filtro
        protected void btnResetFiltro_Click(object sender, EventArgs e)
        {
            count = (int)Session["cantidadFiltrados"];
            Response.Redirect("Default.aspx", false);
        }
    }//
}