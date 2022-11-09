using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Carrito_de_Compras
{
    public static class PageUtils
    {
        public static void Mensaje(Page page, string mensaje)
        {
            if (!string.IsNullOrWhiteSpace(mensaje))
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", $"alert('{mensaje}')", true);
        }

        public static bool IsUserAdmin(Page page, string msjError = "Error Inesperado")
        {
            if(page.Session["usuario"] == null)
            {
                page.Session.Add("error", msjError);
                return false;
            }
            else if (((Usuario)page.Session["usuario"]).Tipo == TipoUsuario.NORMAL)
            {
                page.Session.Add("error", msjError);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}