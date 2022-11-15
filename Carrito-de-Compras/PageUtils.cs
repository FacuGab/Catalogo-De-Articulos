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
            if (!IsSessionActive(page.Session["usuario"]))
            {
                page.Session.Add("Error", "No hay una sesion activa de usuario");
                return false;
            }
            if ( ((Usuario)page.Session["usuario"]).Tipo == TipoUsuario.NORMAL )
            {
                page.Session.Add("error", msjError);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsSessionActive(object session)
        {
            if(session != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}