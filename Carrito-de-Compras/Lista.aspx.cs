﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session.Remove("listaSeleccionados");// <------
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

                rep_repetidor.DataSource = listaCarrito;
                rep_repetidor.DataBind();

                valorTotal = (decimal)Session["montoParcial"];
                Session["montoParcial"] = 0.00M;
                lblTotal.Text += valorTotal.ToString();
            }
        }
        //Metodos:
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
        private void montoParcial(decimal monto)
        {
            if (Session["montoParcial"] != null)
            {
                valorInicial = (decimal)Session["montoParcial"];
                valorFinal = monto + valorInicial;
                Session.Add("montoParcial", valorFinal);
            }
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            int cant;
            string codArt = ((Button)sender).CommandArgument;

            // sacar ?? 
            listaSeleccionados = (List<Articulo>)Session["listaSeleccionados"];
            if (listaSeleccionados == null)
                return;
            // sacar ??

            cant = listaSeleccionados.Count;
            if (cant > 0)
                Session.Add("cantidad", --cant);


            listaCarrito = (List<Articulo>)Session["listaCarrito"];
            Dictionary<string, int> uniXcodigo = (Dictionary<string, int>)Session["uniXcodigo"];
            if (uniXcodigo[codArt] > 1)
            {
                uniXcodigo[codArt]--;
                listaSeleccionados.RemoveAt(listaSeleccionados.FindIndex(itm => itm._codArticulo == codArt));
            }
            else
            {
                listaCarrito.RemoveAt(listaCarrito.FindIndex(itm => itm._codArticulo == codArt));
            }

            rep_repetidor.DataSource = listaCarrito;
            rep_repetidor.DataBind();
        }
    }
    //
}