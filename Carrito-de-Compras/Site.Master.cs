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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                string user = " "+((Usuario)Session["usuario"]).User;
                string tipo = " "+((Usuario)Session["usuario"]).Tipo.ToString();
                lblUsuarioNav.Text += user;
                lblUsuarioTipoNav.Text += tipo;
            }
        }
    }
}