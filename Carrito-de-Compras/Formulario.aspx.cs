using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_de_Compras
{
    public partial class Formulario : System.Web.UI.Page
    {
        public bool ConfirmarElminar { get; set; }
        public bool EventoBotonClick { get; set; }

        // LOAD:
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarElminar = false;
            EventoBotonClick = false;
            tbxId.Enabled = false;

            // cambio ->
            if(PageUtils.IsUserAdmin(Page))
            {
                if (!IsPostBack)
                {
                    try
                    {
                        NegocioDetalle detalle = new NegocioDetalle();
                        detalle.listarDosCategorias();
                        ddlCategoria.DataSource = detalle.listaCategorias;
                        ddlCategoria.DataValueField = "_Id";
                        ddlCategoria.DataTextField = "_Descripcion";
                        ddlCategoria.DataBind();

                        ddlMarca.DataSource = detalle.listaMarcas;
                        ddlMarca.DataValueField = "_Id";
                        ddlMarca.DataTextField = "_Descripcion";
                        ddlMarca.DataBind();

                        if (Request.QueryString["id"] != null)
                        {
                            btnAgregar.Text = "Modificar";
                            string id = Request.QueryString["id"].ToString();
                            NegocioArticulo negocio = new NegocioArticulo();
                            Articulo art = negocio.listarArticulos(0, id)[0];

                            tbxId.Text = id;
                            tbxId.Enabled = false;

                            tbxCodigo.Text = art._codArticulo;
                            tbxNombre.Text = art._nombre;
                            txaDescripcion.Text = art._descripcion;
                            ddlCategoria.SelectedValue = art._categoria._Id.ToString();
                            ddlMarca.SelectedValue = art._marca._Id.ToString();
                            tbxPrecio.Text = art._precio.ToString();
                            txbUrlImg.Text = art._urlImagen;
                            imgFormulario.ImageUrl = txbUrlImg.Text;
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", ex);
                        throw;
                    }
                }
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
            // <- cambio
        }

        // METODOS:
        // Evento Img_TextChanged
        protected void txbUrlImg_TextChanged(object sender, EventArgs e)
        {
            imgFormulario.ImageUrl = txbUrlImg.Text;
        }
        // Boton Agregar
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo artNuevo = new Articulo();
                NegocioArticulo negocio = new NegocioArticulo();
                artNuevo._codArticulo = tbxCodigo.Text;
                artNuevo._nombre = tbxNombre.Text;
                artNuevo._descripcion = txaDescripcion.Text;
                artNuevo._categoria._Id = int.Parse(ddlCategoria.SelectedValue);
                artNuevo._marca._Id = int.Parse(ddlMarca.SelectedValue);
                artNuevo._precio = decimal.Parse(tbxPrecio.Text);
                artNuevo._urlImagen = txbUrlImg.Text;
                if (Request.QueryString["id"] == null)
                {
                    negocio.agregarArticuloSP(artNuevo);
                    PageUtils.Mensaje(this, "Articulo Agregado");
                } 
                else
                {
                    artNuevo._Id = int.Parse(tbxId.Text);
                    negocio.modificarArticuloSP(artNuevo);
                    PageUtils.Mensaje(this, "Articulo Modificado");
                }
                Response.Redirect("Formulario.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        // Botones Elminar y Logicos:
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                ConfirmarElminar = true;
            else
                PageUtils.Mensaje(this, "No se puede eliminar un articulo sin seleccionar primero");
        }
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmarEliminar.Checked)
                {
                    NegocioArticulo negocio = new NegocioArticulo();
                    negocio.eliminarArticulo(int.Parse(tbxId.Text));
                    Response.Redirect("Formulario.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
        protected void btnEliminarLogica_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                NegocioArticulo negocio = new NegocioArticulo();
                negocio.eliminarArticulo(int.Parse(tbxId.Text), true); // true elimina logico
                Response.Redirect("Formulario.aspx", false);
            }
            else
            {
                PageUtils.Mensaje(this, "No se puede eliminar un articulo sin seleccionar primero");
            }
        }
        protected void btnAltaLogica_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                NegocioArticulo negocio = new NegocioArticulo();
                negocio.altaLogica(int.Parse(tbxId.Text)); // true elimina logico
                Response.Redirect("Formulario.aspx", false);
            }
            else
            {
                PageUtils.Mensaje(this, "No se puede eliminar un articulo sin seleccionar primero");
            }
        }
    }
}