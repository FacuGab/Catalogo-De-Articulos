using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_de_Compras
{
    public partial class Login : System.Web.UI.Page
    {
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //METODOS
        //Boton Ingresar:
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            NegocioUsuario negocio = new NegocioUsuario();
            try
            {
                usuario = new Usuario(txtUsuario.Text, txtPass.Text, txtMail.Text);
                if(negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario No registrado");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        //Boton Cerrar Sesion:
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Remove("usuario");
                Response.Redirect("Login.aspx");
            }
        }
        //Boton ir a Registrar:
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }
    }
}