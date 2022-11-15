using Dominio;
using Negocio;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_de_Compras
{
    public partial class Registro : System.Web.UI.Page
    {
        //VARS
        private Usuario user;
        private NegocioUsuario negocio;

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //METODOS
        //Boton Agregar:
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                user = new Usuario(txtUsuario.Text, txtPass.Text, txtMail.Text);
                negocio = new NegocioUsuario();
                negocio.RegistrarUsuario(user);
                if(negocio.StateQuery)//modificar
                {
                    PageUtils.Mensaje(this, "Usuario Registrado");
                    EmailService email = new EmailService();
                    string msj = $"Bienvenido a la app, {user.User}!";
                    email.constructMail(txtMail.Text, "Saludo", msj);
                    email.sendMail();
                }
                    
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}