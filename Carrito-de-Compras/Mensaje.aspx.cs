using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_de_Compras
{
    public partial class Mensaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PageUtils.IsUserAdmin(Page, "El usuario no posee credenciales para acceder a esta pagina."))
            {
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string remitente = txtMail.Text;
            string cuerpo = txtCuerpo.Text;
            string asunto = txtAsunto.Text;
            EmailService email = new EmailService("catalogoscuentagenerica@gmail.com", "Admin_123456789");
            email.constructMail(remitente, asunto, cuerpo);
            try
            {
                email.sendMail();
                PageUtils.Mensaje(this, "Mensaje Enviado!");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}