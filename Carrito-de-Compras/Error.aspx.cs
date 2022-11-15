using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_de_Compras
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["error"] is Exception)
                    {
                        txaError.Text = ((Exception)Session["error"]).Message + "\n" + ((Exception)Session["error"]).InnerException.Message;
                    }
                    else
                    {
                        txaError.Text = Session["error"].ToString();
                    }
                }
                catch
                {
                    if (Session["usuario"] == null)
                        txaError.Text = "Usuario No ingresado";
                    else
                        txaError.Text = "Ocurrio un error inesperado";
                }
            }
        }
    }
}