using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Carrito_de_Compras
{
    public partial class Lista : System.Web.UI.Page
    {
        private List<Articulo> listaSeleccionados;
        private List<Articulo> listaCarrito;
        private decimal valorInicial;
        private decimal valorFinal;
        private decimal valorTotal;

        //Load:
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["listaCarrito"] == null)
                    Session.Add("listaCarrito", new List<Articulo>());
                listaCarrito = (List<Articulo>)Session["listaCarrito"];

                listaSeleccionados = (List<Articulo>)Session["listaSeleccionados"];
                if (listaSeleccionados == null)
                    return;

                foreach (Articulo articulo in listaSeleccionados)
                {
                    if (!listaCarrito.Exists(itm => itm._Id == articulo._Id))
                        listaCarrito.Add(articulo);
                }

                
                Session.Add("cantidad", listaSeleccionados.Count);
                rep_repetidor.DataSource = listaCarrito;
                rep_repetidor.DataBind();
            }

            valorTotal = (decimal)Session["montoParcial"];
            Session["montoParcial"] = 0.00M;
            lblTotal.Text = valorTotal.ToString() + " $";
        }
        //Metodos:
        //Buscador de codigo de articulos
        public string ArtRepetidos(string cod)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cod))
                    return "Nada";
                //se puede hacer mas simple, esta asi para que se lea mejor...
                string repetidos = ((Dictionary<string, int>)Session["uniXcodigo"])[cod].ToString();
                return repetidos;
            }
            catch
            {
                return "Nada";
            }
        }
        //Total acumulado por unidades
        public decimal TotalXunidades(string cod, decimal precio)
        {
            try
            {
                int cantidad = ((Dictionary<string, int>)Session["uniXcodigo"])[cod];
                decimal total = cantidad * precio;
                montoParcial(total);
                return total;
            }
            catch
            {
                return 0;
            }
        }
        //Calculo del monto $ acumulado en el carrito
        private void montoParcial(decimal monto)
        {
            if (Session["montoParcial"] != null)
            {
                valorInicial = (decimal)Session["montoParcial"];
                valorFinal = monto + valorInicial;
                Session.Add("montoParcial", valorFinal);
            }
        }
        //Resta de monto $ al quitar articulo del carrito
        private void restarMonto(decimal resta)
        {
            valorInicial = (decimal)Session["montoParcial"];
            valorFinal -= resta;
            if (valorFinal < 0)
                valorFinal = 0.0M;
            Session.Add("montoParcial", valorFinal);
        }
        //Boton Eliminar
        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            int cant;
            string codArt = ((Button)sender).CommandArgument;

            try
            {
                listaSeleccionados = (List<Articulo>)Session["listaSeleccionados"];
                if (listaSeleccionados == null)
                    return;

                cant = listaSeleccionados.Count;
                if (cant > 0)
                    Session.Add("cantidad", --cant);
                else
                    Session.Add("cantidad", 0);

                listaCarrito = (List<Articulo>)Session["listaCarrito"];
                Dictionary<string, int> uniXcodigo = (Dictionary<string, int>)Session["uniXcodigo"];
                int index = listaSeleccionados.FindIndex(itm => itm._codArticulo == codArt);
                if (uniXcodigo[codArt] > 1)
                {
                    restarMonto(listaSeleccionados[index]._precio);
                    listaSeleccionados.RemoveAt(index);
                    uniXcodigo[codArt]--;
                }
                else
                {
                    restarMonto(listaSeleccionados[index]._precio);
                    listaSeleccionados.RemoveAt(index);
                    listaCarrito.RemoveAt(listaCarrito.FindIndex(itm => itm._codArticulo == codArt));
                    uniXcodigo[codArt]--;
                }

                rep_repetidor.DataSource = listaCarrito;
                rep_repetidor.DataBind();
                valorTotal = (decimal)Session["montoParcial"];
                lblTotal.Text = valorTotal.ToString() + " $";
            }
            catch
            {
                Response.Redirect("Lista.aspx", false);
            }
        }
        //Boton Volver a Default.aspx
        protected void btnVolverLista_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }//
}