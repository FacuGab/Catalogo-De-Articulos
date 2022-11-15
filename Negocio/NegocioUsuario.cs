using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Negocio
{
    public class NegocioUsuario
    {
        //VARS
        public bool StateQuery { get; set; } = false;

        //METODOS
        //Login:
        public bool Login(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("SELECT Id, TipoUsuario, Mail FROM dbo.USUARIOS WHERE Usuario = @user AND Pass = @pass");
                datos.setearParametro("@user", user.User);
                datos.setearParametro("@pass", user.Pass);
                //datos.setearParametro("@mail", user.Mail); // dejar asi, usarlo en la query traeria problemas al tener registros nulos
                datos.ejecutarLectura();
                if(datos._lector.Read())
                {
                    user.Id = (int)datos._lector["Id"];
                    user.Tipo = (TipoUsuario)Convert.ToInt32(datos._lector["TipoUsuario"]);
                    if(datos._lector["Mail"] != null)
                        user.Mail = datos._lector["Mail"].ToString();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            } 
        }
        //Agregar usuario:
        public void RegistrarUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setSP("SP_AgregarUsuario");
                datos.setearParametro("@pUsuario", user.User);
                datos.setearParametro("@pPass", user.Pass);
                datos.setearParametro("@pTipoUsuario", Convert.ToInt16(user.Tipo));
                datos.setearParametro("@pMail", user.Mail);
                datos.ejecutarQuery();
                StateQuery = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }
    }
}
