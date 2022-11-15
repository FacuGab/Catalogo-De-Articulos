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
        public string Mail { get; set; }
        public TipoUsuario Tipo { get; set; }

        //CONSTRUCTORES
        public Usuario(){}
        public Usuario(string user, string pass, bool permiso = false)
        {
            User = user;
            Pass = pass;
            Tipo = permiso ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
        public Usuario(string user, string pass, string mail, bool permiso = false)
        {
            User = user;
            Pass = pass;
            Mail = mail;
            Tipo = permiso ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }
}
