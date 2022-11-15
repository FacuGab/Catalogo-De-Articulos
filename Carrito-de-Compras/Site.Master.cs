using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_de_Compras
{
    public partial class Site : System.Web.UI.MasterPage
    {
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            // Confirmaciones de Tipo de Usuario:
            if ( (Page is Formulario || Page is DetalleDeArticulos ) )
            {
                if (!PageUtils.IsUserAdmin(Page, "No posees permisos para ver esto"))
                    Response.Redirect("Error.aspx");
            }
            else if(Page is Lista)
            {
                if (!PageUtils.IsSessionActive(Page.Session["usuario"]))
                {
                    Page.Session.Add("error", "Tienes que logearte para acceder al carrito");
                    Response.Redirect("Error.aspx");
                }
            }

            // Actualizamos nombre y nivel de usuario en nav:
            if (PageUtils.IsSessionActive(this.Page.Session["usuario"]))
            {
                string user = ((Usuario)Session["usuario"]).User;
                string tipo = ((Usuario)Session["usuario"]).Tipo.ToString();
                lblUsuarioNav.Text = "User:\n" + user;
                lblUsuarioTipoNav.Text = "Tipo:\n" + tipo;
            }
        }

        //METODOS
        // Boton Login:
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
        // Boton Cerrar Sesion:
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (PageUtils.IsSessionActive(this.Page))
            {
                Session.Remove("usuario");
                Response.Redirect("Default.aspx", false);
            }
        }
        // 
    }
}