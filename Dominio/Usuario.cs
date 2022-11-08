using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        ADMIN = 2,
        NORMAL = 1
    }
    public class Usuario
    {
        //VARS
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public TipoUsuario Tipo { get; set; }

        //CONSTRUCTOR
        public Usuario(){}
        public Usuario(string user, string pass, bool permiso)
        {
            User = user;
            Pass = pass;
            Tipo = permiso ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }
}
