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
        public bool Login(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("SELECT Id, TipoUsuario FROM dbo.USUARIOS WHERE Usuario = @user AND Pass = @pass");
                datos.setearParametro("@user", user.User);
                datos.setearParametro("@pass", user.Pass);
                datos.ejecutarLectura();

                while(datos._lector.Read())
                {
                    user.Id = (int)datos._lector["Id"];
                    //user.Tipo = Convert.ToInt32(datos._lector["TipoUsuario"]) == 1? user.Tipo = TipoUsuario.ADMIN : user.Tipo = TipoUsuario.NORMAL;
                    user.Tipo = (TipoUsuario)Convert.ToInt32(datos._lector["TipoUsuario"]);
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
    }
}
